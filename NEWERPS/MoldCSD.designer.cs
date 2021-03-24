namespace NEWERPS
{
    partial class MoldCSD
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
            this.tbMoldNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbMoldNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbMoldClass = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.cbMoldPart = new System.Windows.Forms.ComboBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.chkALL = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMoldNameEN
            // 
            this.tbMoldNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMoldNameEN.Location = new System.Drawing.Point(218, 177);
            this.tbMoldNameEN.Name = "tbMoldNameEN";
            this.tbMoldNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbMoldNameEN.TabIndex = 52;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(22, 187);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 58;
            this.L0003.Text = "英文名稱";
            // 
            // tbMoldNameCN
            // 
            this.tbMoldNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMoldNameCN.Location = new System.Drawing.Point(218, 112);
            this.tbMoldNameCN.Name = "tbMoldNameCN";
            this.tbMoldNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbMoldNameCN.TabIndex = 51;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(22, 122);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 57;
            this.L0002.Text = "中文名稱";
            // 
            // tbMoldClass
            // 
            this.tbMoldClass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMoldClass.Location = new System.Drawing.Point(218, 47);
            this.tbMoldClass.MaxLength = 4;
            this.tbMoldClass.Name = "tbMoldClass";
            this.tbMoldClass.Size = new System.Drawing.Size(102, 34);
            this.tbMoldClass.TabIndex = 50;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(22, 57);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 56;
            this.L0001.Text = "工具類別";
            // 
            // cbMoldPart
            // 
            this.cbMoldPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoldPart.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbMoldPart.FormattingEnabled = true;
            this.cbMoldPart.Items.AddRange(new object[] {
            "面部",
            "底部",
            "其他"});
            this.cbMoldPart.Location = new System.Drawing.Point(218, 246);
            this.cbMoldPart.Name = "cbMoldPart";
            this.cbMoldPart.Size = new System.Drawing.Size(102, 28);
            this.cbMoldPart.TabIndex = 54;
            this.cbMoldPart.SelectedIndexChanged += new System.EventHandler(this.cbMoldPart_SelectedIndexChanged);
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(22, 252);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 55;
            this.L0004.Text = "部位分類";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(192, 314);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 60;
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
            this.dgvWord.TabIndex = 61;
            this.dgvWord.Visible = false;
            // 
            // chkALL
            // 
            this.chkALL.AutoSize = true;
            this.chkALL.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkALL.Location = new System.Drawing.Point(326, 246);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(68, 29);
            this.chkALL.TabIndex = 62;
            this.chkALL.Text = "ALL";
            this.chkALL.UseVisualStyleBackColor = true;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // MoldCSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 409);
            this.Controls.Add(this.chkALL);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbMoldNameEN);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbMoldNameCN);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tbMoldClass);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.cbMoldPart);
            this.Controls.Add(this.L0004);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoldCSD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoldClassSetDetail";
            this.Load += new System.EventHandler(this.MoldClassSetDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMoldNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbMoldNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbMoldClass;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.ComboBox cbMoldPart;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.CheckBox chkALL;
    }
}