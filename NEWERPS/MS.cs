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
    /// MoldSet 工制具設定
    /// </summary>
    public partial class MS : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        DataSet dsbiggest = new DataSet();
        public string USERID;
        private string tsbIsInsertOrModify;
        private string size; // 尺寸明細DGV儲存變數
        private string toolno, toolclass; //模號,類別
        private string mjlb2; // 模具短碼

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MS";

        #endregion

        #region 構造函式

        public MS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MoldSet_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            GetCombobox();

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 外層按鈕事件

        #region 外層TabControl頁面更換事件

        private void tcMoldSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMoldSet.SelectedIndex == 0)
            {
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
            }
            else if (tcMoldSet.SelectedIndex == 1)
            {
                if (tbToolNo.Text != "")
                {
                    tsbDelete.Enabled = true;
                    tsbModify.Enabled = true;
                }
            }
        }

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcMoldSet.SelectedIndex != 0)
            {
                tcMoldSet.SelectedIndex = 0;
            }
            else if (dgvMoldSetData.DataSource == null || tcMoldSet.SelectedIndex == 0)
            {
                MSD msd = new MSD();
                msd.ShowDialog();
                if (msd.isq)
                {
                    MoldClassDataQuery(msd.工具模號, msd.工具類別);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            ClearTextbox();
            tcMoldSet.SelectedIndex = 1;
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

        #region DGV單點擊事件

        private void dgvMoldSetData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ToControls();
        } 

        #endregion

        #region DGV雙點擊事件

        private void dgvMoldSetData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ToControls();
            tcMoldSet.SelectedIndex = 1;
        }

        #endregion
        
        #region 保存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert") // 新增
                {
                    ToolClassmjlb2(); // 短碼最大值
                    InsertMoldClassData(mjlb2);
                }
                else // 修改
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

        #endregion

        #region 工具尺寸明細事件

        #region 尺寸DGV點擊事件

        private void dgvSizeDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnModify.Enabled = true;
            size = dgvSizeDetail.CurrentRow.Cells[0].Value.ToString();
        }

        #endregion

        #region 新增按鈕事件

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MSSD mssd = new MSSD();
            mssd.selectID = 0; // 新增
            mssd.工具模號 = tbToolNo.Text;
            mssd.工具類別 = cbToolClass.Text;
            mssd.ShowDialog();
            QuerySizeDetail();
        }

        #endregion

        #region 刪除按鈕事件

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSizeDetail();
        }

        #endregion

        #region 編輯按鈕事件

        private void btnModify_Click(object sender, EventArgs e)
        {
            MSSD mssd = new MSSD();
            mssd.selectID = 1; // 修改
            mssd.工具模號 = tbToolNo.Text;
            mssd.工具類別 = cbToolClass.Text;
            mssd.尺寸 = this.size;
            mssd.ShowDialog();
            QuerySizeDetail();
        }

        #endregion

        #endregion

        #region 內層TabControl頁面更換事件

        private void tcMoldInformationDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMoldInformationDetail.SelectedIndex == 1)
            {
                tsbClear.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
            }
            else
            {
                tsbInsert.Enabled = true;
                if (tbToolNo.Text != "")
                {
                    tsbClear.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbDelete.Enabled = true;
                }
            }
        }

        #endregion

        #region 200面刀編碼原則彈出視窗事件

        private void tbToolNo_Click(object sender, EventArgs e)
        {
            if (cbToolClass.Text == "200")
            {
                MS200 msep = new MS200();
                msep.ShowDialog();
                tbToolNo.Text = msep.code;
            }
        }

        #endregion

        #region 下拉選單改變事件(工具類別)
        
        private void cbToolClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbToolClass.SelectedIndex == -1)
            {
                tbToolNameCN.Text = "";
            }
            else
            {
                tbToolNameCN.Text = cbToolClass.SelectedValue.ToString();
            }
            if (cbToolClass.Text == "101")
            {
                L0023.Visible = true;
                cbFom.Visible = true;
                GetFomCombobox();
            }
            else
            {
                L0023.Visible = false;
                cbFom.Visible = false;
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
                L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                L0012.Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                L0013.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                L0014.Text = dgvWord.Rows[13].Cells[3].Value.ToString();
                L0015.Text = dgvWord.Rows[14].Cells[3].Value.ToString();
                L0016.Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                L0017.Text = dgvWord.Rows[16].Cells[3].Value.ToString();
                L0018.Text = dgvWord.Rows[17].Cells[3].Value.ToString();
                L0019.Text = dgvWord.Rows[18].Cells[3].Value.ToString();
                L0020.Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                L0021.Text = dgvWord.Rows[20].Cells[3].Value.ToString();
                L0022.Text = dgvWord.Rows[21].Cells[3].Value.ToString();
                L0023.Text = dgvWord.Rows[22].Cells[3].Value.ToString();
                L0024.Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                L0025.Text = dgvWord.Rows[24].Cells[3].Value.ToString();
                L0026.Text = dgvWord.Rows[25].Cells[3].Value.ToString();
                L0027.Text = dgvWord.Rows[26].Cells[3].Value.ToString();
                L0028.Text = dgvWord.Rows[27].Cells[3].Value.ToString();
                L0029.Text = dgvWord.Rows[28].Cells[3].Value.ToString();
                L0030.Text = dgvWord.Rows[29].Cells[3].Value.ToString();
                L0031.Text = dgvWord.Rows[30].Cells[3].Value.ToString();
                L0032.Text = dgvWord.Rows[31].Cells[3].Value.ToString();
                L0033.Text = dgvWord.Rows[32].Cells[3].Value.ToString();
                L0034.Text = dgvWord.Rows[33].Cells[3].Value.ToString();
                L0035.Text = dgvWord.Rows[34].Cells[3].Value.ToString();
                L0036.Text = dgvWord.Rows[35].Cells[3].Value.ToString();
                L0037.Text = dgvWord.Rows[36].Cells[3].Value.ToString();
                L0038.Text = dgvWord.Rows[37].Cells[3].Value.ToString();
                L0039.Text = dgvWord.Rows[38].Cells[3].Value.ToString();
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
                tsbClear.Enabled = true;
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
                tbToolNo.Enabled = true;
                cbToolClass.Enabled = true;
                if (tcMoldInformationDetail.SelectedIndex == 0) // 基本資料
                {
                    tbRefStyle.Enabled = true;
                    cbUseClient.Enabled = true;
                    cbCountry.Enabled = true;
                    cbMoldVendor.Enabled = true;
                    tbMoldingFactory.Enabled = true;
                    cbProduceVendor.Enabled = true;
                    tbProduceFactory.Enabled = true;
                    tbMoldingDate.Enabled = true;
                    tbMoldingExpected.Enabled = true;
                    tbMoldingActual.Enabled = true;
                    tbBMSMoldingDate.Enabled = true;
                    tbBMSMoldingExpected.Enabled = true;
                    tbBMSMoldingActual.Enabled = true;
                    tbFullMoldingDate.Enabled = true;
                    tbFullMoldingExpected.Enabled = true;
                    tbFullMoldingActual.Enabled = true;
                    tbCounter.Enabled = true;
                    cbFom.Enabled = true;
                    tbRemark.Enabled = true;
                }
                else if (tcMoldInformationDetail.SelectedIndex == 2) // 模攤費用
                {
                    tbMoldQTY.Enabled = true;
                    tbCurrency.Enabled = true;
                    tbMoldTotalPrice.Enabled = true;
                    tbNonAmortization.Enabled = true;
                    tbAmortization.Enabled = true;
                    tbAmortizationDBL.Enabled = true;
                    tbPriceStart.Enabled = true;
                    tbPriceEnd.Enabled = true;
                    tbAmortizationUP.Enabled = true;
                    tbConfirmPrice.Enabled = true;
                }
            }
            else // 關
            {
                tbToolNo.Enabled = false;
                cbToolClass.Enabled = false;
                if (tcMoldInformationDetail.SelectedIndex == 0) // 基本資料
                {
                    tbRefStyle.Enabled = false;
                    cbUseClient.Enabled = false;
                    cbCountry.Enabled = false;
                    cbMoldVendor.Enabled = false;
                    tbMoldingFactory.Enabled = false;
                    cbProduceVendor.Enabled = false;
                    tbProduceFactory.Enabled = false;
                    tbMoldingDate.Enabled = false;
                    tbMoldingExpected.Enabled = false;
                    tbMoldingActual.Enabled = false;
                    tbBMSMoldingDate.Enabled = false;
                    tbBMSMoldingExpected.Enabled = false;
                    tbBMSMoldingActual.Enabled = false;
                    tbFullMoldingDate.Enabled = false;
                    tbFullMoldingExpected.Enabled = false;
                    tbFullMoldingActual.Enabled = false;
                    tbCounter.Enabled = false;
                    cbFom.Enabled = false;
                    tbRemark.Enabled = false;
                }
                else if (tcMoldInformationDetail.SelectedIndex == 2) // 模攤費用
                {
                    tbMoldQTY.Enabled = false;
                    tbCurrency.Enabled = false;
                    tbMoldTotalPrice.Enabled = false;
                    tbNonAmortization.Enabled = false;
                    tbAmortization.Enabled = false;
                    tbAmortizationDBL.Enabled = false;
                    tbPriceStart.Enabled = false;
                    tbPriceEnd.Enabled = false;
                    tbAmortizationUP.Enabled = false;
                    tbConfirmPrice.Enabled = false;
                }
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbToolNo.Text.Trim().Length == 0 && cbToolClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("必須輸入工具模號與類別!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion
        
        #region 下拉選單顯示(工具類別,使用客戶,國別,模具廠商,生產廠商 / 楦頭)

        private void GetCombobox()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 工具類別
                string sql1 = "select distinct g.gjlb,lb.zwsm from gjzl g left join gjlbzl lb on lb.gjlb=g.gjlb order by g.gjlb";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "工具類別表");
                cbToolClass.DataSource = ds.Tables[0];
                cbToolClass.ValueMember = "zwsm";
                cbToolClass.DisplayMember = "gjlb";
                cbToolClass.SelectedIndex = -1;

                // 使用客戶
                string sql2 = "select kfdh,kfjc from kfzl";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(ds, "使用客戶表");
                cbUseClient.DataSource = ds.Tables[1];
                cbUseClient.ValueMember = "kfdh";
                cbUseClient.DisplayMember = "kfjc";
                cbUseClient.SelectedIndex = -1;

                // 尺寸國別
                string sql3 = "select SIZE_ID,SIZE_Name from CSSize";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn.connection);
                adapter3.Fill(ds, "尺寸國別表");
                cbCountry.DataSource = ds.Tables[2];
                cbCountry.ValueMember = "SIZE_ID";
                cbCountry.DisplayMember = "SIZE_Name";
                cbCountry.SelectedIndex = -1;

                // 模具廠商
                string sql4 = "select zsdh,zsjc from zszl";
                SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn.connection);
                adapter4.Fill(ds, "模具廠商表");
                cbMoldVendor.DataSource = ds.Tables[3];
                cbMoldVendor.ValueMember = "zsdh";
                cbMoldVendor.DisplayMember = "zsjc";
                cbMoldVendor.SelectedIndex = -1;

                // 生產廠商
                string sql5 = "select zsdh,zsjc from zszl";
                SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn.connection);
                adapter5.Fill(ds, "生產廠商表");
                cbProduceVendor.DataSource = ds.Tables[4];
                cbProduceVendor.ValueMember = "zsdh";
                cbProduceVendor.DisplayMember = "zsjc";
                cbProduceVendor.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Combobox Error!");
            }
        }

        private void GetFomCombobox()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 楦頭
                string sql1 = "select counter1,gjmh from gjzl where gjlb='100' order by gjmh";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "楦頭表");
                cbFom.DataSource = ds.Tables[0];
                cbFom.ValueMember = "counter1";
                cbFom.DisplayMember = "gjmh";
            }
            catch (Exception)
            {
                MessageBox.Show("Fom Combobox Error!");
            }
        }

        #endregion

        #region 工具類別判斷最大值方法(mjlb2編號)

        private void ToolClassmjlb2()
        {
            dsbiggest = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (cbToolClass.Text == "100") // 楦頭
                {
                    // 楦頭編號最大值
                    try
                    {
                        string sql1 = "select top 1 Mjlb2 from gjzl where gjlb='100' order by Mjlb2 desc";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                        adapter1.Fill(dsbiggest, "楦頭編碼最大值");
                        mjlb2 = (Convert.ToInt32(dsbiggest.Tables[0].Rows[0][0]) + 1).ToString().PadLeft(2, '0');
                    }
                    catch (Exception)
                    {
                        mjlb2 = "00";
                    }
                }
                else if (cbToolClass.Text == "101") // 大底模
                {
                    // 大底模編號最大值
                    try
                    {
                        string sql1 = "select top 1 Mjlb2 from gjzl where gjlb='101' order by Mjlb2 desc";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                        adapter1.Fill(dsbiggest, "大底模編碼最大值");
                        mjlb2 = (Convert.ToInt32(dsbiggest.Tables[0].Rows[0][0]) + 1).ToString().PadLeft(2, '0');
                    }
                    catch (Exception)
                    {
                        mjlb2 = "00";
                    }
                }
                else if (cbToolClass.Text == "200") // 面刀
                {
                    // 面刀模編號最大值
                    try
                    {
                        string sql1 = "select top 1 Mjlb2 from gjzl where gjlb='200' order by Mjlb2 desc";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                        adapter1.Fill(dsbiggest, "面刀模編碼最大值");
                        //ACSII A=65 > Z=90
                        char ones = Convert.ToChar(dsbiggest.Tables[0].Rows[0][0].ToString().Substring(1, 1)); // 個
                        char tens = Convert.ToChar(dsbiggest.Tables[0].Rows[0][0].ToString().Substring(0, 1)); // 十
                        int R = Convert.ToInt32(Convert.ToByte(ones)); // 個
                        int L = Convert.ToInt32(Convert.ToByte(tens)); // 十
                        R++;
                        if (R > 90)
                        {
                            R = 65;
                            L++;
                        }
                        mjlb2 = Convert.ToChar(L).ToString() + Convert.ToChar(R).ToString();
                    }
                    catch (Exception)
                    {
                        mjlb2 = "AA";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tool Class Biggest Error");
            }
        }

        #endregion

        #region 附值速查內容方法

        private void ToControls()
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            tbToolNo.Text = dgvMoldSetData.CurrentRow.Cells[0].Value.ToString();
            toolno = dgvMoldSetData.CurrentRow.Cells[0].Value.ToString();
            cbToolClass.Text = dgvMoldSetData.CurrentRow.Cells[1].Value.ToString();
            toolclass = dgvMoldSetData.CurrentRow.Cells[1].Value.ToString();
            tbToolNameCN.Text = dgvMoldSetData.CurrentRow.Cells[2].Value.ToString();
            tbRefStyle.Text = dgvMoldSetData.CurrentRow.Cells[3].Value.ToString();
            cbUseClient.SelectedValue = dgvMoldSetData.CurrentRow.Cells[4].Value.ToString();
            cbCountry.SelectedValue = dgvMoldSetData.CurrentRow.Cells[5].Value.ToString() == "" ? "" : dgvMoldSetData.CurrentRow.Cells[5].Value.ToString();
            cbMoldVendor.SelectedValue = dgvMoldSetData.CurrentRow.Cells[6].Value.ToString();
            tbMoldingFactory.Text = dgvMoldSetData.CurrentRow.Cells[7].Value.ToString();
            cbProduceVendor.SelectedValue = dgvMoldSetData.CurrentRow.Cells[8].Value.ToString();
            tbProduceFactory.Text = dgvMoldSetData.CurrentRow.Cells[9].Value.ToString();
            //日期
            tbMoldingDate.Text = dgvMoldSetData.CurrentRow.Cells[10].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[10].Value.ToString().Substring(0, 10);
            tbMoldingExpected.Text = dgvMoldSetData.CurrentRow.Cells[11].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[11].Value.ToString().Substring(0, 10);
            tbMoldingActual.Text = dgvMoldSetData.CurrentRow.Cells[12].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[12].Value.ToString().Substring(0, 10);
            tbBMSMoldingDate.Text = dgvMoldSetData.CurrentRow.Cells[13].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[13].Value.ToString().Substring(0, 10);
            tbBMSMoldingExpected.Text = dgvMoldSetData.CurrentRow.Cells[14].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[14].Value.ToString().Substring(0, 10);
            tbBMSMoldingActual.Text = dgvMoldSetData.CurrentRow.Cells[15].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[15].Value.ToString().Substring(0, 10);
            tbFullMoldingDate.Text = dgvMoldSetData.CurrentRow.Cells[16].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[16].Value.ToString().Substring(0, 10);
            tbFullMoldingExpected.Text = dgvMoldSetData.CurrentRow.Cells[17].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[17].Value.ToString().Substring(0, 10);
            tbFullMoldingActual.Text = dgvMoldSetData.CurrentRow.Cells[18].Value.ToString().Length == 0 ? "" : dgvMoldSetData.CurrentRow.Cells[18].Value.ToString().Substring(0, 10);
            tbCounter.Text = dgvMoldSetData.CurrentRow.Cells[19].Value.ToString();
            cbFom.Text = dgvMoldSetData.CurrentRow.Cells[20].Value.ToString();
            tbRemark.Text = dgvMoldSetData.CurrentRow.Cells[21].Value.ToString();
            tbMoldQTY.Text = dgvMoldSetData.CurrentRow.Cells[22].Value.ToString();
            tbCurrency.Text = dgvMoldSetData.CurrentRow.Cells[23].Value.ToString();
            tbMoldTotalPrice.Text = dgvMoldSetData.CurrentRow.Cells[24].Value.ToString();
            tbPriceStart.Text = dgvMoldSetData.CurrentRow.Cells[25].Value.ToString();
            tbPriceEnd.Text = dgvMoldSetData.CurrentRow.Cells[26].Value.ToString();
            tbNonAmortization.Text = dgvMoldSetData.CurrentRow.Cells[27].Value.ToString();
            tbAmortization.Text = dgvMoldSetData.CurrentRow.Cells[28].Value.ToString();
            tbAmortizationDBL.Text = dgvMoldSetData.CurrentRow.Cells[29].Value.ToString();
            tbAmortizationUP.Text = dgvMoldSetData.CurrentRow.Cells[30].Value.ToString();
            tbConfirmPrice.Text = dgvMoldSetData.CurrentRow.Cells[31].Value.ToString();
            QuerySizeDetail();
        }

        #endregion

        #region 查詢工制具設定方法(速查)

        private void MoldClassDataQuery(string toolno, string toolclass)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select g.gjmh 工具模號,g.gjlb 工具類別,lb.zwsm 中文說明" +
                    ",g.ckxx 參考鞋型,g.kfdh 使用客戶,g.gb 國別" +
                    ",g.zsdh 模具廠商,g.cqdh 開模廠區,g.zsdh1 生產廠商,g.cqdh1 生產廠區" +
                    ",g.kmrq 開模日期,g.kmrq_1 預計完成日期,g.kmrq_2 實際完成日期" +
                    ",g.kmrq1 大中小開模日期,g.kmrq1_1 預計完成日期,g.kmrq1_2 實際完成日期" +
                    ",g.kmrq2 全套開模日期,g.kmrq2_1 預計完成日期,g.kmrq2_2 實際完成日期" +
                    ",g.counter counter#,g.counter1 楦頭類別,g.bz 備註" + 
                    // 分攤
                    ",g.mjzs 模具總數,g.mjbb 幣別,g.Mtgr 模具總價,g.kfftdqr 分攤開始日,g.zsftdqr 分攤結束日" +
                    ",g.mjf1 不攤金額,g.mjf 攤提金額,g.kfss 攤提雙數,g.kfdj 攤提單價,g.zsdj 確認攤價 " +
                    "from gjzl g " +
                    "left join gjlbzl lb on lb.gjlb=g.gjlb " +
                    "where g.gjmh like '{0}%' and g.gjlb like '{1}%'"
                    , toolno, toolclass);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "工制具設定表");
                this.dgvMoldSetData.DataSource = this.ds.Tables[0];
                for(int i = 7; i <= 31; i++)
                {
                    this.dgvMoldSetData.Columns[i].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Query Error!");
            }
        }

        #endregion

        #region 新增工制具設定方法

        private void InsertMoldClassData(string mjlb2)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 0工具模號gjmh 1工具類別gjlb 2參考鞋型ckxx 3使用客戶kfdh 4國別gb 5模具廠商zsdh 6開模廠商cqdh 7生產廠商cqdh 8生產廠區cqdh1
                // 9開模日期kmrq 10預計完成日期kmrq_1 11實際完成日期kmrq_2 12大中小開模日期kmrq1 13預計完成日期kmrq1_1 14實際完成日期kmrq1_2 15全套開模日期kmrq2 16預計完成日期kmrq2_1 17實際完成日期kmrq2_2
                // 18counter#counter 19楦頭類別counter1 20備註bz
                // 21模具總數mjzs 22幣別mjbb 23模具總價Mtgr 24分攤開始日kfftdqr 25分攤結束日zsftdqr
                // 26不攤金額mjf1 27攤提金額mjf 28攤提雙數kfss 29攤提單價kfdj 30確認攤價zsdj 31模具短碼
                string sql = string.Format("insert into gjzl" +
                    "(gjmh,gjlb,ckxx,kfdh,gb,zsdh,cqdh,zsdh1,cqdh1,kmrq,kmrq_1,kmrq_2,kmrq1,kmrq1_1,kmrq1_2,kmrq2,kmrq2_1,kmrq2_2,counter,counter1,bz,mjzs,mjbb,Mtgr,kfftdqr,zsftdqr,mjf1,mjf,kfss,kfdj,zsdj,Mjlb2) " +
                    "values('{0}','{1}','{2}',{3},{4},{5},'{6}',{7},'{8}'," +
                    "{9},{10},{11},{12},{13},{14},{15},{16},{17}," +
                    "'{18}',{19},'{20}'," +
                    "{21},'{22}',{23},'{24}','{25}'," +
                    "{26},{27},{28},{29},{30},'{31}')"
                    , tbToolNo.Text, cbToolClass.Text, tbRefStyle.Text, cbUseClient.SelectedIndex == -1 ? "NULL" : "'" + cbUseClient.SelectedValue + "'", cbCountry.Text == "" ? "NULL" : "'" + cbCountry.SelectedValue + "'", cbMoldVendor.SelectedIndex == -1 ? "NULL" : "'" + cbMoldVendor.SelectedValue + "'", tbMoldingFactory.Text, cbProduceVendor.SelectedIndex == -1 ? "NULL" : "'" + cbProduceVendor.SelectedValue + "'", tbProduceFactory.Text
                    , tbMoldingDate.Text == "" ? "null" : "'" + tbMoldingDate.Text + "'", tbMoldingExpected.Text == "" ? "null" : "'" + tbMoldingExpected.Text + "'", tbMoldingActual.Text == "" ? "null" : "'" + tbMoldingActual.Text + "'", tbBMSMoldingDate.Text == "" ? "null" : "'" + tbBMSMoldingDate.Text + "'", tbBMSMoldingExpected.Text == "" ? "null" : "'" + tbBMSMoldingExpected.Text + "'", tbBMSMoldingActual.Text == "" ? "null" : "'" + tbBMSMoldingActual.Text + "'", tbFullMoldingDate.Text == "" ? "null" : "'" + tbFullMoldingDate.Text + "'", tbFullMoldingExpected.Text == "" ? "null" : "'" + tbFullMoldingExpected.Text + "'", tbFullMoldingActual.Text == "" ? "null" : "'" + tbFullMoldingActual.Text + "'"
                    , tbCounter.Text, cbFom.Visible == false ? "null" : "'" + cbFom.Text + "'", tbRemark.Text
                    , tbMoldQTY.Text == "" ? "null" : tbMoldQTY.Text, tbCurrency.Text, tbMoldTotalPrice.Text == "" ? "null" : tbMoldTotalPrice.Text, tbPriceStart.Text, tbPriceEnd.Text
                    , tbNonAmortization.Text == "" ? "null" : tbNonAmortization.Text, tbAmortization.Text == "" ? "null" : tbAmortization.Text, tbAmortizationDBL.Text == "" ? "null" : tbAmortizationDBL.Text, tbAmortizationUP.Text == "" ? "null" : tbAmortizationUP.Text, tbConfirmPrice.Text == "" ? "null" : tbConfirmPrice.Text, mjlb2);
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

        #region 修改工制具設定方法

        private void ModifyMoldClassData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update gjzl " +
                    "set gjmh='{0}',gjlb='{1}',ckxx='{2}',kfdh={3},gb={4},zsdh={5},cqdh='{6}',zsdh1={7},cqdh1='{8}'," +
                    "kmrq={9},kmrq_1={10},kmrq_2={11},kmrq1={12},kmrq1_1={13},kmrq1_2={14},kmrq2={15},kmrq2_1={16},kmrq2_2={17}," +
                    "counter='{18}',counter1={19},bz='{20}'," +
                    "mjzs={21},mjbb='{22}',Mtgr={23},kfftdqr='{24}',zsftdqr='{25}'," +
                    "mjf1={26},mjf={27},kfss={28},kfdj={29},zsdj={30} " +
                    "where gjmh = '{31}' and gjlb = '{32}'"
                    , tbToolNo.Text, cbToolClass.Text, tbRefStyle.Text, cbUseClient.SelectedIndex == -1 ? "NULL" : "'" + cbUseClient.SelectedValue + "'", cbCountry.Text == "" ? "NULL" : "'" + cbCountry.SelectedValue + "'", cbMoldVendor.SelectedIndex == -1 ? "NULL" : "'" + cbMoldVendor.SelectedValue + "'", tbMoldingFactory.Text, cbProduceVendor.SelectedIndex == -1 ? "NULL" : "'" + cbProduceVendor.SelectedValue + "'", tbProduceFactory.Text
                    , tbMoldingDate.Text == "" ? "null" : "'" + tbMoldingDate.Text + "'", tbMoldingExpected.Text == "" ? "null" : "'" + tbMoldingExpected.Text + "'", tbMoldingActual.Text == "" ? "null" : "'" + tbMoldingActual.Text + "'", tbBMSMoldingDate.Text == "" ? "null" : "'" + tbBMSMoldingDate.Text + "'", tbBMSMoldingExpected.Text == "" ? "null" : "'" + tbBMSMoldingExpected.Text + "'", tbBMSMoldingActual.Text == "" ? "null" : "'" + tbBMSMoldingActual.Text + "'", tbFullMoldingDate.Text == "" ? "null" : "'" + tbFullMoldingDate.Text + "'", tbFullMoldingExpected.Text == "" ? "null" : "'" + tbFullMoldingExpected.Text + "'", tbFullMoldingActual.Text == "" ? "null" : "'" + tbFullMoldingActual.Text + "'"
                    , tbCounter.Text, cbFom.Visible == false ? "null" : "'" + cbFom.Text + "'", tbRemark.Text
                    , tbMoldQTY.Text == "" ? "null" : tbMoldQTY.Text, tbCurrency.Text, tbMoldTotalPrice.Text == "" ? "null" : tbMoldTotalPrice.Text, tbPriceStart.Text, tbPriceEnd.Text
                    , tbNonAmortization.Text == "" ? "null" : tbNonAmortization.Text, tbAmortization.Text == "" ? "null" : tbAmortization.Text, tbAmortizationDBL.Text == "" ? "null" : tbAmortizationDBL.Text, tbAmortizationUP.Text == "" ? "null" : tbAmortizationUP.Text, tbConfirmPrice.Text == "" ? "null" : tbConfirmPrice.Text
                    , toolno, toolclass);
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

        #region 刪除工制具設定方法

        private void DeleteMoldClassData()
        {
            if (this.dgvMoldSetData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + dgvMoldSetData.CurrentRow.Cells[0].Value + " , " + dgvMoldSetData.CurrentRow.Cells[2].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from gjzl where gjmh='{0}' and gjlb='{1}' ", toolno, toolclass);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextbox();
                            MoldClassDataQuery(toolno, toolclass); // 重新查詢
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

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            // 工具資料
            tbToolNo.Text = "";
            cbToolClass.SelectedIndex = -1;
            // 基本資料
            tbRefStyle.Text = "";
            cbUseClient.SelectedIndex = -1;
            cbCountry.SelectedIndex = -1;
            cbMoldVendor.SelectedIndex = -1;
            tbMoldingFactory.Text = "";
            tbMoldShortCode.Text = "";
            cbProduceVendor.SelectedIndex = -1;
            tbProduceFactory.Text = "";
            tbSizeRange.Text = "";
            tbMoldingDate.Text = "";
            tbMoldingExpected.Text = "";
            tbMoldingActual.Text = "";
            tbBMSMoldingDate.Text = "";
            tbBMSMoldingExpected.Text = "";
            tbBMSMoldingActual.Text = "";
            tbFullMoldingDate.Text = "";
            tbFullMoldingExpected.Text = "";
            tbFullMoldingActual.Text = "";
            tbCounter.Text = "";
            tbRemark.Text = "";
            // 模攤費用
            tbMoldQTY.Text = "";
            tbCurrency.Text = "";
            tbMoldTotalPrice.Text = "";
            tbNonAmortization.Text = "";
            tbAmortization.Text = "";
            tbAmortizationDBL.Text = "";
            tbAmortizationUP.Text = "";
            tbHasAmortization.Text = "";
            tbHasAmortizationDBL.Text = "";
            tbConfirmPrice.Text = "";
            tbFinishAmortization.Text = "";
            tbFinishAmortizationDBL.Text = "";
            tbPriceStart.Text = "";
            tbPriceEnd.Text = "";
        }

        #endregion
        
        #region 工具尺寸明細方法

        #region 查詢工具尺寸明細

        private void QuerySizeDetail()
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select mjcc 尺寸,mjss 數量,mjss1 不攤數,bz 備註,gjmh,gjlb from gjzls " +
                    "where gjmh = '{0}' and gjlb = '{1}' order by gjmh"
                    , tbToolNo.Text, cbToolClass.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "工具SIZE數量檔");
                this.dgvSizeDetail.DataSource = this.ds.Tables[0];
                this.dgvSizeDetail.Columns[4].Visible = false;
                this.dgvSizeDetail.Columns[5].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Size Error!");
            }
        }

        #endregion

        #region 刪除工具尺寸明細

        private void DeleteSizeDetail()
        {
            if (this.dgvSizeDetail.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete Size " + this.dgvSizeDetail.CurrentRow.Cells[0].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from gjzls where gjmh='{0}' and gjlb='{1}' and mjcc='{2}'"
                            , this.dgvSizeDetail.CurrentRow.Cells[4].Value, this.dgvSizeDetail.CurrentRow.Cells[5].Value, this.dgvSizeDetail.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QuerySizeDetail();
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

        #endregion

        
    }
}
