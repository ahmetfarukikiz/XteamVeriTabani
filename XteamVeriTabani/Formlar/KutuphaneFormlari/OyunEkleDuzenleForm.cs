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
    public partial class OyunEkleDuzenleForm : Form
    {

        private int OyunID = 0;
        public OyunEkleDuzenleForm()
        {
            InitializeComponent();
            oyunEkleBtn.Text = "Oyun Ekle";
            this.Text = "Yeni Oyun Ekle";
        }

        public OyunEkleDuzenleForm(int duzenlenecekOyunID)
        {
            OyunID = duzenlenecekOyunID;
            InitializeComponent();
            oyunEkleBtn.Text = "Oyunu Duzenle";
            this.Text = "Oyun Düzenle";
        }


        private void OyunEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
