namespace XteamVeriTabani
{
    partial class AnaMenuForm
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
            magazaButton = new Button();
            profilButton = new Button();
            hesapButton = new Button();
            arkadasButton = new Button();
            label1 = new Label();
            kutuphaneButton = new Button();
            cikisButton = new Button();
            SuspendLayout();
            // 
            // magazaButton
            // 
            magazaButton.BackColor = Color.Azure;
            magazaButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            magazaButton.ForeColor = Color.MidnightBlue;
            magazaButton.Location = new Point(255, 327);
            magazaButton.Name = "magazaButton";
            magazaButton.Size = new Size(189, 87);
            magazaButton.TabIndex = 0;
            magazaButton.Text = "Mağaza";
            magazaButton.UseVisualStyleBackColor = false;
            magazaButton.Click += magazaButton_Click;
            // 
            // profilButton
            // 
            profilButton.BackColor = Color.Azure;
            profilButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            profilButton.ForeColor = Color.MidnightBlue;
            profilButton.Location = new Point(255, 430);
            profilButton.Name = "profilButton";
            profilButton.Size = new Size(189, 87);
            profilButton.TabIndex = 2;
            profilButton.Text = "Profil";
            profilButton.UseVisualStyleBackColor = false;
            profilButton.Click += profilButton_Click;
            // 
            // hesapButton
            // 
            hesapButton.BackColor = Color.Azure;
            hesapButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            hesapButton.ForeColor = Color.MidnightBlue;
            hesapButton.Location = new Point(467, 430);
            hesapButton.Name = "hesapButton";
            hesapButton.Size = new Size(189, 87);
            hesapButton.TabIndex = 3;
            hesapButton.Text = "Hesap";
            hesapButton.UseVisualStyleBackColor = false;
            hesapButton.Click += hesapButton_Click;
            // 
            // arkadasButton
            // 
            arkadasButton.BackColor = Color.Azure;
            arkadasButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            arkadasButton.ForeColor = Color.MidnightBlue;
            arkadasButton.Location = new Point(674, 327);
            arkadasButton.Name = "arkadasButton";
            arkadasButton.Size = new Size(189, 87);
            arkadasButton.TabIndex = 4;
            arkadasButton.Text = "Arkadaşlar";
            arkadasButton.UseVisualStyleBackColor = false;
            arkadasButton.Click += arkadasButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(255, 167);
            label1.Name = "label1";
            label1.Size = new Size(175, 67);
            label1.TabIndex = 6;
            label1.Text = "Xteam";
            // 
            // kutuphaneButton
            // 
            kutuphaneButton.BackColor = Color.Azure;
            kutuphaneButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            kutuphaneButton.ForeColor = Color.MidnightBlue;
            kutuphaneButton.Location = new Point(467, 327);
            kutuphaneButton.Name = "kutuphaneButton";
            kutuphaneButton.Size = new Size(189, 87);
            kutuphaneButton.TabIndex = 7;
            kutuphaneButton.Text = "Kütüphane";
            kutuphaneButton.UseVisualStyleBackColor = false;
            kutuphaneButton.Click += kutuphaneButton_Click;
            // 
            // cikisButton
            // 
            cikisButton.BackColor = Color.Azure;
            cikisButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            cikisButton.ForeColor = Color.MidnightBlue;
            cikisButton.Location = new Point(674, 430);
            cikisButton.Name = "cikisButton";
            cikisButton.Size = new Size(189, 87);
            cikisButton.TabIndex = 8;
            cikisButton.Text = "Çıkış";
            cikisButton.UseVisualStyleBackColor = false;
            cikisButton.Click += cikisButton_Click;
            // 
            // AnaMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1202, 744);
            Controls.Add(cikisButton);
            Controls.Add(kutuphaneButton);
            Controls.Add(label1);
            Controls.Add(arkadasButton);
            Controls.Add(hesapButton);
            Controls.Add(profilButton);
            Controls.Add(magazaButton);
            MaximizeBox = false;
            Name = "AnaMenuForm";
            Text = "AnaMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button magazaButton;
        private Button profilButton;
        private Button hesapButton;
        private Button arkadasButton;
        private Label label1;
        private Button kutuphaneButton;
        private Button cikisButton;
    }
}