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
    public partial class BomCopy : Form
    {
        public BomCopy()
        {
            InitializeComponent();
        }

        #region 變數

        public string shesho = "";
        DataSet ds = new DataSet();
        public string userid = "";
        string bomver = "", xxzlver = "";

        #endregion

        #region 畫面載入

        private void BomCopy_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            Shehao();
        }

        #endregion

        #region 方法

        #region 鞋號載入

        private void Shehao()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select distinct SheHao from xxzls where XieXing = '{0}' and SheHao != '{1}'", textBox1.Text, textBox2.Text);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "SheHao";
                this.comboBox1.DisplayMember = "SheHao";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        private void InsertR() 
        {
            try
            {
                DeleteR();

                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql = string.Format("insert into Usage_R select XieXing, '{0}', BWBH, XTCC, VER, CLSL, GETDATE(), '{1}', xxzlver from Usage_R where XieXing = '{2}' and SheHao = '{3}' and BWBH = '{4}' and VER = '{5}' and xxzlver = '{6}'", textBox2.Text, userid, textBox1.Text, comboBox1.Text, textBox3.Text, bomver, xxzlver);
                Console.WriteLine(sql);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sqlY = string.Format("delete XTBWYL1 where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}' insert into XTBWYL1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,userdate,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}' and VER = '{3}' and xxzlver = '{4}'", textBox1.Text, comboBox1.Text, textBox3.Text, bomver, xxzlver);
                Console.WriteLine(sqlY);

                SqlCommand cmd1Y = new SqlCommand(sqlY, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #region 刪除R

        private void DeleteR()
        {
            try
            {
                #region NEWERP

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete Usage_R where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}'", textBox1.Text, textBox2.Text, textBox3.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                #endregion

                #region LYSHOE

                DBconnect2 con4Y = new DBconnect2();
                StringBuilder sql4Y = new StringBuilder();
                sql4Y.AppendFormat("delete XTBWYL1 where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}'", textBox1.Text, textBox2.Text, textBox3.Text);
                Console.WriteLine(sql4Y);
                SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                con4Y.OpenConnection();
                int result4Y = cmd4Y.ExecuteNonQuery();
                if (result4Y == 1)
                {

                }
                con4Y.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #endregion

        private void InsertC()
        {
            try
            {
                DeleteC();

                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql = string.Format("insert into Usage_C select XieXing, SheHao, BWBH, XTCC, CLSL, getdate(), '{0}' from Usage_C where XieXing = '{1}' and SheHao = '{2}' and BWBH = '{3}'", userid, textBox1.Text, comboBox1.Text, textBox3.Text);
                Console.WriteLine(sql);

                SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                #endregion

                #region LYSHOE


                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sqlY = string.Format("delete xtbwyl where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}' insert into XTBWYL1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,userdate,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}'", textBox1.Text, comboBox1.Text, textBox3.Text);
                Console.WriteLine(sqlY);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                SqlCommand cmd1Y = new SqlCommand(sqlY, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #region 刪除C

        private void DeleteC()
        {
            try
            {
                #region NEWERP

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete Usage_C where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}'", textBox1.Text, textBox2.Text, textBox3.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                #endregion

                #region LYSHOE

                DBconnect2 con4Y = new DBconnect2();
                StringBuilder sql4Y = new StringBuilder();
                sql4Y.AppendFormat("delete xtbwyl where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}'", textBox1.Text, textBox2.Text, textBox3.Text);
                Console.WriteLine(sql4Y);
                SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                con4Y.OpenConnection();
                int result4Y = cmd4Y.ExecuteNonQuery();
                if (result4Y == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4Y.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 事件

        private void button1_Click(object sender, EventArgs e)
        {
            InsertR();
            InsertC();
            shesho = comboBox1.Text;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //取出版本
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select MAX(VER) as ver from Usage_R where XieXing = ' {0}' and SheHao = '{1}'", textBox1.Text, comboBox1.Text);
                Console.WriteLine(sql2);

                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    bomver = reader2["ver"].ToString();
                }
                dbConn2.CloseConnection();

                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select MAX(xxzlver) as xxzlver from Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", textBox1.Text, comboBox1.Text, bomver);
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    xxzlver = reader["xxzlver"].ToString();
                }
                dbConn.CloseConnection();

                ds = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select a.XTCC,a.CLSL,b.CLSL from (select * from Usage_C where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}') as a left join (select * from Usage_R where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}' and VER = '{3}' and xxzlver = '{4}') as b on a.XTCC = b.XTCC", textBox1.Text, comboBox1.Text, textBox3.Text, bomver, xxzlver);

                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds, "棧板表");

                dataGridView2.DataSource = ds.Tables[0];
                dbConn11.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion
    }
}
