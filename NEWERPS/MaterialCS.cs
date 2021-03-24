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
    /// MaterialClassSet 材料分類設定
    /// </summary>
    public partial class MaterialCS : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        public string USERID;
        private bool dgvAOrB = true; // 判斷主材料表或子材料表 
        private int rowindex; // 儲存當前點擊DGV的rowindex

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MaterialCS";

        #endregion

        #region 建構函式

        public MaterialCS()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MaterialClassSet_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 主材料事件 A

        #region 查詢按鈕事件(Class_A)

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            ClassADataQuery();
            dgvClassA_CellClick(dgvClassA, new DataGridViewCellEventArgs(0, 0));
        }

        #endregion

        #region 載入DGV主材料事件(Class_A)

        private void dgvClassA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = dgvClassA.CurrentRow.Cells[0].RowIndex;
            dgvAOrB = true;
            if (dgvClassA.Rows.Count != 0)
            {
                ClassBDataQuery(this.dgvClassA.CurrentRow.Cells[0].Value);
            }
            DecideMainOrDetail();
        }

        #endregion

        #region 主材料新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            dgvAOrB = true;
            MaterialCSD mcsd = new MaterialCSD();
            mcsd.dgvAOrB = this.dgvAOrB;
            mcsd.InsorMod = "Insert";
            mcsd.ShowDialog();
            if (this.dgvClassA.CurrentRow != null)
            {
                ClassADataQuery();
            }
        }

        #endregion

        #region 主材料刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteMaterialClass();
        }

        #endregion

        #region 主材料編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            dgvAOrB = true;
            MaterialCSD mcsd = new MaterialCSD();
            mcsd.dgvAOrB = this.dgvAOrB;
            mcsd.InsorMod = "Modify";
            mcsd.publicText = this.dgvClassA.CurrentRow.Cells[1].Value.ToString().Trim();
            mcsd.publicTextEN = this.dgvClassA.CurrentRow.Cells[2].Value.ToString().Trim();
            mcsd.classID = this.dgvClassA.CurrentRow.Cells[0].Value.ToString();
            mcsd.ShowDialog();
            if (this.dgvClassA.CurrentRow != null)
            {
                ClassADataQuery();
            }
            AfterOPFocus(dgvClassA);
        }

        #endregion

        #endregion

        #region 子材料事件 B

        #region 載入DGV子材料事件(Class_B)

        private void dgvClassB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = dgvClassB.CurrentRow.Cells[0].RowIndex;
            dgvAOrB = false;
            DecideMainOrDetail();
        }

        #endregion

        #region 子材料新增按鈕事件

        private void tsbInsert2_Click(object sender, EventArgs e)
        {
            dgvAOrB = false;
            MaterialCSD mcsd = new MaterialCSD();
            mcsd.dgvAOrB = this.dgvAOrB;
            mcsd.InsorMod = "Insert";
            mcsd.publicText = this.dgvClassA.CurrentRow.Cells[1].Value.ToString().Trim();
            mcsd.classID = this.dgvClassA.CurrentRow.Cells[0].Value.ToString();
            mcsd.ShowDialog();
            if (this.dgvClassA.CurrentRow != null)
            {
                ClassBDataQuery(this.dgvClassA.CurrentRow.Cells[0].Value);
            }
        }

        #endregion

        #region 子材料刪除按鈕事件

        private void tsbDelete2_Click(object sender, EventArgs e)
        {
            DeleteMaterialClass();
        }

        #endregion

        #region 子材料編輯按鈕事件

        private void tsbModify2_Click(object sender, EventArgs e)
        {
            dgvAOrB = false;
            MaterialCSD mcsd = new MaterialCSD();
            mcsd.dgvAOrB = this.dgvAOrB;
            mcsd.InsorMod = "Modify";
            mcsd.publicText = this.dgvClassA.CurrentRow.Cells[1].Value.ToString().Trim();
            mcsd.publicTextEN = this.dgvClassA.CurrentRow.Cells[2].Value.ToString().Trim();
            mcsd.classID = this.dgvClassA.CurrentRow.Cells[0].Value.ToString();
            mcsd.ShowDialog();
            if (this.dgvClassA.CurrentRow != null)
            {
                ClassBDataQuery(this.dgvClassA.CurrentRow.Cells[0].Value);
            }
            AfterOPFocus(dgvClassB);
        }

        #endregion

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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 操作後的焦點資料方法

        private void AfterOPFocus(DataGridView dgv)
        {
            int columnindex = 1;
            dgv.Focus();
            dgv.CurrentCell = dgv[columnindex, rowindex];
        }

        #endregion

        #region 判斷目前滑鼠點擊的DGV

        private void DecideMainOrDetail()
        {
            if (dgvAOrB) // 主材料
            {
                tsbDelete.Enabled = true;
                tsbModify.Enabled = true;
                tsbInsert2.Enabled = true;
                tsbDelete2.Enabled = false;
                tsbModify2.Enabled = false;
                tsbQuery2.Enabled = true;
            }
            if (!dgvAOrB) // 子材料
            {
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbInsert2.Enabled = false;
                tsbDelete2.Enabled = true;
                tsbModify2.Enabled = true;
                tsbQuery2.Enabled = false;
            }
        }

        #endregion

        #region 查詢主材料方法(Class_A)

        private void ClassADataQuery()
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = "select Class_ID 類別代號, zwsm 中文說明, ywsm 英文說明 from CLASS_A";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "主材料表");
                this.dgvClassA.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Query Main Error!");
            }
        }

        #endregion

        #region 查詢子材料方法(Class_B)

        private void ClassBDataQuery(object CID)
        {
            tsbModify2.Enabled = false;
            tsbDelete2.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select b.cllb 材料類別, b.zwsm 中文說明, b.ywsm 英文說明 " +
                    "from CLASS_B b " +
                    "left join CLASS_A a on a.Class_ID=b.Class_ID " +
                    "where b.Class_ID='{0}'", CID);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "子材料表");
                this.dgvClassB.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Query Detail Error!");
            }
        }

        #endregion

        #region 刪除材料方法

        private void DeleteMaterialClass()
        {
            DBconnect dbConn = new DBconnect();
            try
            {
                if (this.dgvAOrB) // 主材料刪除
                {
                    DialogResult dr = MessageBox.Show("Delete " + dgvClassA.CurrentRow.Cells[1].Value.ToString().Trim() + " This Main Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string cl = dgvClassA.CurrentRow.Cells[0].Value.ToString();
                        string sql = string.Format("if exists" +
                            "(select * from CLASS_B where Class_ID='{0}') " +
                            "select * from CLASS_A where Class_ID='NOTEXIST' " +
                            "else delete from CLASS_A where Class_ID='{1}'"
                            , cl, cl);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Main Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ClassADataQuery();
                        }
                        else if (result == -1)
                        {
                            MessageBox.Show("Detail material already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else // 子材料刪除
                {
                    DialogResult dr = MessageBox.Show("Delete " + dgvClassB.CurrentRow.Cells[1].Value.ToString().Trim() + " This Detail Data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("delete from CLASS_B where cllb='{0}'", dgvClassB.CurrentRow.Cells[0].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Delete Detail Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (this.dgvClassA.CurrentRow != null)
                            {
                                ClassBDataQuery(this.dgvClassA.CurrentRow.Cells[0].Value);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConn.CloseConnection();
            }
        }

        #endregion

        #endregion

        
    }
}
