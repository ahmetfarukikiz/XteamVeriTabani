
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
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            oyunuGorButton = new Button();
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
            oyunlarListBox.MouseDoubleClick += oyunlarListBox_MouseDoubleClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(307, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 83);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 3;
            label2.Text = "Oyun İsmi";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(517, 106);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(517, 83);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Kategoriler";
            // 
            // button1
            // 
            button1.Location = new Point(715, 106);
            button1.Name = "button1";
            button1.Size = new Size(153, 29);
            button1.TabIndex = 6;
            button1.Text = "Oyunu Ara";
            button1.UseVisualStyleBackColor = true;
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
            // MagazaMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 778);
            Controls.Add(oyunuGorButton);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private Label label4;
        private Button oyunuGorButton;
    }
}