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
using XteamVeriTabani.Formlar.MagazaFormlari;
using XteamVeriTabani.Models;

namespace XteamVeriTabani
{
    public partial class MagazaMenuForm : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public MagazaMenuForm()
        {
            InitializeComponent();
        }
        private void oyunlarListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void MagazaMenuForm_Load(object sender, EventArgs e)
        {
            OyunlariListele();
            KategoriComboBoxuAyarla();
            GetBakiye();

            if(Oturum.IsGelistirici()) { 
                sepetButton.Visible = false;
                bakiyeLabel.Visible = false;
                bakiyeEkleButton.Visible = false;
            }
        }

        private void KategoriComboBoxuAyarla()
        {
            kategoriComboBox.Items.Clear();

            ComboboxItem tumu = new ComboboxItem();
            tumu.Text = "Tüm Kategoriler";
            tumu.Value = 0; 
            kategoriComboBox.Items.Add(tumu);

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM KATEGORI";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Value = Convert.ToInt32(reader["kategori_id"]); 
                            item.Text = reader["tur_adi"].ToString();      

                            kategoriComboBox.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori hatası: " + ex.Message);
                }
            }

            // 4. Varsayılan olarak "Tüm Kategoriler" seçili gelsin
            kategoriComboBox.SelectedIndex = 0;
        }

    


        private void OyunlariListele(string aramaMetni = "", int kategoriId = 0)
        {
            oyunlarListBox.DataSource = null;
            oyunlarListBox.Items.Clear();
            List<Oyun> oyunListesi = new List<Oyun>();

            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    // SAKLI YORDAMI ÇAĞIRIYORUZ
                    string sql = "SELECT * FROM sp_oyun_ara(@metin, @katId)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@metin", aramaMetni);
                        cmd.Parameters.AddWithValue("@katId", kategoriId);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Oyun oyun = new Oyun();
                                oyun.OyunId = Convert.ToInt32(reader["oyun_id"]);
                                oyun.Baslik = reader["baslik"].ToString();
                                oyun.Fiyat = Convert.ToDecimal(reader["fiyat"]);

                                oyun.KampanyaAdi = reader["kampanya_adi"] != DBNull.Value ? reader["kampanya_adi"].ToString() : "";
                                int indOran = reader["indirim_orani"] != DBNull.Value ? Convert.ToInt32(reader["indirim_orani"]) : 0;
                                oyun.IndirimOrani = indOran;
                                oyunListesi.Add(oyun);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
            }

            oyunlarListBox.DataSource = oyunListesi;
            oyunlarListBox.DisplayMember = "ListeGorunumu";
            oyunlarListBox.ValueMember = "OyunId";
        }

        private void OyunuAraButton_Click(object sender, EventArgs e)
        {
            string aranan = oyunAdiTB.Text.Trim();

            int secilenKategoriId = 0;
            if (kategoriComboBox.SelectedItem != null)
            {
                ComboboxItem item = (ComboboxItem)kategoriComboBox.SelectedItem;
                secilenKategoriId = item.Value;
            }

            OyunlariListele(aranan, secilenKategoriId);
        }

        private void oyunuGorButton_Click(object sender, EventArgs e)
        {
            Oyun secilenOyun = (Oyun)oyunlarListBox.SelectedItem;

            if (secilenOyun != null)
            {
                int oyunId = secilenOyun.OyunId;

                MagazaOyunForm magazaOyunForm = new MagazaOyunForm(oyunId);
                magazaOyunForm.ShowDialog();
            }
        }

        private void sepetButton_Click(object sender, EventArgs e)
        {
            SepetForm sepetForm = new SepetForm();
            sepetForm.ShowDialog();
            GetBakiye();
        }

        private void oyunlarListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oyunlarListBox.SelectedItem != null)
            {
                oyunuGorButton.Enabled = true;
            }
            else
            {
                oyunuGorButton.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        //200 bakiye ekler
        private void bakiyeEkleButton_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
            {
                try
                {
                    conn.Open();

                    string sql = "UPDATE OYUNCU SET cuzdan_bakiyesi = cuzdan_bakiyesi + 200 WHERE oyuncu_id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Oturum.HesapID);

                        cmd.ExecuteNonQuery();
                        GetBakiye();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
