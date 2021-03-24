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
    /// SampleOrderCreateDetail 樣品單速查
    /// </summary>
    public partial class SOCD : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 樣品單號, 鞋型, 色號, ART, 階段, 季節;
        public bool isq = false;
        private int stageindex;
        private string stagestr;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "SOCD"; // FORM ID 未設定

        #endregion

        #region 構造函式

        public SOCD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void SampleOrderCreateDetail_Load(object sender, EventArgs e)
        {
            GetCombobox();
            stagestr = "='" + this.cbStage.SelectedValue;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            //ChangeLabel();
            //ChangeDataView();
        }

        #endregion

        #region 下拉選單改變事件

        private void cbStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            stagestr = "='" + this.cbStage.SelectedValue;
        } 

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.isq = true;
            樣品單號 = this.tbDevSampleOrderNo.Text;
            鞋型 = this.tbShoeModel.Text;
            色號 = this.tbColorNo.Text;
            ART = this.tbART.Text;
            階段 = stagestr;
            季節 = this.tbSeason.Text;
            this.Close();
        }

        #endregion

        #region 階段全部開關

        private void chkStageALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStageALL.Checked)
            {
                stageindex = cbStage.SelectedIndex;
                cbStage.SelectedIndex = -1;
                stagestr = "like '" + this.cbStage.SelectedValue + "%";
                cbStage.Enabled = false;
            }
            else
            {
                cbStage.SelectedIndex = stageindex;
                cbStage.Enabled = true;
                stagestr = "='" + this.cbStage.SelectedValue;
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

        #region 下拉選單載入方法(階段)

        private void GetCombobox()
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                // 讀取開發階段表
                string sql = "select DS_Number from Dev_stage";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn.connection);
                adapter.Fill(ds, "階段表");
                this.cbStage.DataSource = ds.Tables[0];
                this.cbStage.ValueMember = "DS_Number";
                this.cbStage.DisplayMember = "DS_Number";
            }
            catch (Exception)
            {
                MessageBox.Show("Combobox Error!");
            }
        }

        #endregion

        #endregion


    }
}
