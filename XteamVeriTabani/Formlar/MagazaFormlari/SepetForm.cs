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

namespace XteamVeriTabani.Formlar.MagazaFormlari
{
    public partial class SepetForm : Form
    {
        public SepetForm()
        {
            InitializeComponent();
        }

        private void SepetForm_Load(object sender, EventArgs e)
        {
            SepetiListele();
            GetBakiye();
        }

        private void SepetiListele()
        {
            sepetListBox.Items.Clear();
            decimal genelToplam = 0;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();


                string sql = @"
                    SELECT s.sepet_id, o.oyun_id, o.baslik, o.fiyat, 
                           k.baslik as KampanyaAdi, k.indirim_orani
                    FROM SEPET s
                    JOIN OYUN o ON s.oyun_id = o.oyun_id
                    LEFT JOIN KAMPANYA k ON o.kampanya_id = k.kampanya_id
                    WHERE s.oyuncu_id = @uid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sepetId = Convert.ToInt32(reader["sepet_id"]);
                            int oyunId = Convert.ToInt32(reader["oyun_id"]);
                            string oyunAdi = reader["baslik"].ToString();
                            decimal normalFiyat = Convert.ToDecimal(reader["fiyat"]);

                            string kampanyaAdi = reader["KampanyaAdi"] != DBNull.Value ? reader["KampanyaAdi"].ToString() : "";
                            int indirimOrani = reader["indirim_orani"] != DBNull.Value ? Convert.ToInt32(reader["indirim_orani"]) : 0;

                            decimal satisFiyati = normalFiyat;
                            string listeYazisi = "";

                            if (indirimOrani > 0)
                            {
                                //indirim hesabı
                                decimal indirimMiktari = normalFiyat * indirimOrani / 100;
                                satisFiyati = normalFiyat - indirimMiktari;

                                listeYazisi = $"{oyunAdi} | {normalFiyat:N0} TL -> {satisFiyati:N2} TL (%{indirimOrani}) indirim";
                            }
                            else
                            {
                                satisFiyati = normalFiyat;
                                listeYazisi = $"{oyunAdi} - {satisFiyati:N2} ₺";
                            }

                            SepetOgesi oge = new SepetOgesi
                            {
                                SepetId = sepetId,
                                OyunId = oyunId,
                                SatisFiyati = satisFiyati,
                                GorunumMetni = listeYazisi
                            };

                            sepetListBox.Items.Add(oge);

                            genelToplam += satisFiyati;
                        }
                    }
                }
            }

            toplamTurarLabel.Text = "Toplam Tutar: " + genelToplam.ToString("N2") + " ₺";
        }


        private void GetBakiye()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT cuzdan_bakiyesi FROM OYUNCU WHERE oyuncu_id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Oturum.HesapID);
                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null)
                        bakiyeLabel.Text = "Bakiye: " + Convert.ToDecimal(sonuc).ToString("N2") + " TL";
                }
            }
        }

        public class SepetOgesi
        {
            public int SepetId { get; set; }
            public int OyunId { get; set; }
            public decimal SatisFiyati { get; set; } //indirimli fiyatın tutulduğu yer
            public string GorunumMetni { get; set; }

            public override string ToString()
            {
                return GorunumMetni; //listboxta görünen değişken
            }
        }

        private void sepettenSilBtn_Click(object sender, EventArgs e)
        {
            if (sepetListBox.SelectedItem == null) return;

            SepetOgesi secilen = (SepetOgesi)sepetListBox.SelectedItem;

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();
                string sql = "DELETE FROM SEPET WHERE sepet_id = @sid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", secilen.SepetId);
                    cmd.ExecuteNonQuery();
                }
            }

            SepetiListele();
        }

        private void siparisiTamamlaBtn_Click(object sender, EventArgs e)
        {

            if (sepetListBox.Items.Count == 0)
            {
                MessageBox.Show("Sepetiniz boş");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT fn_satin_al(@uid)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);

                        object sonuc = cmd.ExecuteScalar();
                        string mesaj = sonuc != null ? sonuc.ToString() : "Hata";

                        if (mesaj == "Basarili")
                        {
                            MessageBox.Show("Oyunlar kütüphanenize eklendi.", "Satın Alım Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SepetiListele();
                            GetBakiye();
                        }
                        else if (mesaj == "Yetersiz Bakiye")
                        {
                            MessageBox.Show("Yeterli bakiye yok", "Hatas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (mesaj == "Sepet Boş")
                        {
                            MessageBox.Show("Sepetinizde ürün bulunamadı.");
                        }
                        else
                        {
                            MessageBox.Show("İşlem başarısız: " + mesaj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }
    }
}
