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

namespace XteamVeriTabani.Formlar.KutuphaneFormlari
{
    public partial class KutuphaneOyunForm : Form
    {

        private int _oyunId;
        private int _mevcutDurumId;
        private decimal _iadeEdilecekTutar;
        public KutuphaneOyunForm(int oyunID)
        {
            InitializeComponent();
            _oyunId = oyunID;
        }

        private void KutuphaneOyunForm_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    //oyundetaylarını çeken sorgu
                    string sqlGenel = @"
                        SELECT 
                            o.baslik, o.aciklama, o.yukleme_boyutu,
                            h.hesap_adi, 
                            ok.oynama_suresi, ok.alinma_tarihi, ok.durum_id, od.durum_adi
                        FROM OYUN_KULLANICI ok
                        JOIN OYUN o ON ok.oyun_id = o.oyun_id
                        JOIN GELISTIRICI g ON o.gelistirici_id = g.gelistirici_id
                        JOIN HESAP h ON g.gelistirici_id = h.id
                        JOIN OYUN_DURUMU od ON ok.durum_id = od.durum_id
                        WHERE ok.oyun_id = @gid AND ok.oyuncu_id = @uid";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlGenel, conn))
                    {
                        cmd.Parameters.AddWithValue("@gid", _oyunId);
                        cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oyunBaslikLabel.Text = reader["baslik"].ToString();
                                oyunAciklamaRTB.Text = reader["aciklama"].ToString();
                                gelistiriciLabel.Text = reader["hesap_adi"].ToString();
                                yuklemeBoyutuLabel.Text = reader["yukleme_boyutu"].ToString() + " GB";
                                oynamaSuresiLabel.Text = reader["oynama_suresi"].ToString() + " saat";

                                DateTime tarih = Convert.ToDateTime(reader["alinma_tarihi"]);
                                alinmaTarihiLabel.Text = tarih.ToShortDateString();

                                durumLabel.Text = reader["durum_adi"].ToString();
                                _mevcutDurumId = Convert.ToInt32(reader["durum_id"]);

                                ButtonGuncelle();
                            }
                        }
                    }

                    //oyunun zamanında kaç paraya alındığı bilgisi
                    string sqlFiyat = @"
                        SELECT sd.satis_fiyati 
                        FROM SIPARIS_DETAY sd
                        JOIN SIPARIS s ON sd.siparis_id = s.siparis_id
                        WHERE s.oyuncu_id = @uid AND sd.oyun_id = @gid
                        ORDER BY s.siparis_tarihi DESC 
                        LIMIT 1";

                    using (NpgsqlCommand cmdFiyat = new NpgsqlCommand(sqlFiyat, conn))
                    {
                        cmdFiyat.Parameters.AddWithValue("@uid", Oturum.HesapID);
                        cmdFiyat.Parameters.AddWithValue("@gid", _oyunId);

                        object sonuc = cmdFiyat.ExecuteScalar();
                        if (sonuc != null)
                        {
                            _iadeEdilecekTutar = Convert.ToDecimal(sonuc);
                        }
                        else
                        {
                            // Eğer sipariş kaydı bulunamazsa (Örn: Hediye geldiyse veya DB elle değiştirildiyse)
                            _iadeEdilecekTutar = 0;
                        }
                    }

                    // 3. ListBox Doldurma (Kategori ve Dil)
                    GetListBoxData(conn, "SELECT k.tur_adi FROM OYUN_KATEGORI ok JOIN KATEGORI k ON ok.kategori_id = k.kategori_id WHERE ok.oyun_id = @id", kategoriListBox);
                    GetListBoxData(conn, "SELECT d.dil_adi FROM OYUN_DIL od JOIN DIL d ON od.dil_id = d.dil_id WHERE od.oyun_id = @id", dilListBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri hatası: " + ex.Message);
                }
            }
        }

        private void ButtonGuncelle()
        {

            if (_mevcutDurumId == 2)
            {
                oyunuYukleSilButton.Text = "Sil (Kaldır)";
                oyunuAcButton.Enabled = true;
            }
            else
            {
                oyunuYukleSilButton.Text = "Yükle";
                oyunuAcButton.Enabled = false;
            }
        }

        private void GetListBoxData(NpgsqlConnection conn, string sql, ListBox lb)
        {
            lb.Items.Clear();
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) lb.Items.Add(reader[0].ToString());
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void oyunuYukleSilButton_Click(object sender, EventArgs e)
        {
            // Durum değişimi: 2 ise 1 yap, 1 ise 2 yap
            int yeniDurumId = (_mevcutDurumId == 2) ? 1 : 2;
            string islemAdi = (yeniDurumId == 2) ? "Yükleme" : "Kaldırma";

            // Bekleme efekti
            Cursor.Current = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(600);
            Cursor.Current = Cursors.Default;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();

                // SENİN GÖNDERDİĞİN SQL (Update)
                // Not: Tablomuzda sütun adı 'durum_id' olduğu için sorguyu ona göre yazdım.
                string sql = @"UPDATE OYUN_KULLANICI 
                               SET durum_id = @yeniDurumId 
                               WHERE oyuncu_id = @oyuncuId AND oyun_id = @oyunId";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@yeniDurumId", yeniDurumId);
                    cmd.Parameters.AddWithValue("@oyuncuId", Oturum.HesapID);
                    cmd.Parameters.AddWithValue("@oyunId", _oyunId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Oyun başarıyla {islemAdi} işlemi tamamlandı.");
            VerileriGetir(); // Ekranı yenile
        }

        //her basıldığında 10dk oynanmış gibi yapar
        private void oyunuAcButton_Click(object sender, EventArgs e)
        {
            int eklenenSure = 1;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    // süreyi update eder
                    string updateSql = @"
                        UPDATE OYUN_KULLANICI 
                        SET oynama_suresi = oynama_suresi + @sure
                        WHERE oyuncu_id = @uid AND oyun_id = @gid";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sure", eklenenSure);
                        cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);
                        cmd.Parameters.AddWithValue("@gid", _oyunId); // Formun başındaki global değişken

                        int etkilenen = cmd.ExecuteNonQuery();

                        if (etkilenen > 0)
                        {
                            MessageBox.Show($"Oyun başlatıldı...\n{eklenenSure} saat oynandı.", $"{oyunBaslikLabel.Text}");
                        }
                        else
                        {
                            MessageBox.Show("Hata: Oyun kütüphanenizde bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oyun açılırken hata oluştu: " + ex.Message);
                }
            }
            VerileriGetir();
        }

        private void iadeEtButton_Click(object sender, EventArgs e)
        {
            // İade tutarı 0 ise (Hediye vs.) uyarı verelim ama işleme izin verelim
            string fiyatMesaj = _iadeEdilecekTutar > 0
                ? $"{_iadeEdilecekTutar:N2} TL cüzdanınıza iade edilecek."
                : "Bu oyun için ödenecek bir iade tutarı bulunamadı (Ücretsiz veya Hediye).";

            DialogResult cevap = MessageBox.Show(
                $"Bu oyunu iade etmek istediğinize emin misiniz?\n\n{fiyatMesaj}\nOyun kütüphanenizden kalıcı olarak silinecek.",
                "İade Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                IadeIsleminiYap();
            }
        }

        private void IadeIsleminiYap()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Oyunu Kütüphaneden Sil
                        string sqlSil = "DELETE FROM OYUN_KULLANICI WHERE oyuncu_id = @uid AND oyun_id = @gid";
                        using (NpgsqlCommand cmdSil = new NpgsqlCommand(sqlSil, conn))
                        {
                            cmdSil.Parameters.AddWithValue("@uid", Oturum.HesapID);
                            cmdSil.Parameters.AddWithValue("@gid", _oyunId);
                            cmdSil.ExecuteNonQuery();
                        }

                        // 2. Parayı Cüzdana İade Et (Sadece tutar 0'dan büyükse)
                        if (_iadeEdilecekTutar > 0)
                        {
                            string sqlPara = "UPDATE OYUNCU SET cuzdan_bakiyesi = cuzdan_bakiyesi + @tutar WHERE oyuncu_id = @uid";
                            using (NpgsqlCommand cmdPara = new NpgsqlCommand(sqlPara, conn))
                            {
                                cmdPara.Parameters.AddWithValue("@tutar", _iadeEdilecekTutar);
                                cmdPara.Parameters.AddWithValue("@uid", Oturum.HesapID);
                                cmdPara.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("İade işlemi başarılı.");
                        this.Close(); // Formu kapat
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("İade hatası: " + ex.Message);
                    }
                }
            }
        }
    }
}
