namespace NEWERPS
{
    partial class TempQuery
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
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.tbME = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.tbMC = new System.Windows.Forms.TextBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.tbDDBH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(375, 141);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(327, 33);
            this.cbClass.TabIndex = 3;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(152, 151);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(41, 18);
            this.L0001.TabIndex = 2;
            this.L0001.Text = "Class";
            // 
            // tbME
            // 
            this.tbME.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbME.Location = new System.Drawing.Point(375, 275);
            this.tbME.Name = "tbME";
            this.tbME.Size = new System.Drawing.Size(327, 34);
            this.tbME.TabIndex = 10;
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(152, 285);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(117, 18);
            this.L0003.TabIndex = 9;
            this.L0003.Text = "Material English";
            // 
            // tbMC
            // 
            this.tbMC.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMC.Location = new System.Drawing.Point(375, 207);
            this.tbMC.Name = "tbMC";
            this.tbMC.Size = new System.Drawing.Size(327, 34);
            this.tbMC.TabIndex = 8;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(152, 217);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(121, 18);
            this.L0002.TabIndex = 7;
            this.L0002.Text = "Material Chinese";
            // 
            // tbDDBH
            // 
            this.tbDDBH.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDDBH.Location = new System.Drawing.Point(375, 80);
            this.tbDDBH.Name = "tbDDBH";
            this.tbDDBH.Size = new System.Drawing.Size(327, 34);
            this.tbDDBH.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(152, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "TempDDBH";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(316, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 56);
            this.button1.TabIndex = 15;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TempQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbDDBH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbME);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.tbMC);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.L0001);
            this.Name = "TempQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempQuery";
            this.Load += new System.EventHandler(this.TempQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbME;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.TextBox tbMC;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.TextBox tbDDBH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}