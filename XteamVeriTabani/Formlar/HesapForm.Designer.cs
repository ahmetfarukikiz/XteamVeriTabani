namespace XteamVeriTabani
{
    partial class HesapForm
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
            wblabel = new Label();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            hesapAdiLabel = new Label();
            kullaniciAdiTB = new TextBox();
            sifreTB = new TextBox();
            vnlabel = new Label();
            hesapAdiTB = new TextBox();
            duzenleButton = new Button();
            webSitesiTB = new TextBox();
            kaydetButton = new Button();
            epostaTB = new TextBox();
            label7 = new Label();
            vergiNoTB = new TextBox();
            SuspendLayout();
            // 
            // wblabel
            // 
            wblabel.AutoSize = true;
            wblabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            wblabel.Location = new Point(612, 286);
            wblabel.Name = "wblabel";
            wblabel.Size = new Size(172, 41);
            wblabel.TabIndex = 22;
            wblabel.Text = "Web Sitesi:";
            wblabel.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(154, 366);
            label2.Name = "label2";
            label2.Size = new Size(166, 41);
            label2.TabIndex = 20;
            label2.Text = "Hesap Adı:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(154, 325);
            label5.Name = "label5";
            label5.Size = new Size(90, 41);
            label5.TabIndex = 18;
            label5.Text = "Şifre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(154, 284);
            label3.Name = "label3";
            label3.Size = new Size(196, 41);
            label3.TabIndex = 16;
            label3.Text = "Kullanıcı Adı:";
            // 
            // hesapAdiLabel
            // 
            hesapAdiLabel.AutoSize = true;
            hesapAdiLabel.Font = new Font("Segoe UI Variable Display Semib", 25F);
            hesapAdiLabel.Location = new Point(154, 167);
            hesapAdiLabel.Name = "hesapAdiLabel";
            hesapAdiLabel.Size = new Size(158, 56);
            hesapAdiLabel.TabIndex = 15;
            hesapAdiLabel.Text = "Hesap1";
            // 
            // kullaniciAdiTB
            // 
            kullaniciAdiTB.Location = new Point(353, 296);
            kullaniciAdiTB.Name = "kullaniciAdiTB";
            kullaniciAdiTB.ReadOnly = true;
            kullaniciAdiTB.Size = new Size(200, 27);
            kullaniciAdiTB.TabIndex = 24;
            // 
            // sifreTB
            // 
            sifreTB.Location = new Point(353, 337);
            sifreTB.Name = "sifreTB";
            sifreTB.ReadOnly = true;
            sifreTB.Size = new Size(200, 27);
            sifreTB.TabIndex = 25;
            // 
            // vnlabel
            // 
            vnlabel.AutoSize = true;
            vnlabel.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vnlabel.Location = new Point(612, 340);
            vnlabel.Name = "vnlabel";
            vnlabel.Size = new Size(145, 41);
            vnlabel.TabIndex = 26;
            vnlabel.Text = "Vergi No:";
            vnlabel.Visible = false;
            // 
            // hesapAdiTB
            // 
            hesapAdiTB.Location = new Point(353, 378);
            hesapAdiTB.Name = "hesapAdiTB";
            hesapAdiTB.ReadOnly = true;
            hesapAdiTB.Size = new Size(200, 27);
            hesapAdiTB.TabIndex = 28;
            // 
            // duzenleButton
            // 
            duzenleButton.Location = new Point(353, 479);
            duzenleButton.Name = "duzenleButton";
            duzenleButton.Size = new Size(94, 29);
            duzenleButton.TabIndex = 29;
            duzenleButton.Text = "Düzenle";
            duzenleButton.UseVisualStyleBackColor = true;
            duzenleButton.Click += duzenleButton_Click;
            // 
            // webSitesiTB
            // 
            webSitesiTB.Location = new Point(795, 298);
            webSitesiTB.Name = "webSitesiTB";
            webSitesiTB.ReadOnly = true;
            webSitesiTB.Size = new Size(200, 27);
            webSitesiTB.TabIndex = 30;
            webSitesiTB.Visible = false;
            // 
            // kaydetButton
            // 
            kaydetButton.Location = new Point(459, 479);
            kaydetButton.Name = "kaydetButton";
            kaydetButton.Size = new Size(94, 29);
            kaydetButton.TabIndex = 31;
            kaydetButton.Text = "Kaydet";
            kaydetButton.UseVisualStyleBackColor = true;
            kaydetButton.Click += kaydetButton_Click;
            // 
            // epostaTB
            // 
            epostaTB.Location = new Point(353, 428);
            epostaTB.Name = "epostaTB";
            epostaTB.ReadOnly = true;
            epostaTB.Size = new Size(200, 27);
            epostaTB.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(154, 416);
            label7.Name = "label7";
            label7.Size = new Size(129, 41);
            label7.TabIndex = 32;
            label7.Text = "E-Posta:";
            // 
            // vergiNoTB
            // 
            vergiNoTB.Location = new Point(795, 352);
            vergiNoTB.Name = "vergiNoTB";
            vergiNoTB.ReadOnly = true;
            vergiNoTB.Size = new Size(200, 27);
            vergiNoTB.TabIndex = 34;
            vergiNoTB.Visible = false;
            // 
            // HesapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 782);
            Controls.Add(vergiNoTB);
            Controls.Add(epostaTB);
            Controls.Add(label7);
            Controls.Add(kaydetButton);
            Controls.Add(webSitesiTB);
            Controls.Add(duzenleButton);
            Controls.Add(hesapAdiTB);
            Controls.Add(vnlabel);
            Controls.Add(sifreTB);
            Controls.Add(kullaniciAdiTB);
            Controls.Add(wblabel);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(hesapAdiLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "HesapForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "HesapForm";
            Load += HesapForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label wblabel;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label hesapAdiLabel;
        private TextBox kullaniciAdiTB;
        private TextBox sifreTB;
        private Label vnlabel;
        private TextBox hesapAdiTB;
        private Button duzenleButton;
        private TextBox webSitesiTB;
        private Button kaydetButton;
        private TextBox epostaTB;
        private Label label7;
        private TextBox vergiNoTB;
    }
}