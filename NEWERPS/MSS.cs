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
    /// MergerSampleSelect 選擇樣品單
    /// </summary>
    public partial class MSS : Form
    {
        #region 變數

        public string ypzlbh, stage, season; // 合併單號,開發階段,季節
        public bool isInsert = false; // 是否新增
        /// <summary>
        /// 樣品單容器
        /// </summary>
        DataSet dsSample = new DataSet();
        public string USERID;

        #endregion

        #region 構造函式

        public MSS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MergerSampleSelect_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            tbStage.Text = stage;
            tbSeason.Text = season;
        }

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QuerySampleOrder();
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvYPZL.Rows.Count; i++)
            {
                if ((bool)dgvYPZL.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                    InsertSampleOrderToMergerOrder(dgvYPZL.Rows[i].Cells[1].Value.ToString(), dgvYPZL.Rows[i].Cells[8].Value.ToString()); // 新增樣品單選擇
                }
            }
            if (isInsert)
            {
                MessageBox.Show("Insert SampleOrder Success!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Select SampleOrder Or Exit");
            }
        } 

        #endregion

        #endregion

        #region 方法

        #region 查詢樣品單

        private void QuerySampleOrder()
        {
            dsSample = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select y.YPDH,y.XieXing,y.SheHao,y.ARTICLE,y.KFJD,y.FINDATE,k.JiJie,y.Quantity " +
                    "from YPZL y left join kfxxzl k on k.XieXing=y.XieXing and k.SheHao=y.SheHao " +
                    "where y.CGYPZLBH is null and y.KFRQ between CONVERT(varchar(8), DATEADD(month, -3, GETDATE()), 112) and CONVERT(varchar(8), GETDATE(), 112) " +
                    "and y.KFJD='{0}' and y.XieXing like'%{1}%' and k.JiJie like'{2}%'"
                    , tbStage.Text, tbShoeModel.Text, tbSeason.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsSample, "查詢樣品單表");
                this.dgvYPZL.DataSource = dsSample.Tables[0];
                this.dgvYPZL.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion

        #region 樣品單選擇新增

        private void InsertSampleOrderToMergerOrder(string ypdh, string pairs)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sqlRSL = string.Format("insert into YPZLZLS (YPZLBH,YPDH,PAIRS,USERID,USERDATE,YN,CKBH,GSBH) " +
                    "values ('{0}','{1}',{2},'{3}',getdate(),'1','','')"
                    , ypzlbh, ypdh, pairs, USERID);
                SqlCommand cmd = new SqlCommand(sqlRSL, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    isInsert = true;
                }
            }
            catch (Exception)
            {
                isInsert = false;
                MessageBox.Show("Insert SampleOrder Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion


    }
}
