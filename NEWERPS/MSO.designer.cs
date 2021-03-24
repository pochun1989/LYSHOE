namespace NEWERPS
{
    partial class MSO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSO));
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
            this.tcMergerOrder = new System.Windows.Forms.TabControl();
            this.tpMergerQuery = new System.Windows.Forms.TabPage();
            this.pMerger = new System.Windows.Forms.Panel();
            this.dgvMergerOrder = new System.Windows.Forms.DataGridView();
            this.tpSampleOrderList = new System.Windows.Forms.TabPage();
            this.tbLastComputeDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pSampleOrderList = new System.Windows.Forms.Panel();
            this.dgvSampleOrderList = new System.Windows.Forms.DataGridView();
            this.tbInsdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCompute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMergerNo = new System.Windows.Forms.TextBox();
            this.lbBOMQTY = new System.Windows.Forms.Label();
            this.L0005 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tpOrderBOM = new System.Windows.Forms.TabPage();
            this.pOderBOM = new System.Windows.Forms.Panel();
            this.dgvOrderBOM = new System.Windows.Forms.DataGridView();
            this.tpDEF = new System.Windows.Forms.TabPage();
            this.pSampleOderDEF = new System.Windows.Forms.Panel();
            this.dgvSampleOrderDEF = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSampleOrderDEF = new System.Windows.Forms.TextBox();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.L0 = new System.Windows.Forms.Label();
            this.tsButton.SuspendLayout();
            this.tcMergerOrder.SuspendLayout();
            this.tpMergerQuery.SuspendLayout();
            this.pMerger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMergerOrder)).BeginInit();
            this.tpSampleOrderList.SuspendLayout();
            this.pSampleOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleOrderList)).BeginInit();
            this.tpOrderBOM.SuspendLayout();
            this.pOderBOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBOM)).BeginInit();
            this.tpDEF.SuspendLayout();
            this.pSampleOderDEF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleOrderDEF)).BeginInit();
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
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsButton.Size = new System.Drawing.Size(852, 58);
            this.tsButton.TabIndex = 26;
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
            // tcMergerOrder
            // 
            this.tcMergerOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMergerOrder.Controls.Add(this.tpMergerQuery);
            this.tcMergerOrder.Controls.Add(this.tpSampleOrderList);
            this.tcMergerOrder.Controls.Add(this.tpOrderBOM);
            this.tcMergerOrder.Controls.Add(this.tpDEF);
            this.tcMergerOrder.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcMergerOrder.Location = new System.Drawing.Point(0, 64);
            this.tcMergerOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tcMergerOrder.Name = "tcMergerOrder";
            this.tcMergerOrder.SelectedIndex = 0;
            this.tcMergerOrder.Size = new System.Drawing.Size(852, 454);
            this.tcMergerOrder.TabIndex = 62;
            this.tcMergerOrder.SelectedIndexChanged += new System.EventHandler(this.tcMergerOrder_SelectedIndexChanged);
            // 
            // tpMergerQuery
            // 
            this.tpMergerQuery.Controls.Add(this.pMerger);
            this.tpMergerQuery.Location = new System.Drawing.Point(4, 26);
            this.tpMergerQuery.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpMergerQuery.Name = "tpMergerQuery";
            this.tpMergerQuery.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpMergerQuery.Size = new System.Drawing.Size(844, 424);
            this.tpMergerQuery.TabIndex = 0;
            this.tpMergerQuery.Text = "Merger Order";
            this.tpMergerQuery.UseVisualStyleBackColor = true;
            // 
            // pMerger
            // 
            this.pMerger.Controls.Add(this.dgvMergerOrder);
            this.pMerger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMerger.Location = new System.Drawing.Point(4, 6);
            this.pMerger.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pMerger.Name = "pMerger";
            this.pMerger.Size = new System.Drawing.Size(836, 412);
            this.pMerger.TabIndex = 27;
            // 
            // dgvMergerOrder
            // 
            this.dgvMergerOrder.AllowUserToAddRows = false;
            this.dgvMergerOrder.AllowUserToDeleteRows = false;
            this.dgvMergerOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMergerOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMergerOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMergerOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvMergerOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvMergerOrder.Name = "dgvMergerOrder";
            this.dgvMergerOrder.ReadOnly = true;
            this.dgvMergerOrder.RowHeadersVisible = false;
            this.dgvMergerOrder.RowTemplate.Height = 27;
            this.dgvMergerOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMergerOrder.Size = new System.Drawing.Size(836, 412);
            this.dgvMergerOrder.TabIndex = 23;
            this.dgvMergerOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMergerOrder_CellClick);
            this.dgvMergerOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMergerOrder_CellDoubleClick);
            // 
            // tpSampleOrderList
            // 
            this.tpSampleOrderList.Controls.Add(this.tbLastComputeDate);
            this.tpSampleOrderList.Controls.Add(this.label4);
            this.tpSampleOrderList.Controls.Add(this.pSampleOrderList);
            this.tpSampleOrderList.Controls.Add(this.tbInsdate);
            this.tpSampleOrderList.Controls.Add(this.label3);
            this.tpSampleOrderList.Controls.Add(this.label2);
            this.tpSampleOrderList.Controls.Add(this.btnCompute);
            this.tpSampleOrderList.Controls.Add(this.label1);
            this.tpSampleOrderList.Controls.Add(this.tbMergerNo);
            this.tpSampleOrderList.Controls.Add(this.lbBOMQTY);
            this.tpSampleOrderList.Controls.Add(this.L0005);
            this.tpSampleOrderList.Controls.Add(this.label20);
            this.tpSampleOrderList.Controls.Add(this.label21);
            this.tpSampleOrderList.Location = new System.Drawing.Point(4, 26);
            this.tpSampleOrderList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpSampleOrderList.Name = "tpSampleOrderList";
            this.tpSampleOrderList.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpSampleOrderList.Size = new System.Drawing.Size(844, 424);
            this.tpSampleOrderList.TabIndex = 1;
            this.tpSampleOrderList.Text = "Simple Order List";
            this.tpSampleOrderList.UseVisualStyleBackColor = true;
            // 
            // tbLastComputeDate
            // 
            this.tbLastComputeDate.Enabled = false;
            this.tbLastComputeDate.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbLastComputeDate.Location = new System.Drawing.Point(382, 38);
            this.tbLastComputeDate.Name = "tbLastComputeDate";
            this.tbLastComputeDate.Size = new System.Drawing.Size(216, 25);
            this.tbLastComputeDate.TabIndex = 247;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(431, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 18);
            this.label4.TabIndex = 246;
            this.label4.Text = "Last Compute Date";
            // 
            // pSampleOrderList
            // 
            this.pSampleOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pSampleOrderList.Controls.Add(this.dgvSampleOrderList);
            this.pSampleOrderList.Location = new System.Drawing.Point(8, 72);
            this.pSampleOrderList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pSampleOrderList.Name = "pSampleOrderList";
            this.pSampleOrderList.Size = new System.Drawing.Size(827, 340);
            this.pSampleOrderList.TabIndex = 245;
            // 
            // dgvSampleOrderList
            // 
            this.dgvSampleOrderList.AllowUserToAddRows = false;
            this.dgvSampleOrderList.AllowUserToDeleteRows = false;
            this.dgvSampleOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSampleOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSampleOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSampleOrderList.Location = new System.Drawing.Point(0, 0);
            this.dgvSampleOrderList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvSampleOrderList.Name = "dgvSampleOrderList";
            this.dgvSampleOrderList.ReadOnly = true;
            this.dgvSampleOrderList.RowHeadersVisible = false;
            this.dgvSampleOrderList.RowTemplate.Height = 27;
            this.dgvSampleOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSampleOrderList.Size = new System.Drawing.Size(827, 340);
            this.dgvSampleOrderList.TabIndex = 23;
            this.dgvSampleOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSampleOrderList_CellClick);
            this.dgvSampleOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSampleOrderList_CellDoubleClick);
            // 
            // tbInsdate
            // 
            this.tbInsdate.Enabled = false;
            this.tbInsdate.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbInsdate.Location = new System.Drawing.Point(120, 38);
            this.tbInsdate.Name = "tbInsdate";
            this.tbInsdate.Size = new System.Drawing.Size(216, 25);
            this.tbInsdate.TabIndex = 244;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(629, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 242;
            this.label3.Text = "Lock over 3 days";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 241;
            this.label2.Text = "INSDATE";
            // 
            // btnCompute
            // 
            this.btnCompute.Enabled = false;
            this.btnCompute.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCompute.Location = new System.Drawing.Point(622, 7);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(135, 38);
            this.btnCompute.TabIndex = 240;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 239;
            this.label1.Text = "Merger No";
            // 
            // tbMergerNo
            // 
            this.tbMergerNo.Enabled = false;
            this.tbMergerNo.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMergerNo.Location = new System.Drawing.Point(120, 7);
            this.tbMergerNo.Name = "tbMergerNo";
            this.tbMergerNo.Size = new System.Drawing.Size(216, 25);
            this.tbMergerNo.TabIndex = 238;
            // 
            // lbBOMQTY
            // 
            this.lbBOMQTY.AutoSize = true;
            this.lbBOMQTY.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbBOMQTY.ForeColor = System.Drawing.Color.Red;
            this.lbBOMQTY.Location = new System.Drawing.Point(17, 721);
            this.lbBOMQTY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBOMQTY.Name = "lbBOMQTY";
            this.lbBOMQTY.Size = new System.Drawing.Size(24, 25);
            this.lbBOMQTY.TabIndex = 237;
            this.lbBOMQTY.Text = "0";
            // 
            // L0005
            // 
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(115, 721);
            this.L0005.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(92, 25);
            this.L0005.TabIndex = 55;
            this.L0005.Text = "部位名稱";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(115, 759);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 25);
            this.label20.TabIndex = 218;
            this.label20.Text = "材料名稱";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(74, 797);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 25);
            this.label21.TabIndex = 220;
            this.label21.Text = "Desscription";
            // 
            // tpOrderBOM
            // 
            this.tpOrderBOM.Controls.Add(this.pOderBOM);
            this.tpOrderBOM.Location = new System.Drawing.Point(4, 26);
            this.tpOrderBOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpOrderBOM.Name = "tpOrderBOM";
            this.tpOrderBOM.Size = new System.Drawing.Size(844, 424);
            this.tpOrderBOM.TabIndex = 2;
            this.tpOrderBOM.Text = "Order BOM";
            this.tpOrderBOM.UseVisualStyleBackColor = true;
            // 
            // pOderBOM
            // 
            this.pOderBOM.Controls.Add(this.dgvOrderBOM);
            this.pOderBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pOderBOM.Location = new System.Drawing.Point(0, 0);
            this.pOderBOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pOderBOM.Name = "pOderBOM";
            this.pOderBOM.Size = new System.Drawing.Size(844, 424);
            this.pOderBOM.TabIndex = 247;
            // 
            // dgvOrderBOM
            // 
            this.dgvOrderBOM.AllowUserToAddRows = false;
            this.dgvOrderBOM.AllowUserToDeleteRows = false;
            this.dgvOrderBOM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderBOM.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderBOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvOrderBOM.Name = "dgvOrderBOM";
            this.dgvOrderBOM.ReadOnly = true;
            this.dgvOrderBOM.RowHeadersVisible = false;
            this.dgvOrderBOM.RowTemplate.Height = 27;
            this.dgvOrderBOM.Size = new System.Drawing.Size(844, 424);
            this.dgvOrderBOM.TabIndex = 23;
            this.dgvOrderBOM.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOrderBOM_CellBeginEdit);
            // 
            // tpDEF
            // 
            this.tpDEF.Controls.Add(this.pSampleOderDEF);
            this.tpDEF.Controls.Add(this.label5);
            this.tpDEF.Controls.Add(this.tbSampleOrderDEF);
            this.tpDEF.Location = new System.Drawing.Point(4, 26);
            this.tpDEF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpDEF.Name = "tpDEF";
            this.tpDEF.Size = new System.Drawing.Size(844, 424);
            this.tpDEF.TabIndex = 3;
            this.tpDEF.Text = "Simple Order DEF";
            this.tpDEF.UseVisualStyleBackColor = true;
            // 
            // pSampleOderDEF
            // 
            this.pSampleOderDEF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pSampleOderDEF.Controls.Add(this.dgvSampleOrderDEF);
            this.pSampleOderDEF.Location = new System.Drawing.Point(9, 68);
            this.pSampleOderDEF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pSampleOderDEF.Name = "pSampleOderDEF";
            this.pSampleOderDEF.Size = new System.Drawing.Size(826, 350);
            this.pSampleOderDEF.TabIndex = 246;
            // 
            // dgvSampleOrderDEF
            // 
            this.dgvSampleOrderDEF.AllowUserToAddRows = false;
            this.dgvSampleOrderDEF.AllowUserToDeleteRows = false;
            this.dgvSampleOrderDEF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSampleOrderDEF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSampleOrderDEF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSampleOrderDEF.Location = new System.Drawing.Point(0, 0);
            this.dgvSampleOrderDEF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvSampleOrderDEF.Name = "dgvSampleOrderDEF";
            this.dgvSampleOrderDEF.ReadOnly = true;
            this.dgvSampleOrderDEF.RowHeadersVisible = false;
            this.dgvSampleOrderDEF.RowTemplate.Height = 27;
            this.dgvSampleOrderDEF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSampleOrderDEF.Size = new System.Drawing.Size(826, 350);
            this.dgvSampleOrderDEF.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 241;
            this.label5.Text = "YPDH";
            // 
            // tbSampleOrderDEF
            // 
            this.tbSampleOrderDEF.Enabled = false;
            this.tbSampleOrderDEF.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSampleOrderDEF.Location = new System.Drawing.Point(86, 25);
            this.tbSampleOrderDEF.Name = "tbSampleOrderDEF";
            this.tbSampleOrderDEF.Size = new System.Drawing.Size(216, 34);
            this.tbSampleOrderDEF.TabIndex = 240;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(1334, 14);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(35, 33);
            this.dgvWord.TabIndex = 63;
            this.dgvWord.Visible = false;
            // 
            // L0
            // 
            this.L0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0.AutoSize = true;
            this.L0.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0.Location = new System.Drawing.Point(550, 46);
            this.L0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0.Name = "L0";
            this.L0.Size = new System.Drawing.Size(150, 42);
            this.L0.TabIndex = 64;
            this.L0.Text = "採購併單";
            // 
            // MSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 517);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.L0);
            this.Controls.Add(this.tcMergerOrder);
            this.Controls.Add(this.tsButton);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MSO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MergerSampleOrder";
            this.Load += new System.EventHandler(this.MergerSampleOrder_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.tcMergerOrder.ResumeLayout(false);
            this.tpMergerQuery.ResumeLayout(false);
            this.pMerger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMergerOrder)).EndInit();
            this.tpSampleOrderList.ResumeLayout(false);
            this.tpSampleOrderList.PerformLayout();
            this.pSampleOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleOrderList)).EndInit();
            this.tpOrderBOM.ResumeLayout(false);
            this.pOderBOM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBOM)).EndInit();
            this.tpDEF.ResumeLayout(false);
            this.tpDEF.PerformLayout();
            this.pSampleOderDEF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleOrderDEF)).EndInit();
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
        private System.Windows.Forms.TabControl tcMergerOrder;
        private System.Windows.Forms.TabPage tpMergerQuery;
        private System.Windows.Forms.Panel pMerger;
        private System.Windows.Forms.DataGridView dgvMergerOrder;
        private System.Windows.Forms.TabPage tpSampleOrderList;
        private System.Windows.Forms.Label lbBOMQTY;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tpOrderBOM;
        private System.Windows.Forms.TabPage tpDEF;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.Label L0;
        private System.Windows.Forms.TextBox tbInsdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMergerNo;
        private System.Windows.Forms.Panel pSampleOrderList;
        private System.Windows.Forms.DataGridView dgvSampleOrderList;
        private System.Windows.Forms.TextBox tbLastComputeDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSampleOrderDEF;
        private System.Windows.Forms.Panel pSampleOderDEF;
        private System.Windows.Forms.DataGridView dgvSampleOrderDEF;
        private System.Windows.Forms.Panel pOderBOM;
        private System.Windows.Forms.DataGridView dgvOrderBOM;
    }
}