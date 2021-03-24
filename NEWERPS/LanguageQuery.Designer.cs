namespace NEWERPS
{
    partial class LanguageQuery
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
            this.L0001 = new System.Windows.Forms.Label();
            this.tb表單 = new System.Windows.Forms.TextBox();
            this.B0001 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // L0001
            // 
            this.L0001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(40, 59);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(92, 25);
            this.L0001.TabIndex = 79;
            this.L0001.Text = "表單代號";
            // 
            // tb表單
            // 
            this.tb表單.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb表單.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb表單.Location = new System.Drawing.Point(45, 95);
            this.tb表單.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb表單.Name = "tb表單";
            this.tb表單.Size = new System.Drawing.Size(212, 34);
            this.tb表單.TabIndex = 80;
            // 
            // B0001
            // 
            this.B0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B0001.Location = new System.Drawing.Point(101, 155);
            this.B0001.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B0001.Name = "B0001";
            this.B0001.Size = new System.Drawing.Size(114, 50);
            this.B0001.TabIndex = 81;
            this.B0001.Text = "Query";
            this.B0001.UseVisualStyleBackColor = true;
            this.B0001.Click += new System.EventHandler(this.B0001_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(248, 216);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 101;
            this.dgvWord.Visible = false;
            // 
            // LanguageQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 255);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.B0001);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.tb表單);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LanguageQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanguageQuery";
            this.Load += new System.EventHandler(this.LanguageQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tb表單;
        private System.Windows.Forms.Button B0001;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}