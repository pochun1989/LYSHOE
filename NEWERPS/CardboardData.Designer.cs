namespace NEWERPS
{
    partial class CardboardData
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardboardData));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kfdhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastsgjmhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outsolegjmhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperURLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAPERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lY_TESTDataSet = new NEWERPS.LY_TESTDataSet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tb紙板名 = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.cb底膜 = new System.Windows.Forms.ComboBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.cb楦頭 = new System.Windows.Forms.ComboBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.cb品牌 = new System.Windows.Forms.ComboBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tsButton = new System.Windows.Forms.ToolStrip();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrior = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.pAPERTableAdapter = new NEWERPS.LY_TESTDataSetTableAdapters.PAPERTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAPERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lY_TESTDataSet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.tsButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(13, 63);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1021, 497);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1013, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "紙板速查";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kfdhDataGridViewTextBoxColumn,
            this.lastsgjmhDataGridViewTextBoxColumn,
            this.outsolegjmhDataGridViewTextBoxColumn,
            this.paperIDDataGridViewTextBoxColumn,
            this.paperNameDataGridViewTextBoxColumn,
            this.paperURLDataGridViewTextBoxColumn,
            this.uSERDATEDataGridViewTextBoxColumn,
            this.uSERIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pAPERBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(999, 453);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPro_CellEnter);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // kfdhDataGridViewTextBoxColumn
            // 
            this.kfdhDataGridViewTextBoxColumn.DataPropertyName = "kfdh";
            this.kfdhDataGridViewTextBoxColumn.HeaderText = "kfdh";
            this.kfdhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kfdhDataGridViewTextBoxColumn.Name = "kfdhDataGridViewTextBoxColumn";
            // 
            // lastsgjmhDataGridViewTextBoxColumn
            // 
            this.lastsgjmhDataGridViewTextBoxColumn.DataPropertyName = "Lastsgjmh";
            this.lastsgjmhDataGridViewTextBoxColumn.HeaderText = "Lastsgjmh";
            this.lastsgjmhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastsgjmhDataGridViewTextBoxColumn.Name = "lastsgjmhDataGridViewTextBoxColumn";
            // 
            // outsolegjmhDataGridViewTextBoxColumn
            // 
            this.outsolegjmhDataGridViewTextBoxColumn.DataPropertyName = "Outsolegjmh";
            this.outsolegjmhDataGridViewTextBoxColumn.HeaderText = "Outsolegjmh";
            this.outsolegjmhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.outsolegjmhDataGridViewTextBoxColumn.Name = "outsolegjmhDataGridViewTextBoxColumn";
            // 
            // paperIDDataGridViewTextBoxColumn
            // 
            this.paperIDDataGridViewTextBoxColumn.DataPropertyName = "Paper_ID";
            this.paperIDDataGridViewTextBoxColumn.HeaderText = "Paper_ID";
            this.paperIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paperIDDataGridViewTextBoxColumn.Name = "paperIDDataGridViewTextBoxColumn";
            // 
            // paperNameDataGridViewTextBoxColumn
            // 
            this.paperNameDataGridViewTextBoxColumn.DataPropertyName = "Paper_Name";
            this.paperNameDataGridViewTextBoxColumn.HeaderText = "Paper_Name";
            this.paperNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paperNameDataGridViewTextBoxColumn.Name = "paperNameDataGridViewTextBoxColumn";
            // 
            // paperURLDataGridViewTextBoxColumn
            // 
            this.paperURLDataGridViewTextBoxColumn.DataPropertyName = "Paper_URL";
            this.paperURLDataGridViewTextBoxColumn.HeaderText = "Paper_URL";
            this.paperURLDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paperURLDataGridViewTextBoxColumn.Name = "paperURLDataGridViewTextBoxColumn";
            this.paperURLDataGridViewTextBoxColumn.Visible = false;
            // 
            // uSERDATEDataGridViewTextBoxColumn
            // 
            this.uSERDATEDataGridViewTextBoxColumn.DataPropertyName = "USERDATE";
            this.uSERDATEDataGridViewTextBoxColumn.HeaderText = "USERDATE";
            this.uSERDATEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.uSERDATEDataGridViewTextBoxColumn.Name = "uSERDATEDataGridViewTextBoxColumn";
            this.uSERDATEDataGridViewTextBoxColumn.Visible = false;
            // 
            // uSERIDDataGridViewTextBoxColumn
            // 
            this.uSERIDDataGridViewTextBoxColumn.DataPropertyName = "USERID";
            this.uSERIDDataGridViewTextBoxColumn.HeaderText = "USERID";
            this.uSERIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.uSERIDDataGridViewTextBoxColumn.Name = "uSERIDDataGridViewTextBoxColumn";
            this.uSERIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // pAPERBindingSource
            // 
            this.pAPERBindingSource.DataMember = "PAPER";
            this.pAPERBindingSource.DataSource = this.lY_TESTDataSet;
            // 
            // lY_TESTDataSet
            // 
            this.lY_TESTDataSet.DataSetName = "LY_TESTDataSet";
            this.lY_TESTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvWord);
            this.tabPage2.Controls.Add(this.tb紙板名);
            this.tabPage2.Controls.Add(this.L0004);
            this.tabPage2.Controls.Add(this.cb底膜);
            this.tabPage2.Controls.Add(this.L0003);
            this.tabPage2.Controls.Add(this.cb楦頭);
            this.tabPage2.Controls.Add(this.L0002);
            this.tabPage2.Controls.Add(this.cb品牌);
            this.tabPage2.Controls.Add(this.L0001);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1013, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "紙板資料";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(969, 424);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 131;
            this.dgvWord.Visible = false;
            // 
            // tb紙板名
            // 
            this.tb紙板名.Enabled = false;
            this.tb紙板名.Location = new System.Drawing.Point(500, 331);
            this.tb紙板名.Name = "tb紙板名";
            this.tb紙板名.Size = new System.Drawing.Size(209, 25);
            this.tb紙板名.TabIndex = 7;
            this.tb紙板名.Text = " ";
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Location = new System.Drawing.Point(294, 334);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 6;
            this.L0004.Text = "紙板名稱";
            // 
            // cb底膜
            // 
            this.cb底膜.Enabled = false;
            this.cb底膜.FormattingEnabled = true;
            this.cb底膜.Location = new System.Drawing.Point(500, 265);
            this.cb底膜.Name = "cb底膜";
            this.cb底膜.Size = new System.Drawing.Size(209, 25);
            this.cb底膜.TabIndex = 5;
            this.cb底膜.Visible = false;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Location = new System.Drawing.Point(294, 268);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(50, 18);
            this.L0003.TabIndex = 4;
            this.L0003.Text = "大底模";
            // 
            // cb楦頭
            // 
            this.cb楦頭.Enabled = false;
            this.cb楦頭.FormattingEnabled = true;
            this.cb楦頭.Location = new System.Drawing.Point(500, 199);
            this.cb楦頭.Name = "cb楦頭";
            this.cb楦頭.Size = new System.Drawing.Size(209, 25);
            this.cb楦頭.TabIndex = 3;
            this.cb楦頭.Visible = false;
            this.cb楦頭.SelectedIndexChanged += new System.EventHandler(this.cb楦頭_SelectedIndexChanged);
            this.cb楦頭.SelectedValueChanged += new System.EventHandler(this.cb楦頭_SelectedValueChanged);
            this.cb楦頭.Click += new System.EventHandler(this.cb楦頭_Click);
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Location = new System.Drawing.Point(294, 202);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(36, 18);
            this.L0002.TabIndex = 2;
            this.L0002.Text = "楦頭";
            // 
            // cb品牌
            // 
            this.cb品牌.Enabled = false;
            this.cb品牌.FormattingEnabled = true;
            this.cb品牌.Location = new System.Drawing.Point(500, 133);
            this.cb品牌.Name = "cb品牌";
            this.cb品牌.Size = new System.Drawing.Size(209, 25);
            this.cb品牌.TabIndex = 1;
            this.cb品牌.SelectedIndexChanged += new System.EventHandler(this.cb品牌_SelectedIndexChanged);
            this.cb品牌.SelectedValueChanged += new System.EventHandler(this.cb品牌_SelectedValueChanged);
            this.cb品牌.Click += new System.EventHandler(this.cb品牌_Click);
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Location = new System.Drawing.Point(294, 136);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(36, 18);
            this.L0001.TabIndex = 0;
            this.L0001.Text = "品牌";
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
            this.toolStripSeparator4,
            this.tsbFirst,
            this.tsbPrior,
            this.tsbNext,
            this.tsbLast,
            this.toolStripSeparator2,
            this.tsbPrint,
            this.tsbConfirm,
            this.toolStripSeparator3,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton8});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton.Size = new System.Drawing.Size(1047, 58);
            this.tsButton.TabIndex = 23;
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
            this.tsbInsert.ToolTipText = "列表檢視";
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
            this.tsbDelete.ToolTipText = "列表檢視";
            // 
            // tsbModify
            // 
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(43, 55);
            this.tsbFirst.Text = "First";
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.ToolTipText = "列表檢視";
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
            this.tsbPrior.ToolTipText = "列表檢視";
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
            this.tsbNext.ToolTipText = "列表檢視";
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
            this.tsbLast.ToolTipText = "列表檢視";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
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
            this.tsbPrint.ToolTipText = "列表檢視";
            // 
            // tsbConfirm
            // 
            this.tsbConfirm.Enabled = false;
            this.tsbConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfirm.Image")));
            this.tsbConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfirm.Name = "tsbConfirm";
            this.tsbConfirm.Size = new System.Drawing.Size(70, 55);
            this.tsbConfirm.Text = "Confirm";
            this.tsbConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Enabled = false;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Enabled = false;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Enabled = false;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(29, 55);
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // pAPERTableAdapter
            // 
            this.pAPERTableAdapter.ClearBeforeFill = true;
            // 
            // CardboardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 574);
            this.Controls.Add(this.tsButton);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CardboardData";
            this.Text = "CardboardData";
            this.Load += new System.EventHandler(this.CardboardData_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAPERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lY_TESTDataSet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb紙板名;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.ComboBox cb底膜;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.ComboBox cb楦頭;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.ComboBox cb品牌;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.ToolStrip tsButton;
        private System.Windows.Forms.ToolStripButton tsbQuery;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbInsert;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbModify;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrior;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbConfirm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.DataGridView dgvWord;
        private LY_TESTDataSet lY_TESTDataSet;
        private System.Windows.Forms.BindingSource pAPERBindingSource;
        private LY_TESTDataSetTableAdapters.PAPERTableAdapter pAPERTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kfdhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastsgjmhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outsolegjmhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperURLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERIDDataGridViewTextBoxColumn;
    }
}