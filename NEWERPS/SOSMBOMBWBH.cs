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
    /// SampleOrderShoeModelBOMBWBH 鞋型BOM部位
    /// </summary>
    public partial class SOSMBOMBWBH : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 部位代號, 中文, 部位分類;
        public bool isc = false; // 是否Comfirm
        private string partClass;
        private int cbindex;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "SOSMBOMBWBH";

        #endregion

        #region 構造函式

        public SOSMBOMBWBH()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void SampleOrderShoeModelBOMBWBH_Load(object sender, EventArgs e)
        {
            cbPartClass.SelectedIndex = 0;

            ////獲取語言
            //userLanguage = Program.LanguageType.userLanguage;
            ////更改語言
            //ChangeLabel();
            //ChangeDataView();
        }

        #endregion

        #region 部位分類下拉選單改變

        private void cbPartClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPartClass.Text == "")
            {
                partClass = "";
            }
            else
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
            PartSetDataQuery(tbPartNo.Text, partClass, tbPartName.Text);
        }

        #endregion

        #region DGV雙點擊事件(返回附值)

        private void dgvPartSetData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.部位代號 = this.dgvPartSetData.CurrentRow.Cells[0].Value.ToString();
            this.中文 = this.dgvPartSetData.CurrentRow.Cells[1].Value.ToString();
            this.部位分類 = this.dgvPartSetData.CurrentRow.Cells[4].Value.ToString();
            this.isc = true;
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
                L0003.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 查詢部位方法

        private void PartSetDataQuery(string partno, string partclass, string partname)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bwdh 部位代號,zwsm 中文說明,ywsm 英文說明,bz 備註,bwlb " +
                    "from bwzl " +
                    "where bwlb like '{0}%' and bwdh like '{1}%' and YN='1' and ((zwsm like '%{2}%' or zwsm is null) or (ywsm like '%{3}%' or ywsm is null))"
                    , partclass, partno, partname, partname);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "部位設定表");
                this.dgvPartSetData.DataSource = this.ds.Tables[0];
                this.dgvPartSetData.Columns[4].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Error!");
            }
        }


        #endregion

        #endregion
        
    }
}
