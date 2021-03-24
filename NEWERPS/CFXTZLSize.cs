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
    public partial class CFXTZLSize : Form
    {
        public CFXTZLSize()
        {
            InitializeComponent();
        }

        #region 變數

        public string Xie = "",She = "";
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dsSize = new DataSet();
        string xien = "";
        public string gjlb1, gjlb2, gjlb3, gjlb4, cssize, gender;
        public string userid = "";
        int linenum = 0;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLSize";

        #endregion

        #region 畫面載入

        private void CFXTZLSize_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                //判斷是否有資料
                Checkxxgj();
                Console.WriteLine("xien");
                Console.WriteLine(xien);
                //插入資料
                if (xien == "0")
                {
                    //insert xxgj
                    insertXXGJ();
                    //insert xxgjs
                    //insertXXGJS();
                }
                else //有資料
                {

                }

                //讀取資料
                LoadDataA();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;


                ChangeDataView();
            }
            catch (Exception) { }
        }

        #endregion

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

        #region 切換tabcontrol

        private void ChangeTabControl()
        {
            try
            {
                int i;
                i = int.Parse(userLanguage) + 1;

                dsL = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'P%'", userForm, i);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsL, "棧板表");
                this.dgvWord.DataSource = this.dsL.Tables[0];

                LoadPage();
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
                    //dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
                }

                dataGridView1.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView1.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView1.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();

                dataGridView2.Columns[0].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView2.Columns[1].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView2.Columns[2].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView2.Columns[3].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView2.Columns[4].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView2.Columns[5].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView2.Columns[6].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView2.Columns[7].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                dataGridView2.Columns[8].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dataGridView2.Columns[9].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView2.Columns[10].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                dataGridView2.Columns[11].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                dataGridView2.Columns[12].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                dataGridView2.Columns[13].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                dataGridView2.Columns[14].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();

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

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 方法

        #region 檢查重複

        private void Checkxxgj() 
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(GJLB) as count from xxgj where XieXing  = '{0}' and SheHao = '{1}'", Xie,She);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    xien = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();
            }
            catch (Exception) 
            { }
        }

        #endregion

        #region 插入XXGJ

        private void insertXXGJ()
        {
            try
            {
                if (gjlb1 != "")
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", Xie, She, gjlb1, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn.CloseConnection();
                }

                if (gjlb2 != "")
                {
                    int result2;
                    DBconnect conn2 = new DBconnect();
                    string sql2 = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", Xie, She, gjlb2, userid);
                    Console.WriteLine(sql2);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                    conn2.OpenConnection();
                    result2 = cmd2.ExecuteNonQuery();
                    if (result2 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn2.CloseConnection();
                }

                if (gjlb3 != "")
                {
                    int result3;
                    DBconnect conn3 = new DBconnect();
                    string sql3 = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", Xie, She, gjlb3, userid);
                    Console.WriteLine(sql3);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                    conn3.OpenConnection();
                    result3 = cmd3.ExecuteNonQuery();
                    if (result3 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn3.CloseConnection();
                }

                if (gjlb4 != "")
                {
                    int result4;
                    DBconnect conn4 = new DBconnect();
                    string sql4 = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", Xie, She, gjlb4, userid);
                    Console.WriteLine(sql4);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd4 = new SqlCommand(sql4, conn4.connection);
                    conn4.OpenConnection();
                    result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn4.CloseConnection();
                }

                #region LYSHOE

                int result4Y;
                DBconnect2 conn4Y = new DBconnect2();
                string sql4Y = string.Format("delete ly_shoe.dbo.xxgj where xiexing = '{0}' insert into ly_shoe.dbo.xxgj select xiexing, gjlb, MAX(userid), CONVERT(varchar,max(USERDATE),11), null, null, null, null from [192.168.11.15].New_Erp.dbo.xxgj where XieXing = '{0}' group by xiexing, gjlb ", Xie);
                Console.WriteLine(sql4Y);
                SqlCommand cmd4Y = new SqlCommand(sql4Y, conn4Y.connection);
                conn4Y.OpenConnection();
                result4Y = cmd4Y.ExecuteNonQuery();
                if (result4Y == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                conn4Y.CloseConnection();

                #endregion

            }
            catch (Exception) { }
        }

        #endregion

        #region 插入XXGJS

        private void insertXXGJS()
        {
            try
            {
                #region OLD


                ////選出區間
                //string comd = "", ssize = "", esize = "";
                //double a, b, c;

                //DBconnect dbConn2 = new DBconnect();
                //string sql2 = string.Format("select COMDIF from CSSize where SIZE_ID = '{0}'", cssize);
                ////Console.WriteLine(sql2);

                //SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                //dbConn2.OpenConnection();
                //SqlDataReader reader2 = cmd2.ExecuteReader();
                //if (reader2.Read())
                //{
                //    comd = reader2["COMDIF"].ToString();
                //} 
                //dbConn2.CloseConnection();

                //c = double.Parse(comd);

                ////選出性別區間
                //DBconnect dbConn3 = new DBconnect();
                //string sql3 = string.Format("select Star_Size,End_Size from GENDER where GENDER_id = '{0}'", gender);
                //SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                //dbConn3.OpenConnection();
                //SqlDataReader reader3 = cmd3.ExecuteReader();
                //if (reader3.Read())
                //{
                //    ssize = reader3["Star_Size"].ToString();
                //    esize = reader3["End_Size"].ToString();
                //}
                //dbConn3.CloseConnection();

                //a = double.Parse(ssize);
                //b = double.Parse(esize);
                ////select* from xxgjs where XieXing = 'TH401H0' and SheHao = '01'  and GJLB = '100'

                ////Console.WriteLine(c);
                ////Console.WriteLine(a);
                ////Console.WriteLine(b);


                //do
                //{
                //    string num = "";
                //    //Console.WriteLine(a);
                //    linenum += 1;
                //    int y = linenum.ToString().Length;
                //    if (y == 1)
                //    {
                //        num = "0" + linenum;
                //    }
                //    else 
                //    {
                //        num =  linenum.ToString();
                //    }
                //    Console.WriteLine(num);


                //    //insertgjlb1
                //    int result;
                //    DBconnect conn = new DBconnect();
                //    string sql1 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", Xie, She, gjlb1, num, a, a,userid);
                //    Console.WriteLine(sql1);
                //    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                //    conn.OpenConnection();
                //    result = cmd1.ExecuteNonQuery();
                //    if (result == 1)
                //    {
                //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //    conn.CloseConnection();

                //    //gjlb2
                //    int result22;
                //    DBconnect conn22 = new DBconnect();
                //    string sql22 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", Xie, She, gjlb2, num, a, a, userid);
                //    Console.WriteLine(sql22);
                //    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //    SqlCommand cmd22 = new SqlCommand(sql22, conn22.connection);
                //    conn22.OpenConnection();
                //    result22 = cmd22.ExecuteNonQuery();
                //    if (result22 == 1)
                //    {
                //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //    conn22.CloseConnection();

                //    //gjlb3
                //    int result33;
                //    DBconnect conn33 = new DBconnect();
                //    string sql33 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", Xie, She, gjlb3, num, a, a, userid);
                //    Console.WriteLine(sql33);
                //    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //    SqlCommand cmd33 = new SqlCommand(sql33, conn33.connection);
                //    conn33.OpenConnection();
                //    result33 = cmd33.ExecuteNonQuery();
                //    if (result33 == 1)
                //    {
                //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //    conn33.CloseConnection();

                //    //gjlb4
                //    int result44;
                //    DBconnect conn44 = new DBconnect();
                //    string sql44 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", Xie, She, gjlb4, num, a, a, userid);
                //    Console.WriteLine(sql44);
                //    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //    SqlCommand cmd44 = new SqlCommand(sql44, conn44.connection);
                //    conn44.OpenConnection();
                //    result44 = cmd44.ExecuteNonQuery();
                //    if (result44 == 1)
                //    {
                //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    conn44.CloseConnection();

                //    a += c;
                //    Console.WriteLine(a);
                //}
                //while (a < b);


                #endregion

                string gender = "", khdh = "";

                //取出性別跟客戶
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select KHDH,GENDER from xxzl where XieXing = '{0}' and SheHao = '{1}'", Xie, She);
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
                    string sql11 = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString(), num, dgvSize.Rows[i].Cells[0].Value.ToString().Trim(), dgvSize.Rows[i].Cells[0].Value.ToString().Trim(), userid);
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

                #region LYSHOE

                int result11Y;
                DBconnect2 conn11Y = new DBconnect2();
                string sql11Y = string.Format("delete ly_shoe.dbo.xxgjs where xiexing = '{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz ", Xie);
                Console.WriteLine(sql11Y);

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

        #region 讀取A

        private void LoadDataA() 
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select a.GJLB,ywsm,zwsm from (select * from xxgj where XieXing = '{0}' and SheHao = '{1}' and gjlb != '') as a left join (select * from gjlbzl where gjlb != '') as b on a.GJLB = b.gjlb", Xie, She);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView1.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();
            }
            catch (Exception) { }
        }



        #endregion

        #region 讀取B

        private void LoadDataB() 
        {
            try
            {
                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}'", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds2, "棧板表");

                dataGridView2.DataSource = ds2.Tables[0];

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;

                dataGridView2.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 事件

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int count = 0;

            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select COUNT(XXCC) as count from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}'", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Console.WriteLine(sql2);

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
                //insert xxgjs
                insertXXGJS();
            }
            else //有資料
            {
            }

            LoadDataB();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                a = ds2.Tables[0].Rows.Count;
                Console.WriteLine(a);

                for (int i = 0; i < a; i++)
                {
                    if (ds2.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                    {

                    }
                    else if (ds2.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() != "")
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update xxgjs set GJCC = '{0}', USERID = '{1}', USERDATE = GETDATE() where XieXing = '{2}' and SheHao = '{3}' and GJLB = '{4}' and XXCC = '{5}'", dataGridView2.Rows[i].Cells[5].Value.ToString(), userid, dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[2].Value.ToString(), dataGridView2.Rows[i].Cells[4].Value.ToString());

                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {

                            }
                            con4.CloseConnection();
                        }
                    }
                }

                #region LYSHOE

                int result11Y;
                DBconnect2 conn11Y = new DBconnect2();
                string sql11Y = string.Format("delete ly_shoe.dbo.xxgjs where xiexing = '{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz ", Xie);
                Console.WriteLine(sql11Y);

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
            catch (Exception)
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除此部位?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete xxgj where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}'", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();

                    DBconnect con42 = new DBconnect();
                    StringBuilder sql42 = new StringBuilder();
                    sql42.AppendFormat("delete xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}'", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql42);
                    SqlCommand cmd42 = new SqlCommand(sql42.ToString(), con42.connection);

                    con42.OpenConnection();
                    int result42 = cmd42.ExecuteNonQuery();
                    if (result42 == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con42.CloseConnection();

                    #region LYSHOE

                    DBconnect2 con42Y = new DBconnect2();
                    StringBuilder sql42Y = new StringBuilder();
                    sql42Y.AppendFormat("delete xxgj where XieXing  = '{0}' and GJLB = '{1}' delete xxgjs where XieXing  = '{0}' and GJLB = '{1}'", Xie, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql42Y);
                    SqlCommand cmd42Y = new SqlCommand(sql42Y.ToString(), con42Y.connection);

                    con42Y.OpenConnection();
                    int result42Y = cmd42Y.ExecuteNonQuery();
                    if (result42Y == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con42Y.CloseConnection();

                    #endregion

                    LoadDataA();
                }
            }
            catch (Exception) { }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //xie = "", she = "", gjlb = "", line = ""
                int a = 0;
                a = dataGridView2.Rows.Count;
                CFXTZXLSizeInsert2 Form = new CFXTZXLSizeInsert2();
                Form.xie = Xie;
                Form.she = She;
                Form.gjlb = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Form.line = dataGridView2.Rows[a - 1].Cells[3].Value.ToString();
                Console.WriteLine(dataGridView2.Rows[a - 1].Cells[3].Value.ToString());

                Form.ShowDialog();

                LoadDataA();
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}' and XXCC = '{3}'", Xie, She, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[4].Value.ToString());
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();

                    #region LYSHOE

                    DBconnect2 con4Y = new DBconnect2();
                    StringBuilder sql4Y = new StringBuilder();
                    sql4Y.AppendFormat("delete xxgjs where XieXing  = '{0}' and GJLB = '{1}' and XXCC = '{2}'", Xie, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[4].Value.ToString());
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

                    LoadDataB();
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                CFXTZLPartInsert Form = new CFXTZLPartInsert();
                Form.xie = Xie;
                Form.she = She;
                Form.ShowDialog();
                LoadDataA();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CFXTZLSizeCopy Form = new CFXTZLSizeCopy();
            Form.textBox1.Text = Xie;
            Form.textBox2.Text = She;
            Form.ShowDialog();
            LoadDataA();
        }

        #endregion
    }
}
