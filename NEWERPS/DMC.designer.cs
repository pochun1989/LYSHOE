namespace NEWERPS
{
    partial class DMC
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
            this.tbColorNo = new System.Windows.Forms.TextBox();
            this.L0019 = new System.Windows.Forms.Label();
            this.tbShoeModelNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOldColor = new System.Windows.Forms.TextBox();
            this.tbOldModel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbColorNo
            // 
            this.tbColorNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbColorNo.Location = new System.Drawing.Point(468, 99);
            this.tbColorNo.MaxLength = 50;
            this.tbColorNo.Name = "tbColorNo";
            this.tbColorNo.Size = new System.Drawing.Size(151, 34);
            this.tbColorNo.TabIndex = 51;
            // 
            // L0019
            // 
            this.L0019.AutoSize = true;
            this.L0019.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0019.Location = new System.Drawing.Point(320, 109);
            this.L0019.Name = "L0019";
            this.L0019.Size = new System.Drawing.Size(78, 18);
            this.L0019.TabIndex = 50;
            this.L0019.Text = "New Color";
            // 
            // tbShoeModelNo
            // 
            this.tbShoeModelNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShoeModelNo.Location = new System.Drawing.Point(152, 99);
            this.tbShoeModelNo.Name = "tbShoeModelNo";
            this.tbShoeModelNo.Size = new System.Drawing.Size(140, 34);
            this.tbShoeModelNo.TabIndex = 49;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(12, 109);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(86, 18);
            this.L0001.TabIndex = 48;
            this.L0001.Text = "New Model";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCopy.Location = new System.Drawing.Point(136, 188);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(113, 43);
            this.btnCopy.TabIndex = 52;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(349, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 43);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(320, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "Old Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 54;
            this.label2.Text = "Old Model";
            // 
            // tbOldColor
            // 
            this.tbOldColor.Enabled = false;
            this.tbOldColor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOldColor.Location = new System.Drawing.Point(468, 29);
            this.tbOldColor.MaxLength = 50;
            this.tbOldColor.Name = "tbOldColor";
            this.tbOldColor.Size = new System.Drawing.Size(151, 34);
            this.tbOldColor.TabIndex = 57;
            // 
            // tbOldModel
            // 
            this.tbOldModel.Enabled = false;
            this.tbOldModel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbOldModel.Location = new System.Drawing.Point(152, 29);
            this.tbOldModel.Name = "tbOldModel";
            this.tbOldModel.Size = new System.Drawing.Size(140, 34);
            this.tbOldModel.TabIndex = 56;
            // 
            // DevelopModelCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 276);
            this.Controls.Add(this.tbOldColor);
            this.Controls.Add(this.tbOldModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbColorNo);
            this.Controls.Add(this.L0019);
            this.Controls.Add(this.tbShoeModelNo);
            this.Controls.Add(this.L0001);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevelopModelCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevelopModelCopy";
            this.Load += new System.EventHandler(this.DevelopModelCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbColorNo;
        private System.Windows.Forms.Label L0019;
        private System.Windows.Forms.TextBox tbShoeModelNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOldColor;
        private System.Windows.Forms.TextBox tbOldModel;
    }
}