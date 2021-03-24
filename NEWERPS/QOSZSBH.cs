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
    /// QuoteOrderSelectZSBH 報價單頭選擇廠商
    /// </summary>
    public partial class QOSZSBH : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string 廠商編號, 廠商簡寫; // 廠區資訊
        public bool isSave = false;

        #endregion

        #region 構造函式

        public QOSZSBH()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void QOSZSBH_Load(object sender, EventArgs e)
        {
            GetVendorCombobox();
            if (廠商編號 != null)
            {
                cbVendor.SelectedValue = 廠商編號;
            }
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbVendor.Text == "")
            {
                MessageBox.Show("Vendor Can't Be Null!");
            }
            else
            {
                廠商編號 = cbVendor.SelectedValue.ToString();
                廠商簡寫 = cbVendor.Text;
                isSave = true;
                this.Close();
            }
        } 

        #endregion

        #endregion

        #region 方法

        private void GetVendorCombobox()
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                // 讀取廠區表
                string sql1 = "select zsdh,zsjc from zszl where zsjc is not null order by zsjc";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "廠商表");
                this.cbVendor.DataSource = ds.Tables[0];
                this.cbVendor.ValueMember = "zsdh";
                this.cbVendor.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Vendor Combobox Error!");
            }
        }

        #endregion

        
    }
}
