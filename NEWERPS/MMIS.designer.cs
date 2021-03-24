namespace NEWERPS
{
    partial class MMIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMIS));
            this.tbDeliveryDate = new System.Windows.Forms.TextBox();
            this.L0003 = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.L0006 = new System.Windows.Forms.Label();
            this.tbSmallPackagingWeight = new System.Windows.Forms.TextBox();
            this.L0005 = new System.Windows.Forms.Label();
            this.tbSmallPackaging = new System.Windows.Forms.TextBox();
            this.L0004 = new System.Windows.Forms.Label();
            this.tbMOQS = new System.Windows.Forms.TextBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancelClient = new System.Windows.Forms.Button();
            this.dgvWord = new System.Windows.Forms.DataGridView();
            this.tbHighPurchQTYS = new System.Windows.Forms.TextBox();
            this.L0007 = new System.Windows.Forms.Label();
            this.L0009 = new System.Windows.Forms.Label();
            this.tbHighStockS = new System.Windows.Forms.TextBox();
            this.tbLowStockS = new System.Windows.Forms.TextBox();
            this.L0008 = new System.Windows.Forms.Label();
            this.cbCQDH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDeliveryDate
            // 
            this.tbDeliveryDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDeliveryDate.Location = new System.Drawing.Point(763, 120);
            this.tbDeliveryDate.Name = "tbDeliveryDate";
            this.tbDeliveryDate.Size = new System.Drawing.Size(110, 34);
            this.tbDeliveryDate.TabIndex = 224;
            this.tbDeliveryDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDeliveryDate_KeyPress);
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(465, 130);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(64, 18);
            this.L0003.TabIndex = 223;
            this.L0003.Text = "交貨天數";
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.Transparent;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClient.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClient.Location = new System.Drawing.Point(468, 74);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(108, 32);
            this.btnClient.TabIndex = 208;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // L0006
            // 
            this.L0006.AutoSize = true;
            this.L0006.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0006.Location = new System.Drawing.Point(465, 280);
            this.L0006.Name = "L0006";
            this.L0006.Size = new System.Drawing.Size(120, 18);
            this.L0006.TabIndex = 222;
            this.L0006.Text = "最小包裝單位重量";
            // 
            // tbSmallPackagingWeight
            // 
            this.tbSmallPackagingWeight.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSmallPackagingWeight.Location = new System.Drawing.Point(763, 270);
            this.tbSmallPackagingWeight.Name = "tbSmallPackagingWeight";
            this.tbSmallPackagingWeight.Size = new System.Drawing.Size(110, 34);
            this.tbSmallPackagingWeight.TabIndex = 215;
            // 
            // L0005
            // 
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(465, 230);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(78, 18);
            this.L0005.TabIndex = 221;
            this.L0005.Text = "最小包裝量";
            // 
            // tbSmallPackaging
            // 
            this.tbSmallPackaging.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSmallPackaging.Location = new System.Drawing.Point(763, 220);
            this.tbSmallPackaging.Name = "tbSmallPackaging";
            this.tbSmallPackaging.Size = new System.Drawing.Size(110, 34);
            this.tbSmallPackaging.TabIndex = 214;
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(465, 180);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(64, 18);
            this.L0004.TabIndex = 217;
            this.L0004.Text = "最低購量";
            // 
            // tbMOQS
            // 
            this.tbMOQS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMOQS.Location = new System.Drawing.Point(763, 170);
            this.tbMOQS.Name = "tbMOQS";
            this.tbMOQS.Size = new System.Drawing.Size(110, 34);
            this.tbMOQS.TabIndex = 213;
            // 
            // cbUnit
            // 
            this.cbUnit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.IntegralHeight = false;
            this.cbUnit.Location = new System.Drawing.Point(235, 70);
            this.cbUnit.MaxDropDownItems = 12;
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(204, 33);
            this.cbUnit.TabIndex = 212;
            // 
            // cbClient
            // 
            this.cbClient.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClient.FormattingEnabled = true;
            this.cbClient.IntegralHeight = false;
            this.cbClient.Location = new System.Drawing.Point(669, 75);
            this.cbClient.MaxDropDownItems = 12;
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(204, 33);
            this.cbClient.TabIndex = 210;
            // 
            // cbVendor
            // 
            this.cbVendor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.IntegralHeight = false;
            this.cbVendor.Location = new System.Drawing.Point(152, 20);
            this.cbVendor.MaxDropDownItems = 12;
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(287, 33);
            this.cbVendor.TabIndex = 211;
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(29, 80);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(64, 18);
            this.L0002.TabIndex = 219;
            this.L0002.Text = "採購單位";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(29, 30);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(36, 18);
            this.L0001.TabIndex = 218;
            this.L0001.Text = "廠商";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(789, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 45);
            this.btnSave.TabIndex = 225;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(669, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 45);
            this.btnExit.TabIndex = 226;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancelClient
            // 
            this.btnCancelClient.BackColor = System.Drawing.Color.White;
            this.btnCancelClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelClient.BackgroundImage")));
            this.btnCancelClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelClient.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancelClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelClient.Location = new System.Drawing.Point(582, 73);
            this.btnCancelClient.Name = "btnCancelClient";
            this.btnCancelClient.Size = new System.Drawing.Size(34, 34);
            this.btnCancelClient.TabIndex = 228;
            this.btnCancelClient.UseVisualStyleBackColor = false;
            this.btnCancelClient.Click += new System.EventHandler(this.btnCancelClient_Click);
            // 
            // dgvWord
            // 
            this.dgvWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWord.Location = new System.Drawing.Point(883, 241);
            this.dgvWord.Name = "dgvWord";
            this.dgvWord.RowTemplate.Height = 27;
            this.dgvWord.Size = new System.Drawing.Size(51, 39);
            this.dgvWord.TabIndex = 229;
            this.dgvWord.Visible = false;
            // 
            // tbHighPurchQTYS
            // 
            this.tbHighPurchQTYS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbHighPurchQTYS.Location = new System.Drawing.Point(329, 270);
            this.tbHighPurchQTYS.Name = "tbHighPurchQTYS";
            this.tbHighPurchQTYS.Size = new System.Drawing.Size(110, 34);
            this.tbHighPurchQTYS.TabIndex = 233;
            // 
            // L0007
            // 
            this.L0007.AutoSize = true;
            this.L0007.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0007.Location = new System.Drawing.Point(29, 180);
            this.L0007.Name = "L0007";
            this.L0007.Size = new System.Drawing.Size(64, 18);
            this.L0007.TabIndex = 231;
            this.L0007.Text = "高標存量";
            // 
            // L0009
            // 
            this.L0009.AutoSize = true;
            this.L0009.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0009.Location = new System.Drawing.Point(29, 280);
            this.L0009.Name = "L0009";
            this.L0009.Size = new System.Drawing.Size(78, 18);
            this.L0009.TabIndex = 235;
            this.L0009.Text = "最大採購量";
            // 
            // tbHighStockS
            // 
            this.tbHighStockS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbHighStockS.Location = new System.Drawing.Point(329, 170);
            this.tbHighStockS.Name = "tbHighStockS";
            this.tbHighStockS.Size = new System.Drawing.Size(110, 34);
            this.tbHighStockS.TabIndex = 230;
            // 
            // tbLowStockS
            // 
            this.tbLowStockS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbLowStockS.Location = new System.Drawing.Point(329, 220);
            this.tbLowStockS.Name = "tbLowStockS";
            this.tbLowStockS.Size = new System.Drawing.Size(110, 34);
            this.tbLowStockS.TabIndex = 232;
            // 
            // L0008
            // 
            this.L0008.AutoSize = true;
            this.L0008.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0008.Location = new System.Drawing.Point(29, 230);
            this.L0008.Name = "L0008";
            this.L0008.Size = new System.Drawing.Size(64, 18);
            this.L0008.TabIndex = 234;
            this.L0008.Text = "低標存量";
            // 
            // cbCQDH
            // 
            this.cbCQDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCQDH.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbCQDH.FormattingEnabled = true;
            this.cbCQDH.IntegralHeight = false;
            this.cbCQDH.Items.AddRange(new object[] {
            "TW",
            "CN",
            "VN"});
            this.cbCQDH.Location = new System.Drawing.Point(329, 120);
            this.cbCQDH.MaxDropDownItems = 10;
            this.cbCQDH.Name = "cbCQDH";
            this.cbCQDH.Size = new System.Drawing.Size(110, 33);
            this.cbCQDH.TabIndex = 237;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(29, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 236;
            this.label5.Text = "CQDH";
            // 
            // MMIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 347);
            this.Controls.Add(this.cbCQDH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbHighPurchQTYS);
            this.Controls.Add(this.L0007);
            this.Controls.Add(this.L0009);
            this.Controls.Add(this.tbHighStockS);
            this.Controls.Add(this.tbLowStockS);
            this.Controls.Add(this.L0008);
            this.Controls.Add(this.dgvWord);
            this.Controls.Add(this.btnCancelClient);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDeliveryDate);
            this.Controls.Add(this.L0003);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.L0006);
            this.Controls.Add(this.tbSmallPackagingWeight);
            this.Controls.Add(this.L0005);
            this.Controls.Add(this.tbSmallPackaging);
            this.Controls.Add(this.L0004);
            this.Controls.Add(this.tbMOQS);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.cbVendor);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0001);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MMIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaterialMainInformationSupplier";
            this.Load += new System.EventHandler(this.MaterialMainInformationSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDeliveryDate;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Label L0006;
        private System.Windows.Forms.TextBox tbSmallPackagingWeight;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.TextBox tbSmallPackaging;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.TextBox tbMOQS;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancelClient;
        private System.Windows.Forms.DataGridView dgvWord;
        private System.Windows.Forms.TextBox tbHighPurchQTYS;
        private System.Windows.Forms.Label L0007;
        private System.Windows.Forms.Label L0009;
        private System.Windows.Forms.TextBox tbHighStockS;
        private System.Windows.Forms.TextBox tbLowStockS;
        private System.Windows.Forms.Label L0008;
        private System.Windows.Forms.ComboBox cbCQDH;
        private System.Windows.Forms.Label label5;
    }
}