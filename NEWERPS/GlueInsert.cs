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
    public partial class GlueInsert : Form
    {
        public GlueInsert()
        {
            InitializeComponent();
        }

        public string userid = "";
        DataSet ds = new DataSet();
        DataSet dsY1 = new DataSet();
        DataSet dsY2 = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();

        private void GlueInsert_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from bwzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dsc1, "倉庫");

                comboBox1.DataSource = dsc1.Tables[0];
                comboBox1.ValueMember = "bwdh";
                comboBox1.DisplayMember = "bwdh";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                DBconnect dbconn2 = new DBconnect();
                string sql2 = "select FLBH,DFL from XXBWFLS where YN = 1";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbconn2.connection);
                adapter2.Fill(dsc3, "倉庫");

                comboBox3.DataSource = dsc3.Tables[0];
                comboBox3.ValueMember = "FLBH";
                comboBox3.DisplayMember = "DFL";
                comboBox3.MaxDropDownItems = 8;
                comboBox3.IntegralHeight = false;


            }
            catch (Exception) { }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", textBox1.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", textBox1.Text);
            Console.WriteLine(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.Columns[0].Visible = false;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = "";
                dsc4 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select zsdh from supplier_list where cldh = '{0}'", dataGridView2.CurrentRow.Cells[1].Value.ToString());

                Console.WriteLine(sql1);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dsc4, "倉庫");

                comboBox2.DataSource = dsc4.Tables[0];
                comboBox2.ValueMember = "zsdh";
                comboBox2.DisplayMember = "zsdh";
                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select COUNT(XieXing) as count from XXZLSVN where XieXing = '{0}' and SheHao = '{1}'  and BWBH = '{2}'", label10.Text, label13.Text, comboBox1.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    count = int.Parse(reader2["count"].ToString());
                }
                dbConn2.CloseConnection();

                if (count == 0)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into XXZLSVN (XieXing,SheHao,BWBH,CLBH,CSBH,CLSL,FLBH,PT,USERID,USERDATE,YN) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '01', '1', '{6}', GETDATE(), '1')", label10.Text, label13.Text, comboBox1.Text, textBox1.Text, comboBox2.Text, textBox3.Text, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();

                    MessageBox.Show("插入資料成功");
                }
                else 
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update XXZLSVN set YN = '1',USERID = '{0}',USERDATE = GETDATE(),CLSL = '{1}' where XieXing = '{2}' and SheHao = '{3}' and BWBH = '{4}'", userid, textBox3.Text, label10.Text, label13.Text , comboBox1.Text);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }

                    con4.CloseConnection();
                    MessageBox.Show("插入資料成功");
                }
            }
            catch (Exception) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string buyarea = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CQDH from supplier_list where cldh = '{0}' and zsdh = '{1}'", dataGridView2.CurrentRow.Cells[1].Value.ToString(),comboBox2.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    buyarea = reader2["CQDH"].ToString();
                }
                dbConn2.CloseConnection();

                textBox2.Text = buyarea;
            }
            catch (Exception) { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string flbh = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select XFL from XXBWFLS where FLBH = '{0}'", comboBox3.SelectedValue);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    flbh = reader2["XFL"].ToString();
                }
                dbConn2.CloseConnection();

                textBox4.Text = flbh;
            }
            catch (Exception) { }
        }
    }
}
