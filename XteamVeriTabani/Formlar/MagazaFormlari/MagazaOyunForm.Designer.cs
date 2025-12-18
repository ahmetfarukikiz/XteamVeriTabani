namespace XteamVeriTabani.Formlar
{
    partial class MagazaOyunForm
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
            oyunBaslikLabel = new Label();
            oyunAciklamaRTB = new RichTextBox();
            oyunFiyatLabel = new Label();
            sepeteEkleButton = new Button();
            gelistiriciLabel = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            dilDataGridView = new DataGridView();
            label7 = new Label();
            kategoriListBox = new ListBox();
            label5 = new Label();
            yuklemeBoyutuLabel = new Label();
            label6 = new Label();
            indirilmeSayisiLabel = new Label();
            label4 = new Label();
            cikisTarihiLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            kampanyaLabel = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dilDataGridView).BeginInit();
            SuspendLayout();
            // 
            // oyunBaslikLabel
            // 
            oyunBaslikLabel.AutoSize = true;
            oyunBaslikLabel.Font = new Font("Segoe UI", 22F);
            oyunBaslikLabel.Location = new Point(81, 88);
            oyunBaslikLabel.Name = "oyunBaslikLabel";
            oyunBaslikLabel.Size = new Size(335, 50);
            oyunBaslikLabel.TabIndex = 0;
            oyunBaslikLabel.Text = "League Of Legends";
            // 
            // oyunAciklamaRTB
            // 
            oyunAciklamaRTB.Location = new Point(28, 75);
            oyunAciklamaRTB.Name = "oyunAciklamaRTB";
            oyunAciklamaRTB.ReadOnly = true;
            oyunAciklamaRTB.Size = new Size(411, 154);
            oyunAciklamaRTB.TabIndex = 3;
            oyunAciklamaRTB.Text = "Oyunun Açıklaması burada olacak";
            // 
            // oyunFiyatLabel
            // 
            oyunFiyatLabel.AutoSize = true;
            oyunFiyatLabel.Font = new Font("Segoe UI", 20F);
            oyunFiyatLabel.Location = new Point(81, 194);
            oyunFiyatLabel.Name = "oyunFiyatLabel";
            oyunFiyatLabel.Size = new Size(99, 46);
            oyunFiyatLabel.TabIndex = 4;
            oyunFiyatLabel.Text = "40 TL";
            // 
            // sepeteEkleButton
            // 
            sepeteEkleButton.Font = new Font("Segoe UI", 12F);
            sepeteEkleButton.Location = new Point(81, 243);
            sepeteEkleButton.Name = "sepeteEkleButton";
            sepeteEkleButton.Size = new Size(234, 46);
            sepeteEkleButton.TabIndex = 5;
            sepeteEkleButton.Text = "Sepete Ekle";
            sepeteEkleButton.UseVisualStyleBackColor = true;
            sepeteEkleButton.Click += sepeteEkleButton_Click;
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
            groupBox1.Controls.Add(dilDataGridView);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(kategoriListBox);
            groupBox1.Controls.Add(label5);
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
            groupBox1.Location = new Point(477, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 634);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // dilDataGridView
            // 
            dilDataGridView.AllowUserToAddRows = false;
            dilDataGridView.AllowUserToDeleteRows = false;
            dilDataGridView.AllowUserToOrderColumns = true;
            dilDataGridView.AllowUserToResizeColumns = false;
            dilDataGridView.AllowUserToResizeRows = false;
            dilDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dilDataGridView.Location = new Point(26, 389);
            dilDataGridView.Name = "dilDataGridView";
            dilDataGridView.RowHeadersWidth = 51;
            dilDataGridView.Size = new Size(372, 101);
            dilDataGridView.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(26, 493);
            label7.Name = "label7";
            label7.Size = new Size(109, 28);
            label7.TabIndex = 24;
            label7.Text = "Kategoriler";
            // 
            // kategoriListBox
            // 
            kategoriListBox.FormattingEnabled = true;
            kategoriListBox.Location = new Point(26, 524);
            kategoriListBox.Name = "kategoriListBox";
            kategoriListBox.Size = new Size(235, 104);
            kategoriListBox.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(28, 355);
            label5.Name = "label5";
            label5.Size = new Size(173, 28);
            label5.TabIndex = 22;
            label5.Text = "Desteklenen Diller:";
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
            // kampanyaLabel
            // 
            kampanyaLabel.AutoSize = true;
            kampanyaLabel.BackColor = Color.Transparent;
            kampanyaLabel.Font = new Font("Segoe UI", 15F);
            kampanyaLabel.Location = new Point(81, 138);
            kampanyaLabel.Name = "kampanyaLabel";
            kampanyaLabel.Size = new Size(163, 35);
            kampanyaLabel.TabIndex = 9;
            kampanyaLabel.Text = "%50 INDIRIM";
            kampanyaLabel.Visible = false;
            // 
            // MagazaOyunForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 753);
            Controls.Add(kampanyaLabel);
            Controls.Add(groupBox1);
            Controls.Add(sepeteEkleButton);
            Controls.Add(oyunFiyatLabel);
            Controls.Add(oyunBaslikLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MagazaOyunForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "OyunForm";
            Load += MagazaOyunForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dilDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label oyunBaslikLabel;
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
        private Label label5;
        private Label label7;
        private ListBox kategoriListBox;
        private DataGridView dilDataGridView;
    }
}