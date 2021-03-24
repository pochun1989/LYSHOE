namespace NEWERPS
{
    partial class OrderSizeInsert
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
            this.tbDDBH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLineNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSample = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDDBH
            // 
            this.tbDDBH.Enabled = false;
            this.tbDDBH.Location = new System.Drawing.Point(208, 32);
            this.tbDDBH.Name = "tbDDBH";
            this.tbDDBH.Size = new System.Drawing.Size(239, 34);
            this.tbDDBH.TabIndex = 191;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 25);
            this.label8.TabIndex = 190;
            this.label8.Text = "DDBH";
            // 
            // tbLineNum
            // 
            this.tbLineNum.Enabled = false;
            this.tbLineNum.Location = new System.Drawing.Point(208, 96);
            this.tbLineNum.Name = "tbLineNum";
            this.tbLineNum.Size = new System.Drawing.Size(239, 34);
            this.tbLineNum.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 192;
            this.label1.Text = "LineNum";
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(208, 160);
            this.tbCC.Name = "tbCC";
            this.tbCC.Size = new System.Drawing.Size(239, 34);
            this.tbCC.TabIndex = 195;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 25);
            this.label2.TabIndex = 194;
            this.label2.Text = "CC";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(208, 288);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(239, 34);
            this.tbQuantity.TabIndex = 197;
            this.tbQuantity.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 196;
            this.label3.Text = "Quantity";
            // 
            // tbSample
            // 
            this.tbSample.Location = new System.Drawing.Point(208, 352);
            this.tbSample.Name = "tbSample";
            this.tbSample.Size = new System.Drawing.Size(239, 34);
            this.tbSample.TabIndex = 199;
            this.tbSample.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 198;
            this.label4.Text = "Sample";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 51);
            this.button1.TabIndex = 200;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(208, 224);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(239, 34);
            this.tbPrice.TabIndex = 202;
            this.tbPrice.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 201;
            this.label5.Text = "IPrice";
            // 
            // OrderSizeInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 486);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLineNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDDBH);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OrderSizeInsert";
            this.Text = "OrderSizeInsert";
            this.Load += new System.EventHandler(this.OrderSizeInsert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSample;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox tbDDBH;
        internal System.Windows.Forms.TextBox tbLineNum;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
    }
}