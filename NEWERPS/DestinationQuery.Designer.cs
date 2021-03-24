namespace NEWERPS
{
    partial class DestinationQuery
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
            this.tb英文 = new System.Windows.Forms.TextBox();
            this.tb中文 = new System.Windows.Forms.TextBox();
            this.tb代號 = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tb英文
            // 
            this.tb英文.Location = new System.Drawing.Point(267, 218);
            this.tb英文.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb英文.Name = "tb英文";
            this.tb英文.Size = new System.Drawing.Size(277, 25);
            this.tb英文.TabIndex = 139;
            this.tb英文.TextChanged += new System.EventHandler(this.tb英文_TextChanged);
            // 
            // tb中文
            // 
            this.tb中文.Location = new System.Drawing.Point(267, 131);
            this.tb中文.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb中文.Name = "tb中文";
            this.tb中文.Size = new System.Drawing.Size(277, 25);
            this.tb中文.TabIndex = 138;
            this.tb中文.TextChanged += new System.EventHandler(this.tb中文_TextChanged);
            // 
            // tb代號
            // 
            this.tb代號.Location = new System.Drawing.Point(267, 49);
            this.tb代號.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb代號.Name = "tb代號";
            this.tb代號.Size = new System.Drawing.Size(277, 25);
            this.tb代號.TabIndex = 137;
            this.tb代號.TextChanged += new System.EventHandler(this.tb代號_TextChanged);
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Location = new System.Drawing.Point(49, 221);
            this.L0003.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(67, 15);
            this.L0003.TabIndex = 136;
            this.L0003.Text = "英文說明";
            this.L0003.Click += new System.EventHandler(this.L0003_Click);
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Location = new System.Drawing.Point(49, 139);
            this.L0002.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(67, 15);
            this.L0002.TabIndex = 135;
            this.L0002.Text = "中文說明";
            this.L0002.Click += new System.EventHandler(this.L0002_Click);
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Location = new System.Drawing.Point(49, 56);
            this.L0001.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(37, 15);
            this.L0001.TabIndex = 134;
            this.L0001.Text = "代號";
            this.L0001.Click += new System.EventHandler(this.L0001_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(221, 275);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 42);
            this.button1.TabIndex = 141;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(528, 289);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 142;
            this.dgvWord.Visible = false;
            // 
            // DestinationQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 348);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb英文);
            this.Controls.Add(this.tb中文);
            this.Controls.Add(this.tb代號);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0001);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DestinationQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DestinationQuery";
            this.Load += new System.EventHandler(this.DestinationQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb英文;
        private System.Windows.Forms.TextBox tb中文;
        private System.Windows.Forms.TextBox tb代號;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}