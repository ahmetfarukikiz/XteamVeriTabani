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

namespace XteamVeriTabani.Formlar
{
    public partial class SatinAlimlarForm : Form
    {
        public SatinAlimlarForm()
        {
            InitializeComponent();
        }

        private void SatinAlimlarForm_Load(object sender, EventArgs e)
        {
            TabloAyarlari();
            satinAlimlariListele();
        }

        private void TabloAyarlari()
        {
            if (satinAlimDGW.Rows.Count > 0)
            {
                satinAlimDGW.Columns["Tarih"].Width = 150;
                satinAlimDGW.Columns["Oyun Adı"].Width = 500;
                satinAlimDGW.Columns["Fiyat"].Width = 100;
                satinAlimDGW.Columns["Fiyat"].DefaultCellStyle.Format = "C2"; // Para birimi formatı (TL)
                satinAlimDGW.Columns["Durum"].Width = 120;
            }
        }

        private void satinAlimlariListele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    //satın alımlar listelenir (sipariş detay) sonra kütüphanede var mı diye bakılır yoksa iade edildi yazılır.
                    string sql = @"
                        SELECT 
                            s.siparis_tarihi as ""Tarih"", 
                            o.baslik as ""Oyun Adı"", 
                            sd.satis_fiyati as ""Fiyat"",
                            CASE 
                                WHEN ok.oyun_id IS NOT NULL THEN 'Kütüphanede'
                                ELSE 'İade Edildi' 
                            END as ""Durum""
                        FROM SIPARIS s
                        JOIN SIPARIS_DETAY sd ON s.siparis_id = sd.siparis_id
                        JOIN OYUN o ON sd.oyun_id = o.oyun_id
                        LEFT JOIN OYUN_KULLANICI ok ON o.oyun_id = ok.oyun_id AND ok.oyuncu_id = s.oyuncu_id
                        WHERE s.oyuncu_id = @oyuncuId
                        ORDER BY s.siparis_tarihi DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oyuncuId", Oturum.HesapID);

                        // DataGridView için en kolayı DataTable kullanmaktır
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        satinAlimDGW.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Geçmiş yüklenirken hata: " + ex.Message);
                }
            }
        }
    }
}
