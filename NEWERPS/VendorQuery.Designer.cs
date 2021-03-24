namespace NEWERPS
{
    partial class VendorQuery
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
            this.tb英文1 = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tb廠名1 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tb廠代1 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.B0001 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tb英文1
            // 
            this.tb英文1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb英文1.Location = new System.Drawing.Point(132, 141);
            this.tb英文1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb英文1.Name = "tb英文1";
            this.tb英文1.Size = new System.Drawing.Size(333, 34);
            this.tb英文1.TabIndex = 86;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(18, 144);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(92, 25);
            this.L0003.TabIndex = 85;
            this.L0003.Text = "廠商英文";
            // 
            // tb廠名1
            // 
            this.tb廠名1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb廠名1.Location = new System.Drawing.Point(132, 83);
            this.tb廠名1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb廠名1.Name = "tb廠名1";
            this.tb廠名1.Size = new System.Drawing.Size(333, 34);
            this.tb廠名1.TabIndex = 84;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(18, 86);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(92, 25);
            this.L0002.TabIndex = 83;
            this.L0002.Text = "廠商全名";
            // 
            // tb廠代1
            // 
            this.tb廠代1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb廠代1.Location = new System.Drawing.Point(132, 20);
            this.tb廠代1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb廠代1.Name = "tb廠代1";
            this.tb廠代1.Size = new System.Drawing.Size(333, 34);
            this.tb廠代1.TabIndex = 82;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(18, 23);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(92, 25);
            this.L0001.TabIndex = 81;
            this.L0001.Text = "廠商代號";
            // 
            // B0001
            // 
            this.B0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B0001.Location = new System.Drawing.Point(200, 203);
            this.B0001.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B0001.Name = "B0001";
            this.B0001.Size = new System.Drawing.Size(107, 49);
            this.B0001.TabIndex = 87;
            this.B0001.Text = "Query";
            this.B0001.UseVisualStyleBackColor = true;
            this.B0001.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(12, 190);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 89;
            this.dgvWord.Visible = false;
            // 
            // VendorQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 277);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.B0001);
            this.Controls.Add(this.tb英文1);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tb廠名1);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tb廠代1);
            this.Controls.Add(this.L0001);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VendorQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VendorQuery";
            this.Load += new System.EventHandler(this.VendorQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tb英文1;
        private System.Windows.Forms.Label L0003;
        internal System.Windows.Forms.TextBox tb廠名1;
        private System.Windows.Forms.Label L0002;
        internal System.Windows.Forms.TextBox tb廠代1;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button B0001;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}