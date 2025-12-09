namespace XteamVeriTabani
{
    public partial class KayitMenuForm : Form
    {
        public KayitMenuForm()
        {
            InitializeComponent();
        }

        private void girisYapButton_Click(object sender, EventArgs e)
        {
            AnaMenuForm anaMenuForm = new AnaMenuForm(/*hesapid gidecek*/);
            anaMenuForm.Opacity = 0;
            anaMenuForm.Show();
            anaMenuForm.Opacity = 1;
            anaMenuForm.FormClosed += (s, args) => this.Show(); //kapandýðýnda AnaMenuyu tekrar göstericek
            this.Hide();
        }
    }
}
