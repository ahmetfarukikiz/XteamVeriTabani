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

namespace XteamVeriTabani
{
    public partial class KutuphaneMenuForm : Form
    {
        public KutuphaneMenuForm()
        {
            InitializeComponent();
        }



        private void oyunuGorButton_Click(object sender, EventArgs e)
        {
            KutuphaneOyunForm kutuphaneOyunForm = new KutuphaneOyunForm(/*buraya oyunun kendisi veya özellikleri parametre olarak gidicek*/0);
            kutuphaneOyunForm.ShowDialog();
        }

    }
}
