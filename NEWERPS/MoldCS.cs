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
    /// MoldClassSet 工制具類別設定
    /// </summary>
    public partial class MoldCS : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;
        private string moldPart;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MoldCS";

        #endregion

        #region 構造函式

        public MoldCS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MoldClassSet_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            cbMoldPart.SelectedIndex = 0;

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
            if (tcMoldClassSet.SelectedIndex != 0)
            {
                tcMoldClassSet.SelectedIndex = 0;
            }
            else if (dgvMoldClassData.DataSource == null || tcMoldClassSet.SelectedIndex == 0)
            {
                MoldCSD mcd = new MoldCSD();
                mcd.ShowDialog();
                if (mcd.isq)
                {
                    MoldClassDataQuery(mcd.工具類別, mcd.部位分類, mcd.中文, mcd.英文);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcMoldClassSet.SelectedIndex = 1;
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
            DeleteMoldClassData();
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

        private void dgvMoldClassData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tbMoldClass.Text = dgvMoldClassData.CurrentRow.Cells[0].Value.ToString();
            tbMoldNameCN.Text = dgvMoldClassData.CurrentRow.Cells[1].Value.ToString();
            tbMoldNameEN.Text = dgvMoldClassData.CurrentRow.Cells[2].Value.ToString();
            tbRemark.Text = dgvMoldClassData.CurrentRow.Cells[3].Value.ToString();
            DecideMoldPart(dgvMoldClassData.CurrentRow.Cells[4].Value.ToString());
            tcMoldClassSet.SelectedIndex = 1;
        }

        #endregion

        #region 保存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    InsertMoldClassData();
                }
                else
                {
                    ModifyMoldClassData();
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

        #region 部位分類下拉選單

        private void cbMoldPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoldPart.SelectedIndex == 0)
            {
                moldPart = "U";
            }
            else if (cbMoldPart.SelectedIndex == 1)
            {
                moldPart = "B";
            }
            else if (cbMoldPart.SelectedIndex == 2)
            {
                moldPart = "O";
            }
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 判斷部分分類(DGV呼叫)

        private void DecideMoldPart(string dgvmoldpart)
        {
            if (dgvmoldpart == "面部")
            {
                cbMoldPart.SelectedIndex = 0;
            }
            else if (dgvmoldpart == "底部")
            {
                cbMoldPart.SelectedIndex = 1;
            }
            else if (dgvmoldpart == "其他")
            {
                cbMoldPart.SelectedIndex = 2;
            }
        }

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
                if (tbMoldClass.Text != "")
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
                tbMoldClass.Enabled = true;
                tbMoldNameCN.Enabled = true;
                tbMoldNameEN.Enabled = true;
                tbRemark.Enabled = true;
                cbMoldPart.Enabled = true;
            }
            else // 關
            {
                tbMoldClass.Enabled = false;
                tbMoldNameCN.Enabled = false;
                tbMoldNameEN.Enabled = false;
                tbRemark.Enabled = false;
                cbMoldPart.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbMoldClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("必須輸入工具類別!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 查詢工制具類別方法

        private void MoldClassDataQuery(string moldclass, string moldpart, string moldnameCN, string moldnameEN)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select gjlb 工具類別, zwsm 中文說明, ywsm 英文說明, bz 備註, " +
                    "case when bwfl='U' then '面部' when bwfl='B' then '底部' when bwfl='O' then '其他' end 部位分類 " +
                    "from gjlbzl " +
                    "where bwfl like '{0}%' and gjlb like '{1}%' and ((zwsm like '%{2}%' or zwsm is null) and (ywsm like '%{3}%' or ywsm is null))"
                    , moldpart, moldclass, moldnameCN, moldnameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "工制具類別表");
                this.dgvMoldClassData.DataSource = this.ds.Tables[0];
                this.dgvMoldClassData.Columns[0].Width = 70;
                this.dgvMoldClassData.Columns[4].Width = 80;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Error!");
            }
        }

        #endregion

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            tbMoldClass.Text = "";
            tbMoldNameCN.Text = "";
            tbMoldNameEN.Text = "";
            tbRemark.Text = "";
        }

        #endregion

        #region 新增工制具類別方法

        private void InsertMoldClassData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 新增資料
                string sql = string.Format("insert into gjlbzl " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                    , tbMoldClass.Text, tbMoldNameCN.Text, tbMoldNameEN.Text, tbRemark.Text, moldPart
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

        #region 刪除工制具類別方法

        private void DeleteMoldClassData()
        {
            if (this.dgvMoldClassData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("確定要刪除 " + this.dgvMoldClassData.CurrentRow.Cells[1].Value + " 這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from gjlbzl where gjlb='{0}'"
                            , dgvMoldClassData.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("刪除成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("刪除資料失敗!", "刪除錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dbConn.CloseConnection();
                    }
                }
            }
        }

        #endregion

        #region 編輯工制具類別方法

        private void ModifyMoldClassData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update gjlbzl set gjlb='{0}',zwsm='{1}',ywsm='{2}',bz='{3}',bwfl='{4}',USERID='{5}',USERDATE='{6}' where gjlb='{7}'"
                    , tbMoldClass.Text, tbMoldNameCN.Text, tbMoldNameEN.Text, tbRemark.Text, moldPart
                    , USERID, DateTime.Today.ToString("yyyyMMdd")
                    , dgvMoldClassData.CurrentRow.Cells[0].Value);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("修改資料成功!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("更新資料失敗!", "更新錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
