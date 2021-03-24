namespace NEWERPS
{
    partial class QOC
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
            this.dgvQuoteOrderMaster = new System.Windows.Forms.DataGridView();
            this.dgvQuoteOrderDetail = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.chkIsQueryDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuoteOrderMaster
            // 
            this.dgvQuoteOrderMaster.AllowUserToAddRows = false;
            this.dgvQuoteOrderMaster.AllowUserToDeleteRows = false;
            this.dgvQuoteOrderMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuoteOrderMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuoteOrderMaster.Location = new System.Drawing.Point(13, 15);
            this.dgvQuoteOrderMaster.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvQuoteOrderMaster.Name = "dgvQuoteOrderMaster";
            this.dgvQuoteOrderMaster.ReadOnly = true;
            this.dgvQuoteOrderMaster.RowHeadersVisible = false;
            this.dgvQuoteOrderMaster.RowTemplate.Height = 27;
            this.dgvQuoteOrderMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuoteOrderMaster.Size = new System.Drawing.Size(753, 174);
            this.dgvQuoteOrderMaster.TabIndex = 24;
            this.dgvQuoteOrderMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuoteOrderMaster_CellClick);
            // 
            // dgvQuoteOrderDetail
            // 
            this.dgvQuoteOrderDetail.AllowUserToAddRows = false;
            this.dgvQuoteOrderDetail.AllowUserToDeleteRows = false;
            this.dgvQuoteOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuoteOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuoteOrderDetail.Location = new System.Drawing.Point(13, 240);
            this.dgvQuoteOrderDetail.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvQuoteOrderDetail.Name = "dgvQuoteOrderDetail";
            this.dgvQuoteOrderDetail.ReadOnly = true;
            this.dgvQuoteOrderDetail.RowHeadersVisible = false;
            this.dgvQuoteOrderDetail.RowTemplate.Height = 27;
            this.dgvQuoteOrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuoteOrderDetail.Size = new System.Drawing.Size(753, 200);
            this.dgvQuoteOrderDetail.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(258, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 18);
            this.label2.TabIndex = 89;
            this.label2.Text = "To";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEnd.CustomFormat = "yyyy/MM/dd 23:59";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(298, 198);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 34);
            this.dtpEnd.TabIndex = 88;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStart.CustomFormat = "yyyy/MM/dd";
            this.dtpStart.Enabled = false;
            this.dtpStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(103, 198);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 34);
            this.dtpStart.TabIndex = 87;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(463, 194);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(113, 36);
            this.btnQuery.TabIndex = 90;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfirm.Location = new System.Drawing.Point(632, 194);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(113, 36);
            this.btnConfirm.TabIndex = 91;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkIsQueryDate
            // 
            this.chkIsQueryDate.AutoSize = true;
            this.chkIsQueryDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkIsQueryDate.Location = new System.Drawing.Point(19, 200);
            this.chkIsQueryDate.Name = "chkIsQueryDate";
            this.chkIsQueryDate.Size = new System.Drawing.Size(78, 29);
            this.chkIsQueryDate.TabIndex = 92;
            this.chkIsQueryDate.Text = "Date";
            this.chkIsQueryDate.UseVisualStyleBackColor = true;
            this.chkIsQueryDate.CheckedChanged += new System.EventHandler(this.chkIsQueryDate_CheckedChanged);
            // 
            // QOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 448);
            this.Controls.Add(this.chkIsQueryDate);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgvQuoteOrderDetail);
            this.Controls.Add(this.dgvQuoteOrderMaster);
            this.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuoteOrderConfirm";
            this.Load += new System.EventHandler(this.QOC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuoteOrderMaster;
        private System.Windows.Forms.DataGridView dgvQuoteOrderDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox chkIsQueryDate;
    }
}