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
    public partial class TradeTerm : Form
    {
        public TradeTerm()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器  
        string sl = "";
        string idcheck = "";
        public string userid = "";
        int index = 0;

        #endregion

        #region 方法

        #region 清空文字

        private void Clean()
        {
            tb代號.Text = "";
            tb英文.Text = "";
            tb中文.Text = "";
        }

        #endregion

        #region 允許編輯

        private void Edit()
        {

            tb中文.Enabled = true;
            tb英文.Enabled = true;

        }

        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select count(TRADE_TERM_ID) as count from TRADE_TERM where TRADE_TERM_ID = '{0}'", tb代號.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idcheck = reader["count"].ToString();
                }
                dbConn.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into TRADE_TERM values('{0}','{1}','{2}','{3}',GETDATE())", tb代號.Text, tb中文.Text, tb英文.Text, userid);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception) { }

        }

        #endregion

        #region 還原按鈕

        private void TsbBack()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;

            tb代號.Enabled = false;
            tb英文.Enabled = false;
            tb中文.Enabled = false;
        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update TRADE_TERM set zwsm = '{0}', ywsm = '{1}', USERID = '{2}', USERDATE = GETDATE() where TRADE_TERM_ID = '{3}'", tb中文.Text, tb英文.Text, userid, tb代號.Text);

                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();
            }
            catch (Exception) { }
        }


        #endregion

        #region 重新讀取

        private void Reload()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from TRADE_TERM ");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            dataGridView1.DataSource = ds.Tables[0];
        }

        #endregion

        #endregion

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                TradeTermQuery Form = new TradeTermQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Visible = true;

                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch (Exception)
            { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tb代號.Text = "";
            tb英文.Text = "";
            tb中文.Text = "";
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                sl = "2";
                Edit();
                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbPrior.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false;
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sl == "1") //新增
                {
                    CheckID();
                    if (idcheck == "1")
                    {
                        MessageBox.Show("ID重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (tb代號.Text == "" || tb英文.Text == "" || tb中文.Text == "")
                        {
                            MessageBox.Show("內容不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            InsertData();
                        }
                    }
                }
                else if (sl == "2") //修改
                {
                    Console.WriteLine("MODIFY");
                    ModifyData();
                }

                sl = "";
                TsbBack();
                Reload();
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            TsbBack();
            Reload();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                tsbPrior.Enabled = false;
                tsbNext.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbPrior_Click(object sender, EventArgs e)
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

                }
                tsbNext.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbNext_Click(object sender, EventArgs e)
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

                }
                tsbPrior.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                tsbNext.Enabled = false;
                tsbPrior.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void TradeTerm_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
        }
    }
}
