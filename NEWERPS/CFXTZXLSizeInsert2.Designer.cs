namespace NEWERPS
{
    partial class CFXTZXLSizeInsert2
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
            this.L0001 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(176, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(44, 90);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(64, 25);
            this.L0001.TabIndex = 1;
            this.L0001.Text = "XXCC";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(163, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 34);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(163, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 34);
            this.textBox2.TabIndex = 4;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(44, 158);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(61, 25);
            this.L0002.TabIndex = 3;
            this.L0002.Text = "GJCC";
            // 
            // L0003
            // 
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(152, 220);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(105, 44);
            this.L0003.TabIndex = 5;
            this.L0003.Text = "SAVE";
            this.L0003.UseVisualStyleBackColor = true;
            this.L0003.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(338, 250);
            this.dgvWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowHeadersWidth = 62;
            this.dgvWord.RowTemplate.Height = 31;
            this.dgvWord.Size = new System.Drawing.Size(37, 27);
            this.dgvWord.TabIndex = 96;
            this.dgvWord.Visible = false;
            // 
            // CFXTZXLSizeInsert2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 288);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.L0001);
            this.Controls.Add(this.label1);
            this.Name = "CFXTZXLSizeInsert2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFXTZXLSizeInsert2";
            this.Load += new System.EventHandler(this.CFXTZXLSizeInsert2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Button L0003;
        private System.Windows.Forms.DataGridView dgvWord;
    }
}