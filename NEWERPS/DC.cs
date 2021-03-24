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
    /// DevelopClass 開發類型
    /// </summary>
    public partial class DC : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "DC";

        #endregion

        #region 構造函式

        public DC()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void DevelopClass_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcDevelopClass.SelectedIndex != 0)
            {
                tcDevelopClass.SelectedIndex = 0;
            }
            else if (dgvDevData.DataSource == null || tcDevelopClass.SelectedIndex == 0)
            {
                DCD dcd = new DCD();
                dcd.ShowDialog();
                if (dcd.isq)
                {
                    DevDataQuery(dcd.開發類型, dcd.中文, dcd.英文);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcDevelopClass.SelectedIndex = 1;
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 清除按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearTextbox();
        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteDevData();
        }

        #endregion

        #region 編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Modify";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 關閉頁面按鈕事件

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region DGV雙點擊事件

        private void dgvDevData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tbDevClass.Text = dgvDevData.CurrentRow.Cells[1].Value.ToString();
            tbDevNameCN.Text = dgvDevData.CurrentRow.Cells[2].Value.ToString();
            tbDevNameEN.Text = dgvDevData.CurrentRow.Cells[3].Value.ToString();
            tbIncreaseDay.Text = dgvDevData.CurrentRow.Cells[4].Value.ToString();
            tcDevelopClass.SelectedIndex = 1;
        }

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    InsertDevData();
                }
                else
                {
                    ModifyDevData();
                }
                tsbChoice("Recover");
            }
        }

        #endregion

        #region 取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (tsbIsInsertOrModify == "Insert")
            {
                ClearTextbox();
            }
            tsbChoice("Recover");
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region TSB判定

        private void tsbChoice(string insertormodify)
        {
            if (insertormodify == "Insert") // 新增模式
            {
                EnableColumn(true);
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                ClearTextbox();
            }
            else if (insertormodify == "Modify") // 修改模式
            {
                EnableColumn(true);
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Recover")
            {
                EnableColumn(false);
                tsbQuery.Enabled = true;
                tsbInsert.Enabled = true;
                if (tbDevClass.Text != "")
                {
                    tsbModify.Enabled = true;
                    tsbDelete.Enabled = true;
                }
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
            }
        }

        #endregion

        #region UI欄位狀態開關

        private void EnableColumn(bool isEnable)
        {
            if (isEnable) // 開
            {
                tbDevClass.Enabled = true;
                tbIncreaseDay.Enabled = true;
                tbDevNameCN.Enabled = true;
                tbDevNameEN.Enabled = true;
            }
            else // 關
            {
                tbDevClass.Enabled = false;
                tbIncreaseDay.Enabled = false;
                tbDevNameCN.Enabled = false;
                tbDevNameEN.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbDevClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("必須輸入開發類型!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 查詢開發類型方法

        private void DevDataQuery(string devclass, string devnameCN, string devnameEN)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select DC_ID,DC_Number 開發類型, DC_NameC 中文說明, DC_NameE 英文說明, DC_DATE 增加天數 " +
                    "from Dev_Class where DC_Number like '{0}%' and DC_NameC like '%{1}%' and DC_NameE like '%{2}%'"
                    , devclass, devnameCN, devnameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "開發類型表");
                this.dgvDevData.DataSource = this.ds.Tables[0];
                dgvDevData.Columns[0].Visible = false;
                dgvDevData.Columns[1].Width = 70;
                dgvDevData.Columns[4].Width = 70;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Data Error!");
            }
        }

        #endregion

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            tbDevClass.Text = "";
            tbIncreaseDay.Text = "";
            tbDevNameCN.Text = "";
            tbDevNameEN.Text = "";
        }

        #endregion

        #region 新增開發類型方法

        private void InsertDevData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 新增資料
                string sql = string.Format("insert into Dev_Class " +
                    "values('{0}','{1}','{2}',{3},'{4}','{5}')"
                    , tbDevClass.Text, tbDevNameCN.Text, tbDevNameEN.Text, tbIncreaseDay.Text == "" ? "default" : tbIncreaseDay.Text
                    , USERID, DateTime.Today.ToString("yyyyMMdd"));
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Insert Success!");
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

        #region 刪除開發類型方法

        private void DeleteDevData()
        {
            if (this.dgvDevData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + this.dgvDevData.CurrentRow.Cells[2].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from Dev_Class where DC_ID='{0}'"
                            , dgvDevData.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextbox();
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

        #region 編輯開發類型方法

        private void ModifyDevData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update Dev_Class " +
                    "set DC_Number='{0}',DC_NameC='{1}',DC_NameE='{2}',DC_DATE={3},USERID='{4}',USERDATE='{5}'" +
                    "where DC_ID='{6}'"
                    , tbDevClass.Text, tbDevNameCN.Text, tbDevNameEN.Text, tbIncreaseDay.Text == "" ? "default" : tbIncreaseDay.Text
                    , USERID, DateTime.Today.ToString("yyyyMMdd")
                    , dgvDevData.CurrentRow.Cells[0].Value);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Modify Success!");
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

        #endregion

        
    }
}
