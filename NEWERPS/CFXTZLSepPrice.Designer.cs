namespace NEWERPS
{
    partial class CFXTZLSepPrice
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.L0003 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.xieXingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sheHaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeCLASSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xXDJBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nEW_ERPDataSet = new NEWERPS.NEW_ERPDataSet();
            this.L0004 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.xXDJTableAdapter = new NEWERPS.NEW_ERPDataSetTableAdapters.XXDJTableAdapter();
            this.dgvSize = new System.Windows.Forms.DataGridView();
            this.dgvXXDJ = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xXDJBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEW_ERPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXXDJ)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Enabled = false;
            this.tb1.Location = new System.Drawing.Point(165, 23);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(202, 25);
            this.tb1.TabIndex = 44;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Location = new System.Drawing.Point(36, 26);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(41, 15);
            this.L0001.TabIndex = 43;
            this.L0001.Text = "鞋型:";
            // 
            // tb2
            // 
            this.tb2.Enabled = false;
            this.tb2.Location = new System.Drawing.Point(165, 69);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(202, 25);
            this.tb2.TabIndex = 46;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Location = new System.Drawing.Point(36, 72);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(41, 15);
            this.L0002.TabIndex = 45;
            this.L0002.Text = "色號:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(477, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 33);
            this.comboBox1.TabIndex = 47;
            // 
            // L0003
            // 
            this.L0003.Location = new System.Drawing.Point(642, 20);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(97, 42);
            this.L0003.TabIndex = 48;
            this.L0003.Text = "Copy";
            this.L0003.UseVisualStyleBackColor = true;
            this.L0003.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xieXingDataGridViewTextBoxColumn,
            this.sheHaoDataGridViewTextBoxColumn,
            this.lineNumDataGridViewTextBoxColumn,
            this.sizeCLASSDataGridViewTextBoxColumn,
            this.sizeNumberDataGridViewTextBoxColumn,
            this.oPriceDataGridViewTextBoxColumn,
            this.iPriceDataGridViewTextBoxColumn,
            this.cPriceDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.xXDJBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(12, 119);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 27;
            this.dataGridView3.Size = new System.Drawing.Size(776, 319);
            this.dataGridView3.TabIndex = 49;
            // 
            // xieXingDataGridViewTextBoxColumn
            // 
            this.xieXingDataGridViewTextBoxColumn.DataPropertyName = "XieXing";
            this.xieXingDataGridViewTextBoxColumn.HeaderText = "XieXing";
            this.xieXingDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.xieXingDataGridViewTextBoxColumn.Name = "xieXingDataGridViewTextBoxColumn";
            this.xieXingDataGridViewTextBoxColumn.Width = 84;
            // 
            // sheHaoDataGridViewTextBoxColumn
            // 
            this.sheHaoDataGridViewTextBoxColumn.DataPropertyName = "SheHao";
            this.sheHaoDataGridViewTextBoxColumn.HeaderText = "SheHao";
            this.sheHaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sheHaoDataGridViewTextBoxColumn.Name = "sheHaoDataGridViewTextBoxColumn";
            this.sheHaoDataGridViewTextBoxColumn.Width = 80;
            // 
            // lineNumDataGridViewTextBoxColumn
            // 
            this.lineNumDataGridViewTextBoxColumn.DataPropertyName = "LineNum";
            this.lineNumDataGridViewTextBoxColumn.HeaderText = "LineNum";
            this.lineNumDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lineNumDataGridViewTextBoxColumn.Name = "lineNumDataGridViewTextBoxColumn";
            this.lineNumDataGridViewTextBoxColumn.Width = 90;
            // 
            // sizeCLASSDataGridViewTextBoxColumn
            // 
            this.sizeCLASSDataGridViewTextBoxColumn.DataPropertyName = "Size_CLASS";
            this.sizeCLASSDataGridViewTextBoxColumn.HeaderText = "Size_CLASS";
            this.sizeCLASSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sizeCLASSDataGridViewTextBoxColumn.Name = "sizeCLASSDataGridViewTextBoxColumn";
            this.sizeCLASSDataGridViewTextBoxColumn.Width = 111;
            // 
            // sizeNumberDataGridViewTextBoxColumn
            // 
            this.sizeNumberDataGridViewTextBoxColumn.DataPropertyName = "Size_Number";
            this.sizeNumberDataGridViewTextBoxColumn.HeaderText = "Size_Number";
            this.sizeNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sizeNumberDataGridViewTextBoxColumn.Name = "sizeNumberDataGridViewTextBoxColumn";
            this.sizeNumberDataGridViewTextBoxColumn.Width = 113;
            // 
            // oPriceDataGridViewTextBoxColumn
            // 
            this.oPriceDataGridViewTextBoxColumn.DataPropertyName = "OPrice";
            this.oPriceDataGridViewTextBoxColumn.HeaderText = "OPrice";
            this.oPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.oPriceDataGridViewTextBoxColumn.Name = "oPriceDataGridViewTextBoxColumn";
            this.oPriceDataGridViewTextBoxColumn.Width = 75;
            // 
            // iPriceDataGridViewTextBoxColumn
            // 
            this.iPriceDataGridViewTextBoxColumn.DataPropertyName = "IPrice";
            this.iPriceDataGridViewTextBoxColumn.HeaderText = "IPrice";
            this.iPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iPriceDataGridViewTextBoxColumn.Name = "iPriceDataGridViewTextBoxColumn";
            this.iPriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // cPriceDataGridViewTextBoxColumn
            // 
            this.cPriceDataGridViewTextBoxColumn.DataPropertyName = "CPrice";
            this.cPriceDataGridViewTextBoxColumn.HeaderText = "CPrice";
            this.cPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cPriceDataGridViewTextBoxColumn.Name = "cPriceDataGridViewTextBoxColumn";
            this.cPriceDataGridViewTextBoxColumn.Width = 74;
            // 
            // xXDJBindingSource
            // 
            this.xXDJBindingSource.DataMember = "XXDJ";
            this.xXDJBindingSource.DataSource = this.nEW_ERPDataSet;
            // 
            // nEW_ERPDataSet
            // 
            this.nEW_ERPDataSet.DataSetName = "NEW_ERPDataSet";
            this.nEW_ERPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // L0004
            // 
            this.L0004.Location = new System.Drawing.Point(642, 68);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(97, 42);
            this.L0004.TabIndex = 50;
            this.L0004.Text = "SAVE";
            this.L0004.UseVisualStyleBackColor = true;
            this.L0004.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(751, 20);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 96;
            this.dgvWord.Visible = false;
            // 
            // xXDJTableAdapter
            // 
            this.xXDJTableAdapter.ClearBeforeFill = true;
            // 
            // dgvSize
            // 
            this.dgvSize.AllowUserToAddRows = false;
            this.dgvSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSize.Location = new System.Drawing.Point(763, 72);
            this.dgvSize.Name = "dgvSize";
            this.dgvSize.ReadOnly = true;
            this.dgvSize.RowHeadersVisible = false;
            this.dgvSize.RowHeadersWidth = 51;
            this.dgvSize.RowTemplate.Height = 27;
            this.dgvSize.Size = new System.Drawing.Size(25, 33);
            this.dgvSize.TabIndex = 97;
            this.dgvSize.Visible = false;
            // 
            // dgvXXDJ
            // 
            this.dgvXXDJ.AllowUserToAddRows = false;
            this.dgvXXDJ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvXXDJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXXDJ.Location = new System.Drawing.Point(611, 72);
            this.dgvXXDJ.Name = "dgvXXDJ";
            this.dgvXXDJ.ReadOnly = true;
            this.dgvXXDJ.RowHeadersVisible = false;
            this.dgvXXDJ.RowHeadersWidth = 51;
            this.dgvXXDJ.RowTemplate.Height = 27;
            this.dgvXXDJ.Size = new System.Drawing.Size(25, 33);
            this.dgvXXDJ.TabIndex = 98;
            this.dgvXXDJ.Visible = false;
            // 
            // CFXTZLSepPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvXXDJ);
            this.Controls.Add(this.dgvSize);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.L0001);
            this.Name = "CFXTZLSepPrice";
            this.Text = "CFXTZLSepPrice";
            this.Load += new System.EventHandler(this.CFXTZLSepPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xXDJBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEW_ERPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXXDJ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button L0003;
        internal System.Windows.Forms.TextBox tb1;
        internal System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button L0004;
        private System.Windows.Forms.DataGridView dgvWord;
        private NEW_ERPDataSet nEW_ERPDataSet;
        private System.Windows.Forms.BindingSource xXDJBindingSource;
        private NEW_ERPDataSetTableAdapters.XXDJTableAdapter xXDJTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn xieXingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sheHaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeCLASSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvSize;
        private System.Windows.Forms.DataGridView dgvXXDJ;
    }
}