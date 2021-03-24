namespace NEWERPS
{
    partial class SOSMBOMBWBH
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
            this.chkALL = new System.Windows.Forms.CheckBox();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbPartName = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbPartNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.cbPartClass = new System.Windows.Forms.ComboBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.dgvPartSetData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSetData)).BeginInit();
            this.SuspendLayout();
            // 
            // chkALL
            // 
            this.chkALL.AutoSize = true;
            this.chkALL.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkALL.Location = new System.Drawing.Point(325, 62);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(68, 29);
            this.chkALL.TabIndex = 82;
            this.chkALL.Text = "ALL";
            this.chkALL.UseVisualStyleBackColor = true;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(1004, 3);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 81;
            this.dgvWord.Visible = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(852, 35);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 80;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbPartName
            // 
            this.tbPartName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartName.Location = new System.Drawing.Point(540, 34);
            this.tbPartName.Name = "tbPartName";
            this.tbPartName.Size = new System.Drawing.Size(284, 34);
            this.tbPartName.TabIndex = 73;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(399, 44);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(36, 18);
            this.L0002.TabIndex = 78;
            this.L0002.Text = "名稱";
            // 
            // tbPartNo
            // 
            this.tbPartNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNo.Location = new System.Drawing.Point(217, 14);
            this.tbPartNo.MaxLength = 4;
            this.tbPartNo.Name = "tbPartNo";
            this.tbPartNo.Size = new System.Drawing.Size(102, 34);
            this.tbPartNo.TabIndex = 72;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(21, 24);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 77;
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
            this.cbPartClass.Location = new System.Drawing.Point(217, 62);
            this.cbPartClass.Name = "cbPartClass";
            this.cbPartClass.Size = new System.Drawing.Size(102, 28);
            this.cbPartClass.TabIndex = 75;
            this.cbPartClass.SelectedIndexChanged += new System.EventHandler(this.cbPartClass_SelectedIndexChanged);
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(21, 68);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 76;
            this.L0003.Text = "部位分類";
            // 
            // dgvPartSetData
            // 
            this.dgvPartSetData.AllowUserToAddRows = false;
            this.dgvPartSetData.AllowUserToDeleteRows = false;
            this.dgvPartSetData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartSetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartSetData.Location = new System.Drawing.Point(13, 100);
            this.dgvPartSetData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPartSetData.Name = "dgvPartSetData";
            this.dgvPartSetData.ReadOnly = true;
            this.dgvPartSetData.RowTemplate.Height = 27;
            this.dgvPartSetData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartSetData.Size = new System.Drawing.Size(940, 368);
            this.dgvPartSetData.TabIndex = 83;
            this.dgvPartSetData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartSetData_CellDoubleClick);
            // 
            // SOSMBOMBWBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 485);
            this.Controls.Add(this.dgvPartSetData);
            this.Controls.Add(this.chkALL);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbPartName);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tbPartNo);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.cbPartClass);
            this.Controls.Add(this.L0003);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SOSMBOMBWBH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SampleOrderShoeModelBOMBWBH";
            this.Load += new System.EventHandler(this.SampleOrderShoeModelBOMBWBH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSetData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkALL;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox tbPartName;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbPartNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.ComboBox cbPartClass;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.DataGridView dgvPartSetData;
    }
}