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
    /// CompanyInformationDetail 公司資料速查
    /// </summary>
    public partial class CBID : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 公司代號, 公司名稱, Company, 公司地址, Address, 統編, 電話, 電話2, 傳真, 傳真2, 出口匯率, chi;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "CBID";

        #endregion

        #region 構造函式

        public CBID()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            CompanyDataQuery();
        }

        #endregion

        #region 載入按鈕事件

        private void btnImport_Click(object sender, EventArgs e)
        {
            CompanyDataImport();

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region DGV雙擊事件

        private void dgvCompanyData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CompanyDataImport();
        }

        #endregion

        #endregion

        #region 方法

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            dsL = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsL, "棧板表");
            this.dgvWord.DataSource = this.dsL.Tables[0];

            WordPosition();
        }

        #endregion

        #region 切換 dgv

        private void ChangeDataView()
        {

            int i;
            i = int.Parse(userLanguage) + 1;

            dsL = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsL, "棧板表");
            this.dgvWord.DataSource = this.dsL.Tables[0];

            LoadDgv();
        }

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                int r = dgvWord.Rows.Count;

                for (int i = 0; i < r; i++)
                {
                    dgvWord.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
                }

            }
            catch (Exception) { }
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
                L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 查詢公司資料方法

        private void CompanyDataQuery()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select gsdh 公司代號,gszwqm 公司名稱,gsywqm Company,gszwdz 公司地址,gsywdz Address,tybh 統編,dh 電話,dh2 電話2,cz 傳真,cz2 傳真2,ex_rate 出口匯率,chi chi from gszl " +
                    "where gsdh like '{0}%' and dh like '%{1}%' and (gszwqm like '{2}%' or gsywqm like '{3}%') and (gszwdz like '{4}%' or gsywdz like '{5}%')"
                    , tbCompanyNo.Text, tbTel.Text, tbCompanyName.Text, tbCompanyName.Text, tbAddress.Text, tbAddress.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "查詢表");
                this.dgvCompanyData.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Query Data Error!");
            }
        }

        #endregion

        #region 載入資料回主頁

        private void CompanyDataImport()
        {
            公司代號 = dgvCompanyData.CurrentRow.Cells[0].Value.ToString();
            公司名稱 = dgvCompanyData.CurrentRow.Cells[1].Value.ToString();
            Company = dgvCompanyData.CurrentRow.Cells[2].Value.ToString();
            公司地址 = dgvCompanyData.CurrentRow.Cells[3].Value.ToString();
            Address = dgvCompanyData.CurrentRow.Cells[4].Value.ToString();
            統編 = dgvCompanyData.CurrentRow.Cells[5].Value.ToString();
            電話 = dgvCompanyData.CurrentRow.Cells[6].Value.ToString();
            電話2 = dgvCompanyData.CurrentRow.Cells[7].Value.ToString();
            傳真 = dgvCompanyData.CurrentRow.Cells[8].Value.ToString();
            傳真2 = dgvCompanyData.CurrentRow.Cells[9].Value.ToString();
            出口匯率 = dgvCompanyData.CurrentRow.Cells[10].Value.ToString();
            chi = dgvCompanyData.CurrentRow.Cells[11].Value.ToString();
            this.Close();
        }

        #endregion

        #endregion



    }
}
