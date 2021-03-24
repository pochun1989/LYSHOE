namespace NEWERPS
{
    partial class MaterialCSD
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
            this.L0001 = new System.Windows.Forms.Label();
            this.tbClass = new System.Windows.Forms.TextBox();
            this.tbClassNameCN = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbClassNameEN = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.lbMCSD = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(35, 104);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(36, 18);
            this.L0001.TabIndex = 0;
            this.L0001.Text = "代號";
            // 
            // tbClass
            // 
            this.tbClass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbClass.Location = new System.Drawing.Point(241, 94);
            this.tbClass.Name = "tbClass";
            this.tbClass.Size = new System.Drawing.Size(100, 34);
            this.tbClass.TabIndex = 1;
            // 
            // tbClassNameCN
            // 
            this.tbClassNameCN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbClassNameCN.Location = new System.Drawing.Point(241, 154);
            this.tbClassNameCN.MaxLength = 50;
            this.tbClassNameCN.Name = "tbClassNameCN";
            this.tbClassNameCN.Size = new System.Drawing.Size(419, 34);
            this.tbClassNameCN.TabIndex = 3;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(35, 164);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 2;
            this.L0002.Text = "中文說明";
            // 
            // tbClassNameEN
            // 
            this.tbClassNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbClassNameEN.Location = new System.Drawing.Point(241, 214);
            this.tbClassNameEN.MaxLength = 50;
            this.tbClassNameEN.Name = "tbClassNameEN";
            this.tbClassNameEN.Size = new System.Drawing.Size(419, 34);
            this.tbClassNameEN.TabIndex = 5;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(35, 224);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 4;
            this.L0003.Text = "英文說明";
            // 
            // lbMCSD
            // 
            this.lbMCSD.AutoSize = true;
            this.lbMCSD.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbMCSD.Location = new System.Drawing.Point(45, 32);
            this.lbMCSD.Name = "lbMCSD";
            this.lbMCSD.Size = new System.Drawing.Size(0, 25);
            this.lbMCSD.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(189, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 46);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(417, 280);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 46);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(660, 317);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(48, 39);
            this.dgvWord.TabIndex = 25;
            this.dgvWord.Visible = false;
            // 
            // MaterialClassSetDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 368);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbMCSD);
            this.Controls.Add(this.tbClassNameEN);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbClassNameCN);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tbClass);
            this.Controls.Add(this.L0001);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialClassSetDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaterialClassSetDetail";
            this.Load += new System.EventHandler(this.MaterialClassSetDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.TextBox tbClassNameCN;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbClassNameEN;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label lbMCSD;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}