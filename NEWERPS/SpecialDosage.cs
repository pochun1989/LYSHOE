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
    public partial class SpecialDosage : Form
    {
        public SpecialDosage()
        {
            InitializeComponent();
        }

        #region 畫面載入

        private void SpecialDosage_Load(object sender, EventArgs e) 
        {
            try
            {
                userid = Program.User.userID;

                combobox();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
                //ChangeTabControl();

                DBconnect dbconn2 = new DBconnect();
                string sql12 = "select * from bwzl";
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsc1, "倉庫");

                comboBox2.DataSource = dsc1.Tables[0];
                comboBox2.ValueMember = "bwdh";
                comboBox2.DisplayMember = "bwdh";
                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion



        #region 變數

        public string userid = "";
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsL3 = new DataSet();
        DataSet dsL2 = new DataSet();
        DataSet dsL9 = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        int sl = 0;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "SpecialDosage";

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
                L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
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

        private void combobox()
        {
            try
            {
                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select kfdh from kfzl";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                comboBox1.DataSource = dsc3.Tables[0];
                comboBox1.ValueMember = "kfdh";
                comboBox1.DisplayMember = "kfdh";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {

                try
                {
                    dsL9 = new DataSet();
                    DBconnect dbConnL = new DBconnect();
                    string sqlL = string.Format("select DDBH,XieXing,SheHao,ARTICLE,KHBH,KHPO,Version,ShipDate,Pairs,ZLBH from ddzl where zlbh is not null and ddbh like '%{0}%' and khbh = '{1}' and ShipDate BETWEEN DATEADD(DAY, 0, '{2}') and DATEADD(DAY, 1, '{3}') and ddzt = 'Y' and(DDLB = 'N' or DDZT = 'F')", textBox1.Text, comboBox1.SelectedValue, dateTimePicker2.Text, dateTimePicker1.Text);
                    Console.WriteLine(sqlL);
                    SqlDataAdapter adapterL9 = new SqlDataAdapter(sqlL, dbConnL.connection);
                    adapterL9.Fill(dsL9, "棧板表");
                    dataGridView1.DataSource = dsL9.Tables[0];
                }
                catch (Exception) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                for (int j = 0; j < dataGridView1.Rows.Count; j ++)
                {
                    Console.WriteLine(Convert.ToBoolean(dataGridView1.Rows[j].Cells[0].Value));
                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[0].Value))
                    {
                        int ver = 0;
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select isnull(MAX(VER),0)+1 as ver from zlzls2 where ZLBH = '{0}'", dataGridView1.Rows[j].Cells[1].Value.ToString());
                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ver = int.Parse(reader["ver"].ToString());
                        }
                        dbConn.CloseConnection();

                        //檢查xxzlss
                        int c2 = 0;
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select count(XieXing) as count from xxzlss where XieXing = '{0}' and SheHao = '{1}'", dataGridView1.Rows[j].Cells[2].Value.ToString(), dataGridView1.Rows[j].Cells[3].Value.ToString());
                        Console.WriteLine(sql2);
                        SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                        dbConn2.OpenConnection();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            c2 = int.Parse(reader2["count"].ToString());
                        }
                        dbConn2.CloseConnection();

                        if (c2 == 0) //沒有資料
                        {
                            MessageBox.Show("請先建立資料");
                            tabControl1.SelectedTab = P0002;
                        }
                        else
                        {
                            //刪除ZLZLS2
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete zlzls2 where ZLBH = '{0}' and xh = 'SPL' and YN = '1'", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate, yn, ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, DDZL.Pairs * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '{2}' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 1 UNION select DDZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, sum(DDZLs.Quantity * isnull(Usage_R.CLSL, 0)) as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '{2}' as ver from DDZLs left join DDZL on DDZL.DDBH = DDZLs.DDBH left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH left join Usage_R on ddzl.XieXing = Usage_R.XieXing and ddzl.SheHao = Usage_R.shehao and ddzls.cc = Usage_R.XTCC and xxzls.BWBH = Usage_R.BWBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 2 and Usage_R.clsl is not null group by DDZL.ZLBH, xxzlss.BWBH, xxzlss.CSBH, xxzlss.CLBH, xxzlss.CLSL, CLZL.CLZMLB", userid, dataGridView1.Rows[j].Cells[1].Value.ToString(), ver);
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            conn.CloseConnection();

                            int result2;
                            DBconnect conn2 = new DBconnect();
                            string sql12 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB , ddzls.CC as SIZE , DDZLs.Quantity * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID , getdate() as USERDATE, '1' as YN, '1' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ddzls on ddzls.ddbh = ddzl.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'Y' and ddzls.Quantity <> 0 ", userid, dataGridView1.Rows[j].Cells[1].Value.ToString(), ver);
                            Console.WriteLine(sql12);

                            SqlCommand cmd12 = new SqlCommand(sql12, conn2.connection);
                            conn2.OpenConnection();
                            result2 = cmd12.ExecuteNonQuery();
                            if (result2 == 1)
                            {

                            }
                            conn2.CloseConnection();

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete zlzls2 where zlbh = '{0}' and xh = 'SPL' insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate) (select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}' and xh = 'SPL')", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            Console.WriteLine(sql1Y);

                            SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                            connY.OpenConnection();
                            resultY = cmd1Y.ExecuteNonQuery();
                            if (resultY == 1)
                            {

                            }
                            connY.CloseConnection();

                            #endregion
                            #region OLD


                            //int c3 = 0;
                            //DBconnect dbConn3 = new DBconnect();
                            //string sql3 = string.Format("select COUNT(ZLBH) as count from zlzls2 where ZLBH = '{0}' and XH = 'VN'", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            //Console.WriteLine(sql3);
                            //SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                            //dbConn3.OpenConnection();
                            //SqlDataReader reader3 = cmd3.ExecuteReader();
                            //if (reader3.Read())
                            //{
                            //    c3 = int.Parse(reader3["count"].ToString());
                            //}
                            //dbConn3.CloseConnection();

                            //if (c3 == 0) //沒有資料 新增
                            //{
                            //    int result;
                            //    DBconnect conn = new DBconnect();
                            //    string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'VN' as XH, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity) * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '2' as YN, 1 as ver from xxzlss left join DDZL on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where zlZL.ZLBH = '{1}'", userid, dataGridView1.Rows[j].Cells[1].Value.ToString());
                            //    Console.WriteLine(sql1);

                            //    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            //    conn.OpenConnection();
                            //    result = cmd1.ExecuteNonQuery();
                            //    if (result == 1)
                            //    {

                            //    }
                            //    conn.CloseConnection();
                            //}
                            //else //有舊資料
                            //{
                            //    int ver = 0;
                            //    double clsl = 0, usage = 0, count = 0;

                            //    //zlzls2 > xxzlsvn
                            //    ds2 = new DataSet();
                            //    DBconnect dbConnL = new DBconnect();
                            //    string sqlL = string.Format("select * from ZLZLS2 left join ddzl on ddzl.zlbh = zlzls2.zlbh left join xxzlss on xxzlss.xiexing = ddzl.xiexing and xxzlss.shehao = ddzl.shehao and xxzlss.CLBH = ZLZLS2.CLBH where ZLZLS2.ZLBH = '{0}' and XH = 'VN' and xxzlss.userdate > zlzls2.userdate ", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            //    Console.WriteLine(sqlL);
                            //    SqlDataAdapter adapterL9 = new SqlDataAdapter(sqlL, dbConnL.connection);
                            //    adapterL9.Fill(ds2, "棧板表");
                            //    dgvOldZlzls21.DataSource = ds2.Tables[0];

                            //    Console.WriteLine(dgvOldZlzls21.Rows.Count);
                            //    //插入舊資料版本
                            //    if (dgvOldZlzls21.Rows.Count > 0)
                            //    {
                            //        for (int i = 0; i < dgvOldZlzls21.Rows.Count; i++)
                            //        {
                            //            //取出版本
                            //            DBconnect dbConn1v = new DBconnect();
                            //            string sql1v = string.Format("select ver from zlzls2 where ZLBH = '{0}' and BWBH = '{1}' and CLBH = '{2}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                            //            Console.WriteLine(sql1v);
                            //            SqlCommand cmd1v = new SqlCommand(sql1v, dbConn1v.connection);
                            //            dbConn1v.OpenConnection();
                            //            SqlDataReader reader1v = cmd1v.ExecuteReader();
                            //            if (reader1v.Read())
                            //            {
                            //                ver = int.Parse(reader1v["ver"].ToString());
                            //            }
                            //            dbConn1v.CloseConnection();
                            //            Console.WriteLine(ver);

                            //            //取出數量
                            //            DBconnect dbConn5 = new DBconnect();
                            //            string sql5 = string.Format("select SUM(Quantity) as count from ddzls where DDBH = '{0}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString());
                            //            Console.WriteLine(sql5);
                            //            SqlCommand cmd5 = new SqlCommand(sql5, dbConn5.connection);
                            //            dbConn5.OpenConnection();
                            //            SqlDataReader reader5 = cmd5.ExecuteReader();
                            //            if (reader5.Read())
                            //            {
                            //                count = double.Parse(reader5["count"].ToString());
                            //            }
                            //            dbConn5.CloseConnection();
                            //            Console.WriteLine(count);

                            //            DBconnect dbConn6 = new DBconnect();
                            //            string sql6 = string.Format("select CLSL from xxzlss left join DDZL on xxzlss.XieXing = DDZL.XieXing and xxzlss.SheHao = DDZL.SheHao where DDBH = '{0}' and BWBH = '{1}' and CLBH = '{2}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                            //            Console.WriteLine(sql6);
                            //            SqlCommand cmd6 = new SqlCommand(sql6, dbConn6.connection);
                            //            dbConn6.OpenConnection();
                            //            SqlDataReader reader6 = cmd6.ExecuteReader();
                            //            if (reader6.Read())
                            //            {
                            //                usage = double.Parse(reader6["CLSL"].ToString());
                            //            }
                            //            dbConn6.CloseConnection();
                            //            Console.WriteLine(usage);

                            //            clsl = usage * count;
                            //            Console.WriteLine(clsl);

                            //            //新增資料

                            //            int result7;
                            //            DBconnect conn7 = new DBconnect();
                            //            string sql7 = string.Format("insert into zlzls2 select ZLBH,BWBH,CLBH,SIZE,YN,xh,CSBH,MJBH,ZMLB,'{0}' as CLSL,'{1}' as USAGE,'{2}' as USERID,GETDATE() as USERDATE,CLSL2,Usage2,Qbuy,QWin,Qwot,Udate,LTDBH,ver+1 as ver from zlzls2  where ZLBH = '{3}' and BWBH = '{4}' and CLBH = '{5}'", clsl, usage, userid, dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                            //            Console.WriteLine(sql7);
                            //            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                            //            SqlCommand cmd7 = new SqlCommand(sql7, conn7.connection);
                            //            conn7.OpenConnection();
                            //            result7 = cmd7.ExecuteNonQuery();
                            //            if (result7 == 1)
                            //            {

                            //            }
                            //            conn7.CloseConnection();

                            //            //修改為0
                            //            DBconnect con4 = new DBconnect();
                            //            StringBuilder sql4 = new StringBuilder();
                            //            sql4.AppendFormat("update zlzls2 set YN = 0 where ZLBH = '{0}' and BWBH = '{1}' and CLBH = '{2}' and ver = '{3}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString(), ver);
                            //            Console.WriteLine(sql4);
                            //            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            //            con4.OpenConnection();
                            //            int result4 = cmd4.ExecuteNonQuery();
                            //            if (result4 == 1)
                            //            {
                            //                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //            }



                            //        }
                            //    }

                            //    //插入剩餘資料
                            //    int result;
                            //    DBconnect conn = new DBconnect();
                            //    string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'VN' as XH, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity) * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '2' as YN, 1 as ver from xxzlss left join DDZL on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO  LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where zlZL.ZLBH = '{1}'", userid, dataGridView1.Rows[j].Cells[1].Value.ToString());
                            //    Console.WriteLine(sql1);

                            //    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            //    conn.OpenConnection();
                            //    result = cmd1.ExecuteNonQuery();
                            //    if (result == 1)
                            //    {

                            //    }
                            //    conn.CloseConnection();

                            //}
                            #endregion
                        }
                    }

                }
                MessageBox.Show("計算完成");
            }
            catch (Exception) { }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                a = dataGridView1.Rows.Count;

                if (L0005.Checked == true)
                {
                    for (int i = 0; i < a; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = 1;
                    }
                }
                else if (L0005.Checked == false)
                {
                    for (int i = 0; i < a; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = 0;
                    }
                }
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001) 
                {
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    string cond = "";
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select dest from ddzl where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        cond = reader1["dest"].ToString();
                    }
                    dbConn1.CloseConnection();

                    textBox5.Text = cond;

                    ds1 = new DataSet();
                    DBconnect dbConnL = new DBconnect();
                    string sqlL = string.Format("select * from xxzlss where xiexing='{0}' and shehao= '{1}' and cond= '{2}' and YN = '1'", textBox3.Text, textBox4.Text, cond);
                    Console.WriteLine(sqlL);
                    SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                    adapterL.Fill(ds1, "棧板表");
                    dataGridView3.DataSource = ds1.Tables[0];
                }

            }
            catch (Exception) { }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            try
            {
                SpeCLBH Form = new SpeCLBH();
                Form.ShowDialog();
                textBox7.Text = Form.cldh;
                textBox8.Text = Form.sup;
            }
            catch (Exception) { }
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            try
            {
                SpeCLBH Form = new SpeCLBH();
                Form.ShowDialog();
                textBox7.Text = Form.cldh;
                textBox8.Text = Form.sup;
            }
            catch (Exception) { }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                textBox7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text  = dataGridView3.CurrentRow.Cells[6].Value.ToString();
                textBox10.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception) { }
        }                    

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;

                sl = 1;
                if (tabControl1.SelectedTab == P0001)
                {

                }
                else if (tabControl1.SelectedTab == P0002) 
                {
                    comboBox2.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    textBox6.Enabled = true;
                    textBox10.Enabled = true;
                }

            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == P0002)
            {
                comboBox2.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox6.Enabled = false;
                textBox10.Enabled = false;
            }

            tabControl1.SelectedTab = P0001;
            sl = 0;

            tsbQuery.Enabled = false;
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try 
            {
                if (tabControl1.SelectedTab == P0002)
                {
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;

                    sl = 0;

                    comboBox2.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";

                    comboBox2.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    textBox6.Enabled = true;
                    textBox10.Enabled = true;
                }
            }
            catch(Exception){ }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                int exist = 0;
                if (sl == 0) //新增
                {
                    if (tabControl1.SelectedTab == P0002)
                    {
                        //檢查有無資料
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select count(XieXing) as count from xxzlss where xiexing ='{0}' and shehao = '{1}' and cond = '{2}' and BWBH = '{3}'", textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text);

                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            exist = int.Parse(reader["count"].ToString());
                        }
                        dbConn.CloseConnection();

                        if (exist == 0) //新增
                        {
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into xxzlss (XieXing,SheHao,cond,BWBH,CLBH,CSBH,LOSS,CLSL,USERID,USERDATE,YN) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE(),'1')", textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text, textBox7.Text, textBox8.Text, textBox6.Text, textBox10.Text, userid);
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();
                        }
                        else
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update xxzlss set CLBH = '{1}', CSBH = '{2}',LOSS = '{3}',CLSL = '{4}',USERID = '{5}',USERDATE = GETDATE(),YN = 1 where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}' and BWBH = '{0}'", comboBox2.Text, textBox7.Text, textBox8.Text, textBox6.Text, textBox10.Text, userid, textBox3.Text, textBox4.Text, textBox5.Text);
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();
                        }

                        ds1 = new DataSet();
                        DBconnect dbConnL = new DBconnect();
                        string sqlL = string.Format("select * from xxzlss where xiexing='{0}' and shehao= '{1}' and cond= '{2}' and YN = '1'", textBox3.Text, textBox4.Text, textBox5.Text);
                        Console.WriteLine(sqlL);
                        SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                        adapterL.Fill(ds1, "棧板表");
                        dataGridView3.DataSource = ds1.Tables[0];

                        comboBox2.Enabled = false;
                        textBox7.Enabled = false;
                        textBox8.Enabled = false;
                        textBox6.Enabled = false;
                        textBox10.Enabled = false;
                    }

                }
                else if (sl == 1) //修改
                {
                    if (tabControl1.SelectedTab == P0002)
                    {
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update xxzlss set CLBH = '{1}', CSBH = '{2}',LOSS = '{3}',CLSL = '{4}',USERID = '{5}',USERDATE = GETDATE(),YN = 1 where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}' and BWBH = '{0}'", comboBox2.Text, textBox7.Text, textBox8.Text, textBox6.Text, textBox10.Text, userid, textBox3.Text, textBox4.Text, textBox5.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        ds1 = new DataSet();
                        DBconnect dbConnL = new DBconnect();
                        string sqlL = string.Format("select * from xxzlss where xiexing ='{0}' and shehao = '{1}' and cond = '{2}' and YN = '1'", textBox3.Text, textBox4.Text, textBox5.Text);
                        Console.WriteLine(sqlL);
                        SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                        adapterL.Fill(ds1, "棧板表");
                        dataGridView3.DataSource = ds1.Tables[0];

                        comboBox2.Enabled = false;
                        textBox7.Enabled = false;
                        textBox8.Enabled = false;
                        textBox6.Enabled = false;
                        textBox10.Enabled = false;
                    }

                }

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss SELECT[XieXing],[SheHao],[cond],[BWBH],[CLBH],[CSBH],[LOSS],[CLSL],[USERID],[USERDATE]  FROM [192.168.11.15].New_Erp.dbo.[xxzlss]  where XieXing = '{0}' and SheHao = '{1}'", textBox3.Text, textBox4.Text, textBox5.Text, comboBox2.Text, textBox7.Text, textBox8.Text, textBox6.Text, textBox10.Text, userid);
                Console.WriteLine(sql1Y);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                tsbQuery.Enabled = false;
                tsbInsert.Enabled = true;
                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dsL2 = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("select CC,Quantity,Quantity1 from ddzls where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL2, "棧板表");
                dataGridView2.DataSource = dsL2.Tables[0];

                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //textBox16.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //extBox15.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //textBox14.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                //textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0002) 
                {
                    DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        DBconnect con = new DBconnect();
                        StringBuilder sql = new StringBuilder();
                        sql.AppendFormat("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}' and CLBH = '{4}' and CSBH = '{5}'", dataGridView3.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), dataGridView3.CurrentRow.Cells[2].Value.ToString(), dataGridView3.CurrentRow.Cells[3].Value.ToString(), dataGridView3.CurrentRow.Cells[4].Value.ToString(), dataGridView3.CurrentRow.Cells[5].Value.ToString());

                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                        con.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con.CloseConnection();

                        #region LYSHOE

                        DBconnect2 conY = new DBconnect2();
                        StringBuilder sqlY = new StringBuilder();
                        sqlY.AppendFormat("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}' and CLBH = '{4}' and CSBH = '{5}'", dataGridView3.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), dataGridView3.CurrentRow.Cells[2].Value.ToString(), dataGridView3.CurrentRow.Cells[3].Value.ToString(), dataGridView3.CurrentRow.Cells[4].Value.ToString(), dataGridView3.CurrentRow.Cells[5].Value.ToString());
                        Console.WriteLine(sqlY);
                        SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);

                        conY.OpenConnection();
                        int resultY = cmdY.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conY.CloseConnection();

                        #endregion
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        private void tsbCal_Click(object sender, EventArgs e)
        {

        }
    }
}
