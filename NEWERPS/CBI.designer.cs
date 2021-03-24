namespace NEWERPS
{
    partial class CBI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBI));
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
            this.tsbBankInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbRecord = new System.Windows.Forms.Label();
            this.tbChi = new System.Windows.Forms.TextBox();
            this.tbExportRate = new System.Windows.Forms.TextBox();
            this.tbFAX2 = new System.Windows.Forms.TextBox();
            this.tbFAX1 = new System.Windows.Forms.TextBox();
            this.tbTel2 = new System.Windows.Forms.TextBox();
            this.tbTel1 = new System.Windows.Forms.TextBox();
            this.tbPurchaseTitle = new System.Windows.Forms.TextBox();
            this.tbGUInum = new System.Windows.Forms.TextBox();
            this.tbAddressEN = new System.Windows.Forms.TextBox();
            this.tbAddressCN = new System.Windows.Forms.TextBox();
            this.tbCompanyNameEN = new System.Windows.Forms.TextBox();
            this.tbCompanyNameCN = new System.Windows.Forms.TextBox();
            this.tbCompanyNo = new System.Windows.Forms.TextBox();
            this.L0013 = new System.Windows.Forms.Label();
            this.L0012 = new System.Windows.Forms.Label();
            this.L0011 = new System.Windows.Forms.Label();
            this.L0010 = new System.Windows.Forms.Label();
            this.L0009 = new System.Windows.Forms.Label();
            this.L0008 = new System.Windows.Forms.Label();
            this.L0007 = new System.Windows.Forms.Label();
            this.L0006 = new System.Windows.Forms.Label();
            this.L0005 = new System.Windows.Forms.Label();
            this.L0004 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.tsButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tsbBankInfo,
            this.tsbExit});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton.Size = new System.Drawing.Size(982, 58);
            this.tsButton.TabIndex = 20;
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
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(43, 55);
            this.tsbFirst.Text = "First";
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.ToolTipText = "First";
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrior
            // 
            this.tsbPrior.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrior.Image")));
            this.tsbPrior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrior.Name = "tsbPrior";
            this.tsbPrior.Size = new System.Drawing.Size(47, 55);
            this.tsbPrior.Text = "Prior";
            this.tsbPrior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrior.ToolTipText = "Prior";
            this.tsbPrior.Click += new System.EventHandler(this.tsbPrior_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(45, 55);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.ToolTipText = "Next";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(41, 55);
            this.tsbLast.Text = "Last";
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.ToolTipText = "Last";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
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
            // tsbBankInfo
            // 
            this.tsbBankInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbBankInfo.Image")));
            this.tsbBankInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBankInfo.Name = "tsbBankInfo";
            this.tsbBankInfo.Size = new System.Drawing.Size(47, 55);
            this.tsbBankInfo.Text = "Bank";
            this.tsbBankInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbBankInfo.ToolTipText = "Print";
            this.tsbBankInfo.Visible = false;
            this.tsbBankInfo.Click += new System.EventHandler(this.tsbBankInfo_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(37, 55);
            this.tsbExit.Text = "Exit";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Visible = false;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(907, 318);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 51;
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(59, 47);
            this.dgvWord.TabIndex = 28;
            this.dgvWord.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 493);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbRecord);
            this.tabPage1.Controls.Add(this.dgvWord);
            this.tabPage1.Controls.Add(this.tbChi);
            this.tabPage1.Controls.Add(this.tbExportRate);
            this.tabPage1.Controls.Add(this.tbFAX2);
            this.tabPage1.Controls.Add(this.tbFAX1);
            this.tabPage1.Controls.Add(this.tbTel2);
            this.tabPage1.Controls.Add(this.tbTel1);
            this.tabPage1.Controls.Add(this.tbPurchaseTitle);
            this.tabPage1.Controls.Add(this.tbGUInum);
            this.tabPage1.Controls.Add(this.tbAddressEN);
            this.tabPage1.Controls.Add(this.tbAddressCN);
            this.tabPage1.Controls.Add(this.tbCompanyNameEN);
            this.tabPage1.Controls.Add(this.tbCompanyNameCN);
            this.tabPage1.Controls.Add(this.tbCompanyNo);
            this.tabPage1.Controls.Add(this.L0013);
            this.tabPage1.Controls.Add(this.L0012);
            this.tabPage1.Controls.Add(this.L0011);
            this.tabPage1.Controls.Add(this.L0010);
            this.tabPage1.Controls.Add(this.L0009);
            this.tabPage1.Controls.Add(this.L0008);
            this.tabPage1.Controls.Add(this.L0007);
            this.tabPage1.Controls.Add(this.L0006);
            this.tabPage1.Controls.Add(this.L0005);
            this.tabPage1.Controls.Add(this.L0004);
            this.tabPage1.Controls.Add(this.L0003);
            this.tabPage1.Controls.Add(this.L0002);
            this.tabPage1.Controls.Add(this.L0001);
            this.tabPage1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Company Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbRecord.Location = new System.Drawing.Point(397, 11);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(69, 25);
            this.lbRecord.TabIndex = 53;
            this.lbRecord.Text = "label1";
            this.lbRecord.Visible = false;
            // 
            // tbChi
            // 
            this.tbChi.Enabled = false;
            this.tbChi.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbChi.Location = new System.Drawing.Point(811, 408);
            this.tbChi.Name = "tbChi";
            this.tbChi.Size = new System.Drawing.Size(100, 34);
            this.tbChi.TabIndex = 39;
            // 
            // tbExportRate
            // 
            this.tbExportRate.Enabled = false;
            this.tbExportRate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbExportRate.Location = new System.Drawing.Point(166, 408);
            this.tbExportRate.MaxLength = 13;
            this.tbExportRate.Name = "tbExportRate";
            this.tbExportRate.Size = new System.Drawing.Size(203, 34);
            this.tbExportRate.TabIndex = 38;
            this.tbExportRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFAX2
            // 
            this.tbFAX2.Enabled = false;
            this.tbFAX2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbFAX2.Location = new System.Drawing.Point(506, 358);
            this.tbFAX2.MaxLength = 15;
            this.tbFAX2.Name = "tbFAX2";
            this.tbFAX2.Size = new System.Drawing.Size(238, 34);
            this.tbFAX2.TabIndex = 37;
            // 
            // tbFAX1
            // 
            this.tbFAX1.Enabled = false;
            this.tbFAX1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbFAX1.Location = new System.Drawing.Point(166, 358);
            this.tbFAX1.MaxLength = 15;
            this.tbFAX1.Name = "tbFAX1";
            this.tbFAX1.Size = new System.Drawing.Size(238, 34);
            this.tbFAX1.TabIndex = 36;
            // 
            // tbTel2
            // 
            this.tbTel2.Enabled = false;
            this.tbTel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbTel2.Location = new System.Drawing.Point(506, 308);
            this.tbTel2.MaxLength = 15;
            this.tbTel2.Name = "tbTel2";
            this.tbTel2.Size = new System.Drawing.Size(238, 34);
            this.tbTel2.TabIndex = 35;
            // 
            // tbTel1
            // 
            this.tbTel1.Enabled = false;
            this.tbTel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbTel1.Location = new System.Drawing.Point(166, 308);
            this.tbTel1.MaxLength = 15;
            this.tbTel1.Name = "tbTel1";
            this.tbTel1.Size = new System.Drawing.Size(238, 34);
            this.tbTel1.TabIndex = 34;
            // 
            // tbPurchaseTitle
            // 
            this.tbPurchaseTitle.Enabled = false;
            this.tbPurchaseTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPurchaseTitle.Location = new System.Drawing.Point(611, 108);
            this.tbPurchaseTitle.Name = "tbPurchaseTitle";
            this.tbPurchaseTitle.Size = new System.Drawing.Size(300, 34);
            this.tbPurchaseTitle.TabIndex = 33;
            // 
            // tbGUInum
            // 
            this.tbGUInum.Enabled = false;
            this.tbGUInum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbGUInum.Location = new System.Drawing.Point(166, 258);
            this.tbGUInum.Name = "tbGUInum";
            this.tbGUInum.Size = new System.Drawing.Size(238, 34);
            this.tbGUInum.TabIndex = 32;
            // 
            // tbAddressEN
            // 
            this.tbAddressEN.Enabled = false;
            this.tbAddressEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbAddressEN.Location = new System.Drawing.Point(166, 208);
            this.tbAddressEN.Name = "tbAddressEN";
            this.tbAddressEN.Size = new System.Drawing.Size(745, 34);
            this.tbAddressEN.TabIndex = 31;
            // 
            // tbAddressCN
            // 
            this.tbAddressCN.Enabled = false;
            this.tbAddressCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbAddressCN.Location = new System.Drawing.Point(166, 158);
            this.tbAddressCN.Name = "tbAddressCN";
            this.tbAddressCN.Size = new System.Drawing.Size(745, 34);
            this.tbAddressCN.TabIndex = 30;
            // 
            // tbCompanyNameEN
            // 
            this.tbCompanyNameEN.Enabled = false;
            this.tbCompanyNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompanyNameEN.Location = new System.Drawing.Point(166, 108);
            this.tbCompanyNameEN.Name = "tbCompanyNameEN";
            this.tbCompanyNameEN.Size = new System.Drawing.Size(300, 34);
            this.tbCompanyNameEN.TabIndex = 29;
            // 
            // tbCompanyNameCN
            // 
            this.tbCompanyNameCN.Enabled = false;
            this.tbCompanyNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompanyNameCN.Location = new System.Drawing.Point(166, 58);
            this.tbCompanyNameCN.Name = "tbCompanyNameCN";
            this.tbCompanyNameCN.Size = new System.Drawing.Size(300, 34);
            this.tbCompanyNameCN.TabIndex = 28;
            // 
            // tbCompanyNo
            // 
            this.tbCompanyNo.Enabled = false;
            this.tbCompanyNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCompanyNo.Location = new System.Drawing.Point(166, 8);
            this.tbCompanyNo.MaxLength = 3;
            this.tbCompanyNo.Name = "tbCompanyNo";
            this.tbCompanyNo.Size = new System.Drawing.Size(203, 34);
            this.tbCompanyNo.TabIndex = 27;
            // 
            // L0013
            // 
            this.L0013.AutoSize = true;
            this.L0013.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0013.Location = new System.Drawing.Point(766, 418);
            this.L0013.Name = "L0013";
            this.L0013.Size = new System.Drawing.Size(28, 18);
            this.L0013.TabIndex = 52;
            this.L0013.Text = "chi";
            // 
            // L0012
            // 
            this.L0012.AutoSize = true;
            this.L0012.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0012.Location = new System.Drawing.Point(503, 118);
            this.L0012.Name = "L0012";
            this.L0012.Size = new System.Drawing.Size(64, 18);
            this.L0012.TabIndex = 46;
            this.L0012.Text = "採購抬頭";
            // 
            // L0011
            // 
            this.L0011.AutoSize = true;
            this.L0011.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0011.Location = new System.Drawing.Point(436, 368);
            this.L0011.Name = "L0011";
            this.L0011.Size = new System.Drawing.Size(44, 18);
            this.L0011.TabIndex = 50;
            this.L0011.Text = "傳真2";
            // 
            // L0010
            // 
            this.L0010.AutoSize = true;
            this.L0010.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0010.Location = new System.Drawing.Point(436, 318);
            this.L0010.Name = "L0010";
            this.L0010.Size = new System.Drawing.Size(44, 18);
            this.L0010.TabIndex = 48;
            this.L0010.Text = "電話2";
            // 
            // L0009
            // 
            this.L0009.AutoSize = true;
            this.L0009.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0009.Location = new System.Drawing.Point(51, 418);
            this.L0009.Name = "L0009";
            this.L0009.Size = new System.Drawing.Size(64, 18);
            this.L0009.TabIndex = 51;
            this.L0009.Text = "出口匯率";
            // 
            // L0008
            // 
            this.L0008.AutoSize = true;
            this.L0008.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0008.Location = new System.Drawing.Point(80, 368);
            this.L0008.Name = "L0008";
            this.L0008.Size = new System.Drawing.Size(36, 18);
            this.L0008.TabIndex = 49;
            this.L0008.Text = "傳真";
            // 
            // L0007
            // 
            this.L0007.AutoSize = true;
            this.L0007.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0007.Location = new System.Drawing.Point(80, 318);
            this.L0007.Name = "L0007";
            this.L0007.Size = new System.Drawing.Size(36, 18);
            this.L0007.TabIndex = 47;
            this.L0007.Text = "電話";
            // 
            // L0006
            // 
            this.L0006.AutoSize = true;
            this.L0006.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0006.Location = new System.Drawing.Point(52, 268);
            this.L0006.Name = "L0006";
            this.L0006.Size = new System.Drawing.Size(64, 18);
            this.L0006.TabIndex = 45;
            this.L0006.Text = "統一編號";
            // 
            // L0005
            // 
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(55, 218);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(61, 18);
            this.L0005.TabIndex = 44;
            this.L0005.Text = "Address";
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(52, 168);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 43;
            this.L0004.Text = "公司地址";
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(43, 118);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(72, 18);
            this.L0003.TabIndex = 42;
            this.L0003.Text = "Company";
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(51, 68);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 41;
            this.L0002.Text = "公司名稱";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(51, 18);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 18);
            this.L0001.TabIndex = 40;
            this.L0001.Text = "公司代號";
            // 
            // CBI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CBI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyInformation";
            this.Load += new System.EventHandler(this.CompanyInformation_Load);
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsButton;
        private System.Windows.Forms.ToolStripButton tsbInsert;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrior;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbBankInfo;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.TextBox tbChi;
        private System.Windows.Forms.TextBox tbExportRate;
        private System.Windows.Forms.TextBox tbFAX2;
        private System.Windows.Forms.TextBox tbFAX1;
        private System.Windows.Forms.TextBox tbTel2;
        private System.Windows.Forms.TextBox tbTel1;
        private System.Windows.Forms.TextBox tbPurchaseTitle;
        private System.Windows.Forms.TextBox tbGUInum;
        private System.Windows.Forms.TextBox tbAddressEN;
        private System.Windows.Forms.TextBox tbAddressCN;
        private System.Windows.Forms.TextBox tbCompanyNameEN;
        private System.Windows.Forms.TextBox tbCompanyNameCN;
        private System.Windows.Forms.TextBox tbCompanyNo;
        private System.Windows.Forms.Label L0013;
        private System.Windows.Forms.Label L0012;
        private System.Windows.Forms.Label L0011;
        private System.Windows.Forms.Label L0010;
        private System.Windows.Forms.Label L0009;
        private System.Windows.Forms.Label L0008;
        private System.Windows.Forms.Label L0007;
        private System.Windows.Forms.Label L0006;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
    }
}

