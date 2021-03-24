namespace NEWERPS
{
    partial class PM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PM));
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
            this.tbProduceNameEN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbProduceNameCN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProduceData = new System.Windows.Forms.DataGridView();
            this.tcProduceMethod = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.tpFunction = new System.Windows.Forms.TabPage();
            this.tbPMID = new System.Windows.Forms.TextBox();
            this.lb = new System.Windows.Forms.Label();
            this.tpPMSupplier = new System.Windows.Forms.TabPage();
            this.pS = new System.Windows.Forms.Panel();
            this.dgvSupplierList = new System.Windows.Forms.DataGridView();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tsButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduceData)).BeginInit();
            this.tcProduceMethod.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpFunction.SuspendLayout();
            this.tpPMSupplier.SuspendLayout();
            this.pS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).BeginInit();
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
            this.tsButton.TabIndex = 23;
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
            this.tsbClear.Enabled = false;
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
            // tbProduceNameEN
            // 
            this.tbProduceNameEN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbProduceNameEN.Enabled = false;
            this.tbProduceNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbProduceNameEN.Location = new System.Drawing.Point(374, 194);
            this.tbProduceNameEN.MaxLength = 50;
            this.tbProduceNameEN.Name = "tbProduceNameEN";
            this.tbProduceNameEN.Size = new System.Drawing.Size(284, 34);
            this.tbProduceNameEN.TabIndex = 29;
            // 
            // L0002
            // 
            this.L0002.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(126, 204);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 28;
            this.L0002.Text = "英文名稱";
            // 
            // tbProduceNameCN
            // 
            this.tbProduceNameCN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbProduceNameCN.Enabled = false;
            this.tbProduceNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbProduceNameCN.Location = new System.Drawing.Point(374, 124);
            this.tbProduceNameCN.MaxLength = 50;
            this.tbProduceNameCN.Name = "tbProduceNameCN";
            this.tbProduceNameCN.Size = new System.Drawing.Size(284, 34);
            this.tbProduceNameCN.TabIndex = 27;
            // 
            // L0003
            // 
            this.L0003.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(456, 63);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(150, 42);
            this.L0003.TabIndex = 26;
            this.L0003.Text = "加工方式";
            // 
            // L0001
            // 
            this.L0001.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(126, 134);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 25;
            this.L0001.Text = "中文名稱";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvProduceData);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 282);
            this.panel1.TabIndex = 32;
            // 
            // dgvProduceData
            // 
            this.dgvProduceData.AllowUserToAddRows = false;
            this.dgvProduceData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduceData.Location = new System.Drawing.Point(0, 0);
            this.dgvProduceData.Name = "dgvProduceData";
            this.dgvProduceData.RowHeadersVisible = false;
            this.dgvProduceData.RowHeadersWidth = 51;
            this.dgvProduceData.RowTemplate.Height = 27;
            this.dgvProduceData.Size = new System.Drawing.Size(813, 282);
            this.dgvProduceData.TabIndex = 1;
            this.dgvProduceData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduceData_CellClick);
            this.dgvProduceData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduceData_CellDoubleClick);
            // 
            // tcProduceMethod
            // 
            this.tcProduceMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcProduceMethod.Controls.Add(this.tpQuery);
            this.tcProduceMethod.Controls.Add(this.tpFunction);
            this.tcProduceMethod.Controls.Add(this.tpPMSupplier);
            this.tcProduceMethod.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcProduceMethod.Location = new System.Drawing.Point(12, 108);
            this.tcProduceMethod.Name = "tcProduceMethod";
            this.tcProduceMethod.SelectedIndex = 0;
            this.tcProduceMethod.Size = new System.Drawing.Size(833, 324);
            this.tcProduceMethod.TabIndex = 34;
            this.tcProduceMethod.SelectedIndexChanged += new System.EventHandler(this.tcProduceMethod_SelectedIndexChanged);
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.panel1);
            this.tpQuery.Location = new System.Drawing.Point(4, 26);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(825, 294);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "加工方式速查";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // tpFunction
            // 
            this.tpFunction.Controls.Add(this.tbPMID);
            this.tpFunction.Controls.Add(this.lb);
            this.tpFunction.Controls.Add(this.tbProduceNameEN);
            this.tpFunction.Controls.Add(this.L0002);
            this.tpFunction.Controls.Add(this.tbProduceNameCN);
            this.tpFunction.Controls.Add(this.L0001);
            this.tpFunction.Location = new System.Drawing.Point(4, 26);
            this.tpFunction.Name = "tpFunction";
            this.tpFunction.Padding = new System.Windows.Forms.Padding(3);
            this.tpFunction.Size = new System.Drawing.Size(825, 294);
            this.tpFunction.TabIndex = 1;
            this.tpFunction.Text = "功能";
            this.tpFunction.UseVisualStyleBackColor = true;
            // 
            // tbPMID
            // 
            this.tbPMID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPMID.Enabled = false;
            this.tbPMID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPMID.Location = new System.Drawing.Point(374, 54);
            this.tbPMID.MaxLength = 50;
            this.tbPMID.Name = "tbPMID";
            this.tbPMID.Size = new System.Drawing.Size(284, 34);
            this.tbPMID.TabIndex = 44;
            // 
            // lb
            // 
            this.lb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb.Location = new System.Drawing.Point(126, 64);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(51, 18);
            this.lb.TabIndex = 43;
            this.lb.Text = "PM_ID";
            // 
            // tpPMSupplier
            // 
            this.tpPMSupplier.Controls.Add(this.pS);
            this.tpPMSupplier.Location = new System.Drawing.Point(4, 26);
            this.tpPMSupplier.Name = "tpPMSupplier";
            this.tpPMSupplier.Size = new System.Drawing.Size(825, 294);
            this.tpPMSupplier.TabIndex = 2;
            this.tpPMSupplier.Text = "加工供應商";
            this.tpPMSupplier.UseVisualStyleBackColor = true;
            // 
            // pS
            // 
            this.pS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pS.Controls.Add(this.dgvSupplierList);
            this.pS.Location = new System.Drawing.Point(3, 3);
            this.pS.Name = "pS";
            this.pS.Size = new System.Drawing.Size(819, 288);
            this.pS.TabIndex = 27;
            // 
            // dgvSupplierList
            // 
            this.dgvSupplierList.AllowUserToAddRows = false;
            this.dgvSupplierList.AllowUserToDeleteRows = false;
            this.dgvSupplierList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplierList.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplierList.Name = "dgvSupplierList";
            this.dgvSupplierList.ReadOnly = true;
            this.dgvSupplierList.RowHeadersVisible = false;
            this.dgvSupplierList.RowHeadersWidth = 51;
            this.dgvSupplierList.RowTemplate.Height = 27;
            this.dgvSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierList.Size = new System.Drawing.Size(819, 288);
            this.dgvSupplierList.TabIndex = 23;
            this.dgvSupplierList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplierList_CellClick);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(1185, 754);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 51;
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 41;
            this.dgvWord.Visible = false;
            // 
            // PM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 444);
            this.Controls.Add(this.tcProduceMethod);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tsButton);
            this.Name = "PM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProduceMethod";
            this.Load += new System.EventHandler(this.ProduceMethod_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduceData)).EndInit();
            this.tcProduceMethod.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpFunction.ResumeLayout(false);
            this.tpFunction.PerformLayout();
            this.tpPMSupplier.ResumeLayout(false);
            this.pS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).EndInit();
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
        private System.Windows.Forms.TextBox tbProduceNameEN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbProduceNameCN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProduceData;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.TabControl tcProduceMethod;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TabPage tpFunction;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.TextBox tbPMID;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TabPage tpPMSupplier;
        private System.Windows.Forms.Panel pS;
        private System.Windows.Forms.DataGridView dgvSupplierList;
    }
}