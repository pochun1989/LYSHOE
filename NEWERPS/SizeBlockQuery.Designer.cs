namespace NEWERPS
{
    partial class SizeBlockQuery
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
            this.L0003 = new System.Windows.Forms.Label();
            this.tb英文 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tb中文 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tb代號 = new System.Windows.Forms.TextBox();
            this.B0001 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(67, 188);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 142;
            this.L0003.Text = "英文說明";
            // 
            // tb英文
            // 
            this.tb英文.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb英文.Location = new System.Drawing.Point(248, 178);
            this.tb英文.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb英文.Name = "tb英文";
            this.tb英文.Size = new System.Drawing.Size(253, 34);
            this.tb英文.TabIndex = 143;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(67, 129);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 140;
            this.L0002.Text = "中文說明";
            // 
            // tb中文
            // 
            this.tb中文.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb中文.Location = new System.Drawing.Point(248, 119);
            this.tb中文.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb中文.Name = "tb中文";
            this.tb中文.Size = new System.Drawing.Size(253, 34);
            this.tb中文.TabIndex = 141;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(67, 70);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 134;
            this.L0001.Text = "分段代號";
            // 
            // tb代號
            // 
            this.tb代號.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb代號.Location = new System.Drawing.Point(248, 60);
            this.tb代號.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb代號.Name = "tb代號";
            this.tb代號.Size = new System.Drawing.Size(253, 34);
            this.tb代號.TabIndex = 135;
            // 
            // B0001
            // 
            this.B0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B0001.Location = new System.Drawing.Point(199, 235);
            this.B0001.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B0001.Name = "B0001";
            this.B0001.Size = new System.Drawing.Size(107, 49);
            this.B0001.TabIndex = 144;
            this.B0001.Text = "Query";
            this.B0001.UseVisualStyleBackColor = true;
            this.B0001.Click += new System.EventHandler(this.B0001_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(477, 275);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 145;
            this.dgvWord.Visible = false;
            // 
            // SizeBlockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 314);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.B0001);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tb英文);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tb中文);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.tb代號);
            this.Name = "SizeBlockQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SizeBlockModify";
            this.Load += new System.EventHandler(this.SizeBlockQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L0003;
        internal System.Windows.Forms.TextBox tb英文;
        private System.Windows.Forms.Label L0002;
        internal System.Windows.Forms.TextBox tb中文;
        private System.Windows.Forms.Label L0001;
        internal System.Windows.Forms.TextBox tb代號;
        private System.Windows.Forms.Button B0001;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}