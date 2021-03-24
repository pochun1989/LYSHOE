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
    /// PartSet 部位設定
    /// </summary>
    public partial class PS : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;
        private string partClass;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "PS";

        #endregion

        #region 構造函式

        public PS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void PartSet_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            cbPartClass.SelectedIndex = 0;

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
            if (tcPartSet.SelectedIndex != 0)
            {
                tcPartSet.SelectedIndex = 0;
            }
            else if (dgvPartSetData.DataSource == null || tcPartSet.SelectedIndex == 0)
            {
                PSD psd = new PSD();
                psd.ShowDialog();
                if (psd.isq)
                {
                    PartSetDataQuery(psd.部位代號, psd.部位分類, psd.中文, psd.英文);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcPartSet.SelectedIndex = 1;
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
            DeletePartSetData();
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

        #region DGV點擊事件

        // 單點
        private void dgvPartSetData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbModify.Enabled = true;
            tbPartNo.Text = dgvPartSetData.CurrentRow.Cells[0].Value.ToString();
            tbPartNameCN.Text = dgvPartSetData.CurrentRow.Cells[1].Value.ToString();
            tbPartNameEN.Text = dgvPartSetData.CurrentRow.Cells[2].Value.ToString();
            tbRemark.Text = dgvPartSetData.CurrentRow.Cells[3].Value.ToString();
            DecideMoldPart(dgvPartSetData.CurrentRow.Cells[4].Value.ToString());
        }

        // 雙點
        private void dgvPartSetData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbModify.Enabled = true;
            tbPartNo.Text = dgvPartSetData.CurrentRow.Cells[0].Value.ToString();
            tbPartNameCN.Text = dgvPartSetData.CurrentRow.Cells[1].Value.ToString();
            tbPartNameEN.Text = dgvPartSetData.CurrentRow.Cells[2].Value.ToString();
            tbRemark.Text = dgvPartSetData.CurrentRow.Cells[3].Value.ToString();
            DecideMoldPart(dgvPartSetData.CurrentRow.Cells[4].Value.ToString());
            tcPartSet.SelectedIndex = 1;
        }

        #endregion

        #region 保存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    InsertPartSetData();
                }
                else
                {
                    ModifyPartSetData();
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

        private void cbPartClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPartClass.SelectedIndex == 0)
            {
                partClass = "U";
            }
            else if (cbPartClass.SelectedIndex == 1)
            {
                partClass = "B";
            }
            else if (cbPartClass.SelectedIndex == 2)
            {
                partClass = "A";
            }
            else if (cbPartClass.SelectedIndex == 3)
            {
                partClass = "P";
            }
            else if (cbPartClass.SelectedIndex == 4)
            {
                partClass = "O";
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

        private void DecideMoldPart(string dgvpartset)
        {
            if (dgvpartset == "面部")
            {
                cbPartClass.SelectedIndex = 0;
            }
            else if (dgvpartset == "底部")
            {
                cbPartClass.SelectedIndex = 1;
            }
            else if (dgvpartset == "配件")
            {
                cbPartClass.SelectedIndex = 2;
            }
            else if (dgvpartset == "包材")
            {
                cbPartClass.SelectedIndex = 3;
            }
            else if (dgvpartset == "其他")
            {
                cbPartClass.SelectedIndex = 4;
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
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Recover")
            {
                EnableColumn(false);
                tsbQuery.Enabled = true;
                tsbInsert.Enabled = true;
                if (tbPartNo.Text != "")
                {
                    tsbModify.Enabled = true;
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
                tbPartNo.Enabled = true;
                tbPartNameCN.Enabled = true;
                tbPartNameEN.Enabled = true;
                tbRemark.Enabled = true;
                cbPartClass.Enabled = true;
            }
            else // 關
            {
                tbPartNo.Enabled = false;
                tbPartNameCN.Enabled = false;
                tbPartNameEN.Enabled = false;
                tbRemark.Enabled = false;
                cbPartClass.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbPartNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("必須輸入部位代號!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 查詢顏色方法

        private void PartSetDataQuery(string partno, string partclass, string partnameCN, string partnameEN)
        {
            tsbModify.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bwdh 部位代號, zwsm 中文說明, ywsm 英文說明, bz 備註, " +
                    "case when bwlb='U' then '面部' when bwlb='B' then '底部' when bwlb='A' then '配件' when bwlb='P' then '包材' when bwlb='O' then '其他' end 部位類別 " +
                    "from bwzl " +
                    "where bwlb like '{0}%' and bwdh like '{1}%' and YN='1' and ((zwsm like '%{2}%' or zwsm is null) and (ywsm like '%{3}%' or ywsm is null))"
                    , partclass, partno, partnameCN, partnameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "部位設定表");
                this.dgvPartSetData.DataSource = this.ds.Tables[0];
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
            tbPartNo.Text = "";
            tbPartNameCN.Text = "";
            tbPartNameEN.Text = "";
            tbRemark.Text = "";
        }

        #endregion

        #region 新增顏色資料方法

        private void InsertPartSetData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 新增資料
                string sql = string.Format("insert into bwzl " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','1')"
                    , tbPartNo.Text, tbPartNameCN.Text, tbPartNameEN.Text, tbRemark.Text, partClass
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

        #region 刪除顏色資料方法

        private void DeletePartSetData()
        {
            if (this.dgvPartSetData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + this.dgvPartSetData.CurrentRow.Cells[1].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("update bwzl set YN='0' where bwdh='{0}"
                            , dgvPartSetData.CurrentRow.Cells[0].Value);
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

        #region 編輯顏色資料方法

        private void ModifyPartSetData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update bwzl set bwdh='{0}',zwsm='{1}',ywsm='{2}',bz='{3}',bwlb='{4}',USERID='{5}',USERDATE='{6}' where bwdh='{7}'"
                    , tbPartNo.Text, tbPartNameCN.Text, tbPartNameEN.Text, tbRemark.Text, partClass
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd")
                    , dgvPartSetData.CurrentRow.Cells[0].Value);
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
