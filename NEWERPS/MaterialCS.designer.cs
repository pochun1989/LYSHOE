namespace NEWERPS
{
    partial class MaterialCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialCS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvClassA = new System.Windows.Forms.DataGridView();
            this.tsButton = new System.Windows.Forms.ToolStrip();
            this.tsbQuery = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbModify = new System.Windows.Forms.ToolStripButton();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrior = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvClassB = new System.Windows.Forms.DataGridView();
            this.tsButton2 = new System.Windows.Forms.ToolStrip();
            this.tsbQuery2 = new System.Windows.Forms.ToolStripButton();
            this.tsbClear2 = new System.Windows.Forms.ToolStripButton();
            this.tsbInsert2 = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete2 = new System.Windows.Forms.ToolStripButton();
            this.tsbModify2 = new System.Windows.Forms.ToolStripButton();
            this.tsbFirst2 = new System.Windows.Forms.ToolStripButton();
            this.tsbPrior2 = new System.Windows.Forms.ToolStripButton();
            this.tsbNext2 = new System.Windows.Forms.ToolStripButton();
            this.tsbLast2 = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint2 = new System.Windows.Forms.ToolStripButton();
            this.tsbExit2 = new System.Windows.Forms.ToolStripButton();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.L0001 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassA)).BeginInit();
            this.tsButton.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassB)).BeginInit();
            this.tsButton2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvClassA);
            this.panel1.Controls.Add(this.L0001);
            this.panel1.Controls.Add(this.tsButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 303);
            this.panel1.TabIndex = 0;
            // 
            // dgvClassA
            // 
            this.dgvClassA.AllowUserToAddRows = false;
            this.dgvClassA.AllowUserToDeleteRows = false;
            this.dgvClassA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassA.Location = new System.Drawing.Point(3, 70);
            this.dgvClassA.Name = "dgvClassA";
            this.dgvClassA.ReadOnly = true;
            this.dgvClassA.RowHeadersVisible = false;
            this.dgvClassA.RowTemplate.Height = 27;
            this.dgvClassA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassA.Size = new System.Drawing.Size(890, 230);
            this.dgvClassA.TabIndex = 23;
            this.dgvClassA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassA_CellClick);
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
            this.tsbFirst,
            this.tsbPrior,
            this.tsbNext,
            this.tsbLast,
            this.tsbPrint,
            this.tsbExit});
            this.tsButton.Location = new System.Drawing.Point(0, 0);
            this.tsButton.Name = "tsButton";
            this.tsButton.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton.Size = new System.Drawing.Size(896, 58);
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
            this.tsbExit.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvClassB);
            this.panel2.Controls.Add(this.tsButton2);
            this.panel2.Location = new System.Drawing.Point(12, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 248);
            this.panel2.TabIndex = 23;
            // 
            // dgvClassB
            // 
            this.dgvClassB.AllowUserToAddRows = false;
            this.dgvClassB.AllowUserToDeleteRows = false;
            this.dgvClassB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassB.Location = new System.Drawing.Point(3, 74);
            this.dgvClassB.Name = "dgvClassB";
            this.dgvClassB.ReadOnly = true;
            this.dgvClassB.RowHeadersVisible = false;
            this.dgvClassB.RowTemplate.Height = 27;
            this.dgvClassB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassB.Size = new System.Drawing.Size(890, 171);
            this.dgvClassB.TabIndex = 24;
            this.dgvClassB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassB_CellClick);
            // 
            // tsButton2
            // 
            this.tsButton2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButton2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbQuery2,
            this.tsbClear2,
            this.tsbInsert2,
            this.tsbDelete2,
            this.tsbModify2,
            this.tsbFirst2,
            this.tsbPrior2,
            this.tsbNext2,
            this.tsbLast2,
            this.tsbPrint2,
            this.tsbExit2});
            this.tsButton2.Location = new System.Drawing.Point(0, 0);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsButton2.Size = new System.Drawing.Size(896, 58);
            this.tsButton2.TabIndex = 22;
            this.tsButton2.Text = "toolStrip1";
            // 
            // tsbQuery2
            // 
            this.tsbQuery2.Enabled = false;
            this.tsbQuery2.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuery2.Image")));
            this.tsbQuery2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuery2.Name = "tsbQuery2";
            this.tsbQuery2.Size = new System.Drawing.Size(56, 55);
            this.tsbQuery2.Text = "Query";
            this.tsbQuery2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQuery2.ToolTipText = "Query";
            // 
            // tsbClear2
            // 
            this.tsbClear2.Enabled = false;
            this.tsbClear2.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear2.Image")));
            this.tsbClear2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear2.Name = "tsbClear2";
            this.tsbClear2.Size = new System.Drawing.Size(49, 55);
            this.tsbClear2.Text = "Clear";
            this.tsbClear2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbInsert2
            // 
            this.tsbInsert2.Enabled = false;
            this.tsbInsert2.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsert2.Image")));
            this.tsbInsert2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsert2.Name = "tsbInsert2";
            this.tsbInsert2.Size = new System.Drawing.Size(52, 55);
            this.tsbInsert2.Text = "Insert";
            this.tsbInsert2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInsert2.ToolTipText = "Insert";
            this.tsbInsert2.Click += new System.EventHandler(this.tsbInsert2_Click);
            // 
            // tsbDelete2
            // 
            this.tsbDelete2.Enabled = false;
            this.tsbDelete2.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete2.Image")));
            this.tsbDelete2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete2.Name = "tsbDelete2";
            this.tsbDelete2.Size = new System.Drawing.Size(57, 55);
            this.tsbDelete2.Text = "Delete";
            this.tsbDelete2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete2.ToolTipText = "Delete";
            this.tsbDelete2.Click += new System.EventHandler(this.tsbDelete2_Click);
            // 
            // tsbModify2
            // 
            this.tsbModify2.Enabled = false;
            this.tsbModify2.Image = ((System.Drawing.Image)(resources.GetObject("tsbModify2.Image")));
            this.tsbModify2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModify2.Name = "tsbModify2";
            this.tsbModify2.Size = new System.Drawing.Size(63, 55);
            this.tsbModify2.Text = "Modify";
            this.tsbModify2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModify2.Click += new System.EventHandler(this.tsbModify2_Click);
            // 
            // tsbFirst2
            // 
            this.tsbFirst2.Enabled = false;
            this.tsbFirst2.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst2.Image")));
            this.tsbFirst2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst2.Name = "tsbFirst2";
            this.tsbFirst2.Size = new System.Drawing.Size(43, 55);
            this.tsbFirst2.Text = "First";
            this.tsbFirst2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst2.ToolTipText = "First";
            // 
            // tsbPrior2
            // 
            this.tsbPrior2.Enabled = false;
            this.tsbPrior2.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrior2.Image")));
            this.tsbPrior2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrior2.Name = "tsbPrior2";
            this.tsbPrior2.Size = new System.Drawing.Size(47, 55);
            this.tsbPrior2.Text = "Prior";
            this.tsbPrior2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrior2.ToolTipText = "Prior";
            // 
            // tsbNext2
            // 
            this.tsbNext2.Enabled = false;
            this.tsbNext2.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext2.Image")));
            this.tsbNext2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext2.Name = "tsbNext2";
            this.tsbNext2.Size = new System.Drawing.Size(45, 55);
            this.tsbNext2.Text = "Next";
            this.tsbNext2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext2.ToolTipText = "Next";
            // 
            // tsbLast2
            // 
            this.tsbLast2.Enabled = false;
            this.tsbLast2.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast2.Image")));
            this.tsbLast2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast2.Name = "tsbLast2";
            this.tsbLast2.Size = new System.Drawing.Size(41, 55);
            this.tsbLast2.Text = "Last";
            this.tsbLast2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast2.ToolTipText = "Last";
            // 
            // tsbPrint2
            // 
            this.tsbPrint2.Enabled = false;
            this.tsbPrint2.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint2.Image")));
            this.tsbPrint2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint2.Name = "tsbPrint2";
            this.tsbPrint2.Size = new System.Drawing.Size(46, 55);
            this.tsbPrint2.Text = "Print";
            this.tsbPrint2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint2.ToolTipText = "Print";
            // 
            // tsbExit2
            // 
            this.tsbExit2.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit2.Image")));
            this.tsbExit2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit2.Name = "tsbExit2";
            this.tsbExit2.Size = new System.Drawing.Size(37, 55);
            this.tsbExit2.Text = "Exit";
            this.tsbExit2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit2.Visible = false;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(12, 12);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 24;
            this.dgvWord.Visible = false;
            // 
            // L0001
            // 
            this.L0001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(571, 0);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(216, 42);
            this.L0001.TabIndex = 30;
            this.L0001.Text = "材料類別設定";
            // 
            // MaterialCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 599);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MaterialCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaterialClassSet";
            this.Load += new System.EventHandler(this.MaterialClassSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassA)).EndInit();
            this.tsButton.ResumeLayout(false);
            this.tsButton.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassB)).EndInit();
            this.tsButton2.ResumeLayout(false);
            this.tsButton2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tsButton2;
        private System.Windows.Forms.ToolStripButton tsbQuery2;
        private System.Windows.Forms.ToolStripButton tsbClear2;
        private System.Windows.Forms.ToolStripButton tsbInsert2;
        private System.Windows.Forms.ToolStripButton tsbDelete2;
        private System.Windows.Forms.ToolStripButton tsbModify2;
        private System.Windows.Forms.ToolStripButton tsbFirst2;
        private System.Windows.Forms.ToolStripButton tsbPrior2;
        private System.Windows.Forms.ToolStripButton tsbNext2;
        private System.Windows.Forms.ToolStripButton tsbLast2;
        private System.Windows.Forms.ToolStripButton tsbPrint2;
        private System.Windows.Forms.ToolStripButton tsbExit2;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.DataGridView dgvClassA;
        private System.Windows.Forms.DataGridView dgvClassB;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}