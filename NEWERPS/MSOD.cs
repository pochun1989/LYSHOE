using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEWERPS
{
    /// <summary>
    /// MergerSampleOrderDetail 合併樣品單速查
    /// </summary>
    public partial class MSOD : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 合併單號, 階段, 季節, 開單日起, 開單日止;
        public bool isq = false; // 是否查詢
        private int stageindex;

        #endregion

        #region 構造函式

        public MSOD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MergerSampleOrderDetail_Load(object sender, EventArgs e)
        {
            GetCombobox();
        }

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            isq = true;
            合併單號 = this.tbMergerNo.Text;
            階段 = this.cbStage.Text;
            季節 = this.tbSeason.Text;
            if (chkIsQueryDate.Checked)
            {
                開單日起 = this.dtpStart.Text;
                開單日止 = this.dtpEnd.Text;
            }
            else
            {
                開單日起 = "2000/01/01";
                開單日止 = DateTime.Now.ToString("yyyy/MM/dd 23:59");
            }
            this.Close();
        }

        #endregion

        #region 階段全部開關

        private void chkStageALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStageALL.Checked)
            {
                stageindex = cbStage.SelectedIndex;
                cbStage.SelectedIndex = -1;
                cbStage.Enabled = false;
            }
            else
            {
                cbStage.SelectedIndex = stageindex;
                cbStage.Enabled = true;
            }
        }

        #endregion

        #region 是否查詢日期開關

        private void chkIsQueryDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsQueryDate.Checked)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region 方法

        #region 下拉選單載入方法(階段)

        private void GetCombobox()
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                // 讀取開發階段表
                string sql = "select DS_Number from Dev_stage";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn.connection);
                adapter.Fill(ds, "階段表");
                this.cbStage.DataSource = ds.Tables[0];
                this.cbStage.ValueMember = "DS_Number";
                this.cbStage.DisplayMember = "DS_Number";
            }
            catch (Exception)
            {
                MessageBox.Show("Combobox Error!");
            }
        }

        #endregion

        #endregion
        
    }
}
