namespace NEWERPS
{
    partial class MSSD
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
            this.tbSize = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tbQTY = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbNonAmortization = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSize
            // 
            this.tbSize.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSize.Location = new System.Drawing.Point(172, 22);
            this.tbSize.MaxLength = 4;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(127, 34);
            this.tbSize.TabIndex = 52;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(12, 32);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(36, 18);
            this.L0001.TabIndex = 53;
            this.L0001.Text = "尺寸";
            // 
            // tbQTY
            // 
            this.tbQTY.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbQTY.Location = new System.Drawing.Point(172, 82);
            this.tbQTY.MaxLength = 4;
            this.tbQTY.Name = "tbQTY";
            this.tbQTY.Size = new System.Drawing.Size(127, 34);
            this.tbQTY.TabIndex = 54;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(12, 92);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(36, 18);
            this.L0002.TabIndex = 55;
            this.L0002.Text = "數量";
            // 
            // tbNonAmortization
            // 
            this.tbNonAmortization.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbNonAmortization.Location = new System.Drawing.Point(172, 142);
            this.tbNonAmortization.MaxLength = 4;
            this.tbNonAmortization.Name = "tbNonAmortization";
            this.tbNonAmortization.Size = new System.Drawing.Size(127, 34);
            this.tbNonAmortization.TabIndex = 56;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(12, 152);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(50, 18);
            this.L0003.TabIndex = 57;
            this.L0003.Text = "不攤數";
            // 
            // tbRemark
            // 
            this.tbRemark.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbRemark.Location = new System.Drawing.Point(172, 202);
            this.tbRemark.MaxLength = 4;
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(127, 67);
            this.tbRemark.TabIndex = 58;
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(12, 212);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(36, 18);
            this.L0004.TabIndex = 59;
            this.L0004.Text = "備註";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 45);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(301, 321);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 61;
            this.dgvWord.Visible = false;
            // 
            // MoldSetSizeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 372);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.tbNonAmortization);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbQTY);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.L0001);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoldSetSizeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoldSetSizeDetail";
            this.Load += new System.EventHandler(this.MoldSetSizeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbQTY;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbNonAmortization;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}