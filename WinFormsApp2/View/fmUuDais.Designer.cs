namespace QuanLySuShi
{
    partial class fmUuDais
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
            btnApdung = new Button();
            dtgvUuDai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgvUuDai).BeginInit();
            SuspendLayout();
            // 
            // btnApdung
            // 
            btnApdung.Location = new Point(470, 346);
            btnApdung.Name = "btnApdung";
            btnApdung.Size = new Size(94, 29);
            btnApdung.TabIndex = 6;
            btnApdung.Text = "Áp Dụng";
            btnApdung.UseVisualStyleBackColor = true;
            btnApdung.Click += btnApdung_Click;
            // 
            // dtgvUuDai
            // 
            dtgvUuDai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUuDai.Location = new Point(15, 61);
            dtgvUuDai.Name = "dtgvUuDai";
            dtgvUuDai.RowHeadersWidth = 51;
            dtgvUuDai.Size = new Size(549, 279);
            dtgvUuDai.TabIndex = 7;
            dtgvUuDai.RowHeaderMouseClick += dtgvUuDai_RowHeaderMouseClick;
            // 
            // fmUuDais
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 387);
            Controls.Add(dtgvUuDai);
            Controls.Add(btnApdung);
            Name = "fmUuDais";
            Text = "Ưu Đãi";
            FormClosing += fmUuDais_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dtgvUuDai).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnApdung;
        private DataGridView dtgvUuDai;
    }
}