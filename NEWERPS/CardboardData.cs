using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NEWERPS
{
    public partial class CardboardData : Form
    {
        #region 建構函式

        public CardboardData()
        {
            InitializeComponent();
        }
        #endregion

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        string rowno = "";
        string sl = "";
        int index = 0;
        Boolean checkName = true;
        public string userid = "";
        public string languageType;
        string idmax = "";
        string vermax = "";
        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "2_11";
        string pic;
        string dybh ,mjlb100, mjlb101, paperid;

        #endregion

        #region 畫面載入

        private void CardboardData_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            Kfzl();
            Gjzl100();
            Gjzl101();
        }

        #endregion

        #region 方法

        #region 品牌載入

        private void Kfzl()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from kfzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cb品牌.DataSource = ds.Tables[0];
                this.cb品牌.ValueMember = "kfdh";
                this.cb品牌.DisplayMember = "kfjc";

                cb品牌.MaxDropDownItems = 8;
                cb品牌.IntegralHeight = false;
            }
            catch (Exception) 
            {
                MessageBox.Show("KFZL ERROR");
            }
        }

        #endregion

        #region 楦頭載入

        private void Gjzl100()
        {
            try
            {
                int a = 0;
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select COUNT(gjmh) as count from gjzl where gjlb = '100' and kfdh = '{0}'", cb品牌.SelectedValue.ToString());
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    a = int.Parse(reader2["count"].ToString());
                }

                if (a > 0)
                {
                    cb楦頭.Visible = true;
                    cb底膜.Visible = true;
                    ds = new DataSet();
                    DBconnect dbconn = new DBconnect();
                    string sql1 = string.Format("select * from gjzl where gjlb = '100' and kfdh = '{0}'", cb品牌.SelectedValue.ToString());
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                    adapter1.Fill(ds, "倉庫位置");
                    this.cb楦頭.DataSource = ds.Tables[0];
                    this.cb楦頭.ValueMember = "gjmh";
                    this.cb楦頭.DisplayMember = "gjmh";

                    cb楦頭.MaxDropDownItems = 8;
                    cb楦頭.IntegralHeight = false;
                }
                else 
                {
                    cb楦頭.Visible = false;
                    cb底膜.Visible = false;
                }
                
            }
            catch (Exception) 
            {
                MessageBox.Show("100 ERROR");
            }
        }

        #endregion

        #region 底膜載入

        private void Gjzl101()
        {
            try
            {
                int a = 0;
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select COUNT(gjmh) as count from gjzl where gjlb = '101' and kfdh = '{0}' and counter1 = '{1}'", cb品牌.SelectedValue.ToString(), cb楦頭.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    a = int.Parse(reader2["count"].ToString());
                }

                if (a > 0)
                {
                    //cb楦頭.Visible = true;
                    cb底膜.Visible = true;
                    ds = new DataSet();
                    DBconnect dbconn = new DBconnect();
                    string sql1 = string.Format("select * from gjzl where gjlb = '101' and kfdh = '{0}' and counter1 = '{1}'", cb品牌.SelectedValue.ToString(), cb楦頭.Text);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                    adapter1.Fill(ds, "倉庫位置");
                    this.cb底膜.DataSource = ds.Tables[0];
                    this.cb底膜.ValueMember = "gjmh";

                    this.cb底膜.DisplayMember = "gjmh";

                    cb底膜.MaxDropDownItems = 8;
                    cb底膜.IntegralHeight = false;
                }
                else
                {
                    //cb楦頭.Visible = false;
                    cb底膜.Visible = false;
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("101 ERROR");
            }
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

            cb品牌.Enabled = false;
            cb楦頭.Enabled = false;
            cb底膜.Enabled = false;
            tb紙板名.Enabled = false;
        }

        #endregion

        #region 最大ID

        private void IDMax()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select isnull(max(Paper_ID), 'A') as max from PAPER where kfdh = '{0}' and Lastsgjmh = '{1}' and Outsolegjmh = '{2}'", cb品牌.Text, cb楦頭.Text, cb底膜.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idmax = reader["max"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ID ERROR");
            }
        }

        #endregion

        #region 最大ver

        private void IDVer()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select isnull(max(VER)+1, '1') as max from PAPER where kfdh = '{0}' and Lastsgjmh = '{1}' and Outsolegjmh = '{2}' and Paper_Name = '{3}'", cb品牌.SelectedValue, cb楦頭.Text, cb底膜.Text, tb紙板名.Text);
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    vermax = reader["max"].ToString();
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("VER ERROR");
            }
        }

        #endregion

        #region 重新讀取

        private void Reload()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from PAPER ");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) 
            {
                MessageBox.Show("PAPER ERROR");
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
                string sql1 = string.Format("insert into PAPER values('{0}','{1}','{2}','{3}','{4}',NULL, 1,GETDATE(),'{5}')", cb品牌.SelectedValue, cb楦頭.Text, cb底膜.Text, idmax, tb紙板名.Text , userid);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                insertPic();

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update PAPER set Paper_URL = '{0}'  where Paper_Name = '{1}' and VER = '1'", pic, tb紙板名.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("INSERT PAPER ERROR");
            }

        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            try
            {
                IDVer();
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into PAPER values('{0}','{1}','{2}','{3}','{4}', NULL, '{5}',GETDATE(),'{6}')", cb品牌.SelectedValue, cb楦頭.Text, cb底膜.Text, idmax, tb紙板名.Text, vermax, userid);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                insertPic();

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update PAPER set Paper_URL = '{0}'  where Paper_Name = '{1}' and VER = '{2}'", pic, tb紙板名.Text, vermax);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("MODIFY PAPER ERROR");
            }
        }


        #endregion

        #region 取出DYBH

        private void DybhID() 
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select dybh from kfzl where kfdh = '{0}'", cb品牌.SelectedValue);
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dybh = reader["dybh"].ToString();
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("dybh ERROR");
            }
        }

        #endregion

        #region 取出100

        private void GjzlID()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select Mjlb2 from gjzl where gjlb = '100' and gjmh = '{0}'", cb楦頭.Text);
            Console.WriteLine(sql);

            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mjlb100 = reader["Mjlb2"].ToString();
            }
        }

        #endregion

        #region 取出101

        private void GjzlID2()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select Mjlb2 from gjzl where gjlb = '101' and gjmh = '{0}'", cb底膜.Text);
            Console.WriteLine(sql);

            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mjlb101 = reader["Mjlb2"].ToString();
            }
        }

        #endregion

        #region 取出paper

        private void PaperID()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select Paper_ID from PAPER where Paper_Name = '{0}'", tb紙板名.Text);
            Console.WriteLine(sql);

            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                paperid = reader["Paper_ID"].ToString();
            }
        }

        #endregion

        #region 插入圖片

        private void insertPic() 
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                //this.textBox2.Text = file.SafeFileName;

                string x, y, z;
                y = file.FileName;
                Console.WriteLine(y);
                x = file.SafeFileName;
                Console.WriteLine(x);

                //string[] sArray = x.Split('.'); 
                //Console.WriteLine(sArray[0]);
                //z = sArray[0];

                DybhID();
                GjzlID();
                GjzlID2();
                PaperID();
                IDVer();

                z = dybh + mjlb100 + mjlb101 + paperid + vermax;

                pic = "D:\\test\\" + z + ".rar";

                Console.WriteLine(pic);

                File.Copy(file.FileName, pic);
            }
            catch (Exception) 
            {
                MessageBox.Show("RAR ERROR");
            }
        }



        #endregion

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                CardboardQuery Form = new CardboardQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                //LoadText();
                dataGridView1.Visible = true;
            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            try
            {
                cb品牌.SelectedIndex = 0;
                cb楦頭.SelectedIndex = 0;
                cb底膜.SelectedIndex = 0;
                tb紙板名.Text = "";
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                cb品牌.Enabled = true;
                cb楦頭.Enabled = true;
                cb底膜.Enabled = true;
                tb紙板名.Enabled = true;

                tb紙板名.Text = "";
                cb品牌.SelectedIndex = 0;
                cb楦頭.SelectedIndex = 0;
                cb底膜.SelectedIndex = 0;

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

                IDMax();
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "1";
                cb品牌.Enabled = true;
                cb楦頭.Enabled = true;
                cb底膜.Enabled = true;
                tb紙板名.Enabled = true;

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
                sl = "2";
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (tb紙板名.Text == "")
                {
                    MessageBox.Show("紙板名稱不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (sl == "1")
                    {
                        InsertData();
                        sl = "";
                        tsbBack();
                    }
                    else if (sl == "2")
                    {
                        ModifyData();
                        sl = "";
                        tsbBack();
                    }
                    Reload();
                }
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                tsbBack();
            }
            catch (Exception) { }
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                //LoadText();
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
                    //LoadText();
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
                    //LoadText();
                }
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }

        private void cb品牌_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gjzl101();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void cb楦頭_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void cb品牌_Click(object sender, EventArgs e)
        {
            cb楦頭.Visible = true;
        }

        private void cb楦頭_Click(object sender, EventArgs e)
        {
            cb底膜.Visible = true;
        }

        private void cb品牌_SelectedValueChanged(object sender, EventArgs e)
        {
            Gjzl100();
        }

        private void cb楦頭_SelectedValueChanged(object sender, EventArgs e)
        {
            Gjzl101();
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                //CompanyDataLoading("select count(*) from zszl");
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                //LoadText();
                tsbNext.Enabled = false;
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }

        #endregion

        private void dgvPro_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cb品牌.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cb楦頭.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cb底膜.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb紙板名.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }
    }
}
