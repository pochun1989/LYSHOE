namespace NEWERPS
{
    partial class SOSM
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvShowModel = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.tbShoeModel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowModel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(323, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ShoeModel";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(687, 30);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 59;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvShowModel
            // 
            this.dgvShowModel.AllowUserToAddRows = false;
            this.dgvShowModel.AllowUserToDeleteRows = false;
            this.dgvShowModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowModel.Location = new System.Drawing.Point(13, 87);
            this.dgvShowModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvShowModel.Name = "dgvShowModel";
            this.dgvShowModel.ReadOnly = true;
            this.dgvShowModel.RowTemplate.Height = 27;
            this.dgvShowModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowModel.Size = new System.Drawing.Size(851, 349);
            this.dgvShowModel.TabIndex = 60;
            this.dgvShowModel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowModel_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(25, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 62;
            this.label2.Text = "Brand";
            // 
            // cbBrand
            // 
            this.cbBrand.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.IntegralHeight = false;
            this.cbBrand.Location = new System.Drawing.Point(98, 36);
            this.cbBrand.MaxDropDownItems = 15;
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(197, 33);
            this.cbBrand.TabIndex = 61;
            // 
            // tbShoeModel
            // 
            this.tbShoeModel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShoeModel.Location = new System.Drawing.Point(449, 36);
            this.tbShoeModel.Name = "tbShoeModel";
            this.tbShoeModel.Size = new System.Drawing.Size(197, 34);
            this.tbShoeModel.TabIndex = 63;
            // 
            // SOSM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.tbShoeModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.dgvShowModel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SOSM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SampleOrderShoeModel";
            this.Load += new System.EventHandler(this.SampleOrderShoeModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvShowModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.TextBox tbShoeModel;
    }
}