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
            kwebsitesiTB = new TextBox();
            label8 = new Label();
            kverginoTB = new TextBox();
            label7 = new Label();
            label5 = new Label();
            kturComboBox = new ComboBox();
            ksifreTB = new TextBox();
            kkullaniciadiTB = new TextBox();
            label6 = new Label();
            khesapadiTB = new TextBox();
            label4 = new Label();
            kayitOlButton = new Button();
            label2 = new Label();
            kepostaTB = new TextBox();
            label3 = new Label();
            kayitMenusuTab.SuspendLayout();
            tabPage1.SuspendLayout();
            kayitolTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // girisYapButton
            // 
            girisYapButton.Location = new Point(165, 305);
            girisYapButton.Name = "girisYapButton";
            girisYapButton.Size = new Size(295, 33);
            girisYapButton.TabIndex = 0;
            girisYapButton.Text = "Giriş Yap";
            girisYapButton.UseVisualStyleBackColor = true;
            girisYapButton.Click += girisYapButton_Click;
            // 
            // kullaniciTextBox
            // 
            kullaniciTextBox.Location = new Point(165, 196);
            kullaniciTextBox.Name = "kullaniciTextBox";
            kullaniciTextBox.Size = new Size(295, 27);
            kullaniciTextBox.TabIndex = 1;
            // 
            // sifreTextBox
            // 
            sifreTextBox.Location = new Point(165, 257);
            sifreTextBox.Name = "sifreTextBox";
            sifreTextBox.Size = new Size(295, 27);
            sifreTextBox.TabIndex = 2;
            // 
            // kullaniciadLabel
            // 
            kullaniciadLabel.AutoSize = true;
            kullaniciadLabel.Location = new Point(165, 173);
            kullaniciadLabel.Name = "kullaniciadLabel";
            kullaniciadLabel.Size = new Size(92, 20);
            kullaniciadLabel.TabIndex = 3;
            kullaniciadLabel.Text = "Kullanıcı Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 234);
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
            kayitMenusuTab.Size = new Size(652, 592);
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
            tabPage1.Size = new Size(644, 559);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Giriş Yap";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // kayitolTabPage
            // 
            kayitolTabPage.Controls.Add(kwebsitesiTB);
            kayitolTabPage.Controls.Add(label8);
            kayitolTabPage.Controls.Add(kverginoTB);
            kayitolTabPage.Controls.Add(label7);
            kayitolTabPage.Controls.Add(label5);
            kayitolTabPage.Controls.Add(kturComboBox);
            kayitolTabPage.Controls.Add(ksifreTB);
            kayitolTabPage.Controls.Add(kkullaniciadiTB);
            kayitolTabPage.Controls.Add(label6);
            kayitolTabPage.Controls.Add(khesapadiTB);
            kayitolTabPage.Controls.Add(label4);
            kayitolTabPage.Controls.Add(kayitOlButton);
            kayitolTabPage.Controls.Add(label2);
            kayitolTabPage.Controls.Add(kepostaTB);
            kayitolTabPage.Controls.Add(label3);
            kayitolTabPage.Location = new Point(4, 29);
            kayitolTabPage.Name = "kayitolTabPage";
            kayitolTabPage.Padding = new Padding(3);
            kayitolTabPage.Size = new Size(644, 559);
            kayitolTabPage.TabIndex = 1;
            kayitolTabPage.Text = "Kayıt Ol";
            kayitolTabPage.UseVisualStyleBackColor = true;
            kayitolTabPage.Click += kayitolTabPage_Click;
            // 
            // kwebsitesiTB
            // 
            kwebsitesiTB.Enabled = false;
            kwebsitesiTB.Location = new Point(168, 436);
            kwebsitesiTB.Name = "kwebsitesiTB";
            kwebsitesiTB.Size = new Size(295, 27);
            kwebsitesiTB.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(168, 413);
            label8.Name = "label8";
            label8.Size = new Size(147, 20);
            label8.TabIndex = 21;
            label8.Text = "Websitesi (Geliştirici)";
            // 
            // kverginoTB
            // 
            kverginoTB.Enabled = false;
            kverginoTB.Location = new Point(168, 368);
            kverginoTB.Name = "kverginoTB";
            kverginoTB.Size = new Size(295, 27);
            kverginoTB.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(168, 345);
            label7.Name = "label7";
            label7.Size = new Size(142, 20);
            label7.TabIndex = 19;
            label7.Text = "Vergi No (Geliştirici)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(168, 283);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 18;
            label5.Text = "Hesap Türü:";
            // 
            // kturComboBox
            // 
            kturComboBox.DisplayMember = "Oyuncu";
            kturComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            kturComboBox.FormattingEnabled = true;
            kturComboBox.Items.AddRange(new object[] { "Oyuncu", "Geliştirici" });
            kturComboBox.Location = new Point(168, 306);
            kturComboBox.Name = "kturComboBox";
            kturComboBox.Size = new Size(295, 28);
            kturComboBox.TabIndex = 17;
            kturComboBox.ValueMember = "Oyuncu";
            kturComboBox.SelectedIndexChanged += kturComboBox_SelectedIndexChanged;
            // 
            // ksifreTB
            // 
            ksifreTB.Location = new Point(168, 242);
            ksifreTB.Name = "ksifreTB";
            ksifreTB.Size = new Size(295, 27);
            ksifreTB.TabIndex = 16;
            // 
            // kkullaniciadiTB
            // 
            kkullaniciadiTB.Location = new Point(168, 181);
            kkullaniciadiTB.Name = "kkullaniciadiTB";
            kkullaniciadiTB.Size = new Size(295, 27);
            kkullaniciadiTB.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(168, 158);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 15;
            label6.Text = "Kullanıcı Adı";
            // 
            // khesapadiTB
            // 
            khesapadiTB.Location = new Point(168, 116);
            khesapadiTB.Name = "khesapadiTB";
            khesapadiTB.Size = new Size(295, 27);
            khesapadiTB.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(168, 93);
            label4.Name = "label4";
            label4.Size = new Size(171, 20);
            label4.TabIndex = 11;
            label4.Text = "Hesap Adı (Görünen Ad)";
            // 
            // kayitOlButton
            // 
            kayitOlButton.Location = new Point(168, 489);
            kayitOlButton.Name = "kayitOlButton";
            kayitOlButton.Size = new Size(295, 37);
            kayitOlButton.TabIndex = 5;
            kayitOlButton.Text = "Kayıt Ol";
            kayitOlButton.UseVisualStyleBackColor = true;
            kayitOlButton.Click += kayitOlButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 219);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 9;
            label2.Text = "Şifre";
            // 
            // kepostaTB
            // 
            kepostaTB.Location = new Point(168, 49);
            kepostaTB.Name = "kepostaTB";
            kepostaTB.Size = new Size(295, 27);
            kepostaTB.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 26);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 8;
            label3.Text = "E-posta";
            // 
            // KayitMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 592);
            Controls.Add(kayitMenusuTab);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "KayitMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xteam";
            Load += KayitMenuForm_Load;
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
        private TextBox kkullaniciadiTB;
        private Label label6;
        private TextBox khesapadiTB;
        private Label label4;
        private Button kayitOlButton;
        private Label label2;
        private TextBox kepostaTB;
        private Label label3;
        private TextBox ksifreTB;
        private ComboBox kturComboBox;
        private Label label5;
        private TextBox kwebsitesiTB;
        private Label label8;
        private TextBox kverginoTB;
        private Label label7;
    }
}
