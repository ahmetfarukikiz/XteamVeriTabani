
namespace XteamVeriTabani
{
    partial class MagazaMenuForm
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
            oyunlarListBox = new ListBox();
            oyunAdiTB = new TextBox();
            label2 = new Label();
            kategoriComboBox = new ComboBox();
            label3 = new Label();
            oyunuAraButton = new Button();
            label4 = new Label();
            oyunuGorButton = new Button();
            bakiyeLabel = new Label();
            sepetButton = new Button();
            bakiyeEkleButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display Semib", 25F);
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(168, 56);
            label1.TabIndex = 0;
            label1.Text = "Mağaza";
            // 
            // oyunlarListBox
            // 
            oyunlarListBox.FormattingEnabled = true;
            oyunlarListBox.Location = new Point(48, 192);
            oyunlarListBox.Name = "oyunlarListBox";
            oyunlarListBox.Size = new Size(1067, 544);
            oyunlarListBox.TabIndex = 1;
            oyunlarListBox.SelectedIndexChanged += oyunlarListBox_SelectedIndexChanged;
            oyunlarListBox.MouseDoubleClick += oyunlarListBox_MouseDoubleClick;
            // 
            // oyunAdiTB
            // 
            oyunAdiTB.Location = new Point(250, 125);
            oyunAdiTB.Name = "oyunAdiTB";
            oyunAdiTB.Size = new Size(160, 27);
            oyunAdiTB.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 102);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 3;
            label2.Text = "Oyun İsmi";
            // 
            // kategoriComboBox
            // 
            kategoriComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            kategoriComboBox.FormattingEnabled = true;
            kategoriComboBox.Location = new Point(460, 125);
            kategoriComboBox.Name = "kategoriComboBox";
            kategoriComboBox.Size = new Size(151, 28);
            kategoriComboBox.TabIndex = 4;
            kategoriComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(460, 102);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Kategoriler";
            // 
            // oyunuAraButton
            // 
            oyunuAraButton.Location = new Point(658, 125);
            oyunuAraButton.Name = "oyunuAraButton";
            oyunuAraButton.Size = new Size(153, 29);
            oyunuAraButton.TabIndex = 6;
            oyunuAraButton.Text = "Oyunu Ara";
            oyunuAraButton.UseVisualStyleBackColor = true;
            oyunuAraButton.Click += OyunuAraButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F);
            label4.Location = new Point(993, 138);
            label4.Name = "label4";
            label4.Size = new Size(122, 41);
            label4.TabIndex = 7;
            label4.Text = "Oyunlar";
            // 
            // oyunuGorButton
            // 
            oyunuGorButton.Location = new Point(968, 742);
            oyunuGorButton.Name = "oyunuGorButton";
            oyunuGorButton.Size = new Size(147, 29);
            oyunuGorButton.TabIndex = 8;
            oyunuGorButton.Text = "Oyunu Gör";
            oyunuGorButton.UseVisualStyleBackColor = true;
            oyunuGorButton.Click += oyunuGorButton_Click;
            // 
            // bakiyeLabel
            // 
            bakiyeLabel.AutoSize = true;
            bakiyeLabel.Font = new Font("Segoe UI", 16F);
            bakiyeLabel.Location = new Point(969, 28);
            bakiyeLabel.Name = "bakiyeLabel";
            bakiyeLabel.Size = new Size(163, 37);
            bakiyeLabel.TabIndex = 10;
            bakiyeLabel.Text = "Bakiye: 12TL";
            // 
            // sepetButton
            // 
            sepetButton.Location = new Point(838, 28);
            sepetButton.Name = "sepetButton";
            sepetButton.Size = new Size(125, 41);
            sepetButton.TabIndex = 11;
            sepetButton.Text = "Sepet";
            sepetButton.UseVisualStyleBackColor = true;
            sepetButton.Click += sepetButton_Click;
            // 
            // bakiyeEkleButton
            // 
            bakiyeEkleButton.Location = new Point(969, 68);
            bakiyeEkleButton.Name = "bakiyeEkleButton";
            bakiyeEkleButton.Size = new Size(94, 32);
            bakiyeEkleButton.TabIndex = 12;
            bakiyeEkleButton.Text = "+200 TL";
            bakiyeEkleButton.UseVisualStyleBackColor = true;
            bakiyeEkleButton.Click += bakiyeEkleButton_Click;
            // 
            // MagazaMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 796);
            Controls.Add(bakiyeEkleButton);
            Controls.Add(sepetButton);
            Controls.Add(bakiyeLabel);
            Controls.Add(oyunuGorButton);
            Controls.Add(label4);
            Controls.Add(oyunuAraButton);
            Controls.Add(label3);
            Controls.Add(kategoriComboBox);
            Controls.Add(label2);
            Controls.Add(oyunAdiTB);
            Controls.Add(oyunlarListBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MagazaMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MagazaMenu";
            Load += MagazaMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private ListBox oyunlarListBox;
        private TextBox oyunAdiTB;
        private Label label2;
        private ComboBox kategoriComboBox;
        private Label label3;
        private Button oyunuAraButton;
        private Label label4;
        private Button oyunuGorButton;
        private Label bakiyeLabel;
        private Button sepetButton;
        private Button bakiyeEkleButton;
    }
}