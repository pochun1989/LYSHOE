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
    /// MergerSampleOrderIM 合併單新增刪除
    /// </summary>
    public partial class MSOIM : Form
    {
        #region 變數

        public bool isNew; // 是否新增
        DataSet ds = new DataSet();
        public string 階段, 季節, 備註;
        public bool isSave = false; // 是否儲存

        #endregion

        #region 構造函式

        public MSOIM()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MergerSampleIM_Load(object sender, EventArgs e)
        {
            if (isNew) // 新增
            {
                GetCombobox();
            }
            else // 修改
            {
                GetInfo();
            }
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            階段 = cbStage.Text;
            季節 = tbSeason.Text;
            備註 = tbMemo.Text;
            isSave = true;
            this.Close();
        }

        #endregion

        #region 離開按鈕事件

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region 讀取修改項目(修改時呼叫)

        private void GetInfo()
        {
            GetCombobox();
            cbStage.SelectedValue = 階段;
            // 階段不可修改
            cbStage.Enabled = false;
            tbSeason.Text = 季節;
            tbMemo.Text = 備註;
        }

        #endregion

        #endregion


    }
}
