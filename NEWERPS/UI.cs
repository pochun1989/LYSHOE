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
    /// UnitInformation 單位維護
    /// </summary>
    public partial class UI : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "1_7";

        #endregion

        #region 構造函式

        public UI()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 視窗載入

        private void AssetsUnit_Load(object sender, EventArgs e)
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
            if (tcUnitInformation.SelectedIndex != 0)
            {
                tcUnitInformation.SelectedIndex = 0;
            }
            else if (dgvUnitData.DataSource == null || tcUnitInformation.SelectedIndex == 0)
            {
                UID uid = new UID();
                uid.ShowDialog();
                QueryUnitData(uid.單位編號, uid.中文, uid.英文);
            }
        } 

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcUnitInformation.SelectedIndex = 1;
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 修改按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Modify";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            UnitDelete();
        }

        #endregion

        #region 關閉頁面按鈕事件

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 清除欄位

        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        #endregion

        #region DGV雙點擊事件

        private void dgvUnitData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tbUnitNo.Text = this.dgvUnitData.CurrentRow.Cells[0].Value.ToString();
            tbUnitNameCN.Text = this.dgvUnitData.CurrentRow.Cells[1].Value.ToString();
            tbUnitNameEN.Text = this.dgvUnitData.CurrentRow.Cells[2].Value.ToString();
            tcUnitInformation.SelectedIndex = 1;
        }

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    UnitInsert();
                }
                else
                {
                    UnitUpdate();
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
                ClearTextBox();
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
                EnableUIColumns(true);
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Modify") // 修改模式
            {
                EnableUIColumns(true);
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Recover")
            {
                EnableUIColumns(false);
                tsbQuery.Enabled = true;
                tsbInsert.Enabled = true;
                if (tsbIsInsertOrModify == "Modify")
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

        private void EnableUIColumns(bool isEnable)
        {
            if (isEnable) // 開
            {
                tbUnitNo.Enabled = true;
                tbUnitNameCN.Enabled = true;
                tbUnitNameEN.Enabled = true;
            }
            else // 關
            {
                tbUnitNo.Enabled = false;
                tbUnitNameCN.Enabled = false;
                tbUnitNameEN.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbUnitNo.Text.Trim().Length == 0 && (tbUnitNameCN.Text.Trim().Length == 0 || tbUnitNameEN.Text.Length == 0))
            {
                MessageBox.Show("中英至少輸入一項!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 清除欄位方法

        private void ClearTextBox()
        {
            tbUnitNameCN.Text = "";
            tbUnitNameEN.Text = "";
            tbUnitNo.Text = "";
        }

        #endregion

        #region 查詢單位方法

        private void QueryUnitData(string unitno, string unitnameCN, string unitnameEN)
        {
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select Unit_ID 單位編號, zwsm 中文說明, ywsm 英文說明 from UNIT " +
                    "where Unit_ID like '{0}%' and zwsm like '%{1}%' and ywsm like '%{2}%'"
                    , unitno, unitnameCN, unitnameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "單位資訊");
                this.dgvUnitData.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Query Unit Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region 新增單位名稱方法

        private void UnitInsert()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into UNIT " +
                    "values('{0}','{1}','{2}','{3}','{4}'"
                    , tbUnitNo.Text, tbUnitNameCN.Text, tbUnitNameEN.Text
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd"));
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
        
        #region 修改單位名稱方法

        private void UnitUpdate()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update UNIT " +
                    "set Unit_ID='{0}',zwsm='{1}',ywsm='{2}',USERID='{3}',USERDATE='{4}' " +
                    "where Unit_ID='{5}'"
                    , tbUnitNo.Text, tbUnitNameCN.Text, tbUnitNameEN.Text, USERID, DateTime.Today.ToString("yyyy-MM-dd")
                    , this.dgvUnitData.CurrentRow.Cells[0].Value.ToString());
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
        
        #region 刪除單位方法

        private void UnitDelete()
        {
            if (this.dgvUnitData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + this.dgvUnitData.CurrentRow.Cells[1].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        string sql = string.Format("delete from UNIT where Unit_ID='{0}'", this.dgvUnitData.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextBox();
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

        #endregion

        
    }
}
