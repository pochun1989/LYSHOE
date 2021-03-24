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
    /// QuoteOrderDetail 報價單速查
    /// </summary>
    public partial class QOD : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 報價單號, 廠商, 開單日起, 開單日止;
        public bool isq = false; // 是否查詢
        private int supplierindex;
        private string supplierstr; // 供應商

        #endregion

        #region 構造函式

        public QOD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void QuoteOrderDetail_Load(object sender, EventArgs e)
        {
            GetCombobox();
            supplierstr = "='" + this.cbSupplier.SelectedValue + "'";
        }

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            isq = true;
            報價單號 = this.tbBJNo.Text;
            廠商 = supplierstr;
            if (chkIsQueryDate.Checked)
            {
                開單日起 = this.dtpStart.Text;
                開單日止 = this.dtpEnd.Text;
            }
            else
            {
                開單日起 = "2000/01/01";
                開單日止 = DateTime.Now.ToString("yyyy/MM/dd 23:59");
            }
            this.Close();
        }

        #endregion

        #region 廠商下拉選單改變事件

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierstr = "='" + this.cbSupplier.SelectedValue + "'";
        } 

        #endregion

        #region 是否查廠商全部開關

        private void chkSupplierALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplierALL.Checked)
            {
                supplierindex = cbSupplier.SelectedIndex;
                cbSupplier.SelectedIndex = -1;
                supplierstr = "like '" + this.cbSupplier.SelectedValue + "%'";
                cbSupplier.Enabled = false;
            }
            else
            {
                cbSupplier.SelectedIndex = supplierindex;
                cbSupplier.Enabled = true;
                supplierstr = "='" + this.cbSupplier.SelectedValue + "'";
            }
        } 

        #endregion

        #region 是否查詢日期開關

        private void chkIsQueryDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsQueryDate.Checked)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region 方法

        #region 下拉選單載入方法(廠商)

        private void GetCombobox()
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                // 讀取廠商表
                string sql = "select zsdh,zsjc from zszl where zsjc is not null order by zsjc";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn.connection);
                adapter.Fill(ds, "廠商表");
                this.cbSupplier.DataSource = ds.Tables[0];
                this.cbSupplier.ValueMember = "zsdh";
                this.cbSupplier.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier Combobox Error!");
            }
        }

        #endregion

        #endregion

        
    }
}
