namespace XteamVeriTabani
{
    partial class ArkadasMenuForm
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
            kAdiTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            arkadasEkleButton = new Button();
            label3 = new Label();
            hesabiGorButton = new Button();
            silButton = new Button();
            arkadasListBox = new ListBox();
            gelenIstekListBox = new ListBox();
            kabuletBtn = new Button();
            reddetBtn = new Button();
            SuspendLayout();
            // 
            // kAdiTB
            // 
            kAdiTB.Location = new Point(829, 131);
            kAdiTB.Name = "kAdiTB";
            kAdiTB.Size = new Size(206, 27);
            kAdiTB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(829, 93);
            label1.Name = "label1";
            label1.Size = new Size(123, 28);
            label1.TabIndex = 1;
            label1.Text = "Oyuncu Nick";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(42, 21);
            label2.Name = "label2";
            label2.Size = new Size(176, 46);
            label2.TabIndex = 3;
            label2.Text = "Arkadaşlar";
            // 
            // arkadasEkleButton
            // 
            arkadasEkleButton.Location = new Point(829, 173);
            arkadasEkleButton.Name = "arkadasEkleButton";
            arkadasEkleButton.Size = new Size(206, 29);
            arkadasEkleButton.TabIndex = 4;
            arkadasEkleButton.Text = "Arkadaş Ekle";
            arkadasEkleButton.UseVisualStyleBackColor = true;
            arkadasEkleButton.Click += arkadasEkleButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(53, 409);
            label3.Name = "label3";
            label3.Size = new Size(223, 46);
            label3.TabIndex = 6;
            label3.Text = "Gelen İstekler";
            // 
            // hesabiGorButton
            // 
            hesabiGorButton.Enabled = false;
            hesabiGorButton.Location = new Point(554, 361);
            hesabiGorButton.Name = "hesabiGorButton";
            hesabiGorButton.Size = new Size(94, 29);
            hesabiGorButton.TabIndex = 7;
            hesabiGorButton.Text = "Hesabı Gör";
            hesabiGorButton.UseVisualStyleBackColor = true;
            hesabiGorButton.Click += hesabiGorButton_Click;
            // 
            // silButton
            // 
            silButton.Enabled = false;
            silButton.Location = new Point(454, 361);
            silButton.Name = "silButton";
            silButton.Size = new Size(94, 29);
            silButton.TabIndex = 8;
            silButton.Text = "Sil";
            silButton.UseVisualStyleBackColor = true;
            silButton.Click += silButton_Click;
            // 
            // arkadasListBox
            // 
            arkadasListBox.FormattingEnabled = true;
            arkadasListBox.Location = new Point(42, 80);
            arkadasListBox.Name = "arkadasListBox";
            arkadasListBox.Size = new Size(606, 264);
            arkadasListBox.TabIndex = 9;
            arkadasListBox.SelectedIndexChanged += arkadasListBox_SelectedIndexChanged;
            // 
            // gelenIstekListBox
            // 
            gelenIstekListBox.FormattingEnabled = true;
            gelenIstekListBox.Location = new Point(53, 470);
            gelenIstekListBox.Name = "gelenIstekListBox";
            gelenIstekListBox.Size = new Size(606, 224);
            gelenIstekListBox.TabIndex = 10;
            gelenIstekListBox.SelectedIndexChanged += gelenIstekListBox_SelectedIndexChanged;
            // 
            // kabuletBtn
            // 
            kabuletBtn.Enabled = false;
            kabuletBtn.Location = new Point(464, 700);
            kabuletBtn.Name = "kabuletBtn";
            kabuletBtn.Size = new Size(94, 29);
            kabuletBtn.TabIndex = 12;
            kabuletBtn.Text = "Kabul Et";
            kabuletBtn.UseVisualStyleBackColor = true;
            kabuletBtn.Click += kabuletBtn_Click;
            // 
            // reddetBtn
            // 
            reddetBtn.Enabled = false;
            reddetBtn.Location = new Point(564, 700);
            reddetBtn.Name = "reddetBtn";
            reddetBtn.Size = new Size(94, 29);
            reddetBtn.TabIndex = 11;
            reddetBtn.Text = "Reddet";
            reddetBtn.UseVisualStyleBackColor = true;
            reddetBtn.Click += reddetBtn_Click;
            // 
            // ArkadasMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 782);
            Controls.Add(kabuletBtn);
            Controls.Add(reddetBtn);
            Controls.Add(gelenIstekListBox);
            Controls.Add(arkadasListBox);
            Controls.Add(silButton);
            Controls.Add(hesabiGorButton);
            Controls.Add(label3);
            Controls.Add(arkadasEkleButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(kAdiTB);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ArkadasMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ArkadasMenuFormcs";
            Load += ArkadasMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox kAdiTB;
        private Label label1;
        private Label label2;
        private Button arkadasEkleButton;
        private Label label3;
        private Button hesabiGorButton;
        private Button silButton;
        private ListBox arkadasListBox;
        private ListBox gelenIstekListBox;
        private Button kabuletBtn;
        private Button reddetBtn;
    }
}