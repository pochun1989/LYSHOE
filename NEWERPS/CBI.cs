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
    /// CompanyInformation 公司基本資料
    /// </summary>
    public partial class CBI : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID; // 使用者名稱
        public string CompanyNo, CompanyNameCN, PurchaseTitle, CompanyNameEN, AddressCN, AddressEN, GUInum, Tel1, FAX1, Tel2, FAX2, ExportRate, Chi;
        private string rowno;
        private string isInsertOrModify;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "CBI";

        #endregion

        #region 構造函式

        public CBI()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入(第一筆資料)

        private void CompanyInformation_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            CompanyDataLoading("1"); // 初始值(第一筆資料)
            lbRecord.Text = "第" + rowno + "筆資料";

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 銀行基本資料頁面(帶入公司代號)

        private void tsbBankInfo_Click(object sender, EventArgs e)
        {
            BI bi = new BI();
            bi.companyNo = tbCompanyNo.Text;
            bi.Show();
        }

        #endregion

        #region 公司名稱(英)與採購抬頭相同

        private void tbCompanyNameEN_TextChanged(object sender, EventArgs e)
        {
            tbPurchaseTitle.Text = tbCompanyNameEN.Text;
        }

        #endregion

        #region 公司資料改變筆數

        // 第一筆資料
        private void tsbFirst_Click(object sender, EventArgs e)
        {
            CompanyDataLoading("1");
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 上一筆資料
        private void tsbPrior_Click(object sender, EventArgs e)
        {
            CompanyDataLoading((Convert.ToInt32(rowno) - 1).ToString());
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 下一筆資料
        private void tsbNext_Click(object sender, EventArgs e)
        {
            CompanyDataLoading((Convert.ToInt32(rowno) + 1).ToString());
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 最後一筆資料
        private void tsbLast_Click(object sender, EventArgs e)
        {
            CompanyDataLoading("select count(*) from gszl");
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        #endregion

        #region 清除按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {
            TextBoxClear();
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            TSBstatus("Insert");
            TextBoxClear();
        }

        #endregion

        #region 編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            TSBstatus("Modify");
        }

        #endregion

        #region 保存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (isInsertOrModify == "Insert") // 新增
                {
                    InsertCompanyData();
                }
                else // 編輯
                {
                    ModifyCompanyData();
                }
                tbCompanyNo.Enabled = false;
            }
        }

        #endregion

        #region 取消新增或編輯事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (isInsertOrModify == "Insert")
            {
                CompanyDataLoading("1");
                lbRecord.Text = "第" + rowno + "筆資料";
                TSBstatus("Recover");
            }
            else
            {
                TSBstatus("Recover");
            }
        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteCompanyData();
        }

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            CBID cid = new CBID();
            cid.ShowDialog();
            tbCompanyNo.Text = cid.公司代號;
            tbCompanyNameCN.Text = cid.公司名稱;
            tbCompanyNameEN.Text = cid.Company;
            tbPurchaseTitle.Text = cid.Company;
            tbAddressCN.Text = cid.公司地址;
            tbAddressEN.Text = cid.Address;
            tbGUInum.Text = cid.統編;
            tbTel1.Text = cid.電話;
            tbTel2.Text = cid.電話2;
            tbFAX1.Text = cid.傳真;
            tbFAX2.Text = cid.傳真2;
            tbExportRate.Text = cid.出口匯率;
            tbChi.Text = cid.chi;
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
                L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                L0012.Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                L0013.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbCompanyNo.Text.Trim().Length == 0 && (tbCompanyNameCN.Text.Trim().Length == 0 || tbCompanyNameEN.Text.Length == 0))
            {
                MessageBox.Show("公司編號與公司名稱(中或英)不可空白!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 讀取公司資料

        public void CompanyDataLoading(string rownum)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select * from (select *,rowno=ROW_NUMBER() over(order by gsdh asc) from gszl) a where rowno=({0})", rownum);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rowno = reader["rowno"].ToString();
                    this.tbCompanyNo.Text = reader["gsdh"].ToString();
                    this.tbCompanyNameCN.Text = reader["gszwqm"].ToString();
                    this.tbPurchaseTitle.Text = reader["gsywqm"].ToString();
                    this.tbCompanyNameEN.Text = reader["gsywqm"].ToString();
                    this.tbAddressCN.Text = reader["gszwdz"].ToString();
                    this.tbAddressEN.Text = reader["gsywdz"].ToString();
                    this.tbGUInum.Text = reader["tybh"].ToString();
                    this.tbTel1.Text = reader["dh"].ToString();
                    this.tbFAX1.Text = reader["cz"].ToString();
                    this.tbTel2.Text = reader["dh2"].ToString();
                    this.tbFAX2.Text = reader["cz2"].ToString();
                    this.tbExportRate.Text = reader["ex_rate"].ToString();
                    this.tbChi.Text = reader["chi"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("載入公司第一筆資料錯誤!");
            }
        }

        #endregion

        #region 清除TextBox資料

        private void TextBoxClear()
        {
            lbRecord.Text = "新的資料";
            this.tbCompanyNo.Text = "";
            this.tbCompanyNameCN.Text = "";
            this.tbPurchaseTitle.Text = "";
            this.tbCompanyNameEN.Text = "";
            this.tbAddressCN.Text = "";
            this.tbAddressEN.Text = "";
            this.tbGUInum.Text = "";
            this.tbTel1.Text = "";
            this.tbFAX1.Text = "";
            this.tbTel2.Text = "";
            this.tbFAX2.Text = "";
            this.tbExportRate.Text = "";
            this.tbChi.Text = "";
        }

        #endregion

        #region Enable Textbox

        private void EnableTextbox(bool isEnable)
        {
            if (isEnable)
            {
                this.tbCompanyNameCN.Enabled = true;
                this.tbCompanyNameEN.Enabled = true;
                this.tbAddressCN.Enabled = true;
                this.tbAddressEN.Enabled = true;
                this.tbGUInum.Enabled = true;
                this.tbTel1.Enabled = true;
                this.tbFAX1.Enabled = true;
                this.tbTel2.Enabled = true;
                this.tbFAX2.Enabled = true;
                this.tbExportRate.Enabled = true;
                this.tbChi.Enabled = true;
            }
            else
            {
                this.tbCompanyNameCN.Enabled = false;
                this.tbCompanyNameEN.Enabled = false;
                this.tbAddressCN.Enabled = false;
                this.tbAddressEN.Enabled = false;
                this.tbGUInum.Enabled = false;
                this.tbTel1.Enabled = false;
                this.tbFAX1.Enabled = false;
                this.tbTel2.Enabled = false;
                this.tbFAX2.Enabled = false;
                this.tbExportRate.Enabled = false;
                this.tbChi.Enabled = false;
            }
        }

        #endregion

        #region TSB恢復原狀

        private void TSBstatus(string status)
        {
            switch (status)
            {
                case "Recover":
                    EnableTextbox(false);
                    tbCompanyNo.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbFirst.Enabled = true;
                    tsbPrior.Enabled = true;
                    tsbNext.Enabled = true;
                    tsbLast.Enabled = true;
                    break;
                case "Insert":
                    EnableTextbox(true);
                    tbCompanyNo.Enabled = true;
                    isInsertOrModify = "Insert";
                    tsbClear.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbFirst.Enabled = false;
                    tsbPrior.Enabled = false;
                    tsbNext.Enabled = false;
                    tsbLast.Enabled = false;
                    break;
                case "Modify":
                    EnableTextbox(true);
                    isInsertOrModify = "Modify";
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbFirst.Enabled = false;
                    tsbPrior.Enabled = false;
                    tsbNext.Enabled = false;
                    tsbLast.Enabled = false;
                    break;
            }
        }

        #endregion

        #region 新增公司資料方法

        private void InsertCompanyData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into gszl " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}','{13}')"
                    , tbCompanyNo.Text, tbCompanyNameCN.Text, tbCompanyNameEN.Text, tbAddressCN.Text, tbAddressEN.Text
                    , tbGUInum.Text, tbTel1.Text, tbFAX1.Text, tbChi.Text, tbExportRate.Text == "" ? "1" : tbExportRate.Text, tbTel2.Text, tbFAX2.Text, USERID, DateTime.Today.ToString("yyyyMMdd"));
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Insert Success!");
                    tbCompanyNo.Enabled = false;
                    TSBstatus("Recover");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 編輯公司資料方法

        private void ModifyCompanyData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update gszl " +
                    "set gszwqm='{0}',gsywqm='{1}',gszwdz='{2}',gsywdz='{3}',tybh='{4}'," +
                    "dh='{5}',cz='{6}',chi='{7}',ex_rate='{8}',dh2='{9}',cz2='{10}',USERID='{11}',USERDATE='{12}' " +
                    "where gsdh='{13}'"
                    , tbCompanyNameCN.Text, tbCompanyNameEN.Text, tbAddressCN.Text, tbAddressEN.Text, tbGUInum.Text
                    , tbTel1.Text, tbFAX1.Text, tbChi.Text, tbExportRate.Text, tbTel2.Text, tbFAX2.Text
                    , USERID, DateTime.Today.ToString("yyyyMMdd"), tbCompanyNo.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Modify Success!");
                    TSBstatus("Recover");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 刪除公司資料方法

        private void DeleteCompanyData()
        {
            DialogResult dr = MessageBox.Show("Delete " + tbCompanyNameCN.Text + " This Company Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                if (DecideIsDeleteCompany())
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        string sql = string.Format("delete gszl where gsdh='{0}'", tbCompanyNo.Text);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CompanyDataLoading(rowno);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Delete Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dbConn.CloseConnection();
                    }
                }
            }
        }

        #endregion

        #region 判斷公司代號是否有在銀行表出現(刪除前判斷)

        private bool DecideIsDeleteCompany()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select distinct GSDH from BANKINFO where GSDH='{0}'", tbCompanyNo.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "銀行表(公司代號)");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("此公司正在使用,無法刪除!\n請至銀行表更改公司代號!", "錯誤!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("判斷表錯誤!");
                return false;
            }
        }

        #endregion

        #endregion


    }
}
