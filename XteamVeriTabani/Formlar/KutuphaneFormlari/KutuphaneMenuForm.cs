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
using XteamVeriTabani.Formlar;
using XteamVeriTabani.Formlar.KutuphaneFormlari;
using XteamVeriTabani.Models;

namespace XteamVeriTabani;

public partial class KutuphaneMenuForm : Form
{
    public KutuphaneMenuForm()
    {
        InitializeComponent();
    }

    private void oyunuGorButton_Click(object sender, EventArgs e)
    {

        KutuphaneOgesi secilenOyun = (KutuphaneOgesi)oyunlarListBox.SelectedItem;

        if (secilenOyun is null) return;

        int oyunId;
        oyunId = secilenOyun.OyunId;

        if (Oturum.IsOyuncu())
        {
            KutuphaneOyunForm kutuphaneOyunForm = new KutuphaneOyunForm(oyunId);
            kutuphaneOyunForm.ShowDialog();
        }
        else
        {
            MagazaOyunForm magazaOyunForm = new MagazaOyunForm(oyunId);
            magazaOyunForm.ShowDialog();
        }

        OyunlariListele(); //bir değişiklik olma ihtimali sebebiyle oyunları tekrar yükle
    }

    private void KutuphaneMenuForm_Load(object sender, EventArgs e)
    {
        OyunlariListele();
    }

    private void OyunlariListele()
    {
        if (Oturum.IsGelistirici())
        {
            oyunEkleButton.Visible = true;
            oyunDuzenleButton.Visible = true;
            oyunuGorButton.Text = "Magazada Gor";
            GelistiriciOyunlariniListele();
        }
        else //oyuncuysa
        {
            oyunEkleButton.Visible = false;
            oyunDuzenleButton.Visible = false;

            OyuncuKutuphanesiniListele();
        }
    }

    private void OyuncuKutuphanesiniListele()
    {
        oyunlarListBox.Items.Clear();

        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            try
            {
                conn.Open();
                //oyuncunun sahip olduğu oyunları çeker
                string sql = @"
                        SELECT o.oyun_id, o.baslik, ok.oynama_suresi, ok.alinma_tarihi, od.durum_adi
                        FROM OYUN_KULLANICI ok
                        JOIN OYUN o ON ok.oyun_id = o.oyun_id
                        JOIN OYUN_DURUMU od ON ok.durum_id = od.durum_id
                        WHERE ok.oyuncu_id = @uid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KutuphaneOgesi oge = new KutuphaneOgesi
                            {
                                GelistiriciMi = false,
                                OyunId = Convert.ToInt32(reader["oyun_id"]),
                                Baslik = reader["baslik"].ToString(),
                                Durum = reader["durum_adi"].ToString(),
                                OynamaSuresi = reader["oynama_suresi"].ToString(),
                                AlinmaTarihi = Convert.ToDateTime(reader["alinma_tarihi"]).ToShortDateString()
                            };
                            oyunlarListBox.Items.Add(oge);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kütüphane yüklenirken hata: " + ex.Message);
            }
        }
    }

    private void GelistiriciOyunlariniListele()
    {
        oyunlarListBox.Items.Clear();

        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            try
            {
                conn.Open();

                // Geliştiricinin yaptığı oyunları çeker
                string sql = @"SELECT oyun_id, baslik, fiyat, indirilme_sayisi 
                                   FROM OYUN 
                                   WHERE gelistirici_id = @gid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@gid", Oturum.HesapID); // HesapID geliştirici ID ile aynı tabloda

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KutuphaneOgesi oge = new KutuphaneOgesi
                            {
                                GelistiriciMi = true,
                                OyunId = Convert.ToInt32(reader["oyun_id"]),
                                Baslik = reader["baslik"].ToString(),
                                Fiyat = Convert.ToDecimal(reader["fiyat"]),
                                IndirilmeSayisi = Convert.ToInt32(reader["indirilme_sayisi"])
                            };
                            oyunlarListBox.Items.Add(oge);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyunlarınız listelenirken hata: " + ex.Message);
            }
        }
    }
    public class KutuphaneOgesi
    {
        public int OyunId { get; set; }
        public string Baslik { get; set; }
        public string Durum { get; set; }        // Oyuncu için (Yüklü, Silindi vb.)
        public string OynamaSuresi { get; set; } // Oyuncu için
        public string AlinmaTarihi { get; set; } // Oyuncu için

        // Geliştirici için alanlar
        public decimal Fiyat { get; set; }
        public int IndirilmeSayisi { get; set; }
        public bool GelistiriciMi { get; set; }

        // ListBox'ta nasıl görüneceğini ayarlayan kısım
        public override string ToString()
        {
            if (GelistiriciMi)
            {
                // Geliştirici Görünümü
                string fiyatYazi = Fiyat == 0 ? "Ücretsiz" : Fiyat.ToString("N2") + " TL";
                return $"{Baslik}  |  Fiyat: {fiyatYazi}  |  Toplam İndirilme: {IndirilmeSayisi}";
            }
            else
            {
                return $"{Baslik}  |  Durum: {Durum} |  Alınma: {AlinmaTarihi}";
            }
        }
    }

    private void oyunDuzenleButton_Click(object sender, EventArgs e)
    {
        KutuphaneOgesi secilenOyun = (KutuphaneOgesi)oyunlarListBox.SelectedItem;

        if (secilenOyun is null) return;

        int oyunId;
        oyunId = secilenOyun.OyunId;

        OyunEkleDuzenleForm oyunEkleDuzenleForm = new OyunEkleDuzenleForm(oyunId);
        oyunEkleDuzenleForm.ShowDialog();
        OyunlariListele();
    }

    private void oyunEkleButton_Click(object sender, EventArgs e)
    {
        OyunEkleDuzenleForm oyunEkleDuzenleForm = new OyunEkleDuzenleForm();
        oyunEkleDuzenleForm.ShowDialog();
        OyunlariListele();
    }
}
