namespace NEWERPS
{
    partial class CFXTZLSupplier
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.L0001 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.nEW_ERPDataSet = new NEWERPS.NEW_ERPDataSet();
            this.supplierlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplier_listTableAdapter = new NEWERPS.NEW_ERPDataSetTableAdapters.supplier_listTableAdapter();
            this.cldhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zsdhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kfdhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packingMinQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hIGHSTOCKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOWSTOCKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hIGHPURCHQTYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leadtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLCLASSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQDHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEW_ERPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierlistBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cldhDataGridViewTextBoxColumn,
            this.zsdhDataGridViewTextBoxColumn,
            this.pMIDDataGridViewTextBoxColumn,
            this.kfdhDataGridViewTextBoxColumn,
            this.packingMinQtyDataGridViewTextBoxColumn,
            this.mOQDataGridViewTextBoxColumn,
            this.hIGHSTOCKDataGridViewTextBoxColumn,
            this.lOWSTOCKDataGridViewTextBoxColumn,
            this.hIGHPURCHQTYDataGridViewTextBoxColumn,
            this.leadtimeDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.unitidDataGridViewTextBoxColumn,
            this.sLCLASSDataGridViewTextBoxColumn,
            this.uSERIDDataGridViewTextBoxColumn,
            this.uSERDATEDataGridViewTextBoxColumn,
            this.cQDHDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.supplierlistBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(414, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(614, 554);
            this.dataGridView1.TabIndex = 98;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(49, 190);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(57, 25);
            this.L0001.TabIndex = 99;
            this.L0001.Text = "材料:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(105, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 100;
            this.label2.Text = "0";
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(26, 538);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 101;
            this.dgvWord.Visible = false;
            // 
            // nEW_ERPDataSet
            // 
            this.nEW_ERPDataSet.DataSetName = "NEW_ERPDataSet";
            this.nEW_ERPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supplierlistBindingSource
            // 
            this.supplierlistBindingSource.DataMember = "supplier_list";
            this.supplierlistBindingSource.DataSource = this.nEW_ERPDataSet;
            // 
            // supplier_listTableAdapter
            // 
            this.supplier_listTableAdapter.ClearBeforeFill = true;
            // 
            // cldhDataGridViewTextBoxColumn
            // 
            this.cldhDataGridViewTextBoxColumn.DataPropertyName = "cldh";
            this.cldhDataGridViewTextBoxColumn.HeaderText = "cldh";
            this.cldhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cldhDataGridViewTextBoxColumn.Name = "cldhDataGridViewTextBoxColumn";
            this.cldhDataGridViewTextBoxColumn.Width = 60;
            // 
            // zsdhDataGridViewTextBoxColumn
            // 
            this.zsdhDataGridViewTextBoxColumn.DataPropertyName = "zsdh";
            this.zsdhDataGridViewTextBoxColumn.HeaderText = "zsdh";
            this.zsdhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.zsdhDataGridViewTextBoxColumn.Name = "zsdhDataGridViewTextBoxColumn";
            this.zsdhDataGridViewTextBoxColumn.Width = 61;
            // 
            // pMIDDataGridViewTextBoxColumn
            // 
            this.pMIDDataGridViewTextBoxColumn.DataPropertyName = "PM_ID";
            this.pMIDDataGridViewTextBoxColumn.HeaderText = "PM_ID";
            this.pMIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pMIDDataGridViewTextBoxColumn.Name = "pMIDDataGridViewTextBoxColumn";
            this.pMIDDataGridViewTextBoxColumn.Width = 79;
            // 
            // kfdhDataGridViewTextBoxColumn
            // 
            this.kfdhDataGridViewTextBoxColumn.DataPropertyName = "kfdh";
            this.kfdhDataGridViewTextBoxColumn.HeaderText = "kfdh";
            this.kfdhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kfdhDataGridViewTextBoxColumn.Name = "kfdhDataGridViewTextBoxColumn";
            this.kfdhDataGridViewTextBoxColumn.Width = 62;
            // 
            // packingMinQtyDataGridViewTextBoxColumn
            // 
            this.packingMinQtyDataGridViewTextBoxColumn.DataPropertyName = "Packing_Min_Qty";
            this.packingMinQtyDataGridViewTextBoxColumn.HeaderText = "Packing_Min_Qty";
            this.packingMinQtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.packingMinQtyDataGridViewTextBoxColumn.Name = "packingMinQtyDataGridViewTextBoxColumn";
            this.packingMinQtyDataGridViewTextBoxColumn.Width = 140;
            // 
            // mOQDataGridViewTextBoxColumn
            // 
            this.mOQDataGridViewTextBoxColumn.DataPropertyName = "MOQ";
            this.mOQDataGridViewTextBoxColumn.HeaderText = "MOQ";
            this.mOQDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mOQDataGridViewTextBoxColumn.Name = "mOQDataGridViewTextBoxColumn";
            this.mOQDataGridViewTextBoxColumn.Width = 69;
            // 
            // hIGHSTOCKDataGridViewTextBoxColumn
            // 
            this.hIGHSTOCKDataGridViewTextBoxColumn.DataPropertyName = "HIGH_STOCK";
            this.hIGHSTOCKDataGridViewTextBoxColumn.HeaderText = "HIGH_STOCK";
            this.hIGHSTOCKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hIGHSTOCKDataGridViewTextBoxColumn.Name = "hIGHSTOCKDataGridViewTextBoxColumn";
            this.hIGHSTOCKDataGridViewTextBoxColumn.Width = 124;
            // 
            // lOWSTOCKDataGridViewTextBoxColumn
            // 
            this.lOWSTOCKDataGridViewTextBoxColumn.DataPropertyName = "LOW_STOCK";
            this.lOWSTOCKDataGridViewTextBoxColumn.HeaderText = "LOW_STOCK";
            this.lOWSTOCKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lOWSTOCKDataGridViewTextBoxColumn.Name = "lOWSTOCKDataGridViewTextBoxColumn";
            this.lOWSTOCKDataGridViewTextBoxColumn.Width = 121;
            // 
            // hIGHPURCHQTYDataGridViewTextBoxColumn
            // 
            this.hIGHPURCHQTYDataGridViewTextBoxColumn.DataPropertyName = "HIGH_PURCH_QTY";
            this.hIGHPURCHQTYDataGridViewTextBoxColumn.HeaderText = "HIGH_PURCH_QTY";
            this.hIGHPURCHQTYDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hIGHPURCHQTYDataGridViewTextBoxColumn.Name = "hIGHPURCHQTYDataGridViewTextBoxColumn";
            this.hIGHPURCHQTYDataGridViewTextBoxColumn.Width = 160;
            // 
            // leadtimeDataGridViewTextBoxColumn
            // 
            this.leadtimeDataGridViewTextBoxColumn.DataPropertyName = "leadtime";
            this.leadtimeDataGridViewTextBoxColumn.HeaderText = "leadtime";
            this.leadtimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.leadtimeDataGridViewTextBoxColumn.Name = "leadtimeDataGridViewTextBoxColumn";
            this.leadtimeDataGridViewTextBoxColumn.Width = 84;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "weight";
            this.weightDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.Width = 74;
            // 
            // unitidDataGridViewTextBoxColumn
            // 
            this.unitidDataGridViewTextBoxColumn.DataPropertyName = "unit_id";
            this.unitidDataGridViewTextBoxColumn.HeaderText = "unit_id";
            this.unitidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.unitidDataGridViewTextBoxColumn.Name = "unitidDataGridViewTextBoxColumn";
            this.unitidDataGridViewTextBoxColumn.Width = 76;
            // 
            // sLCLASSDataGridViewTextBoxColumn
            // 
            this.sLCLASSDataGridViewTextBoxColumn.DataPropertyName = "SL_CLASS";
            this.sLCLASSDataGridViewTextBoxColumn.HeaderText = "SL_CLASS";
            this.sLCLASSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sLCLASSDataGridViewTextBoxColumn.Name = "sLCLASSDataGridViewTextBoxColumn";
            this.sLCLASSDataGridViewTextBoxColumn.Width = 104;
            // 
            // uSERIDDataGridViewTextBoxColumn
            // 
            this.uSERIDDataGridViewTextBoxColumn.DataPropertyName = "USERID";
            this.uSERIDDataGridViewTextBoxColumn.HeaderText = "USERID";
            this.uSERIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.uSERIDDataGridViewTextBoxColumn.Name = "uSERIDDataGridViewTextBoxColumn";
            this.uSERIDDataGridViewTextBoxColumn.Width = 87;
            // 
            // uSERDATEDataGridViewTextBoxColumn
            // 
            this.uSERDATEDataGridViewTextBoxColumn.DataPropertyName = "USERDATE";
            this.uSERDATEDataGridViewTextBoxColumn.HeaderText = "USERDATE";
            this.uSERDATEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.uSERDATEDataGridViewTextBoxColumn.Name = "uSERDATEDataGridViewTextBoxColumn";
            this.uSERDATEDataGridViewTextBoxColumn.Width = 110;
            // 
            // cQDHDataGridViewTextBoxColumn
            // 
            this.cQDHDataGridViewTextBoxColumn.DataPropertyName = "CQDH";
            this.cQDHDataGridViewTextBoxColumn.HeaderText = "CQDH";
            this.cQDHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cQDHDataGridViewTextBoxColumn.Name = "cQDHDataGridViewTextBoxColumn";
            this.cQDHDataGridViewTextBoxColumn.Width = 75;
            // 
            // CFXTZLSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 597);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CFXTZLSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFXTZLSupplier";
            this.Load += new System.EventHandler(this.CFXTZLSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEW_ERPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierlistBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label L0001;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvWord;
        private NEW_ERPDataSet nEW_ERPDataSet;
        private System.Windows.Forms.BindingSource supplierlistBindingSource;
        private NEW_ERPDataSetTableAdapters.supplier_listTableAdapter supplier_listTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zsdhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kfdhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packingMinQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hIGHSTOCKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOWSTOCKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hIGHPURCHQTYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leadtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLCLASSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cQDHDataGridViewTextBoxColumn;
    }
}