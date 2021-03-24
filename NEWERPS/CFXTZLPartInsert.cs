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
    public partial class CFXTZLPartInsert : Form
    {
        public CFXTZLPartInsert()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds1 = new DataSet();
        DataSet dsSize = new DataSet();
        public string xie = "", she = "";
        public string userid = "";
        int linenum = 0;

        #endregion

        #region 事件

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", xie, she, dataGridView1.CurrentRow.Cells[0].Value.ToString(), userid);
                Console.WriteLine(sql1);

                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
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
                string sql1Y = string.Format("delete ly_shoe.dbo.xxgj where xiexing = '{0}' insert into ly_shoe.dbo.xxgj select xiexing, gjlb, MAX(userid), CONVERT(varchar,max(USERDATE),11),  null, null, null, null from [192.168.11.15].New_Erp.dbo.xxgj where XieXing = '{0}' group by xiexing, gjlb ", xie);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion

                insertXXGJS();
                this.Close();
            }
            catch (Exception) { }
        }

        #endregion

        #region 方法

        private void insertXXGJS()
        {
            try
            {
                string gender = "", khdh = "";

                //取出性別跟客戶
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select KHDH,GENDER from xxzl where XieXing = '{0}' and SheHao = '{1}'", xie, she);
                Console.WriteLine(sql2);

                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    gender = reader2["GENDER"].ToString();
                    khdh = reader2["KHDH"].ToString();
                }
                dbConn2.CloseConnection();

                Console.WriteLine(gender);
                Console.WriteLine(khdh);

                dsSize = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select Size from GENDER_Def where GENDER_id = '{0}' and KCBH = '{1}' order by SORTSN", gender, khdh);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(dsSize, "棧板表");

                dgvSize.DataSource = dsSize.Tables[0];
                dbConn11.CloseConnection();

                for (int i = 0; i < dgvSize.Rows.Count; i++)
                {
                    string num = "";
                    //Console.WriteLine(a);
                    linenum += 1;
                    int y = linenum.ToString().Length;
                    if (y == 1)
                    {
                        num = "0" + linenum;
                    }
                    else
                    {
                        num = linenum.ToString();
                    }
                    Console.WriteLine(num);


                    //insertgjlb1
                    int result11;
                    DBconnect conn11 = new DBconnect();
                    string sql11 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", xie, she, dataGridView1.CurrentRow.Cells[0].Value.ToString(), num, dgvSize.Rows[i].Cells[0].Value.ToString().Trim(), dgvSize.Rows[i].Cells[0].Value.ToString().Trim(), userid);
                    Console.WriteLine(sql11);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd11 = new SqlCommand(sql11, conn11.connection);
                    conn11.OpenConnection();
                    result11 = cmd11.ExecuteNonQuery();
                    if (result11 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn11.CloseConnection();
                }

                #region NEWERP

                int result11Y;
                DBconnect2 conn11Y = new DBconnect2();
                string sql11Y = string.Format("delete ly_shoe.dbo.xxgjs where xiexing = '{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz  from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz", xie);
                Console.WriteLine(sql11Y);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                SqlCommand cmd11Y = new SqlCommand(sql11Y, conn11Y.connection);
                conn11Y.OpenConnection();
                result11Y = cmd11Y.ExecuteNonQuery();
                if (result11Y == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn11Y.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #endregion

        #region 畫面載入

        private void CFXTZLPartInsert_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                ds1 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from gjlbzl where gjlb not in (select gjlb from xxgjs where XieXing = '{0}' and SheHao = '{1}')", xie, she);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds1, "棧板表");
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion
    }
}
