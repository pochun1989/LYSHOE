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
    /// QuoteOrderConfirm 報價單確認
    /// </summary>
    public partial class QOC : Form
    {
        #region 變數

        /// <summary>
        /// 採購單頭容器
        /// </summary>
        DataSet dsQO = new DataSet();
        /// <summary>
        /// 採購單身容器
        /// </summary>
        DataSet dsQOM = new DataSet();
        private string dstart, dend;
        public string USERID;

        #endregion

        #region 構造函式

        public QOC()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void QOC_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
        } 

        #endregion

        #region 查詢報價單頭按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (chkIsQueryDate.Checked)
            {
                dstart = this.dtpStart.Text;
                dend = this.dtpEnd.Text;
            }
            else
            {
                dstart = "2000/01/01";
                dend = DateTime.Now.ToString("yyyy/MM/dd 23:59");
            }
            QueryCGBJ(dstart, dend);
        }

        #endregion

        #region 報價單身查詢事件

        private void dgvQuoteOrderMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirm.Enabled = true;
            QueryCGBJS(dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString());
        } 

        #endregion
        
        #region 確認報價單按鈕事件

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmCGBJ(dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString());
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

        #region 查詢報價單頭方法

        private void QueryCGBJ(string dstart, string dend)
        {
            btnConfirm.Enabled = false;
            dsQO = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bj.BJNO,bj.ZSBH,z.zsywjc,bj.USERDATE,bj.USERID,bj.CFMDate,bj.CFMID,bj.YN " +
                    "from CGBJ bj " +
                    "left join zszl z on z.zsdh=bj.ZSBH " +
                    "where (bj.USERDATE between '{0}' and '{1}') and bj.YN='1' and bj.CFMDate is null " +
                    "order by BJNO desc"
                    , dstart, dend);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQO, "報價單頭表");
                this.dgvQuoteOrderMaster.DataSource = dsQO.Tables[0];
                this.dgvQuoteOrderMaster.CurrentCell = null;
                this.dgvQuoteOrderDetail.DataSource = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query CGBJ Error!");
            }
        }

        #endregion

        #region 查詢報價單身方法

        private void QueryCGBJS(string bjno)
        {
            dsQOM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bs.CLBH,c.ywpm,c.dwbh,bs.USPrice,bs.VNPrice,bs.Memo " +
                    "from CGBJS bs " +
                    "left join clzl c on c.cldh=bs.CLBH " +
                    "where bs.BJNO='{0}' order by bs.CLBH"
                    , bjno);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQOM, "報價單身表");
                this.dgvQuoteOrderDetail.DataSource = dsQOM.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query CGBJS Error!");
            }
        }

        #endregion
        // CFMID沒抓登入ID
        #region 報價確認方法

        private void ConfirmCGBJ(string bjno)
        {
            dsQOM = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update CGBJ set CFMID='{0}',CFMDate=GETDATE() " +
                    "where BJNO='{1}'"
                    , "TESTID", bjno);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    //string sqlclbh = string.Format("select CLBH from CGBJS where BJNO='{0}'", bjno);
                    //SqlDataAdapter adapter = new SqlDataAdapter(sqlclbh, dbconn.connection);
                    //adapter.Fill(dsQOM, "報價單明細的材料");
                    for(int i = 0; i < dgvQuoteOrderDetail.Rows.Count; i++)
                    {
                        string sqlyn0 = string.Format("update CGBJS set YN='0' where BJNO!='{0}' and CLBH='{1}'"
                            , bjno, dgvQuoteOrderDetail.Rows[i].Cells[0].Value.ToString());
                        SqlCommand cmdyn = new SqlCommand(sqlyn0, dbconn.connection);
                        cmdyn.ExecuteNonQuery();
                    }
                    MessageBox.Show("Confirm CGBJ Success!");
                    btnQuery.PerformClick();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Confirm CGBJ Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
