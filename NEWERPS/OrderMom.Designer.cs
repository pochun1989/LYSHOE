namespace NEWERPS
{
    partial class OrderMom
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
            this.textbox2 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0004 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox2
            // 
            this.textbox2.Enabled = false;
            this.textbox2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textbox2.Location = new System.Drawing.Point(208, 92);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(193, 34);
            this.textbox2.TabIndex = 78;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(61, 95);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(52, 25);
            this.L0002.TabIndex = 77;
            this.L0002.Text = "色號";
            // 
            // L0004
            // 
            this.L0004.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(171, 210);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(98, 44);
            this.L0004.TabIndex = 79;
            this.L0004.Text = "SAVE";
            this.L0004.UseVisualStyleBackColor = true;
            this.L0004.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(208, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 34);
            this.textBox1.TabIndex = 81;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(61, 42);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(52, 25);
            this.L0001.TabIndex = 80;
            this.L0001.Text = "型體";
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(61, 148);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(72, 25);
            this.L0003.TabIndex = 82;
            this.L0003.Text = "母訂單";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(208, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 33);
            this.comboBox1.TabIndex = 83;
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(387, 241);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 28);
            this.dgvWord.TabIndex = 96;
            this.dgvWord.Visible = false;
            // 
            // OrderMom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 280);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.L0002);
            this.Name = "OrderMom";
            this.Text = "OrderMom";
            this.Load += new System.EventHandler(this.OrderMom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Button L0004;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textbox2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}