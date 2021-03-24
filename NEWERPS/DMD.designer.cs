namespace NEWERPS
{
    partial class DMD
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbShoeModel = new System.Windows.Forms.TextBox();
            this.tbColorNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(207, 263);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 56;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbShoeModel
            // 
            this.tbShoeModel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShoeModel.Location = new System.Drawing.Point(197, 56);
            this.tbShoeModel.MaxLength = 200;
            this.tbShoeModel.Name = "tbShoeModel";
            this.tbShoeModel.Size = new System.Drawing.Size(284, 34);
            this.tbShoeModel.TabIndex = 50;
            // 
            // tbColorNo
            // 
            this.tbColorNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbColorNo.Location = new System.Drawing.Point(197, 158);
            this.tbColorNo.MaxLength = 200;
            this.tbColorNo.Name = "tbColorNo";
            this.tbColorNo.Size = new System.Drawing.Size(284, 34);
            this.tbColorNo.TabIndex = 51;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(34, 66);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(36, 18);
            this.L0001.TabIndex = 53;
            this.L0001.Text = "鞋型";
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(34, 168);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(36, 18);
            this.L0002.TabIndex = 54;
            this.L0002.Text = "色號";
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(483, 310);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 57;
            this.dgvWord.Visible = false;
            // 
            // DevelopModelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 361);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbShoeModel);
            this.Controls.Add(this.tbColorNo);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.L0002);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevelopModelDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevelopModelDetail";
            this.Load += new System.EventHandler(this.DevelopModelDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox tbShoeModel;
        private System.Windows.Forms.TextBox tbColorNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}