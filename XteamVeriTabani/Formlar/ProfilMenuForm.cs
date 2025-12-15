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

namespace XteamVeriTabani
{
    public partial class ProfilMenuForm : Form
    {
        private int _hesapID;
        public ProfilMenuForm(int HesapId)
        {
            _hesapID = HesapId;
            InitializeComponent();
        }

        private void ProfilMenuForm_Load(object sender, EventArgs e)
        {
            ProfilBilgileriniGetir();
        }
        private void ProfilBilgileriniGetir()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    // SENİN VERİTABANINA TAM UYUMLU SQL SORGUSU
                    // h.son_giris_tarihi YERİNE h.son_giris YAPILDI
                    string sql = @"
                        SELECT h.hesap_adi, h.kayit_tarihi, h.son_giris, o.seviye
                        FROM HESAP h
                        JOIN OYUNCU o ON h.id = o.oyuncu_id
                        WHERE h.id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _hesapID);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hesapAdiLabel.Text = reader["hesap_adi"].ToString();

                                if (reader["seviye"] != DBNull.Value)
                                    seviyeLabel.Text = reader["seviye"].ToString();
                                else
                                    seviyeLabel.Text = "1";

                                if (reader["kayit_tarihi"] != DBNull.Value)
                                {
                                    DateTime kayit = Convert.ToDateTime(reader["kayit_tarihi"]);
                                    kayitTarihiLabel.Text = kayit.ToString("dd.MM.yyyy");
                                }
                                else
                                {
                                    kayitTarihiLabel.Text = "-";
                                }

                                if (reader["son_giris"] != DBNull.Value)
                                {
                                    DateTime sonGiris = Convert.ToDateTime(reader["son_giris"]);
                                    sonGirisLabel.Text = sonGiris.ToString("dd.MM.yyyy HH:mm");
                                }
                                else
                                {
                                    sonGirisLabel.Text = "-";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Profil yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }


    }

}
