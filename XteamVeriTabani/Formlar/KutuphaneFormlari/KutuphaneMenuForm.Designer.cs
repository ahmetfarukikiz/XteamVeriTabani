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
            oyunuGorButton.Click += oyunuGorButton_Click;
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
            label1.Location = new Point(89, 25);
            label1.Name = "label1";
            label1.Size = new Size(230, 56);
            label1.TabIndex = 9;
            label1.Text = "Kütüphane";
            // 
            // oyunDuzenleButton
            // 
            oyunDuzenleButton.Location = new Point(856, 732);
            oyunDuzenleButton.Name = "oyunDuzenleButton";
            oyunDuzenleButton.Size = new Size(147, 29);
            oyunDuzenleButton.TabIndex = 18;
            oyunDuzenleButton.Text = "Oyunu Düzenle";
            oyunDuzenleButton.UseVisualStyleBackColor = true;
            oyunDuzenleButton.Click += oyunDuzenleButton_Click;
            // 
            // oyunEkleButton
            // 
            oyunEkleButton.Location = new Point(703, 732);
            oyunEkleButton.Name = "oyunEkleButton";
            oyunEkleButton.Size = new Size(147, 29);
            oyunEkleButton.TabIndex = 19;
            oyunEkleButton.Text = "Oyun Ekle";
            oyunEkleButton.UseVisualStyleBackColor = true;
            oyunEkleButton.Click += oyunEkleButton_Click;
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
            Controls.Add(oyunlarListBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "KutuphaneMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KutuphaneMenuForm";
            Load += KutuphaneMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button oyunuGorButton;
        private Label label4;
        private ListBox oyunlarListBox;
        private Label label1;
        private Button oyunDuzenleButton;
        private Button oyunEkleButton;
    }
}