namespace XteamVeriTabani
{
    partial class KutuphaneMenuForm
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
            oyunuGorButton = new Button();
            label4 = new Label();
            oyunuAraButton = new Button();
            label3 = new Label();
            kategoriComboBox = new ComboBox();
            label2 = new Label();
            oyunAdiTextBox = new TextBox();
            oyunlarListBox = new ListBox();
            label1 = new Label();
            oyunDuzenleButton = new Button();
            oyunEkleButton = new Button();
            SuspendLayout();
            // 
            // oyunuGorButton
            // 
            oyunuGorButton.Location = new Point(1009, 732);
            oyunuGorButton.Name = "oyunuGorButton";
            oyunuGorButton.Size = new Size(147, 29);
            oyunuGorButton.TabIndex = 17;
            oyunuGorButton.Text = "Oyunu Gör";
            oyunuGorButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F);
            label4.Location = new Point(1001, 127);
            label4.Name = "label4";
            label4.Size = new Size(155, 41);
            label4.TabIndex = 16;
            label4.Text = "Oyunlarım";
            // 
            // oyunuAraButton
            // 
            oyunuAraButton.Location = new Point(756, 96);
            oyunuAraButton.Name = "oyunuAraButton";
            oyunuAraButton.Size = new Size(153, 29);
            oyunuAraButton.TabIndex = 15;
            oyunuAraButton.Text = "Oyunu Ara";
            oyunuAraButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(558, 73);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 14;
            label3.Text = "Kategoriler";
            // 
            // kategoriComboBox
            // 
            kategoriComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            kategoriComboBox.FormattingEnabled = true;
            kategoriComboBox.Location = new Point(558, 96);
            kategoriComboBox.Name = "kategoriComboBox";
            kategoriComboBox.Size = new Size(151, 28);
            kategoriComboBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 73);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 12;
            label2.Text = "Oyun İsmi";
            // 
            // oyunAdiTextBox
            // 
            oyunAdiTextBox.Location = new Point(348, 96);
            oyunAdiTextBox.Name = "oyunAdiTextBox";
            oyunAdiTextBox.Size = new Size(160, 27);
            oyunAdiTextBox.TabIndex = 11;
            // 
            // oyunlarListBox
            // 
            oyunlarListBox.FormattingEnabled = true;
            oyunlarListBox.Location = new Point(89, 182);
            oyunlarListBox.Name = "oyunlarListBox";
            oyunlarListBox.Size = new Size(1067, 544);
            oyunlarListBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 25F);
            label1.Location = new Point(62, 18);
            label1.Name = "label1";
            label1.Size = new Size(230, 56);
            label1.TabIndex = 9;
            label1.Text = "Kütüphane";
            // 
            // oyunDuzenleButton
            // 
            oyunDuzenleButton.Enabled = false;
            oyunDuzenleButton.Location = new Point(856, 732);
            oyunDuzenleButton.Name = "oyunDuzenleButton";
            oyunDuzenleButton.Size = new Size(147, 29);
            oyunDuzenleButton.TabIndex = 18;
            oyunDuzenleButton.Text = "Oyunu Düzenle";
            oyunDuzenleButton.UseVisualStyleBackColor = true;
            // 
            // oyunEkleButton
            // 
            oyunEkleButton.Enabled = false;
            oyunEkleButton.Location = new Point(703, 732);
            oyunEkleButton.Name = "oyunEkleButton";
            oyunEkleButton.Size = new Size(147, 29);
            oyunEkleButton.TabIndex = 19;
            oyunEkleButton.Text = "Oyun Ekle";
            oyunEkleButton.UseVisualStyleBackColor = true;
            // 
            // KutuphaneMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 778);
            Controls.Add(oyunEkleButton);
            Controls.Add(oyunDuzenleButton);
            Controls.Add(oyunuGorButton);
            Controls.Add(label4);
            Controls.Add(oyunuAraButton);
            Controls.Add(label3);
            Controls.Add(kategoriComboBox);
            Controls.Add(label2);
            Controls.Add(oyunAdiTextBox);
            Controls.Add(oyunlarListBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "KutuphaneMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KutuphaneMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button oyunuGorButton;
        private Label label4;
        private Button oyunuAraButton;
        private Label label3;
        private ComboBox kategoriComboBox;
        private Label label2;
        private TextBox oyunAdiTextBox;
        private ListBox oyunlarListBox;
        private Label label1;
        private Button oyunDuzenleButton;
        private Button oyunEkleButton;
    }
}