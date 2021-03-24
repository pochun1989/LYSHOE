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
    public partial class SizeCountry : Form
    {
        #region 建構函式
        public SizeCountry()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        //string rowno = "";
        string sl = "";
        int index = 0;
        //Boolean checkName = true;
        public string userid = "";
        public string languageType;
        Boolean checkcq = true;
        string sizeid = "";

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "2_2";


        #endregion

        #region 畫面載入
        private void SizeCountry_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();
            ChangeDataView();
        }
        #endregion

        #region 方法

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            try
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
            catch (Exception) { }
        }

        #endregion

        #region 切換 dgv

        private void ChangeDataView()
        {
            try
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
            catch (Exception) { }
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
                    dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 載入文字

        private void LoadText()
        {
            tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbsize.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb備註.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        #endregion

        #region 復原按鍵

        private void RecoverBtn()
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
            tsbPrint.Enabled = false;


            tbsize.Enabled = false;
            tb備註.Enabled = false;
            tbID.Enabled = false;
        }

        #endregion

        #region 清空

        private void Clean1()
        {
            tbsize.Text = "";
            tb備註.Text = "";

        }

        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from CSSize where SIZE_Name = '{0}'", tbsize.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    checkcq = false;
                }
            }
            catch (Exception)
            { }
        }

        #endregion

        #region 刪除方法
        public void DeleteData()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("delete CSSize where SIZE_Name = '{0}'  and SIZE_ID = '{1}'", dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 清空方法

        private void Clean()
        {
            tbsize.Text = "";
            tb備註.Text = "";

            tbsize.Enabled = true;
            tb備註.Enabled = true;
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

            tbsize.Enabled = false;
            tb備註.Enabled = false;
            tbID.Enabled = false;
        }

        #endregion

        #region 最大ID

        private void IDMax()
        {
            //DBconnect dbConn = new DBconnect();
            //string sql = string.Format("select isnull(max(SIZE_ID),0)+1 as max from CSSize ");
            //SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            //dbConn.OpenConnection();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    idmax = reader["max"].ToString();
            //}
        }

        #endregion

        #region 檢查ID

        private void Check() 
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select count(SIZE_ID) as count from CSSize where SIZE_ID  ='{0}'", tbID.Text);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                sizeid = reader2["count"].ToString();
            }
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {
                Check();

                if (sizeid == "0")
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into CSSize values ('{0}','{1}','{2}','{3}',GETDATE(), '{4}')", tbID.Text, tbsize.Text, tb備註.Text, userid, textBox1.Text);
                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    MessageBox.Show("ID重複!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }

        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update CSSize set  SIZE_Name = '{0}' ,SIZE_Memo = '{1}',USERID = '{2}',USERDATE = GETDATE(),COMDIF = '{3}' where SIZE_ID = '{3}'", tbsize.Text, tb備註.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), textBox1.Text);
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("修改資料失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con4.CloseConnection();
        }


        #endregion

        #region 重新讀取

        private void Reload()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from CSSize ");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            dataGridView1.DataSource = ds.Tables[0];
        }

        #endregion

        #endregion

        #region 事件



        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                SizeCountryQuery Form = new SizeCountryQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
                dataGridView1.Visible = true;
            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clean1();
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                tabControl1.SelectedTab = tabPage2;
            
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
                sl = "1";

                tbsize.Enabled = true;
                tb備註.Enabled = true;
                tbID.Enabled = true;

                tbsize.Text = "";
                tb備註.Text = "";
                tbID.Text = "";
            }

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DeleteData();
                }
                Reload();
            }
            catch (Exception)
            {
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "1";
            //OpenText();
            tsbQuery.Enabled = false;
            tsbInsert.Enabled = false;
            tsbFirst.Enabled = false;
            tsbNext.Enabled = false;
            tsbPrior.Enabled = false;
            tsbLast.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            sl = "2";

            tbsize.Enabled = true;
            tb備註.Enabled = true;

            dataGridView1.Visible = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (tbsize.Text != "")
                {
                    if (sl == "1") //insert
                    {
                        CheckID();
                        if (checkcq == false)
                        {
                            MessageBox.Show("代號重複 請重新輸入", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clean();
                        }
                        else
                        {
                            Console.WriteLine("INSERT");
                            InsertData();
                            sl = "";
                            tsbBack();
                        }

                    }
                    else if (sl == "2") //midify
                    {
                        ModifyData();
                        sl = "";
                        tsbBack();
                    }
                    Reload();
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                RecoverBtn();
                //dataGridView1.DataSource = zszlBindingSource;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.CSSize' 資料表。您可以視需要進行移動或移除。
                //this.cSSizeTableAdapter.Fill(this.lY_TESTDataSet.CSSize);

                LoadText();
            }
            catch (Exception) { }
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
                tsbPrior.Enabled = false;
                tsbNext.Enabled = true;
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
                    LoadText();
                }
                tsbNext.Enabled = true;
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
                    LoadText();
                }
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                LoadText();
                tsbNext.Enabled = false;
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }
        #endregion

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbsize.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage2;
            
        }
    }
}
