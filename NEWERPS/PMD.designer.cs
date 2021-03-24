namespace NEWERPS
{
    partial class PMD
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
            this.tbProduceNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tbProduceNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbProduceNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProduceNo
            // 
            this.tbProduceNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbProduceNo.Location = new System.Drawing.Point(221, 47);
            this.tbProduceNo.Name = "tbProduceNo";
            this.tbProduceNo.Size = new System.Drawing.Size(102, 34);
            this.tbProduceNo.TabIndex = 37;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(28, 57);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 36;
            this.L0001.Text = "加工編號";
            // 
            // tbProduceNameEN
            // 
            this.tbProduceNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbProduceNameEN.Location = new System.Drawing.Point(221, 177);
            this.tbProduceNameEN.MaxLength = 50;
            this.tbProduceNameEN.Name = "tbProduceNameEN";
            this.tbProduceNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbProduceNameEN.TabIndex = 35;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(28, 187);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 34;
            this.L0003.Text = "英文名稱";
            // 
            // tbProduceNameCN
            // 
            this.tbProduceNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbProduceNameCN.Location = new System.Drawing.Point(221, 112);
            this.tbProduceNameCN.MaxLength = 50;
            this.tbProduceNameCN.Name = "tbProduceNameCN";
            this.tbProduceNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbProduceNameCN.TabIndex = 33;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(28, 122);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 32;
            this.L0002.Text = "中文名稱";
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
            this.dgvWord.TabIndex = 41;
            this.dgvWord.Visible = false;
            // 
            // ProduceMethodDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 361);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbProduceNo);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.tbProduceNameEN);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbProduceNameCN);
            this.Controls.Add(this.L0002);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProduceMethodDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProduceMethodDetail";
            this.Load += new System.EventHandler(this.ProduceMethodDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProduceNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbProduceNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbProduceNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}