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
    public partial class AnaMenuForm : Form
    {
        public AnaMenuForm()
        {
            InitializeComponent();
        }

        private void magazaButton_Click(object sender, EventArgs e)
        {
            MagazaMenuForm magazaMenuForm = new MagazaMenuForm();
            magazaMenuForm.Opacity = 0;
            magazaMenuForm.Show();
            magazaMenuForm.Location = this.Location;
            magazaMenuForm.Opacity = 1;
            magazaMenuForm.FormClosed += (s, args) => this.Show(); //kapandığında AnaMenuyu tekrar göstericek
            this.Hide();
        }

        private void kutuphaneButton_Click(object sender, EventArgs e)
        {
            KutuphaneMenuForm k = new KutuphaneMenuForm();
            k.Opacity = 0;
            k.Show();
            k.Location = this.Location;
            k.Opacity = 1;
            k.FormClosed += (s, args) => this.Show(); //kapandığında AnaMenuyu tekrar göstericek
            this.Hide();
        }

        private void arkadasButton_Click(object sender, EventArgs e)
        {
            ArkadasMenuForm ar = new ArkadasMenuForm();
            ar.Opacity = 0;
            ar.Show();
            ar.Location = this.Location;
            ar.Opacity = 1;
            ar.FormClosed += (s, args) => this.Show(); //kapandığında AnaMenuyu tekrar göstericek
            this.Hide();
        }

        private void profilButton_Click(object sender, EventArgs e)
        {
            ProfilMenuForm pr = new ProfilMenuForm();
            pr.Opacity = 0;
            pr.Show();
            pr.Location = this.Location;
            pr.Opacity = 1;
            pr.FormClosed += (s, args) => this.Show(); //kapandığında AnaMenuyu tekrar göstericek
            this.Hide();
        }

        private void hesapButton_Click(object sender, EventArgs e)
        {
            HesapForm he = new HesapForm();
            he.Opacity = 0;
            he.Show();
            he.Location = this.Location;
            he.Opacity = 1;
            he.FormClosed += (s, args) => this.Show(); //kapandığında AnaMenuyu tekrar göstericek
            this.Hide();
        }

        private void cikisButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
