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
    /// PartSetDetail 部位設定速查
    /// </summary>
    public partial class PSD : Form
    {
        #region 變數

        public string 部位代號, 中文, 英文, 部位分類;
        private int cbindex;
        public bool isq = false; // 是否查詢

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "PSD";

        #endregion

        #region 構造函式

        public PSD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void PartSetDetail_Load(object sender, EventArgs e)
        {
            cbPartClass.SelectedIndex = 0;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 部位分類下拉選單改變

        private void cbPartClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPartClass.Text == "")
            {
                部位分類 = "";
            }
            else
            {
                if (cbPartClass.SelectedIndex == 0)
                {
                    部位分類 = "U";
                }
                else if (cbPartClass.SelectedIndex == 1)
                {
                    部位分類 = "B";
                }
                else if (cbPartClass.SelectedIndex == 2)
                {
                    部位分類 = "A";
                }
                else if (cbPartClass.SelectedIndex == 3)
                {
                    部位分類 = "P";
                }
                else if (cbPartClass.SelectedIndex == 4)
                {
                    部位分類 = "O";
                }
            }
        }

        #endregion

        #region 部位CheckBox狀態改變

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkALL.Checked)
            {
                cbindex = cbPartClass.SelectedIndex;
                cbPartClass.SelectedIndex = -1;
                cbPartClass.Enabled = false;
            }
            else
            {
                cbPartClass.Enabled = true;
                cbPartClass.SelectedIndex = cbindex;
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            isq = true;
            部位代號 = this.tbPartNo.Text;
            中文 = this.tbPartNameCN.Text;
            英文 = this.tbPartNameEN.Text;
            this.Close();
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

        #endregion

    }
}
