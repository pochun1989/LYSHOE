namespace NEWERPS
{
    partial class DCD
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
            this.tbDevClass = new System.Windows.Forms.TextBox();
            this.tbDevNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbDevNameCN = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDevClass
            // 
            this.tbDevClass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDevClass.Location = new System.Drawing.Point(233, 47);
            this.tbDevClass.MaxLength = 4;
            this.tbDevClass.Name = "tbDevClass";
            this.tbDevClass.Size = new System.Drawing.Size(124, 34);
            this.tbDevClass.TabIndex = 41;
            // 
            // tbDevNameEN
            // 
            this.tbDevNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDevNameEN.Location = new System.Drawing.Point(233, 177);
            this.tbDevNameEN.Name = "tbDevNameEN";
            this.tbDevNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbDevNameEN.TabIndex = 44;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(21, 187);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 47;
            this.L0003.Text = "英文名稱";
            // 
            // tbDevNameCN
            // 
            this.tbDevNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDevNameCN.Location = new System.Drawing.Point(233, 112);
            this.tbDevNameCN.Name = "tbDevNameCN";
            this.tbDevNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbDevNameCN.TabIndex = 43;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(21, 57);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 45;
            this.L0001.Text = "開發類型";
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(21, 122);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 46;
            this.L0002.Text = "中文名稱";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(192, 254);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 49;
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
            this.dgvWord.TabIndex = 50;
            this.dgvWord.Visible = false;
            // 
            // DevelopClassDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 361);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbDevClass);
            this.Controls.Add(this.tbDevNameEN);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbDevNameCN);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.L0002);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevelopClassDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevelopClassDetail";
            this.Load += new System.EventHandler(this.DevelopClassDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDevClass;
        private System.Windows.Forms.TextBox tbDevNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbDevNameCN;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}