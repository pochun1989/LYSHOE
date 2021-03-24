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
    /// SampleOrderShoeModelBOMCLBH 鞋型BOM材料主檔
    /// </summary>
    public partial class SOSMBOMCLBH : Form
    {
        #region 變數

        DataSet dsqA = new DataSet(); // ClassA下拉選單容器
        DataSet dsqB = new DataSet(); // ClassB下拉選單容器
        DataSet dsclzl = new DataSet(); // 材料主檔容器
        DataSet dsVendor = new DataSet(); // 附值容器(材料主檔)
        private string caID; // 下拉單搜尋值(Class_A.ID)
        public bool isc = false; // 是否Comfirm
        /// <summary>
        /// Formal:正式料號, Temporary:臨時料號
        /// </summary>
        public string selectmnum = "Formal";
        /// <summary>
        /// 輸出至外部變數(材料編號,中英文;廠商編號,縮寫)
        /// </summary>
        public string 材料編號, 中文, 英文, 廠商編號, 廠商縮寫, 是否臨時料號;

        #endregion

        #region 構造函式

        public SOSMBOMCLBH()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件
        
        #region 頁面載入

        private void SampleOrderShoeModelBOMCLBH_Load(object sender, EventArgs e)
        {
            ClassACombobox();
            if (材料編號 != "")
            {
                GetMaterialInformation(材料編號, 是否臨時料號, 廠商編號);
            }
        }

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // (小分類value , 材料名稱模糊查詢)
            QueryMaterial(cbClassBQuery.SelectedValue.ToString(), tbzwpm.Text);
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvCLZL.CurrentRow == null)
            {
                MessageBox.Show("Please Select One Material!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.材料編號 = this.dgvCLZL.CurrentRow.Cells[0].Value.ToString();
                this.中文 = this.dgvCLZL.CurrentRow.Cells[1].Value.ToString();
                this.英文 = this.dgvCLZL.CurrentRow.Cells[2].Value.ToString();
                this.廠商編號 = this.cbVendor.Visible == true ? dsVendor.Tables[0].Rows.Count == 0 ? "" : this.cbVendor.SelectedValue.ToString() : dgvCLZL.CurrentRow.Cells[3].Value.ToString();
                this.廠商縮寫 = this.cbVendor.Visible == true ? this.cbVendor.Text : dgvCLZL.CurrentRow.Cells[4].Value.ToString();
                this.isc = true;
                this.Close();
            }
        } 

        #endregion

        #region 下拉選單改變(大分類)

        // 大分類
        private void cbClassAQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbClassBQuery.Text = "";
            if (!chkIsChangecldh.Checked)
            {
                caID = dsqA.Tables[0].Rows[cbClassAQuery.SelectedIndex]["Class_ID"].ToString();
                ClassBCombobox(caID);
            }
        }

        #endregion

        #region DGV點擊事件(確認材料編號)
        
        private void dgvCLZL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbVendor.DataSource = null;
            GetZSZLCombobox(this.dgvCLZL.CurrentRow.Cells[0].Value.ToString());
        }

        #endregion

        #region 正式與臨時料號更換事件

        private void chkIsChangecldh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsChangecldh.Checked) // 臨時料號
            {
                chkIsChangecldh.Text = "Temporary";
                selectmnum = chkIsChangecldh.Text;
                cbClassAQuery.DataSource = null;
                cbClassAQuery.Enabled = false;
                ClassBCombobox("");
                label1.Visible = false;
                cbVendor.Visible = false;
            }
            else // 正式料號
            {
                chkIsChangecldh.Text = "Formal";
                selectmnum = chkIsChangecldh.Text;
                cbClassAQuery.Enabled = true;
                ClassACombobox();
                label1.Visible = true;
                cbVendor.Visible = true;
            }
        } 

        #endregion

        #endregion

        #region 方法

        #region 顯示下拉選單

        #region 大分類

        private void ClassACombobox()
        {
            dsqA = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = "select Class_ID,zwsm from CLASS_A";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsqA, "CLASS_A");
                cbClassAQuery.DataSource = dsqA.Tables[0];
                cbClassAQuery.ValueMember = "Class_ID";
                cbClassAQuery.DisplayMember = "zwsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Class A Combobox Error!");
            }
        }

        #endregion

        #region 小分類

        private void ClassBCombobox(string classAid)
        {
            dsqB = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (!chkIsChangecldh.Checked) // 正式料號
                {
                    string sql = string.Format("select cllb,zwsm from CLASS_B where Class_ID='{0}'", classAid);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsqB, "CLASS_B");
                }
                else
                {
                    string sql = "select distinct ct.cllb,cb.zwsm from clzltemp ct left join CLASS_B cb on cb.cllb=ct.cllb where ct.cldh is null";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsqB, "CLASS_B");
                }
                cbClassBQuery.DataSource = dsqB.Tables[0];
                cbClassBQuery.ValueMember = "cllb";
                cbClassBQuery.DisplayMember = "zwsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Class B Combobox Error!");
            }
        }

        #endregion

        #region 廠商
        
        private void GetZSZLCombobox(string cldh)
        {
            dsVendor = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 廠商
                string sql1 = string.Format("select distinct s.zsdh,z.zsjc from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh where cldh='{0}' order by zsdh", cldh);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsVendor, "廠商表");
                cbVendor.DataSource = dsVendor.Tables[0];
                cbVendor.ValueMember = "zsdh";
                cbVendor.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("zszl Combobox Error!");
            }
        }

        #endregion

        #endregion
        //
        #region 編輯時值回寫

        private void GetMaterialInformation(string cldh,string istemp,string csbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql;
                if (istemp == "") // 正式料號
                {
                    chkIsChangecldh.Checked = false;
                    sql = string.Format("select SUBSTRING(cllb,1,1) classA,cllb,cldh from clzl where cldh='{0}'", cldh);
                }
                else // 臨時料號
                {
                    chkIsChangecldh.Checked = true;
                    sql = string.Format("select SUBSTRING(cllb,1,1) classA,cllb,tempddbh cldh from clzltemp where tempddbh='{0}'", cldh);
                }
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cbClassAQuery.SelectedValue = reader["classA"].ToString();
                    cbClassBQuery.SelectedValue = reader["cllb"].ToString();
                }
                btnQuery.PerformClick();
                //LOCATE
                DataRow[] rows = dsclzl.Tables[0].Select("材料編號='" + cldh + "'");
                if (rows.Length == 0)
                {
                    MessageBox.Show("空");
                }
                else
                {
                    int index = dsclzl.Tables[0].Rows.IndexOf(rows[0]);
                    dgvCLZL.CurrentCell = dgvCLZL.Rows[index].Cells[0];
                    dgvCLZL_CellClick(dgvCLZL, new DataGridViewCellEventArgs(index, 0));
                }
                cbVendor.SelectedValue = csbh;
            }
            catch (Exception)
            {
                MessageBox.Show("Get Material Data Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 查詢材料方法

        // 主動點擊
        private void QueryMaterial(string classBid,string materialname)
        {
            dsclzl = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (!chkIsChangecldh.Checked) // 正式料號
                {
                    string sql = string.Format("select cldh 材料編號,zwpm 中,ywpm 英 from clzl where cllb='{0}' and (zwpm like '%{1}%' or ywpm like '%{2}%') order by cldh"
                        , classBid, materialname, materialname);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsclzl, "clzl");
                }
                else // 臨時料號
                {
                    string sql = string.Format("select tempddbh 材料編號,zwpm 中,ywpm 英,zsbh,zsjc from clzltemp left join zszl on zszl.zsdh=clzltemp.zsbh where cldh is null and cllb='{0}' and (zwpm like '%{1}%' or ywpm like '%{2}%') order by tempddbh"
                        , classBid, materialname, materialname);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsclzl, "clzl");
                }
                dgvCLZL.DataSource = dsclzl.Tables[0];
                if (chkIsChangecldh.Checked)
                {
                    dgvCLZL.Columns[3].Visible = false;
                    dgvCLZL.Columns[4].Visible = false;
                }
                dgvCLZL.Columns[0].Width = 80;
                dgvCLZL_CellClick(dgvCLZL, new DataGridViewCellEventArgs(0, 0));
            }
            catch (Exception)
            {
                MessageBox.Show("Query CLZL Error!");
            }
        }
        
        #endregion

        #endregion


    }
}
