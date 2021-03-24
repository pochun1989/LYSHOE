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
    public partial class VendorQuery : Form
    {
        public VendorQuery()
        {
            InitializeComponent();
        }

        #region 變數

        public DataSet ds = new DataSet();
        public string 廠代, 廠名, 簡稱, 英文, 統編, 發票, 付款, 扣趴, 幣別, 傳真, 電話, 最後交易日, 負責人, Mail1, 開發, Mail2, 量產, Mail3, 生產地, 用戶, 異動日, 郵寄;

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "1_3_1";

        private void VendorQuery_Load(object sender, EventArgs e)
        {      
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            //更改語言
            ChangeLabel();

        }



        #endregion



        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryData();
            }
            catch (Exception)
            {
                MessageBox.Show("查詢資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 搜尋方法

        private void QueryData()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from zszl where zsdh like '%{0}%' and zsqm like '%{1}%' and zsywjc like '%{2}%'", tb廠代1.Text, tb廠名1.Text, tb英文1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                this.Close();
                //this.dgvVendor.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("載入廠商失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            this.dgvWord.DataSource = this.ds.Tables[0];

            WordPosition();
        }

        #endregion

        #region 文字定位

        private void WordPosition()
        {
            try
            {
                L0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                L0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                L0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion

        #endregion
    }
}
