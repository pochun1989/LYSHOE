namespace NEWERPS
{
    partial class SOSMBOMCLBH
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
            this.cbClassBQuery = new System.Windows.Forms.ComboBox();
            this.cbClassAQuery = new System.Windows.Forms.ComboBox();
            this.L0002 = new System.Windows.Forms.Label();
            this.L0001 = new System.Windows.Forms.Label();
            this.tbzwpm = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvCLZL = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsChangecldh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCLZL)).BeginInit();
            this.SuspendLayout();
            // 
            // cbClassBQuery
            // 
            this.cbClassBQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassBQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClassBQuery.FormattingEnabled = true;
            this.cbClassBQuery.IntegralHeight = false;
            this.cbClassBQuery.Location = new System.Drawing.Point(704, 15);
            this.cbClassBQuery.MaxDropDownItems = 15;
            this.cbClassBQuery.Name = "cbClassBQuery";
            this.cbClassBQuery.Size = new System.Drawing.Size(280, 33);
            this.cbClassBQuery.TabIndex = 8;
            // 
            // cbClassAQuery
            // 
            this.cbClassAQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassAQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClassAQuery.FormattingEnabled = true;
            this.cbClassAQuery.IntegralHeight = false;
            this.cbClassAQuery.Location = new System.Drawing.Point(288, 15);
            this.cbClassAQuery.MaxDropDownItems = 15;
            this.cbClassAQuery.Name = "cbClassAQuery";
            this.cbClassAQuery.Size = new System.Drawing.Size(280, 33);
            this.cbClassAQuery.TabIndex = 7;
            this.cbClassAQuery.SelectedIndexChanged += new System.EventHandler(this.cbClassAQuery_SelectedIndexChanged);
            // 
            // L0002
            // 
            this.L0002.AutoSize = true;
            this.L0002.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0002.Location = new System.Drawing.Point(642, 25);
            this.L0002.Name = "L0002";
            this.L0002.Size = new System.Drawing.Size(56, 18);
            this.L0002.TabIndex = 6;
            this.L0002.Text = "Class_B";
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(225, 25);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(57, 18);
            this.L0001.TabIndex = 5;
            this.L0001.Text = "Class_A";
            // 
            // tbzwpm
            // 
            this.tbzwpm.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbzwpm.Location = new System.Drawing.Point(38, 63);
            this.tbzwpm.Name = "tbzwpm";
            this.tbzwpm.Size = new System.Drawing.Size(839, 34);
            this.tbzwpm.TabIndex = 63;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(883, 57);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 65;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvCLZL
            // 
            this.dgvCLZL.AllowUserToAddRows = false;
            this.dgvCLZL.AllowUserToDeleteRows = false;
            this.dgvCLZL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCLZL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCLZL.Location = new System.Drawing.Point(13, 107);
            this.dgvCLZL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCLZL.Name = "dgvCLZL";
            this.dgvCLZL.ReadOnly = true;
            this.dgvCLZL.RowTemplate.Height = 27;
            this.dgvCLZL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCLZL.Size = new System.Drawing.Size(995, 418);
            this.dgvCLZL.TabIndex = 66;
            this.dgvCLZL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCLZL_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(673, 533);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 42);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbVendor
            // 
            this.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.IntegralHeight = false;
            this.cbVendor.Location = new System.Drawing.Point(359, 539);
            this.cbVendor.MaxDropDownItems = 15;
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(280, 33);
            this.cbVendor.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(177, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 70;
            this.label1.Text = "Vendor";
            // 
            // chkIsChangecldh
            // 
            this.chkIsChangecldh.AutoSize = true;
            this.chkIsChangecldh.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkIsChangecldh.Location = new System.Drawing.Point(38, 17);
            this.chkIsChangecldh.Name = "chkIsChangecldh";
            this.chkIsChangecldh.Size = new System.Drawing.Size(100, 29);
            this.chkIsChangecldh.TabIndex = 73;
            this.chkIsChangecldh.Text = "Formal";
            this.chkIsChangecldh.UseVisualStyleBackColor = true;
            this.chkIsChangecldh.CheckedChanged += new System.EventHandler(this.chkIsChangecldh_CheckedChanged);
            // 
            // SOSMBOMCLBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 587);
            this.Controls.Add(this.chkIsChangecldh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbVendor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCLZL);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbzwpm);
            this.Controls.Add(this.cbClassBQuery);
            this.Controls.Add(this.cbClassAQuery);
            this.Controls.Add(this.L0002);
            this.Controls.Add(this.L0001);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SOSMBOMCLBH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SampleOrderShoeModelBOMCLBH";
            this.Load += new System.EventHandler(this.SampleOrderShoeModelBOMCLBH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCLZL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClassBQuery;
        private System.Windows.Forms.ComboBox cbClassAQuery;
        private System.Windows.Forms.Label L0002;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.TextBox tbzwpm;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvCLZL;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsChangecldh;
    }
}