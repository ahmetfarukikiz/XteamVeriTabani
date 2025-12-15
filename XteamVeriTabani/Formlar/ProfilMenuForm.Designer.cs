namespace XteamVeriTabani
{
    partial class ProfilMenuForm
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
            hesapAdiLabel = new Label();
            label3 = new Label();
            seviyeLabel = new Label();
            kayitTarihiLabel = new Label();
            label5 = new Label();
            sonGirisLabel = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // hesapAdiLabel
            // 
            hesapAdiLabel.AutoSize = true;
            hesapAdiLabel.Font = new Font("Segoe UI Variable Display Semib", 25F);
            hesapAdiLabel.Location = new Point(68, 87);
            hesapAdiLabel.Name = "hesapAdiLabel";
            hesapAdiLabel.Size = new Size(158, 56);
            hesapAdiLabel.TabIndex = 1;
            hesapAdiLabel.Text = "Hesap1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(77, 204);
            label3.Name = "label3";
            label3.Size = new Size(136, 41);
            label3.TabIndex = 3;
            label3.Text = "Seviyesi:";
            // 
            // seviyeLabel
            // 
            seviyeLabel.AutoSize = true;
            seviyeLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            seviyeLabel.ForeColor = Color.FromArgb(64, 64, 64);
            seviyeLabel.Location = new Point(260, 210);
            seviyeLabel.Name = "seviyeLabel";
            seviyeLabel.Size = new Size(29, 35);
            seviyeLabel.TabIndex = 8;
            seviyeLabel.Text = "8";
            // 
            // kayitTarihiLabel
            // 
            kayitTarihiLabel.AutoSize = true;
            kayitTarihiLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            kayitTarihiLabel.ForeColor = Color.FromArgb(64, 64, 64);
            kayitTarihiLabel.Location = new Point(260, 248);
            kayitTarihiLabel.Name = "kayitTarihiLabel";
            kayitTarihiLabel.RightToLeft = RightToLeft.Yes;
            kayitTarihiLabel.Size = new Size(141, 35);
            kayitTarihiLabel.TabIndex = 10;
            kayitTarihiLabel.Text = "21.11.2015";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(77, 245);
            label5.Name = "label5";
            label5.Size = new Size(177, 41);
            label5.TabIndex = 9;
            label5.Text = "Kayıt Tarihi:";
            // 
            // sonGirisLabel
            // 
            sonGirisLabel.AutoSize = true;
            sonGirisLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            sonGirisLabel.ForeColor = Color.FromArgb(64, 64, 64);
            sonGirisLabel.Location = new Point(260, 292);
            sonGirisLabel.Name = "sonGirisLabel";
            sonGirisLabel.RightToLeft = RightToLeft.Yes;
            sonGirisLabel.Size = new Size(141, 35);
            sonGirisLabel.TabIndex = 12;
            sonGirisLabel.Text = "21.11.2015";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(77, 286);
            label2.Name = "label2";
            label2.Size = new Size(149, 41);
            label2.TabIndex = 11;
            label2.Text = "Son Giriş:";
            // 
            // ProfilMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 639);
            Controls.Add(sonGirisLabel);
            Controls.Add(label2);
            Controls.Add(kayitTarihiLabel);
            Controls.Add(label5);
            Controls.Add(seviyeLabel);
            Controls.Add(label3);
            Controls.Add(hesapAdiLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProfilMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profil";
            Load += ProfilMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hesapAdiLabel;
        private Label label3;
        private Label seviyeLabel;
        private Label kayitTarihiLabel;
        private Label label5;
        private Label sonGirisLabel;
        private Label label2;
    }
}