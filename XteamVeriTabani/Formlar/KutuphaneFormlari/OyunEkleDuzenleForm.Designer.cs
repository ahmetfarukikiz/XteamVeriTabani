namespace XteamVeriTabani.Formlar.KutuphaneFormlari
{
    partial class OyunEkleDuzenleForm
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
            oyunEkleBtn = new Button();
            oyunAdiTextBox = new TextBox();
            label3 = new Label();
            aciklamaRTB = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            kategoriCheckBox = new CheckedListBox();
            label6 = new Label();
            fiyatTB = new TextBox();
            label7 = new Label();
            yuklemeBoyutuTB = new TextBox();
            label8 = new Label();
            kampanyaComboBox = new ComboBox();
            dgvDiller = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDiller).BeginInit();
            SuspendLayout();
            // 
            // oyunEkleBtn
            // 
            oyunEkleBtn.Location = new Point(96, 575);
            oyunEkleBtn.Name = "oyunEkleBtn";
            oyunEkleBtn.Size = new Size(841, 37);
            oyunEkleBtn.TabIndex = 23;
            oyunEkleBtn.Text = "Oyun Ekle";
            oyunEkleBtn.UseVisualStyleBackColor = true;
            oyunEkleBtn.Click += oyunEkleDuzenleButton;
            // 
            // oyunAdiTextBox
            // 
            oyunAdiTextBox.Location = new Point(96, 89);
            oyunAdiTextBox.Name = "oyunAdiTextBox";
            oyunAdiTextBox.Size = new Size(295, 27);
            oyunAdiTextBox.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 66);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 25;
            label3.Text = "Oyunun Adı:";
            // 
            // aciklamaRTB
            // 
            aciklamaRTB.Location = new Point(96, 154);
            aciklamaRTB.Name = "aciklamaRTB";
            aciklamaRTB.Size = new Size(841, 120);
            aciklamaRTB.TabIndex = 26;
            aciklamaRTB.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 131);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 27;
            label1.Text = "Açıklaması:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 297);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 29;
            label2.Text = "Diller:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(490, 297);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 31;
            label4.Text = "Kategoriler";
            // 
            // kategoriCheckBox
            // 
            kategoriCheckBox.FormattingEnabled = true;
            kategoriCheckBox.Location = new Point(490, 320);
            kategoriCheckBox.Name = "kategoriCheckBox";
            kategoriCheckBox.Size = new Size(172, 136);
            kategoriCheckBox.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(682, 297);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 35;
            label6.Text = "Kampanyası";
            // 
            // fiyatTB
            // 
            fiyatTB.Location = new Point(96, 505);
            fiyatTB.Name = "fiyatTB";
            fiyatTB.Size = new Size(215, 27);
            fiyatTB.TabIndex = 36;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(96, 482);
            label7.Name = "label7";
            label7.Size = new Size(47, 20);
            label7.TabIndex = 37;
            label7.Text = "Fiyatı:";
            // 
            // yuklemeBoyutuTB
            // 
            yuklemeBoyutuTB.Location = new Point(348, 505);
            yuklemeBoyutuTB.Name = "yuklemeBoyutuTB";
            yuklemeBoyutuTB.Size = new Size(215, 27);
            yuklemeBoyutuTB.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(348, 482);
            label8.Name = "label8";
            label8.Size = new Size(115, 20);
            label8.TabIndex = 39;
            label8.Text = "Yükleme Boyutu";
            // 
            // kampanyaComboBox
            // 
            kampanyaComboBox.FormattingEnabled = true;
            kampanyaComboBox.Location = new Point(682, 320);
            kampanyaComboBox.Name = "kampanyaComboBox";
            kampanyaComboBox.Size = new Size(236, 28);
            kampanyaComboBox.TabIndex = 40;
            // 
            // dgvDiller
            // 
            dgvDiller.AllowUserToAddRows = false;
            dgvDiller.AllowUserToDeleteRows = false;
            dgvDiller.AllowUserToOrderColumns = true;
            dgvDiller.AllowUserToResizeColumns = false;
            dgvDiller.AllowUserToResizeRows = false;
            dgvDiller.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiller.Location = new Point(96, 320);
            dgvDiller.Name = "dgvDiller";
            dgvDiller.RowHeadersWidth = 51;
            dgvDiller.Size = new Size(367, 145);
            dgvDiller.TabIndex = 41;
            // 
            // OyunEkleDuzenleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 666);
            Controls.Add(dgvDiller);
            Controls.Add(kampanyaComboBox);
            Controls.Add(yuklemeBoyutuTB);
            Controls.Add(label8);
            Controls.Add(fiyatTB);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(kategoriCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(aciklamaRTB);
            Controls.Add(oyunEkleBtn);
            Controls.Add(oyunAdiTextBox);
            Controls.Add(label3);
            Name = "OyunEkleDuzenleForm";
            Text = "OyunEkle";
            Load += OyunEkle_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiller).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button oyunEkleBtn;
        private TextBox oyunAdiTextBox;
        private Label label3;
        private RichTextBox aciklamaRTB;
        private Label label1;
        private Label label2;
        private Label label4;
        private CheckedListBox kategoriCheckBox;
        private Label label6;
        private TextBox fiyatTB;
        private Label label7;
        private TextBox yuklemeBoyutuTB;
        private Label label8;
        private ComboBox kampanyaComboBox;
        private DataGridView dgvDiller;
    }
}