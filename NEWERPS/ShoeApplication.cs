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
    public partial class ShoeApplication : Form
    {
        #region 建構函式
        public ShoeApplication()
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
        string idmax = "";

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "2_4";

        #endregion

        #region 畫面載入

        private void ShoeApplication_Load(object sender, EventArgs e)
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
            tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
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


            tbID.Enabled = false;
            tb中文.Enabled = false;
            tb英文.Enabled = false;
        }

        #endregion

        #region 清空

        private void Clean1()
        {
            tbID.Text = "";
            tb中文.Text = "";
            tb英文.Text = "";

        }

        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from ShoeMode where Mode_ID = '{0}'", tbID.Text);
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
            sql4.AppendFormat("delete ShoeMode where Mode_ID = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
            tbID.Text = "";
            tb中文.Text = "";
            tb英文.Text = "";

            tbID.Enabled = true;
            tb中文.Enabled = true;
            tb英文.Enabled = true;
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

            tbID.Enabled = false;
            tb中文.Enabled = false;
            tb英文.Enabled = false;
        }

        #endregion

        #region 最大ID

        private void IDMax()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select isnull(max(Mode_ID),0)+1 as max from ShoeMode ");
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                idmax = reader["max"].ToString();
            }
            tbID.Text = idmax;
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into ShoeMode values ('{0}','{1}','{2}','{3}',GETDATE())", tbID.Text, tb中文.Text, tb英文.Text, userid);
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

        #region 修改方法

        private void ModifyData()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update ShoeMode set  ywsm = '{0}' ,zwsm = '{1}',USERID = '{2}',USERDATE = GETDATE() where Mode_ID = '{3}'", tb英文.Text, tb中文.Text, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
            string sql = string.Format("select * from ShoeMode ");
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
                ShoeAppQuery Form = new ShoeAppQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                //LoadText();
                dataGridView1.Visible = true;
                tsbDelete.Enabled = true;
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

                tb中文.Enabled = true;
                tb英文.Enabled = true;
                tb中文.Text = "";
                tb英文.Text = "";
            }

            //IDMax();
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
            tsbQuery.Enabled = false;
            tsbInsert.Enabled = false;
            tsbFirst.Enabled = false;
            tsbNext.Enabled = false;
            tsbPrior.Enabled = false;
            tsbLast.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            sl = "2";

            tb中文.Enabled = true;
            tb英文.Enabled = true;

            dataGridView1.Visible = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (tbID.Text != "")
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

                }
                else
                {
                }
                Reload();
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
            tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
