namespace NEWERPS
{
    partial class CBID
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
            this.dgvCompanyData = new System.Windows.Forms.DataGridView();
            this.L0001 = new System.Windows.Forms.Label();
            this.L0004 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbCompanyNo = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompanyData
            // 
            this.dgvCompanyData.AllowUserToAddRows = false;
            this.dgvCompanyData.AllowUserToDeleteRows = false;
            this.dgvCompanyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyData.Location = new System.Drawing.Point(32, 254);
            this.dgvCompanyData.Name = "dgvCompanyData";
            this.dgvCompanyData.ReadOnly = true;
            this.dgvCompanyData.RowHeadersVisible = false;
            this.dgvCompanyData.RowTemplate.Height = 27;
            this.dgvCompanyData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanyData.Size = new System.Drawing.Size(722, 276);
            this.dgvCompanyData.TabIndex = 0;
            this.dgvCompanyData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyData_CellDoubleClick);
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(29, 44);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 14;
            this.L0001.Text = "公司代號";
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(317, 44);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 15;
            this.L0004.Text = "公司電話";
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(29, 97);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 16;
            this.L0002.Text = "公司名稱";
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(29, 147);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 17;
            this.L0003.Text = "公司地址";
            // 
            // tbCompanyNo
            // 
            this.tbCompanyNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompanyNo.Location = new System.Drawing.Point(156, 34);
            this.tbCompanyNo.Name = "tbCompanyNo";
            this.tbCompanyNo.Size = new System.Drawing.Size(140, 34);
            this.tbCompanyNo.TabIndex = 18;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(343, 195);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 19;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbTel
            // 
            this.tbTel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbTel.Location = new System.Drawing.Point(447, 34);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(307, 34);
            this.tbTel.TabIndex = 20;
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompanyName.Location = new System.Drawing.Point(156, 87);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(598, 34);
            this.tbCompanyName.TabIndex = 21;
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbAddress.Location = new System.Drawing.Point(156, 137);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(598, 34);
            this.tbAddress.TabIndex = 22;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(776, 517);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(47, 39);
            this.dgvWord.TabIndex = 23;
            this.dgvWord.Visible = false;
            // 
            // CompanyInformationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 556);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbCompanyName);
            this.Controls.Add(this.tbTel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbCompanyNo);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.dgvCompanyData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyInformationDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyInformationDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompanyData;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbCompanyNo;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}