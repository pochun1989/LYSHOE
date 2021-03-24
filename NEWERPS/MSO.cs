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
    /// MergerSampleOrder 合併樣品單
    /// </summary>
    public partial class MSO : Form
    {
        #region 變數

        /// <summary>
        /// 合併單容器
        /// </summary>
        DataSet dsM = new DataSet();
        /// <summary>
        /// 樣品單選擇容器
        /// </summary>
        DataSet dsMS = new DataSet();
        /// <summary>
        /// 採購量設定容器
        /// </summary>
        DataSet dsorderBOM = new DataSet();
        /// <summary>
        /// 樣品單材料入庫情況容器
        /// </summary>
        DataSet dsSDEF = new DataSet();
        /// <summary>
        /// 計算展開YPZLZLS2容器
        /// </summary>
        DataSet dsexS2 = new DataSet();
        /// <summary>
        /// 採購量設定刪除表
        /// </summary>
        DataTable dtoBOMd = new DataTable("採購量設定刪除表");

        public string USERID;
        /// <summary>
        /// UI新增修改按鈕變數
        /// </summary>
        private string tsbIsInsertOrModify;
        private string q1, q2, q3, q4, q5; // 搜尋條件
        /// <summary>
        /// 合併單編號
        /// </summary>
        private string oypzlbh;
        /// <summary>
        /// 併單當月最大值
        /// </summary>
        private string biggestYPZLBH;
        /// <summary>
        /// 合併單新增欄位(階段,季節,備註)
        /// </summary>
        private string mstage, mseason, mmemo;
        /// <summary>
        /// S2已經展開計算完畢
        /// </summary>
        private bool S2isExpansionSuccess = true;
        string ypmemo; // S1更新ypmemo
        private int ypzlzlsindex = 0; // DGV點擊index
        private bool isdeletesample = false; // 是否刪除樣品單(選擇樣品單頁面)

        //語言變數
        //public DataSet dsL = new DataSet();
        //public string userLanguage;
        //string userForm = ""; // FORM ID 未設定

        #endregion

        #region 構造函式

        public MSO()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MergerSampleOrder_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            
            //獲取語言
            //userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            //ChangeLabel();
            //ChangeDataView();
        }

        #endregion
        
        #region TabControl頁籤改變事件

        private void tcMergerOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcChangeTotsb(tcMergerOrder.SelectedIndex);
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: // 合併單
                    if (dgvMergerOrder.DataSource != null && dgvMergerOrder.CurrentCell != null)
                    {
                        if (dgvMergerOrder.CurrentRow.Cells["YN"].Value.ToString() == "1")
                        {
                            tsbModify.Enabled = true;
                            tsbDelete.Enabled = true;
                        }
                        else
                        {
                            tsbModify.Enabled = false;
                            tsbDelete.Enabled = false;
                        }
                    }
                    break;
                case 1: // 樣品單選擇
                    if (dgvMergerOrder.CurrentCell != null)
                    {
                        tbMergerNo.Text = oypzlbh;
                        tbInsdate.Text = dgvMergerOrder.CurrentRow.Cells[1].Value.ToString();
                        tbLastComputeDate.Text = dgvMergerOrder.CurrentRow.Cells[4].Value.ToString();
                        QueryMergerSampleOrder(oypzlbh); // 載入樣品單選擇頁面
                        if (dgvMergerOrder.CurrentRow.Cells["YN"].Value.ToString() != "0")
                        {
                            // 開單日計算
                            DateTime d1 = Convert.ToDateTime(tbInsdate.Text);
                            TimeSpan s = new TimeSpan(DateTime.Now.Ticks - d1.Ticks);
                            // 判斷開單日
                            if (s.Days > 3)
                            {
                                tsbInsert.Enabled = false;
                                //tsbDelete.Enabled = false;
                            }
                            else
                            {
                                tsbInsert.Enabled = true;
                                //tsbDelete.Enabled = true;
                            }
                            if (dgvSampleOrderList.RowCount > 0)
                            {
                                // 計算日
                                if (tbLastComputeDate.Text != "")
                                {
                                    // 開始計算日計算
                                    DateTime d2 = Convert.ToDateTime(tbLastComputeDate.Text);
                                    TimeSpan s2 = new TimeSpan(DateTime.Now.Ticks - d2.Ticks);
                                    // 最後計算日判斷
                                    if (s2.Days > 3)
                                    {
                                        btnCompute.Enabled = false;
                                    }
                                    else
                                    {
                                        btnCompute.Enabled = true;
                                    }
                                }
                                else // 沒有計算過
                                {
                                    if (s.Days > 3) // 超過建檔日三天要退單並釋放樣品單的CGYPZLBH
                                    {
                                        ReleaseCGYPZLBH();
                                        btnCompute.Enabled = false;
                                    }
                                    else
                                    {
                                        btnCompute.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                btnCompute.Enabled = false;
                            }
                        }
                        else// 其他狀態全關閉
                        {
                            btnCompute.Enabled = false;
                            tsbInsert.Enabled = false;
                            //tsbDelete.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One MergerOrder!");
                        tcMergerOrder.SelectedIndex = 0;
                    }
                    break;
                case 2: // 採購量設定
                    if (dgvMergerOrder.CurrentCell != null)
                    {
                        if (tbLastComputeDate.Text != "")
                        {
                            QueryOrderBOM(dgvMergerOrder.CurrentRow.Cells[0].Value.ToString());
                            if (dgvMergerOrder.CurrentRow.Cells["YN"].Value.ToString() != "0")
                            {
                                if (dgvOrderBOM.RowCount == 0)
                                {
                                    tsbModify.Enabled = false;
                                }
                                else
                                {
                                    DateTime d = Convert.ToDateTime(tbLastComputeDate.Text);
                                    TimeSpan s = new TimeSpan(DateTime.Now.Ticks - d.Ticks);
                                    if (s.Days > 3)
                                    {
                                        tsbModify.Enabled = false;
                                    }
                                    else
                                    {
                                        tsbModify.Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Compute MergerOrder!");
                            tcMergerOrder.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One MergerOrder!");
                        tcMergerOrder.SelectedIndex = 0;
                    }
                    break;
                case 3: // 樣品單材料入庫情況
                    if (dgvMergerOrder.CurrentCell != null)
                    {
                        if (dgvSampleOrderList.Rows.Count != 0)
                        {
                            tbSampleOrderDEF.Text = dgvSampleOrderList.CurrentRow.Cells[0].Value.ToString();
                            QuerySampleOrderDEF(tbMergerNo.Text, tbSampleOrderDEF.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One MergerOrder!");
                        tcMergerOrder.SelectedIndex = 0;
                    }
                    break;
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcMergerOrder.SelectedIndex != 0)
            {
                tcMergerOrder.SelectedIndex = 0;
            }
            else if (dgvMergerOrder.DataSource == null || tcMergerOrder.SelectedIndex == 0)
            {
                MSOD msod = new MSOD();
                msod.ShowDialog();
                if (msod.isq)
                {
                    q1 = msod.合併單號;
                    q2 = msod.階段;
                    mstage = msod.階段;
                    q3 = msod.季節;
                    mseason = msod.季節;
                    q4 = msod.開單日起;
                    q5 = msod.開單日止;
                    QueryMergerOrder(q1, q2, q3, q4, q5);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 清除按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteMergerOrder();
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
        
        #region 樣品單計算按鈕

        private void btnCompute_Click(object sender, EventArgs e)
        {
            // 重新計算前需要刪除所有S2資料
            DeleteYPZLZLS2BeforeCount(tbMergerNo.Text);
            // 計算樣品單(從YPZLS開始寫入)
            for (int i = 0; i < dgvSampleOrderList.Rows.Count; i++)
            {
                // YPZLZLS2展開
                QuerySampleOrderExpansion(dgvSampleOrderList.Rows[i].Cells[0].Value.ToString());
                // 刷新樣品單CGYPZLBH
                UpdateCGYPZLBH(tbMergerNo.Text, dgvSampleOrderList.Rows[i].Cells[0].Value.ToString());
            }
            if (S2isExpansionSuccess)
            {
                // YPZLZLS1加總
                SumSampleOrderDosage(tbMergerNo.Text);
                ModifyMerger(); // 寫入計算時間(合併單)
                MessageBox.Show("Compute Complete!");
            }
        } 

        #endregion
        
        #region DGV Event
        
        #region 合併單

        // 單點
        private void dgvMergerOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            oypzlbh = dgvMergerOrder.CurrentRow.Cells[0].Value.ToString();
            if (tcMergerOrder.SelectedIndex == 0)
            {
                if (dgvMergerOrder.CurrentRow.Cells["YN"].Value.ToString() == "1")
                {
                    tsbModify.Enabled = true;
                    tsbDelete.Enabled = true;
                }
                else
                {
                    tsbModify.Enabled = false;
                    tsbDelete.Enabled = false;
                }
            }
        }

        // 雙點
        private void dgvMergerOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oypzlbh = dgvMergerOrder.CurrentRow.Cells[0].Value.ToString();
            tcMergerOrder.SelectedIndex = 1;
        }

        #endregion

        #region 樣品單選擇

        // 單點(樣品單選擇模擬點擊)
        private void dgvSampleOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ypzlzlsindex = dgvSampleOrderList.CurrentRow.Cells[0].RowIndex;
            tsbDelete.Enabled = dgvSampleOrderList.CurrentCell == null ? false : true;
        }

        // 雙點
        private void dgvSampleOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ypzlzlsindex = dgvSampleOrderList.CurrentRow.Cells[0].RowIndex;
            tcMergerOrder.SelectedIndex = 3;
        }

        #endregion

        #endregion
        
        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (tcMergerOrder.SelectedIndex == 2)
            {
                dgvOrderBOMRowState(dsorderBOM.Tables["採購量設定表"]); // 判斷欄位狀態(dsorderBOM)
                QueryOrderBOM(tbMergerNo.Text);
            }
            tsbIsInsertOrModify = "Recover";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if(tcMergerOrder.SelectedIndex == 2)
            {
                QueryOrderBOM(tbMergerNo.Text);
            }
            tsbIsInsertOrModify = "Recover";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #endregion

        #region 方法
        //
        #region UI邏輯
        //
        #region TSB判定

        private void tsbChoice(string insertormodify)
        {
            if (insertormodify == "Recover")
            {
                if (tcMergerOrder.SelectedIndex == 1) // 樣品單選擇
                {
                    TSBchange(insertormodify);
                }
                else if (tcMergerOrder.SelectedIndex == 2) // 採購量設定
                {
                    tsbQuery.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    dgvOrderBOM.ReadOnly = true;
                    dgvOrderBOM.AllowUserToDeleteRows = false;
                }
            }
            else if (insertormodify == "Insert") // 新增模式
            {
                if (tcMergerOrder.SelectedIndex == 0) // 合併單
                {
                    MSOIM msim = new MSOIM();
                    msim.isNew = true; // 新增
                    msim.ShowDialog();
                    if (msim.isSave)
                    {
                        this.mstage = msim.階段;
                        this.mseason = msim.季節;
                        this.mmemo = msim.備註;
                        InsertMerger();
                        // 刷新查詢合併單並Focus
                        QueryMergerOrder(biggestYPZLBH, mstage, mseason);
                    }
                }
                else if (tcMergerOrder.SelectedIndex == 1) // 樣品單選擇
                {
                    MSS mss = new MSS();
                    mss.ypzlbh = tbMergerNo.Text;
                    mss.stage = this.dgvMergerOrder.CurrentRow.Cells[2].Value.ToString();
                    mss.season = this.dgvMergerOrder.CurrentRow.Cells[3].Value.ToString();
                    mss.ShowDialog();
                    if (mss.isInsert)
                    {
                        QueryMergerSampleOrder(oypzlbh); // 載入樣品單選擇頁面
                    }
                }
            }
            else if (insertormodify == "Modify") // 修改模式
            {
                if (tcMergerOrder.SelectedIndex == 0) // 合併單
                {
                    MSOIM msim = new MSOIM();
                    msim.isNew = false; // 修改
                    msim.階段 = this.dgvMergerOrder.CurrentRow.Cells[2].Value.ToString();
                    msim.季節 = this.dgvMergerOrder.CurrentRow.Cells[3].Value.ToString();
                    msim.備註 = this.dgvMergerOrder.CurrentRow.Cells[5].Value.ToString();
                    msim.ShowDialog();
                    if (msim.isSave)
                    {
                        this.mstage = msim.階段;
                        this.mseason = msim.季節;
                        this.mmemo = msim.備註;
                        ModifyMerger();
                    }
                }
                else if (tcMergerOrder.SelectedIndex == 2) // 採購量設定
                {
                    TSBchange(insertormodify);
                    dgvOrderBOM.ReadOnly = false;
                    dgvOrderBOM.AllowUserToDeleteRows = true;
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
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    break;
                case "Insert":
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    break;
                case "Modify":
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    break;
            }
        }

        #endregion
        
        #region 頁籤更換UI按鈕改變

        private void tcChangeTotsb(int page)
        {
            switch (page)
            {
                case 0: // 合併單
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    break;
                case 1: // 樣品單選擇
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    break;
                case 2: // 採購量設定
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    break;
                case 3: // 樣品單材料入庫情況
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    break;
            }
        }

        #endregion

        #endregion
        
        #region 查詢方法

        #region 查詢合併單方法

        // 速查
        private void QueryMergerOrder(string orderno, string stage, string season, string dstart, string dend)
        {
            dsM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select YPZLBH,INSDATE,KFJD,JiJie,CALDATE,memo,USERID,USERDATE,YN " +
                    "from YPZLZL " +
                    "where YPZLBH like'%{0}%' and YN>'0' and (KFJD='{1}') and (JiJie like'{2}%' or JiJie is null) and INSDATE between '{3}' and '{4}' " +
                    "order by YPZLBH desc"
                    , orderno, stage, season, dstart, dend);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsM, "合併單表");
                this.dgvMergerOrder.DataSource = dsM.Tables[0];
                this.dgvMergerOrder.CurrentCell = null;
                // 清除併單內容
                tbMergerNo.Text = "";
                tbInsdate.Text = "";
                tbLastComputeDate.Text = "";
                dgvSampleOrderList.DataSource = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        // focus資料(根據階段,季節)
        private void QueryMergerOrder(string orderno, string stage, string season)
        {
            dsM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select YPZLBH,INSDATE,KFJD,JiJie,CALDATE,memo,USERID,USERDATE,YN from YPZLZL " +
                    "where KFJD='{0}' and (JiJie like'{1}%' or JiJie is null) and YN>'0' order by YPZLBH"
                    , stage, season);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsM, "合併單表");
                this.dgvMergerOrder.DataSource = dsM.Tables[0];
                if (orderno != "")
                {
                    DataRow[] rows = dsM.Tables[0].Select("YPZLBH='" + orderno + "'");
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("空");
                    }
                    else
                    {
                        int index = dsM.Tables[0].Rows.IndexOf(rows[0]);
                        dgvMergerOrder.CurrentCell = dgvMergerOrder.Rows[index].Cells[0];
                        dgvMergerOrder_CellClick(dgvMergerOrder, new DataGridViewCellEventArgs(index, 0));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion
        
        #region 查詢樣品單選擇

        private void QueryMergerSampleOrder(string ypzlbh)
        {
            tsbDelete.Enabled = false;
            dsMS = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select y.YPDH,yzs.PAIRS,y.ARTICLE,k.XieMing,yzs.YN,y.XieXing,y.SheHao " +
                    "from YPZLZLS yzs " +
                    "left join YPZLZL yz on yz.YPZLBH=yzs.YPZLBH " +
                    "left join YPZL y on y.YPDH=yzs.YPDH " +
                    "left join kfxxzl k on k.XieXing=y.XieXing and k.SheHao=y.SheHao " +
                    "where yzs.YPZLBH='{0}'", ypzlbh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsMS, "樣品單選擇表");
                this.dgvSampleOrderList.DataSource = dsMS.Tables[0];
                if (dgvSampleOrderList.RowCount > 0)
                {
                    if (!isdeletesample)
                    {
                        dgvSampleOrderList.CurrentCell = dgvSampleOrderList[0, ypzlzlsindex];
                        dgvSampleOrderList_CellClick(dgvSampleOrderList, new DataGridViewCellEventArgs(0, ypzlzlsindex));
                    }
                    else
                    {
                        dgvSampleOrderList.CurrentCell = dgvSampleOrderList[0, 0];
                        dgvSampleOrderList_CellClick(dgvSampleOrderList, new DataGridViewCellEventArgs(0, 0));
                        ypzlzlsindex = 0;
                        isdeletesample = false;
                    }
                    btnCompute.Enabled = true;
                }
                else
                {
                    btnCompute.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Query Merger SampleOrder Select Data Error!");
            }
        }

        #endregion

        #region 查詢採購量設定

        private void QueryOrderBOM(string ypzlbh)
        {
            dsorderBOM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select case ys1.YN when '0' then 'Invalid' when '1' then 'Valid' when '2' then 'Purchased' when '3' then 'QTY Changed' else 'X' end YN" +
                    ",ys1.YPZLBH,ys1.CLBH,case when rtrim(ISNULL(c.ywpm,'')) != '' then rtrim(c.ywpm) else rtrim(ct.ywpm) end ywpm" +
                    ",ys1.CLSL,ys1.QTY,z.zsjc,ys1.CSBH,ys1.ypmemo,ys1.YPOmemo " +
                    "from YPZLZLS1 ys1 " +
                    "left join clzl c on c.cldh=ys1.CLBH " +
                    "left join clzltemp ct on ct.tempddbh=ys1.CLBH " +
                    "left join zszl z on z.zsdh=ys1.CSBH " +
                    "where YPZLBH='{0}' order by ys1.CLBH", ypzlbh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsorderBOM, "採購量設定表");
                this.dgvOrderBOM.DataSource = dsorderBOM.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Query Order BOM Data Error!");
            }
        }

        #endregion

        #region 查詢樣品單材料入庫情況

        private void QuerySampleOrderDEF(string ypzlbh, string ypdh)
        {
            //dsSDEF = new DataSet();
            dsSDEF.Tables.Clear();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select ys2.YPDH,ys2.BWBH,ys2.CLBH" +
                    ",case when rtrim(ISNULL(c.ywpm,'')) != '' then rtrim(c.ywpm) else rtrim(ct.ywpm) end ywpm" +
                    ",ys2.CSBH,ys2.CLSL,ys2.QTY,cg.CGNO " +
                    "from YPZLZLS2 ys2 " +
                    "left join clzl c on c.cldh=ys2.CLBH " +
                    "left join clzltemp ct on ct.tempddbh=ys2.CLBH " +
                    "left join CGZLSS cg on cg.CLBH=ys2.CLBH and cg.ZLBH=ys2.YPDH " +
                    "where ys2.YPZLBH='{0}' and ys2.YPDH='{1}' order by ys2.BWBH"
                    , ypzlbh, ypdh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsSDEF, "樣品單材料入庫表");
                this.dgvSampleOrderDEF.DataSource = dsSDEF.Tables[0];
                this.dgvSampleOrderDEF.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Query SampleOrder DEF Data Error!");
            }
        }

        #endregion
        
        #region 查詢展開樣品單(開始計算)

        /// <summary>
        /// 計算時展開樣品單鞋型BOM
        /// </summary>
        /// <param name="ypdh">樣品單號</param>
        private void QuerySampleOrderExpansion(string ypdh)
        {
            dsexS2 = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select ys.XH,ys.BWBH,ys.CSBH,ys.CLBH,c.clzmlb,y.Quantity * ys.CLSL * (1 + (ys.LOSS * 0.01)) afterclsl,ys.CLSL,y.Quantity,ys.LOSS " +
                    "from YPZLS ys " +
                    "left join YPZL y on y.YPDH=ys.YPDH " +
                    "left join clzl c on c.cldh=ys.CLBH " +
                    "where ys.YPDH='{0}' order by ys.XH", ypdh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsexS2, "樣品單展開表");
                DataTable dt = dsexS2.Tables["樣品單展開表"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // 開始計算寫入S2
                    CountExpansionSampleOrder(tbMergerNo.Text, ypdh, dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), "zzzzzzzzzz", dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString());
                }
            }
            catch (Exception)
            {
                S2isExpansionSuccess = false;
                MessageBox.Show("Query SampleOrder Expansion Data Error!");
            }
        }

        #endregion

        #endregion

        #region 合併單當月最大值(新增觸發)

        private void BiggestYPZLBH()
        {
            dsM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select top 1 YPZLBH from YPZLZL where YPZLBH like '{0}%' order by YPZLBH desc"
                    , DateTime.Today.ToString("yyyyMM"));
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsM, "併單當月最大值");
                int count = Convert.ToInt32(dsM.Tables[0].Rows[0][0].ToString().Substring(6, 6)) + 1;
                biggestYPZLBH = DateTime.Today.ToString("yyyyMM") + count.ToString().PadLeft(6, '0');
            }
            catch (Exception)
            {
                biggestYPZLBH = DateTime.Today.ToString("yyyyMM") + "000001";
            }
        }

        #endregion

        #region 刷新樣品單的CGYPZLBH(計算時刷新)

        private void UpdateCGYPZLBH(string ypzlbh, string ypdh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update YPZL set CGYPZLBH='{0}' where YPDH='{1}'", ypzlbh, ypdh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Refresh CGYPZLBH Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 釋放樣品單的CGYPZLBH

        // 檢查計算日為空並超過建檔日三天時
        private void ReleaseCGYPZLBH()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                for (int i = 0; i < dgvSampleOrderList.Rows.Count; i++)
                {
                    string sql = string.Format("update YPZL set CGYPZLBH=null where YPDH='{0}'"
                        , dgvSampleOrderList.Rows[i].Cells[0].Value.ToString());
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    cmd.ExecuteNonQuery();
                }
                try
                {
                    string sqlcypzlzl = string.Format("update YPZLZL set YN='0' where YPZLBH='{0}'"
                        , tbMergerNo.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cancel YPZLZL Status Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Release CGYPZLBH Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        // 選擇樣品單葉面刪除樣品單時
        private void ReleaseCGYPZLBH(string ypdh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update YPZL set CGYPZLBH=null where YPDH='{0}'"
                    , ypdh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Release CGYPZLBH Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region DGV判斷是否可編輯的欄位

        // 採購量設定
        private void dgvOrderBOM_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 新增方法
        
        #region 新增合併單

        private void InsertMerger()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tcMergerOrder.SelectedIndex == 0) // 合併單
                {
                    BiggestYPZLBH(); // 最大值
                    string sqlmain = string.Format("insert into YPZLZL (YPZLBH,INSDATE,KFJD,JiJie,USERID,USERDATE,YN,PD,memo,gsbh) " +
                        "values ('{0}','{1}',{2},{3},'{4}','{5}',1,'P',{6},'')"
                        , biggestYPZLBH, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), mstage == "" ? "null" : "'" + mstage + "'", mseason == "" ? "null" : "'" + mseason + "'"
                        , USERID, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), mmemo == "" ? "null" : "'" + mmemo + "'");
                    SqlCommand cmd = new SqlCommand(sqlmain, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Insert MergerOrder Success!");
                    }
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

        #region 計算YPZLZLS2樣品單部位

        /// <summary>
        /// 計算YPZLZLS2樣品單部位
        /// </summary>
        /// <param name="ypzlbh">樣品合併號</param>
        /// <param name="ypdh">樣品單號</param>
        /// <param name="bwbh">部位編號</param>
        /// <param name="csbh">廠商編號</param>
        /// <param name="mjbh">母材料編號</param>
        /// <param name="clbh">材料編號</param>
        /// <param name="zmlb">是否子母材料</param>
        /// <param name="afterclsl">計算用量結果</param>
        /// <param name="orgclsl">鞋型BOM原始用量</param>
        /// <param name="orgquantity">樣品單原始雙數</param>
        /// <param name="orgloss">鞋型BOM原始LOSS%</param>
        private void CountExpansionSampleOrder(string ypzlbh, string ypdh, string bwbh, string csbh, string mjbh, string clbh, string zmlb, string afterclsl, string orgclsl, string orgquantity, string orgloss)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (zmlb != "Y")
                {
                    double usage = Convert.ToDouble(afterclsl) / Convert.ToDouble(orgquantity);
                    string sqlex = string.Format("insert into YPZLZLS2 (YPZLBH,YPDH,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,QTY,USAGE,USERID,USERDATE,YN) " +
                        "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','zzzzzz',{7},0,{8},'{9}',getdate(),'Y')"
                        , ypzlbh, ypdh, bwbh, csbh, mjbh, clbh, zmlb, afterclsl, usage, USERID);
                    SqlCommand cmd = new SqlCommand(sqlex, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        S2isExpansionSuccess = true;
                    }
                }
                else if (zmlb == "Y")
                {
                    try
                    {
                        if (dsexS2.Tables.Count > 1)
                        {
                            dsexS2.Tables[1].Clear();
                        }
                        string sqlclzhzl = string.Format("select zsdh,cldh_S,syl from clzhzl " +
                        "where cldh_M='{0}' and PM_ID='ZZZZ'", clbh);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlclzhzl, dbconn.connection);
                        adapter.Fill(dsexS2, "子材料展開表");
                        DataTable dt2 = dsexS2.Tables["子材料展開表"];
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            double s2clsl = Convert.ToDouble(afterclsl) * Convert.ToDouble(dt2.Rows[i][2]);
                            double usage2 = s2clsl / Convert.ToDouble(orgquantity);
                            string sqlclzhzlinsert = string.Format("insert into " +
                                "YPZLZLS2 (YPZLBH,YPDH,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,QTY,USAGE,USERID,USERDATE,YN) " +
                                "values ('{0}','{1}','{2}','{3}','{4}','{5}','N','zzzzzz',{6},0,{7},'{8}',getdate(),'Y')"
                                , ypzlbh, ypdh, bwbh, dt2.Rows[i][0].ToString(), clbh, dt2.Rows[i][1].ToString(), s2clsl, usage2, USERID);
                            SqlCommand cmd2 = new SqlCommand(sqlclzhzlinsert, dbconn.connection);
                            dbconn.OpenConnection();
                            int result2 = cmd2.ExecuteNonQuery();
                            if (result2 > 0)
                            {
                                S2isExpansionSuccess = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        S2isExpansionSuccess = false;
                        MessageBox.Show("Expansion Insert(CLZHZL) Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                S2isExpansionSuccess = false;
                MessageBox.Show("Expansion Insert(YPZLZLS2) Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 加總YPZLZLS2用量(YPZLZLS1)

        /// <summary>
        /// 加總用量方法(YPZLZLS1)
        /// </summary>
        /// <param name="ypzlbh">樣品合併號</param>
        private void SumSampleOrderDosage(string ypzlbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                QueryOrderBOM(tbMergerNo.Text);
                bool isrecount = false;
                string sqlsum = null;
                if (dgvOrderBOM.Rows.Count == 0)
                {
                    isrecount = false;
                    sqlsum = string.Format("insert into YPZLZLS1 (YPZLBH,CLBH,CSBH,CLSL,QTY,USERID,USERDATE,YN) " +
                    "select '{0}',a.CLBH,a.CSBH,a.CLSL,a.CLSL,'{1}',getdate(),'1' " +
                    "from (select CLBH,CSBH,sum(CLSL) CLSL from YPZLZLS2 where YPZLBH='{2}' group by CSBH,CLBH) a " +
                    "order by a.CLBH"
                    , ypzlbh, USERID, ypzlbh);
                }
                else
                {
                    isrecount = true;
                    sqlsum = string.Format("create table #vtable (rn int,CLBH varchar(10),CSBH varchar(4),CLSL numeric(18,4)) " +
                        // 虛擬表
                        // 新加總與原始S1比較(列出有差異的資料並放入虛擬表)
                        "insert into #vtable " +
                        "select ROW_NUMBER() OVER(ORDER BY result.CLBH) rn,* from (" +
                        "select CLBH,CSBH,sum(CLSL) CLSL from YPZLZLS2 where YPZLBH='{0}' group by CSBH,CLBH " +
                        "except select CLBH,CSBH,CLSL from YPZLZLS1 where YPZLBH='{1}') result " +
                        // 跑迴圈
                        "declare @i int,@max int set @i=1 select @max=count(vt.rn) from #vtable vt " +
                        "while(@i<=@max) begin " +
                        // 各列資料附值
                        "declare @clbh varchar(10),@csbh varchar(4),@clsl numeric(18,4) " +
                        "select @clbh=vt.CLBH,@csbh=vt.CSBH,@clsl=vt.CLSL from #vtable vt where vt.rn=@i " +
                        // 檢查是否存在(存在:更新, 不存在:新增)
                        "if exists(select * from YPZLZLS1 where YPZLBH='{2}' and CLBH=@clbh and CSBH=@csbh) " +
                        "begin update YPZLZLS1 set CLSL=@clsl,USERDATE=GETDATE() where YPZLBH='{3}' and CLBH=@clbh and CSBH=@csbh " +
                        "update YPZLZLS1 set ypmemo=(select f.memo from(select YPZLBH,(select '/'+YPDH from YPZLZLS2 T2 where T2.YPZLBH = T1.YPZLBH and CLBH=@clbh and CSBH=@csbh group by YPDH for xml path('')) as memo from YPZLZLS2 T1 where YPZLBH='{4}' group by YPZLBH) f)where YPZLBH='{5}' and CLBH=@clbh and CSBH=@csbh " +
                        "end " +
                        "else " +
                        "begin insert into YPZLZLS1 (YPZLBH,CLBH,CSBH,CLSL,QTY,USERID,USERDATE,YN) values('{6}',@clbh,@csbh,@clsl,@clsl,'{7}',getdate(),'1') " +
                        "update YPZLZLS1 set ypmemo=(select f.memo from(select YPZLBH,(select '/'+YPDH from YPZLZLS2 T2 where T2.YPZLBH = T1.YPZLBH and CLBH=@clbh and CSBH=@csbh group by YPDH for xml path('')) as memo from YPZLZLS2 T1 where YPZLBH='{8}' group by YPZLBH) f)where YPZLBH='{9}' and CLBH=@clbh and CSBH=@csbh " +
                        "end " +
                        "set @i=@i+1 " +
                        "end drop table #vtable"
                        , ypzlbh, ypzlbh, ypzlbh, ypzlbh, ypzlbh, ypzlbh, ypzlbh, USERID, ypzlbh, ypzlbh);
                }
                SqlCommand cmd = new SqlCommand(sqlsum, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    QueryOrderBOM(tbMergerNo.Text);
                    if (!isrecount)
                    {
                        for (int i = 0; i < dsorderBOM.Tables["採購量設定表"].Rows.Count; i++)
                        {
                            string sqlypmemo = string.Format("select distinct YPDH from YPZLZLS2 where YPZLBH='{0}' and CLBH='{1}' and CSBH='{2}'"
                                , dsorderBOM.Tables["採購量設定表"].Rows[i][1].ToString(), dsorderBOM.Tables["採購量設定表"].Rows[i][2].ToString(), dsorderBOM.Tables["採購量設定表"].Rows[i][7].ToString());
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlypmemo, dbconn.connection);
                            adapter.Fill(dsorderBOM, "S2樣品單展開");
                            for (int j = 0; j < dsorderBOM.Tables["S2樣品單展開"].Rows.Count; j++)
                            {
                                if (dsorderBOM.Tables["S2樣品單展開"].Rows.Count > 1)
                                {
                                    ypmemo = ypmemo + "/" + dsorderBOM.Tables["S2樣品單展開"].Rows[j][0].ToString();
                                }
                                else if (dsorderBOM.Tables["S2樣品單展開"].Rows.Count == 1)
                                {
                                    ypmemo = "/" + dsorderBOM.Tables["S2樣品單展開"].Rows[j][0].ToString();
                                }
                            }
                            dsorderBOM.Tables["S2樣品單展開"].Clear();
                            // 刷新ypmemo
                            string sqluypmemo = string.Format("update YPZLZLS1 set ypmemo='{0}' where YPZLBH='{1}' and CLBH='{2}' and CSBH='{3}'"
                                , ypmemo, dsorderBOM.Tables["採購量設定表"].Rows[i][1].ToString(), dsorderBOM.Tables["採購量設定表"].Rows[i][2].ToString(), dsorderBOM.Tables["採購量設定表"].Rows[i][7].ToString());
                            SqlCommand cmdup = new SqlCommand(sqluypmemo, dbconn.connection);
                            dbconn.OpenConnection();
                            cmdup.ExecuteNonQuery();
                            ypmemo = "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SUM Insert(YPZLZLS1) Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        } 

        #endregion

        #endregion
        
        #region 編輯方法

        private void ModifyMerger()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tcMergerOrder.SelectedIndex == 0) // 合併單
                {
                    string sql = string.Format("update YPZLZL set JiJie={0},memo={1},USERID='{2}',USERDATE='{3}' " +
                        "where YPZLBH='{4}'"
                        , mseason == "" ? "null" : "'" + mseason + "'", mmemo == "" ? "null" : "'" + mmemo + "'"
                        , USERID, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), oypzlbh);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Modify Success!");
                        QueryMergerOrder(oypzlbh, mstage, mseason);
                    }
                }
                else if (tcMergerOrder.SelectedIndex == 1) // 樣品單選擇(計算按鈕觸發) 更新計算日子
                {
                    string sql = string.Format("update YPZLZL set CALDATE=GETDATE() " +
                        "where YPZLBH='{0}'", oypzlbh);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        // 刷新計算日期
                        QueryMergerOrder(oypzlbh, mstage, mseason);
                        tbLastComputeDate.Text = dgvMergerOrder.CurrentRow.Cells[4].Value.ToString();
                    }
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

        #region 採購量設定

        #region 判斷採購量設定DataSet列狀態

        /// <summary>
        /// 判斷採購量設定 dataset列狀態
        /// </summary>
        /// <param name="dtr">目標dataset</param>
        private void dgvOrderBOMRowState(DataTable dtr)
        {
            if (tsbIsInsertOrModify == "Modify") // 修改模式
            {
                try
                {
                    for (int i = 0; i < dtr.Rows.Count; i++)
                    {
                        if (dtr.Rows[i].RowState.ToString() == "Modified")
                        {
                            ModifyDevRemark(dgvOrderBOM.Rows[i].Cells[5].Value.ToString(), dgvOrderBOM.Rows[i].Cells[1].Value.ToString(), dgvOrderBOM.Rows[i].Cells[2].Value.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Modify Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 更新採購量設定

        private void ModifyDevRemark(string qty, string ypzlbh, string clbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update YPZLZLS1 set QTY={0} " +
                    "where YPZLBH='{1}' and CLBH='{2}'"
                    , qty, ypzlbh, clbh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Remark Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion
        
        #region 刪除方法

        /// <summary>
        /// 刪除按鈕觸發
        /// </summary>
        private void DeleteMergerOrder()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tcMergerOrder.SelectedIndex == 0) // 合併單
                {
                    DialogResult dr = MessageBox.Show("Delete : " + oypzlbh + " This MergerOrder?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("update YPZLZL set YN=0 where YPZLBH='{0}' " +
                            "update YPZLZLS set YN='0' where YPZLBH='{1}' " +
                            "update YPZLZLS1 set YN='0' where YPZLBH='{2}' " +
                            "update YPZLZLS2 set YN='N' where YPZLBH='{3}'"
                            , oypzlbh, oypzlbh, oypzlbh, oypzlbh);
                        SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            QueryMergerSampleOrder(oypzlbh);
                            try
                            {
                                for (int i = 0; i < dsMS.Tables[0].Rows.Count; i++)
                                {
                                    string sqlre = string.Format("update YPZL set CGYPZLBH=null where YPDH='{0}'"
                                        , dsMS.Tables[0].Rows[i][0]);
                                    SqlCommand cmd2 = new SqlCommand(sqlre, dbconn.connection);
                                    cmd2.ExecuteNonQuery();
                                }
                                MessageBox.Show("Delete Success!");
                                QueryMergerOrder("", mstage, mseason);
                                QueryMergerSampleOrder(oypzlbh);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Delete MergerOrder Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                else if (tcMergerOrder.SelectedIndex == 1) // 樣品單選擇
                {
                    DialogResult dr = MessageBox.Show("Delete : " + dgvSampleOrderList.CurrentRow.Cells[0].Value + " This Sample Order?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            string sql = string.Format("delete YPZLZLS where YPZLBH='{0}' and YPDH='{1}'"
                                , tbMergerNo.Text, dgvSampleOrderList.CurrentRow.Cells[0].Value.ToString());
                            SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                            dbconn.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                isdeletesample = true;
                                ReleaseCGYPZLBH(dgvSampleOrderList.CurrentRow.Cells[0].Value.ToString()); // 釋放CGYPZLBH
                                QueryMergerSampleOrder(oypzlbh); // 重新綁定
                                if (dgvSampleOrderList.RowCount > 0 && tbLastComputeDate.Text != "")
                                {
                                    btnCompute.PerformClick(); // 重新計算
                                }
                                else
                                {
                                    string sql2 = string.Format("delete YPZLZLS1 where YPZLBH='{0}' " +
                                        "delete YPZLZLS2 where YPZLBH='{1}'", oypzlbh, oypzlbh);
                                    SqlCommand cmd2 = new SqlCommand(sql2, dbconn.connection);
                                    int r = cmd2.ExecuteNonQuery();
                                    if (r > 0)
                                    {
                                        MessageBox.Show("Sample Order Delete Success!");
                                        dgvOrderBOM.DataSource = null;
                                        dgvSampleOrderDEF.DataSource = null;
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sample Order Delete Error!");
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
                dbconn.CloseConnection();
            }
        }

        /// <summary>
        /// 重新計算要先刪除YPZLZLS2資料
        /// </summary>
        private void DeleteYPZLZLS2BeforeCount(string ypzlbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("delete from YPZLZLS2 where YPZLBH='{0}'", ypzlbh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Delete YPZLZLS2(Before Counting) Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
