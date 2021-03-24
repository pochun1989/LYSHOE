namespace NEWERPS
{
    partial class CardboardQuery
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.cb底模 = new System.Windows.Forms.ComboBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.cb楦頭 = new System.Windows.Forms.ComboBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.cb品牌 = new System.Windows.Forms.ComboBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(233, 206);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 29);
            this.textBox1.TabIndex = 15;
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(122, 214);
            this.L0004.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(51, 15);
            this.L0004.TabIndex = 14;
            this.L0004.Text = "紙板名稱";
            // 
            // cb底模
            // 
            this.cb底模.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb底模.FormattingEnabled = true;
            this.cb底模.Location = new System.Drawing.Point(233, 154);
            this.cb底模.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb底模.Name = "cb底模";
            this.cb底模.Size = new System.Drawing.Size(158, 28);
            this.cb底模.TabIndex = 13;
            this.cb底模.Visible = false;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(122, 162);
            this.L0003.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(40, 15);
            this.L0003.TabIndex = 12;
            this.L0003.Text = "大底模";
            // 
            // cb楦頭
            // 
            this.cb楦頭.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb楦頭.FormattingEnabled = true;
            this.cb楦頭.Location = new System.Drawing.Point(233, 101);
            this.cb楦頭.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb楦頭.Name = "cb楦頭";
            this.cb楦頭.Size = new System.Drawing.Size(158, 28);
            this.cb楦頭.TabIndex = 11;
            this.cb楦頭.Visible = false;
            this.cb楦頭.SelectedIndexChanged += new System.EventHandler(this.cb楦頭_SelectedIndexChanged);
            this.cb楦頭.Click += new System.EventHandler(this.cb楦頭_Click);
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(122, 109);
            this.L0002.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(29, 15);
            this.L0002.TabIndex = 10;
            this.L0002.Text = "楦頭";
            // 
            // cb品牌
            // 
            this.cb品牌.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb品牌.FormattingEnabled = true;
            this.cb品牌.Location = new System.Drawing.Point(233, 48);
            this.cb品牌.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb品牌.Name = "cb品牌";
            this.cb品牌.Size = new System.Drawing.Size(158, 28);
            this.cb品牌.TabIndex = 9;
            this.cb品牌.SelectedIndexChanged += new System.EventHandler(this.cb品牌_SelectedIndexChanged);
            this.cb品牌.Click += new System.EventHandler(this.cb品牌_Click);
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(122, 56);
            this.L0001.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(29, 15);
            this.L0001.TabIndex = 8;
            this.L0001.Text = "品牌";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(189, 261);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "QUERY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(459, 293);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(28, 22);
            this.dgvWord.TabIndex = 101;
            this.dgvWord.Visible = false;
            // 
            // CardboardQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 324);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.cb底模);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.cb楦頭);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.cb品牌);
            this.Controls.Add(this.L0001);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CardboardQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CardboardQuery";
            this.Load += new System.EventHandler(this.CardboardQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.ComboBox cb底模;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.ComboBox cb楦頭;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.ComboBox cb品牌;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}