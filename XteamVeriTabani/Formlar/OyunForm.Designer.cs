namespace XteamVeriTabani.Formlar
{
    partial class OyunForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OyunForm));
            oyunAdiLabel = new Label();
            pictureBox1 = new PictureBox();
            oyunAciklamaRTB = new RichTextBox();
            oyunFiyatLabel = new Label();
            sepeteEkleButton = new Button();
            gelistiriciLabel = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            cikisTarihiLabel = new Label();
            label4 = new Label();
            indirilmeSayisiLabel = new Label();
            kampanyaLabel = new Label();
            label6 = new Label();
            yuklemeBoyutuLabel = new Label();
            geriButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // oyunAdiLabel
            // 
            oyunAdiLabel.AutoSize = true;
            oyunAdiLabel.Font = new Font("Segoe UI", 22F);
            oyunAdiLabel.Location = new Point(69, 134);
            oyunAdiLabel.Name = "oyunAdiLabel";
            oyunAdiLabel.Size = new Size(335, 50);
            oyunAdiLabel.TabIndex = 0;
            oyunAdiLabel.Text = "League Of Legends";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(69, 207);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(339, 249);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // oyunAciklamaRTB
            // 
            oyunAciklamaRTB.Location = new Point(28, 75);
            oyunAciklamaRTB.Name = "oyunAciklamaRTB";
            oyunAciklamaRTB.Size = new Size(411, 154);
            oyunAciklamaRTB.TabIndex = 3;
            oyunAciklamaRTB.Text = "Oyunun Açıklaması burada olacak";
            // 
            // oyunFiyatLabel
            // 
            oyunFiyatLabel.AutoSize = true;
            oyunFiyatLabel.Font = new Font("Segoe UI", 20F);
            oyunFiyatLabel.Location = new Point(69, 469);
            oyunFiyatLabel.Name = "oyunFiyatLabel";
            oyunFiyatLabel.Size = new Size(99, 46);
            oyunFiyatLabel.TabIndex = 4;
            oyunFiyatLabel.Text = "40 TL";
            // 
            // sepeteEkleButton
            // 
            sepeteEkleButton.Font = new Font("Segoe UI", 10F);
            sepeteEkleButton.Location = new Point(174, 475);
            sepeteEkleButton.Name = "sepeteEkleButton";
            sepeteEkleButton.Size = new Size(121, 40);
            sepeteEkleButton.TabIndex = 5;
            sepeteEkleButton.Text = "Sepete Ekle";
            sepeteEkleButton.UseVisualStyleBackColor = true;
            // 
            // gelistiriciLabel
            // 
            gelistiriciLabel.AutoSize = true;
            gelistiriciLabel.Font = new Font("Segoe UI", 12F);
            gelistiriciLabel.ForeColor = Color.DimGray;
            gelistiriciLabel.Location = new Point(290, 232);
            gelistiriciLabel.Name = "gelistiriciLabel";
            gelistiriciLabel.Size = new Size(107, 28);
            gelistiriciLabel.TabIndex = 6;
            gelistiriciLabel.Text = "RiotGames";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(28, 232);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 7;
            label1.Text = "Geliştirici:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(yuklemeBoyutuLabel);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(indirilmeSayisiLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cikisTarihiLabel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(oyunAciklamaRTB);
            groupBox1.Controls.Add(gelistiriciLabel);
            groupBox1.Location = new Point(463, 153);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(468, 362);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(28, 260);
            label2.Name = "label2";
            label2.Size = new Size(107, 28);
            label2.TabIndex = 8;
            label2.Text = "Çıkış Tarihi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(28, 35);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 9;
            label3.Text = "Oyun Hakkında:";
            // 
            // cikisTarihiLabel
            // 
            cikisTarihiLabel.AutoSize = true;
            cikisTarihiLabel.Font = new Font("Segoe UI", 12F);
            cikisTarihiLabel.ForeColor = Color.DimGray;
            cikisTarihiLabel.Location = new Point(290, 260);
            cikisTarihiLabel.Name = "cikisTarihiLabel";
            cikisTarihiLabel.Size = new Size(108, 28);
            cikisTarihiLabel.TabIndex = 10;
            cikisTarihiLabel.Text = "23.11.2023";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(28, 288);
            label4.Name = "label4";
            label4.Size = new Size(147, 28);
            label4.TabIndex = 11;
            label4.Text = "İndirilme Sayısı:";
            // 
            // indirilmeSayisiLabel
            // 
            indirilmeSayisiLabel.AutoSize = true;
            indirilmeSayisiLabel.Font = new Font("Segoe UI", 12F);
            indirilmeSayisiLabel.ForeColor = Color.DimGray;
            indirilmeSayisiLabel.Location = new Point(290, 288);
            indirilmeSayisiLabel.Name = "indirilmeSayisiLabel";
            indirilmeSayisiLabel.Size = new Size(71, 28);
            indirilmeSayisiLabel.TabIndex = 12;
            indirilmeSayisiLabel.Text = "12.000";
            // 
            // kampanyaLabel
            // 
            kampanyaLabel.AutoSize = true;
            kampanyaLabel.BackColor = Color.Transparent;
            kampanyaLabel.Font = new Font("Segoe UI", 15F);
            kampanyaLabel.Location = new Point(83, 406);
            kampanyaLabel.Name = "kampanyaLabel";
            kampanyaLabel.Size = new Size(163, 35);
            kampanyaLabel.TabIndex = 9;
            kampanyaLabel.Text = "%50 INDIRIM";
            kampanyaLabel.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(28, 316);
            label6.Name = "label6";
            label6.Size = new Size(157, 28);
            label6.TabIndex = 13;
            label6.Text = "Yükleme Boyutu:";
            // 
            // yuklemeBoyutuLabel
            // 
            yuklemeBoyutuLabel.AutoSize = true;
            yuklemeBoyutuLabel.Font = new Font("Segoe UI", 12F);
            yuklemeBoyutuLabel.ForeColor = Color.DimGray;
            yuklemeBoyutuLabel.Location = new Point(290, 316);
            yuklemeBoyutuLabel.Name = "yuklemeBoyutuLabel";
            yuklemeBoyutuLabel.Size = new Size(59, 28);
            yuklemeBoyutuLabel.TabIndex = 14;
            yuklemeBoyutuLabel.Text = "20GB";
            // 
            // geriButton
            // 
            geriButton.Location = new Point(12, 12);
            geriButton.Name = "geriButton";
            geriButton.Size = new Size(63, 42);
            geriButton.TabIndex = 10;
            geriButton.Text = "<--";
            geriButton.UseVisualStyleBackColor = true;
            // 
            // OyunForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 666);
            Controls.Add(geriButton);
            Controls.Add(kampanyaLabel);
            Controls.Add(groupBox1);
            Controls.Add(sepeteEkleButton);
            Controls.Add(oyunFiyatLabel);
            Controls.Add(pictureBox1);
            Controls.Add(oyunAdiLabel);
            Name = "OyunForm";
            Text = "OyunForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label oyunAdiLabel;
        private PictureBox pictureBox1;
        private RichTextBox oyunAciklamaRTB;
        private Label oyunFiyatLabel;
        private Button sepeteEkleButton;
        private Label gelistiriciLabel;
        private Label label1;
        private GroupBox groupBox1;
        private Label cikisTarihiLabel;
        private Label label3;
        private Label label2;
        private Label indirilmeSayisiLabel;
        private Label label4;
        private Label kampanyaLabel;
        private Label label6;
        private Label yuklemeBoyutuLabel;
        private Button geriButton;
    }
}