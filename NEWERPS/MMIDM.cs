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
    /// MaterialMainInformationDetailModify 子材料修改頁面
    /// </summary>
    public partial class MMIDM : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string cldhm, cldhs, sn; // 子材料Table主key
        public string usage, vendor; // 需改變的值
        public bool isSave = false; // 是否儲存成功

        #endregion

        #region 構造函式

        public MMIDM()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MMIDM_Load(object sender, EventArgs e)
        {
            GetVendorCombobox();
            // 附值
            cbSupplierVendor.SelectedValue = vendor;
            tbUsage.Text = usage;
        }

        #endregion

        #region 儲存子材料內容按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbUsage.Text != "" && cbSupplierVendor.SelectedValue.ToString() != "")
            {
                UpdateDetailMaterial();
            }
        }

        #endregion

        #endregion

        #region 方法

        #region 載入下拉選單(子材料的廠商)

        private void GetVendorCombobox()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 廠商
                string sql1 = string.Format("select distinct s.zsdh,z.zsjc from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh where cldh='{0}' order by zsdh", cldhs);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "廠商表");
                cbSupplierVendor.DataSource = ds.Tables[0];
                cbSupplierVendor.ValueMember = "zsdh";
                cbSupplierVendor.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("RSL Combobox Error!");
            }
        }

        #endregion

        #region 修改子材料方法

        private void UpdateDetailMaterial()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update clzhzl set zsdh='{0}', syl='{1}' " +
                    "where cldh_M='{2}' and cldh_S='{3}' and SN={4}"
                    , cbSupplierVendor.SelectedValue, tbUsage.Text
                    , cldhm, cldhs, sn);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    isSave = true;
                    this.Close();
                }
            }
            catch (Exception)
            {
                isSave = false;
                MessageBox.Show("Modify DetailMaterial Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
