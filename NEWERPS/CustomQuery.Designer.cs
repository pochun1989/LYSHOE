namespace NEWERPS
{
    partial class CustomQuery
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
            this.L0002 = new System.Windows.Forms.Label();
            this.tb全稱 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tb代號 = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tb簡稱 = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.tb編號 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(122, 130);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(92, 25);
            this.L0002.TabIndex = 51;
            this.L0002.Text = "客戶全稱";
            // 
            // tb全稱
            // 
            this.tb全稱.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb全稱.Location = new System.Drawing.Point(231, 126);
            this.tb全稱.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb全稱.Name = "tb全稱";
            this.tb全稱.Size = new System.Drawing.Size(147, 34);
            this.tb全稱.TabIndex = 52;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(122, 46);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(92, 25);
            this.L0001.TabIndex = 49;
            this.L0001.Text = "客戶代號";
            // 
            // tb代號
            // 
            this.tb代號.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb代號.Location = new System.Drawing.Point(231, 42);
            this.tb代號.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb代號.Name = "tb代號";
            this.tb代號.Size = new System.Drawing.Size(147, 34);
            this.tb代號.TabIndex = 50;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(122, 221);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(92, 25);
            this.L0003.TabIndex = 95;
            this.L0003.Text = "客戶簡稱";
            // 
            // tb簡稱
            // 
            this.tb簡稱.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb簡稱.Location = new System.Drawing.Point(231, 217);
            this.tb簡稱.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb簡稱.Name = "tb簡稱";
            this.tb簡稱.Size = new System.Drawing.Size(147, 34);
            this.tb簡稱.TabIndex = 96;
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(122, 299);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(92, 25);
            this.L0004.TabIndex = 97;
            this.L0004.Text = "對應編號";
            // 
            // tb編號
            // 
            this.tb編號.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb編號.Location = new System.Drawing.Point(231, 294);
            this.tb編號.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb編號.MaxLength = 2;
            this.tb編號.Name = "tb編號";
            this.tb編號.Size = new System.Drawing.Size(147, 34);
            this.tb編號.TabIndex = 98;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(193, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 48);
            this.button1.TabIndex = 99;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(460, 411);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 100;
            this.dgvWord.Visible = false;
            // 
            // CustomQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.tb編號);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tb簡稱);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.tb全稱);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.tb代號);
            this.Name = "CustomQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomQuery";
            this.Load += new System.EventHandler(this.CustomQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tb全稱;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tb代號;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tb簡稱;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.TextBox tb編號;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}