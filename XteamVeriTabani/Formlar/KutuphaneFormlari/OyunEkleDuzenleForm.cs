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

namespace XteamVeriTabani.Formlar.KutuphaneFormlari;

public partial class OyunEkleDuzenleForm : Form
{

    public class VeriItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    private int _oyunID = 0; // 0 ise Ekleme, >0 ise Düzenleme

    // Constructor 1: Yeni Ekleme
    public OyunEkleDuzenleForm()
    {
        InitializeComponent();
        _oyunID = 0;
        oyunEkleBtn.Text = "Oyun Ekle";
        this.Text = "Yeni Oyun Ekle";
    }

    // Constructor 2: Düzenleme
    public OyunEkleDuzenleForm(int duzenlenecekOyunID)
    {
        InitializeComponent();
        _oyunID = duzenlenecekOyunID;
        oyunEkleBtn.Text = "Değişiklikleri Kaydet";
        this.Text = "Oyun Düzenle";
    }

    private void OyunEkle_Load(object sender, EventArgs e)
    {
        GridAyarlariniYap();
        ComboveListBoxDoldur(); // Önce ComboBox ve CheckList'leri doldur

        if (_oyunID > 0)
        {
            OyunBilgileriniGetir();
        }
    }

    // comboBox ve Listeleri Doldurur
    private void ComboveListBoxDoldur()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            conn.Open();

            // A. Kampanyaları Doldur
            kampanyaComboBox.Items.Clear();
            kampanyaComboBox.Items.Add(new VeriItem { Text = "Kampanya Yok", Value = 0 }); // Varsayılan

            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT kampanya_id, baslik FROM KAMPANYA WHERE aktif_mi = true", conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    kampanyaComboBox.Items.Add(new VeriItem
                    {
                        Value = Convert.ToInt32(reader["kampanya_id"]),
                        Text = reader["baslik"].ToString()
                    });
                }
            }
            kampanyaComboBox.SelectedIndex = 0; // "Kampanya Yok" seçili gelsin

            // B. Kategorileri Doldur
            kategoriCheckBox.Items.Clear();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT kategori_id, tur_adi FROM KATEGORI", conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    kategoriCheckBox.Items.Add(new VeriItem
                    {
                        Value = Convert.ToInt32(reader["kategori_id"]),
                        Text = reader["tur_adi"].ToString()
                    });
                }
            }

            // C. Diller (GRID DOLDURMA)
            dgvDiller.Rows.Clear();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT dil_id, dil_adi FROM DIL", conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Grid'e satır ekle: ID, Dil Adı, Altyazı(False), Ses(False)
                    dgvDiller.Rows.Add(reader["dil_id"], reader["dil_adi"].ToString(), false, false);
                }
            }
        }
    }


    private void OyunBilgileriniGetir()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            conn.Open();

            // Temel Bilgiler
            string sql = "SELECT * FROM OYUN WHERE oyun_id = @id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunID);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oyunAdiTextBox.Text = reader["baslik"].ToString();
                        fiyatTB.Text = reader["fiyat"].ToString();
                        yuklemeBoyutuTB.Text = reader["yukleme_boyutu"].ToString();
                        aciklamaRTB.Text = reader["aciklama"].ToString();

                        // Kampanya Seçimi
                        if (reader["kampanya_id"] != DBNull.Value)
                        {
                            int kmpId = Convert.ToInt32(reader["kampanya_id"]);
                            // ComboBox'ta bu ID'yi bul ve seç
                            foreach (VeriItem item in kampanyaComboBox.Items)
                            {
                                if (item.Value == kmpId)
                                {
                                    kampanyaComboBox.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // Kategorileri İşaretle 
            string katSql = "SELECT kategori_id FROM OYUN_KATEGORI WHERE oyun_id = @id";
            List<int> seciliKategoriler = new List<int>();
            using (NpgsqlCommand cmd = new NpgsqlCommand(katSql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunID);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) seciliKategoriler.Add(Convert.ToInt32(reader[0]));
                }
            }

            for (int i = 0; i < kategoriCheckBox.Items.Count; i++)
            {
                VeriItem item = (VeriItem)kategoriCheckBox.Items[i];
                if (seciliKategoriler.Contains(item.Value))
                    kategoriCheckBox.SetItemChecked(i, true);
            }

            // Dilleri ve Özelliklerini İşaretle 
            string dilSql = "SELECT dil_id, altyazi_var_mi, seslendirme_var_mi FROM OYUN_DIL WHERE oyun_id = @id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(dilSql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _oyunID);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dbDilId = Convert.ToInt32(reader["dil_id"]);
                        bool altyazi = Convert.ToBoolean(reader["altyazi_var_mi"]);
                        bool ses = Convert.ToBoolean(reader["seslendirme_var_mi"]);

                        // Grid'deki satırları gez, ID eşleşirse kutucukları işaretle
                        foreach (DataGridViewRow row in dgvDiller.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["id"].Value) == dbDilId)
                            {
                                row.Cells["altyazi"].Value = altyazi;
                                row.Cells["ses"].Value = ses;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    // eğer gelen id 0 dan büyükse yani gerçek bir değer geldiyse düzenleme yapar bir değer gelmediyse 0 varsayar ve ekleme yapar
    private void oyunEkleDuzenleButton(object sender, EventArgs e)
    {
        // Basit Validasyon
        if (string.IsNullOrWhiteSpace(oyunAdiTextBox.Text) || string.IsNullOrWhiteSpace(fiyatTB.Text))
        {
            MessageBox.Show("Oyun Adı ve Fiyat zorunludur!");
            return;
        }

        // Geliştirici ID'sini al (HesapID aslında geliştirici ID'sidir JOIN mantığına göre)
        int gelistiriciId = Oturum.HesapID;
        int kampanyaId = 0;
        if (kampanyaComboBox.SelectedItem != null)
            kampanyaId = ((VeriItem)kampanyaComboBox.SelectedItem).Value;

        decimal fiyat = Convert.ToDecimal(fiyatTB.Text);
        int boyut = string.IsNullOrEmpty(yuklemeBoyutuTB.Text) ? 0 : Convert.ToInt32(yuklemeBoyutuTB.Text);

        using (NpgsqlConnection conn = new NpgsqlConnection(Oturum.BaglantiCumlesi))
        {
            conn.Open();
            NpgsqlTransaction trans = conn.BeginTransaction(); // Hata olursa her şeyi geri almak için

            try
            {
                int islenenOyunID = _oyunID;

                if (_oyunID == 0) //EKLEME  
                {
                    string insertSql = @"
                            INSERT INTO OYUN (baslik, fiyat, cikis_tarihi, yukleme_boyutu, aciklama, gelistirici_id, kampanya_id, indirilme_sayisi)
                            VALUES (@baslik, @fiyat, CURRENT_DATE, @boyut, @aciklama, @gelId, @kmpId, 0)
                            RETURNING oyun_id"; // Eklenen oyunun ID'sini geri al

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@baslik", oyunAdiTextBox.Text);
                        cmd.Parameters.AddWithValue("@fiyat", fiyat);
                        cmd.Parameters.AddWithValue("@boyut", boyut);
                        cmd.Parameters.AddWithValue("@aciklama", aciklamaRTB.Text);
                        cmd.Parameters.AddWithValue("@gelId", gelistiriciId);

                        if (kampanyaId > 0) cmd.Parameters.AddWithValue("@kmpId", kampanyaId);
                        else cmd.Parameters.AddWithValue("@kmpId", DBNull.Value);

                        islenenOyunID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                else //GÜNCELLEME
                {
                    string updateSql = @"
                            UPDATE OYUN 
                            SET baslik=@baslik, fiyat=@fiyat, yukleme_boyutu=@boyut, aciklama=@aciklama, kampanya_id=@kmpId
                            WHERE oyun_id=@oyunId";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@baslik", oyunAdiTextBox.Text);
                        cmd.Parameters.AddWithValue("@fiyat", fiyat);
                        cmd.Parameters.AddWithValue("@boyut", boyut);
                        cmd.Parameters.AddWithValue("@aciklama", aciklamaRTB.Text);

                        if (kampanyaId > 0) cmd.Parameters.AddWithValue("@kmpId", kampanyaId);
                        else cmd.Parameters.AddWithValue("@kmpId", DBNull.Value);

                        cmd.Parameters.AddWithValue("@oyunId", _oyunID);
                        cmd.ExecuteNonQuery();
                    }

                    // Güncellemede ilişkili tabloları temizleyip yeniden eklemek en kolayıdır
                    new NpgsqlCommand("DELETE FROM OYUN_KATEGORI WHERE oyun_id=" + _oyunID, conn, trans).ExecuteNonQuery();
                    new NpgsqlCommand("DELETE FROM OYUN_DIL WHERE oyun_id=" + _oyunID, conn, trans).ExecuteNonQuery();
                }

                // --- İLİŞKİLİ TABLOLAR (KATEGORİ & DİL) ---

                // 1. Kategorileri Ekle
                foreach (VeriItem item in kategoriCheckBox.CheckedItems)
                {
                    string katIns = "INSERT INTO OYUN_KATEGORI (oyun_id, kategori_id) VALUES (@oid, @kid)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(katIns, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@oid", islenenOyunID);
                        cmd.Parameters.AddWithValue("@kid", item.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                // 3. DİLLERİ VE DETAYLARINI EKLE (GRID'DEN)
                foreach (DataGridViewRow row in dgvDiller.Rows)
                {
                    // Checkbox değerlerini güvenli şekilde al (Null gelebilir)
                    bool altyazi = Convert.ToBoolean(row.Cells["altyazi"].Value ?? false);
                    bool ses = Convert.ToBoolean(row.Cells["ses"].Value ?? false);

                    // Eğer en az biri seçiliyse veritabanına ekle
                    if (altyazi || ses)
                    {
                        int dilId = Convert.ToInt32(row.Cells["id"].Value);

                        // Burada parametreler dinamik (altyazi, seslendirme)
                        string dilIns = "INSERT INTO OYUN_DIL (oyun_id, dil_id, altyazi_var_mi, seslendirme_var_mi) VALUES (@oid, @did, @alt, @ses)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(dilIns, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@oid", islenenOyunID);
                            cmd.Parameters.AddWithValue("@did", dilId);
                            cmd.Parameters.AddWithValue("@alt", altyazi);
                            cmd.Parameters.AddWithValue("@ses", ses);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                trans.Commit(); // İşlemi onayla
                MessageBox.Show("İşlem başarıyla tamamlandı.");
                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                trans.Rollback(); // Hata varsa her şeyi iptal et
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }


    private void GridAyarlariniYap()
    {
        dgvDiller.Columns.Clear();

        // ID Sütunu (Gizli)
        dgvDiller.Columns.Add("id", "ID");
        dgvDiller.Columns["id"].Visible = false;

        // Dil Adı Sütunu (Sadece okunur)
        dgvDiller.Columns.Add("ad", "Dil");
        dgvDiller.Columns["ad"].ReadOnly = true;
        dgvDiller.Columns["ad"].Width = 100;

        // Altyazı Checkbox Sütunu
        DataGridViewCheckBoxColumn chkAltyazi = new DataGridViewCheckBoxColumn();
        chkAltyazi.HeaderText = "Altyazı";
        chkAltyazi.Name = "altyazi";
        chkAltyazi.Width = 60;
        dgvDiller.Columns.Add(chkAltyazi);

        // Seslendirme Checkbox Sütunu
        DataGridViewCheckBoxColumn chkSes = new DataGridViewCheckBoxColumn();
        chkSes.HeaderText = "Seslendirme";
        chkSes.Name = "ses";
        chkSes.Width = 80;
        dgvDiller.Columns.Add(chkSes);
    }
}
