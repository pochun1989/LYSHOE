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
    /// MaterialMainInformationSupplier 材料供應商操作頁面
    /// </summary>
    public partial class MMIS : Form
    {
        #region 變數

        public string USERID;
        public string cldh, zsdh; // 外部傳入值(材料編號,廠商編號)
        /// <summary>
        /// 外部傳入值(MOQ,高標存量,低標存量,最大採購量,單位(用量直接帶),客戶,採購區域)
        /// </summary>
        public string moq, highstock, lowstock, highpurchqty, unit, client, cqdh;

        public bool isSave = false; // 是否儲存
        DataSet ds = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MMIS";

        #endregion

        #region 構造函式

        public MMIS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MaterialMainInformationSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                USERID = Program.User.userID;

                if (zsdh == null) // 新增
                {
                    SupplierGetCombobox();
                    tbMOQS.Text = moq;
                    tbHighStockS.Text = highstock;
                    tbLowStockS.Text = lowstock;
                    tbHighPurchQTYS.Text = highpurchqty;
                    cbUnit.SelectedValue = unit;
                    cbCQDH.Text = cqdh;
                }
                else // 修改
                {
                    GetSupplierData();
                }

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;
                //更改語言
                ChangeLabel();
                ChangeDataView();
            }
            catch (Exception) { }
        }

        #endregion

        #region 載入下拉選單按鈕事件

        #region 客戶

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                ClientCombobox();
            }
            catch (Exception) { }
        }  

        #endregion

        #endregion

        #region 清除客戶下拉選單資料

        private void btnCancelClient_Click(object sender, EventArgs e)
        {
            try
            {
                cbClient.DataSource = null;
            }
            catch (Exception) { }
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (zsdh == null) // 新增
                {
                    ds = new DataSet();
                    DBconnect dbconn = new DBconnect();
                    string sqlchk = string.Format("select * from supplier_list " +
                        "where cldh='{0}' and zsdh='{1}'", cldh, cbVendor.SelectedValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlchk, dbconn.connection);
                    adapter.Fill(ds, "供應商表");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Factory! Please Select Another Factory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InsertSupplierList();
                    }
                }
                else // 修改
                {
                    ModifySupplierList();
                }
            }
            catch (Exception) { }
        } 

        #endregion

        #region 離開按鈕事件

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 交期限制輸入數字

        private void tbDeliveryDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLower(e.KeyChar))
                {
                    tbDeliveryDate.SelectedText = char.ToUpper(e.KeyChar).ToString();
                }
                InputLimit(e);
            }
            catch (Exception) { }
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 限制輸入方法(只可輸入數字)

        private void InputLimit(KeyPressEventArgs e)
        {
            try
            {
                if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 顯示下拉選單項目方法(客戶,廠商,採購單位)
        
        // 客戶(按鈕觸發)
        private void ClientCombobox()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 客戶
                string sql1 = "select kfdh,kfjc from kfzl order by kfdh";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "客戶表");
                cbClient.DataSource = ds.Tables[0];
                cbClient.ValueMember = "kfdh";
                cbClient.DisplayMember = "kfjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Client Combobox Error!");
            }
        }
        
        // 廠商與單位
        private void SupplierGetCombobox()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 用量單位
                string sql1 = "select Unit_ID,ywsm from UNIT";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "Unit");
                cbUnit.DataSource = ds.Tables[0];
                cbUnit.ValueMember = "Unit_ID";
                cbUnit.DisplayMember = "ywsm";

                // 廠商
                string sql2 = "select distinct s.zsdh,z.zsjc from supplier_list s left join zszl z on z.zsdh=s.zsdh where z.zsjc is not null order by zsjc";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(ds, "廠商表");
                cbVendor.DataSource = ds.Tables[1];
                cbVendor.ValueMember = "zsdh";
                cbVendor.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier Combobox Error!");
            }
        }

        #endregion

        #region 取得選取資料(編輯呼叫)

        private void GetSupplierData()
        {
            SupplierGetCombobox();
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("select * from supplier_list where cldh='{0}' and zsdh='{1}' and kfdh='{2}'", cldh, zsdh, client);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.cbVendor.SelectedValue = reader["zsdh"].ToString();
                    if (reader["CQDH"].ToString() == "")
                    {
                        this.cbCQDH.SelectedIndex = -1;
                    }
                    else
                    {
                        this.cbCQDH.Text = reader["CQDH"].ToString();
                    }
                    if (reader["kfdh"].ToString().Trim() != "" && reader["kfdh"].ToString().Trim() != "0")
                    {
                        btnClient.PerformClick();
                        this.cbClient.SelectedValue = reader["kfdh"].ToString();
                    }
                    this.tbSmallPackaging.Text = reader["Packing_Min_Qty"].ToString();
                    this.tbMOQS.Text = reader["MOQ"].ToString();
                    this.tbHighStockS.Text = reader["HIGH_STOCK"].ToString();
                    this.tbLowStockS.Text = reader["LOW_STOCK"].ToString();
                    this.tbHighPurchQTYS.Text = reader["HIGH_PURCH_QTY"].ToString();
                    this.tbDeliveryDate.Text = reader["leadtime"].ToString();
                    this.tbSmallPackagingWeight.Text = reader["weight"].ToString();
                    this.cbUnit.SelectedValue = reader["unit_id"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Get Supplier Data Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 新增供應商方法

        private void InsertSupplierList()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sqlSup = string.Format("insert into supplier_list (cldh,zsdh,PM_ID,kfdh,Packing_Min_Qty,MOQ,HIGH_STOCK,LOW_STOCK,HIGH_PURCH_QTY,leadtime,weight,unit_id,SL_CLASS,USERID,USERDATE,CQDH) " +
                    "values('{0}','{1}','','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','1','{11}','{12}',{13})"
                    , cldh, cbVendor.SelectedValue, cbClient.DataSource == null ? "" : cbClient.SelectedValue
                    , tbSmallPackaging.Text == "" ? "0.00" : tbSmallPackaging.Text, tbMOQS.Text == "" ? "0.0000" : tbMOQS.Text, tbHighStockS.Text == "" ? "0.000" : tbHighStockS.Text, tbLowStockS.Text == "" ? "0.000" : tbLowStockS.Text, tbHighPurchQTYS.Text == "" ? "0.000" : tbHighPurchQTYS.Text
                    , tbDeliveryDate.Text == "" ? "0" : tbDeliveryDate.Text, tbSmallPackagingWeight.Text == "" ? "0.00" : tbSmallPackagingWeight.Text, cbUnit.SelectedValue
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd"), cbCQDH.Text == "" ? "null" : "'" + cbCQDH.Text + "'");
                SqlCommand cmd = new SqlCommand(sqlSup, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    isSave = true;
                    MessageBox.Show("Insert SupplierData Success!");
                    this.Close();
                }

            }
            catch (Exception)
            {
                isSave = false;
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 修改供應商方法

        private void ModifySupplierList()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update supplier_list set zsdh='{0}',kfdh='{1}',Packing_Min_Qty='{2}',MOQ='{3}',HIGH_STOCK='{4}',LOW_STOCK='{5}'" +
                    ",leadtime={6},weight='{7}',unit_id='{8}',USERID='{9}',USERDATE='{10}',CQDH={11} " +
                    "where cldh='{12}' and zsdh='{13}'"
                    , cbVendor.SelectedValue, cbClient.DataSource == null ? "" : cbClient.SelectedValue
                    , tbSmallPackaging.Text == "" ? "0.00" : tbSmallPackaging.Text, tbMOQS.Text == "" ? "0.0000" : tbMOQS.Text, tbHighStockS.Text == "" ? "0.0000" : tbHighStockS.Text, tbLowStockS.Text == "" ? "0.0000" : tbLowStockS.Text
                    , tbDeliveryDate.Text == "" ? "0" : tbDeliveryDate.Text, tbSmallPackagingWeight.Text == "" ? "0.00" : tbSmallPackagingWeight.Text, cbUnit.SelectedValue
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd"), cbCQDH.Text == "" ? "null" : "'" + cbCQDH.Text + "'"
                    , cldh, zsdh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    isSave = true;
                    MessageBox.Show("Modify SupplierData Success!");
                    this.Close();
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

        #endregion


    }
}
