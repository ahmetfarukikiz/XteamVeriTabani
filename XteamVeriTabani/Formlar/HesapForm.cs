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

namespace XteamVeriTabani
{
    public partial class HesapForm : Form
    {

        private int _hesapID;

        public HesapForm(int hesapID)
        {
            InitializeComponent();
            _hesapID = hesapID;
        }

        private void HesapForm_Load(object sender, EventArgs e)
        {
            sifreTB.PasswordChar = '*';
            HesapBilgileriniGetir();
        }

        private void HesapBilgileriniGetir()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            h.kullanici_adi, 
                            h.sifre, 
                            h.hesap_adi, 
                            h.eposta,
                            g.web_sitesi, 
                            g.vergi_no
                        FROM HESAP h
                        LEFT JOIN GELISTIRICI g ON h.id = g.gelistirici_id
                        WHERE h.id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Oturum.HesapID);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ortak alanlar
                                kullaniciAdiTB.Text = reader["kullanici_adi"].ToString();
                                sifreTB.Text = reader["sifre"].ToString();
                                hesapAdiTB.Text = reader["hesap_adi"].ToString();
                                hesapAdiLabel.Text = reader["hesap_adi"].ToString();
                                epostaTB.Text = reader["eposta"].ToString();

                                // geliştiriciyse
                                if (Oturum.IsGelistirici())
                                {
                                    vergiNoTB.Text = reader["vergi_no"].ToString();

                                    if (reader["web_sitesi"] != DBNull.Value)
                                        webSitesiTB.Text = reader["web_sitesi"].ToString();
                                    else
                                        webSitesiTB.Text = "";

                                    GelistiriciAlanlariniGoster(true);
                                }
                                else
                                {
                                    GelistiriciAlanlariniGoster(false);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilgiler yüklenirken hata: " + ex.Message);
                }
            }
        }

        private void GelistiriciAlanlariniGoster(bool gosterilsinMi)
        {
            wblabel.Visible = gosterilsinMi;
            vnlabel.Visible = gosterilsinMi;
            vergiNoTB.Visible = gosterilsinMi;
            webSitesiTB.Visible = gosterilsinMi;
        }

        private void duzenleButton_Click(object sender, EventArgs e)
        {
            kullaniciAdiTB.ReadOnly = false;
            sifreTB.ReadOnly = false;
            hesapAdiTB.ReadOnly = false;
            epostaTB.ReadOnly = false;
            webSitesiTB.ReadOnly = false;
            vergiNoTB.ReadOnly = false;
        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kullaniciAdiTB.Text) ||
                string.IsNullOrWhiteSpace(sifreTB.Text) ||
                string.IsNullOrWhiteSpace(hesapAdiTB.Text) ||
                string.IsNullOrWhiteSpace(epostaTB.Text))
            {
                MessageBox.Show("Temel bilgileri boş bırakamazsınız.");
                return;
            }

            if (Oturum.IsGelistirici() && string.IsNullOrWhiteSpace(vergiNoTB.Text))
            {
                MessageBox.Show("Vergi No zorunludur.");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    // HESAP TABLOSU GÜNCELLEME (HERKES İÇİN) ---
                    string hesapUpdateSql = @"
                        UPDATE HESAP 
                        SET kullanici_adi = @kadi, sifre = @sifre, hesap_adi = @hadi, eposta = @eposta
                        WHERE id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(hesapUpdateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kadi", kullaniciAdiTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@sifre", sifreTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@hadi", hesapAdiTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@eposta", epostaTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", Oturum.HesapID);
                        cmd.ExecuteNonQuery();
                    }

                    // GELİŞTİRİCİ TABLOSU GÜNCELLEME (geliştiriciyse)
                    if (Oturum.IsGelistirici())
                    {
                        string gelistiriciUpdateSql = @"
                            UPDATE GELISTIRICI
                            SET vergi_no = @vergino, web_sitesi = @web
                            WHERE gelistirici_id = @id";

                        using (NpgsqlCommand cmdGel = new NpgsqlCommand(gelistiriciUpdateSql, conn))
                        {
                            cmdGel.Parameters.AddWithValue("@vergino", vergiNoTB.Text.Trim());

                            if (string.IsNullOrEmpty(webSitesiTB.Text.Trim()))
                                cmdGel.Parameters.AddWithValue("@web", DBNull.Value);
                            else
                                cmdGel.Parameters.AddWithValue("@web", webSitesiTB.Text.Trim());

                            cmdGel.Parameters.AddWithValue("@id", Oturum.HesapID);
                            cmdGel.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Bilgiler güncellendi.");

                    //kutuları düzenlemeyi kapat
                    kullaniciAdiTB.ReadOnly = true;
                    sifreTB.ReadOnly = true;
                    hesapAdiTB.ReadOnly = true;
                    epostaTB.ReadOnly = true;
                    webSitesiTB.ReadOnly = true;
                    vergiNoTB.ReadOnly = true;
                }
                catch (NpgsqlException ex)
                {
                    if (ex.SqlState == "23505")
                        MessageBox.Show("Bu kullanıcı adı veya e-posta zaten kullanılıyor.");
                    else
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
    }
}
