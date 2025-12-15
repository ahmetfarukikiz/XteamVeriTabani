namespace XteamVeriTabani.Formlar.MagazaFormlari
{
    partial class SepetForm
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
            label1 = new Label();
            siparisiTamamlaBtn = new Button();
            sepettenSilBtn = new Button();
            toplamTurarLabel = new Label();
            bakiyeLabel = new Label();
            sepetListBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(56, 47);
            label1.Name = "label1";
            label1.Size = new Size(306, 46);
            label1.TabIndex = 1;
            label1.Text = "Sepetteki Oyunlar";
            // 
            // siparisiTamamlaBtn
            // 
            siparisiTamamlaBtn.Font = new Font("Segoe UI", 11F);
            siparisiTamamlaBtn.Location = new Point(56, 495);
            siparisiTamamlaBtn.Name = "siparisiTamamlaBtn";
            siparisiTamamlaBtn.Size = new Size(169, 45);
            siparisiTamamlaBtn.TabIndex = 3;
            siparisiTamamlaBtn.Text = "Siparişi Tamamla";
            siparisiTamamlaBtn.UseVisualStyleBackColor = true;
            siparisiTamamlaBtn.Click += siparisiTamamlaBtn_Click;
            // 
            // sepettenSilBtn
            // 
            sepettenSilBtn.Font = new Font("Segoe UI", 11F);
            sepettenSilBtn.Location = new Point(231, 495);
            sepettenSilBtn.Name = "sepettenSilBtn";
            sepettenSilBtn.Size = new Size(100, 45);
            sepettenSilBtn.TabIndex = 4;
            sepettenSilBtn.Text = "Sil";
            sepettenSilBtn.UseVisualStyleBackColor = true;
            sepettenSilBtn.Click += sepettenSilBtn_Click;
            // 
            // toplamTurarLabel
            // 
            toplamTurarLabel.AutoSize = true;
            toplamTurarLabel.Font = new Font("Segoe UI", 15F);
            toplamTurarLabel.Location = new Point(585, 505);
            toplamTurarLabel.Name = "toplamTurarLabel";
            toplamTurarLabel.Size = new Size(224, 35);
            toplamTurarLabel.TabIndex = 6;
            toplamTurarLabel.Text = "Toplam Tutar: 20TL";
            // 
            // bakiyeLabel
            // 
            bakiyeLabel.AutoSize = true;
            bakiyeLabel.Font = new Font("Segoe UI", 15F);
            bakiyeLabel.Location = new Point(686, 55);
            bakiyeLabel.Name = "bakiyeLabel";
            bakiyeLabel.Size = new Size(148, 35);
            bakiyeLabel.TabIndex = 8;
            bakiyeLabel.Text = "Bakiye: 50TL";
            // 
            // sepetListBox
            // 
            sepetListBox.FormattingEnabled = true;
            sepetListBox.Location = new Point(56, 106);
            sepetListBox.Name = "sepetListBox";
            sepetListBox.Size = new Size(795, 384);
            sepetListBox.TabIndex = 9;
            // 
            // SepetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 597);
            Controls.Add(sepetListBox);
            Controls.Add(bakiyeLabel);
            Controls.Add(toplamTurarLabel);
            Controls.Add(sepettenSilBtn);
            Controls.Add(siparisiTamamlaBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "SepetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SepetForm";
            Load += SepetForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button siparisiTamamlaBtn;
        private Button sepettenSilBtn;
        private Label toplamTurarLabel;
        private Label bakiyeLabel;
        private ListBox sepetListBox;
    }
}