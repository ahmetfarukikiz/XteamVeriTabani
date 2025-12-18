using Npgsql;
using XteamVeriTabani.Models;

namespace XteamVeriTabani;

public partial class KayitMenuForm : Form
{

    public KayitMenuForm()
    {
        InitializeComponent();
    }

   
    private void girisYapButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(kullaniciTextBox.Text) || string.IsNullOrWhiteSpace(sifreTextBox.Text))
        {
            MessageBox.Show("Lütfen kullanýcý adý ve þifrenizi giriniz.");
            return;
        }

        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            try
            {
                conn.Open();

                //fn_giris_yap ile hesap turu anlama
                string hesapTurSql = "SELECT * FROM fn_giris_yap(@kadi, @sifre)";

                int gelenId = 0;
                string gelenRolString = "";

                using (NpgsqlCommand cmd = new NpgsqlCommand(hesapTurSql, conn))
                {
                    cmd.Parameters.AddWithValue("@kadi", kullaniciTextBox.Text);
                    cmd.Parameters.AddWithValue("@sifre", sifreTextBox.Text);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gelenId = Convert.ToInt32(reader["id"]);
                            gelenRolString = reader["rol"].ToString();
                        }
                    }
                }

                // Eðer ID 0 geldiyse veya rol "Hatali" ise giriþ baþarýsýzdýr
                if (gelenId == 0 || gelenRolString == "Hatali")
                {
                    MessageBox.Show("Kullanýcý adý veya þifre hatalý!", "Giriþ Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }


                //asýl detaylarý çeken ikinci sorgu
                string sqlDetay = "";

                HesapTuru hesapTur = (gelenRolString == "Gelistirici") ? HesapTuru.Gelistirici : HesapTuru.Oyuncu;

                if (hesapTur == HesapTuru.Gelistirici)
                {
                    sqlDetay = @"SELECT h.hesap_adi, h.eposta, g.web_sitesi, g.vergi_no 
                                     FROM HESAP h 
                                     JOIN GELISTIRICI g ON h.id = g.gelistirici_id 
                                     WHERE h.id = @id";
                }
                else
                {
                    sqlDetay = @"SELECT h.hesap_adi, h.eposta, o.seviye 
                                     FROM HESAP h 
                                     JOIN OYUNCU o ON h.id = o.oyuncu_id 
                                     WHERE h.id = @id";
                }

                string hesapAdi = "";
                string eposta = "";
                string webSitesi = null;
                string vergiNo = null;
                int seviye = 1;

                using (NpgsqlCommand cmdDetay = new NpgsqlCommand(sqlDetay, conn))
                {
                    cmdDetay.Parameters.AddWithValue("@id", gelenId);

                    using (NpgsqlDataReader reader = cmdDetay.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hesapAdi = reader["hesap_adi"].ToString();
                            eposta = reader["eposta"].ToString();

                            if (hesapTur == HesapTuru.Gelistirici)
                            {
                                webSitesi = reader["web_sitesi"].ToString();
                                vergiNo = reader["vergi_no"].ToString();
                            }
                            else
                            {
                                seviye = Convert.ToInt32(reader["seviye"]);
                            }
                        }
                    }
                }

                //statik sýnýf verilerini doldur
                Oturum.GirisYap(gelenId, hesapAdi, kullaniciTextBox.Text, eposta, seviye, hesapTur);

                if (hesapTur == HesapTuru.Gelistirici)
                {
                    Oturum.WebSitesi = webSitesi;
                    Oturum.VergiNo = vergiNo;
                }

                AnaMenuForm anaMenuForm = new AnaMenuForm();
                anaMenuForm.Opacity = 0;
                anaMenuForm.Show();
                anaMenuForm.Opacity = 1;
                anaMenuForm.FormClosed += (s, args) => this.Show(); //kapandýðýnda AnaMenuyu tekrar göstericek
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void kayitOlButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(kepostaTB.Text) ||
            string.IsNullOrWhiteSpace(khesapadiTB.Text) ||
            string.IsNullOrWhiteSpace(kkullaniciadiTB.Text) ||
            string.IsNullOrWhiteSpace(ksifreTB.Text))
        {
            MessageBox.Show("Lütfen zorunlu alanlarý doldurunuz.");
            return;
        }

        if (kturComboBox.Text == "Geliþtirici" && string.IsNullOrWhiteSpace(kverginoTB.Text))
        {
            MessageBox.Show("Geliþtiriciler için Vergi No zorunludur!");
            return;
        }


        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            try
            {
                conn.Open();

                string sql = "SELECT fn_kayit_ol(@eposta, @ad, @kadi, @sifre, @tur, @vergi, @web)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@eposta", kepostaTB.Text);
                    cmd.Parameters.AddWithValue("@ad", khesapadiTB.Text);
                    cmd.Parameters.AddWithValue("@kadi", kkullaniciadiTB.Text);
                    cmd.Parameters.AddWithValue("@sifre", ksifreTB.Text);

                    string hesapTuru = kturComboBox.Text == "Geliþtirici" ? "Gelistirici" : "Oyuncu";
                    cmd.Parameters.AddWithValue("@tur", hesapTuru);

                    if (hesapTuru == "Gelistirici")
                    {
                        cmd.Parameters.AddWithValue("@vergi", kverginoTB.Text);

                        // websitesi boþ býrakýldýysa null gitsin.
                        if (string.IsNullOrWhiteSpace(kwebsitesiTB.Text))
                            cmd.Parameters.AddWithValue("@web", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@web", kwebsitesiTB.Text);
                    }
                    else
                    {
                        // Oyuncu ise Vergi ve Web Sitesi NULL olacak
                        cmd.Parameters.AddWithValue("@vergi", DBNull.Value);
                        cmd.Parameters.AddWithValue("@web", DBNull.Value);
                    }

                    int yeniId = (int)cmd.ExecuteScalar();

                    MessageBox.Show($"Kayýt Baþarýlý!\nHesap ID: {yeniId}\nÞimdi giriþ yapabilirsiniz.");
                    KayitBilgileriniTemizle();
                }
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                    MessageBox.Show("Bu E-posta veya Kullanýcý Adý zaten kullanýlýyor!");
                else
                    MessageBox.Show("VT Hatasý: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }

    private void KayitBilgileriniTemizle()
    {
        kepostaTB.Text = "";
        kverginoTB.Text = "";
        kkullaniciadiTB.Text = "";
        khesapadiTB.Text = "";
        ksifreTB.Text = "";
        kwebsitesiTB.Text = "";
        kturComboBox.SelectedIndex = -1;
    }

    private void kturComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (kturComboBox.Text == "Geliþtirici")
        {
            kverginoTB.Enabled = true;
            kwebsitesiTB.Enabled = true;

        }
        else
        {
            kverginoTB.Enabled = false;
            kwebsitesiTB.Enabled = false;
        }
    }

    private void KayitMenuForm_Load(object sender, EventArgs e)
    {
        sifreTextBox.PasswordChar = '*';
    }
}
