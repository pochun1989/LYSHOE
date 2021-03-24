namespace NEWERPS
{
    partial class CI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CI));
            this.tsButton = new System.Windows.Forms.ToolStrip();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrior = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.dgvColorData = new System.Windows.Forms.DataGridView();
            this.L0004 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbColorClass = new System.Windows.Forms.ComboBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tbColorNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbColorNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tcColorInformation = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.tpFunction = new System.Windows.Forms.TabPage();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tsButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorData)).BeginInit();
            this.panel1.SuspendLayout();
            this.tcColorInformation.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tsButton
            // 
            this.tsButton.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbQuery,
            this.tsbClear,
            this.tsbInsert,
            this.tsbDelete,
            this.tsbModify,
            this.tsbSave,
            this.tsbCancel,
            this.tsbFirst,
            this.tsbPrior,
            this.tsbNext,
            this.tsbLast,
            this.tsbPrint,
            this.tsbExit});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton.Size = new System.Drawing.Size(857, 58);
            this.tsButton.TabIndex = 22;
            this.tsButton.Text = "toolStrip1";
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(56, 55);
            this.tsbQuery.Text = "Query";
            this.tsbQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQuery.ToolTipText = "Query";
            this.tsbQuery.Click += new System.EventHandler(this.tsbQuery_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(49, 55);
            this.tsbClear.Text = "Clear";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClear.Visible = false;
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbInsert
            // 
            this.tsbInsert.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsert.Image")));
            this.tsbInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsert.Name = "tsbInsert";
            this.tsbInsert.Size = new System.Drawing.Size(52, 55);
            this.tsbInsert.Text = "Insert";
            this.tsbInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInsert.ToolTipText = "Insert";
            this.tsbInsert.Visible = false;
            this.tsbInsert.Click += new System.EventHandler(this.tsbInsert_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(57, 55);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Visible = false;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbModify
            // 
            this.tsbModify.Enabled = false;
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(63, 55);
            this.tsbModify.Text = "Modify";
            this.tsbModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModify.Visible = false;
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(46, 55);
            this.tsbSave.Text = "Save";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Visible = false;
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(59, 55);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Enabled = false;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(43, 55);
            this.tsbFirst.Text = "First";
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.ToolTipText = "First";
            this.tsbFirst.Visible = false;
            // 
            // tsbPrior
            // 
            this.tsbPrior.Enabled = false;
            this.tsbPrior.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrior.Image")));
            this.tsbPrior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrior.Name = "tsbPrior";
            this.tsbPrior.Size = new System.Drawing.Size(47, 55);
            this.tsbPrior.Text = "Prior";
            this.tsbPrior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrior.ToolTipText = "Prior";
            this.tsbPrior.Visible = false;
            // 
            // tsbNext
            // 
            this.tsbNext.Enabled = false;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(45, 55);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.ToolTipText = "Next";
            this.tsbNext.Visible = false;
            // 
            // tsbLast
            // 
            this.tsbLast.Enabled = false;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(41, 55);
            this.tsbLast.Text = "Last";
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.ToolTipText = "Last";
            this.tsbLast.Visible = false;
            // 
            // tsbPrint
            // 
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(46, 55);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.ToolTipText = "Print";
            this.tsbPrint.Visible = false;
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(37, 55);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // dgvColorData
            // 
            this.dgvColorData.AllowUserToAddRows = false;
            this.dgvColorData.AllowUserToDeleteRows = false;
            this.dgvColorData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColorData.Location = new System.Drawing.Point(0, 0);
            this.dgvColorData.Name = "dgvColorData";
            this.dgvColorData.ReadOnly = true;
            this.dgvColorData.RowHeadersVisible = false;
            this.dgvColorData.RowHeadersWidth = 51;
            this.dgvColorData.RowTemplate.Height = 27;
            this.dgvColorData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColorData.Size = new System.Drawing.Size(813, 282);
            this.dgvColorData.TabIndex = 23;
            this.dgvColorData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColorData_CellDoubleClick);
            // 
            // L0004
            // 
            this.L0004.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(498, 63);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(150, 42);
            this.L0004.TabIndex = 24;
            this.L0004.Text = "顏色維護";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvColorData);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 282);
            this.panel1.TabIndex = 25;
            // 
            // cbColorClass
            // 
            this.cbColorClass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbColorClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorClass.Enabled = false;
            this.cbColorClass.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbColorClass.FormattingEnabled = true;
            this.cbColorClass.Items.AddRange(new object[] {
            "單色",
            "多色"});
            this.cbColorClass.Location = new System.Drawing.Point(400, 86);
            this.cbColorClass.Name = "cbColorClass";
            this.cbColorClass.Size = new System.Drawing.Size(102, 28);
            this.cbColorClass.TabIndex = 27;
            // 
            // L0001
            // 
            this.L0001.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(152, 92);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 26;
            this.L0001.Text = "顏色分類";
            // 
            // tbColorNameCN
            // 
            this.tbColorNameCN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbColorNameCN.Enabled = false;
            this.tbColorNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbColorNameCN.Location = new System.Drawing.Point(400, 140);
            this.tbColorNameCN.Name = "tbColorNameCN";
            this.tbColorNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbColorNameCN.TabIndex = 29;
            // 
            // L0002
            // 
            this.L0002.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(152, 150);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 28;
            this.L0002.Text = "中文名稱";
            // 
            // tbColorNameEN
            // 
            this.tbColorNameEN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbColorNameEN.Enabled = false;
            this.tbColorNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbColorNameEN.Location = new System.Drawing.Point(400, 200);
            this.tbColorNameEN.Name = "tbColorNameEN";
            this.tbColorNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbColorNameEN.TabIndex = 31;
            // 
            // L0003
            // 
            this.L0003.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(152, 210);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 30;
            this.L0003.Text = "英文名稱";
            // 
            // tcColorInformation
            // 
            this.tcColorInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcColorInformation.Controls.Add(this.tpQuery);
            this.tcColorInformation.Controls.Add(this.tpFunction);
            this.tcColorInformation.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcColorInformation.Location = new System.Drawing.Point(12, 108);
            this.tcColorInformation.Name = "tcColorInformation";
            this.tcColorInformation.SelectedIndex = 0;
            this.tcColorInformation.Size = new System.Drawing.Size(833, 324);
            this.tcColorInformation.TabIndex = 32;
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.panel1);
            this.tpQuery.Location = new System.Drawing.Point(4, 26);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(825, 294);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "顏色速查";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // tpFunction
            // 
            this.tpFunction.Controls.Add(this.dgvWord);
            this.tpFunction.Controls.Add(this.L0001);
            this.tpFunction.Controls.Add(this.tbColorNameEN);
            this.tpFunction.Controls.Add(this.cbColorClass);
            this.tpFunction.Controls.Add(this.L0003);
            this.tpFunction.Controls.Add(this.L0002);
            this.tpFunction.Controls.Add(this.tbColorNameCN);
            this.tpFunction.Location = new System.Drawing.Point(4, 26);
            this.tpFunction.Name = "tpFunction";
            this.tpFunction.Padding = new System.Windows.Forms.Padding(3);
            this.tpFunction.Size = new System.Drawing.Size(825, 294);
            this.tpFunction.TabIndex = 1;
            this.tpFunction.Text = "功能";
            this.tpFunction.UseVisualStyleBackColor = true;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(1144, 588);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 51;
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(51, 39);
            this.dgvWord.TabIndex = 32;
            this.dgvWord.Visible = false;
            // 
            // CI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 444);
            this.Controls.Add(this.tcColorInformation);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.tsButton);
            this.Name = "CI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorInformation";
            this.Load += new System.EventHandler(this.ColorInformation_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tcColorInformation.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpFunction.ResumeLayout(false);
            this.tpFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsButton;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbInsert;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrior;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.DataGridView dgvColorData;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbColorClass;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbColorNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbColorNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.TabControl tcColorInformation;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TabPage tpFunction;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}