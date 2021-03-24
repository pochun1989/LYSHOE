namespace NEWERPS
{
    partial class QO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QO));
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
            this.tsbConfirm = new System.Windows.Forms.ToolStripButton();
            this.tcQuoteOrder = new System.Windows.Forms.TabControl();
            this.tpQuoteMas = new System.Windows.Forms.TabPage();
            this.pBJMas = new System.Windows.Forms.Panel();
            this.dgvQuoteOrderMaster = new System.Windows.Forms.DataGridView();
            this.txtBJNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbZSBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbZSYWJC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbVbjno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbdedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbendate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCFMDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCFMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpQuoteDet = new System.Windows.Forms.TabPage();
            this.tbCFMID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSUppName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBJDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pBJDet = new System.Windows.Forms.Panel();
            this.dgvQuoteOrderDetail = new System.Windows.Forms.DataGridView();
            this.tbCLBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbYWPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDWBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbUSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbVNPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbBJLX = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tbBJClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbYN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbBOQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTOQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbddays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSUppID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBJNO = new System.Windows.Forms.TextBox();
            this.lbBOMQTY = new System.Windows.Forms.Label();
            this.L0005 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.L0026 = new System.Windows.Forms.Label();
            this.dgvCGBJSDelete = new System.Windows.Forms.DataGridView();
            this.tsButton.SuspendLayout();
            this.tcQuoteOrder.SuspendLayout();
            this.tpQuoteMas.SuspendLayout();
            this.pBJMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderMaster)).BeginInit();
            this.tpQuoteDet.SuspendLayout();
            this.pBJDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGBJSDelete)).BeginInit();
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
            this.tsbExit,
            this.tsbConfirm});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsButton.Size = new System.Drawing.Size(940, 58);
            this.tsButton.TabIndex = 27;
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
            // tsbConfirm
            // 
            this.tsbConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfirm.Image")));
            this.tsbConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfirm.Name = "tsbConfirm";
            this.tsbConfirm.Size = new System.Drawing.Size(70, 55);
            this.tsbConfirm.Text = "Confirm";
            this.tsbConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbConfirm.Click += new System.EventHandler(this.tsbConfirm_Click);
            // 
            // tcQuoteOrder
            // 
            this.tcQuoteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcQuoteOrder.Controls.Add(this.tpQuoteMas);
            this.tcQuoteOrder.Controls.Add(this.tpQuoteDet);
            this.tcQuoteOrder.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcQuoteOrder.Location = new System.Drawing.Point(13, 64);
            this.tcQuoteOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tcQuoteOrder.Name = "tcQuoteOrder";
            this.tcQuoteOrder.SelectedIndex = 0;
            this.tcQuoteOrder.Size = new System.Drawing.Size(914, 455);
            this.tcQuoteOrder.TabIndex = 63;
            this.tcQuoteOrder.SelectedIndexChanged += new System.EventHandler(this.tcQuoteOrder_SelectedIndexChanged);
            // 
            // tpQuoteMas
            // 
            this.tpQuoteMas.Controls.Add(this.pBJMas);
            this.tpQuoteMas.Location = new System.Drawing.Point(4, 26);
            this.tpQuoteMas.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpQuoteMas.Name = "tpQuoteMas";
            this.tpQuoteMas.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpQuoteMas.Size = new System.Drawing.Size(906, 425);
            this.tpQuoteMas.TabIndex = 0;
            this.tpQuoteMas.Text = "BJMas";
            this.tpQuoteMas.UseVisualStyleBackColor = true;
            // 
            // pBJMas
            // 
            this.pBJMas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBJMas.Controls.Add(this.dgvQuoteOrderMaster);
            this.pBJMas.Location = new System.Drawing.Point(9, 12);
            this.pBJMas.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pBJMas.Name = "pBJMas";
            this.pBJMas.Size = new System.Drawing.Size(888, 401);
            this.pBJMas.TabIndex = 27;
            // 
            // dgvQuoteOrderMaster
            // 
            this.dgvQuoteOrderMaster.AllowUserToAddRows = false;
            this.dgvQuoteOrderMaster.AllowUserToDeleteRows = false;
            this.dgvQuoteOrderMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuoteOrderMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtBJNo,
            this.tbZSBH,
            this.tbZSYWJC,
            this.tbVbjno,
            this.tbdedate,
            this.tbendate,
            this.txtCFMDate,
            this.txtCFMID});
            this.dgvQuoteOrderMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuoteOrderMaster.Location = new System.Drawing.Point(0, 0);
            this.dgvQuoteOrderMaster.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvQuoteOrderMaster.Name = "dgvQuoteOrderMaster";
            this.dgvQuoteOrderMaster.ReadOnly = true;
            this.dgvQuoteOrderMaster.RowHeadersVisible = false;
            this.dgvQuoteOrderMaster.RowTemplate.Height = 27;
            this.dgvQuoteOrderMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuoteOrderMaster.Size = new System.Drawing.Size(888, 401);
            this.dgvQuoteOrderMaster.TabIndex = 23;
            this.dgvQuoteOrderMaster.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvQuoteOrderMaster_CellBeginEdit);
            this.dgvQuoteOrderMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderMaster_CellClick);
            this.dgvQuoteOrderMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderMaster_CellDoubleClick);
            this.dgvQuoteOrderMaster.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderMaster_CellValueChanged);
            this.dgvQuoteOrderMaster.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvQuoteOrderMaster_EditingControlShowing);
            // 
            // txtBJNo
            // 
            this.txtBJNo.DataPropertyName = "BJNO";
            this.txtBJNo.HeaderText = "BJNo";
            this.txtBJNo.Name = "txtBJNo";
            this.txtBJNo.ReadOnly = true;
            this.txtBJNo.Width = 104;
            // 
            // tbZSBH
            // 
            this.tbZSBH.DataPropertyName = "ZSBH";
            this.tbZSBH.HeaderText = "ZSBH";
            this.tbZSBH.Name = "tbZSBH";
            this.tbZSBH.ReadOnly = true;
            this.tbZSBH.Width = 110;
            // 
            // tbZSYWJC
            // 
            this.tbZSYWJC.DataPropertyName = "zsjc";
            this.tbZSYWJC.HeaderText = "ZSYWJC";
            this.tbZSYWJC.Name = "tbZSYWJC";
            this.tbZSYWJC.ReadOnly = true;
            this.tbZSYWJC.Width = 111;
            // 
            // tbVbjno
            // 
            this.tbVbjno.DataPropertyName = "Vbjno";
            this.tbVbjno.HeaderText = "Vbjno";
            this.tbVbjno.Name = "tbVbjno";
            this.tbVbjno.ReadOnly = true;
            this.tbVbjno.Width = 110;
            // 
            // tbdedate
            // 
            this.tbdedate.DataPropertyName = "dedate";
            this.tbdedate.HeaderText = "dedate";
            this.tbdedate.Name = "tbdedate";
            this.tbdedate.ReadOnly = true;
            this.tbdedate.Width = 111;
            // 
            // tbendate
            // 
            this.tbendate.DataPropertyName = "endate";
            this.tbendate.HeaderText = "endate";
            this.tbendate.Name = "tbendate";
            this.tbendate.ReadOnly = true;
            this.tbendate.Width = 111;
            // 
            // txtCFMDate
            // 
            this.txtCFMDate.DataPropertyName = "CFMDate";
            this.txtCFMDate.HeaderText = "CFMDate";
            this.txtCFMDate.Name = "txtCFMDate";
            this.txtCFMDate.ReadOnly = true;
            this.txtCFMDate.Width = 110;
            // 
            // txtCFMID
            // 
            this.txtCFMID.DataPropertyName = "CFMID";
            this.txtCFMID.HeaderText = "CFMID";
            this.txtCFMID.Name = "txtCFMID";
            this.txtCFMID.ReadOnly = true;
            this.txtCFMID.Width = 112;
            // 
            // tpQuoteDet
            // 
            this.tpQuoteDet.Controls.Add(this.tbCFMID);
            this.tpQuoteDet.Controls.Add(this.label5);
            this.tpQuoteDet.Controls.Add(this.tbSUppName);
            this.tpQuoteDet.Controls.Add(this.label3);
            this.tpQuoteDet.Controls.Add(this.tbBJDate);
            this.tpQuoteDet.Controls.Add(this.label4);
            this.tpQuoteDet.Controls.Add(this.pBJDet);
            this.tpQuoteDet.Controls.Add(this.tbSUppID);
            this.tpQuoteDet.Controls.Add(this.label2);
            this.tpQuoteDet.Controls.Add(this.label1);
            this.tpQuoteDet.Controls.Add(this.tbBJNO);
            this.tpQuoteDet.Controls.Add(this.lbBOMQTY);
            this.tpQuoteDet.Controls.Add(this.L0005);
            this.tpQuoteDet.Controls.Add(this.label20);
            this.tpQuoteDet.Controls.Add(this.label21);
            this.tpQuoteDet.Location = new System.Drawing.Point(4, 26);
            this.tpQuoteDet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpQuoteDet.Name = "tpQuoteDet";
            this.tpQuoteDet.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tpQuoteDet.Size = new System.Drawing.Size(900, 468);
            this.tpQuoteDet.TabIndex = 1;
            this.tpQuoteDet.Text = "BJDet";
            this.tpQuoteDet.UseVisualStyleBackColor = true;
            // 
            // tbCFMID
            // 
            this.tbCFMID.Enabled = false;
            this.tbCFMID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCFMID.Location = new System.Drawing.Point(729, 16);
            this.tbCFMID.Name = "tbCFMID";
            this.tbCFMID.Size = new System.Drawing.Size(126, 34);
            this.tbCFMID.TabIndex = 251;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(660, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 250;
            this.label5.Text = "CFMID";
            // 
            // tbSUppName
            // 
            this.tbSUppName.Enabled = false;
            this.tbSUppName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSUppName.Location = new System.Drawing.Point(425, 56);
            this.tbSUppName.Name = "tbSUppName";
            this.tbSUppName.Size = new System.Drawing.Size(216, 34);
            this.tbSUppName.TabIndex = 249;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 248;
            this.label3.Text = "SUppName";
            // 
            // tbBJDate
            // 
            this.tbBJDate.Enabled = false;
            this.tbBJDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBJDate.Location = new System.Drawing.Point(425, 16);
            this.tbBJDate.Name = "tbBJDate";
            this.tbBJDate.Size = new System.Drawing.Size(216, 34);
            this.tbBJDate.TabIndex = 247;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 246;
            this.label4.Text = "BJDate";
            // 
            // pBJDet
            // 
            this.pBJDet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBJDet.Controls.Add(this.dgvQuoteOrderDetail);
            this.pBJDet.Location = new System.Drawing.Point(9, 101);
            this.pBJDet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pBJDet.Name = "pBJDet";
            this.pBJDet.Size = new System.Drawing.Size(882, 355);
            this.pBJDet.TabIndex = 245;
            // 
            // dgvQuoteOrderDetail
            // 
            this.dgvQuoteOrderDetail.AllowUserToAddRows = false;
            this.dgvQuoteOrderDetail.AllowUserToDeleteRows = false;
            this.dgvQuoteOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuoteOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbCLBH,
            this.tbYWPM,
            this.tbDWBH,
            this.tbUSPrice,
            this.tbVNPrice,
            this.tbBJLX,
            this.tbBJClass,
            this.tbMemo,
            this.tbYN,
            this.tbBOQ,
            this.tbTOQ,
            this.tbddays});
            this.dgvQuoteOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuoteOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvQuoteOrderDetail.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvQuoteOrderDetail.Name = "dgvQuoteOrderDetail";
            this.dgvQuoteOrderDetail.ReadOnly = true;
            this.dgvQuoteOrderDetail.RowHeadersVisible = false;
            this.dgvQuoteOrderDetail.RowTemplate.Height = 27;
            this.dgvQuoteOrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuoteOrderDetail.Size = new System.Drawing.Size(882, 355);
            this.dgvQuoteOrderDetail.TabIndex = 23;
            this.dgvQuoteOrderDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvQuoteOrderDetail_CellBeginEdit);
            this.dgvQuoteOrderDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderDetail_CellClick);
            this.dgvQuoteOrderDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderDetail_CellDoubleClick);
            this.dgvQuoteOrderDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderDetail_CellValueChanged);
            this.dgvQuoteOrderDetail.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvQuoteOrderDetail_UserDeletingRow);
            // 
            // tbCLBH
            // 
            this.tbCLBH.DataPropertyName = "CLBH";
            this.tbCLBH.HeaderText = "CLBH";
            this.tbCLBH.Name = "tbCLBH";
            this.tbCLBH.ReadOnly = true;
            this.tbCLBH.Width = 74;
            // 
            // tbYWPM
            // 
            this.tbYWPM.DataPropertyName = "ywpm";
            this.tbYWPM.HeaderText = "YWPM";
            this.tbYWPM.Name = "tbYWPM";
            this.tbYWPM.ReadOnly = true;
            this.tbYWPM.Width = 74;
            // 
            // tbDWBH
            // 
            this.tbDWBH.DataPropertyName = "dwbh";
            this.tbDWBH.HeaderText = "DWBH";
            this.tbDWBH.Name = "tbDWBH";
            this.tbDWBH.ReadOnly = true;
            this.tbDWBH.Width = 73;
            // 
            // tbUSPrice
            // 
            this.tbUSPrice.DataPropertyName = "USPrice";
            this.tbUSPrice.HeaderText = "USPrice";
            this.tbUSPrice.Name = "tbUSPrice";
            this.tbUSPrice.ReadOnly = true;
            this.tbUSPrice.Width = 74;
            // 
            // tbVNPrice
            // 
            this.tbVNPrice.DataPropertyName = "VNPrice";
            this.tbVNPrice.HeaderText = "VNPrice";
            this.tbVNPrice.Name = "tbVNPrice";
            this.tbVNPrice.ReadOnly = true;
            this.tbVNPrice.Width = 73;
            // 
            // tbBJLX
            // 
            this.tbBJLX.DataPropertyName = "BJLX";
            this.tbBJLX.HeaderText = "BJLX";
            this.tbBJLX.Items.AddRange(new object[] {
            "開發材料",
            "生產材料",
            "其他",
            "總務",
            "外箱",
            "化學",
            "模製具"});
            this.tbBJLX.Name = "tbBJLX";
            this.tbBJLX.ReadOnly = true;
            this.tbBJLX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tbBJLX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tbBJLX.Width = 64;
            // 
            // tbBJClass
            // 
            this.tbBJClass.DataPropertyName = "BJClass";
            this.tbBJClass.HeaderText = "BJClass";
            this.tbBJClass.Name = "tbBJClass";
            this.tbBJClass.ReadOnly = true;
            this.tbBJClass.Width = 75;
            // 
            // tbMemo
            // 
            this.tbMemo.DataPropertyName = "Memo";
            this.tbMemo.HeaderText = "Memo";
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.ReadOnly = true;
            this.tbMemo.Width = 74;
            // 
            // tbYN
            // 
            this.tbYN.DataPropertyName = "YN";
            this.tbYN.HeaderText = "YN";
            this.tbYN.Name = "tbYN";
            this.tbYN.ReadOnly = true;
            this.tbYN.Width = 75;
            // 
            // tbBOQ
            // 
            this.tbBOQ.DataPropertyName = "BOQ";
            this.tbBOQ.HeaderText = "BOQ";
            this.tbBOQ.Name = "tbBOQ";
            this.tbBOQ.ReadOnly = true;
            this.tbBOQ.Width = 74;
            // 
            // tbTOQ
            // 
            this.tbTOQ.DataPropertyName = "TOQ";
            this.tbTOQ.HeaderText = "TOQ";
            this.tbTOQ.Name = "tbTOQ";
            this.tbTOQ.ReadOnly = true;
            this.tbTOQ.Width = 75;
            // 
            // tbddays
            // 
            this.tbddays.DataPropertyName = "ddays";
            this.tbddays.HeaderText = "ddays";
            this.tbddays.Name = "tbddays";
            this.tbddays.ReadOnly = true;
            this.tbddays.Width = 74;
            // 
            // tbSUppID
            // 
            this.tbSUppID.Enabled = false;
            this.tbSUppID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSUppID.Location = new System.Drawing.Point(96, 56);
            this.tbSUppID.Name = "tbSUppID";
            this.tbSUppID.Size = new System.Drawing.Size(216, 34);
            this.tbSUppID.TabIndex = 244;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 241;
            this.label2.Text = "SUppID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 239;
            this.label1.Text = "BJNO";
            // 
            // tbBJNO
            // 
            this.tbBJNO.Enabled = false;
            this.tbBJNO.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbBJNO.Location = new System.Drawing.Point(96, 16);
            this.tbBJNO.Name = "tbBJNO";
            this.tbBJNO.Size = new System.Drawing.Size(216, 34);
            this.tbBJNO.TabIndex = 238;
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
            // L0026
            // 
            this.L0026.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0026.AutoSize = true;
            this.L0026.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0026.Location = new System.Drawing.Point(719, 33);
            this.L0026.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0026.Name = "L0026";
            this.L0026.Size = new System.Drawing.Size(117, 42);
            this.L0026.TabIndex = 64;
            this.L0026.Text = "報價單";
            // 
            // dgvCGBJSDelete
            // 
            this.dgvCGBJSDelete.AllowUserToAddRows = false;
            this.dgvCGBJSDelete.AllowUserToDeleteRows = false;
            this.dgvCGBJSDelete.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCGBJSDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCGBJSDelete.Location = new System.Drawing.Point(1120, 0);
            this.dgvCGBJSDelete.Name = "dgvCGBJSDelete";
            this.dgvCGBJSDelete.ReadOnly = true;
            this.dgvCGBJSDelete.RowTemplate.Height = 27;
            this.dgvCGBJSDelete.Size = new System.Drawing.Size(50, 42);
            this.dgvCGBJSDelete.TabIndex = 241;
            this.dgvCGBJSDelete.Visible = false;
            // 
            // QO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 534);
            this.Controls.Add(this.dgvCGBJSDelete);
            this.Controls.Add(this.L0026);
            this.Controls.Add(this.tcQuoteOrder);
            this.Controls.Add(this.tsButton);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuoteOrder";
            this.Load += new System.EventHandler(this.QuoteOrder_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.tcQuoteOrder.ResumeLayout(false);
            this.tpQuoteMas.ResumeLayout(false);
            this.pBJMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderMaster)).EndInit();
            this.tpQuoteDet.ResumeLayout(false);
            this.tpQuoteDet.PerformLayout();
            this.pBJDet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGBJSDelete)).EndInit();
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
        private System.Windows.Forms.TabControl tcQuoteOrder;
        private System.Windows.Forms.TabPage tpQuoteMas;
        private System.Windows.Forms.Panel pBJMas;
        private System.Windows.Forms.DataGridView dgvQuoteOrderMaster;
        private System.Windows.Forms.TabPage tpQuoteDet;
        private System.Windows.Forms.TextBox tbBJDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pBJDet;
        private System.Windows.Forms.DataGridView dgvQuoteOrderDetail;
        private System.Windows.Forms.TextBox tbSUppID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBJNO;
        private System.Windows.Forms.Label lbBOMQTY;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label L0026;
        private System.Windows.Forms.DataGridView dgvCGBJSDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBJNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbZSBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbZSYWJC;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbVbjno;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbdedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbendate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCFMDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCFMID;
        private System.Windows.Forms.TextBox tbCFMID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSUppName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton tsbConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCLBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbYWPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbDWBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbUSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbVNPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn tbBJLX;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbBJClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbYN;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbBOQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbTOQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbddays;
    }
}