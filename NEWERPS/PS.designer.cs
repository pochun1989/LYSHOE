namespace NEWERPS
{
    partial class PS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PS));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPartSetData = new System.Windows.Forms.DataGridView();
            this.L0006 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.tbPartNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbPartNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbPartNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.cbPartClass = new System.Windows.Forms.ComboBox();
            this.L0005 = new System.Windows.Forms.Label();
            this.tcPartSet = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.tpFunction = new System.Windows.Forms.TabPage();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tsButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSetData)).BeginInit();
            this.tcPartSet.SuspendLayout();
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
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsButton.Size = new System.Drawing.Size(643, 54);
            this.tsButton.TabIndex = 24;
            this.tsButton.Text = "toolStrip1";
            // 
            // tsbQuery
            // 
            this.tsbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery.Image")));
            this.tsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery.Name = "tsbQuery";
            this.tsbQuery.Size = new System.Drawing.Size(45, 51);
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
            this.tsbClear.Size = new System.Drawing.Size(40, 51);
            this.tsbClear.Text = "Clear";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbInsert
            // 
            this.tsbInsert.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsert.Image")));
            this.tsbInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsert.Name = "tsbInsert";
            this.tsbInsert.Size = new System.Drawing.Size(41, 51);
            this.tsbInsert.Text = "Insert";
            this.tsbInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInsert.ToolTipText = "Insert";
            this.tsbInsert.Click += new System.EventHandler(this.tsbInsert_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(48, 51);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbModify
            // 
            this.tsbModify.Enabled = false;
            this.tsbModify.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify.Image")));
            this.tsbModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify.Name = "tsbModify";
            this.tsbModify.Size = new System.Drawing.Size(52, 51);
            this.tsbModify.Text = "Modify";
            this.tsbModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModify.Click += new System.EventHandler(this.tsbModify_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(38, 51);
            this.tsbSave.Text = "Save";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(49, 51);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Enabled = false;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(36, 51);
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
            this.tsbPrior.Size = new System.Drawing.Size(37, 51);
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
            this.tsbNext.Size = new System.Drawing.Size(38, 51);
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
            this.tsbLast.Size = new System.Drawing.Size(36, 51);
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
            this.tsbPrint.Size = new System.Drawing.Size(36, 51);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.ToolTipText = "Print";
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(36, 51);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvPartSetData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 227);
            this.panel1.TabIndex = 27;
            // 
            // dgvPartSetData
            // 
            this.dgvPartSetData.AllowUserToAddRows = false;
            this.dgvPartSetData.AllowUserToDeleteRows = false;
            this.dgvPartSetData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartSetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartSetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartSetData.Location = new System.Drawing.Point(0, 0);
            this.dgvPartSetData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPartSetData.Name = "dgvPartSetData";
            this.dgvPartSetData.RowHeadersVisible = false;
            this.dgvPartSetData.RowTemplate.Height = 27;
            this.dgvPartSetData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartSetData.Size = new System.Drawing.Size(613, 227);
            this.dgvPartSetData.TabIndex = 23;
            this.dgvPartSetData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartSetData_CellClick);
            this.dgvPartSetData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartSetData_CellDoubleClick);
            // 
            // L0006
            // 
            this.L0006.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0006.AutoSize = true;
            this.L0006.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0006.Location = new System.Drawing.Point(342, 50);
            this.L0006.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0006.Name = "L0006";
            this.L0006.Size = new System.Drawing.Size(123, 34);
            this.L0006.TabIndex = 28;
            this.L0006.Text = "部位設定";
            // 
            // tbRemark
            // 
            this.tbRemark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbRemark.Enabled = false;
            this.tbRemark.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbRemark.Location = new System.Drawing.Point(264, 142);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(320, 29);
            this.tbRemark.TabIndex = 53;
            // 
            // L0004
            // 
            this.L0004.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(64, 150);
            this.L0004.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(29, 15);
            this.L0004.TabIndex = 59;
            this.L0004.Text = "備註";
            // 
            // tbPartNameEN
            // 
            this.tbPartNameEN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPartNameEN.Enabled = false;
            this.tbPartNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNameEN.Location = new System.Drawing.Point(264, 110);
            this.tbPartNameEN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPartNameEN.Name = "tbPartNameEN";
            this.tbPartNameEN.Size = new System.Drawing.Size(194, 29);
            this.tbPartNameEN.TabIndex = 52;
            // 
            // L0003
            // 
            this.L0003.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(64, 118);
            this.L0003.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(29, 15);
            this.L0003.TabIndex = 58;
            this.L0003.Text = "英文";
            // 
            // tbPartNameCN
            // 
            this.tbPartNameCN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPartNameCN.Enabled = false;
            this.tbPartNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNameCN.Location = new System.Drawing.Point(264, 78);
            this.tbPartNameCN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPartNameCN.Name = "tbPartNameCN";
            this.tbPartNameCN.Size = new System.Drawing.Size(194, 29);
            this.tbPartNameCN.TabIndex = 51;
            // 
            // L0002
            // 
            this.L0002.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(64, 86);
            this.L0002.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(29, 15);
            this.L0002.TabIndex = 57;
            this.L0002.Text = "中文";
            // 
            // tbPartNo
            // 
            this.tbPartNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPartNo.Enabled = false;
            this.tbPartNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPartNo.Location = new System.Drawing.Point(264, 46);
            this.tbPartNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPartNo.MaxLength = 4;
            this.tbPartNo.Name = "tbPartNo";
            this.tbPartNo.Size = new System.Drawing.Size(68, 29);
            this.tbPartNo.TabIndex = 50;
            // 
            // L0001
            // 
            this.L0001.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(64, 54);
            this.L0001.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(51, 15);
            this.L0001.TabIndex = 56;
            this.L0001.Text = "部位代號";
            // 
            // cbPartClass
            // 
            this.cbPartClass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPartClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartClass.Enabled = false;
            this.cbPartClass.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPartClass.FormattingEnabled = true;
            this.cbPartClass.Items.AddRange(new object[] {
            "面部",
            "底部",
            "配件",
            "包材",
            "其他"});
            this.cbPartClass.Location = new System.Drawing.Point(264, 174);
            this.cbPartClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPartClass.Name = "cbPartClass";
            this.cbPartClass.Size = new System.Drawing.Size(78, 24);
            this.cbPartClass.TabIndex = 54;
            this.cbPartClass.SelectedIndexChanged += new System.EventHandler(this.cbPartClass_SelectedIndexChanged);
            // 
            // L0005
            // 
            this.L0005.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(64, 179);
            this.L0005.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(51, 15);
            this.L0005.TabIndex = 55;
            this.L0005.Text = "部位分類";
            // 
            // tcPartSet
            // 
            this.tcPartSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPartSet.Controls.Add(this.tpQuery);
            this.tcPartSet.Controls.Add(this.tpFunction);
            this.tcPartSet.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcPartSet.Location = new System.Drawing.Point(9, 86);
            this.tcPartSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcPartSet.Name = "tcPartSet";
            this.tcPartSet.SelectedIndex = 0;
            this.tcPartSet.Size = new System.Drawing.Size(625, 259);
            this.tcPartSet.TabIndex = 60;
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.panel1);
            this.tpQuery.Location = new System.Drawing.Point(4, 24);
            this.tpQuery.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpQuery.Size = new System.Drawing.Size(617, 231);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "工制具類別速查";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // tpFunction
            // 
            this.tpFunction.Controls.Add(this.dgvWord);
            this.tpFunction.Controls.Add(this.tbRemark);
            this.tpFunction.Controls.Add(this.L0004);
            this.tpFunction.Controls.Add(this.tbPartNameEN);
            this.tpFunction.Controls.Add(this.L0003);
            this.tpFunction.Controls.Add(this.tbPartNameCN);
            this.tpFunction.Controls.Add(this.L0002);
            this.tpFunction.Controls.Add(this.tbPartNo);
            this.tpFunction.Controls.Add(this.L0001);
            this.tpFunction.Controls.Add(this.cbPartClass);
            this.tpFunction.Controls.Add(this.L0005);
            this.tpFunction.Location = new System.Drawing.Point(4, 24);
            this.tpFunction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpFunction.Name = "tpFunction";
            this.tpFunction.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpFunction.Size = new System.Drawing.Size(617, 231);
            this.tpFunction.TabIndex = 1;
            this.tpFunction.Text = "功能";
            this.tpFunction.UseVisualStyleBackColor = true;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(860, 470);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(36, 31);
            this.dgvWord.TabIndex = 60;
            this.dgvWord.Visible = false;
            // 
            // PS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 355);
            this.Controls.Add(this.tcPartSet);
            this.Controls.Add(this.L0006);
            this.Controls.Add(this.tsButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartSet";
            this.Load += new System.EventHandler(this.PartSet_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSetData)).EndInit();
            this.tcPartSet.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrior;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPartSetData;
        private System.Windows.Forms.Label L0006;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.TextBox tbPartNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbPartNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbPartNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.ComboBox cbPartClass;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.TabControl tcPartSet;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TabPage tpFunction;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}