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
using XteamVeriTabani.Models;

namespace XteamVeriTabani
{
    public partial class MagazaMenuForm : Form
    {
        public MagazaMenuForm()
        {
            InitializeComponent();
        }
        private void oyunlarListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //oyunugör butonu yerine çift tıklanarak da seçili oyunun işlemi yapılabilir
        }

        private void MagazaMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void oyunuGorButton_Click(object sender, EventArgs e)
        {
            MagazaOyunForm magazaOyunForm = new MagazaOyunForm(/*buraya oyunun kendisi veya özellikleri parametre olarak gidicek*/0);
            magazaOyunForm.ShowDialog();
        }
    }
}
