using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XteamVeriTabani.KutuphaneMenuForm;

namespace XteamVeriTabani
{
    public partial class ArkadasMenuForm : Form
    {
        public ArkadasMenuForm()
        {
            InitializeComponent();
        }

        private void ArkadasMenuForm_Load(object sender, EventArgs e)
        {

            ArkadasliklariListele();
        }

        private void ArkadasliklariListele()
        {
            arkadasListBox.Items.Clear(); // Kabul edilmiş arkadaşlar listbox'ı
            gelenIstekListBox.Items.Clear();       // Gelen istekler listbox'ı

            // Bağlantı cümlesini Oturum sınıfından alıyoruz
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    // mevcut arkadaşları listeleyen sql
                    // DEĞİŞİKLİK: kullanıcı_adı -> hesap_adi
                    string arkadasSql = @"
                        SELECT h.hesap_adi, h.id 
                        FROM ARKADASLIK a
                        JOIN HESAP h ON (a.istek_alan_id = h.id OR a.istek_gonderen_id = h.id)
                        WHERE (a.istek_gonderen_id = @oyuncuId OR a.istek_alan_id = @oyuncuId)
                        AND h.id != @oyuncuId
                        AND a.durum_id = 2"; // 2: Kabul Edildi

                    using (NpgsqlCommand cmd = new NpgsqlCommand(arkadasSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oyuncuId", Oturum.HesapID);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                arkadasListBox.Items.Add(new ArkadasListBoxItem
                                {
                                    // DEĞİŞİKLİK: okurken de hesap_adi
                                    KullaniciAdi = reader["hesap_adi"].ToString(),
                                    ArkadasId = Convert.ToInt32(reader["id"]) // Arkadaşın ID'si
                                });
                            }
                        }
                    }

                    // Gelen istekleri listeleyen sql
                    // DEĞİŞİKLİK: kullanıcı_adı -> hesap_adi
                    string istekSql = @"
                        SELECT a.istek_gonderen_id, h.hesap_adi
                        FROM ARKADASLIK a
                        JOIN HESAP h ON a.istek_gonderen_id = h.id
                        WHERE a.istek_alan_id = @oyuncuId AND a.durum_id = 1"; // 1: Beklemede

                    using (NpgsqlCommand cmd = new NpgsqlCommand(istekSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oyuncuId", Oturum.HesapID);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gelenIstekListBox.Items.Add(new ArkadasListBoxItem
                                {
                                    // DEĞİŞİKLİK: okurken de hesap_adi
                                    KullaniciAdi = reader["hesap_adi"].ToString(),
                                    ArkadasId = Convert.ToInt32(reader["istek_gonderen_id"]) // İsteği atanın ID'si
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
            }
        }

        public class ArkadasListBoxItem
        {
            public int ArkadasId { get; set; }      // Karşı tarafın ID'si
            public string KullaniciAdi { get; set; } // ListBox'ta görünecek isim

            public override string ToString()
            {
                return KullaniciAdi;
            }
        }

        private void arkadasEkleButton_Click(object sender, EventArgs e)
        {
            string hedefKullaniciAdi = kAdiTB.Text.Trim();
            int aktifId = Oturum.HesapID;

            if (string.IsNullOrEmpty(hedefKullaniciAdi)) return;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();

                int hedefId = 0;

                // isimden id bulma
                // DEĞİŞİKLİK: kullanıcı_adı -> hesap_adi
                string kulBulSql = @"
                SELECT o.oyuncu_id 
                FROM OYUNCU o
                JOIN HESAP h ON o.oyuncu_id = h.id 
                WHERE h.hesap_adi = @ad";

                using (NpgsqlCommand bulSorgu = new NpgsqlCommand(kulBulSql, conn))
                {
                    bulSorgu.Parameters.AddWithValue("@ad", hedefKullaniciAdi);
                    object result = bulSorgu.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Kullanıcı bulunamadı.");
                        return;
                    }
                    hedefId = Convert.ToInt32(result);
                }

                //zaten arkadaş olan biriyse isteği engelle
                string kontrolSql = @"
                SELECT durum_id FROM ARKADASLIK 
                WHERE (istek_gonderen_id = @gonderenId AND istek_alan_id = @alanId)
                   OR (istek_gonderen_id = @alanId AND istek_alan_id = @gonderenId)";

                using (NpgsqlCommand kontrolSorgu = new NpgsqlCommand(kontrolSql, conn))
                {
                    kontrolSorgu.Parameters.AddWithValue("@gonderenId", aktifId);
                    kontrolSorgu.Parameters.AddWithValue("@alanId", hedefId);

                    object durumObj = kontrolSorgu.ExecuteScalar();

                    if (durumObj != null)
                    {
                        int mevcutDurum = Convert.ToInt32(durumObj);

                        if (mevcutDurum == 2)
                        {
                            MessageBox.Show("Bu kullanıcıyla zaten arkadaşsınız.");
                            return;
                        }
                        else if (mevcutDurum == 1)
                        {
                            MessageBox.Show("Zaten bu kullanıcıya giden veya gelen bir isteğiniz var");
                            return;
                        }
                    }
                }

                // istek Gönderme
                try
                {
                    string istekSql = @"
                        INSERT INTO ARKADASLIK (istek_gonderen_id, istek_alan_id, durum_id, arkadaslik_tarihi)
                        VALUES (@gonderenId, @alanId, 1, CURRENT_TIMESTAMP)";

                    using (NpgsqlCommand istekSorgu = new NpgsqlCommand(istekSql, conn))
                    {
                        istekSorgu.Parameters.AddWithValue("@gonderenId", aktifId);
                        istekSorgu.Parameters.AddWithValue("@alanId", hedefId);
                        istekSorgu.ExecuteNonQuery();
                        MessageBox.Show("Arkadaşlık isteği gönderildi.");
                    }
                }
                catch (NpgsqlException ex) when (ex.SqlState == "23505") //zaten arkadaşlarsa veya istek gönderilmiş ise
                {
                    MessageBox.Show("Bu kullanıcı zaten listenizde veya beklemede olan bir isteğiniz var.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İstek gönderme hatası: " + ex.Message);
                }
            }
        }

        private void kabuletBtn_Click(object sender, EventArgs e) => IstekCevapla(2);
        private void reddetBtn_Click(object sender, EventArgs e) => IstekCevapla(3);


        private void IstekCevapla(int yeniDurum)
        {
            if (gelenIstekListBox.SelectedItem == null)
            {
                MessageBox.Show("Lütfen gelen isteklerden birini seçin.");
                return;
            }

            ArkadasListBoxItem secilen = (ArkadasListBoxItem)gelenIstekListBox.SelectedItem;
            int aktifId = Oturum.HesapID;
            int gonderenId = secilen.ArkadasId; // İsteği atan kişinin ID'si

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();
                    string durumUpdateSql = @"
                        UPDATE ARKADASLIK 
                        SET durum_id = @yeniDurum 
                        WHERE istek_gonderen_id = @gonderenId AND istek_alan_id = @alanId";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(durumUpdateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@yeniDurum", yeniDurum); // 2: Kabul, 3: Red
                        cmd.Parameters.AddWithValue("@gonderenId", gonderenId);
                        cmd.Parameters.AddWithValue("@alanId", aktifId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem hatası: " + ex.Message);
                }
            }
            ArkadasliklariListele();
            ButtonlariKontrolEt();

        }

        private void arkadasListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonlariKontrolEt();

        }

        private void gelenIstekListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonlariKontrolEt();
        }

        private void ButtonlariKontrolEt()
        {
            if (gelenIstekListBox.SelectedItem != null)
            {
                kabuletBtn.Enabled = true;
                reddetBtn.Enabled = true;
            }
            else
            {
                kabuletBtn.Enabled = false;
                reddetBtn.Enabled = false;
            }

            if (arkadasListBox.SelectedItem != null)
            {
                hesabiGorButton.Enabled = true;
                silButton.Enabled = true;
            }
            else
            {
                hesabiGorButton.Enabled = false;
                silButton.Enabled = false;
            }
        }


        private void silButton_Click(object sender, EventArgs e)
        {
            ArkadasListBoxItem secilenKisi = (ArkadasListBoxItem)arkadasListBox.SelectedItem;
            int arkadasId = secilenKisi.ArkadasId;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    string arkadasSilSql = @"
                    DELETE FROM ARKADASLIK 
                    WHERE (istek_gonderen_id = @userid AND istek_alan_id = @arkadasId)
                       OR (istek_gonderen_id = @arkadasId AND istek_alan_id = @userid)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(arkadasSilSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", Oturum.HesapID);
                        cmd.Parameters.AddWithValue("@arkadasId", arkadasId);

                        int etkilenen = cmd.ExecuteNonQuery();

                        if (etkilenen > 0)
                        {
                            ArkadasliklariListele();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu veya kayıt zaten yok.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatası: " + ex.Message);
                }
            }
            ButtonlariKontrolEt();
        }

        private void hesabiGorButton_Click(object sender, EventArgs e)
        {

            ArkadasListBoxItem secilenArkadas = (ArkadasListBoxItem)arkadasListBox.SelectedItem;

            if (secilenArkadas is null) return;

            int arkadasId;
            arkadasId = secilenArkadas.ArkadasId;

            ProfilMenuForm profilMenuForm = new ProfilMenuForm(arkadasId);
            profilMenuForm.ShowDialog();
        }
    }
}