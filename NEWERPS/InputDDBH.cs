using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;

namespace NEWERPS
{
    public partial class InputDDBH : Form
    {
        public InputDDBH()
        {
            InitializeComponent();
        }

        #region 變數

        DataTableCollection tableCollection;
        public string userid = "";
        string cddbh = "";
        int rowscount = 0;
        #endregion

        #region 方法

        private void DDBH()
        {
            try
            {
                int count = 0;
                int rowscount = 0;
                rowscount = dgvInput.Rows.Count;

                for (int i = 1; i < rowscount; i++)
                {
                    OrderCheck oc = new OrderCheck();

                    if (oc.check(dgvInput.Rows[i].Cells[0].Value.ToString().Trim()) == true)
                    {

                        count++;
                        Console.WriteLine("計算" + count);
                        //dgvInput.Rows[i].Cells[0].Value = "";

                        #region 插入訂單號

                        string dybh = "", year = "", day = "", max = "", area = "";

                        //取出
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select dybh,datepart(yy,GETDATE()) as year,datepart(mm, GETDATE()) as month from kfzl where kfdh = '{0}'", dgvInput.Rows[i].Cells[9].Value.ToString().Trim());
                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            dybh = reader["dybh"].ToString();
                            year = reader["year"].ToString();
                            day = reader["month"].ToString();
                        }
                        dbConn.CloseConnection();
                        Console.WriteLine(dybh);
                        Console.WriteLine(year);
                        Console.WriteLine(day);


                        string article = "";
                        string she = "";
                        she = dgvInput.Rows[i].Cells[5].Value.ToString().Trim();
                        if (she.Length == 1)
                        {
                            she = "0" + dgvInput.Rows[i].Cells[5].Value.ToString().Trim();
                        }
                        //she = "0" + dgvInput.Rows[i].Cells[5].Value.ToString().Trim();
                        //取出
                        DBconnect dbConnA = new DBconnect();
                        string sqlA = string.Format("select ARTICLE from xxzl where XieXing = '{0}' and SheHao = '{1}'", dgvInput.Rows[i].Cells[4].Value.ToString().Trim(), she);
                        Console.WriteLine(sqlA);
                        SqlCommand cmdA = new SqlCommand(sqlA, dbConnA.connection);
                        dbConnA.OpenConnection();
                        SqlDataReader readerA = cmdA.ExecuteReader();
                        if (readerA.Read())
                        {
                            article = readerA["ARTICLE"].ToString();
                        }
                        dbConnA.CloseConnection();

                        dgvInput.Rows[i].Cells[7].Value = article;

                        if (dgvInput.Rows[i].Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("Customer Code Empty");

                            rowscount = dgvInput.Rows.Count;
                            for (int j = 1; j < rowscount; j++)
                            {
                                if (dgvInput.Rows[j].Cells[0].Value.ToString().Trim() != "")
                                {
                                    //刪除資料
                                    DBconnect con4 = new DBconnect();
                                    StringBuilder sql4 = new StringBuilder();
                                    sql4.AppendFormat("delete ddzl where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql4);
                                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                    con4.OpenConnection();
                                    int result4 = cmd4.ExecuteNonQuery();
                                    if (result4 == 1)
                                    {
                                    }
                                    con4.CloseConnection();

                                    DBconnect con5 = new DBconnect();
                                    StringBuilder sql5 = new StringBuilder();
                                    sql5.AppendFormat("delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql5);
                                    SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                                    con5.OpenConnection();
                                    int result5 = cmd5.ExecuteNonQuery();
                                    if (result5 == 1)
                                    {

                                    }
                                    con5.CloseConnection();

                                    #region LYSHOE

                                    DBconnect2 con5Y = new DBconnect2();
                                    StringBuilder sql5Y = new StringBuilder();
                                    sql5Y.AppendFormat("delete ddzl where DDBH = '{0}' delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql5Y);
                                    SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                                    con5Y.OpenConnection();
                                    int result5Y = cmd5Y.ExecuteNonQuery();
                                    if (result5Y == 1)
                                    {
                                    }
                                    con5Y.CloseConnection();

                                    #endregion
                                }
                            }
                            MessageBox.Show("Film Error, Data Delete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;

                        }
                        else
                        {
                            if (dybh.Length == 2)
                            {
                                //string.Format("{0:D}", dt);
                                //Console.WriteLine(string.Format("{0:D}", dgvInput.Rows[i].Cells[23].Value.ToString().Trim()));
                                DateTime dt = DateTime.Parse(string.Format("{0:d}", dgvInput.Rows[i].Cells[23].Value.ToString().Trim()));
                                Console.WriteLine(dt);
                                dt = dt.AddDays(-14); //減少天
                                                      //dt = dt.ToString("yyyy/MM/dd");
                                Console.WriteLine(dt);

                                year = dt.ToString("yyyy/MM/dd").Substring(2, 2);
                                day = dt.ToString("yyyy/MM/dd").Substring(5, 2);

                                Console.WriteLine(year);
                                Console.WriteLine(day);
                                if (day.Substring(1, 1) == "/")
                                {
                                    day = "0" + day.Substring(0, 1);
                                }
                                Console.WriteLine(day);


                                area = dgvInput.Rows[i].Cells[2].Value.ToString().Trim();


                                cddbh = area + dybh + dgvInput.Rows[i].Cells[1].Value.ToString().Trim() + year + day + dgvInput.Rows[i].Cells[14].Value.ToString().Trim();

                                Console.WriteLine(cddbh);

                                //取出最大值
                                DBconnect dbConn1 = new DBconnect();
                                string sql1 = string.Format("select max(substring(DDBH,11,3)) as a from DDZL where SUBSTRING(DDBH, 1, 9) = '{0}'", cddbh);
                                Console.WriteLine(sql1);
                                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                                dbConn1.OpenConnection();
                                SqlDataReader reader1 = cmd1.ExecuteReader();
                                if (reader1.Read())
                                {
                                    max = reader1["a"].ToString();
                                }
                                Console.WriteLine(max);
                                dbConn1.CloseConnection();

                                if (max == "") //沒有資料帶001 
                                {
                                    cddbh = cddbh + "-" + "001";
                                }
                                else
                                {
                                    int z = 0;
                                    z = int.Parse(max);
                                    z = z + 1;
                                    max = z.ToString();

                                    if (max.Length == 1)
                                    {
                                        max = "00" + max;
                                    }
                                    else if (max.Length == 2)
                                    {
                                        max = "0" + max;
                                    }

                                    cddbh = cddbh + "-" + max;
                                }

                                //dgvInput.Rows[i].Cells[0].Value = cddbh;


                                int ddbhexist = 0;
                                DBconnect dbConnme = new DBconnect();
                                string sqlme = string.Format("select count(DDBH) as count from DDZL where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                                SqlCommand cmdme = new SqlCommand(sqlme, dbConnme.connection);
                                dbConnme.OpenConnection();
                                SqlDataReader readerme = cmdme.ExecuteReader();
                                if (readerme.Read())
                                {
                                    ddbhexist = int.Parse(readerme["count"].ToString());
                                }
                                dbConnme.CloseConnection();

                                if (ddbhexist == 0)
                                {
                                    #region 插入DDZL
                                    Console.WriteLine(dgvInput.Rows[i].Cells[19].Value.ToString().Trim());
                                    Console.WriteLine(dgvInput.Rows[i].Cells[23].Value.ToString().Trim());
                                    Console.WriteLine(dgvInput.Rows[i].Cells[24].Value.ToString().Trim());
                                    DateTime dtA = DateTime.Parse(string.Format("{0:d}", dgvInput.Rows[i].Cells[19].Value.ToString().Trim()));
                                    DateTime dtB = DateTime.Parse(string.Format("{0:d}", dgvInput.Rows[i].Cells[23].Value.ToString().Trim()));
                                    DateTime dtC = DateTime.Parse(string.Format("{0:d}", dgvInput.Rows[i].Cells[24].Value.ToString().Trim()));
                                    string getdate = "", FTD = "", XTD = "";
                                    getdate = dtA.ToString("yyyy/MM/dd");
                                    FTD = dtB.ToString("yyyy/MM/dd");
                                    XTD = dtC.ToString("yyyy/MM/dd");

                                    string color = "";
                                    color = dgvInput.Rows[i].Cells[5].Value.ToString().Trim();
                                    if (color.Length == 1)
                                    {
                                        color = "0" + color;
                                    }
                                    //dgvInput.Rows[i].Cells[5].Value = "'"+ color + "'";
                                    //MAX VER
                                    string maxver = "";
                                    //取出最大值                    
                                    DBconnect dbConnm = new DBconnect();
                                    string sqlm = string.Format("select isnull(MAX(VER),1) as ver from xxzls where XieXing = '{0}' and SheHao = '{1}'", dgvInput.Rows[i].Cells[4].Value.ToString().Trim(), color);
                                    SqlCommand cmdm = new SqlCommand(sqlm, dbConnm.connection);
                                    dbConnm.OpenConnection();
                                    SqlDataReader readerm = cmdm.ExecuteReader();
                                    if (readerm.Read())
                                    {
                                        maxver = readerm["ver"].ToString();
                                    }
                                    dbConnm.CloseConnection();
                                    maxver = "1"; //BOM上線取出
                                    dgvInput.Rows[i].Cells[6].Value = maxver;

                                    //insert
                                    #region NEWERP

                                    //dest
                                    Console.WriteLine(dgvInput.Rows[i].Cells[17].Value.ToString().Trim());
                                    string dest = "";
                                    dest = dgvInput.Rows[i].Cells[17].Value.ToString().Trim();
                                    if (dest.Length == 1)
                                    {
                                        dest = "000" + dest;
                                    }
                                    else if (dest.Length == 2)
                                    {
                                        dest = "00" + dest;
                                    }
                                    else if (dest.Length == 3)
                                    {
                                        dest = "0" + dest;
                                    }
                                    //dest = (dest.Length <= 2) ? "00" + dest : dest;

                                    Console.WriteLine(dest);

                                    string country = "";
                                    country = dgvInput.Rows[i].Cells[18].Value.ToString().Trim();
                                    if (country.Length == 1)
                                    {
                                        country = "00" + country;
                                    }

                                    //pairs
                                    int pairs = 0;
                                    for (int z = 49; z < dgvInput.Columns.Count; z++)
                                    {
                                        if (dgvInput.Rows[i].Cells[z].Value.ToString().Trim() != "-")
                                        {
                                            pairs += int.Parse(dgvInput.Rows[i].Cells[z].Value.ToString().Trim());
                                        }
                                    }

                                    Console.WriteLine(pairs);
                                    Console.WriteLine(dgvInput.Rows[i].Cells[25].Value.ToString().Trim());

                                    int result2;
                                    DBconnect conn2 = new DBconnect();
                                    string sql2 = string.Format("insert into DDZL (DDBH, DDZT, XieXing, SheHao, Version, ARTICLE, CCGB, KHBH, BB, KHPO, Trader, TraderPO, DDLB, CPLB, BZFS, Dest, DDGB, DDRQ, MDDBH, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, USERID, USERDATE, DDCZ, DDPACKSM, LABELCHARGE, Gender, SC01, SC02, PUMAPO, Pairs1, balance, mtyf, BUYNO, YN, Pairs2, balance2, KFJD, RYTYPE,  FinishedDay, UsageVer) values ('{0}', '{1}', '{2}', '{3}', '{41}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}','{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', 'LIN', 'ZZZZZZZZZZZZZZZZZZZZ', '{24}', CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) , '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}' , '{36}' , '{37}', '{38}', 'zzz','{39}', '{40}', '1')", dgvInput.Rows[i].Cells[0].Value.ToString().Trim(), dgvInput.Rows[i].Cells[3].Value.ToString().Trim(), dgvInput.Rows[i].Cells[4].Value.ToString().Trim(), color, dgvInput.Rows[i].Cells[7].Value.ToString().Trim(), dgvInput.Rows[i].Cells[8].Value.ToString().Trim(), dgvInput.Rows[i].Cells[9].Value.ToString().Trim(), dgvInput.Rows[i].Cells[10].Value.ToString().Trim(), dgvInput.Rows[i].Cells[11].Value.ToString().Trim(), dgvInput.Rows[i].Cells[12].Value.ToString().Trim(), dgvInput.Rows[i].Cells[13].Value.ToString().Trim(), dgvInput.Rows[i].Cells[14].Value.ToString().Trim(), dgvInput.Rows[i].Cells[15].Value.ToString().Trim(), dgvInput.Rows[i].Cells[16].Value.ToString().Trim(), dest, country, getdate, dgvInput.Rows[i].Cells[20].Value.ToString().Trim(), dgvInput.Rows[i].Cells[21].Value.ToString().Trim(), dgvInput.Rows[i].Cells[22].Value.ToString().Trim(), XTD, pairs, dgvInput.Rows[i].Cells[26].Value.ToString().Trim(), dgvInput.Rows[i].Cells[27].Value.ToString().Trim(), userid, dgvInput.Rows[i].Cells[32].Value.ToString().Trim(), dgvInput.Rows[i].Cells[33].Value.ToString().Trim(), dgvInput.Rows[i].Cells[34].Value.ToString().Trim(), dgvInput.Rows[i].Cells[35].Value.ToString().Trim(), "N", dgvInput.Rows[i].Cells[37].Value.ToString().Trim(), dgvInput.Rows[i].Cells[38].Value.ToString().Trim(), dgvInput.Rows[i].Cells[39].Value.ToString().Trim(), dgvInput.Rows[i].Cells[40].Value.ToString().Trim(), dgvInput.Rows[i].Cells[42].Value.ToString().Trim(), dgvInput.Rows[i].Cells[43].Value.ToString().Trim(), dgvInput.Rows[i].Cells[44].Value.ToString().Trim(), dgvInput.Rows[i].Cells[45].Value.ToString().Trim(), dgvInput.Rows[i].Cells[46].Value.ToString().Trim(), dgvInput.Rows[i].Cells[48].Value.ToString().Trim(), FTD, maxver);

                                    Console.WriteLine(sql2);

                                    SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                                    conn2.OpenConnection();
                                    result2 = cmd2.ExecuteNonQuery();
                                    if (result2 == 1)
                                    {

                                    }
                                    conn2.CloseConnection();

                                    #endregion

                                    #region LYSHOE

                                    int result2Y;
                                    DBconnect2 conn2Y = new DBconnect2();
                                    string sql2Y = string.Format("delete DDZL where DDBH = '{0}' insert into DDZL select DDBH, XieXing, SheHao, ARTICLE, CCGB, KHBH, BB, KHPO, Version, Trader, TraderPO, DDLB, DDZT, CPLB, BZFS, Dest, DDGB, CAST(year(DDRQ) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(DDRQ) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(DDRQ) as NVARCHAR), 2), JYTJ, FKTJ,  CAST(year(ShipDate) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(ShipDate) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(ShipDate) as NVARCHAR), 2), Pairs, Totals, ZLBH, GSDH, CFNO, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) , DDCZ, DDPACKSM, LABELCHARGE, SC01, SC02,  PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, Pairs2, balance2, RYTYPE from [192.168.11.15].New_Erp.dbo.DDZL where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql2Y);
                                    SqlCommand cmd2Y = new SqlCommand(sql2Y, conn2Y.connection);
                                    conn2Y.OpenConnection();
                                    result2Y = cmd2Y.ExecuteNonQuery();
                                    if (result2Y == 1)
                                    {
                                    }
                                    conn2Y.CloseConnection();

                                    #endregion

                                    #endregion

                                    #region DDZLS

                                    int num = 0;
                                    string num2 = "";
                                    for (int z = 49; z < dgvInput.Columns.Count; z++)
                                    {
                                        num += 1;
                                        num2 = num.ToString();
                                        if (dgvInput.Rows[i].Cells[z].Value.ToString().Trim() != "-")
                                        {
                                            if (num2.Length == 1)
                                            {
                                                num2 = "0" + num2;
                                            }

                                            int result9;
                                            DBconnect conn9 = new DBconnect();
                                            string sql9 = string.Format("insert into DDZLs (DDBH, LineNum, CC, Quantity,Price,CPrice,IPrice,USERID,USERDATE,Quantity1,mtdj,Quantity2,TestQty) values ('{0}', '{1}','{2}', '{3}','0','0','0','{4}', CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) , '0','0','0', '0')", dgvInput.Rows[i].Cells[0].Value.ToString().Trim(), num2, dgvInput.Rows[0].Cells[z].Value.ToString().Trim(), dgvInput.Rows[i].Cells[z].Value.ToString().Trim(), userid);
                                            Console.WriteLine(sql9);

                                            SqlCommand cmd9 = new SqlCommand(sql9, conn9.connection);
                                            conn9.OpenConnection();
                                            result9 = cmd9.ExecuteNonQuery();
                                            if (result9 == 1)
                                            {

                                            }
                                            conn9.CloseConnection();
                                        }
                                    }

                                    #region LYSHOE

                                    int result9Y;
                                    DBconnect2 conn9Y = new DBconnect2();
                                    string sql9Y = string.Format("delete DDZLs where DDBH = '{0}' insert into ddzls SELECT[DDBH],[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID], CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) ,[Quantity1],[mtdj],[Quantity2],[TestQty] FROM [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                                    Console.WriteLine(sql9Y);

                                    SqlCommand cmd9Y = new SqlCommand(sql9Y, conn9Y.connection);
                                    conn9Y.OpenConnection();
                                    result9Y = cmd9Y.ExecuteNonQuery();
                                    if (result9Y == 1)
                                    {

                                    }
                                    conn9Y.CloseConnection();

                                    dgvInput.Rows[i].Cells[5].Value = "'" + color;

                                    #endregion

                                    #endregion

                                    dgvInput.Columns[0].Width = 200;
                                    //#region 插入DDZLS

                                    //int count = 0;
                                    //int l = 0; //第一碼
                                    //int m = 0; //最後碼

                                    //int k = 49;
                                    //while (k < dgvInput.Columns.Count)
                                    //{
                                    //    if (dgvInput.Rows[i].Cells[k].Value.ToString().Trim() != "-")
                                    //    {
                                    //        l = k;
                                    //        break;
                                    //    }
                                    //    k++;
                                    //}

                                    //int n = dgvInput.Columns.Count;
                                    //while (n > 49)
                                    //{
                                    //    Console.WriteLine(dgvInput.Rows[i].Cells[n - 1].Value.ToString().Trim());
                                    //    if (dgvInput.Rows[i].Cells[n - 1].Value.ToString().Trim() != "-")
                                    //    {
                                    //        m = n;
                                    //        break;
                                    //    }
                                    //    n--;
                                    //}

                                    //Console.WriteLine("max:" + m + " min:" + l);

                                    //for (int j = l; j < m; j++)
                                    //{

                                    //    count += 1;
                                    //    //Console.WriteLine(count);


                                    //    string linenum = "";
                                    //    linenum = count.ToString();
                                    //    if (linenum.Length == 1)
                                    //    {
                                    //        linenum = "0" + linenum;
                                    //    }
                                    //    Console.WriteLine(linenum);

                                    //    int result9;
                                    //    DBconnect conn9 = new DBconnect();
                                    //    string sql9 = string.Format("insert into DDZLs (DDBH, LineNum, CC, Quantity,Price,CPrice,IPrice,USERID,USERDATE,Quantity1,mtdj,YN,Quantity2,TestQty) values ('{0}', '{1}','{2}', '{3}','0','0','0','{4}', GETDATE(),'0','0','1','0', '0')", dgvInput.Rows[i].Cells[0].Value.ToString().Trim(), linenum, dgvInput.Rows[0].Cells[j].Value.ToString().Trim(), dgvInput.Rows[i].Cells[j].Value.ToString().Trim(), userid);
                                    //    Console.WriteLine(sql1);
                                    //    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                                    //    SqlCommand cmd9 = new SqlCommand(sql9, conn9.connection);
                                    //    conn9.OpenConnection();
                                    //    result9 = cmd9.ExecuteNonQuery();
                                    //    if (result9 == 1)
                                    //    {

                                    //    }
                                    //    conn9.CloseConnection();
                                    //}

                                    //#endregion
                                }
                                else
                                {
                                    MessageBox.Show("Same DDBH Exist");

                                    rowscount = dgvInput.Rows.Count;
                                    for (int j = 1; j < rowscount; j++)
                                    {
                                        if (dgvInput.Rows[j].Cells[0].Value.ToString().Trim() != "")
                                        {
                                            //刪除資料
                                            DBconnect con4 = new DBconnect();
                                            StringBuilder sql4 = new StringBuilder();
                                            sql4.AppendFormat("delete ddzl where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                            Console.WriteLine(sql4);
                                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                            con4.OpenConnection();
                                            int result4 = cmd4.ExecuteNonQuery();
                                            if (result4 == 1)
                                            {
                                            }
                                            con4.CloseConnection();

                                            DBconnect con5 = new DBconnect();
                                            StringBuilder sql5 = new StringBuilder();
                                            sql5.AppendFormat("delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                            Console.WriteLine(sql5);
                                            SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                                            con5.OpenConnection();
                                            int result5 = cmd5.ExecuteNonQuery();
                                            if (result5 == 1)
                                            {

                                            }
                                            con5.CloseConnection();

                                            #region LYSHOE

                                            DBconnect2 con5Y = new DBconnect2();
                                            StringBuilder sql5Y = new StringBuilder();
                                            sql5Y.AppendFormat("delete ddzl where DDBH = '{0}' delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                            Console.WriteLine(sql5Y);
                                            SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                                            con5Y.OpenConnection();
                                            int result5Y = cmd5Y.ExecuteNonQuery();
                                            if (result5Y == 1)
                                            {
                                            }
                                            con5Y.CloseConnection();

                                            #endregion
                                        }
                                    }
                                    MessageBox.Show("Film Error, Data Delete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Customer Code Over Size");

                                rowscount = dgvInput.Rows.Count;
                                for (int j = 1; j < rowscount; j++)
                                {
                                    if (dgvInput.Rows[j].Cells[0].Value.ToString().Trim() != "")
                                    {
                                        //刪除資料
                                        DBconnect con4 = new DBconnect();
                                        StringBuilder sql4 = new StringBuilder();
                                        sql4.AppendFormat("delete ddzl where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                        Console.WriteLine(sql4);
                                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                        con4.OpenConnection();
                                        int result4 = cmd4.ExecuteNonQuery();
                                        if (result4 == 1)
                                        {
                                        }
                                        con4.CloseConnection();

                                        DBconnect con5 = new DBconnect();
                                        StringBuilder sql5 = new StringBuilder();
                                        sql5.AppendFormat("delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                        Console.WriteLine(sql5);
                                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                                        con5.OpenConnection();
                                        int result5 = cmd5.ExecuteNonQuery();
                                        if (result5 == 1)
                                        {

                                        }
                                        con5.CloseConnection();

                                        #region LYSHOE

                                        DBconnect2 con5Y = new DBconnect2();
                                        StringBuilder sql5Y = new StringBuilder();
                                        sql5Y.AppendFormat("delete ddzl where DDBH = '{0}' delete ddzls where DDBH = '{0}'", dgvInput.Rows[j].Cells[0].Value.ToString().Trim());
                                        Console.WriteLine(sql5Y);
                                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                                        con5Y.OpenConnection();
                                        int result5Y = cmd5Y.ExecuteNonQuery();
                                        if (result5Y == 1)
                                        {
                                        }
                                        con5Y.CloseConnection();

                                        #endregion
                                    }
                                }
                                MessageBox.Show("Film Error, Data Delete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                break;

                            }
                        }
                        #endregion

                    }
                    else
                    {
                        MessageBox.Show("DDBH Error");
                        int rowcount2 = 0;
                        rowcount2 = dgvInput.Rows.Count;
                        for (int k = 1; k < rowcount2; k++)
                        {
                            if (dgvInput.Rows[k].Cells[0].Value.ToString().Trim() != "")
                            {
                                //刪除資料
                                DBconnect con4 = new DBconnect();
                                StringBuilder sql4 = new StringBuilder();
                                sql4.AppendFormat("delete ddzl where DDBH = '{0}'", dgvInput.Rows[k].Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql4);
                                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                con4.OpenConnection();
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                }
                                con4.CloseConnection();

                                DBconnect con5 = new DBconnect();
                                StringBuilder sql5 = new StringBuilder();
                                sql5.AppendFormat("delete ddzls where DDBH = '{0}'", dgvInput.Rows[k].Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql5);
                                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                                con5.OpenConnection();
                                int result5 = cmd5.ExecuteNonQuery();
                                if (result5 == 1)
                                {

                                }
                                con5.CloseConnection();

                                #region LYSHOE

                                DBconnect2 con5Y = new DBconnect2();
                                StringBuilder sql5Y = new StringBuilder();
                                sql5Y.AppendFormat("delete ddzl where DDBH = '{0}' delete ddzls where DDBH = '{0}'", dgvInput.Rows[k].Cells[0].Value.ToString().Trim());
                                Console.WriteLine(sql5Y);
                                SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                                con5Y.OpenConnection();
                                int result5Y = cmd5Y.ExecuteNonQuery();
                                if (result5Y == 1)
                                {
                                }
                                con5Y.CloseConnection();

                                #endregion
                            }
                        }
                        MessageBox.Show("Film Error, Data Delete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        button2.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                int rowscount = 0;
                rowscount = dgvInput.Rows.Count;
                for (int i = 1; i < rowscount; i++)
                {
                    if (dgvInput.Rows[i].Cells[0].Value.ToString().Trim() != "")
                    {
                        //刪除資料
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete ddzl where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                        }
                        con4.CloseConnection();

                        DBconnect con5 = new DBconnect();
                        StringBuilder sql5 = new StringBuilder();
                        sql5.AppendFormat("delete ddzls where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {

                        }
                        con5.CloseConnection();

                        #region LYSHOE

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("delete ddzl where DDBH = '{0}' delete ddzls where DDBH = '{0}'", dgvInput.Rows[i].Cells[0].Value.ToString().Trim());
                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {
                        }
                        con5Y.CloseConnection();

                        #endregion
                    }
                }
                MessageBox.Show("Film Error, Data Delete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button2.Enabled = false;
            }
        }

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                         //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                         //   {  
                                                         //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                         //      rg.NumberFormat = "00000000";  
                                                         //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("导出文件成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("报表为空,无表格需要导出", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        #endregion

        #region 事件

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtFilename.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cboSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cboSheet.Items.Add(table.TableName);//add sheet to combobox
                            }
                        }
                    }
                }

                button2.Enabled = true;
            }
            catch(Exception)
            {
                MessageBox.Show("File Open Error.開啟檔案路徑失敗");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInput.Rows.Count == 0)
                {
                    DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                    dgvInput.DataSource = dt;
                    DDBH();
                    dgvInput.Columns[0].Width = 150;
                }
                else 
                {
                    MessageBox.Show("Data Already Insert.資料已插入");
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Load Data Fail.載入資料失敗");
            }            
        }

        private void InputDDBH_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //倒出文件
                ExportExcel("SalesOrder", dgvInput);
                this.Close();
            }
            catch (Exception) 
            {                
            }
        }
        #endregion
    }
}
