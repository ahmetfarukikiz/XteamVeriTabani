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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            toplamTurarLabel = new Label();
            label3 = new Label();
            bakiyeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(56, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(780, 351);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(56, 495);
            button1.Name = "button1";
            button1.Size = new Size(169, 45);
            button1.TabIndex = 3;
            button1.Text = "Siparişi Tamamla";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 11F);
            button2.Location = new Point(231, 495);
            button2.Name = "button2";
            button2.Size = new Size(100, 45);
            button2.TabIndex = 4;
            button2.Text = "Sil";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(598, 497);
            label2.Name = "label2";
            label2.Size = new Size(166, 35);
            label2.TabIndex = 5;
            label2.Text = "Toplam Tutar:";
            // 
            // toplamTurarLabel
            // 
            toplamTurarLabel.AutoSize = true;
            toplamTurarLabel.Font = new Font("Segoe UI", 15F);
            toplamTurarLabel.Location = new Point(770, 497);
            toplamTurarLabel.Name = "toplamTurarLabel";
            toplamTurarLabel.Size = new Size(66, 35);
            toplamTurarLabel.TabIndex = 6;
            toplamTurarLabel.Text = "20TL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(661, 58);
            label3.Name = "label3";
            label3.Size = new Size(90, 35);
            label3.TabIndex = 7;
            label3.Text = "Bakiye:";
            // 
            // bakiyeLabel
            // 
            bakiyeLabel.AutoSize = true;
            bakiyeLabel.Font = new Font("Segoe UI", 15F);
            bakiyeLabel.Location = new Point(757, 58);
            bakiyeLabel.Name = "bakiyeLabel";
            bakiyeLabel.Size = new Size(79, 35);
            bakiyeLabel.TabIndex = 8;
            bakiyeLabel.Text = "220TL";
            // 
            // SepetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 596);
            Controls.Add(bakiyeLabel);
            Controls.Add(label3);
            Controls.Add(toplamTurarLabel);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "SepetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SepetForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label toplamTurarLabel;
        private Label label3;
        private Label bakiyeLabel;
    }
}