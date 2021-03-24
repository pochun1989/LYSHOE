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
    /// BankInformation 銀行基本資料
    /// </summary>
    public partial class BI : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID; // 使用者名稱
        public string companyNo; // 公司代號
        private string rowno;
        private string isInsertOrModify;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "BI";

        #endregion

        #region 構造函數

        public BI()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入(第一筆資料)

        private void BankInformation_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            BankDataLoading("1"); // 初始值(第一筆資料)
            lbRecord.Text = "第" + rowno + "筆資料";

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 銀行資料改變筆數

        // 第一筆資料
        private void tsbFirst_Click(object sender, EventArgs e)
        {
            BankDataLoading("1");
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 上一筆資料
        private void tsbPrior_Click(object sender, EventArgs e)
        {
            BankDataLoading((Convert.ToInt32(rowno) - 1).ToString());
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 下一筆資料
        private void tsbNext_Click(object sender, EventArgs e)
        {
            BankDataLoading((Convert.ToInt32(rowno) + 1).ToString());
            lbRecord.Text = "第" + rowno + "筆資料";
        }

        // 最後一筆資料
        private void tsbLast_Click(object sender, EventArgs e)
        {
            BankDataLoading("select count(*) from BANKINFO where GSDH='" + companyNo + "'");
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
                    InsertBankData();
                }
                else // 編輯
                {
                    ModifyBankData();
                }
            }
        } 

        #endregion

        #region 取消新增或編輯事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (isInsertOrModify == "Insert")
            {
                BankDataLoading("1");
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
            DeleteBankData();
        } 

        #endregion

        #region 代號欄位輸入事件

        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                tbCode.SelectedText = char.ToUpper(e.KeyChar).ToString();
            }
            InputLimit(e);
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 檢查輸入

        /// <summary>
        /// 檢查是否輸入
        /// </summary>
        /// <returns> true過, false不過 </returns>
        private bool CheckInput()
        {
            bool ok = true;
            if (tbCompanyNo.Text.Trim().Length == 0 && tbAccName.Text.Trim().Length == 0 && tbBName.Text.Length == 0)
            {
                MessageBox.Show("公司編號,帳戶名稱與銀行名稱不可空白!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 限制輸入方法(只可輸入數字)

        private void InputLimit(KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region 讀取銀行資料

        public void BankDataLoading(string rownum)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select * from (select *,rowno=ROW_NUMBER() over(order by CODE asc) from BANKINFO where GSDH='{0}') a where rowno=({1})", companyNo, rownum);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rowno = reader["rowno"].ToString();
                    this.tbCompanyNo.Text = reader["GSDH"].ToString();
                    this.tbCode.Text = reader["CODE"].ToString();
                    this.tbAccName.Text = reader["NAME"].ToString();
                    this.tbBName.Text = reader["BANK"].ToString();
                    this.tbBTel.Text = reader["BATEL"].ToString();
                    this.tbBFax.Text = reader["BAFAX"].ToString();
                    this.tbBAddress.Text = reader["BADDR"].ToString();
                    this.tbSWcode.Text = reader["SWCODE"].ToString();
                    this.tbAcct.Text = reader["ACCT"].ToString();
                    this.tbRemark.Text = reader["REMARK"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("載入銀行第一筆資料錯誤!");
            }
        }

        #endregion

        #region 清除TextBox資料

        private void TextBoxClear()
        {
            lbRecord.Text = "新的資料";
            this.tbCode.Text = "";
            this.tbAccName.Text = "";
            this.tbBName.Text = "";
            this.tbBTel.Text = "";
            this.tbBFax.Text = "";
            this.tbBAddress.Text = "";
            this.tbSWcode.Text = "";
            this.tbAcct.Text = "";
            this.tbRemark.Text = "";
        }

        #endregion

        #region Enable Textbox

        private void EnableTextbox(bool isEnable)
        {
            if (isEnable)
            {
                this.tbCode.Enabled = true;
                this.tbAccName.Enabled = true;
                this.tbBName.Enabled = true;
                this.tbBTel.Enabled = true;
                this.tbBFax.Enabled = true;
                this.tbBAddress.Enabled = true;
                this.tbSWcode.Enabled = true;
                this.tbAcct.Enabled = true;
                this.tbRemark.Enabled = true;
            }
            else
            {
                this.tbCode.Enabled = false;
                this.tbAccName.Enabled = false;
                this.tbBName.Enabled = false;
                this.tbBTel.Enabled = false;
                this.tbBFax.Enabled = false;
                this.tbBAddress.Enabled = false;
                this.tbSWcode.Enabled = false;
                this.tbAcct.Enabled = false;
                this.tbRemark.Enabled = false;
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
                    break;
            }
        }

        #endregion

        #region 新增銀行資料方法

        private void InsertBankData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into BANKINFO " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}')"
                    , tbCode.Text, tbAccName.Text, tbBName.Text, tbBAddress.Text, tbBTel.Text, tbBFax.Text
                    , tbSWcode.Text, tbAcct.Text, "NULL", tbRemark.Text, companyNo
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd"));
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Insert Success!");
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
        
        #region 編輯銀行資料方法

        private void ModifyBankData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update gszl " +
                    "set gszwqm='{0}',gsywqm='{1}',gszwdz='{2}',gsywdz='{3}',tybh='{4}'," +
                    "dh='{5}',cz='{6}',chi='{7}',ex_rate='{8}',dh2='{9}',cz2='{10}',USERID='{11}',USERDATE='{12}' " +
                    "where gsdh='{13}'"
                    
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

        #region 刪除銀行資料方法

        private void DeleteBankData()
        {
            DialogResult dr = MessageBox.Show("Delete " + tbBName.Text + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {

                DBconnect dbConn = new DBconnect();
                try
                {
                    string sql = string.Format("delete BANKINFO where CODE='{0}' and GSDH='{1}'", tbCode.Text, tbCompanyNo.Text);
                    SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                    dbConn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BankDataLoading(rowno);
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

        #endregion

        #endregion

        
    }
}
