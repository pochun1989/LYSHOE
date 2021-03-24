namespace NEWERPS
{
    partial class PSD
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
            this.tbPartNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbPartNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbPartNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.cbPartClass = new System.Windows.Forms.ComboBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.chkALL = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPartNameEN
            // 
            this.tbPartNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNameEN.Location = new System.Drawing.Point(218, 177);
            this.tbPartNameEN.Name = "tbPartNameEN";
            this.tbPartNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbPartNameEN.TabIndex = 62;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(22, 187);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 68;
            this.L0003.Text = "英文名稱";
            // 
            // tbPartNameCN
            // 
            this.tbPartNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNameCN.Location = new System.Drawing.Point(218, 112);
            this.tbPartNameCN.Name = "tbPartNameCN";
            this.tbPartNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbPartNameCN.TabIndex = 61;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(22, 122);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 67;
            this.L0002.Text = "中文名稱";
            // 
            // tbPartNo
            // 
            this.tbPartNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNo.Location = new System.Drawing.Point(218, 47);
            this.tbPartNo.MaxLength = 4;
            this.tbPartNo.Name = "tbPartNo";
            this.tbPartNo.Size = new System.Drawing.Size(102, 34);
            this.tbPartNo.TabIndex = 60;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(22, 57);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 66;
            this.L0001.Text = "部位代號";
            // 
            // cbPartClass
            // 
            this.cbPartClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartClass.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPartClass.FormattingEnabled = true;
            this.cbPartClass.Items.AddRange(new object[] {
            "面部",
            "底部",
            "配件",
            "包材",
            "其他"});
            this.cbPartClass.Location = new System.Drawing.Point(218, 246);
            this.cbPartClass.Name = "cbPartClass";
            this.cbPartClass.Size = new System.Drawing.Size(102, 28);
            this.cbPartClass.TabIndex = 64;
            this.cbPartClass.SelectedIndexChanged += new System.EventHandler(this.cbPartClass_SelectedIndexChanged);
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(22, 252);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 65;
            this.L0004.Text = "部位分類";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(192, 314);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 69;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(483, 358);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 70;
            this.dgvWord.Visible = false;
            // 
            // chkALL
            // 
            this.chkALL.AutoSize = true;
            this.chkALL.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkALL.Location = new System.Drawing.Point(326, 246);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(68, 29);
            this.chkALL.TabIndex = 71;
            this.chkALL.Text = "ALL";
            this.chkALL.UseVisualStyleBackColor = true;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // PartSetDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 409);
            this.Controls.Add(this.chkALL);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbPartNameEN);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbPartNameCN);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tbPartNo);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.cbPartClass);
            this.Controls.Add(this.L0004);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartSetDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartSetDetail";
            this.Load += new System.EventHandler(this.PartSetDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPartNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbPartNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbPartNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.ComboBox cbPartClass;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.CheckBox chkALL;
    }
}