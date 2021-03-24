namespace NEWERPS
{
    partial class MMIDM
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
            this.tbUsage = new System.Windows.Forms.TextBox();
            this.cbSupplierVendor = new System.Windows.Forms.ComboBox();
            this.L0007 = new System.Windows.Forms.Label();
            this.L0005 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUsage
            // 
            this.tbUsage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbUsage.Location = new System.Drawing.Point(80, 31);
            this.tbUsage.Name = "tbUsage";
            this.tbUsage.Size = new System.Drawing.Size(110, 34);
            this.tbUsage.TabIndex = 196;
            // 
            // cbSupplierVendor
            // 
            this.cbSupplierVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierVendor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbSupplierVendor.FormattingEnabled = true;
            this.cbSupplierVendor.IntegralHeight = false;
            this.cbSupplierVendor.Location = new System.Drawing.Point(273, 31);
            this.cbSupplierVendor.MaxDropDownItems = 12;
            this.cbSupplierVendor.Name = "cbSupplierVendor";
            this.cbSupplierVendor.Size = new System.Drawing.Size(165, 33);
            this.cbSupplierVendor.TabIndex = 197;
            // 
            // L0007
            // 
            this.L0007.AutoSize = true;
            this.L0007.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0007.Location = new System.Drawing.Point(210, 41);
            this.L0007.Name = "L0007";
            this.L0007.Size = new System.Drawing.Size(57, 18);
            this.L0007.TabIndex = 199;
            this.L0007.Text = "Vendor";
            // 
            // L0005
            // 
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(24, 41);
            this.L0005.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(49, 18);
            this.L0005.TabIndex = 198;
            this.L0005.Text = "Usage";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(476, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 40);
            this.btnSave.TabIndex = 200;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MMIDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 106);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbUsage);
            this.Controls.Add(this.cbSupplierVendor);
            this.Controls.Add(this.L0007);
            this.Controls.Add(this.L0005);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MMIDM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMIDM";
            this.Load += new System.EventHandler(this.MMIDM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsage;
        private System.Windows.Forms.ComboBox cbSupplierVendor;
        private System.Windows.Forms.Label L0007;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.Button btnSave;
    }
}