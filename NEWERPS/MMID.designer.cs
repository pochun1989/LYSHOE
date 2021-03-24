namespace NEWERPS
{
    partial class MMID
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbClassB = new System.Windows.Forms.ComboBox();
            this.cbClassA = new System.Windows.Forms.ComboBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.dgvCLZL = new System.Windows.Forms.DataGridView();
            this.L0004 = new System.Windows.Forms.Label();
            this.L0003 = new System.Windows.Forms.Label();
            this.L0005 = new System.Windows.Forms.Label();
            this.cbSupplierVendorD = new System.Windows.Forms.ComboBox();
            this.L0007 = new System.Windows.Forms.Label();
            this.tbSizeStart = new System.Windows.Forms.TextBox();
            this.tbSizeEnd = new System.Windows.Forms.TextBox();
            this.tbUsage = new System.Windows.Forms.TextBox();
            this.btnSaveMaterial = new System.Windows.Forms.Button();
            this.tbCLDHQuery = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbMaterialNameQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMaterialSN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPM = new System.Windows.Forms.ComboBox();
            this.L0006 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbPMSN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSavePM = new System.Windows.Forms.Button();
            this.cbSupplierVendorPM = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSwitch = new System.Windows.Forms.Label();
            this.pcSwitch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCLZL)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // cbClassB
            // 
            this.cbClassB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassB.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClassB.FormattingEnabled = true;
            this.cbClassB.IntegralHeight = false;
            this.cbClassB.Location = new System.Drawing.Point(381, 9);
            this.cbClassB.MaxDropDownItems = 15;
            this.cbClassB.Name = "cbClassB";
            this.cbClassB.Size = new System.Drawing.Size(273, 33);
            this.cbClassB.TabIndex = 2;
            this.cbClassB.SelectedIndexChanged += new System.EventHandler(this.cbClassB_SelectedIndexChanged);
            // 
            // cbClassA
            // 
            this.cbClassA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassA.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClassA.FormattingEnabled = true;
            this.cbClassA.IntegralHeight = false;
            this.cbClassA.Location = new System.Drawing.Point(68, 9);
            this.cbClassA.MaxDropDownItems = 15;
            this.cbClassA.Name = "cbClassA";
            this.cbClassA.Size = new System.Drawing.Size(251, 33);
            this.cbClassA.TabIndex = 1;
            this.cbClassA.SelectedIndexChanged += new System.EventHandler(this.cbClassA_SelectedIndexChanged);
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(325, 19);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(50, 18);
            this.L0002.TabIndex = 10;
            this.L0002.Text = "ClassB";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(11, 19);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(51, 18);
            this.L0001.TabIndex = 9;
            this.L0001.Text = "ClassA";
            // 
            // dgvCLZL
            // 
            this.dgvCLZL.AllowUserToAddRows = false;
            this.dgvCLZL.AllowUserToDeleteRows = false;
            this.dgvCLZL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCLZL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCLZL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCLZL.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCLZL.Location = new System.Drawing.Point(11, 263);
            this.dgvCLZL.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCLZL.Name = "dgvCLZL";
            this.dgvCLZL.ReadOnly = true;
            this.dgvCLZL.RowHeadersWidth = 51;
            this.dgvCLZL.RowTemplate.Height = 27;
            this.dgvCLZL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCLZL.Size = new System.Drawing.Size(972, 275);
            this.dgvCLZL.TabIndex = 18;
            this.dgvCLZL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCLZL_CellClick);
            this.dgvCLZL.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCLZL_CellDoubleClick);
            // 
            // L0004
            // 
            this.L0004.AutoSize = true;
            this.L0004.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0004.Location = new System.Drawing.Point(162, 108);
            this.L0004.Name = "L0004";
            this.L0004.Size = new System.Drawing.Size(61, 18);
            this.L0004.TabIndex = 20;
            this.L0004.Text = "SizeEnd";
            // 
            // L0003
            // 
            this.L0003.AutoSize = true;
            this.L0003.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0003.Location = new System.Drawing.Point(11, 108);
            this.L0003.Name = "L0003";
            this.L0003.Size = new System.Drawing.Size(66, 18);
            this.L0003.TabIndex = 19;
            this.L0003.Text = "SizeStart";
            // 
            // L0005
            // 
            this.L0005.AutoSize = true;
            this.L0005.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0005.Location = new System.Drawing.Point(308, 108);
            this.L0005.Name = "L0005";
            this.L0005.Size = new System.Drawing.Size(49, 18);
            this.L0005.TabIndex = 21;
            this.L0005.Text = "Usage";
            // 
            // cbSupplierVendorD
            // 
            this.cbSupplierVendorD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierVendorD.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbSupplierVendorD.FormattingEnabled = true;
            this.cbSupplierVendorD.IntegralHeight = false;
            this.cbSupplierVendorD.Location = new System.Drawing.Point(503, 98);
            this.cbSupplierVendorD.Margin = new System.Windows.Forms.Padding(2);
            this.cbSupplierVendorD.MaxDropDownItems = 12;
            this.cbSupplierVendorD.Name = "cbSupplierVendorD";
            this.cbSupplierVendorD.Size = new System.Drawing.Size(255, 33);
            this.cbSupplierVendorD.TabIndex = 6;
            // 
            // L0007
            // 
            this.L0007.AutoSize = true;
            this.L0007.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0007.Location = new System.Drawing.Point(442, 108);
            this.L0007.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L0007.Name = "L0007";
            this.L0007.Size = new System.Drawing.Size(57, 18);
            this.L0007.TabIndex = 195;
            this.L0007.Text = "Vendor";
            // 
            // tbSizeStart
            // 
            this.tbSizeStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSizeStart.Location = new System.Drawing.Point(82, 98);
            this.tbSizeStart.Margin = new System.Windows.Forms.Padding(2);
            this.tbSizeStart.Name = "tbSizeStart";
            this.tbSizeStart.Size = new System.Drawing.Size(75, 34);
            this.tbSizeStart.TabIndex = 3;
            // 
            // tbSizeEnd
            // 
            this.tbSizeEnd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSizeEnd.Location = new System.Drawing.Point(228, 98);
            this.tbSizeEnd.Margin = new System.Windows.Forms.Padding(2);
            this.tbSizeEnd.Name = "tbSizeEnd";
            this.tbSizeEnd.Size = new System.Drawing.Size(75, 34);
            this.tbSizeEnd.TabIndex = 4;
            // 
            // tbUsage
            // 
            this.tbUsage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbUsage.Location = new System.Drawing.Point(362, 98);
            this.tbUsage.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsage.Name = "tbUsage";
            this.tbUsage.Size = new System.Drawing.Size(75, 34);
            this.tbUsage.TabIndex = 5;
            // 
            // btnSaveMaterial
            // 
            this.btnSaveMaterial.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSaveMaterial.Location = new System.Drawing.Point(867, 95);
            this.btnSaveMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveMaterial.Name = "btnSaveMaterial";
            this.btnSaveMaterial.Size = new System.Drawing.Size(84, 36);
            this.btnSaveMaterial.TabIndex = 196;
            this.btnSaveMaterial.Text = "Save";
            this.btnSaveMaterial.UseVisualStyleBackColor = true;
            this.btnSaveMaterial.Click += new System.EventHandler(this.btnSaveMaterial_Click);
            // 
            // tbCLDHQuery
            // 
            this.tbCLDHQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCLDHQuery.Location = new System.Drawing.Point(709, 9);
            this.tbCLDHQuery.Margin = new System.Windows.Forms.Padding(2);
            this.tbCLDHQuery.Name = "tbCLDHQuery";
            this.tbCLDHQuery.Size = new System.Drawing.Size(176, 34);
            this.tbCLDHQuery.TabIndex = 221;
            this.tbCLDHQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCLDHQuery_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(659, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 222;
            this.label4.Text = "CLDH";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(867, 55);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(84, 36);
            this.btnQuery.TabIndex = 223;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbMaterialNameQuery
            // 
            this.tbMaterialNameQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMaterialNameQuery.Location = new System.Drawing.Point(68, 48);
            this.tbMaterialNameQuery.Multiline = true;
            this.tbMaterialNameQuery.Name = "tbMaterialNameQuery";
            this.tbMaterialNameQuery.Size = new System.Drawing.Size(782, 43);
            this.tbMaterialNameQuery.TabIndex = 225;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(11, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 224;
            this.label1.Text = "Name";
            // 
            // cbMaterialSN
            // 
            this.cbMaterialSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialSN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbMaterialSN.FormattingEnabled = true;
            this.cbMaterialSN.IntegralHeight = false;
            this.cbMaterialSN.Location = new System.Drawing.Point(793, 98);
            this.cbMaterialSN.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaterialSN.MaxDropDownItems = 12;
            this.cbMaterialSN.Name = "cbMaterialSN";
            this.cbMaterialSN.Size = new System.Drawing.Size(57, 33);
            this.cbMaterialSN.TabIndex = 226;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(762, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 18);
            this.label2.TabIndex = 227;
            this.label2.Text = "SN";
            // 
            // cbPM
            // 
            this.cbPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPM.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPM.FormattingEnabled = true;
            this.cbPM.IntegralHeight = false;
            this.cbPM.Location = new System.Drawing.Point(110, 19);
            this.cbPM.Margin = new System.Windows.Forms.Padding(2);
            this.cbPM.MaxDropDownItems = 12;
            this.cbPM.Name = "cbPM";
            this.cbPM.Size = new System.Drawing.Size(243, 33);
            this.cbPM.TabIndex = 228;
            this.cbPM.SelectedIndexChanged += new System.EventHandler(this.cbPM_SelectedIndexChanged);
            // 
            // L0006
            // 
            this.L0006.AutoSize = true;
            this.L0006.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0006.Location = new System.Drawing.Point(75, 29);
            this.L0006.Name = "L0006";
            this.L0006.Size = new System.Drawing.Size(30, 18);
            this.L0006.TabIndex = 229;
            this.L0006.Text = "PM";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 110);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.L0001);
            this.splitContainer1.Panel1.Controls.Add(this.L0002);
            this.splitContainer1.Panel1.Controls.Add(this.cbClassA);
            this.splitContainer1.Panel1.Controls.Add(this.cbClassB);
            this.splitContainer1.Panel1.Controls.Add(this.cbMaterialSN);
            this.splitContainer1.Panel1.Controls.Add(this.L0003);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.L0004);
            this.splitContainer1.Panel1.Controls.Add(this.tbMaterialNameQuery);
            this.splitContainer1.Panel1.Controls.Add(this.L0005);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.L0007);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.cbSupplierVendorD);
            this.splitContainer1.Panel1.Controls.Add(this.tbCLDHQuery);
            this.splitContainer1.Panel1.Controls.Add(this.tbSizeStart);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.tbSizeEnd);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.tbUsage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbPMSN);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.btnSavePM);
            this.splitContainer1.Panel2.Controls.Add(this.cbSupplierVendorPM);
            this.splitContainer1.Panel2.Controls.Add(this.cbPM);
            this.splitContainer1.Panel2.Controls.Add(this.L0006);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(994, 148);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 231;
            // 
            // cbPMSN
            // 
            this.cbPMSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPMSN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPMSN.FormattingEnabled = true;
            this.cbPMSN.IntegralHeight = false;
            this.cbPMSN.Location = new System.Drawing.Point(766, 18);
            this.cbPMSN.Margin = new System.Windows.Forms.Padding(2);
            this.cbPMSN.MaxDropDownItems = 12;
            this.cbPMSN.Name = "cbPMSN";
            this.cbPMSN.Size = new System.Drawing.Size(57, 33);
            this.cbPMSN.TabIndex = 230;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(735, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 18);
            this.label5.TabIndex = 231;
            this.label5.Text = "SN";
            // 
            // btnSavePM
            // 
            this.btnSavePM.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSavePM.Location = new System.Drawing.Point(429, 70);
            this.btnSavePM.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePM.Name = "btnSavePM";
            this.btnSavePM.Size = new System.Drawing.Size(84, 36);
            this.btnSavePM.TabIndex = 205;
            this.btnSavePM.Text = "Save";
            this.btnSavePM.UseVisualStyleBackColor = true;
            this.btnSavePM.Click += new System.EventHandler(this.btnSavePM_Click);
            // 
            // cbSupplierVendorPM
            // 
            this.cbSupplierVendorPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierVendorPM.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbSupplierVendorPM.FormattingEnabled = true;
            this.cbSupplierVendorPM.IntegralHeight = false;
            this.cbSupplierVendorPM.Location = new System.Drawing.Point(429, 19);
            this.cbSupplierVendorPM.Margin = new System.Windows.Forms.Padding(2);
            this.cbSupplierVendorPM.MaxDropDownItems = 12;
            this.cbSupplierVendorPM.Name = "cbSupplierVendorPM";
            this.cbSupplierVendorPM.Size = new System.Drawing.Size(300, 33);
            this.cbSupplierVendorPM.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(368, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 204;
            this.label3.Text = "Vendor";
            // 
            // lbSwitch
            // 
            this.lbSwitch.AutoSize = true;
            this.lbSwitch.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSwitch.Location = new System.Drawing.Point(506, 39);
            this.lbSwitch.Name = "lbSwitch";
            this.lbSwitch.Size = new System.Drawing.Size(71, 36);
            this.lbSwitch.TabIndex = 230;
            this.lbSwitch.Text = "開關";
            // 
            // pcSwitch
            // 
            this.pcSwitch.ErrorImage = global::NEWERPS.Properties.Resources.switch_off;
            this.pcSwitch.Image = global::NEWERPS.Properties.Resources.switch_off;
            this.pcSwitch.Location = new System.Drawing.Point(349, 3);
            this.pcSwitch.Name = "pcSwitch";
            this.pcSwitch.Size = new System.Drawing.Size(128, 101);
            this.pcSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcSwitch.TabIndex = 230;
            this.pcSwitch.TabStop = false;
            this.pcSwitch.Click += new System.EventHandler(this.pcSwitch_Click);
            // 
            // MMID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 552);
            this.Controls.Add(this.lbSwitch);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pcSwitch);
            this.Controls.Add(this.dgvCLZL);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MMID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaterialMainInformationDetail";
            this.Load += new System.EventHandler(this.MaterialMainInformationDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCLZL)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcSwitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClassB;
        private System.Windows.Forms.ComboBox cbClassA;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.DataGridView dgvCLZL;
        private System.Windows.Forms.Label L0004;
        private System.Windows.Forms.Label L0003;
        private System.Windows.Forms.Label L0005;
        private System.Windows.Forms.ComboBox cbSupplierVendorD;
        private System.Windows.Forms.Label L0007;
        private System.Windows.Forms.TextBox tbSizeStart;
        private System.Windows.Forms.TextBox tbSizeEnd;
        private System.Windows.Forms.TextBox tbUsage;
        private System.Windows.Forms.Button btnSaveMaterial;
        private System.Windows.Forms.TextBox tbCLDHQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox tbMaterialNameQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMaterialSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPM;
        private System.Windows.Forms.Label L0006;
        private System.Windows.Forms.PictureBox pcSwitch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSavePM;
        private System.Windows.Forms.ComboBox cbSupplierVendorPM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSwitch;
        private System.Windows.Forms.ComboBox cbPMSN;
        private System.Windows.Forms.Label label5;
    }
}