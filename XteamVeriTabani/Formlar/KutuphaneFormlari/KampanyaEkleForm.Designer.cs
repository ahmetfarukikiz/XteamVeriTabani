namespace XteamVeriTabani.Formlar.KutuphaneFormlari
{
    partial class KampanyaEkleForm
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
            kampanyaAdiTB = new TextBox();
            label1 = new Label();
            baslangicTarihiDP = new DateTimePicker();
            bitisTarihiDP = new DateTimePicker();
            indirimOraniTB = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            EkleButton = new Button();
            SuspendLayout();
            // 
            // kampanyaAdiTB
            // 
            kampanyaAdiTB.Location = new Point(317, 109);
            kampanyaAdiTB.Name = "kampanyaAdiTB";
            kampanyaAdiTB.Size = new Size(273, 27);
            kampanyaAdiTB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(173, 112);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 1;
            label1.Text = "Kampanya Adı:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // baslangicTarihiDP
            // 
            baslangicTarihiDP.Location = new Point(317, 157);
            baslangicTarihiDP.Name = "baslangicTarihiDP";
            baslangicTarihiDP.Size = new Size(273, 27);
            baslangicTarihiDP.TabIndex = 2;
            // 
            // bitisTarihiDP
            // 
            bitisTarihiDP.Location = new Point(317, 201);
            bitisTarihiDP.Name = "bitisTarihiDP";
            bitisTarihiDP.Size = new Size(273, 27);
            bitisTarihiDP.TabIndex = 3;
            // 
            // indirimOraniTB
            // 
            indirimOraniTB.Location = new Point(317, 245);
            indirimOraniTB.Name = "indirimOraniTB";
            indirimOraniTB.Size = new Size(273, 27);
            indirimOraniTB.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 248);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 5;
            label2.Text = "İndirim Oranı:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 206);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 6;
            label3.Text = "Bitiş Tarihi:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 157);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 7;
            label4.Text = "Başlangıç Tarihi:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EkleButton
            // 
            EkleButton.Location = new Point(173, 294);
            EkleButton.Name = "EkleButton";
            EkleButton.Size = new Size(417, 43);
            EkleButton.TabIndex = 8;
            EkleButton.Text = "Kampanya Ekle";
            EkleButton.UseVisualStyleBackColor = true;
            EkleButton.Click += EkleButton_Click;
            // 
            // KampanyaEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EkleButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(indirimOraniTB);
            Controls.Add(bitisTarihiDP);
            Controls.Add(baslangicTarihiDP);
            Controls.Add(label1);
            Controls.Add(kampanyaAdiTB);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "KampanyaEkleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kampanya Ekle";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox kampanyaAdiTB;
        private Label label1;
        private DateTimePicker baslangicTarihiDP;
        private DateTimePicker bitisTarihiDP;
        private TextBox indirimOraniTB;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button EkleButton;
    }
}