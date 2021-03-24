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
    /// MaterialMainInformationDetail 子材料新增頁面
    /// </summary>
    public partial class MMID : Form
    {
        #region 變數

        public string cldhM; // 母材料代號(外部建入)
        public int clzhzlcount; // 子材料數量(判斷是否為第一筆)
        public string clzlEN, clzlCN; // 回傳子材料中英名稱
        public string pmEN, pmCN; // 回傳加工方式中英名稱
        public int msn, psn; // 材料加工組,加工方式加工組
        public bool isSave = false; // 是否存檔
        public string USERID;
        DataSet ds = new DataSet();
        DataSet dspm = new DataSet(); // 加工容器
        DataSet dsqA = new DataSet();
        DataSet dsqB = new DataSet();
        DataSet dsqC = new DataSet();
        private string classA, classBID;

        #endregion

        #region 構造函式

        public MMID()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 視窗載入

        private void MaterialMainInformationDetail_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel2.Hide();
            lbSwitch.Text = "Material";
            USERID = Program.User.userID;
            ClassAComboboxDisplay(cbClassA); // 大類下拉選單
            if (clzhzlcount == 0) // 第一筆(子材料沒筆數)
            {
                cbMaterialSN.Items.Add(1);
                cbMaterialSN.SelectedIndex = 0;
                pcSwitch.Enabled = false;
            }
            else // 子材料有筆數
            {
                DetailGetPMCombobox(); // 加工方式下拉選單
                // 抓取目前母材料所有SN(材料與加工)
                for (int i = 0; i < msn; i++) // 材料加工組
                {
                    cbMaterialSN.Items.Add(i + 1);
                    if (i == msn - 1) // 多一筆
                    {
                        cbMaterialSN.Items.Add(i + 2);
                    }
                }
                if (psn == 0)
                {
                    cbPMSN.Items.Add(1);
                }
                else
                {
                    for (int i = 0; i < psn; i++) // 加工方式加工組
                    {
                        cbPMSN.Items.Add(i + 1);
                        if (i == psn - 1) // 多一筆
                        {
                            cbPMSN.Items.Add(i + 2);
                        }
                    }
                }
                cbMaterialSN.SelectedIndex = 0;
                cbPMSN.SelectedIndex = 0;
                pcSwitch.Enabled = true;
            }
        }

        #endregion
        
        #region 按鈕事件

        #region 查詢材料按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ClzlComboboxDisplay(classBID, tbMaterialNameQuery.Text);
        }

        #endregion

        #region 儲存按鈕事件(材料與加工方式)

        // 材料
        private void btnSaveMaterial_Click(object sender, EventArgs e)
        {
            if (tbUsage.Text != "" && cbSupplierVendorD.Text != "" && cbMaterialSN.Text != "")
            {
                clzlEN = this.dgvCLZL.CurrentRow.Cells[1].Value.ToString();
                clzlCN = this.dgvCLZL.CurrentRow.Cells[2].Value.ToString();
                InsertMaterialDetail(this.dgvCLZL.CurrentRow.Cells[0].Value.ToString(), cbMaterialSN.Text, "ZZZZ", "'" + cbSupplierVendorD.SelectedValue.ToString() + "'");
                isSave = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usage && Vender && SN Can't Be Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 加工方式
        private void btnSavePM_Click(object sender, EventArgs e)
        {
            if (cbPMSN.Text != "")
            {
                InsertMaterialDetail("ZZZZ", cbPMSN.Text, cbPM.SelectedValue.ToString(), "'" + cbSupplierVendorPM.SelectedValue.ToString() + "'");
                // pmEN, pmCN 外部呼叫
                isSave = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("SN Can't Be Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region DGV點擊事件(顯示材料供應商)

        private void dgvCLZL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbSupplierVendorD.DataSource = null;
            GetMaterialZSZLCombobox(this.dgvCLZL.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvCLZL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbSupplierVendorD.DataSource = null;
            GetMaterialZSZLCombobox(this.dgvCLZL.CurrentRow.Cells[0].Value.ToString());
        }

        #endregion

        #region TextBox Event

        #region 材料編號欄位改變事件

        private void tbCLDHQuery_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbCLDHQuery.Text == "")
            {
                cbClassA.Enabled = true;
                cbClassB.Enabled = true;
            }
            else
            {
                cbClassA.Enabled = false;
                cbClassB.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region Combobox Event

        #region 材料大分類下拉選單改變事件

        private void cbClassA_SelectedIndexChanged(object sender, EventArgs e)
        {
            classA = dsqA.Tables[0].Rows[(sender as ComboBox).SelectedIndex]["Class_ID"].ToString();
            ClassBComboboxDisplay(classA, cbClassB);
        }

        #endregion

        #region 材料小分類下拉選單改變事件

        private void cbClassB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSupplierVendorD.DataSource = null;
            classBID = dsqB.Tables[0].Rows[(sender as ComboBox).SelectedIndex]["cllb"].ToString();
        }

        #endregion

        #region 加工方式下拉選單改變事件

        private void cbPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPM.SelectedValue.ToString().Length == 10)
            {
                pmEN = dspm.Tables[0].Rows[cbPM.SelectedIndex]["ywsm"].ToString();
                pmCN = dspm.Tables[0].Rows[cbPM.SelectedIndex]["zwsm"].ToString();
                DetailGetZSZLCombobox(cbPM.SelectedValue.ToString());
            }
        }

        #endregion

        #endregion

        #region 圖片開關(新增材料或加工)

        int i = 0;
        bool b = false;
        private void pcSwitch_Click(object sender, EventArgs e)
        {
            i = i ^ 1; //做 xor 運算 ，按一下 True ，再按一下 False......... 
            b = Convert.ToBoolean(i);
            if (b)
            {
                pcSwitch.Image = Properties.Resources.switch_on;
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
                lbSwitch.Text = "Produce";
                this.Height = 250;
            }
            else
            {
                pcSwitch.Image = Properties.Resources.switch_off;
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
                lbSwitch.Text = "Material";
                this.Height = 595;
            }
        } 

        #endregion

        #endregion

        #region 方法

        #region 顯示下拉選單項目方法(大分類,小分類,材料供應商,加工方式,加工供應商)

        // 材料大分類
        private void ClassAComboboxDisplay(ComboBox comboBox)
        {
            dsqA = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料大分類
                string sql1 = "select Class_ID,ywsm from CLASS_A";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqA, "CLASS_A");
                comboBox.DataSource = dsqA.Tables[0];
                comboBox.ValueMember = "Class_ID";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Class A Combobox Error!");
            }
        }

        // 材料小分類
        private void ClassBComboboxDisplay(string classID, ComboBox comboBox)
        {
            dsqB = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料分類
                string sql1 = string.Format("select cllb,ywsm from CLASS_B where Class_ID='{0}'", classID);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqB, "CLASS_B");
                comboBox.DataSource = dsqB.Tables[0];
                comboBox.ValueMember = "cllb";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Class B Combobox Error!");
            }
        }
        
        // 材料供應商
        private void GetMaterialZSZLCombobox(string cldhs)
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
                cbSupplierVendorD.DataSource = ds.Tables[0];
                cbSupplierVendorD.ValueMember = "zsdh";
                cbSupplierVendorD.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Detail zszl Combobox Error!");
            }
        }

        // 加工方式
        private void DetailGetPMCombobox()
        {
            dspm = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 加工方式
                string sql = "select PM_ID,ywsm,zwsm from produce_method order by PM_ID";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dspm, "加工方式表");
                cbPM.DataSource = dspm.Tables[0];
                cbPM.ValueMember = "PM_ID";
                cbPM.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Detail PM Combobox Error!");
            }
        }

        // 加工供應商
        private void DetailGetZSZLCombobox(string pmid)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 廠商
                string sql1 = string.Format("select distinct s.zsdh,z.zsjc from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh where PM_ID='{0}' order by zsdh", pmid);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(ds, "廠商表");
                cbSupplierVendorPM.DataSource = ds.Tables[0];
                cbSupplierVendorPM.ValueMember = "zsdh";
                cbSupplierVendorPM.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Detail zszl Combobox Error!");
            }
        }

        #endregion

        #region 材料內容顯示方法

        private void ClzlComboboxDisplay(string classBID, string name)
        {
            dsqC = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料主檔
                string sql1 = null;
                if (tbCLDHQuery.Text == "")
                {
                    sql1 = string.Format("select cldh 子材料編號,ywpm EN,zwpm CN from clzl where cllb='{0}' and (ywpm like'%{1}%' or zwpm like'%{2}%') order by cldh", classBID, name, name);
                }
                else
                {
                    sql1 = string.Format("select cldh 子材料編號,ywpm EN,zwpm CN from clzl where cldh like'{0}%' and (ywpm like'%{1}%' or zwpm like'%{2}%') order by cldh", tbCLDHQuery.Text, name, name);
                }
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqC, "CLZL");
                dgvCLZL.DataSource = dsqC.Tables[0];
                dgvCLZL.Columns[0].Width = 120;
                dgvCLZL.CurrentCell = null;
                dgvCLZL.ClearSelection(); // 清除焦點
            }
            catch (Exception)
            {
                MessageBox.Show("CLZL Combobox Error!");
            }
        }

        #endregion
        
        #region 新增子材料方法

        private void InsertMaterialDetail(string cldhS, string sn, string pmid,string zsdh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 新增資料
                string sql = string.Format("insert into clzhzl (cldh_M,cldh_S,ccqS,SN,ccqE,syl,PM_ID,zsdh,USERID,USERDATE) " +
                    "values('{0}','{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}','{9}')"
                    , cldhM, cldhS, tbSizeStart.Text == "" ? "" : tbSizeStart.Text, sn, tbSizeEnd.Text == "" ? "" : tbSizeEnd.Text
                    , tbUsage.Text == "" ? "0" : tbUsage.Text, pmid, zsdh, USERID, DateTime.Today.ToString("yyyy-MM-dd"));
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

        #endregion


    }
}
