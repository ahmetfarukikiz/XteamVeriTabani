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
    public partial class KampanyaEkleForm : Form
    {
        public KampanyaEkleForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baslangicTarihiDP.Value = DateTime.Now;
            bitisTarihiDP.Value = DateTime.Now.AddDays(7); // Varsayılan 1 hafta sonrası
        }

        private void EkleButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kampanyaAdiTB.Text))
            {
                MessageBox.Show("Lütfen kampanya adını giriniz.");
                return;
            }

            if (Convert.ToInt32(indirimOraniTB.Text) <= 0)
            {
                MessageBox.Show("İndirim oranı 0'dan büyük olmalıdır.");
                return;
            }

            string kampanyaAdi = kampanyaAdiTB.Text.Trim();
            DateTime baslangic = baslangicTarihiDP.Value;
            DateTime bitis = bitisTarihiDP.Value;
            int indirimOrani = Convert.ToInt32(indirimOraniTB.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                conn.Open();

                try
                {
                    string sql = @"
                        INSERT INTO KAMPANYA (baslik, baslangic_tarihi, bitis_tarihi, indirim_orani, aktif_mi)
                        VALUES (@baslik, @bas, @bit, @oran, true)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@baslik", kampanyaAdi);
                        cmd.Parameters.AddWithValue("@bas", baslangic);
                        cmd.Parameters.AddWithValue("@bit", bitis);
                        cmd.Parameters.AddWithValue("@oran", indirimOrani);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kampanya başarıyla oluşturuldu.");
                        this.Close();
                    }
                }
                catch (PostgresException ex)
                {

                     MessageBox.Show("Veritabanı Hatası: " + ex.MessageText);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
