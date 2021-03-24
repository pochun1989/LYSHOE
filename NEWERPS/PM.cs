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
    /// ProduceMethod 加工方式維護
    /// </summary>
    public partial class PM : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        /// <summary>
        /// 加工供應商容器
        /// </summary>
        DataSet dsSupply = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;
        /// <summary>
        /// 是否進入編輯或修改模式
        /// </summary>
        private bool isStateChange = false;
        private int tcindex;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "PM";

        #endregion

        #region 構造函式

        public PM()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void ProduceMethod_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region TabControl項目頁籤改變

        private void tcProduceMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: // 速查頁面
                    if (!isStateChange)
                    {
                        tcindex = tcProduceMethod.SelectedIndex;
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                    }
                    else
                    {
                        tcProduceMethod.SelectedIndex = tcindex;
                    }
                    break;
                case 1: // 加工方式主頁面
                    if (!isStateChange)
                    {
                        tcindex = tcProduceMethod.SelectedIndex;
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                        if (dgvProduceData.CurrentCell != null)
                        {
                            if (tbPMID.Text != "")
                            {
                                CallQueryPMPage(dgvProduceData.CurrentRow.Cells[0].Value.ToString()); // 刷新頁面資訊(根據速查)
                                tsbModify.Enabled = true;
                                tsbDelete.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        tcProduceMethod.SelectedIndex = tcindex;
                    }
                    break;
                case 2: // 加工供應商
                    if (!isStateChange)
                    {
                        tcindex = tcProduceMethod.SelectedIndex;
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                        if (tbPMID.Text != "")
                        {
                            QuerySupplierList(); // 供應商查詢
                            dgvSupplierList.ClearSelection();
                        }
                        else
                        {
                            tcProduceMethod.SelectedIndex = 1;
                            MessageBox.Show("No Produce Method Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tcProduceMethod.SelectedIndex = tcindex;
                    }
                    break;
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcProduceMethod.SelectedIndex != 0)
            {
                tcProduceMethod.SelectedIndex = 0;
            }
            else if (dgvProduceData.DataSource == null || tcProduceMethod.SelectedIndex == 0)
            {
                PMD pmd = new PMD();
                pmd.ShowDialog();
                ProduceDataQuery(pmd.加工編號, pmd.中文, pmd.英文);
            }
        }

        #endregion

        #region 清除按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearTextbox();
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteProduceMethod();
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

        #region 速查

        // 單點
        private void dgvProduceData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CallQueryPMPage(dgvProduceData.CurrentRow.Cells[0].Value.ToString());
        }

        // 雙點
        private void dgvProduceData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CallQueryPMPage(dgvProduceData.CurrentRow.Cells[0].Value.ToString());
            tcProduceMethod.SelectedIndex = 1;
        }

        #endregion

        #region 加工供應商

        private void dgvSupplierList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbModify.Enabled = true;
            tsbDelete.Enabled = true;
        } 

        #endregion

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tcProduceMethod.SelectedIndex == 1) // 主加工方式
                {
                    if (tsbIsInsertOrModify == "Insert")
                    {
                        InsertProduceMethod();
                    }
                    else if (tsbIsInsertOrModify == "Modify")
                    {
                        ModifyProduceMethod();
                    }
                }
                tsbIsInsertOrModify = "Recover";
                tsbChoice("Recover");
            }
        }

        #endregion

        #region 取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Recover";
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
                L0001.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                L0001.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                L0002.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region UI邏輯
        
        #region TSB判定

        private void tsbChoice(string insertormodify)
        {
            if (insertormodify == "Recover")
            {
                EnableUIColumns(false);
                if (tcProduceMethod.SelectedIndex == 1) // 加工方式
                {
                    CallQueryPMPage(tbPMID.Text);
                    TSBchange(insertormodify);
                }
                else if (tcProduceMethod.SelectedIndex == 2) // 加工供應商
                {
                    TSBchange(insertormodify);
                    tsbModify.Enabled = false;
                    tsbDelete.Enabled = false;
                }
                isStateChange = false;
            }
            else if (insertormodify == "Insert") // 新增模式
            {
                isStateChange = true;
                if (tcProduceMethod.SelectedIndex == 0) // 速查
                {
                    tcProduceMethod.SelectedIndex = 1;
                    tsbInsert.PerformClick();
                }
                else if (tcProduceMethod.SelectedIndex == 1) // 加工方式
                {
                    EnableUIColumns(true);
                    TSBchange(insertormodify);
                    ClearTextbox();
                }
                else if (tcProduceMethod.SelectedIndex == 2) // 加工供應商
                {
                    PMS pms = new PMS();
                    pms.pmid = this.tbPMID.Text;
                    pms.ShowDialog();
                    TSBchange(insertormodify);
                    if (pms.isSave)
                    {
                        QuerySupplierList(); //重新綁定
                    }
                    else
                    {
                        tsbCancel.PerformClick();
                        isStateChange = false;
                    }
                    tsbClear.Enabled = false; // 不清除
                    tsbInsert.Enabled = true; // 可重複新增
                }
            }
            else if (insertormodify == "Modify") // 修改模式
            {
                isStateChange = true;
                if (tcProduceMethod.SelectedIndex == 1) // 加工方式
                {
                    EnableUIColumns(true);
                    TSBchange(insertormodify);
                }
                else if (tcProduceMethod.SelectedIndex == 2) // 加工供應商
                {
                    PMS pms = new PMS();
                    pms.pmid = this.tbPMID.Text;
                    pms.zsdh = this.dgvSupplierList.CurrentRow.Cells[0].Value.ToString();
                    pms.client = this.dgvSupplierList.CurrentRow.Cells[2].Value.ToString();
                    pms.ShowDialog();
                    TSBchange(insertormodify);
                    if (pms.isSave)
                    {
                        QuerySupplierList(); //重新綁定
                    }
                    else
                    {
                        tsbCancel.PerformClick();
                        isStateChange = false;
                    }
                    tsbClear.Enabled = false; // 供應商彈出視窗無清除按鈕
                }
            }
        }

        #endregion

        #region UI按鈕改變方法

        private void TSBchange(string status)
        {
            switch (status)
            {
                case "Recover":
                    tsbQuery.Enabled = true;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    break;
                case "Insert":
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    break;
                case "Modify":
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    break;
            }
        }

        #endregion

        #region UI欄位狀態開關

        /// <summary>
        /// 加工方式欄位開關
        /// </summary>
        /// <param name="isEnable">開關</param>
        private void EnableUIColumns(bool isEnable)
        {
            if (isEnable) // 開
            {
                tbProduceNameCN.Enabled = true;
                tbProduceNameEN.Enabled = true;
            }
            else // 關
            {
                tbProduceNameCN.Enabled = false;
                tbProduceNameEN.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbProduceNameCN.Text.Trim().Length == 0 || tbProduceNameEN.Text.Length == 0)
            {
                MessageBox.Show("English And Chinese Can't Be Null!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 查詢方法

        #region 速查加工方式方法

        private void ProduceDataQuery(string produceno, string producenameCN, string producenameEN)
        {
            ClearTextbox();
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select PM_ID 加工編號, zwsm 中文說明, ywsm 英文說明 " +
                    "from produce_method " +
                    "where PM_ID like '{0}%' and zwsm like '{1}%' and ywsm like '{2}%'"
                    , produceno, producenameCN, producenameEN);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "加工方式表");
                this.dgvProduceData.DataSource = this.ds.Tables[0];
                this.dgvProduceData.CurrentCell = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Data Error!");
            }
        }

        #endregion

        #region 查詢加工主頁方式(切換頁面或刷新資訊)

        private void CallQueryPMPage(string PMID)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("select PM_ID,ywsm,zwsm from produce_method where PM_ID='{0}'"
                    , PMID);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbPMID.Text = reader["PM_ID"].ToString();
                    tbProduceNameCN.Text = reader["zwsm"].ToString();
                    tbProduceNameEN.Text = reader["ywsm"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Refresh MainMaterial Data Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 查詢材料供應商

        private void QuerySupplierList()
        {
            dsSupply.Clear();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select s.zsdh 廠商代號,z.zsjc 廠商名稱,s.kfdh 客戶代號,k.kfqm 客戶名稱,u.zwsm 採購單位,s.leadtime 交期,s.MOQ 最低購量,s.Packing_Min_Qty 最小包裝數,weight 最小包裝整數重量,HIGH_STOCK 高存,LOW_STOCK 低存,HIGH_PURCH_QTY 最大採購量,s.PM_ID,s.unit_id " +
                    "from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh " +
                    "left join kfzl k on k.kfdh=s.kfdh " +
                    "left join UNIT u on u.Unit_ID=s.unit_id " +
                    "left join produce_method pm on pm.PM_ID=s.PM_ID " +
                    "where s.PM_ID='{0}'"
                    , tbPMID.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsSupply, "材料供應商表");
                this.dgvSupplierList.DataSource = this.dsSupply.Tables[0];
                this.dgvSupplierList.Columns[12].Visible = false;
                this.dgvSupplierList.Columns[13].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier List Query Error!");
            }
        }

        #endregion

        #endregion

        #region 加工方式方法

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            tbProduceNameCN.Text = "";
            tbProduceNameEN.Text = "";
        }

        #endregion

        #region 新增加工方式方法

        private void InsertProduceMethod()
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tbProduceNameCN.Text != tbProduceNameEN.Text)
                {
                    string pmbiggest;
                    try
                    {
                        string sqlbig = "select top 1 PM_ID from produce_method order by PM_ID desc";
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlbig, dbconn.connection);
                        adapter.Fill(ds, "最大值");
                        pmbiggest = (Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1).ToString().PadLeft(10, '0');
                    }
                    catch (Exception)
                    {
                        pmbiggest = "0000000001";
                    }
                    string sql = string.Format("insert into produce_method " +
                        "values('{0}','{1}','{2}','{3}','{4}')"
                        , pmbiggest, tbProduceNameEN.Text, tbProduceNameCN.Text, USERID, DateTime.Now.ToString("yyyy-MM-dd"));
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
                    MessageBox.Show("English And Chinese Name Can't Be The Same!");
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

        #region 編輯加工方式方法

        private void ModifyProduceMethod()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tbProduceNameCN.Text != tbProduceNameEN.Text)
                {
                    string sql = string.Format("update produce_method " +
                    "set zwsm='{0}',ywsm='{1}',USERID='{2}',USERDATE='{3}' " +
                    "where PM_ID='{4}'"
                    , tbProduceNameCN.Text, tbProduceNameEN.Text, USERID, DateTime.Now.ToString("yyyy-MM-dd")
                    , this.dgvProduceData.CurrentRow.Cells[0].Value);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Modify Success!");
                    }
                }
                else
                {
                    MessageBox.Show("English And Chinese Name Can't Be The Same!");
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

        #region 刪除加工方式方法

        private void DeleteProduceMethod()
        {
            DBconnect dbConn = new DBconnect();
            try
            {
                if (tcProduceMethod.SelectedIndex == 1) // 加工方式
                {
                    DialogResult dr = MessageBox.Show("Delete " + this.dgvProduceData.CurrentRow.Cells[1].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from produce_method where PM_ID='{0}'", this.dgvProduceData.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextbox();
                        }
                    }
                }
                else if (tcProduceMethod.SelectedIndex == 2) // 加工供應商
                {
                    DialogResult dr = MessageBox.Show("Delete " + dgvSupplierList.CurrentRow.Cells[1].Value + " this data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("delete from supplier_list where PM_ID='{0}' and zsdh='{1}' and kfdh='{2}'"
                            , tbPMID.Text, dgvSupplierList.CurrentRow.Cells[0].Value.ToString(), dgvSupplierList.CurrentRow.Cells[2].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Supplyer Delete Success", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QuerySupplierList();
                        }
                    }
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


        #endregion

        #endregion

        #endregion

        
    }
}
