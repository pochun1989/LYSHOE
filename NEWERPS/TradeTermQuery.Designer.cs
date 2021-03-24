namespace NEWERPS
{
    partial class TradeTermQuery
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
            this.button1 = new System.Windows.Forms.Button();
            this.tb英文 = new System.Windows.Forms.TextBox();
            this.tb中文 = new System.Windows.Forms.TextBox();
            this.tb代號 = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(208, 340);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 42);
            this.button1.TabIndex = 147;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb英文
            // 
            this.tb英文.Location = new System.Drawing.Point(208, 249);
            this.tb英文.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb英文.Name = "tb英文";
            this.tb英文.Size = new System.Drawing.Size(277, 25);
            this.tb英文.TabIndex = 146;
            // 
            // tb中文
            // 
            this.tb中文.Location = new System.Drawing.Point(208, 166);
            this.tb中文.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb中文.Name = "tb中文";
            this.tb中文.Size = new System.Drawing.Size(277, 25);
            this.tb中文.TabIndex = 145;
            // 
            // tb代號
            // 
            this.tb代號.Location = new System.Drawing.Point(208, 84);
            this.tb代號.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb代號.Name = "tb代號";
            this.tb代號.Size = new System.Drawing.Size(277, 25);
            this.tb代號.TabIndex = 144;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Location = new System.Drawing.Point(40, 252);
            this.L0003.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(67, 15);
            this.L0003.TabIndex = 143;
            this.L0003.Text = "英文說明";
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Location = new System.Drawing.Point(40, 170);
            this.L0002.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(67, 15);
            this.L0002.TabIndex = 142;
            this.L0002.Text = "中文說明";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Location = new System.Drawing.Point(40, 88);
            this.L0001.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(37, 15);
            this.L0001.TabIndex = 141;
            this.L0001.Text = "代號";
            // 
            // TradeTermQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 432);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb英文);
            this.Controls.Add(this.tb中文);
            this.Controls.Add(this.tb代號);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0001);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TradeTermQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TradeTermQuery";
            this.Load += new System.EventHandler(this.TradeTermQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb英文;
        private System.Windows.Forms.TextBox tb中文;
        private System.Windows.Forms.TextBox tb代號;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
    }
}