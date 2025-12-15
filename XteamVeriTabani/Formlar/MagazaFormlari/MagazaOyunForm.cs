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
using XteamVeriTabani.Models;

namespace XteamVeriTabani.Formlar;

public partial class MagazaOyunForm : Form
{
    private int _oyunId;
    public MagazaOyunForm(int oyunid)
    {
        _oyunId = oyunid;
        InitializeComponent();
    }

    private void MagazaOyunForm_Load(object sender, EventArgs e)
    {
        DilDgwAyari();
        SqlVerisiCek();
        if (Oturum.IsOyuncu()) SahiplikKontrolu();
        else if (Oturum.IsGelistirici()) sepeteEkleButton.Enabled = false;

    }

    private void SahiplikKontrolu()
    {

        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            conn.Open();

            // Bu oyun, bu kullanıcının kütüphanesinde var mı?
            string sql = "SELECT COUNT(*) FROM OYUN_KULLANICI WHERE oyun_id = @gid AND oyuncu_id = @uid";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@gid", _oyunId); // Formun başındaki oyunId
                cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);

                // Sonuç 0'dan büyükse satın alınmış demektir
                long sonuc = (long)cmd.ExecuteScalar();

                if (sonuc > 0)
                {
                    // BUTONU KAPATIYORUZ
                    sepeteEkleButton.Enabled = false;
                    sepeteEkleButton.Text = "Satın Alındı";
                }
            }
        }
    }

    private void SqlVerisiCek()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            conn.Open();

            string sqlOyun = @"
                    SELECT 
                        o.baslik, 
                        o.aciklama, 
                        o.fiyat, 
                        o.yukleme_boyutu, 
                        o.cikis_tarihi, 
                        o.indirilme_sayisi,
                        h.hesap_adi, -- Geliştiricinin görünen adı HESAP tablosunda
                        k.indirim_orani
                    FROM OYUN o
                    JOIN GELISTIRICI g ON o.gelistirici_id = g.gelistirici_id
                    JOIN HESAP h ON g.gelistirici_id = h.id
                    LEFT JOIN KAMPANYA k ON o.kampanya_id = k.kampanya_id
                    WHERE o.oyun_id = @id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlOyun, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oyunBaslikLabel.Text = reader["baslik"].ToString();
                        oyunAciklamaRTB.Text = reader["aciklama"].ToString();
                        gelistiriciLabel.Text = reader["hesap_adi"].ToString();

                        DateTime cikisTarihi = Convert.ToDateTime(reader["cikis_tarihi"]);
                        cikisTarihiLabel.Text = cikisTarihi.ToShortDateString();

                        yuklemeBoyutuLabel.Text = reader["yukleme_boyutu"].ToString() + " GB";
                        indirilmeSayisiLabel.Text = reader["indirilme_sayisi"].ToString() + " İndirme";

                        // Fiyat Formatı
                        decimal fiyat = Convert.ToDecimal(reader["fiyat"]);

                        // İndirim oranını kontrol et (Null ise 0 al)
                        int indirimOrani = reader["indirim_orani"] != DBNull.Value ? Convert.ToInt32(reader["indirim_orani"]) : 0;

                        if (indirimOrani > 0 && fiyat > 0)
                        {
                            decimal indirimliFiyat = fiyat - (fiyat * indirimOrani / 100);

                            oyunFiyatLabel.Text = $"{fiyat:N2}TL  ->  {indirimliFiyat:N2}TL";

                            if (kampanyaLabel != null)
                            {
                                kampanyaLabel.Text = $"%{indirimOrani} İNDİRİM";
                                kampanyaLabel.Visible = true;
                            }
                        }
                        else
                        {
                            // İndirim yoksa normal göster
                            oyunFiyatLabel.Text = fiyat == 0 ? "Ücretsiz" : fiyat.ToString("N2") + " TL";
                            oyunFiyatLabel.ForeColor = Color.Black; // Normal renk

                            // İndirim etiketini gizle
                            if (kampanyaLabel != null) kampanyaLabel.Visible = false;
                        }

                        this.Text = oyunBaslikLabel.Text + " - Detay"; // Form başlığı
                    }
                }
            } 


            string sqlKategori = @"
                    SELECT k.tur_adi 
                    FROM OYUN_KATEGORI ok
                    JOIN KATEGORI k ON ok.kategori_id = k.kategori_id
                    WHERE ok.oyun_id = @id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlKategori, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    kategoriListBox.Items.Clear(); // ListBox'ı temizle
                    while (reader.Read())
                    {
                        kategoriListBox.Items.Add(reader["tur_adi"].ToString());
                    }
                }
            }

            string sqlDil = @"
                    SELECT d.dil_adi, od.altyazi_var_mi, od.seslendirme_var_mi
                    FROM OYUN_DIL od
                    JOIN DIL d ON od.dil_id = d.dil_id
                    WHERE od.oyun_id = @id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlDil, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    dilDataGridView.Rows.Clear();
                    while (reader.Read())
                    {
                        // Verileri ata
                        string dilAdi = reader["dil_adi"].ToString();
                        bool altyazi = Convert.ToBoolean(reader["altyazi_var_mi"]);
                        bool ses = Convert.ToBoolean(reader["seslendirme_var_mi"]);

                        // Grid'e satır olarak ekle
                        dilDataGridView.Rows.Add(dilAdi, altyazi, ses);
                    }
                }
            }
        }
    }

    private void sepeteEkleButton_Click(object sender, EventArgs e)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            try
            {
                conn.Open();

                string sql = "INSERT INTO SEPET (oyuncu_id, oyun_id, eklenme_tarihi) VALUES (@uid, @gid, CURRENT_TIMESTAMP)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Oturum.HesapID);
                    cmd.Parameters.AddWithValue("@gid", _oyunId); // Bu formun en başında tanımladığımız _oyunId

                    cmd.ExecuteNonQuery();

                    sepeteEkleButton.Enabled = false;
                    sepeteEkleButton.Text = "Sepette";
                }
            }
            catch (PostgresException ex)
            {
                // 23505: Unique Violation (Zaten ekli hatası)
                if (ex.SqlState == "23505")
                    MessageBox.Show("Bu oyun zaten sepetinizde.");
                else
                    MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }

    private void DilDgwAyari()
    {
        dilDataGridView.Columns.Clear();

        // 1. Dil Adı Sütunu
        dilDataGridView.Columns.Add("dil", "Dil");
        dilDataGridView.Columns["dil"].Width = 100;

        // 2. Altyazı Sütunu (CheckBox)
        DataGridViewCheckBoxColumn chkAltyazi = new DataGridViewCheckBoxColumn();
        chkAltyazi.HeaderText = "Altyazı";
        chkAltyazi.Name = "altyazi";
        chkAltyazi.Width = 60;
        dilDataGridView.Columns.Add(chkAltyazi);

        // 3. Seslendirme Sütunu (CheckBox)
        DataGridViewCheckBoxColumn chkSes = new DataGridViewCheckBoxColumn();
        chkSes.HeaderText = "Seslendirme";
        chkSes.Name = "ses";
        chkSes.Width = 80;
        dilDataGridView.Columns.Add(chkSes);

        // Sadece okunabilir olsun
        dilDataGridView.ReadOnly = true;
    }
}
