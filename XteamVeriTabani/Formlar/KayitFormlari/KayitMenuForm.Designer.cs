namespace XteamVeriTabani
{
    partial class KayitMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            girisYapButton = new Button();
            kullaniciTextBox = new TextBox();
            sifreTextBox = new TextBox();
            kullaniciadLabel = new Label();
            label1 = new Label();
            kayitMenusuTab = new TabControl();
            tabPage1 = new TabPage();
            kayitolTabPage = new TabPage();
            textBox2 = new TextBox();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            kayitMenusuTab.SuspendLayout();
            tabPage1.SuspendLayout();
            kayitolTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // girisYapButton
            // 
            girisYapButton.Location = new Point(158, 287);
            girisYapButton.Name = "girisYapButton";
            girisYapButton.Size = new Size(295, 33);
            girisYapButton.TabIndex = 0;
            girisYapButton.Text = "Giriş Yap";
            girisYapButton.UseVisualStyleBackColor = true;
            // 
            // kullaniciTextBox
            // 
            kullaniciTextBox.Location = new Point(158, 178);
            kullaniciTextBox.Name = "kullaniciTextBox";
            kullaniciTextBox.Size = new Size(295, 27);
            kullaniciTextBox.TabIndex = 1;
            // 
            // sifreTextBox
            // 
            sifreTextBox.Location = new Point(158, 239);
            sifreTextBox.Name = "sifreTextBox";
            sifreTextBox.Size = new Size(295, 27);
            sifreTextBox.TabIndex = 2;
            // 
            // kullaniciadLabel
            // 
            kullaniciadLabel.AutoSize = true;
            kullaniciadLabel.Location = new Point(158, 155);
            kullaniciadLabel.Name = "kullaniciadLabel";
            kullaniciadLabel.Size = new Size(92, 20);
            kullaniciadLabel.TabIndex = 3;
            kullaniciadLabel.Text = "Kullanıcı Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 216);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 4;
            label1.Text = "Şifre";
            // 
            // kayitMenusuTab
            // 
            kayitMenusuTab.Controls.Add(tabPage1);
            kayitMenusuTab.Controls.Add(kayitolTabPage);
            kayitMenusuTab.Dock = DockStyle.Fill;
            kayitMenusuTab.Location = new Point(0, 0);
            kayitMenusuTab.Name = "kayitMenusuTab";
            kayitMenusuTab.SelectedIndex = 0;
            kayitMenusuTab.Size = new Size(620, 542);
            kayitMenusuTab.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(girisYapButton);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(kullaniciTextBox);
            tabPage1.Controls.Add(kullaniciadLabel);
            tabPage1.Controls.Add(sifreTextBox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 509);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Giriş Yap";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // kayitolTabPage
            // 
            kayitolTabPage.Controls.Add(textBox2);
            kayitolTabPage.Controls.Add(textBox5);
            kayitolTabPage.Controls.Add(label6);
            kayitolTabPage.Controls.Add(textBox3);
            kayitolTabPage.Controls.Add(label4);
            kayitolTabPage.Controls.Add(button1);
            kayitolTabPage.Controls.Add(label2);
            kayitolTabPage.Controls.Add(textBox1);
            kayitolTabPage.Controls.Add(label3);
            kayitolTabPage.Location = new Point(4, 29);
            kayitolTabPage.Name = "kayitolTabPage";
            kayitolTabPage.Padding = new Padding(3);
            kayitolTabPage.Size = new Size(636, 507);
            kayitolTabPage.TabIndex = 1;
            kayitolTabPage.Text = "Kayıt Ol";
            kayitolTabPage.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(167, 305);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(295, 27);
            textBox2.TabIndex = 16;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(167, 244);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(295, 27);
            textBox5.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 221);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 15;
            label6.Text = "Kullanıcı Adı";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(167, 179);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(295, 27);
            textBox3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 156);
            label4.Name = "label4";
            label4.Size = new Size(171, 20);
            label4.TabIndex = 11;
            label4.Text = "Hesap Adı (Görünen Ad)";
            // 
            // button1
            // 
            button1.Location = new Point(167, 354);
            button1.Name = "button1";
            button1.Size = new Size(295, 37);
            button1.TabIndex = 5;
            button1.Text = "Kayıt Ol";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 282);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 9;
            label2.Text = "Şifre";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(167, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(295, 27);
            textBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 89);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 8;
            label3.Text = "E-posta";
            // 
            // KayitMenusu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 542);
            Controls.Add(kayitMenusuTab);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "KayitMenusu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xteam";
            kayitMenusuTab.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            kayitolTabPage.ResumeLayout(false);
            kayitolTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button girisYapButton;
        private TextBox kullaniciTextBox;
        private TextBox sifreTextBox;
        private Label kullaniciadLabel;
        private Label label1;
        private TabControl kayitMenusuTab;
        private TabPage tabPage1;
        private TabPage kayitolTabPage;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox3;
        private Label label4;
        private Button button1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
    }
}
