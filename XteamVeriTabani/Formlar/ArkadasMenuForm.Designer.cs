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
            hesapAdiTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            arkadasEkleButton = new Button();
            label3 = new Label();
            hesabiGorButton = new Button();
            silButton = new Button();
            arkadasListBox = new ListBox();
            listBox1 = new ListBox();
            kabuletBtn = new Button();
            reddetBtn = new Button();
            SuspendLayout();
            // 
            // hesapAdiTB
            // 
            hesapAdiTB.Location = new Point(829, 131);
            hesapAdiTB.Name = "hesapAdiTB";
            hesapAdiTB.Size = new Size(206, 27);
            hesapAdiTB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(829, 93);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 1;
            label1.Text = "Hesap Adı";
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
            hesabiGorButton.Location = new Point(554, 361);
            hesabiGorButton.Name = "hesabiGorButton";
            hesabiGorButton.Size = new Size(94, 29);
            hesabiGorButton.TabIndex = 7;
            hesabiGorButton.Text = "Hesabı Gör";
            hesabiGorButton.UseVisualStyleBackColor = true;
            // 
            // silButton
            // 
            silButton.Location = new Point(454, 361);
            silButton.Name = "silButton";
            silButton.Size = new Size(94, 29);
            silButton.TabIndex = 8;
            silButton.Text = "Sil";
            silButton.UseVisualStyleBackColor = true;
            // 
            // arkadasListBox
            // 
            arkadasListBox.FormattingEnabled = true;
            arkadasListBox.Location = new Point(42, 80);
            arkadasListBox.Name = "arkadasListBox";
            arkadasListBox.Size = new Size(606, 264);
            arkadasListBox.TabIndex = 9;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(53, 470);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(606, 224);
            listBox1.TabIndex = 10;
            // 
            // kabuletBtn
            // 
            kabuletBtn.Location = new Point(464, 700);
            kabuletBtn.Name = "kabuletBtn";
            kabuletBtn.Size = new Size(94, 29);
            kabuletBtn.TabIndex = 12;
            kabuletBtn.Text = "Kabul Et";
            kabuletBtn.UseVisualStyleBackColor = true;
            // 
            // reddetBtn
            // 
            reddetBtn.Location = new Point(564, 700);
            reddetBtn.Name = "reddetBtn";
            reddetBtn.Size = new Size(94, 29);
            reddetBtn.TabIndex = 11;
            reddetBtn.Text = "Reddet";
            reddetBtn.UseVisualStyleBackColor = true;
            // 
            // ArkadasMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 782);
            Controls.Add(kabuletBtn);
            Controls.Add(reddetBtn);
            Controls.Add(listBox1);
            Controls.Add(arkadasListBox);
            Controls.Add(silButton);
            Controls.Add(hesabiGorButton);
            Controls.Add(label3);
            Controls.Add(arkadasEkleButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hesapAdiTB);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            Name = "ArkadasMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ArkadasMenuFormcs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox hesapAdiTB;
        private Label label1;
        private Label label2;
        private Button arkadasEkleButton;
        private Label label3;
        private Button hesabiGorButton;
        private Button silButton;
        private ListBox arkadasListBox;
        private ListBox listBox1;
        private Button kabuletBtn;
        private Button reddetBtn;
    }
}