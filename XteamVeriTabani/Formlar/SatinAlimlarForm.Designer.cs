namespace XteamVeriTabani.Formlar
{
    partial class SatinAlimlarForm
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
            satinAlimDGW = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)satinAlimDGW).BeginInit();
            SuspendLayout();
            // 
            // satinAlimDGW
            // 
            satinAlimDGW.AllowUserToAddRows = false;
            satinAlimDGW.AllowUserToDeleteRows = false;
            satinAlimDGW.AllowUserToResizeColumns = false;
            satinAlimDGW.AllowUserToResizeRows = false;
            satinAlimDGW.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            satinAlimDGW.Location = new Point(79, 131);
            satinAlimDGW.Name = "satinAlimDGW";
            satinAlimDGW.ReadOnly = true;
            satinAlimDGW.RowHeadersWidth = 51;
            satinAlimDGW.Size = new Size(836, 465);
            satinAlimDGW.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(79, 63);
            label1.Name = "label1";
            label1.Size = new Size(318, 46);
            label1.TabIndex = 1;
            label1.Text = "Satın Alım Geçmişi";
            // 
            // SatinAlimlarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 684);
            Controls.Add(label1);
            Controls.Add(satinAlimDGW);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "SatinAlimlarForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SatinAlimlarForm";
            Load += SatinAlimlarForm_Load;
            ((System.ComponentModel.ISupportInitialize)satinAlimDGW).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView satinAlimDGW;
        private Label label1;
    }
}