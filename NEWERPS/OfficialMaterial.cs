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
    public partial class OfficialMaterial : Form
    {
        #region 建構函式
        public OfficialMaterial()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public string userid = "";
        public string languageType;
        #endregion

        #region 畫面載入
        private void OfficialMaterial_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            ClassB();
        }

        #endregion

        #region 方法

        #region Class載入

        private void ClassB()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from CLASS_B";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cbClass.DataSource = ds.Tables[0];
                this.cbClass.ValueMember = "ywsm";
                this.cbClass.DisplayMember = "cllb";

                cbClass.MaxDropDownItems = 8;
                cbClass.IntegralHeight = false;


            }
            catch (Exception) { }
        }

        #endregion

        #region clzltemp

        private void Clzltemp() 
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update clzltemp set cldh = '{0}' , USERID= '{1}', USERDATE = GETDATE() where tempddbh = '{2}'", textBox2.Text, userid, textBox1.Text);
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);+
            }
            con4.CloseConnection();
        }

        #endregion

        #region CGZLS

        private void CGZLS()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update CGZLS set CLBH = '{0}', USERID= '{1}', USERDate = GETDATE() where CLBH = '{2}'", textBox2.Text, userid, textBox1.Text);
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con4.CloseConnection();
        }

        #endregion

        #region YPZLS

        private void YPZLS()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update YPZLS set CLBH = '{0}' where CLBH = '{1}'", textBox2.Text, textBox1.Text);
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con4.CloseConnection();
        }

        #endregion

        #region YPZLZLS2

        private void YPZLZLS2()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update YPZLZLS2 set CLBH = '{0}', USERID= '{1}', USERDATE = GETDATE() where CLBH = '{2}'", textBox2.Text, userid, textBox1.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                DBconnect con = new DBconnect();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("update YPZLZLS1 set CLBH = '{0}', USERID= '{1}', USERDATE = GETDATE() where CLBH = '{2}'", textBox2.Text, userid, textBox1.Text);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                con.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 更改正式料號

        private void Official() 
        {
            try
            {
                Clzltemp();
                CGZLS();
                YPZLS();
                YPZLZLS2();
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #endregion

        #region 事件

        #endregion

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = "";
                textBox2.Text = "";

                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select * from clzl where cllb = '{0}'", cbClass.Text);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds2, "棧板表");
                dataGridView2.DataSource = ds2.Tables[0];
                dataGridView2.ReadOnly = true;
                dataGridView2.Columns[0].Width = 550;

                dataGridView2.Columns[0].Visible = false;


                if (checkBox1.Checked == true)
                {
                    
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}' and cldh is null", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;


                    if (dataGridView1.Rows.Count == 0)
                    {
                          textBox1.Text = "";                      
                    }
                    else 
                    {
                        textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    }
                }
                else if (checkBox1.Checked == false) 
                {
                    
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}'", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;

                    if (dataGridView1.Rows.Count == 0)
                    {
                         textBox1.Text = ""; 
                    }
                    else
                    { 
                        textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    }
                }


            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                textBox1.Text = "";
                if (checkBox1.Checked == true)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}' and cldh is null", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;
                }
                else if (checkBox1.Checked == false)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}'", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;
                }
            } 
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("確定要修改料號嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                Official();

                if (checkBox1.Checked == true)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}' and cldh is null", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;
                }
                else if (checkBox1.Checked == false)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}'", cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.ReadOnly = true;
                }
            }
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
