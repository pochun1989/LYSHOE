namespace NEWERPS
{
    partial class FactoryQuery
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
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tb公司名 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tb代號 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.B0001 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompany.Location = new System.Drawing.Point(225, 232);
            this.tbCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(200, 34);
            this.tbCompany.TabIndex = 52;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(34, 242);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(72, 18);
            this.L0003.TabIndex = 51;
            this.L0003.Text = "Company";
            // 
            // tb公司名
            // 
            this.tb公司名.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb公司名.Location = new System.Drawing.Point(225, 157);
            this.tb公司名.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb公司名.Name = "tb公司名";
            this.tb公司名.Size = new System.Drawing.Size(200, 34);
            this.tb公司名.TabIndex = 50;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(34, 167);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 49;
            this.L0002.Text = "公司名稱";
            // 
            // tb代號
            // 
            this.tb代號.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb代號.Location = new System.Drawing.Point(225, 84);
            this.tb代號.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb代號.Name = "tb代號";
            this.tb代號.Size = new System.Drawing.Size(200, 34);
            this.tb代號.TabIndex = 48;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(34, 94);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 47;
            this.L0001.Text = "廠區代號";
            // 
            // B0001
            // 
            this.B0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B0001.Location = new System.Drawing.Point(147, 317);
            this.B0001.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B0001.Name = "B0001";
            this.B0001.Size = new System.Drawing.Size(154, 54);
            this.B0001.TabIndex = 53;
            this.B0001.Text = "Query";
            this.B0001.UseVisualStyleBackColor = true;
            this.B0001.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(12, 11);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 71;
            this.dgvWord.Visible = false;
            // 
            // FactoryQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 417);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.B0001);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tb公司名);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tb代號);
            this.Controls.Add(this.L0001);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FactoryQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FactoryQuery";
            this.Load += new System.EventHandler(this.FactoryQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tb公司名;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tb代號;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button B0001;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}