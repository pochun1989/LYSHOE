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
    /// DevelopModel 開發型體設定
    /// </summary>
    public partial class DM : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        DataSet dscb = new DataSet(); // 下拉選單容器
        DataTable dtFOM = new DataTable(); // 楦頭下拉容器
        DataTable dtOutSole = new DataTable(); // 大底下拉容器
        DataTable dt200 = new DataTable(); // 面刀下拉容器
        public string USERID;
        private string tsbIsInsertOrModify;
        private string shoemodel, colornum; // 鞋型,色號
        private string mjlb100, mjlb101; // 楦頭大底模鋸短碼
        private bool isSave = false;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "DM";

        #endregion

        #region 構造函式

        public DM()
        {
            InitializeComponent();
        }


        #endregion

        #region 事件

        #region 畫面載入

        private void DevelopModel_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            tbDevUser.Text = USERID;
            GetCombobox();

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
            if (tcDevelopModel.SelectedIndex != 0)
            {
                tcDevelopModel.SelectedIndex = 0;
            }
            else if (dgvDevModelData.DataSource == null || tcDevelopModel.SelectedIndex == 0)
            {
                DMD dmd = new DMD();
                dmd.ShowDialog();
                if (dmd.isq)
                {
                    DevModelQuery(dmd.鞋型, dmd.色號);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tcDevelopModel.SelectedIndex = 1;
            ClearTextbox();
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
            DeleteDevModelData();
        }

        #endregion

        #region 編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            tcDevelopModel.SelectedIndex = 1;
            tsbIsInsertOrModify = "Modify";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 拷貝按鈕事件

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            DMC dmc = new DMC();
            dmc.oldshoemodel = this.tbShoeModelNo.Text;
            dmc.oldcolor = this.tbColorNo.Text;
            dmc.ShowDialog();
            if (dmc.isCopy)
            {
                InsertDevModelData(dmc.新鞋型, dmc.新色號);
            }
        } 

        #endregion

        #region 速查DGV單擊事件

        private void dgvDevModelData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ToControls();
        }

        #endregion

        #region 速查DGV雙擊事件

        private void dgvDevModelData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ToControls();
            tcDevelopModel.SelectedIndex = 1;
        } 

        #endregion

        #region 關閉頁面按鈕事件

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (tsbIsInsertOrModify == "Insert") // 新增
                {
                    InsertDevModelData(tbShoeModelNo.Text, tbColorNo.Text);
                }
                else // 修改
                {
                    ModifyDevModelData();
                }
                if (isSave)
                {
                    tsbChoice("Recover");
                }
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

        #region 清除工具按鈕事件

        private void btnCancel100_Click(object sender, EventArgs e)
        {
            cb100No.SelectedIndex = -1;
        }

        private void btnCancel101_Click(object sender, EventArgs e)
        {
            cb101No.SelectedIndex = -1;
        }

        private void btnCancel102_Click(object sender, EventArgs e)
        {
            cb102No.SelectedIndex = -1;
        }

        private void btnCancel200_Click(object sender, EventArgs e)
        {
            cb200No.SelectedIndex = -1;
        }

        #endregion

        #region Combobox Event

        #region 下拉選單改變事件

        // 主材料
        private void cbMainMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbClassBDisplay.Text = "";
            if (cbMainMaterial.SelectedIndex != -1)
            {
                tbClassBDisplay.Text = dscb.Tables[2].Rows[cbMainMaterial.SelectedIndex]["cllb"].ToString();
            }
        }

        // 鞋功能
        private void cbShoeFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFunctionDisplay.Text = "";
            if (cbShoeFunction.SelectedIndex != -1)
            {
                tbFunctionDisplay.Text = dscb.Tables[3].Rows[cbShoeFunction.SelectedIndex]["Mode_ID"].ToString();
            }
        }

        // 客戶
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbClientDisplay.Text = "";
            if (cbClient.SelectedIndex != -1)
            {
                cb100No.DataSource = null;
                cb101No.DataSource = null;
                cb200No.DataSource = null;
                tbClientDisplay.Text = dscb.Tables[4].Rows[cbClient.SelectedIndex]["kfdh"].ToString();
                GetFOM(dscb.Tables[4].Rows[cbClient.SelectedIndex]["kfdh"].ToString());
            }
        }

        // 楦頭
        private void cb100No_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb100No.SelectedIndex != -1)
                {

                    cb101No.DataSource = null;
                    cb200No.DataSource = null;
                    GetOutSole(dscb.Tables[4].Rows[cbClient.SelectedIndex]["kfdh"].ToString(), dtFOM.Rows[cb100No.SelectedIndex]["gjmh"].ToString());
                    if (cb100No.SelectedIndex != -1)
                    {
                        mjlb100 = dtFOM.Rows[cb100No.SelectedIndex]["Mjlb2"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }

        // 大底
        private void cb101No_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb101No.SelectedIndex != -1)
            {
                mjlb101 = dtOutSole.Rows[cb101No.SelectedIndex]["Mjlb2"].ToString();
                if (mjlb100 != null && mjlb101 != null)
                {
                    cb200No.DataSource = null;
                    Get200(dscb.Tables[4].Rows[cbClient.SelectedIndex]["kfdh"].ToString(), mjlb100 + mjlb101);
                }
            }
        }

        #endregion 

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
                tsbCopy.Enabled = false;
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
                tsbCopy.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Recover")
            {
                EnableUIColumns(false);
                tsbQuery.Enabled = true;
                tsbInsert.Enabled = true;
                if (tbShoeModelNo.Text != "")
                {
                    tsbModify.Enabled = true;
                    tsbDelete.Enabled = true;
                    tsbCopy.Enabled = true;
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
                tbShoeModelNo.Enabled = true;
                tbArticleName.Enabled = true;
                tbSeason.Enabled = true;
                cbDevFactory.Enabled = true;
                cbSizeCountry.Enabled = true;
                cbMainMaterial.Enabled = true;
                cbShoeFunction.Enabled = true;
                cbClient.Enabled = true;
                cbDevClass.Enabled = true;
                cbGender.Enabled = true;
                tbRemark.Enabled = true;
                tbColorNo.Enabled = true;
                tbColorDetail.Enabled = true;
                tbSizeRange.Enabled = true;
                tbDevNo.Enabled = true;
                btnCancel100.Enabled = true;
                btnCancel101.Enabled = true;
                btnCancel102.Enabled = true;
                btnCancel200.Enabled = true;
                cb100No.Enabled = true;
                cb101No.Enabled = true;
                cb102No.Enabled = true;
                cb200No.Enabled = true;
                pcPic.Enabled = true;
                tbArticleNo.Enabled = true;
            }
            else // 關
            {
                tbShoeModelNo.Enabled = false;
                tbArticleName.Enabled = false;
                tbSeason.Enabled = false;
                cbDevFactory.Enabled = false;
                cbSizeCountry.Enabled = false;
                cbMainMaterial.Enabled = false;
                cbShoeFunction.Enabled = false;
                cbClient.Enabled = false;
                cbDevClass.Enabled = false;
                cbGender.Enabled = false;
                tbRemark.Enabled = false;
                tbColorNo.Enabled = false;
                tbColorDetail.Enabled = false;
                tbSizeRange.Enabled = false;
                tbDevNo.Enabled = false;
                btnCancel100.Enabled = false;
                btnCancel101.Enabled = false;
                btnCancel102.Enabled = false;
                btnCancel200.Enabled = false;
                cb100No.Enabled = false;
                cb101No.Enabled = false;
                cb102No.Enabled = false;
                cb200No.Enabled = false;
                pcPic.Enabled = false;
                tbArticleNo.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbShoeModelNo.Text.Trim().Length == 0 && tbColorNo.Text.Trim().Length == 0 && cbClient.Text == "")
            {
                MessageBox.Show("ShoeModel & ColorNum & Client is null!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion
        
        #region 下拉選單載入
        
        #region 下拉選單載入(其餘)

        private void GetCombobox()
        {
            dscb = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 0 開發廠區
                string sql1 = "select cqdh,gszwqm from cqzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dscb, "開發廠區表");
                cbDevFactory.DataSource = dscb.Tables[0];
                cbDevFactory.ValueMember = "cqdh";
                cbDevFactory.DisplayMember = "gszwqm";
                cbDevFactory.SelectedIndex = -1;

                // 1 尺寸國別
                string sql2 = "select SIZE_ID,SIZE_Name from CSSize";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(dscb, "尺寸國別表");
                cbSizeCountry.DataSource = dscb.Tables[1];
                cbSizeCountry.ValueMember = "SIZE_ID";
                cbSizeCountry.DisplayMember = "SIZE_Name";
                cbSizeCountry.SelectedIndex = -1;

                // 2 主材料
                string sql3 = "select cllb,zwsm from CLASS_B";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn.connection);
                adapter3.Fill(dscb, "主材料表");
                cbMainMaterial.DataSource = dscb.Tables[2];
                cbMainMaterial.ValueMember = "cllb";
                cbMainMaterial.DisplayMember = "zwsm";
                cbMainMaterial.SelectedIndex = -1;

                // 3 鞋功能
                string sql4 = "select Mode_ID,zwsm from ShoeMode";
                SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn.connection);
                adapter4.Fill(dscb, "鞋功能表");
                cbShoeFunction.DataSource = dscb.Tables[3];
                cbShoeFunction.ValueMember = "Mode_ID";
                cbShoeFunction.DisplayMember = "zwsm";
                cbShoeFunction.SelectedIndex = -1;

                // 4 客戶
                string sql5 = "select kfdh,kfjc from kfzl order by kfjc";
                SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn.connection);
                adapter5.Fill(dscb, "客戶表");
                cbClient.DataSource = dscb.Tables[4];
                cbClient.ValueMember = "kfdh";
                cbClient.DisplayMember = "kfjc";
                cbClient.SelectedIndex = -1;

                // 5 開發類型
                string sql6 = "select DC_ID,DC_Number from Dev_Class";
                SqlDataAdapter adapter6 = new SqlDataAdapter(sql6, dbConn.connection);
                adapter6.Fill(dscb, "開發類型表");
                cbDevClass.DataSource = dscb.Tables[5];
                cbDevClass.ValueMember = "DC_ID";
                cbDevClass.DisplayMember = "DC_Number";
                cbDevClass.SelectedIndex = -1;

                // 6 GENDER
                string sql7 = "select GENDER_id,GENDERE from GENDER";
                SqlDataAdapter adapter7 = new SqlDataAdapter(sql7, dbConn.connection);
                adapter7.Fill(dscb, "GENDER表");
                cbGender.DataSource = dscb.Tables[6];
                cbGender.ValueMember = "GENDER_id";
                cbGender.DisplayMember = "GENDERE";
                cbGender.SelectedIndex = -1;

                // 7 M/S
                string sql10 = "select gjmh,gjlb from gjzl where gjlb='102' order by gjmh";
                SqlDataAdapter adapter10 = new SqlDataAdapter(sql10, dbConn.connection);
                adapter10.Fill(dscb, "M/S表");
                cb102No.DataSource = dscb.Tables[7];
                cb102No.ValueMember = "gjlb";
                cb102No.DisplayMember = "gjmh";
                cb102No.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Combobox Diplay Error");
            }
        }

        #endregion

        #region 楦頭下拉選單

        private void GetFOM(string kfdh)
        {
            dtFOM = new DataTable("楦頭表");
            DBconnect dbConn = new DBconnect();
            try
            {
                // 楦頭
                string sql1 = string.Format("select gjmh,gjlb,Mjlb2 from gjzl " +
                    "where gjlb='100' and kfdh='{0}'", kfdh);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dtFOM);
                cb100No.DataSource = dtFOM;
                cb100No.ValueMember = "gjlb";
                cb100No.DisplayMember = "gjmh";
                cb100No.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("FOM Combobox Diplay Error");
            }
        }

        #endregion

        #region 大底模下拉選單

        private void GetOutSole(string kfdh, string fomno)
        {
            dtOutSole = new DataTable("大底表");
            DBconnect dbConn = new DBconnect();
            try
            {
                // 大底模
                string sql1 = string.Format("select gjmh,gjlb,Mjlb2 from gjzl " +
                    "where gjlb='101' and kfdh='{0}' and counter1='{1}'", kfdh, fomno);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dtOutSole);
                cb101No.DataSource = dtOutSole;
                cb101No.ValueMember = "gjlb";
                cb101No.DisplayMember = "gjmh";
                cb101No.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("OutSole Combobox Diplay Error");
            }
        }

        #endregion

        #region 面刀下拉選單

        private void Get200(string kfdh, string mjlb2)
        {
            if (mjlb2.Length == 4)
            {
                dt200 = new DataTable("面刀表");
                DBconnect dbConn = new DBconnect();
                try
                {
                    // 楦頭
                    string sql1 = string.Format("select gjmh,gjlb from gjzl " +
                        "where gjlb='200' and gjmh like '_____%{0}%_____' and kfdh='{1}'", mjlb2, kfdh);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                    adapter1.Fill(dt200);
                    cb200No.DataSource = dt200;
                    cb200No.ValueMember = "gjlb";
                    cb200No.DisplayMember = "gjmh";
                    cb200No.SelectedIndex = -1;
                }
                catch (Exception)
                {
                    MessageBox.Show("200 Combobox Diplay Error");
                }
            }
        }

        #endregion

        #endregion

        #region 附值速查內容方法

        private void ToControls()
        {
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tsbCopy.Enabled = true;
            tbShoeModelNo.Text = dgvDevModelData.CurrentRow.Cells[0].Value.ToString();
            shoemodel = dgvDevModelData.CurrentRow.Cells[0].Value.ToString();
            tbColorNo.Text = dgvDevModelData.CurrentRow.Cells[1].Value.ToString();
            colornum = dgvDevModelData.CurrentRow.Cells[1].Value.ToString();
            tbArticleName.Text = dgvDevModelData.CurrentRow.Cells[2].Value.ToString();
            tbColorDetail.Text = dgvDevModelData.CurrentRow.Cells[3].Value.ToString();
            tbSeason.Text = dgvDevModelData.CurrentRow.Cells[4].Value.ToString();
            cbMainMaterial.SelectedValue = dgvDevModelData.CurrentRow.Cells[5].Value.ToString();
            cbShoeFunction.SelectedValue = dgvDevModelData.CurrentRow.Cells[7].Value.ToString();
            cbDevFactory.SelectedValue = dgvDevModelData.CurrentRow.Cells[9].Value.ToString();
            cbClient.SelectedValue = dgvDevModelData.CurrentRow.Cells[11].Value.ToString();
            cbSizeCountry.SelectedValue = dgvDevModelData.CurrentRow.Cells[13].Value.ToString();
            tbSizeRange.Text = dgvDevModelData.CurrentRow.Cells[15].Value.ToString();
            cbDevClass.SelectedValue = dgvDevModelData.CurrentRow.Cells[16].Value;
            tbDevNo.Text = dgvDevModelData.CurrentRow.Cells[18].Value.ToString();
            cbGender.SelectedValue = dgvDevModelData.CurrentRow.Cells[19].Value;
            cb100No.Text = dgvDevModelData.CurrentRow.Cells[22].Value.ToString();
            cb101No.Text = dgvDevModelData.CurrentRow.Cells[24].Value.ToString();
            cb102No.Text = dgvDevModelData.CurrentRow.Cells[26].Value.ToString();
            cb200No.Text = dgvDevModelData.CurrentRow.Cells[28].Value.ToString();
            tbRemark.Text = dgvDevModelData.CurrentRow.Cells[29].Value.ToString();
            tbStartDate.Text = dgvDevModelData.CurrentRow.Cells[30].Value.ToString();
            tbConfirmDate.Text = dgvDevModelData.CurrentRow.Cells[31].Value.ToString();
        }

        #endregion

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            tbShoeModelNo.Text = "";
            tbArticleName.Text = "";
            tbSeason.Text = "";
            cbClient.SelectedIndex = -1;
            cbDevFactory.SelectedIndex = -1;
            cbSizeCountry.SelectedIndex = -1;
            cbMainMaterial.SelectedIndex = -1;
            cbShoeFunction.SelectedIndex = -1;
            cbDevClass.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            tbRemark.Text = "";
            tbColorNo.Text = "";
            tbColorDetail.Text = "";
            tbSizeRange.Text = "";
            tbDevNo.Text = "";
            btnCancel100.PerformClick();
            btnCancel101.PerformClick();
            btnCancel102.PerformClick();
            btnCancel200.PerformClick();
            cb100No.Text = "";
            cb101No.Text = "";
            cb102No.Text = "";
            cb200No.Text = "";
            tbPicturePath.Text = "";
            pcPic.Image = null;
        }

        #endregion

        #region 查詢開發類型方法

        private void DevModelQuery(string XieXing, string SheHao)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            tsbCopy.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select kx.XieXing 鞋型,kx.SheHao 色號,kx.ARTICLE 'ART.NAME',kx.YSSM 顏色說明," +
                    "kx.JiJie 季節,kx.CLID,cb.zwsm 材料名稱,kx.XieGN,sm.zwsm 功能名稱,kx.KFCQ,cq.gszwqm 開發廠區,kx.KHDH,kf.kfjc 客戶," +
                    "kx.CCGB,cs.SIZE_Name 尺寸國別,kx.LOGO 尺寸範圍,dc.DC_ID,dc.DC_NameC 開發類型,kx.DEVCODE 開發代碼,kx.GENDER," +
                    "g.Gender_Name 'GENDER',kx.XTGJ,kx.XTMH 楦頭模號,kx.DMGJ,kx.DDMH 大底模號,kx.MSGJ,kx.MDMH 'M/S模號',kx.DAOGJ,kx.DAOMH 面刀模號,kx.BZ 備註,kx.KFDATE 開發日期,kx.CFMDATE 確認日期 " +
                    "from kfxxzl kx " +
                    "left join cqzl cq on cq.cqdh=kx.KFCQ " +
                    "left join CSSize cs on cs.SIZE_ID=kx.CCGB " +
                    "left join CLASS_B cb on cb.cllb=kx.CLID " +
                    "left join ShoeMode sm on sm.Mode_ID=kx.XieGN " +
                    "left join kfzl kf on kf.kfdh=kx.KHDH " +
                    "left join Dev_Class dc on dc.DC_ID=kx.DevType " +
                    "left join GENDER g on g.GENDER_id=kx.GENDER " +
                    "where kx.XieXing like '%{0}%' and kx.SheHao like '%{1}%'"
                    , XieXing, SheHao);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "開發類型表");
                this.dgvDevModelData.DataSource = this.ds.Tables[0];
                dgvDevModelData.Columns[1].Width = 15;
                dgvDevModelData.Columns[4].Width = 20;
                dgvDevModelData.Columns[5].Visible = false;
                dgvDevModelData.Columns[7].Visible = false;
                dgvDevModelData.Columns[9].Visible = false;
                for(int i = 11; i <= 31; i++)
                {
                    dgvDevModelData.Columns[i].Visible = false;
                }
                dgvDevModelData.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Query Data Error!");
            }
        }


        #endregion
        
        #region 新增開發類型方法

        private void InsertDevModelData(string shoemodelno,string colorno)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 0鞋型 1色號 2article 3顏色說明 4季節 5主材料編號 6鞋功能編號 7開發廠編號 8客戶編號 9尺寸國編號 10尺寸範圍
                // 11開發類型編號(int) 12開發代碼 13性別編號(int) 14楦頭 15楦頭模號 16大底 17大底模號 18M / S 19M / S模號 20面刀 21面刀模號
                // 22備註 23使用者ID 24建立日期
                string sql = string.Format("insert into kfxxzl " +
                    "(XieXing,SheHao,XieMing,YSSM,JiJie,CLID,XieGN,KFCQ,KHDH,CCGB,LOGO" +
                    ",DevType,DEVCODE,GENDER,XTGJ,XTMH,DMGJ,DDMH,MSGJ,MDMH,DAOGJ,DAOMH" +
                    ",BZ,USERID,USERDATE,ARTICLE) " +
                    "values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}',{9},'{10}'" +
                    ",{11},'{12}',{13},{14},{15},{16},{17},{18},{19},{20},{21}" +
                    ",'{22}','{23}','{24}', '{25}')"
                    , shoemodelno, colorno, tbArticleName.Text, tbColorDetail.Text, tbSeason.Text, cbMainMaterial.Text == "" ? "NULL" : "'" + cbMainMaterial.SelectedValue + "'", cbShoeFunction.Text == "" ? "NULL" : "'" + cbShoeFunction.SelectedValue + "'", cbDevFactory.Text == "" ? "NULL" : "'" + cbDevFactory.SelectedValue + "'", cbClient.SelectedValue, cbSizeCountry.Text == "" ? "NULL" : "'" + cbSizeCountry.SelectedValue + "'", tbSizeRange.Text
                    , cbDevClass.Text == "" ? "NULL" : cbDevClass.SelectedValue, tbDevNo.Text, cbGender.Text == "" ? "NULL" : cbGender.SelectedValue
                    , cb100No.Text == "" ? "null" : "'" + cb100No.SelectedValue + "'", cb100No.Text == "" ? "null" : "'" + cb100No.Text + "'", cb101No.Text == "" ? "null" : "'" + cb101No.SelectedValue + "'", cb101No.Text == "" ? "null" : "'" + cb101No.Text + "'", cb102No.Text == "" ? "null" : "'" + cb102No.SelectedValue + "'", cb102No.Text == "" ? "null" : "'" + cb102No.Text + "'", cb200No.Text == "" ? "null" : "'" + cb200No.SelectedValue + "'", cb200No.Text == "" ? "null" : "'" + cb200No.Text + "'"
                    , tbRemark.Text, USERID, DateTime.Today.ToString("yyyyMMdd"), tbArticleNo.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    isSave = true;
                    MessageBox.Show("Insert Success!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                isSave = false;
                //MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 編輯開發類型方法

        private void ModifyDevModelData()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update kfxxzl " +
                    "set XieXing='{0}',SheHao='{1}',XieMing='{2}',YSSM='{3}',JiJie='{4}',CLID={5},XieGN={6},KFCQ={7},KHDH='{8}',CCGB={9},LOGO='{10}'" +
                    ",DevType={11},DEVCODE='{12}',GENDER={13},XTGJ={14},XTMH={15},DMGJ={16},DDMH={17},MSGJ={18},MDMH={19},DAOGJ={20},DAOMH={21}" +
                    ",BZ='{22}',USERID='{23}',USERDATE='{24}', ARTICLE = '{27}' " +
                    "where XieXing='{25}' and SheHao='{26}'"
                    , tbShoeModelNo.Text, tbColorNo.Text, tbArticleName.Text, tbColorDetail.Text, tbSeason.Text, cbMainMaterial.Text == "" ? "NULL" : "'" + cbMainMaterial.SelectedValue + "'", cbShoeFunction.Text == "" ? "NULL" : "'" + cbShoeFunction.SelectedValue + "'", cbDevFactory.Text == "" ? "NULL" : "'" + cbDevFactory.SelectedValue + "'", cbClient.SelectedValue, cbSizeCountry.Text == "" ? "NULL" : "'" + cbSizeCountry.SelectedValue + "'", tbSizeRange.Text
                    , cbDevClass.Text == "" ? "NULL" : cbDevClass.SelectedValue, tbDevNo.Text, cbGender.Text == "" ? "NULL" : cbGender.SelectedValue
                    , cb100No.Text == "" ? "null" : "'" + cb100No.SelectedValue + "'", cb100No.Text == "" ? "null" : "'" + cb100No.Text + "'", cb101No.Text == "" ? "null" : "'" + cb101No.SelectedValue + "'", cb101No.Text == "" ? "null" : "'" + cb101No.Text + "'", cb102No.Text == "" ? "null" : "'" + cb102No.SelectedValue + "'", cb102No.Text == "" ? "null" : "'" + cb102No.Text + "'", cb200No.Text == "" ? "null" : "'" + cb200No.SelectedValue + "'", cb200No.Text == "" ? "null" : "'" + cb200No.Text + "'"
                    , tbRemark.Text, USERID, DateTime.Today.ToString("yyyyMMdd")
                    , shoemodel, colornum, tbArticleNo.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    isSave = true;
                    MessageBox.Show("Modify Success!");
                }
            }
            catch (Exception)
            {
                isSave = false;
                MessageBox.Show("Modify Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 刪除開發類型方法

        private void DeleteDevModelData()
        {
            if (this.dgvDevModelData.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Delete " + dgvDevModelData.CurrentRow.Cells[0].Value + " , " + dgvDevModelData.CurrentRow.Cells[1].Value + " This Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect dbConn = new DBconnect();
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("delete from kfxxzl where XieXing ='{0}' and SheHao ='{0}'", shoemodel, colornum);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextbox();
                            DevModelQuery(shoemodel, colornum); // 重新查詢
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
