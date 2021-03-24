namespace NEWERPS
{
    partial class UID
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
            this.tbUnitNameEN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbUnitNameCN = new System.Windows.Forms.TextBox();
            this.tbUnitNo = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(28, 57);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 27;
            this.L0001.Text = "單位編號";
            // 
            // tbUnitNameEN
            // 
            this.tbUnitNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbUnitNameEN.Location = new System.Drawing.Point(221, 177);
            this.tbUnitNameEN.MaxLength = 50;
            this.tbUnitNameEN.Name = "tbUnitNameEN";
            this.tbUnitNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbUnitNameEN.TabIndex = 30;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(28, 122);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 25;
            this.L0002.Text = "中文名稱";
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(28, 187);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 29;
            this.L0003.Text = "英文名稱";
            // 
            // tbUnitNameCN
            // 
            this.tbUnitNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbUnitNameCN.Location = new System.Drawing.Point(221, 112);
            this.tbUnitNameCN.MaxLength = 50;
            this.tbUnitNameCN.Name = "tbUnitNameCN";
            this.tbUnitNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbUnitNameCN.TabIndex = 26;
            // 
            // tbUnitNo
            // 
            this.tbUnitNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbUnitNo.Location = new System.Drawing.Point(221, 47);
            this.tbUnitNo.Name = "tbUnitNo";
            this.tbUnitNo.Size = new System.Drawing.Size(102, 34);
            this.tbUnitNo.TabIndex = 28;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(192, 254);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 39;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(483, 310);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 40;
            this.dgvWord.Visible = false;
            // 
            // UnitInformationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 361);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.tbUnitNameEN);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbUnitNameCN);
            this.Controls.Add(this.tbUnitNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitInformationDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnitInformationDetail";
            this.Load += new System.EventHandler(this.UnitInformationDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbUnitNameEN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbUnitNameCN;
        private System.Windows.Forms.TextBox tbUnitNo;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}