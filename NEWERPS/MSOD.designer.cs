namespace NEWERPS
{
    partial class MSOD
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
            this.tbMergerNo = new System.Windows.Forms.TextBox();
            this.L0001 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSeason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStage = new System.Windows.Forms.ComboBox();
            this.chkStageALL = new System.Windows.Forms.CheckBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkIsQueryDate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbMergerNo
            // 
            this.tbMergerNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMergerNo.Location = new System.Drawing.Point(169, 40);
            this.tbMergerNo.MaxLength = 15;
            this.tbMergerNo.Name = "tbMergerNo";
            this.tbMergerNo.Size = new System.Drawing.Size(298, 34);
            this.tbMergerNo.TabIndex = 56;
            // 
            // L0001
            // 
            this.L0001.AutoSize = true;
            this.L0001.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L0001.Location = new System.Drawing.Point(38, 50);
            this.L0001.Name = "L0001";
            this.L0001.Size = new System.Drawing.Size(81, 18);
            this.L0001.TabIndex = 57;
            this.L0001.Text = "Merger No";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnQuery.Location = new System.Drawing.Point(218, 296);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 42);
            this.btnQuery.TabIndex = 59;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(38, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Sample-Mode";
            // 
            // tbSeason
            // 
            this.tbSeason.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSeason.Location = new System.Drawing.Point(169, 160);
            this.tbSeason.MaxLength = 15;
            this.tbSeason.Name = "tbSeason";
            this.tbSeason.Size = new System.Drawing.Size(151, 34);
            this.tbSeason.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(38, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Season";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(38, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 66;
            this.label4.Text = "INSDATE";
            // 
            // cbStage
            // 
            this.cbStage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbStage.FormattingEnabled = true;
            this.cbStage.IntegralHeight = false;
            this.cbStage.Location = new System.Drawing.Point(169, 100);
            this.cbStage.MaxDropDownItems = 15;
            this.cbStage.Name = "cbStage";
            this.cbStage.Size = new System.Drawing.Size(150, 33);
            this.cbStage.TabIndex = 69;
            // 
            // chkStageALL
            // 
            this.chkStageALL.AutoSize = true;
            this.chkStageALL.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkStageALL.Location = new System.Drawing.Point(327, 102);
            this.chkStageALL.Name = "chkStageALL";
            this.chkStageALL.Size = new System.Drawing.Size(68, 29);
            this.chkStageALL.TabIndex = 70;
            this.chkStageALL.Text = "ALL";
            this.chkStageALL.UseVisualStyleBackColor = true;
            this.chkStageALL.CheckedChanged += new System.EventHandler(this.chkStageALL_CheckedChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStart.CustomFormat = "yyyy/MM/dd";
            this.dtpStart.Enabled = false;
            this.dtpStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(255, 220);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 34);
            this.dtpStart.TabIndex = 71;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEnd.CustomFormat = "yyyy/MM/dd 23:59";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(413, 220);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 34);
            this.dtpEnd.TabIndex = 72;
            // 
            // chkIsQueryDate
            // 
            this.chkIsQueryDate.AutoSize = true;
            this.chkIsQueryDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkIsQueryDate.Location = new System.Drawing.Point(171, 223);
            this.chkIsQueryDate.Name = "chkIsQueryDate";
            this.chkIsQueryDate.Size = new System.Drawing.Size(78, 29);
            this.chkIsQueryDate.TabIndex = 73;
            this.chkIsQueryDate.Text = "Date";
            this.chkIsQueryDate.UseVisualStyleBackColor = true;
            this.chkIsQueryDate.CheckedChanged += new System.EventHandler(this.chkIsQueryDate_CheckedChanged);
            // 
            // MergerSampleOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 371);
            this.Controls.Add(this.chkIsQueryDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.chkStageALL);
            this.Controls.Add(this.cbStage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.tbMergerNo);
            this.Controls.Add(this.L0001);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergerSampleOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MergerSampleOrderDetail";
            this.Load += new System.EventHandler(this.MergerSampleOrderDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMergerNo;
        private System.Windows.Forms.Label L0001;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSeason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbStage;
        private System.Windows.Forms.CheckBox chkStageALL;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox chkIsQueryDate;
    }
}