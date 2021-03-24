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
    /// MoldSet200EncodingPrinciple 200面刀
    /// </summary>
    public partial class MS200 : Form
    {
        #region 變數

        DataSet dsKFZL = new DataSet(); // 客戶容器
        DataSet dsFOM = new DataSet(); // 楦頭容器
        DataSet dsOutSole = new DataSet(); // 大底模容器
        DataSet dsPaper = new DataSet(); // 紙板容器
        private string kfdh; // 客戶代號
        private string FOM; // 楦頭代號
        //private string Outsole; // 大底模代號
        public string code; // 200面刀編號
        public bool isok = false; // 是否OK

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MS200";

        #endregion

        #region 構造函式

        public MS200()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MoldSet200EncodingPrinciple_Load(object sender, EventArgs e)
        {
            GetKFZL();

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 確認按鈕事件

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbBrandCOD.Text == "" || tbShoeLastCOD.Text == "" || tbOutsoleMoldCOD.Text == "" || tbCardboardCOD.Text == "")
            {
                MessageBox.Show("Serial Number Can't Be Null!");
            }
            else
            {
                code = tbBrandCOD.Text + "-" + tbShoeLastCOD.Text + tbOutsoleMoldCOD.Text + "-" + tbCardboardCOD.Text + "-" + tbInnerOuterCOD.Text + tbLeftRightCOD.Text;
                isok = true;
                this.Close();
            }
        }

        #endregion
        
        #region 下拉選單改變事件

        // 品牌
        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbShoeLastCOD.Text = "";
            cbShoeLast.Text = "";
            tbOutsoleMoldCOD.Text = "";
            cbOutsoleMold.Text = "";
            tbCardboardCOD.Text = "";
            cbCardboard.Text = "";
            tbBrandCOD.Text = cbBrand.SelectedValue.ToString();
            kfdh = dsKFZL.Tables[0].Rows[cbBrand.SelectedIndex]["kfdh"].ToString();
            GetFOM(kfdh);
        }

        // 楦頭
        private void cbShoeLast_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbOutsoleMoldCOD.Text = "";
            cbOutsoleMold.Text = "";
            tbCardboardCOD.Text = "";
            cbCardboard.Text = "";
            FOM = dsFOM.Tables[0].Rows[cbShoeLast.SelectedIndex]["gjmh"].ToString();
            tbShoeLastCOD.Text = dsFOM.Tables[0].Rows[cbShoeLast.SelectedIndex]["Mjlb2"].ToString();
            GetOutSole(kfdh, FOM);
        }

        // 大底模
        private void cbOutsoleMold_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCardboardCOD.Text = "";
            cbCardboard.Text = "";
            //Outsole = dsOutSole.Tables[0].Rows[cbOutsoleMold.SelectedIndex]["gjmh"].ToString();
            tbOutsoleMoldCOD.Text = dsOutSole.Tables[0].Rows[cbOutsoleMold.SelectedIndex]["Mjlb2"].ToString();
            GetPAPER(kfdh, cbShoeLast.Text, cbOutsoleMold.Text);
        }

        // 紙板
        private void cbCardboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCardboardCOD.Text = cbCardboard.SelectedValue.ToString();
        }

        #endregion

        #region 左右內外腰分刀

        // 內外腰
        private void chkInnerOuter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInnerOuter.Checked)
            {
                chkInnerOuter.Text = "Outer";
                tbInnerOuterCOD.Text = "T";
            }
            else
            {
                chkInnerOuter.Text = "Inner";
                tbInnerOuterCOD.Text = "N";
            }
        }

        // 左右
        private void chkLeftRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeftRight.Checked)
            {
                chkLeftRight.Text = "Right";
                tbLeftRightCOD.Text = "1";
            }
            else
            {
                chkLeftRight.Text = "Left";
                tbLeftRightCOD.Text = "0";
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 下拉選單載入

        #region 客戶下拉選單

        private void GetKFZL()
        {
            dsKFZL = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 品牌
                string sql1 = "select kfdh,kfjc,dybh from kfzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsKFZL, "品牌");
                cbBrand.DataSource = dsKFZL.Tables[0];
                cbBrand.ValueMember = "dybh";
                cbBrand.DisplayMember = "kfjc";
            }
            catch (Exception)
            {
                MessageBox.Show("KFZL Combobox Diplay Error");
            }
        }

        #endregion
        
        #region 楦頭下拉選單

        private void GetFOM(string kfdh)
        {
            dsFOM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 楦頭
                string sql1 = string.Format("select gjmh,gjlb,Mjlb2 from gjzl " +
                    "where gjlb='100' and kfdh='{0}'", kfdh);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsFOM, "楦頭");
                cbShoeLast.DataSource = dsFOM.Tables[0];
                cbShoeLast.ValueMember = "gjlb";
                cbShoeLast.DisplayMember = "gjmh";
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
            dsOutSole = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 大底模
                string sql1 = string.Format("select gjmh,gjlb,Mjlb2 from gjzl " +
                    "where gjlb='101' and kfdh='{0}' and counter1='{1}'", kfdh, fomno);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsOutSole, "大底模");
                cbOutsoleMold.DataSource = dsOutSole.Tables[0];
                cbOutsoleMold.ValueMember = "gjlb";
                cbOutsoleMold.DisplayMember = "gjmh";
            }
            catch (Exception)
            {
                MessageBox.Show("OutSole Combobox Diplay Error");
            }
        }

        #endregion
        
        #region 紙板下拉選單

        private void GetPAPER(string kfdh, string fomno, string outsoleno)
        {
            dsPaper = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 紙板
                string sql1 = string.Format("select Paper_ID,Paper_Name from PAPER " +
                    "where kfdh='{0}' and Lastsgjmh='{1}' and Outsolegjmh='{2}'", kfdh, fomno, outsoleno);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsPaper, "紙板");
                cbCardboard.DataSource = dsPaper.Tables[0];
                cbCardboard.ValueMember = "Paper_ID";
                cbCardboard.DisplayMember = "Paper_Name";
            }
            catch (Exception)
            {
                //MessageBox.Show("PAPER Combobox Diplay Error");
            }
        }

        #endregion

        #endregion

        #endregion

        
    }
}
