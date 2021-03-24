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
    public partial class LanguageModify : Form
    {
        public LanguageModify()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "";
        DataSet ds2 = new DataSet();
        public string sl = ""; //1 insert //2 modify
        int index = 0;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "1_11_1";
        Boolean insertCheck, insertCheck2 = true;
        string ldata = "";
        #endregion

        private void LanguageModify_Load(object sender, EventArgs e)
        {


            try
            {
                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.DataTable1' 資料表。您可以視需要進行移動或移除。
                //this.dataTable1TableAdapter.Fill(this.lY_TESTDataSet.DataTable1);

                userid = Program.User.userID;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                LoadText();

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;


                //更改語言
                ChangeLabel();
                ChangeDataView();
            }
            catch (Exception) 
            { }

        }

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

        #region 重新載入

        private void Reload()
        {            

            ds2 = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select distinct a.FORM_ID,a.LAB_ID,b.SHOW_DATA as '中文', c.SHOW_DATA as '英文' ,d.SHOW_DATA as '越文' ,e.SHOW_DATA as '緬甸文' from(select * from MMDATA where FORM_ID = '{0}')as a left join(select * from MMDATA where MM_ID = 1 and FORM_ID = '{1}') as b on a.FORM_ID = b.FORM_ID and a.LAB_ID = b.LAB_ID left join(select * from MMDATA  where MM_ID = 2  and FORM_ID = '{2}') as c on a.FORM_ID = c.FORM_ID and a.LAB_ID = c.LAB_ID left join(select * from MMDATA where MM_ID = 3  and FORM_ID = '{3}') as d on a.FORM_ID = d.FORM_ID and a.LAB_ID = d.LAB_ID left join(select * from MMDATA where MM_ID = 4  and FORM_ID = '{4}') as e on a.FORM_ID = e.FORM_ID and a.LAB_ID = e.LAB_ID order by a.FORM_ID, a.LAB_ID", ldata, ldata, ldata, ldata, ldata);
            Console.WriteLine(sql);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds2, "棧板表");
            this.dataGridView1.DataSource = this.ds2.Tables[0];
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
                dataGridView1.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView1.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView1.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dataGridView1.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView1.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView1.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                //dgvPro.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                //dgvPro.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                //dgvPro.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                //dgvPro.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
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

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 載入文字方法

        private void LoadText()
        {
            try
            {
                tb表單.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb條碼.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb越南文.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tb緬甸文.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {
                if (tb表單.Text != "" && tb條碼.Text != "")
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into MMDATA values('1','{0}','{1}','{2}','{3}',GETDATE())", tb表單.Text, tb條碼.Text, tb中文.Text, userid);

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();

                    string sql2 = string.Format("insert into MMDATA values('2','{0}','{1}','{2}','{3}',GETDATE())", tb表單.Text, tb條碼.Text, tb英文.Text, userid);

                    SqlCommand cmd2 = new SqlCommand(sql2, conn.connection);
                    conn.OpenConnection();
                    result = cmd2.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();

                    string sql3 = string.Format("insert into MMDATA values('3','{0}','{1}','{2}','{3}',GETDATE())", tb表單.Text, tb條碼.Text, tb越南文.Text, userid);

                    SqlCommand cmd3 = new SqlCommand(sql3, conn.connection);
                    conn.OpenConnection();
                    result = cmd3.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();

                    string sql4 = string.Format("insert into MMDATA values('4','{0}','{1}','{2}','{3}',GETDATE())", tb表單.Text, tb條碼.Text, tb緬甸文.Text, userid);

                    SqlCommand cmd4 = new SqlCommand(sql4, conn.connection);
                    conn.OpenConnection();
                    result = cmd4.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();

                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.DataTable1' 資料表。您可以視需要進行移動或移除。
                    this.dataTable1TableAdapter.Fill(this.lY_TESTDataSet.DataTable1);

                }
                else 
                {
                    MessageBox.Show("表單條碼不可為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }

        }

        #endregion

        #region 按鈕還原

        private void tsbBack()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbDelete.Enabled = true;
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;
            tsbPrint.Enabled = false;

                       
            tb表單.Enabled = false;
            tb條碼.Enabled = false;
            tb中文.Enabled = false;
            tb英文.Enabled = false;
            tb越南文.Enabled = false;
            tb緬甸文.Enabled = false;

        }

        #endregion

        #region 刪除

        private void DeleteFactory()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("delete MMDATA where FORM_ID = '{0}' and LAB_ID = '{1}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 >= 1)
            {
                MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //CompanyDataLoading("1");
            }

        }

        #endregion

        #region 修改方法

        private void ModifyFactory()
        {
            try
            {
                int result4;
                DBconnect con4 = new DBconnect();
                if (tb中文.Text != "")
                {
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = '{2}',userid = '{3}',UserDate = GETDATE() where MM_ID = '1' and FORM_ID = '{4}' and LAB_ID = '{5}'", tb表單.Text, tb條碼.Text, tb中文.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }
                else 
                {
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = NULL,userid = '{2}',UserDate = GETDATE() where MM_ID = '1' and FORM_ID = '{3}' and LAB_ID = '{4}'", tb表單.Text, tb條碼.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }

                if (tb英文.Text != "")
                {
                    StringBuilder sql5 = new StringBuilder();
                    sql5.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = '{2}',userid = '{3}',UserDate = GETDATE() where MM_ID = '2' and FORM_ID = '{4}' and LAB_ID = '{5}'", tb表單.Text, tb條碼.Text, tb英文.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd5.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }
                else 
                {
                    StringBuilder sql5 = new StringBuilder();
                    sql5.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = NULL,userid = '{2}',UserDate = GETDATE() where MM_ID = '2' and FORM_ID = '{3}' and LAB_ID = '{4}'", tb表單.Text, tb條碼.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd5.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }

                if (tb越南文.Text != "")
                {
                    StringBuilder sql6 = new StringBuilder();
                    sql6.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = '{2}',userid = '{3}',UserDate = GETDATE() where MM_ID = '3' and FORM_ID = '{4}' and LAB_ID = '{5}'", tb表單.Text, tb條碼.Text, tb越南文.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd6.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }
                else 
                {
                    StringBuilder sql6 = new StringBuilder();
                    sql6.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = NULL,userid = '{2}',UserDate = GETDATE() where MM_ID = '3' and FORM_ID = '{3}' and LAB_ID = '{4}'", tb表單.Text, tb條碼.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd6.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }

                if (tb緬甸文.Text != "")
                {
                    StringBuilder sql7 = new StringBuilder();
                    sql7.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = '{2}',userid = '{3}',UserDate = GETDATE() where MM_ID = '4' and FORM_ID = '{4}' and LAB_ID = '{5}'", tb表單.Text, tb條碼.Text, tb緬甸文.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd7 = new SqlCommand(sql7.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd7.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }
                else 
                {
                    StringBuilder sql7 = new StringBuilder();
                    sql7.AppendFormat("update MMDATA set FORM_ID = '{0}' , LAB_ID = '{1}',SHOW_DATA = NULL,userid = '{2}',UserDate = GETDATE() where MM_ID = '4' and FORM_ID = '{3}' and LAB_ID = '{4}'", tb表單.Text, tb條碼.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd7 = new SqlCommand(sql7.ToString(), con4.connection);
                    con4.OpenConnection();
                    result4 = cmd7.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }

                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.DataTable1' 資料表。您可以視需要進行移動或移除。
                this.dataTable1TableAdapter.Fill(this.lY_TESTDataSet.DataTable1);
            }
            catch (Exception) { }
        }

        #endregion

        #region 清空方法

        private void Clean()
        {
            tb表單.Text = "";
            tb條碼.Text = "";
            tb中文.Text = "";
            tb英文.Text = "";
            tb越南文.Text = "";
            tb緬甸文.Text = "";
        }

        #endregion



        #region 檢查重複

        private void CheckInsert2()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where  FORM_ID = '{0}' and LAB_ID = '{1}' and SHOW_DATA = '{2}'", tb表單.Text, tb條碼.Text, tb中文.Text);
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                insertCheck2 = false;
            }

        }

        #endregion

        #endregion

        #region 事件

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageQuery Form = new LanguageQuery();
                Form.ShowDialog();
                this.dataGridView1.DataSource = Form.ds2.Tables[0];
                LoadText();
            }
            catch (Exception) { }
        }

        private void TsbClear_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void TsbInsert_Click(object sender, EventArgs e)
        {

            Clean();


            tb表單.Enabled = true;
            tb條碼.Enabled = true;
            tb中文.Enabled = true;
            tb英文.Enabled = true;
            tb越南文.Enabled = true;
            tb緬甸文.Enabled = true;

            tsbClear.Enabled = true;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            tsbFirst.Enabled = false;
            tsbPrior.Enabled = false;
            tsbNext.Enabled = false;
            tsbLast.Enabled = false;
            tsbCancel.Enabled = true;
            tsbSave.Enabled = true;
            tsbInsert.Enabled = false;

            sl = "1";
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DeleteFactory();
                }
            }
            catch (Exception)
            {
            }
        }

        private void TsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "1";
                tb表單.Enabled = true;
                tb條碼.Enabled = true;
                tb中文.Enabled = true;
                tb英文.Enabled = true;
                tb越南文.Enabled = true;
                tb緬甸文.Enabled = true;

                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbLast.Enabled = false;
                tsbNext.Enabled = false;
                tsbPrior.Enabled = false;

                sl = "2";

            }
            catch (Exception)
            {

            }
        }

        private void TsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                ldata = tb表單.Text;
                if (tb中文.Text != "")
                {
                    if (sl == "1") //insert
                    {
                        CheckInsert2();
                        if (insertCheck2 == true)
                        {
                            InsertData();
                            sl = "";
                            tsbBack();
                        }
                        else
                        {
                            MessageBox.Show("資料重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (sl == "2") //midify
                    {

                        ModifyFactory();
                        sl = "";
                        tsbBack();

                    }
                    Reload();
                    // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.DataTable1' 資料表。您可以視需要進行移動或移除。
                    //this.dataTable1TableAdapter.Fill(this.lY_TESTDataSet.DataTable1);
                    ldata = "";
                }
                else
                {
                }
            }
            catch (Exception) { }
        }

        private void TsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                tsbBack();
                sl = "";
                dataGridView1.DataSource = dataTable1BindingSource;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
            }
            catch (Exception) { }
        }

        private void TsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
                tsbBack();
            }
            catch (Exception) { }
        }

        private void TsbPrior_Click(object sender, EventArgs e)
        {
            try
            {
                int indexData;

                if (index == 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
                else
                {
                    indexData = index - 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];
                    LoadText();
                }
                tsbBack();
            }
            catch (Exception) { }
        }

        private void TsbNext_Click(object sender, EventArgs e)
        {
            try
            {
                int indexData;

                if (index == dataGridView1.RowCount - 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                }
                else
                {
                    indexData = index + 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];
                    LoadText();

                }
                tsbBack();
            }
            catch (Exception) { }
        }

        private void TsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                LoadText();
                tsbBack();
            }
            catch (Exception) { }
        }

        #endregion

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            LoadText();
        }
    }
}
