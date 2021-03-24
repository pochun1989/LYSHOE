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
    /// ColorInformation 顏色維護
    /// </summary>
    public partial class CI : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "CI";

        #endregion

        #region 構造函式

        public CI()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void ColorInformation_Load(object sender, EventArgs e)
        {
            cbColorClass.IntegralHeight = false;
            cbColorClass.SelectedIndex = 0;
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
            if (tcColorInformation.SelectedIndex != 0)
            {
                tcColorInformation.SelectedIndex = 0;
            }
            else if (dgvColorData.DataSource == null || tcColorInformation.SelectedIndex == 0)
            {
                CID cid = new CID();
                cid.ShowDialog();
                ColorDataQuery(cid.顏色分類, cid.中文, cid.英文);
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcColorInformation.SelectedIndex = 1;
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
            DeleteColorData();
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

        private void dgvColorData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tbColorNameCN.Text = dgvColorData.CurrentRow.Cells[1].Value.ToString();
            tbColorNameEN.Text = dgvColorData.CurrentRow.Cells[2].Value.ToString();
            tcColorInformation.SelectedIndex = 1;
        }

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    InsertColorData();
                }
                else
                {
                    ModifyColorData();
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
                cbColorClass.Enabled = true;
                tbColorNameCN.Enabled = true;
                tbColorNameEN.Enabled = true;
            }
            else // 關
            {
                cbColorClass.Enabled = false;
                tbColorNameCN.Enabled = false;
                tbColorNameEN.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbColorNameCN.Text.Trim().Length == 0 || tbColorNameEN.Text.Length == 0)
            {
                MessageBox.Show("Chinese & English Data At Least Key-In One!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 查詢顏色方法

        private void ColorDataQuery(string colorclass, string colornameCN, string colornameEN)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select COLOR_ID 顏色編號, zwsm 中文說明, ywsm 英文說明, " +
                    "case when COLOR_CLASS='1' then '單色' when COLOR_CLASS='2' then '多色' end 顏色分類 " +
                    "from color where COLOR_CLASS like '{0}%' and zwsm like '%{1}%' and ywsm like '%{2}%'"
                    , colorclass == "0" ? "" : colorclass, colornameCN, colornameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "顏色表");
                this.dgvColorData.DataSource = this.ds.Tables[0];
                this.dgvColorData.Columns[0].Width = 60;
                this.dgvColorData.Columns[3].Width = 80;
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
            tbColorNameCN.Text = "";
            tbColorNameEN.Text = "";
        }

        #endregion

        #region 新增顏色資料方法

        private void InsertColorData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tbColorNameCN.Text != tbColorNameEN.Text)
                {
                    int bigestColorID = 1;
                    ds = new DataSet();
                    // 抓取顏色編號最大值
                    string sql1 = "select top 1 COLOR_ID from color order by COLOR_ID desc";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                    adapter1.Fill(ds, "顏色編號最大值");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        bigestColorID = Convert.ToInt32(bigestColorID.ToString().PadLeft(4, '0'));
                    }
                    else
                    {
                        bigestColorID = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
                    }
                    // 新增資料
                    string sql = string.Format("insert into color " +
                        "values('{0}','1','{1}','{2}','{3}','{4}')"
                        , bigestColorID.ToString(), tbColorNameCN.Text, tbColorNameEN.Text, USERID, DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Insert Success!");
                    }
                }
                else
                {
                    MessageBox.Show("Chinese Can't Same As English!");
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

        private void DeleteColorData()
        {
            if (this.dgvColorData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + this.dgvColorData.CurrentRow.Cells[1].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from color where COLOR_ID='{0}'", this.dgvColorData.CurrentRow.Cells[0].Value);
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

        private void ModifyColorData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update color " +
                    "set zwsm='{0}',ywsm='{1}',USERID='{2}',USERDATE='{3}' where COLOR_ID='{4}'"
                    , tbColorNameCN.Text, tbColorNameEN.Text, USERID, DateTime.Now.ToString("yyyy-MM-dd")
                    , this.dgvColorData.CurrentRow.Cells[0].Value);
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
