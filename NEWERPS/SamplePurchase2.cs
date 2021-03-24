using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEWERPS
{
    public partial class SamplePurchase2 : Form
    {
        #region 建構函式
        public SamplePurchase2()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds2CGS = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds3B = new DataSet();
        DataSet ds3B2 = new DataSet();
        DataSet dsCGSS = new DataSet();
        DataSet dsBKZS = new DataSet();
        DataSet dsYPS2 = new DataSet();
        DataSet dsSUMNEW = new DataSet();
        DataSet dsSUMOLD = new DataSet();
        DataTable dt2 = new DataTable();
        DataTable dtX = new DataTable();
        DataTable dtX2 = new DataTable();
        DataTable dtXC = new DataTable();
        DataTable dtY = new DataTable();
        DataTable dtZ = new DataTable();
        DataTable dtA = new DataTable();
        DataTable dtCS = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dtss = new DataTable();
        DateTime myDate = DateTime.Now;
        string maxD, maxCG = "";
        string maxD2, maxCG3 = "";
        long maxCG4 = 0;
        public string userid = "";
        int cg = 0, cgs = 0, cgss = 0;
        long maxCG2 = 0;
        Boolean date = false;
        int clbhcount = 0, clbhcount2 = 0;
        int checkcgzls = 0;
        string ETA;
        int cgzlyn = 0;
        int cscount = 0;
        int oldcheck = 0;
        string GETCGNO = "";
        string cfm;
        string cgnos1 = "";
        string ZLBH = "";
        int countdel = 0;

        #endregion

        #region 方法

        #region 品牌載入

        private void Kfzl()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from zszl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "zsdh";
                this.comboBox1.DisplayMember = "zsqm";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion

        #region 查詢方法

        private void Query()
        {
            if (checkBox1.Checked == true) //有日期
            {
                if (checkBox2.Checked == true) //全選
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select distinct a.YPZLBH, Convert(varchar(10),a.INSDATE,111) as INSDATE, KFJD,JiJie,a.YN, Convert(varchar(10),a.USERDATE,111) as USERDATE from YPZLZL as a left join YPZLZLS1 as c on a.YPZLBH = c.YPZLBH where CALDATE > '{0}' and a.YN = '4'", dateTimePicker1.Value.ToString());
                    Console.WriteLine(sql);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];

                }
                else
                {
                    if (comboBox1.SelectedValue.ToString() != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select distinct a.YPZLBH, Convert(varchar(10),a.INSDATE,111) as INSDATE, KFJD,JiJie,a.YN, Convert(varchar(10),a.USERDATE,111) as USERDATE   from YPZLZL as a left join YPZLZLS1 as c on a.YPZLBH = c.YPZLBH where CALDATE > '{0}' and a.YN = '4'  and c.CSBH = '{1}' ", dateTimePicker1.Value.ToString(), comboBox1.SelectedValue.ToString());
                        Console.WriteLine(sql);

                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("BRAND IS NULL");
                    }
                }
            }
            else //沒日期
            {
                if (checkBox2.Checked == true)  //全選
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select distinct a.YPZLBH, Convert(varchar(10),a.INSDATE,111) as INSDATE, KFJD,JiJie,a.YN, Convert(varchar(10),a.USERDATE,111) as USERDATE   from YPZLZL as a left join YPZLZLS1 as c on a.YPZLBH = c.YPZLBH where (a.YN = '3' or a.YN = '1')");
                    Console.WriteLine(sql);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    if (comboBox1.SelectedValue.ToString() != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select distinct a.YPZLBH, Convert(varchar(10),a.INSDATE,111) as INSDATE, KFJD,JiJie,a.YN, Convert(varchar(10),a.USERDATE,111) as USERDATE   from YPZLZL as a left join YPZLZLS1 as c on a.YPZLBH = c.YPZLBH where (a.YN = '3' or a.YN = '1') and c.CSBH = '{0}' ", comboBox1.SelectedValue.ToString());
                        Console.WriteLine(sql);

                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("BRAND IS NULL");
                    }
                }
            }

            dataGridView1.Columns[0].Width = 120;

        }

        #endregion

        #region 頁面1變色

        private void Tab1color()
        {
            try
            {

                int x = dataGridView1.Rows.Count;
                int a = 0, y = 0;
                for (int i = 0; i < x; i++)
                {
                    //
                    DBconnect dbConn3 = new DBconnect();
                    string sql3 = string.Format("select YN from YPZLZL where YPZLBH = '{0}'", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Console.WriteLine(sql3);

                    SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                    dbConn3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.Read()) //取出箱號
                    {
                        a = int.Parse(reader3["YN"].ToString());
                    }
                    dbConn3.CloseConnection();

                    if (a == 1) //YN判定
                    {
                        //有效
                        //檢查天數
                        DBconnect dbConn = new DBconnect();
                        string sql1 = string.Format("select count(YPZLBH) as count from YPZLZL where YPZLBH = '{0}' and CALDATE > DATEADD (DAY , -2 , '{1}') ", dataGridView1.Rows[i].Cells[0].Value.ToString(), myDate);
                        Console.WriteLine(sql1);

                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            y = int.Parse(reader1["count"].ToString());
                        }
                        Console.WriteLine(y);
                        dbConn.CloseConnection();

                        if (y == 0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        }
                        else 
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                        }

                    }
                    else if (a == 2)
                    {


                        
                    }
                    else if (a == 3)
                    {
                        int scbh = 0;
                        //採購中
                        //檢查廠商
                        DBconnect dbConns = new DBconnect();
                        string sql1s = string.Format("select isnull(count(CSBH),0) as count from YPZLZLS1 where YPZLBH = '{0}' and (CSBH is null or CSBH = '')", dataGridView1.Rows[i].Cells[0].Value.ToString());
                        Console.WriteLine(sql1s);
                        SqlCommand cmd1s = new SqlCommand(sql1s, dbConns.connection);
                        dbConns.OpenConnection();
                        SqlDataReader reader1s = cmd1s.ExecuteReader();
                        if (reader1s.Read()) //取出箱號
                        {
                            scbh = reader1s.GetInt32(0);
                        }
                        dbConns.CloseConnection();

                        if (scbh > 0) //有未採購
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                        }
                        else if (scbh == 0)  //採購完成
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Purple;
                        }

                        //檢查天數
                        DBconnect dbConn = new DBconnect();
                        string sql1 = string.Format("select count(YPZLBH) as count from YPZLZL where YPZLBH = '{0}' and CALDATE > DATEADD (DAY , -2 , '{1}') and YN != 4 ", dataGridView1.Rows[i].Cells[0].Value.ToString(), myDate);
                        Console.WriteLine(sql1);

                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read()) //取出箱號
                        {
                            y = reader1.GetInt32(0);
                        }
                        Console.WriteLine(y);
                        dbConn.CloseConnection();

                        if (y == 0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        }


                    }
                    else if (a == 4)
                    {
                        //採購完成
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }


                    #region OLD


                    //DBconnect dbConn3 = new DBconnect();
                    //string sql3 = string.Format("select count(YPZLBH) as count from YPZLZLS2 where YPZLBH = '{0}' and (CSBH is null or CSBH = '')", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    //Console.WriteLine(sql3);

                    //SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                    //dbConn3.OpenConnection();
                    //SqlDataReader reader3 = cmd3.ExecuteReader();
                    //if (reader3.Read()) //取出箱號
                    //{
                    //    a = reader3.GetInt32(0);
                    //}
                    //dbConn3.CloseConnection();
                    //if (a > 0)
                    //{
                    //    //有指定廠商
                    //    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    //}
                    //else
                    //{
                    //    //未指定廠商
                    //    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Purple;

                    //    //檢查採購與否
                    //    int z = 0;
                    //    DBconnect dbConn2 = new DBconnect();
                    //    string sql2 = string.Format("select count(YPZLBH) as count from YPZLZLS1  where YPZLBH = '{0}' and YN = '1' ", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    //    Console.WriteLine(sql2);

                    //    SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                    //    dbConn2.OpenConnection();
                    //    SqlDataReader reader2 = cmd2.ExecuteReader();
                    //    if (reader2.Read()) 
                    //    {
                    //        z = reader2.GetInt32(0);
                    //    }

                    //    if (z > 0)
                    //    {
                    //        //dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    //    }
                    //    else
                    //    {
                    //        //採買完黑色
                    //        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    //    }
                    //    dbConn2.CloseConnection();

                    //}


                    //DBconnect dbConn = new DBconnect();
                    //string sql1 = string.Format("select count(YPZLBH) as count from YPZLZL where YPZLBH = '{0}' and CALDATE < DATEADD (DAY , -2 , '{1}' ) ", dataGridView1.Rows[i].Cells[0].Value.ToString(), myDate);
                    //Console.WriteLine(sql1);

                    //SqlCommand cmd1 = new SqlCommand(sql1, dbConn.connection);
                    //dbConn.OpenConnection();
                    //SqlDataReader reader1 = cmd1.ExecuteReader();
                    //if (reader1.Read()) //取出箱號
                    //{
                    //    y = reader1.GetInt32(0);
                    //}
                    //Console.WriteLine(y);
                    //dbConn.CloseConnection();
                    ////未採購大於兩天
                    //if (y == 1) //紅色
                    //{

                    //    //檢查採購與否
                    //    int z = 0;
                    //    DBconnect dbConn2 = new DBconnect();
                    //    string sql2 = string.Format("select count(YPZLBH) as count from YPZLZLS1  where YPZLBH = '{0}' and YN = '1' ", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    //    Console.WriteLine(sql2);

                    //    SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                    //    dbConn2.OpenConnection();
                    //    SqlDataReader reader2 = cmd2.ExecuteReader();
                    //    if (reader2.Read()) 
                    //    {
                    //        z = int.Parse(reader2["count"].ToString());
                    //    }

                    //    if (z > 0)
                    //    {
                    //        //未採購且兩天以上紅色
                    //        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    //    }
                    //    else
                    //    {
                    //        //dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    //    }
                    //    dbConn2.CloseConnection();

                    //}

                    #endregion
                }

                //dataGridView1.Columns[7].Visible = false;
                //dataGridView1.Columns[8].Visible = false;
            }
            catch (Exception)
            {
                //MessageBox.Show("COLOR ERROR");
            }
        }

        #endregion

        #region 檢查CGZL

        private void CheckCG()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select isnull(count(CGNO),0) as count from CGZL where ZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) //有資料
            {
                cg = int.Parse(reader["count"].ToString());
            }

            Console.WriteLine(cg);
            dbConn.CloseConnection();
        }

        private void CheckCGs()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select isnull(count(CGNO),0) as count from CGZLS where CGNO = '{0}'", dataGridView2.CurrentRow.Cells[0].Value.ToString());
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) //有資料
            {
                cgs = int.Parse(reader["count"].ToString());                
            }

            Console.WriteLine(cg);
        }

        private void CheckCGss()
        {
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select isnull(count(CGNO),0) as count from CGZLSS where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) //有資料
            {
                cgss = int.Parse(reader["count"].ToString());
            }

            Console.WriteLine(cg);
        }

        #endregion

        #region 計算列出全部廠商

        private void CSBHALL()
        {
            try
            {
                DBconnect connX = new DBconnect();
                string sql = string.Format("select distinct CSBH from YPZLZLS1 where YPZLBH = '{0}' and CSBH != ''", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);
                SqlCommand cmdX = new SqlCommand(sql, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                sdaX.Fill(dtCS);
                connX.OpenConnection();
                connX.CloseConnection();
                cscount = dtCS.Rows.Count;
            }
            catch (Exception) { }
        }

        #endregion

        #region 取出CGZL最大

        private void MaxDate()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select Cast(year(getdate()) as varchar)+right('0'+CONVERT(varchar,MONTH(getdate())),2) as date");
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    maxD = reader["date"].ToString();
                }

                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select convert(bigint,max(CGNO)) as CGNO from CGZL where CGNO like '{0}%'", maxD);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read()) //有資料
                {
                    maxCG = reader2["CGNO"].ToString();
                }

                if (maxCG == "")
                {
                    maxCG = maxD + "00000";
                    date = true;
                }
                maxCG2 = Int64.Parse(maxCG) + 1;
                Console.WriteLine(maxCG);
            }
            catch (Exception) { }
        }

        private void MaxDate2()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select Cast(year(getdate()) as varchar)+right('0'+CONVERT(varchar,MONTH(getdate())),2) as date");
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    maxD2 = reader["date"].ToString();
                }

                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select convert(bigint,max(CGNO)) as CGNO from CGZL where CGNO like '{0}%'", maxD2);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read()) //有資料
                {
                    maxCG3 = reader2["CGNO"].ToString();
                }

                if (maxCG3 == "")
                {
                    maxCG3 = maxD2 + "00000";
                    date = true;
                }
                maxCG4 = Int64.Parse(maxCG3) + 1;
                Console.WriteLine(maxCG3);
            }
            catch (Exception) { }
        }

        #endregion

        #region 載入CGZL

        private void LoadCgzl()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select CGNO, a.ZSBH, b.zsywjc, Convert(varchar(10),CGDate,111) as CGDATE , GSBH, a.USERID, Convert(varchar(10), a.USERDate,111) as USERDATE , a.YN from (select * from CGZL where YN != 0) as a left join zszl as b on a.ZSBH = b.zsdh where (ZLBH = '{0}' and a.ZT = '2') or  (ZLBH = '{0}' and a.ZT = '4') ", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView2.DataSource = ds.Tables[0];

            }
            catch (Exception) { }
        }

        #endregion

        #region 取出材料

        private void CLBH()
        {
            try
            {
                DBconnect connX = new DBconnect();
                string sqlX = string.Format("select * from YPZLZLS1 where YPZLBH = '{0}' and CSBH = '{1}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sqlX);
                SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                sdaX.Fill(dtX);
                connX.OpenConnection();
                connX.CloseConnection();
                clbhcount = dtX.Rows.Count;
                Console.WriteLine(clbhcount);

                //dtX.Rows[i][0].ToString()

            }
            catch (Exception) { }
        }

        private void CLBH2()
        {
            try
            {


                //dtX.Rows[i][0].ToString()

            }
            catch (Exception) { }
        }

        #endregion

        #region 查詢廠商

        private void Supplier()
        {
            try
            {
                //CLBH();

                ds2 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select zsdh from (select count(CGZLS.CLBH) as co,supplier_list.zsdh,CGNO from CGZLS left join supplier_list on CGZLS.CLBH = supplier_list.cldh where CGNO='{0}' group by zsdh,CGNO) as p where co=(	select count(*) as oldco from CGZLS where  CGNO='{1}' group by CGNO)", textBox1.Text, textBox1.Text);

                //string sql1 = string.Format("SELECT * FROM (SELECT zsdh,COUNT(zsdh) AS CO FROM supplier_list WHERE cldh IN ('{0}'", dtX.Rows[0][1].ToString());

                //for (int i = 1; i < clbhcount; i++)
                //{
                //    sql1 += string.Format(",'{0}'", dtX.Rows[i][1].ToString());
                //}
                //sql1 += string.Format(" )GROUP BY zsdh) AS P WHERE P.CO = '{0}' ", clbhcount);
                Console.WriteLine(sql1);

                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds2, "倉庫位置");
                this.comboBox2.DataSource = ds2.Tables[0];
                this.comboBox2.ValueMember = "zsdh";
                this.comboBox2.DisplayMember = "zsdh";

                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 檢查CGZLS

        private void CheckCgzls()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select count(CGNO) as count from CGZLS where CGNO = '{0}'", textBox1.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                Console.WriteLine(sql);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    checkcgzls = int.Parse(reader["count"].ToString());
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 插入CGZLS

        private void CGZLS()
        {
            try
            {

            }
            catch (Exception) { }
        }



        #endregion

        #region 載入CGZLS

        private void LoadCgzls()
        {
            try
            {
                ds2CGS = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CLBH, b.ywpm, dwbh, XqQty, Qty,Convert(varchar(10),YQDate,111) as YQDate, USPrice, VNPrice, XqQty * USPrice as ACCUS, XqQty * VNPrice as ACCVN,  Convert(varchar(10),a.CFMDate,111) as CFMDate, Memo, a.USERDate, a.USERID from (select * from CGZLS where CGNO = '{0}') as a left join (select * from clzl ) as b on a.CLBH = b.cldh where a.YN != 0 order by CLBH", dataGridView2.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds2CGS, "棧板表");

                dataGridView3.DataSource = ds2CGS.Tables[0];

                int a = 0;
                string b = "", c = "";
                string ywpm = "", cldh = "";
                a = dataGridView3.Rows.Count;
                for (int i = 0; i < a; i++) 
                {
                    if (dataGridView3.Rows[i].Cells[1].Value.ToString() == "") 
                    {
                        b = dataGridView3.Rows[i].Cells[1].Value.ToString();
                        b = b.Substring(0, 1);
                        if (b == "T") 
                        {
                            DBconnect dbConn = new DBconnect();
                            string sql = string.Format("select ywpm,cldh from clzltemp where tempddbh = '{0}'", dataGridView3.Rows[i].Cells[0].Value.ToString());
                            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                            dbConn.OpenConnection();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                ywpm = reader["ywpm"].ToString();
                                cldh = reader["cldh"].ToString();
                            }
                            dbConn.CloseConnection();

                            dataGridView3.Rows[i].Cells[1].Value = ywpm;
                            dataGridView3.Rows[i].Cells[2].Value = cldh;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改廠商

        #region 修改YPZLS

        private void MYPZLS()
        {
            try
            {
                int count = 0;
                DBconnect connX = new DBconnect();
                string sql = string.Format("select YPDH from YPZLZLS where YPZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);
                SqlCommand cmdX = new SqlCommand(sql, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                sdaX.Fill(dtXC);
                connX.OpenConnection();
                connX.CloseConnection();
                count = dtXC.Rows.Count;
                Console.WriteLine(clbhcount);



                for (int i = 0; i < count; i++)
                {

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update YPZLS set CSBH = '{0}' where YPDH = '{1}'", dataGridView2.Rows[i].Cells[1].Value.ToString(), dtXC.Rows[i][0].ToString());

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
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改YPZLZLS1

        private void MYPZLZLS1()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update YPZLZLS1 set CSBH = '{0}' where YPZLBH = '{1}'",  dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
            catch (Exception) { }
        }

        #endregion

        #region 修改YPZLZLS2

        private void MYPZLZLS2()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update YPZLZLS2 set CSBH = '{0}' where YPZLBH = '{1}'", dataGridView2.Rows[0].Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
            catch (Exception) { }
        }

        #endregion

        #region 修改CGZL

        private void MCGZL()
        {
            try
            {
                //DBconnect con4 = new DBconnect();
                //StringBuilder sql4 = new StringBuilder();
                //sql4.AppendFormat("update CGZL set ZSBH = '{0}' where ZLBH = '{1}'", comboBox2.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString());

                //Console.WriteLine(sql4);
                //SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                //con4.OpenConnection();
                //int result4 = cmd4.ExecuteNonQuery();
                //if (result4 == 1)
                //{
                //    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //con4.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion


        #region 修改CGZL

        private void MYPZLZL()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update YPZLZL set YN = 3 where YPZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 修改CGZLS

        private void ModifyCGZLS()
        {
            try
            {
                int a = 0;
                a = ds2CGS.Tables[0].Rows.Count;

                for (int i = 0; i < a; i++)
                {
                    if (ds2CGS.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update CGZLS set USERDate = GETDATE(), YQDate = '{0}' , USPrice = '{1}', VNPrice = '{2}' where CGNO = '{3}' and CLBH = '{4}'", dataGridView3.Rows[i].Cells[5].Value.ToString(), dataGridView3.Rows[i].Cells[6].Value.ToString(), dataGridView3.Rows[i].Cells[7].Value.ToString(), textBox6.Text, dataGridView3.Rows[i].Cells[0].Value.ToString());

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
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region YPZLZLS2廠商

        private void YPZLZLS21()
        {
            try
            {
                ds3 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select distinct YPDH,BWBH,a.CLBH,CSBH,USAGE,a.CLSL, b.CFMDate from YPZLZLS2 as a left join CGZLSS as b on a.YPDH = b.ZLBH and a.CLBH = b.CLBH where YPZLBH = '{0}' and CSBH  = ''", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds3, "棧板表");

                dataGridView4.DataSource = ds3.Tables[0];
            }
            catch (Exception) { }
        }

        private void YPZLZLS22()
        {
            try
            {
                ds3 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select distinct YPDH,BWBH,a.CLBH,CSBH,USAGE,a.CLSL, b.CFMDate from YPZLZLS2 as a left join CGZLSS as b on a.YPDH = b.ZLBH and a.CLBH = b.CLBH where YPZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds3, "棧板表");

                dataGridView4.DataSource = ds3.Tables[0];
            }
            catch (Exception) { }
        }


        #endregion

        #region 檢查採購

        private void CGZLYN()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select count(CGNO) as count from CGZL where ZLBH = '{0}' and YN = 3", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                Console.WriteLine(sql);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    cgzlyn = int.Parse(reader["count"].ToString());
                }
            }
            catch (Exception) { }
        }


        #endregion

        #region 修改YPZLZLS2廠商

        private void ChangeYPZLZLS2()
        {

            DBconnect con5 = new DBconnect();
            StringBuilder sql5 = new StringBuilder();
            sql5.AppendFormat("update YPZLZLS2 set CSBH = '{0}' where YPZLBH = '{1}' and YPDH = '{2}' and BWBH = '{3}'", dataGridView4.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString());

            Console.WriteLine(sql5);
            SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
            con5.OpenConnection();
            int result5 = cmd5.ExecuteNonQuery();
            if (result5 == 1)
            {
                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con5.CloseConnection();

        }

        #endregion

        #region 刪除YPZLZLS1

        private void DeleteYPZLZLS1()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete YPZLZLS1 where YPZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改YPZLZLS2

        private void ModifyYPZLZLs2()
        {
            try
            {
                int c;
                DBconnect connY = new DBconnect();
                string sqlY = string.Format("select YPZLBH,CLBH,CSBH, SUM(CLSL) as CLSL, SUM(QTY) as QTY from YPZLZLS2 where YPZLBH = '{0}' group by YPZLBH,CSBH,CLBH", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
                SqlDataAdapter sdaY = new SqlDataAdapter(cmdY);
                sdaY.Fill(dtY);
                connY.OpenConnection();
                connY.CloseConnection();
                c = dtY.Rows.Count;

                for (int i = 0; i < c; i++)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into YPZLZLS1 values('{0}','{1}','{2}','{3}','{4}',NULL,'{5}',GETDATE(),'1',NULL,NULL,'LTY','LTY')", dtX.Rows[i][0].ToString(), dtX.Rows[i][1].ToString(), dtX.Rows[i][2].ToString(), dtX.Rows[i][3].ToString(), dtX.Rows[i][4].ToString(), userid);
                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();
                }
            }
            catch (Exception) { }
        }

        #endregion

        //#region 修改CGZLS

        //private void ModifyCGZLS()
        //{
        //    try
        //    {
        //        //更改失效CGZL
        //        DBconnect con4 = new DBconnect();
        //        StringBuilder sql4 = new StringBuilder();
        //        sql4.AppendFormat("update CGZL set YN = 0 where ZSBH not in (select CSBH from YPZLZLS1 where YPZLBH = '{0}') and ZLBH = '{1}'", dataGridView4.Rows[0].Cells[0].Value.ToString(), dataGridView4.Rows[0].Cells[0].Value.ToString());

        //        Console.WriteLine(sql4);
        //        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
        //        con4.OpenConnection();
        //        int result4 = cmd4.ExecuteNonQuery();
        //        if (result4 == 1)
        //        {
        //            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        con4.CloseConnection();

        //        //取出新YPZLZLS1
        //        int c;
        //        DBconnect connY = new DBconnect();
        //        string sqlY = string.Format("select CSBH from YPZLZLS1 where CSBH not in ( select ZSBH from CGZL where ZLBH = '{0}') and YPZLBH = '{1}'", dataGridView4.Rows[0].Cells[0].Value.ToString(), dataGridView4.Rows[0].Cells[0].Value.ToString());
        //        Console.WriteLine(sqlY);
        //        SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
        //        SqlDataAdapter sdaY = new SqlDataAdapter(cmdY);
        //        sdaY.Fill(dtZ);
        //        connY.OpenConnection();
        //        connY.CloseConnection();
        //        c = dtZ.Rows.Count;

        //        for (int i = 0; i < c; i++)
        //        {
        //            MaxDate();
        //            int result;
        //            DBconnect conn = new DBconnect();
        //            string sql1 = string.Format("insert into CGZL values('{0}','LTY','VTY','{1}',GETDATE(),GETDATE(),'{2}','6','1',NULL,NULL,NULL,NULL,NULL,NULL,'2','ZLBH',NULL,NULL)", maxCG2, dtZ.Rows[i][0].ToString(), userID, dataGridView4.Rows[0].Cells[0].Value.ToString());
        //            Console.WriteLine(sql1);
        //            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
        //            conn.OpenConnection();
        //            result = cmd1.ExecuteNonQuery();
        //            if (result == 1)
        //            {
        //                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            conn.CloseConnection();
        //        }



        //    }
        //    catch (Exception) { }
        //}

        ////update CGZL set YN = 0 where CGNO in (select * from YPZLZLS1)

        //#endregion

        #region 刪除CGZLS CGZLSS

        private void DeleteCGZLSS()
        {
            try
            {
                //取出新YPZLZLS1
                int c;
                DBconnect connY = new DBconnect();
                string sqlY = string.Format("select CGNO from CGZL where ZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
                SqlDataAdapter sdaY = new SqlDataAdapter(cmdY);
                sdaY.Fill(dtA);
                connY.OpenConnection();
                connY.CloseConnection();
                c = dtA.Rows.Count;


                for (int i = 0; i < c; i++)
                {
                    //刪除CGZLS
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete CGZLS where CGNO = '{0}' and CFMDate is null", dtA.Rows[i][0].ToString());

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //刪除CGZLSS
                    DBconnect con1 = new DBconnect();
                    StringBuilder sql1 = new StringBuilder();
                    sql1.AppendFormat("delete CGZLSS where CGNO = '{0}' and CFMDate is null", dtA.Rows[i][0].ToString());

                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1.ToString(), con1.connection);
                    con1.OpenConnection();
                    int result1 = cmd1.ExecuteNonQuery();
                    if (result1 == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception) { }
        }


        #endregion

        #region 插入CGZLS 

        private void InsertCGZLS()
        {
            try
            {
                int c;
                DBconnect connY = new DBconnect();
                string sqlY = string.Format("select CGNO,ZSBH,ZLBH from CGZL where ZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
                SqlDataAdapter sdaY = new SqlDataAdapter(cmdY);
                sdaY.Fill(dtA);
                connY.OpenConnection();
                connY.CloseConnection();
                c = dtA.Rows.Count;

                //插入CGZLS
                for (int j = 0; j < c; j++)
                {
                    DBconnect connX = new DBconnect();
                    string sqlX = string.Format("select * from YPZLZLS1 where YPZLBH = '{0}' and CSBH = '{1}'", dtA.Rows[j][2].ToString(), dtA.Rows[j][1].ToString());
                    Console.WriteLine(sqlX);
                    SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    connX.CloseConnection();
                    clbhcount = dtX.Rows.Count;
                    Console.WriteLine(clbhcount);

                    for (int i = 0; i < clbhcount; i++)
                    {
                        string US = "", VN = "", BJNO = "";
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select a.BJNO,ZSBH,max(endate) as date,CLBH,USPrice,VNPrice from (select * from CGBJ) as a left join (select * from CGBJS) as b on a.BJNO = b.BJNO where a.ZSBH = '{0}' and b.CLBH = '{1}' and b.YN = '1' and endate > GETDATE() group by a.BJNO,ZSBH,CLBH,USPrice,VNPrice", dtX.Rows[i][2].ToString(), dtX.Rows[i][1].ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        Console.WriteLine(sql);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) //有資料
                        {
                            BJNO = reader["BJNO"].ToString();
                            US = reader["USPrice"].ToString();
                            VN = reader["VNPrice"].ToString();
                        }
                        dbConn.CloseConnection();
                        Console.WriteLine(BJNO);
                        Console.WriteLine(US);
                        Console.WriteLine(VN);


                        int result;
                        DBconnect conn = new DBconnect();
                        string sql1 = string.Format("insert into CGZLS values('LBT','{0}','{1}','{2}','{3}','{4}','{5}',NULL,'{6}',GETDATE(),GETDATE(),GETDATE(),'{7}','1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'LBT')", dtA.Rows[j][0].ToString(), dtX.Rows[i][1].ToString(), dtX.Rows[i][3].ToString(), dtX.Rows[i][4].ToString(), US, VN, BJNO, userid);
                        Console.WriteLine(sql1);
                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        conn.CloseConnection();

                    }
                }
                //插入CGZLSS
            }
            catch (Exception) { }
        }

        #endregion

        #region 插入CGZLSS

        private void InsertCGZLSS()
        {
            try
            {
                int c;
                DBconnect connY = new DBconnect();
                string sqlY = string.Format("select CGNO,ZSBH from CGZL where ZLBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
                SqlDataAdapter sdaY = new SqlDataAdapter(cmdY);
                sdaY.Fill(dtA);
                connY.OpenConnection();
                connY.CloseConnection();
                c = dtA.Rows.Count;



                for (int j = 0; j < c; j++)
                {
                    int count = 0;
                    DBconnect connX = new DBconnect();
                    string sql = string.Format("select YPZLBH,YPDH,CLBH, SUM(CLSL) as CLSL, SUM(QTY) as QTY from YPZLZLS2 where YPZLBH = '{0}' and CSBH = '{1}' group by YPZLBH,YPDH,CLBH ", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dtA.Rows[j][1].ToString());
                    Console.WriteLine(sql);
                    SqlCommand cmdX = new SqlCommand(sql, connX.connection);
                    SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                    sdaX.Fill(dtX);
                    connX.OpenConnection();
                    connX.CloseConnection();
                    count = dtX.Rows.Count;


                    for (int i = 0; i < count; i++)
                    {
                        int result;
                        DBconnect conn = new DBconnect();
                        string sql1 = string.Format("insert into CGZLSS values('LTY','{0}','{1}','{2}',NULL,'{3}','{4}',NULL,GETDATE(),GETDATE(),GETDATE(),'{5}','1',NULL,NULL,NULL,'LTY')", dtA.Rows[j][0].ToString(), dtX.Rows[i][2].ToString(), dtX.Rows[i][1].ToString(), dtX.Rows[i][4].ToString(), dtX.Rows[i][3].ToString(), userid);
                        Console.WriteLine(sql1);
                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn.CloseConnection();
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 備份廠商

        private void BackZSBH()
        {
            try
            {
                #region 讀取廠商

                ds3B = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CSBH from YPZLZLS2 where YPZLBH = '{0}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds3B, "棧板表");

                Console.WriteLine(ds3B.Tables[0].Rows[0][0].ToString());
                Console.WriteLine(ds3B.Tables[0].Rows[1][0].ToString());

                #endregion
            }
            catch (Exception) { }
        }

        private void BackZSBH2()
        {
            try
            {
                #region 讀取廠商

                ds3B2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CSBH from YPZLZLS2 where YPZLBH = '{0}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds3B2, "棧板表");

                Console.WriteLine(ds3B2.Tables[0].Rows[0][0].ToString());
                Console.WriteLine(ds3B2.Tables[0].Rows[1][0].ToString());

                #endregion
            }
            catch (Exception) { }
        }

        #endregion

        #region 讀取CGNO

        private void FindCGNO()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select CGNO from CGZL where ZLBH = '{0}' and YN = '1'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                Console.WriteLine(sql);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    GETCGNO = reader["CGNO"].ToString();
                }
                dbConn.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 檢查CFM

        private void CheckCFM()
        {
            //取出CGNO
            FindCGNO();

            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select count(CGNO) as count from CGZLS where CGNO = '{0}' and CFMDate is not null and CLBH = '{1}'", GETCGNO, dataGridView4.CurrentRow.Cells[2].Value.ToString());
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            Console.WriteLine(sql);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) //有資料
            {
                cfm = reader["count"].ToString();
            }
            dbConn.CloseConnection();

        }
        #endregion

        #region 修改CGZL CGZLS CGZLSS

        //private void ModifyCG() 
        //{
        //    try
        //    {
        //        FindCGNO();

        //        //修改CGZLS
        //        DBconnect con5 = new DBconnect();
        //        StringBuilder sql5 = new StringBuilder();
        //        sql5.AppendFormat("update CGZLS set YN = 0 where CGNO = '{0}' and CLBH  = '{1}'", GETCGNO, dataGridView4.Rows[i].Cells[2].Value.ToString());
        //        Console.WriteLine(sql5);
        //        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
        //        con5.OpenConnection();
        //        int result5 = cmd5.ExecuteNonQuery();
        //        if (result5 == 1)
        //        {
        //            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        con5.CloseConnection();

        //        //修改CGZL

        //        #region 選出廠商

        //        ds3 = new DataSet();
        //        DBconnect dbConn3 = new DBconnect();
        //        string sql3 = string.Format("select CSBH from YPZLZLS2 where YPZLBH = '{0}' and CLBH = '{1}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[2].Value.ToString());
        //        Console.WriteLine(sql3);
        //        SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
        //        adapter3.Fill(ds3, "棧板表");

        //        #endregion

        //        DBconnect con6 = new DBconnect();
        //        StringBuilder sql6 = new StringBuilder();
        //        sql6.AppendFormat("update CGZL set YN = 0 where CGNO = '{0}' and ZSBH  = '{1}'", GETCGNO, ds3.Tables[0].Rows[0][0].ToString());
        //        Console.WriteLine(sql6);
        //        SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);
        //        con6.OpenConnection();
        //        int result6 = cmd6.ExecuteNonQuery();
        //        if (result6 == 1)
        //        {
        //            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        con6.CloseConnection();

        //        //修改CGZLSS
        //        DBconnect con7 = new DBconnect();
        //        StringBuilder sql7 = new StringBuilder();
        //        sql7.AppendFormat("update CGZLSS set YN = 0 where CGNO = '{0}' and CLBH  = '{1}'", GETCGNO, dataGridView4.Rows[i].Cells[2].Value.ToString());
        //        Console.WriteLine(sql7);
        //        SqlCommand cmd7 = new SqlCommand(sql7.ToString(), con7.connection);
        //        con7.OpenConnection();
        //        int result7 = cmd7.ExecuteNonQuery();
        //        if (result7 == 1)
        //        {
        //            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        con7.CloseConnection();
        //    }
        //    catch (Exception) { }
        //}

        #endregion

        #region 修改單頭廠商

        #region 備份廠商

        private void BKZSBH()
        {
            try
            {
                dsBKZS = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql = string.Format("select CGNO, a.ZSBH, b.zsywjc, Convert(varchar(10),CGDate,111) as CGDATE , GSBH, a.USERID, Convert(varchar(10), a.USERDate,111) as USERDATE , a.YN from CGZL as a left join zszl as b on a.ZSBH = b.zsdh where (ZLBH = '{0}' and a.ZT = '2') or  (ZLBH = '{0}' and a.ZT = '4')", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                adapter.Fill(dsBKZS, "棧板表");

                Console.WriteLine(dsBKZS.Tables[0].Rows[0][1].ToString());
                //Console.WriteLine(dsBKZS.Tables[0].Rows[1][1].ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改CGZL

        private void MC()
        {
            try
            {
                //DBconnect con5 = new DBconnect();
                //StringBuilder sql5 = new StringBuilder();
                //sql5.AppendFormat("update CGZL set ZSBH = '{0}' where CGNO = '{1}'", comboBox2.Text.Trim(), dataGridView2.CurrentRow.Cells[0].Value.ToString());
                //Console.WriteLine(sql5);
                //SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                //con5.OpenConnection();
                //int result5 = cmd5.ExecuteNonQuery();
                //if (result5 == 1)
                //{
                //    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //con5.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 紀錄CGZLSS

        private void LCGZLSS()
        {
            try
            {
                dsCGSS = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select distinct ZLBH,CLBH from CGZLSS where CGNO = '{0}'", dataGridView2.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(dsCGSS, "棧板表");

                Console.WriteLine(dsCGSS.Tables[0].Rows[0][0].ToString());
                Console.WriteLine(dsCGSS.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region 找出合併單號

        private void SYPZLZLS2()
        {
            try
            {
                int a = dataGridView2.CurrentRow.Index;

                dsYPS2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql = string.Format("select YPZLBH from YPZLZLS2 where YPDH = '{0}' and CLBH = '{1}'", dsCGSS.Tables[0].Rows[0][0].ToString(), dsCGSS.Tables[0].Rows[0][1].ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                adapter.Fill(dsYPS2, "棧板表");

                Console.WriteLine(dsYPS2.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region updateYPZLZLS2

        private void UYPZLZLS2()
        {
            try
            {

                //DBconnect con5 = new DBconnect();
                //StringBuilder sql5 = new StringBuilder();
                //sql5.AppendFormat("update YPZLZLS2 set CSBH = '{0}' where YPZLBH = '{1}' and YPDH = '{2}' and CLBH = '{3}' and CSBH = '{4}'", comboBox2.Text, dsYPS2.Tables[0].Rows[0][0].ToString(), dsCGSS.Tables[0].Rows[0][0].ToString(), dsCGSS.Tables[0].Rows[0][1].ToString(), dsBKZS.Tables[0].Rows[0][1].ToString());

                //Console.WriteLine(sql5);
                //SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                //con5.OpenConnection();
                //int result5 = cmd5.ExecuteNonQuery();
                //if (result5 == 1)
                //{
                //    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //con5.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 刪除YPZLZS1

        private void deleteYPZLZLS1()
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #region SUM新廠商

        private void SUMNEW() 
        {
            try 
            {

            }
            catch (Exception) { }
        }

        #endregion

        #region 新增廠商

        private void InsertS1() 
        {
            try
            {
                int a = dsSUMNEW.Tables[0].Rows.Count;

                for (int i = 0; i < a; i++)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into YPZLZLS1 (YPZLBH,CLBH,CSBH,CLSL,QTY,USERID,USERDATE)  values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) ", dsSUMNEW.Tables[0].Rows[i][0].ToString(), dsSUMNEW.Tables[0].Rows[i][1].ToString(), dsSUMNEW.Tables[0].Rows[i][2].ToString(), dsSUMNEW.Tables[0].Rows[i][3].ToString(), dsSUMNEW.Tables[0].Rows[i][4].ToString(), userid);
                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.CloseConnection();
                }

            }
            catch (Exception) { }
        }

        #endregion

        #region 檢查舊廠商

        private void OLDYPZLZLS2() 
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #region 計算舊廠商

        private void OldYPZLZLS1()         
        {
            try
            {
                if (oldcheck > 0) //有誤刪資料
                {
                    dsSUMOLD = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql = string.Format("select YPZLBH, CLBH, isnull(CSBH,'') as CSBH, isnull(SUM(CLSL),0) as CLSL, isnull(SUM(QTY),0) as QTY from YPZLZLS2  where YPZLBH = '{0}' and CSBH = '{1}' group by YPZLBH, CLBH, CSBH ", dsYPS2.Tables[0].Rows[0][0].ToString(), dsBKZS.Tables[0].Rows[0][1].ToString());
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn2.connection);
                    adapter.Fill(dsSUMOLD, "棧板表");

                    Console.WriteLine(dsSUMOLD.Tables[0].Rows[0][0].ToString());

                    int a = dsSUMOLD.Tables[0].Rows.Count;

                    for (int i = 0; i < a; i++)
                    {
                        int result;
                        DBconnect conn = new DBconnect();
                        string sql1 = string.Format("insert into YPZLZLS1 (YPZLBH,CLBH,CSBH,CLSL,QTY,USERID,USERDATE)  values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) ", dsSUMOLD.Tables[0].Rows[i][0].ToString(), dsSUMOLD.Tables[0].Rows[i][1].ToString(), dsSUMOLD.Tables[0].Rows[i][2].ToString(), dsSUMOLD.Tables[0].Rows[i][3].ToString(), dsSUMOLD.Tables[0].Rows[i][4].ToString(), userid);
                        Console.WriteLine(sql1);
                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn.CloseConnection();
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #endregion



        #endregion

        #region 事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1) //第一分頁 
                {
                    CheckCG(); //檢查有無資料
                    Console.WriteLine("000");
                    if (cg == 0) //新增資料
                    {
                        //選出全部廠商
                        CSBHALL();
                        //Console.WriteLine("111");
                        for (int i = 0; i < cscount; i++)
                        {
                            MaxDate();
                            Console.WriteLine("222");
                            //新增資料
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into CGZL values('{0}','LTY','VTY','{1}',GETDATE(),GETDATE(),'{2}','6','1',NULL,NULL,NULL,NULL,'1',NULL,'2','{3}',NULL,NULL)", maxCG2, dtCS.Rows[i][0].ToString().Trim(), userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                            Console.WriteLine(sql1);
                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();
                        }
                    }
                    //載入資料
                    LoadCgzl();

                    //取出文字
                    textBox1.Text = dataGridView2.Rows[0].Cells[0].Value.ToString().Trim();
                    textBox2.Text = dataGridView2.Rows[0].Cells[3].Value.ToString().Trim();
                    textBox3.Text = dataGridView2.Rows[0].Cells[6].Value.ToString().Trim();
                    comboBox2.Text = dataGridView2.Rows[0].Cells[1].Value.ToString().Trim();
                    textBox5.Text = dataGridView2.Rows[0].Cells[2].Value.ToString().Trim();

                    Supplier();

                    int dgv2 = 0;
                    dgv2 = dataGridView2.Rows.Count;
                    //MessageBox.Show(dgv2.ToString());

                    for (int i = 0 ; i < dgv2 ; i++) 
                    {
                        //插入CGZLS

                        //MaxDate();
                        dtX2 = new DataTable();
                        DBconnect connX = new DBconnect();
                        string sqlX = string.Format("select * from YPZLZLS1 where YPZLBH = '{0}' and CSBH = '{1}'", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView2.Rows[i].Cells[1].Value.ToString().Trim());
                        Console.WriteLine(sqlX);
                        SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                        SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                        sdaX.Fill(dtX2);
                        connX.OpenConnection();
                        connX.CloseConnection();
                        clbhcount2 = dtX2.Rows.Count;
                        Console.WriteLine(clbhcount2);
                        //CLBH2();
                        //CGZLS();

                        #region CGZLS

                        //檢查CGZLS
                        DBconnect dbConns = new DBconnect();
                        string sqls = string.Format("select isnull(count(CGNO),0) as count from CGZLS where CGNO = '{0}'", dataGridView2.Rows[i].Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sqls);
                        SqlCommand cmds = new SqlCommand(sqls, dbConns.connection);
                        dbConns.OpenConnection();
                        SqlDataReader readers = cmds.ExecuteReader();
                        if (readers.Read()) //有資料
                        {
                            cgs = int.Parse(readers["count"].ToString());
                        }
                        dbConns.CloseConnection();

                        Console.WriteLine(cgs);
                        if (cgs == 0) // 新增
                        {
                            Console.WriteLine("CGZLS");
                            for (int j = 0; j < clbhcount2; j++)
                            {
                                string US = "0", VN = "0", BJNO = "0";
                                DBconnect dbConn = new DBconnect();
                                string sql = string.Format("select a.BJNO,ZSBH,max(endate) as date,CLBH,USPrice,VNPrice from (select * from CGBJ) as a left join (select * from CGBJS) as b on a.BJNO = b.BJNO where a.ZSBH = '{0}' and b.CLBH = '{1}' and b.YN = '1' and endate > GETDATE() group by a.BJNO,ZSBH,CLBH,USPrice,VNPrice", dtX2.Rows[j][2].ToString().Trim(), dtX2.Rows[j][1].ToString().Trim());
                                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                                Console.WriteLine(sql);
                                dbConn.OpenConnection();
                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read()) //有資料
                                {
                                    BJNO = reader["BJNO"].ToString();
                                    US = reader["USPrice"].ToString();
                                    VN = reader["VNPrice"].ToString();
                                }
                                dbConn.CloseConnection();
                                Console.WriteLine(BJNO);
                                Console.WriteLine(US);
                                Console.WriteLine(VN);


                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert into CGZLS values('LTY','{0}','{1}','VTY','{2}','{3}','{4}','{5}',NULL,'{6}',NULL,NULL,GETDATE(),'{7}','1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)", dataGridView2.Rows[i].Cells[0].Value.ToString().Trim(), dtX2.Rows[j][1].ToString().Trim(), dtX2.Rows[j][3].ToString().Trim(), dtX2.Rows[j][3].ToString().Trim(), US, VN, BJNO, userid);
                                Console.WriteLine(sql1);
                                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                conn.OpenConnection();
                                result = cmd1.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                conn.CloseConnection();



                            }
                        }

                        clbhcount2 = 0;

                        #endregion

                        //插入CGZLSS

                        //檢查CGZLSS
                        DBconnect dbConnss = new DBconnect();
                        string sqlss = string.Format("select isnull(count(CGNO),0) as count from CGZLSS where CGNO = '{0}'", dataGridView2.Rows[i].Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sqlss);
                        SqlCommand cmdss = new SqlCommand(sqlss, dbConnss.connection);
                        dbConnss.OpenConnection();
                        SqlDataReader readerss = cmdss.ExecuteReader();
                        if (readerss.Read()) //有資料
                        {
                            cgss = int.Parse(readerss["count"].ToString());
                        }
                        dbConnss.CloseConnection();

                        Console.WriteLine(cgss);
                        if (cgss == 0) // 新增
                        {
                            int result9s;
                            DBconnect conn9s = new DBconnect();
                            string sql9s = string.Format("INSERT INTO CGZLSS (GSBH,CGNO,CLBH,ZLBH,XXCC,Qty,CLSL,YQDate,USERDate,USERID,YN,STAGE,CKBH) (SELECT 'LTY' as GSBH, b.CGNO, a.CLBH, c.YPDH, a.SIZE, sum(isnull(a.QTY, 0)) as QTY, sum(isnull(a.CLSL, 0)) as CLSL, GETDATE() as YQDate, GETDATE() as USERDate, '{0}' as USERID, '1' as YN, '' as STAGE, '' as CKBH FROM YPZLZLS2 as a LEFT JOIN CGZL as b on a.YPZLBH = b.ZLBH and a.CSBH = b.ZSBH left join YPZLZLS as c on a.YPZLBH = c.YPZLBH where a.YPZLBH = '{1}' and a.CSBH != '' group by b.CGNO, a.CLBH, c.YPDH, a.SIZE)", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                            Console.WriteLine(sql9s);
                            SqlCommand cmd9s = new SqlCommand(sql9s, conn9s.connection);
                            conn9s.OpenConnection();
                            result9s = cmd9s.ExecuteNonQuery();
                            if (result9s == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn9s.CloseConnection();
                        }


                    }



                    //Console.WriteLine("333");

                    tabControl1.SelectedTab = tabPage2;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("INSERT ERROR");
            }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1) //第一分頁 
                {
                    //搜尋方法
                    Query();

                    //變色顯示
                    Tab1color();

                    BackZSBH();
                }
                else if (tabControl1.SelectedTab == tabPage4) //第四分頁 
                {

                }
            }

            catch (Exception)
            {
                MessageBox.Show("QUERY ERROR");
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1) //第一分頁 
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    BackZSBH();
                    if (checkBox3.Checked == true) //未選廠商
                    {
                        YPZLZLS21();
                    }
                    else
                    {
                        YPZLZLS22();
                    }
                    btnCompute.Enabled = false;

                    dataGridView4.Columns[0].Width = 200;

                    tabControl1.SelectedTab = tabPage4;
                    //tsbSave.Enabled = true;
                    //tsbCancel.Enabled = true;
                }
            }
            else if (tabControl1.SelectedTab == tabPage2) //第2分頁 
            {
                dataGridView2.ReadOnly = false;
                comboBox2.Enabled = true;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbModify.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage3) //第3分頁 
            {
                dataGridView3.ReadOnly = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbModify.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabPage4) //第4分頁 
            {
                dataGridView4.ReadOnly = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbModify.Enabled = false;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dataGridView2.IsCurrentCellInEditMode)
                {
                    this.dataGridView2.CurrentCell = null;
                }

                if (this.dataGridView3.IsCurrentCellInEditMode)
                {
                    this.dataGridView3.CurrentCell = null;
                }

                if (this.dataGridView4.IsCurrentCellInEditMode)
                {
                    this.dataGridView4.CurrentCell = null;
                }

                if (tabControl1.SelectedTab == tabPage2) //第2分頁 
                {
                    DialogResult dr = MessageBox.Show("Confirm to change supplier?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region OLD
                        //Console.WriteLine("CMYPZLS");
                        //MYPZLS();
                        //Console.WriteLine("CMYPZLZLS1");
                        //MYPZLZLS1();
                        //Console.WriteLine("CMYPZLZLS2");
                        //MYPZLZLS2();
                        //Console.WriteLine("CMCGZL");
                        //MCGZL();
                        //MYPZLZL();
                        #endregion

                        int a = 0;
                        a = ds.Tables[0].Rows.Count;
                        Console.WriteLine(a);
                        for (int i = 0; i < a; i++)
                        {
                            //MessageBox.Show(i.ToString());                        
                            Console.WriteLine(ds.Tables[0].Rows[i].RowState.ToString());
                            if (ds.Tables[0].Rows[i].RowState.ToString() == "Modified")
                            {
                                BKZSBH();
                                //modifyCGZL
                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("update CGZL set ZSBH = '{0}' where CGNO = '{1}'", dataGridView2.Rows[i].Cells[1].Value.ToString().Trim(), dataGridView2.Rows[i].Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5.CloseConnection();

                                //updataYPZLZLS2
                                #region YPZLZLS2
                                //選出ZLBH

                                DBconnect dbConn = new DBconnect();
                                string sql = string.Format("select ZLBH from CGZL where CGNO = '{0}'", dataGridView2.Rows[i].Cells[0].Value.ToString().Trim());
                                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                                Console.WriteLine(sql);
                                dbConn.OpenConnection();
                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read()) //有資料
                                {
                                    ZLBH = reader["ZLBH"].ToString();
                                }
                                dbConn.CloseConnection();
                                //MessageBox.Show(ZLBH);


                                DBconnect con51 = new DBconnect();
                                StringBuilder sql51 = new StringBuilder();
                                sql51.AppendFormat("update YPZLZLS2 set CSBH = '{0}' where YPZLBH = '{1}' and CSBH = '{2}'", dataGridView2.Rows[i].Cells[1].Value.ToString().Trim(), ZLBH, dsBKZS.Tables[0].Rows[i][1].ToString().Trim());

                                Console.WriteLine(sql51);
                                SqlCommand cmd51 = new SqlCommand(sql51.ToString(), con51.connection);
                                con51.OpenConnection();
                                int result51 = cmd51.ExecuteNonQuery();
                                if (result51 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                con51.CloseConnection();
                                #endregion

                                #region deleteYPZLZLS1

                                DBconnect con4 = new DBconnect();
                                StringBuilder sql4 = new StringBuilder();
                                sql4.AppendFormat("delete YPZLZLS1 where CSBH = '{0}' and YPZLBH = '{1}' ", dsBKZS.Tables[0].Rows[i][1].ToString().Trim(), ZLBH);

                                Console.WriteLine(sql4);
                                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                con4.OpenConnection();
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con4.CloseConnection();

                                #endregion

                                #region 加總

                                dsSUMNEW = new DataSet();
                                DBconnect dbConn2 = new DBconnect();
                                string sqln = string.Format("select YPZLBH, CLBH, isnull(CSBH,'') as CSBH, isnull(SUM(CLSL),0) as CLSL, isnull(SUM(QTY),0) as QTY from YPZLZLS2  where YPZLBH = '{0}' and CSBH = '{1}' group by YPZLBH, CLBH, CSBH ", ZLBH, dsBKZS.Tables[0].Rows[i][1].ToString().Trim());
                                Console.WriteLine(sqln);
                                SqlDataAdapter adapter = new SqlDataAdapter(sqln, dbConn2.connection);
                                adapter.Fill(dsSUMNEW, "棧板表");

                                //Console.WriteLine(dsSUMNEW.Tables[0].Rows[0][0].ToString());

                                #endregion

                                InsertS1();

                                #region OLDZLS2

                                DBconnect dbConns2 = new DBconnect();
                                string sqls2 = string.Format("select isnull(count(YPZLBH),0) as count from YPZLZLS2 where CSBH = '{0}' and YPZLBH = '{1}'", dsBKZS.Tables[0].Rows[i][1].ToString().Trim(), ZLBH);
                                SqlCommand cmds2 = new SqlCommand(sqls2, dbConns2.connection);
                                Console.WriteLine(sqls2);
                                dbConns2.OpenConnection();
                                SqlDataReader readers2 = cmds2.ExecuteReader();
                                if (readers2.Read()) //有資料
                                {
                                    oldcheck = int.Parse(readers2["count"].ToString());
                                }
                                dbConn.CloseConnection();
                                #endregion

                                #region INSERTYPZLZLS1

                                if (oldcheck > 0) //有誤刪資料
                                {
                                    dsSUMOLD = new DataSet();
                                    DBconnect dbConn2i = new DBconnect();
                                    string sqli = string.Format("select YPZLBH, CLBH, isnull(CSBH,'') as CSBH, isnull(SUM(CLSL),0) as CLSL, isnull(SUM(QTY),0) as QTY from YPZLZLS2  where YPZLBH = '{0}' and CSBH = '{1}' group by YPZLBH, CLBH, CSBH ", ZLBH, dsBKZS.Tables[0].Rows[i][1].ToString().Trim());
                                    Console.WriteLine(sqli);
                                    SqlDataAdapter adapteri = new SqlDataAdapter(sqli, dbConn2i.connection);
                                    adapteri.Fill(dsSUMOLD, "棧板表");

                                    Console.WriteLine(dsSUMOLD.Tables[0].Rows[0][0].ToString());

                                    int k = dsSUMOLD.Tables[0].Rows.Count;

                                    for (int l = 0; i < k; l++)
                                    {
                                        int result;
                                        DBconnect conn = new DBconnect();
                                        string sql1 = string.Format("insert into YPZLZLS1 (YPZLBH,CLBH,CSBH,CLSL,QTY,USERID,USERDATE)  values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE()) ", dsSUMOLD.Tables[0].Rows[l][0].ToString().Trim(), dsSUMOLD.Tables[0].Rows[l][1].ToString().Trim(), dsSUMOLD.Tables[0].Rows[l][2].ToString().Trim(), dsSUMOLD.Tables[0].Rows[l][3].ToString().Trim(), dsSUMOLD.Tables[0].Rows[l][4].ToString().Trim(), userid);
                                        Console.WriteLine(sql1);
                                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                        conn.OpenConnection();
                                        result = cmd1.ExecuteNonQuery();
                                        if (result == 1)
                                        {
                                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        conn.CloseConnection();
                                    }
                                }

                                #endregion

                            }
                        }

                    }
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbModify.Enabled = true;
                    dataGridView2.ReadOnly = true;
                    comboBox2.Enabled = false;
                }
                else if (tabControl1.SelectedTab == tabPage3) //第3分頁 
                {
                    //dataGridView3.ReadOnly = true;
                    ModifyCGZLS();
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbModify.Enabled = true;

                    //int a = dataGridView3.Rows.Count;
                    //double x = 0, y = 0, m = 0, n = 0;

                    //Console.WriteLine(dataGridView3.Rows[0].Cells[5].Value.ToString());
                    //Console.WriteLine(dataGridView3.Rows[0].Cells[6].Value.ToString());
                    //Console.WriteLine(dataGridView3.Rows[0].Cells[3].Value.ToString());
                    //Console.WriteLine(dataGridView3.Rows[0].Cells[4].Value.ToString());

                    //for (int i = 0; i < a; i++)
                    //{

                    //    x = Double.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                    //    y = Double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    //    m = Double.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());
                    //    n = Double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());

                    //    dataGridView3.Rows[i].Cells[7].Value = x * m;
                    //    dataGridView3.Rows[i].Cells[8].Value = y * n;
                    //}
                }


                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tabControl1.SelectedTab = tabPage1;
            comboBox2.Enabled = false;
        }


        #endregion

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                LoadCgzls();

                textBox6.Text = textBox1.Text;
                textBox7.Text = textBox5.Text;
                textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                dataGridView3.Columns[5].DefaultCellStyle.BackColor = Color.Aqua;
                dataGridView3.Columns[0].Width = 200;
                tabControl1.SelectedTab = tabPage3;
                dataGridView3.Columns[1].Width = 200;

            }
            catch (Exception)
            {
                MessageBox.Show("LOAD PAGE2 ERROR");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //開啟日期編輯
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        #region 畫面載入

        private void SamplePurchase2_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nEW_ERPDataSet.DataTable1' 資料表。您可以視需要進行移動或移除。
            //this.dataTable1TableAdapter.Fill(this.nEW_ERPDataSet.DataTable1);


            try
            {
                userid = Program.User.userID;
                //品牌載入
                Kfzl();
            }
            catch (Exception) { }
        }

        #endregion



        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true) //未選廠商
                {
                    YPZLZLS21();
                }
                else
                {
                    YPZLZLS22();
                }

                dataGridView4.Columns[0].Width = 200;
            }
            catch (Exception) { }
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.CurrentRow.Cells[6].Value.ToString() != "")
                {
                    MessageBox.Show("已經採購確認", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    string clbh = "";

                    clbh = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                    clbh = clbh.Substring(0, 1);
                    //MessageBox.Show(clbh);
                    //檢查天數
                    //CGZLYN();
                    //if (cgzlyn > 0)
                    //{
                    //    MessageBox.Show("已經確定無法修改", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                        ////檢查CFM
                        //CheckCFM();
                        //if (cfm == "0")
                        //{
                            if (clbh == "T")
                            {
                                MessageBox.Show("臨時料號", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                SampleZsbh Form = new SampleZsbh();
                                Form.clbh = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                                Form.zsdh = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                                Form.ShowDialog();
                                Console.WriteLine(Form.zsdh);

                                dataGridView4.CurrentRow.Cells[3].Value = Form.zsdh;

                                if (Form.changezsdh == "1")
                                {
                                    btnCompute.Enabled = true;
                                }
                            }

                        //}
                        //else
                        //{
                        //    MessageBox.Show("已經確認日期 請取消確認", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        //tsbSave.Enabled = true;
                    //}
                }
            }
            catch (Exception) { }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                BackZSBH2();
                //重新計算

                int a = 0;
                a = ds3B2.Tables[0].Rows.Count;
                Console.WriteLine(a);
                countdel = 0;

                for (int i = 0; i < a; i++)
                {

                    //Console.WriteLine(ds3.Tables[0].Rows[i].RowState.ToString());
                    //Console.WriteLine(i);

                    if (ds3.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                    {

                    }
                    else if (ds3.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        int checkss = 0;
                        Console.WriteLine(ds3B2.Tables[0].Rows[0][0].ToString());
                        Console.WriteLine(ds3B2.Tables[0].Rows[1][0].ToString());

                        int cgzls = 0;
                        //檢查CGZLSS
                        DBconnect dbConnq = new DBconnect();
                        string sqlq = string.Format("select count(ZSBH) as count from CGZL as a left join CGZLSS as b on a.CGNO = b.CGNO where a.ZLBH = '{0}' and b.CLBH = '{1}' and ZSBH = '{2}'", dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim());
                        SqlCommand cmdq = new SqlCommand(sqlq, dbConnq.connection);
                        Console.WriteLine(sqlq);
                        dbConnq.OpenConnection();
                        SqlDataReader readerq = cmdq.ExecuteReader();
                        if (readerq.Read()) //有資料
                        {
                            cgzls = int.Parse(readerq["count"].ToString());
                        }
                        dbConnq.CloseConnection();


                        if (cgzls == 0)
                        {
                            //delete CGZLS
                            if (countdel == 0)
                            {
                                DBconnect con5ds = new DBconnect();
                                StringBuilder sql5ds = new StringBuilder();
                                sql5ds.AppendFormat("update CGZLS set YN = '0', USERID = '{0}', USERDate = GETDATE() where CGNO in (select a.CGNO from CGZL as a left join CGZLS as b on a.CGNO = b.CGNO where a.ZLBH = '{1}' and b.CLBH = '{2}') and CLBH = '{2}'", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                                Console.WriteLine(sql5ds);
                                SqlCommand cmd5ds = new SqlCommand(sql5ds.ToString(), con5ds.connection);
                                con5ds.OpenConnection();
                                int result5ds = cmd5ds.ExecuteNonQuery();
                                if (result5ds == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5ds.CloseConnection();
                                countdel = 1;
                            }
                        }


                        #region NEW

                        //修改YPZLZL
                        DBconnect conZL = new DBconnect();
                        StringBuilder sqlZL = new StringBuilder();
                        sqlZL.AppendFormat("update YPZLZL set YN = '3',USERID = '{0}', USERDATE = GETDATE() where YPZLBH = '{1}'", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sqlZL);
                        SqlCommand cmdZL = new SqlCommand(sqlZL.ToString(), conZL.connection);
                        conZL.OpenConnection();
                        int resultZL = cmdZL.ExecuteNonQuery();
                        if (resultZL == 1)
                        {
                            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conZL.CloseConnection();


                        //檢查CGZLSS
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select isnull(count(ZLBH), 0) as count from CGZLSS where ZLBH = '{0}' and CLBH = '{1}' and CFMDate is not null", dataGridView4.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        Console.WriteLine(sql);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) //有資料
                        {
                            checkss = int.Parse(reader["count"].ToString());
                        }
                        dbConn.CloseConnection();
                        Console.WriteLine(checkss);


                        if (checkss == 1)
                        {
                            MessageBox.Show("已經確認日期 請取消確認", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                            #region UPDATE YPZLZLS2

                            //UPDATE YPZLZLS2
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update YPZLZLS2 set CSBH = '{0}', USERID = '{1}', USERDATE = GETDATE() where YPZLBH = '{2}' and YPDH = '{3}' and BWBH = '{4}' and CLBH = '{5}' and CSBH = '{6}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[1].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            #endregion

                            #region CGZL CGZLS CGZLSS

                            #region deleteCGZLSS

                            //取CGNO
                            string cgdelete = "";
                            DBconnect dbConn6d = new DBconnect();
                            string sql6d = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(),dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            SqlCommand cmd6d = new SqlCommand(sql6d, dbConn6d.connection);
                            Console.WriteLine(sql6d);
                            dbConn6d.OpenConnection();
                            SqlDataReader reader6d = cmd6d.ExecuteReader();
                            if (reader6d.Read()) //有資料
                            {
                                cgdelete = reader6d["CGNO"].ToString();
                            }
                            dbConn6d.CloseConnection();




                            #endregion

                            #region 新廠商

                            #region CGZL

                            int checkcg = 0;
                            DBconnect dbConn6 = new DBconnect();
                            string sql6 = string.Format("select isnull(count(CGZL.ZSBH),0) as count from CGZL left join CGZLS on CGZL.CGNO = CGZLS.CGNO where ZSBH = '{0}' and ZLBH = '{1}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            SqlCommand cmd6 = new SqlCommand(sql6, dbConn6.connection);
                            Console.WriteLine(sql6);
                            dbConn6.OpenConnection();
                            SqlDataReader reader6 = cmd6.ExecuteReader();
                            if (reader6.Read()) //有資料
                            {
                                checkcg = int.Parse(reader6["count"].ToString());
                            }
                            dbConn6.CloseConnection();

                            if (checkcg == 0) //沒有資料新增
                            {
                                //insert CGZL
                                MaxDate2();
                                int result7;
                                DBconnect conn7 = new DBconnect();
                                string sql7 = string.Format("insert into CGZL (CGNO,GSBH,CKBH,ZSBH,USERDate,USERID,CGLX,YN,PRLX,ZT,ZLBH,CGDate) values('{0}','LTY','VTY','{1}', GETDATE(),'{2}','6','1','1','2','{3}', GETDATE())", maxCG4, dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql7);
                                SqlCommand cmd7 = new SqlCommand(sql7, conn7.connection);
                                conn7.OpenConnection();
                                result7 = cmd7.ExecuteNonQuery();
                                if (result7 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                conn7.CloseConnection();

                                //取出YPZLZLS1
                                string yypzlbh ="", zclbh = "", ycsbh = "", yclsl = "", yqty = "";
                                DBconnect dbConns = new DBconnect();
                                string sqls = string.Format("select YPZLBH,CLBH,CSBH,CLSL,QTY from YPZLZLS1 where YPZLBH = '{0}' and CLBH = '{1}' and CSBH = '{2}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                SqlCommand cmds = new SqlCommand(sqls, dbConns.connection);
                                Console.WriteLine(sqls);
                                dbConns.OpenConnection();
                                SqlDataReader readers = cmds.ExecuteReader();
                                if (readers.Read()) //有資料
                                {
                                    yypzlbh = readers["YPZLBH"].ToString();
                                    zclbh = readers["CLBH"].ToString();
                                    ycsbh = readers["CSBH"].ToString();
                                    yclsl = readers["CLSL"].ToString();
                                    yqty = readers["QTY"].ToString();
                                }
                                dbConns.CloseConnection();

                                string US = "", VN = "", BJNO = "";
                                DBconnect dbConnBJ = new DBconnect();
                                string sqlBJ = string.Format("select a.BJNO,ZSBH,max(endate) as date,CLBH,USPrice,VNPrice from (select * from CGBJ) as a left join (select * from CGBJS) as b on a.BJNO = b.BJNO where a.ZSBH = '{0}' and b.CLBH = '{1}' and b.YN = '1' and endate > GETDATE() group by a.BJNO,ZSBH,CLBH,USPrice,VNPrice", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                                SqlCommand cmdBJ = new SqlCommand(sqlBJ, dbConnBJ.connection);
                                Console.WriteLine(sqlBJ);
                                dbConnBJ.OpenConnection();
                                SqlDataReader readerBJ = cmdBJ.ExecuteReader();
                                if (readerBJ.Read()) //有資料
                                {
                                    BJNO = readerBJ["BJNO"].ToString();
                                    US = readerBJ["USPrice"].ToString();
                                    VN = readerBJ["VNPrice"].ToString();
                                }
                                dbConnBJ.CloseConnection();
                                if (yclsl == "")
                                {
                                    yclsl = "0";
                                    yqty = "0";
                                }
                                if (BJNO == "") 
                                {
                                    US = "0";
                                    VN = "0";
                                }


                                //insert CGZLS    
                                int result9;
                                DBconnect conn9 = new DBconnect();
                                string sql9 = string.Format("insert into CGZLS (GSBH, CGNO, CLBH, CKBH, XqQty, Qty,USPrice,VNPrice,BJNO,USERDate,USERID,YN) values ('LBT','{0}','{1}','LBT','{2}','{3}','{4}','{5}','{6}',GETDATE(),'{7}','1')", maxCG4, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), US, VN, BJNO, userid);
                                Console.WriteLine(sql9);
                                SqlCommand cmd9 = new SqlCommand(sql9, conn9.connection);
                                conn9.OpenConnection();
                                result9 = cmd9.ExecuteNonQuery();
                                if (result9 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                conn9.CloseConnection();

                            }
                            else  //有資料YN1
                            {

                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("update CGZL set YN = 1, USERID = '{0}' , USERDate = GETDATE() where ZSBH = '{1}' and ZLBH = '{2}'", userid, dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5.CloseConnection();

                                //取資料YPZLZLS1
                                string sclsl = "0", sqty = "0";
                                DBconnect dbConnBJ = new DBconnect();
                                string sqlBJ = string.Format("select CLSL,QTY from YPZLZLS1 where YPZLBH = '{0}' and CLBH = '{1}' and CSBH = '{2}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                SqlCommand cmdBJ = new SqlCommand(sqlBJ, dbConnBJ.connection);
                                Console.WriteLine(sqlBJ);
                                dbConnBJ.OpenConnection();
                                SqlDataReader readerBJ = cmdBJ.ExecuteReader();
                                if (readerBJ.Read()) //有資料
                                {
                                    sclsl = readerBJ["CLSL"].ToString();
                                    sqty = readerBJ["QTY"].ToString();
                                }
                                dbConnBJ.CloseConnection();

                                //取CGNO

                                DBconnect dbConnBJ2 = new DBconnect();
                                string sqlBJ2 = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                SqlCommand cmdBJ2 = new SqlCommand(sqlBJ2, dbConnBJ2.connection);
                                Console.WriteLine(sqlBJ2);
                                dbConnBJ2.OpenConnection();
                                SqlDataReader readerBJ2 = cmdBJ2.ExecuteReader();
                                if (readerBJ2.Read()) //有資料
                                {
                                    cgnos1 = readerBJ2["CGNO"].ToString();
                                }
                                dbConnBJ2.CloseConnection();

                                //select CGZLS
                                string clbh = "";
                                DBconnect dbConn11 = new DBconnect();
                                string sql11 = string.Format("select COUNT(CLBH) as count from CGZLS where CGNO = '{0}' and CLBH = '{1}'", cgnos1, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                                SqlCommand cmd11 = new SqlCommand(sql11, dbConn11.connection);
                                Console.WriteLine(sql11);
                                dbConn11.OpenConnection();
                                SqlDataReader reader11 = cmd11.ExecuteReader();
                                if (reader11.Read()) //有資料
                                {
                                    clbh = reader11["count"].ToString();
                                }
                                dbConn11.CloseConnection();

                                if (clbh == "1")
                                {
                                    //update CGZLS
                                    DBconnect con5s = new DBconnect();
                                    StringBuilder sql5s = new StringBuilder();
                                    sql5s.AppendFormat("update CGZLS set YN = '1', XqQty = isnull(XqQty,0) + '{0}' , Qty = isnull(Qty,0) + '{1}',USERID = '{2}', USERDate = GETDATE() where CLBH = '{3}' and CGNO = '{4}'", dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), userid, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), cgnos1);
                                    Console.WriteLine(sql5s);
                                    SqlCommand cmd5s = new SqlCommand(sql5s.ToString(), con5s.connection);
                                    con5s.OpenConnection();
                                    int result5s = cmd5s.ExecuteNonQuery();
                                    if (result5s == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5s.CloseConnection();
                                }
                                else 
                                {
                                    string US = "", VN = "", BJNO = "";

                                    DBconnect dbConnBJ3 = new DBconnect();
                                    string sqlBJ3 = string.Format("select a.BJNO,ZSBH,max(endate) as date,CLBH,USPrice,VNPrice from (select * from CGBJ) as a left join (select * from CGBJS) as b on a.BJNO = b.BJNO where a.ZSBH = '{0}' and b.CLBH = '{1}' and b.YN = '1' and endate > GETDATE() group by a.BJNO,ZSBH,CLBH,USPrice,VNPrice", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                                    SqlCommand cmdBJ3 = new SqlCommand(sqlBJ3, dbConnBJ3.connection);
                                    Console.WriteLine(sqlBJ3);
                                    dbConnBJ3.OpenConnection();
                                    SqlDataReader readerBJ3 = cmdBJ3.ExecuteReader();
                                    if (readerBJ3.Read()) //有資料
                                    {
                                        BJNO = readerBJ3["BJNO"].ToString();
                                        US = readerBJ3["USPrice"].ToString();
                                        VN = readerBJ3["VNPrice"].ToString();
                                    }
                                    dbConnBJ3.CloseConnection();
                                    
                                    if (BJNO == "")
                                    {
                                        US = "0";
                                        VN = "0";
                                    }
                                    //insert
                                    int result9;
                                    DBconnect conn9 = new DBconnect();
                                    string sql9 = string.Format("insert into CGZLS (GSBH, CGNO, CLBH, CKBH, XqQty, Qty,USPrice,VNPrice,BJNO,USERDate,USERID,YN) values ('LBT','{0}','{1}','LBT','{2}','{3}','{4}','{5}','{6}',GETDATE(),'{7}','1')", cgnos1, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), US, VN, BJNO, userid);
                                    Console.WriteLine(sql9);
                                    SqlCommand cmd9 = new SqlCommand(sql9, conn9.connection);
                                    conn9.OpenConnection();
                                    result9 = cmd9.ExecuteNonQuery();
                                    if (result9 == 1)
                                    {
                                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    conn9.CloseConnection();
                                }
                            }

                            #endregion

                            #endregion

                            #region UPDATE YPZLZLS1

                            #region OLD廠商

                            //OLD廠商
                            int olds1 = 0;
                            DBconnect dbConn1 = new DBconnect();
                            string sql1 = string.Format("select isnull(count(YPZLBH),0) as count from YPZLZLS2 where CSBH = '{0}' and YPZLBH = '{1}' and YPDH = '{2}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim());
                            SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                            Console.WriteLine(sql1);
                            dbConn1.OpenConnection();
                            SqlDataReader reader1 = cmd1.ExecuteReader();
                            if (reader1.Read()) //有資料
                            {
                                olds1 = int.Parse(reader1["count"].ToString());
                            }
                            dbConn1.CloseConnection();
                            Console.WriteLine(olds1);

                            if (olds1 == 0) // 停用
                            {
                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("update YPZLZLS1 set YN = 0, USERID = '{0}', USERDATE = GETDATE() where YPZLBH = '{1}' and CLBH = '{2}' and CSBH = '{3}'", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5.CloseConnection();
                            }
                            else //有繼續使用
                            {
                                double s2clsl = 0, s2qty = 0;
                                //選出扣除數量
                                DBconnect dbConn2 = new DBconnect();
                                string sql2 = string.Format("select CLSL, QTY from YPZLZLS2 where CSBH = '{0}' and YPZLBH = '{1}' and YPDH = '{2}' and CLBH = '{3}' and BWBH = '{4}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[1].Value.ToString().Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                                Console.WriteLine(sql2);
                                dbConn2.OpenConnection();
                                SqlDataReader reader2 = cmd2.ExecuteReader();
                                if (reader2.Read()) //有資料
                                {
                                    s2clsl = double.Parse(reader2["CLSL"].ToString());
                                    s2qty = double.Parse(reader2["QTY"].ToString());
                                }
                                dbConn2.CloseConnection();

                                //扣除UPZLZLS
                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("update YPZLZLS1 set CLSL = CLSL - '{0}', QTY = QTY - '{1}', USERID = '{2}', USERDATE = GETDATE() where YPZLBH = '{3}' and CLBH = '{4}' and CSBH = '{5}'", dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5.CloseConnection();

                                //扣除CGZLS
                                DBconnect con5c = new DBconnect();
                                StringBuilder sql5c = new StringBuilder();
                                sql5c.AppendFormat("update CGZLS set YN = '1',XqQty = XqQty - '{0}', Qty = Qty- '{1}',USERID = '{2}',USERDate = GETDATE() where CLBH = '{3}' and CGNO in (select distinct a.CGNO from CGZL as a left join CGZLSS as b on a.CGNO = b.CGNO where a.ZLBH = '{4}' and b.CLBH = '{5}' and ZSBH = '{6}')", dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), userid, dataGridView4.Rows[i].Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                Console.WriteLine(sql5c);
                                SqlCommand cmd5c = new SqlCommand(sql5c.ToString(), con5c.connection);
                                con5c.OpenConnection();
                                int result5c = cmd5c.ExecuteNonQuery();
                                if (result5c == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5c.CloseConnection();


                            }
                            
                            //delete
                            DBconnect con5d = new DBconnect();
                            StringBuilder sql5d = new StringBuilder();
                            sql5d.AppendFormat("delete CGZLSS where CGNO in (SELECT  distinct b.CGNO FROM YPZLZLS2 as a LEFT JOIN CGZL as b on a.YPZLBH = b.ZLBH and a.CSBH = b.ZSBH left join YPZLZLS as c on a.YPZLBH = c.YPZLBH where a.YPZLBH = '{0}' and a.CSBH != '' group by b.CGNO, a.CLBH, c.YPDH, a.SIZE)", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            Console.WriteLine(sql5d);
                            SqlCommand cmd5d = new SqlCommand(sql5d.ToString(), con5d.connection);
                            con5d.OpenConnection();
                            int result5d = cmd5d.ExecuteNonQuery();
                            if (result5d == 1)
                            {
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con5d.CloseConnection();

                            #endregion

                            #region NEW廠商

                            //NEW廠商
                            int news1 = 0;
                            DBconnect dbConn3 = new DBconnect();
                            string sql3 = string.Format("select isnull(count(YPZLBH),0) as count from YPZLZLS2 where CSBH = '{0}' and YPZLBH = '{1}' and YPDH = '{2}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim());
                            SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                            Console.WriteLine(sql3);
                            dbConn3.OpenConnection();
                            SqlDataReader reader3 = cmd3.ExecuteReader();
                            if (reader3.Read()) //有資料
                            {
                                news1 = int.Parse(reader3["count"].ToString());
                            }
                            dbConn3.CloseConnection();
                            Console.WriteLine(olds1);

                            if (news1 == 0) //無資料新增 
                            {
                                double s2clsl = 0, s2qty = 0;
                                //選出扣除數量
                                DBconnect dbConn2 = new DBconnect();
                                string sql2 = string.Format("select SUM(CLSL) as CLSL,SUM(QTY) as QTY from YPZLZLS2 where YPZLBH = '{0}' and YPDH = '{1}' and CSBH = '{2}' and CLBH = '{3}'", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                                Console.WriteLine(sql2);
                                dbConn2.OpenConnection();
                                SqlDataReader reader2 = cmd2.ExecuteReader();
                                if (reader2.Read()) //有資料
                                {
                                    s2clsl = double.Parse(reader2["CLSL"].ToString());
                                    s2qty = double.Parse(reader2["QTY"].ToString());
                                }
                                dbConn2.CloseConnection();

                                //insert YPZLZLS1
                                int result5;
                                DBconnect conn5 = new DBconnect();
                                string sql5 = string.Format("insert into YPZLZLS1 (YPZLBH, CLBH, CSBH, CLSL,QTY,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE())", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), s2clsl, s2qty, userid);
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5, conn5.connection);
                                conn5.OpenConnection();
                                result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                conn5.CloseConnection();
                            }
                            else //有資料加入
                            {
                                double s2clsl = 0, s2qty = 0;
                                //選出扣除數量
                                DBconnect dbConn2 = new DBconnect();
                                string sql2 = string.Format("select CLSL, QTY from YPZLZLS2 where CSBH = '{0}' and YPZLBH = '{1}' and YPDH = '{2}' and CLBH = '{3}' and BWBH = '{4}'", dataGridView4.Rows[i].Cells[3].Value.ToString().Trim(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[1].Value.ToString().Trim());
                                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                                Console.WriteLine(sql2);
                                dbConn2.OpenConnection();
                                SqlDataReader reader2 = cmd2.ExecuteReader();
                                if (reader2.Read()) //有資料
                                {
                                    s2clsl = double.Parse(reader2["CLSL"].ToString());
                                    s2qty = double.Parse(reader2["QTY"].ToString());
                                }
                                dbConn2.CloseConnection();

                                //扣除UPZLZLS
                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("update YPZLZLS1 set YN  ='1',CLSL = CLSL + '{0}', QTY = QTY + '{1}', USERID = '{2}', USERDATE = GETDATE() where YPZLBH = '{3}' and CLBH = '{4}' and CSBH = '{5}'", s2clsl, s2qty, userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5.CloseConnection();

                                //扣除CGZLS
                                DBconnect con5c = new DBconnect();
                                StringBuilder sql5c = new StringBuilder();
                                sql5c.AppendFormat("update CGZLS set YN = '1',XqQty = XqQty + '{0}', Qty = Qty + '{1}',USERID = '{2}',USERDate = GETDATE() where CLBH = '{3}' and CGNO in (select distinct a.CGNO from CGZL as a left join CGZLSS as b on a.CGNO = b.CGNO where a.ZLBH = '{4}' and b.CLBH = '{5}' and ZSBH = '{6}')", dataGridView4.Rows[i].Cells[5].Value.ToString(), dataGridView4.Rows[i].Cells[5].Value.ToString(), userid, dataGridView4.Rows[i].Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                                Console.WriteLine(sql5c);
                                SqlCommand cmd5c = new SqlCommand(sql5c.ToString(), con5c.connection);
                                con5c.OpenConnection();
                                int result5c = cmd5c.ExecuteNonQuery();
                                if (result5c == 1)
                                {
                                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                con5c.CloseConnection();
                            }


                            #endregion

                            #endregion

                            #region 舊廠商
                            int checkcgold = 0;
                            int checkcgoldclbh = 0;
                            //取資料YPZLZLS1
                            DBconnect dbConn8 = new DBconnect();
                            string sql8 = string.Format("select isnull(count(CLBH),0) as count from YPZLZLS2 where YPZLBH = '{0}'  and CSBH = '{1}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString());
                            SqlCommand cmd8 = new SqlCommand(sql8, dbConn8.connection);
                            Console.WriteLine(sql8);
                            dbConn8.OpenConnection();
                            SqlDataReader reader8 = cmd8.ExecuteReader();
                            if (reader8.Read()) //有資料
                            {
                                checkcgold = int.Parse(reader8["count"].ToString());
                            }
                            dbConn8.CloseConnection();

                            DBconnect dbConn811 = new DBconnect();
                            string sql811 = string.Format("select isnull(count(CLBH),0) as count from YPZLZLS2 where YPZLBH = '{0}'  and CSBH = '{1}' and CLBH = '{2}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView4.Rows[i].Cells[2].Value.ToString());
                            SqlCommand cmd81 = new SqlCommand(sql811, dbConn811.connection);
                            Console.WriteLine(sql811);
                            dbConn811.OpenConnection();
                            SqlDataReader reader81 = cmd81.ExecuteReader();
                            if (reader81.Read()) //有資料
                            {
                                checkcgoldclbh = int.Parse(reader81["count"].ToString());
                            }
                            dbConn811.CloseConnection();

                            if (checkcgoldclbh == 0)
                            {
                                if (checkcgold == 0) //沒有資料
                                {
                                    //修改CGNO = 0
                                    //update CGZLS
                                    DBconnect con5s = new DBconnect();
                                    StringBuilder sql5s = new StringBuilder();
                                    sql5s.AppendFormat("update CGZL set YN = 0 where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql5s);
                                    SqlCommand cmd5s = new SqlCommand(sql5s.ToString(), con5s.connection);
                                    con5s.OpenConnection();
                                    int result5s = cmd5s.ExecuteNonQuery();
                                    if (result5s == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5s.CloseConnection();


                                    string cgnos1 = "";
                                    DBconnect dbConnBJ2 = new DBconnect();
                                    string sqlBJ2 = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    SqlCommand cmdBJ2 = new SqlCommand(sqlBJ2, dbConnBJ2.connection);
                                    Console.WriteLine(sqlBJ2);
                                    dbConnBJ2.OpenConnection();
                                    SqlDataReader readerBJ2 = cmdBJ2.ExecuteReader();
                                    if (readerBJ2.Read()) //有資料
                                    {
                                        cgnos1 = readerBJ2["CGNO"].ToString();
                                    }
                                    dbConnBJ2.CloseConnection();

                                    double zz = 0;
                                    zz = double.Parse(dataGridView4.Rows[i].Cells[5].Value.ToString().Trim())*2;
                                    Console.WriteLine(zz);
                                    //update CGZLS
                                    DBconnect con5ss = new DBconnect();
                                    StringBuilder sql5ss = new StringBuilder();
                                    sql5ss.AppendFormat("update CGZLS set YN = 0,XqQty = XqQty-'{0}' ,Qty = Qty- '{1}',USERID = '{2}',USERDate = GETDATE() where CLBH = '{3}' and CGNO = '{4}'", zz, zz, userid, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), cgnos1);
                                    Console.WriteLine(sql5ss);
                                    SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                                    con5ss.OpenConnection();
                                    int result5ss = cmd5ss.ExecuteNonQuery();
                                    if (result5ss == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5ss.CloseConnection();
                                }
                                else
                                {
                                    //取資料YPZLZLS1
                                    string sclsl = "0", sqty = "0";
                                    DBconnect dbConnBJ = new DBconnect();
                                    string sqlBJ = string.Format("select CLSL,QTY from YPZLZLS1 where YPZLBH = '{0}' and CLBH = '{1}' and CSBH = '{2}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim());
                                    SqlCommand cmdBJ = new SqlCommand(sqlBJ, dbConnBJ.connection);
                                    Console.WriteLine(sqlBJ);
                                    dbConnBJ.OpenConnection();
                                    SqlDataReader readerBJ = cmdBJ.ExecuteReader();
                                    if (readerBJ.Read()) //有資料
                                    {
                                        sclsl = readerBJ["CLSL"].ToString();
                                        sqty = readerBJ["QTY"].ToString();
                                    }
                                    dbConnBJ.CloseConnection();

                                    string cgnos1 = "";
                                    DBconnect dbConnBJ2 = new DBconnect();
                                    string sqlBJ2 = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    SqlCommand cmdBJ2 = new SqlCommand(sqlBJ2, dbConnBJ2.connection);
                                    Console.WriteLine(sqlBJ2);
                                    dbConnBJ2.OpenConnection();
                                    SqlDataReader readerBJ2 = cmdBJ2.ExecuteReader();
                                    if (readerBJ2.Read()) //有資料
                                    {
                                        cgnos1 = readerBJ2["CGNO"].ToString();
                                    }
                                    dbConnBJ2.CloseConnection();

                                    //update CGZLS
                                    DBconnect con5ss = new DBconnect();
                                    StringBuilder sql5ss = new StringBuilder();
                                    sql5ss.AppendFormat("update CGZLS set YN = 0,USERID = '{0}',USERDate = GETDATE() where CLBH = '{1}' and CGNO = '{2}'", userid, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), cgnos1);
                                    Console.WriteLine(sql5ss);
                                    SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                                    con5ss.OpenConnection();
                                    int result5ss = cmd5ss.ExecuteNonQuery();
                                    if (result5ss == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5ss.CloseConnection();
                                }
                            }
                            else
                            {
                                if (checkcgold == 0) //沒有資料
                                {
                                    //修改CGNO = 0
                                    //update CGZLS
                                    DBconnect con5s = new DBconnect();
                                    StringBuilder sql5s = new StringBuilder();
                                    sql5s.AppendFormat("update CGZL set YN = 0 where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql5s);
                                    SqlCommand cmd5s = new SqlCommand(sql5s.ToString(), con5s.connection);
                                    con5s.OpenConnection();
                                    int result5s = cmd5s.ExecuteNonQuery();
                                    if (result5s == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5s.CloseConnection();


                                    string cgnos1 = "";
                                    DBconnect dbConnBJ2 = new DBconnect();
                                    string sqlBJ2 = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    SqlCommand cmdBJ2 = new SqlCommand(sqlBJ2, dbConnBJ2.connection);
                                    Console.WriteLine(sqlBJ2);
                                    dbConnBJ2.OpenConnection();
                                    SqlDataReader readerBJ2 = cmdBJ2.ExecuteReader();
                                    if (readerBJ2.Read()) //有資料
                                    {
                                        cgnos1 = readerBJ2["CGNO"].ToString();
                                    }
                                    dbConnBJ2.CloseConnection();


                                    //update CGZLS
                                    DBconnect con5ss = new DBconnect();
                                    StringBuilder sql5ss = new StringBuilder();
                                    sql5ss.AppendFormat("update CGZLS set YN = 0,USERID = '{0}',USERDate = GETDATE() where CLBH = '{1}' and CGNO = '{2}'", userid, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), cgnos1);
                                    Console.WriteLine(sql5ss);
                                    SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                                    con5ss.OpenConnection();
                                    int result5ss = cmd5ss.ExecuteNonQuery();
                                    if (result5ss == 1)
                                    {
                                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con5ss.CloseConnection();
                                }
                                else
                                {
                                    //取資料YPZLZLS1
                                    string sclsl = "0", sqty = "0";
                                    DBconnect dbConnBJ = new DBconnect();
                                    string sqlBJ = string.Format("select CLSL,QTY from YPZLZLS1 where YPZLBH = '{0}' and CLBH = '{1}' and CSBH = '{2}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim());
                                    SqlCommand cmdBJ = new SqlCommand(sqlBJ, dbConnBJ.connection);
                                    Console.WriteLine(sqlBJ);
                                    dbConnBJ.OpenConnection();
                                    SqlDataReader readerBJ = cmdBJ.ExecuteReader();
                                    if (readerBJ.Read()) //有資料
                                    {
                                        sclsl = readerBJ["CLSL"].ToString();
                                        sqty = readerBJ["QTY"].ToString();
                                    }
                                    dbConnBJ.CloseConnection();

                                    string cgnos1 = "";
                                    DBconnect dbConnBJ2 = new DBconnect();
                                    string sqlBJ2 = string.Format("select CGNO from CGZL where ZSBH = '{0}' and ZLBH = '{1}'", ds3B2.Tables[0].Rows[i][0].ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                                    SqlCommand cmdBJ2 = new SqlCommand(sqlBJ2, dbConnBJ2.connection);
                                    Console.WriteLine(sqlBJ2);
                                    dbConnBJ2.OpenConnection();
                                    SqlDataReader readerBJ2 = cmdBJ2.ExecuteReader();
                                    if (readerBJ2.Read()) //有資料
                                    {
                                        cgnos1 = readerBJ2["CGNO"].ToString();
                                    }
                                    dbConnBJ2.CloseConnection();

                                    ////扣除CGZLS
                                    ////update CGZLS
                                    //DBconnect con5ss = new DBconnect();
                                    //StringBuilder sql5ss = new StringBuilder();
                                    //sql5ss.AppendFormat("update CGZLS set YN = '1',XqQty = XqQty - '{0}' , Qty = Qty - '{1}',USERID = '{2}', USERDate = GETDATE() where CLBH = '{3}' and CGNO = '{4}'", dataGridView4.Rows[i].Cells[5].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[5].Value.ToString().Trim(), userID, dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), cgnos1);
                                    //Console.WriteLine(sql5ss);
                                    //SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                                    //con5ss.OpenConnection();
                                    //int result5ss = cmd5ss.ExecuteNonQuery();
                                    //if (result5ss == 1)
                                    //{
                                    //    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //}
                                    //con5ss.CloseConnection();
                                }
                            }

                            #endregion

                            #endregion

                            int result9s;
                            DBconnect conn9s = new DBconnect();
                            string sql9s = string.Format("INSERT INTO CGZLSS (GSBH,CGNO,CLBH,ZLBH,XXCC,Qty,CLSL,YQDate,USERDate,USERID,YN,STAGE,CKBH) (SELECT 'LTY' as GSBH, b.CGNO, a.CLBH, c.YPDH, a.SIZE, sum(isnull(a.QTY, 0)) as QTY, sum(isnull(a.CLSL, 0)) as CLSL, GETDATE() as YQDate, GETDATE() as USERDate, '{0}' as USERID, '1' as YN, '' as STAGE, '' as CKBH FROM YPZLZLS2 as a LEFT JOIN CGZL as b on a.YPZLBH = b.ZLBH and a.CSBH = b.ZSBH left join YPZLZLS as c on a.YPZLBH = c.YPZLBH where a.YPZLBH = '{1}' and a.CSBH != '' group by b.CGNO, a.CLBH, c.YPDH, a.SIZE)", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                            Console.WriteLine(sql9s);
                            SqlCommand cmd9s = new SqlCommand(sql9s, conn9s.connection);
                            conn9s.OpenConnection();
                            result9s = cmd9s.ExecuteNonQuery();
                            if (result9s == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn9s.CloseConnection();

                            #region CGZLSS
                            //string ssypdh = "",sssize = "",ssusage = "",ssclbh = "",sscsbh = "",ssclsl = "",ssqty = "",ssgsbh = "",ssckbh = "";
                            //DBconnect dbConnBJ2s = new DBconnect();
                            //string sqlBJ2s = string.Format("select YPDH,CSBH,CLBH,SIZE,CLSL,QTY,USAGE,GSBH,CKBH from YPZLZLS2 where YPZLBH = '{0}' and CLBH = '{1}' and CSBH = '{2}'", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView4.Rows[i].Cells[3].Value.ToString().Trim());
                            //SqlCommand cmdBJ2s = new SqlCommand(sqlBJ2s, dbConnBJ2s.connection);
                            //Console.WriteLine(sqlBJ2s);
                            //dbConnBJ2s.OpenConnection();
                            //SqlDataReader readerBJ2s = cmdBJ2s.ExecuteReader();
                            //if (readerBJ2s.Read()) //有資料
                            //{
                            //    ssypdh = readerBJ2s["YPDH"].ToString();
                            //    sssize = readerBJ2s["SIZE"].ToString();
                            //    ssusage = readerBJ2s["USAGE"].ToString();
                            //    ssclbh = readerBJ2s["CLBH"].ToString();
                            //    sscsbh = readerBJ2s["YPDH"].ToString();
                            //    ssclsl = readerBJ2s["CLSL"].ToString();
                            //    ssqty = readerBJ2s["QTY"].ToString();
                            //    ssgsbh = readerBJ2s["GSBH"].ToString();
                            //    ssckbh = readerBJ2s["CKBH"].ToString();
                            //}
                            //dbConnBJ2s.CloseConnection();
                            //Console.WriteLine(maxCG4);
                            //if (maxCG4 == 0) //old cgno 
                            //{
                            //    //insert CGZLSS   
                            //    int result9s;
                            //    DBconnect conn9s = new DBconnect();
                            //    string sql9s = string.Format("insert into CGZLSS (GSBH,CGNO,CLBH,ZLBH,XXCC,Qty,CLSL,YQDate,USERDate,USERID,YN,STAGE,CKBH) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','',GETDATE(),'{7}','1','','{8}') ", ssgsbh, cgdelete, ssclbh, sscsbh, sssize, ssqty, ssclsl, userID, ssckbh);
                            //    Console.WriteLine(sql9s);
                            //    SqlCommand cmd9s = new SqlCommand(sql9s, conn9s.connection);
                            //    conn9s.OpenConnection();
                            //    result9s = cmd9s.ExecuteNonQuery();
                            //    if (result9s == 1)
                            //    {
                            //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //    conn9s.CloseConnection();
                            //}
                            //else //新CGNO
                            //{
                            //    //insert CGZLSS   
                            //    int result9s;
                            //    DBconnect conn9s = new DBconnect();
                            //    string sql9s = string.Format("insert into CGZLSS (GSBH,CGNO,CLBH,ZLBH,XXCC,Qty,CLSL,YQDate,USERDate,USERID,YN,STAGE,CKBH) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','',GETDATE(),'{7}','1','','{8}') ", ssgsbh, maxCG4, ssclbh, sscsbh, sssize, ssqty, ssclsl, userID, ssckbh);
                            //    Console.WriteLine(sql9s);
                            //    SqlCommand cmd9s = new SqlCommand(sql9s, conn9s.connection);
                            //    conn9s.OpenConnection();
                            //    result9s = cmd9s.ExecuteNonQuery();
                            //    if (result9s == 1)
                            //    {
                            //        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //    conn9s.CloseConnection();

                            //    maxCG4 = 0;
                            //}
                            #endregion
                        }


                        #endregion



                    }
                    
                }
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { }
        }





        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex].Name == "Column6")
            {
                dataGridView3.CurrentCell.Value = ((DateTimePicker)sender).Value.ToString("yyyy/MM/dd");
            }
        }


        private void dataGridView3_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentCell.ColumnIndex < 0) return;
                Control parentCTL = e.Control.Parent;

                if ((dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex].Name == "Column6") || (dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex].Name == "Column11"))
                {
                    DateTimePicker dtPicker = new DateTimePicker();
                    dtPicker.Name = "dateTimePicker1";
                    dtPicker.Size = dataGridView3.CurrentCell.Size;
                    if (dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex].Name == "Column6")
                    {
                        dtPicker.CustomFormat = "yyyy/MM/dd";
                    }
                    else if (dataGridView3.Columns[dataGridView3.CurrentCell.ColumnIndex].Name == "Column11")
                    {
                        dtPicker.CustomFormat = "yyyy-MM-dd";
                    }


                    dtPicker.Format = DateTimePickerFormat.Custom;
                    dtPicker.Location = new Point(e.Control.Location.X - e.Control.Margin.Left < 0 ? 0 : e.Control.Location.X - e.Control.Margin.Left, e.Control.Location.Y - e.Control.Margin.Top < 0 ? 0 : e.Control.Location.Y - e.Control.Margin.Top);
                    Console.WriteLine(e.Control.Text);
                    if (e.Control.Text != "")
                    {
                        dtPicker.Value = DateTime.ParseExact(e.Control.Text, dtPicker.CustomFormat, null);
                    }
                    e.Control.Visible = false;

                    foreach (Control tmpCTL in parentCTL.Controls)
                    {
                        if (tmpCTL.Name == dtPicker.Name) parentCTL.Controls.Remove(tmpCTL);
                    }
                    parentCTL.Controls.Add(dtPicker);

                    dtPicker.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                }
                else
                {
                    foreach (Control tmpCTL in parentCTL.Controls)
                    {
                        if (tmpCTL.Name == "dateTimePicker1") parentCTL.Controls.Remove(tmpCTL);
                    }
                }
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tsbQuery.Enabled = true;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    comboBox2.Enabled = false;
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        LoadCgzl();

                        textBox1.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                        textBox2.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
                        textBox3.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                        comboBox2.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                        textBox5.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();

                        Supplier();
                    }
                    else
                    {
                        MessageBox.Show("先查詢樣品單");
                        tabControl1.SelectedTab = tabPage1;
                        tsbQuery.Enabled = true;
                        tsbClear.Enabled = false;
                        tsbInsert.Enabled = true;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                    }


                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    if (dataGridView2.Rows.Count > 0)
                    {
                        LoadCgzls();

                        //dataGridView3.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                        textBox6.Text = textBox1.Text;
                        textBox7.Text = textBox5.Text;
                        textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                        dataGridView3.Columns[5].DefaultCellStyle.BackColor = Color.Aqua;
                        dataGridView3.Columns[0].Width = 150;
                        dataGridView3.Columns[1].Width = 150;


                    }
                    else
                    {
                        MessageBox.Show("缺少採購單單頭");
                        tabControl1.SelectedTab = tabPage2;
                        comboBox2.Enabled = false;
                        tsbQuery.Enabled = true;
                        tsbClear.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                    }

                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    if (checkBox3.Checked == true) //未選廠商
                    {
                        YPZLZLS21();
                    }
                    else
                    {
                        YPZLZLS22();
                    }

                }
            }
            catch (Exception) { }
        }





        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
                switch (dataGridView3.Columns[e.ColumnIndex].Name)
                {
                    case "Column1":
                    case "Column2":
                    case "Column3":
                    case "Column4":
                    case "Column5":
                    case "Column6":
                        dataGridView3.BeginEdit(true);
                        break;
                    case "Column7":
                    case "Column8":
                    case "Column9":
                    case "Column10":
                    case "Column11":
                    case "Column12":
                    case "Column13":
                    case "Column14":
                    case "Column15":
                    default:
                        dataGridView3.EndEdit();
                        break;
                }
            }
            catch (Exception) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string date = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CONVERT(varchar, DATEADD(day,isnull(leadtime,0),getdate()), 111) as leadtime from supplier_list where cldh = '{0}' and zsdh = '{1}'", dataGridView3.CurrentRow.Cells[0].Value.ToString().Trim(), dataGridView2.CurrentRow.Cells[1].Value.ToString().Trim());
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read()) //有資料
                {
                    date = reader2["leadtime"].ToString();                    
                }
                dbConn2.CloseConnection();
                Console.WriteLine(date);

                dataGridView3.CurrentRow.Cells[5].Value = date;

                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;

                dataGridView3.ReadOnly = false;
            }
            catch (Exception) { }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Enabled == true)
                {
                    int a = 0;
                    dataGridView2.CurrentRow.Cells[1].Value = comboBox2.Text;

                    //a = dataGridView2.CurrentRow.Index;
                    //Console.WriteLine(a);
                    //ds.Tables[0].Rows[a][1] = comboBox2.Text ;
                    //Console.WriteLine(ds.Tables[0].Rows[a][1]);
                    //Console.WriteLine(ds.Tables[0].Rows[a].RowState.ToString());
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;

                double u = 0.0,v = 0.0;
                double q = 0.0, w = 0.0;
                CGBJ Form = new CGBJ();
                Form.zsbh = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                Form.clbh = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                Form.ShowDialog();
                u = double.Parse(Form.US);
                v = double.Parse(Form.VN);
                dataGridView3.CurrentRow.Cells[6].Value = u;
                dataGridView3.CurrentRow.Cells[7].Value = v;

                q = double.Parse(dataGridView3.CurrentRow.Cells[4].Value.ToString());

                dataGridView3.CurrentRow.Cells[8].Value = u * q;
                dataGridView3.CurrentRow.Cells[9].Value = v * q;
            }
            catch (Exception) { }
        }



        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            Supplier();

            comboBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //開啟品牌選擇
            if (checkBox2.Checked == true)
            {
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
            }
        }
    }
}
