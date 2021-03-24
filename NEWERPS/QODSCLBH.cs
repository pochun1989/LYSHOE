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
    /// QuoteOrderDetailSelectCLBH 報價單身選擇材料
    /// </summary>
    public partial class QODSCLBH : Form
    {
        #region 變數

        public string 材料編號, 材料名稱, 單位編號; // 外部取值
        public bool isSave = false;
        DataSet dsqA = new DataSet();
        DataSet dsqB = new DataSet();
        DataSet dsqC = new DataSet();
        private string classA, classBID;

        #endregion

        #region 構造函式

        public QODSCLBH()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void QOSCLBH_Load(object sender, EventArgs e)
        {
            ClassAComboboxDisplay(cbClassA); // 大類下拉選單
            if (材料編號 != "")
            {
                cbClassA.SelectedValue = 材料編號.Substring(0, 1);
                cbClassB.SelectedValue = 材料編號.Substring(0, 3);
                ClzlDisplay(材料編號);
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ClzlDisplay(classBID, tbMaterialNameQuery.Text);
        }

        #endregion

        #region Combobox Event

        // 大分類
        private void cbClassA_SelectedIndexChanged(object sender, EventArgs e)
        {
            classA = dsqA.Tables[0].Rows[(sender as ComboBox).SelectedIndex]["Class_ID"].ToString();
            ClassBComboboxDisplay(classA, cbClassB);
        }

        // 小分類
        private void cbClassB_SelectedIndexChanged(object sender, EventArgs e)
        {
            classBID = dsqB.Tables[0].Rows[(sender as ComboBox).SelectedIndex]["cllb"].ToString();
        }

        #endregion

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

        #region DGV點擊事件(儲存資料)

        // 單點
        private void dgvCLZL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // 雙點(儲存)
        private void dgvCLZL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            材料編號 = dgvCLZL.CurrentRow.Cells[0].Value.ToString();
            材料名稱 = dgvCLZL.CurrentRow.Cells[1].Value.ToString();
            單位編號 = dgvCLZL.CurrentRow.Cells[3].Value.ToString();
            isSave = true;
            this.Close();
        } 

        #endregion

        #endregion

        #region 方法

        #region 下拉選單內容(大小分類)

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

        #endregion

        #region 材料內容顯示方法

        // 查詢顯示
        private void ClzlDisplay(string classBID, string name)
        {
            dsqC = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料主檔
                string sql1 = null;
                if (tbCLDHQuery.Text == "")
                {
                    sql1 = string.Format("select cldh 子材料編號,ywpm EN,zwpm CN,dwbh from clzl where cllb='{0}' and (ywpm like'%{1}%' or zwpm like'%{2}%') order by cldh", classBID, name, name);
                }
                else
                {
                    sql1 = string.Format("select cldh 子材料編號,ywpm EN,zwpm CN,dwbh from clzl where cldh like'{0}%' and (ywpm like'%{1}%' or zwpm like'%{2}%') order by cldh", tbCLDHQuery.Text, name, name);
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

        // 修改載入Locate
        private void ClzlDisplay(string clbh)
        {
            dsqC = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql1 = string.Format("select cldh,ywpm EN,zwpm CN,dwbh from clzl " +
                    "where cldh like SUBSTRING('{0}',1,3)+'%' order by cldh", clbh);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqC, "CLZL");
                dgvCLZL.DataSource = dsqC.Tables[0];
                dgvCLZL.Columns[0].Width = 120;
                DataRow[] rows = dsqC.Tables[0].Select("cldh='" + clbh + "'");
                if (rows.Length == 0)
                {
                    MessageBox.Show("空");
                }
                else
                {
                    int index = dsqC.Tables[0].Rows.IndexOf(rows[0]);
                    dgvCLZL.CurrentCell = dgvCLZL.Rows[index].Cells[0];
                    dgvCLZL_CellClick(dgvCLZL, new DataGridViewCellEventArgs(index, 0));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CLZL Locate Error!");
            }
        }

        #endregion

        #endregion

    }
}
