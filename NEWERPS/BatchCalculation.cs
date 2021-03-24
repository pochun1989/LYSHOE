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
    public partial class BatchCalculation : Form
    {
        public BatchCalculation()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "";
        DataSet dsY1 = new DataSet();
        DataSet dsY2 = new DataSet();
        DataSet ds = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        DataSet dsL3 = new DataSet();
        DataSet dsL2 = new DataSet();
        DataSet ds2 = new DataSet();
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "070300";//BatchCalculation
        string factory = "";

        #endregion

        #region 畫面載入

        private void BatchCalculation_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                combobox();
                combobox2();

                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select * from destination";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc4, "part");

                comboBox4.DataSource = dsc4.Tables[0];
                comboBox4.ValueMember = "DESTINATION_ID";
                comboBox4.DisplayMember = "zwsm";
                comboBox4.MaxDropDownItems = 8;
                comboBox4.IntegralHeight = false;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //ChangeLabel();
                //ChangeDataView();
                //ChangeTabControl();
            }
            catch (Exception) 
            {
                MessageBox.Show("Load Error.載入訂單資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                dataGridView1.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView1.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView1.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView1.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView1.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView1.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView1.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView1.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();

                dataGridView2.Columns[0].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dataGridView2.Columns[1].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView2.Columns[2].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();

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
                //L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                
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

        #region 插入zlzl

        private void insertzlzl()
        {
            try
            {
                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value))
                    {
                        string first = "";
                        first = dataGridView1.Rows[z].Cells[1].Value.ToString();
                        first = first.Substring(0, 1);
                        Console.WriteLine(first);
                        if (first != "Z")
                        {
                            if (first == "S")
                            {
                                factory = "LTY";
                            }
                            else if (first == "C")
                            {
                                factory = "LBT";
                            }
                            else if (first == "F")
                            {
                                factory = "LYF";
                            }

                            //取VER
                            int zlzlver = 0, zlzlsver = 0;
                            DBconnect dbConnV = new DBconnect();
                            string sqlV = string.Format("select isnull(MAX(ver), 0)+1 as ver from zlzl where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sqlV);
                            SqlCommand cmdV = new SqlCommand(sqlV, dbConnV.connection);
                            dbConnV.OpenConnection();
                            SqlDataReader readerV = cmdV.ExecuteReader();
                            if (readerV.Read())
                            {
                                zlzlver = int.Parse(readerV["ver"].ToString());
                            }
                            dbConnV.CloseConnection();

                            DBconnect dbConnV2 = new DBconnect();
                            string sqlV2 = string.Format("select isnull(MAX(ver), 0)+1 as ver from zlzls where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sqlV2);
                            SqlCommand cmdV2 = new SqlCommand(sqlV2, dbConnV2.connection);
                            dbConnV2.OpenConnection();
                            SqlDataReader readerV2 = cmdV2.ExecuteReader();
                            if (readerV2.Read())
                            {
                                zlzlsver = int.Parse(readerV2["ver"].ToString());
                            }
                            dbConnV2.CloseConnection();

                            #region NEWERP

                            //delete zlzl
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete zlzl where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            //delete zlzls
                            DBconnect conD = new DBconnect();
                            StringBuilder sqlD = new StringBuilder();
                            sqlD.AppendFormat("delete zlzls where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sqlD);
                            SqlCommand cmdD = new SqlCommand(sqlD.ToString(), conD.connection);

                            conD.OpenConnection();
                            int resultD = cmdD.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conD.CloseConnection();

                            #endregion
                            
                            #region NEWERP

                            //insert zlzl
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert zlzl (ZLBH,DDBH,CQDH,KDRQ,CGBH,GJJH,YLJS,YLBB,SHQR,GSDH,USERID,USERDATE, YN,ver) values ('{0}','{1}','{2}', GETDATE(), '', 'Y', 'Y', 'B', 'Y', 'LIN', '{3}',GETDATE(), '1', '{4}')", dataGridView1.Rows[z].Cells[1].Value.ToString(), dataGridView1.Rows[z].Cells[1].Value.ToString(), factory, userid, zlzlver);
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            conn.CloseConnection();

                            #endregion

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete zlzl where ZLBH = '{0}' insert zlzl(ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, USERDATE) (select ZLBH, DDBH, CQDH, CAST(year(KDRQ) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(KDRQ) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(KDRQ) as NVARCHAR), 2), 'ZERO', GJJH, YLJS, YLBB, SHQR, GSDH, USERID, CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) from  [192.168.11.15].New_Erp.dbo.zlzl where ZLBH = '{0}')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql1Y);

                            SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                            connY.OpenConnection();
                            resultY = cmd1Y.ExecuteNonQuery();
                            if (resultY == 1)
                            {

                            }
                            connY.CloseConnection();

                            #endregion

                            //insert zlzls
                            ds = new DataSet();
                            DBconnect dbConn = new DBconnect();
                            string sql = string.Format("select * from ddzls where DDBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.Fill(ds, "ddzls");
                            dataGridView9.DataSource = ds.Tables[0];


                            int b = 0;
                            b = dataGridView9.Rows.Count;

                            for (int i = 0; i < b; i++)
                            {
                                int results;
                                DBconnect conns = new DBconnect();
                                string sql1s = string.Format("insert into zlzls (ZLBH, ZLCC,XXCC,QTY,LAST,OS,MS,CUT,USERID,USERDATE,YN,ver) values ('{0}', '{1}','{2}','{3}','0', '0', '0', '0', '{4}', GETDATE(), '1', '{5}')", dataGridView1.Rows[z].Cells[1].Value.ToString(), dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[3].Value.ToString(), userid, zlzlsver);
                                Console.WriteLine(sql1s);

                                SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                                conns.OpenConnection();
                                results = cmd1s.ExecuteNonQuery();
                                if (results == 1)
                                {

                                }
                                conns.CloseConnection();
                            }

                            #region LYSHOE

                            int resultsY;
                            DBconnect2 connsY = new DBconnect2();
                            string sql1sY = string.Format("delete zlzls where ZLBH = '{0}' insert into zlzls(ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, USERDATE)(select ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls where ZLBH = '{0}')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql1sY);

                            SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                            connsY.OpenConnection();
                            resultsY = cmd1sY.ExecuteNonQuery();
                            if (resultsY == 1)
                            {

                            }
                            connsY.CloseConnection();

                            #endregion
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert zlzl Error. 新增訂單資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void combobox() 
        {
            try
            {
                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select * from kfzl";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                comboBox1.DataSource = dsc3.Tables[0];
                comboBox1.ValueMember = "kfdh";
                comboBox1.DisplayMember = "kfqm";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;
            }
            catch (Exception) 
            {
            }
        }

        private void combobox2()
        {
            try
            {
                //DBconnect dbconn3 = new DBconnect();
                //string sql13 = "select * from cqzl";
                //SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                //adapter13.Fill(dsc2, "倉庫");

                //comboBox3.DataSource = dsc2.Tables[0];
                //comboBox3.ValueMember = "cqdh";
                //comboBox3.DisplayMember = "gsywqm";
                //comboBox3.MaxDropDownItems = 8;
                //comboBox3.IntegralHeight = false;
            }
            catch (Exception)
            {
            }
        }

        private void dgv1Load() 
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    dsL3 = new DataSet();
                    DBconnect dbConnL = new DBconnect();
                    string sqlL = string.Format("select DDBH,XieXing,SheHao,ARTICLE,KHBH,KHPO,Version,ShipDate,Pairs,ZLBH from  ddzl where khbh = '{0}' and ShipDate BETWEEN DATEADD(day, 0, '{1}') and  DATEADD(day, 1, '{2}') and ddzt = 'Y' and(DDLB = 'N' or DDZT = 'F') and DDBH like '{3}%' and article like '%{4}%' and dest = '{5}'", comboBox1.SelectedValue, dateTimePicker2.Text, dateTimePicker1.Text, textBox1.Text, textBox2.Text, comboBox4.SelectedValue);
                    Console.WriteLine(sqlL);
                    SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                    adapterL.Fill(dsL3, "棧板表");
                    dataGridView1.DataSource = dsL3.Tables[0];
                }
                else 
                {
                    dsL3 = new DataSet();
                    DBconnect dbConnL = new DBconnect();
                    string sqlL = string.Format("select DDBH,XieXing,SheHao,ARTICLE,KHBH,KHPO,Version,ShipDate,Pairs,ZLBH from  ddzl where khbh = '{0}' and ShipDate BETWEEN DATEADD(day, 0, '{1}') and  DATEADD(day, 1, '{2}') and ddzt = 'Y' and(DDLB = 'N' or DDZT = 'F') and DDBH like '{3}%' and article like '%{4}%'", comboBox1.SelectedValue, dateTimePicker2.Text, dateTimePicker1.Text, textBox1.Text, textBox2.Text, comboBox4.SelectedValue);
                    Console.WriteLine(sqlL);
                    SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                    adapterL.Fill(dsL3, "棧板表");
                    dataGridView1.DataSource = dsL3.Tables[0];
                }
            }
            catch (Exception) { }
        }

        private void special()
        {
            try
            {
                label4.Visible = false;
                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    Console.WriteLine(Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value));
                    if (Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value))
                    {
                        //檢查xxzlss

                        int c2 = 0;
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select count(XieXing) as count from xxzlss where XieXing = '{0}' and SheHao = '{1}'", dataGridView1.Rows[z].Cells[2].Value.ToString(), dataGridView1.Rows[z].Cells[3].Value.ToString());
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
                            //MessageBox.Show(dataGridView1.Rows[z].Cells[1].Value.ToString() + " No SPBOM");
                            label4.Visible = true;
                        }
                        else
                        {
                            //檢查zlzls2
                            int c3 = 0;
                            DBconnect dbConn3 = new DBconnect();
                            string sql3 = string.Format("select COUNT(ZLBH) as count from zlzls2 where ZLBH = '{0}' and XH = 'SPL'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql3);
                            SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                            dbConn3.OpenConnection();
                            SqlDataReader reader3 = cmd3.ExecuteReader();
                            if (reader3.Read())
                            {
                                c3 = int.Parse(reader3["count"].ToString());
                            }
                            dbConn3.CloseConnection();

                            if (c3 == 0) //沒有資料 新增
                            {
                                #region NEWERP

                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH  , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE , DDZL.Pairs * xxzlss.CLSL as CLSL , xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '1' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 1 UNION select DDZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE , sum(DDZLs.Quantity * isnull(Usage_R.CLSL, 0)) as CLSL , xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '1' as ver from DDZLs left join DDZL on DDZL.DDBH = DDZLs.DDBH left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH left join Usage_R on ddzl.XieXing = Usage_R.XieXing and ddzl.SheHao = Usage_R.shehao and ddzls.cc = Usage_R.XTCC and xxzls.BWBH = Usage_R.BWBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 2 and Usage_R.clsl is not null group by DDZL.ZLBH, xxzlss.BWBH, xxzlss.CSBH, xxzlss.CLBH, xxzlss.CLSL, CLZL.CLZMLB", userid, dataGridView1.Rows[z].Cells[1].Value.ToString());
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
                                string sql12 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB , ddzls.CC as SIZE , DDZLs.Quantity * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID , getdate() as USERDATE, '1' as YN, '1' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ddzls on ddzls.ddbh = ddzl.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'Y' and ddzls.Quantity <> 0 ", userid, dataGridView1.Rows[z].Cells[1].Value.ToString());
                                Console.WriteLine(sql12);

                                SqlCommand cmd12 = new SqlCommand(sql12, conn2.connection);
                                conn2.OpenConnection();
                                result2 = cmd12.ExecuteNonQuery();
                                if (result2 == 1)
                                {

                                }
                                conn2.CloseConnection();

                                //int result;
                                //DBconnect conn = new DBconnect();
                                //string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'SPL' as XH, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity) * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '2' as YN, 1 as ver from xxzlss left join DDZL on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where zlZL.ZLBH = '{1}'", userid, dataGridView1.Rows[z].Cells[1].Value.ToString());
                                //Console.WriteLine(sql1);

                                //SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                //conn.OpenConnection();
                                //result = cmd1.ExecuteNonQuery();
                                //if (result == 1)
                                //{

                                //}
                                //conn.CloseConnection();

                                #endregion

                                //#region LYSHOE

                                //int resultY;
                                //DBconnect2 connY = new DBconnect2();
                                //string sql1Y = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate)(select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CONVERT(varchar,userdate,11) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}' and xh <> 'VN')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                                //Console.WriteLine(sql1Y);

                                //SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                                //connY.OpenConnection();
                                //resultY = cmd1Y.ExecuteNonQuery();
                                //if (resultY == 1)
                                //{
                                //}
                                //connY.CloseConnection();

                                //#endregion
                            }
                            else //有舊資料
                            {
                                int ver = 0;
                                double clsl = 0, usage = 0, count = 0;

                                //zlzls2 > xxzlsvn
                                ds2 = new DataSet();
                                DBconnect dbConnL = new DBconnect();
                                string sqlL = string.Format("select * from ZLZLS2 left join ddzl on ddzl.zlbh = zlzls2.zlbh left join xxzlss on xxzlss.xiexing = ddzl.xiexing and xxzlss.shehao = ddzl.shehao and xxzlss.CLBH = ZLZLS2.CLBH where ZLZLS2.ZLBH = '{0}' and XH = 'SPL' and xxzlss.userdate > zlzls2.userdate ", dataGridView1.Rows[z].Cells[1].Value.ToString());
                                Console.WriteLine(sqlL);
                                SqlDataAdapter adapterL9 = new SqlDataAdapter(sqlL, dbConnL.connection);
                                adapterL9.Fill(ds2, "棧板表");
                                dgvOldZlzls21.DataSource = ds2.Tables[0];

                                Console.WriteLine(dgvOldZlzls21.Rows.Count);
                                //插入舊資料版本
                                if (dgvOldZlzls21.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dgvOldZlzls21.Rows.Count; i++)
                                    {
                                        //取出版本
                                        DBconnect dbConn1v = new DBconnect();
                                        string sql1v = string.Format("select ver from zlzls2 where ZLBH = '{0}' and BWBH = '{1}' and CLBH = '{2}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                                        Console.WriteLine(sql1v);
                                        SqlCommand cmd1v = new SqlCommand(sql1v, dbConn1v.connection);
                                        dbConn1v.OpenConnection();
                                        SqlDataReader reader1v = cmd1v.ExecuteReader();
                                        if (reader1v.Read())
                                        {
                                            ver = int.Parse(reader1v["ver"].ToString());
                                        }
                                        dbConn1v.CloseConnection();
                                        Console.WriteLine(ver);

                                        //取出數量
                                        DBconnect dbConn5 = new DBconnect();
                                        string sql5 = string.Format("select SUM(Quantity) as count from ddzls where DDBH = '{0}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString());
                                        Console.WriteLine(sql5);
                                        SqlCommand cmd5 = new SqlCommand(sql5, dbConn5.connection);
                                        dbConn5.OpenConnection();
                                        SqlDataReader reader5 = cmd5.ExecuteReader();
                                        if (reader5.Read())
                                        {
                                            count = double.Parse(reader5["count"].ToString());
                                        }
                                        dbConn5.CloseConnection();
                                        Console.WriteLine(count);

                                        DBconnect dbConn6 = new DBconnect();
                                        string sql6 = string.Format("select CLSL from xxzlss left join DDZL on xxzlss.XieXing = DDZL.XieXing and xxzlss.SheHao = DDZL.SheHao where DDBH = '{0}' and BWBH = '{1}' and CLBH = '{2}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                                        Console.WriteLine(sql6);
                                        SqlCommand cmd6 = new SqlCommand(sql6, dbConn6.connection);
                                        dbConn6.OpenConnection();
                                        SqlDataReader reader6 = cmd6.ExecuteReader();
                                        if (reader6.Read())
                                        {
                                            usage = double.Parse(reader6["CLSL"].ToString());
                                        }
                                        dbConn6.CloseConnection();
                                        Console.WriteLine(usage);

                                        clsl = usage * count;
                                        Console.WriteLine(clsl);

                                        //新增資料

                                        int result7;
                                        DBconnect conn7 = new DBconnect();
                                        string sql7 = string.Format("insert into zlzls2 select ZLBH,BWBH,CLBH,SIZE,YN,xh,CSBH,MJBH,ZMLB,'{0}' as CLSL,'{1}' as USAGE,'{2}' as USERID,GETDATE() as USERDATE,CLSL2,Usage2,Qbuy,QWin,Qwot,Udate,LTDBH,ver+1 as ver from zlzls2  where ZLBH = '{3}' and BWBH = '{4}' and CLBH = '{5}'", clsl, usage, userid, dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
                                        Console.WriteLine(sql7);
                                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                                        SqlCommand cmd7 = new SqlCommand(sql7, conn7.connection);
                                        conn7.OpenConnection();
                                        result7 = cmd7.ExecuteNonQuery();
                                        if (result7 == 1)
                                        {

                                        }
                                        conn7.CloseConnection();

                                        //修改為0
                                        DBconnect con8 = new DBconnect();
                                        StringBuilder sql8 = new StringBuilder();
                                        sql8.AppendFormat("update zlzls2 set YN = 0 where ZLBH = '{0}' and BWBH = '{1}' and CLBH = '{2}' and ver = '{3}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString(), ver);
                                        Console.WriteLine(sql8);
                                        SqlCommand cmd8 = new SqlCommand(sql8.ToString(), con8.connection);

                                        con8.OpenConnection();
                                        int result8 = cmd8.ExecuteNonQuery();
                                        if (result8 == 1)
                                        {
                                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        con8.CloseConnection();                                      
                                    }
                                }

                                //插入剩餘資料
                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'SPL' as XH, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH, xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity) * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '2' as YN, 1 as ver from xxzlss left join DDZL on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO  LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where zlZL.ZLBH = '{1}'", userid, dataGridView1.Rows[z].Cells[1].Value.ToString());
                                Console.WriteLine(sql1);

                                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                conn.OpenConnection();
                                result = cmd1.ExecuteNonQuery();
                                if (result == 1)
                                {

                                }
                                conn.CloseConnection();


                                #region LYSHOE

                                int resultY2;
                                DBconnect2 connY2 = new DBconnect2();
                                string sql1Y2 = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate)(select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2)  from[192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                                Console.WriteLine(sql1Y2);

                                SqlCommand cmd1Y2 = new SqlCommand(sql1Y2, connY2.connection);
                                connY2.OpenConnection();
                                resultY2 = cmd1Y2.ExecuteNonQuery();
                                if (resultY2 == 1)
                                {

                                }
                                connY2.CloseConnection();

                                #endregion

                            }

                        }

                        //刪除BOM
                        DBconnect con4B = new DBconnect();
                        StringBuilder sql4B = new StringBuilder();
                        sql4B.AppendFormat("delete zlzls2 where zlbh = '{0}' and BWBH in (select bwbh from BOMAD where cond = '{0}' and ADTYP = 'D')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                        Console.WriteLine(sql4B);
                        SqlCommand cmd4B = new SqlCommand(sql4B.ToString(), con4B.connection);
                        con4B.OpenConnection();
                        int result4B = cmd4B.ExecuteNonQuery();
                        if (result4B == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4B.CloseConnection();
                        

                        int resultY;
                        DBconnect2 connY = new DBconnect2();
                        string sql1Y = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2 (zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate) (select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from[192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                        Console.WriteLine(sql1Y);

                        SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                        connY.OpenConnection();
                        resultY = cmd1Y.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connY.CloseConnection();

                        //新增OLD
                        int oldVer = 0;
                        DBconnect dbConnV = new DBconnect();
                        string sqlV = string.Format("select isnull(MAX(plus), 0)+1 as ver from zlzls2old where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                        Console.WriteLine(sqlV);
                        SqlCommand cmdV = new SqlCommand(sqlV, dbConnV.connection);
                        dbConnV.OpenConnection();
                        SqlDataReader readerV = cmdV.ExecuteReader();
                        if (readerV.Read())
                        {
                            oldVer = int.Parse(readerV["ver"].ToString());
                        }
                        dbConnV.CloseConnection();
                        Console.WriteLine(oldVer);

                        int ver2 = 0;
                        DBconnect dbConnD = new DBconnect();
                        string sqlD = string.Format("select isnull(MAX(ver), 0) as ver from zlzls2 where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                        Console.WriteLine(sqlD);
                        SqlCommand cmdD = new SqlCommand(sqlD, dbConnD.connection);
                        dbConnD.OpenConnection();
                        SqlDataReader readerD = cmdD.ExecuteReader();
                        if (readerD.Read())
                        {
                            ver2 = int.Parse(readerD["ver"].ToString());
                        }
                        dbConnD.CloseConnection();
                        Console.WriteLine(ver2);

                        int resultO;
                        DBconnect connO = new DBconnect();
                        string sql1O = string.Format("insert into zlzls2old select ZLBH, BWBH, CLBH, SIZE, YN, xh, CSBH, MJBH, ZMLB, CLSL, USAGE, USERID, USERDATE, CLSL2, Usage2, Qbuy, QWin, Qwot, Udate, LTDBH, '{2}' from zlzls2 where ZLBH = '{0}' and ver = ('{1}')", dataGridView1.Rows[z].Cells[1].Value.ToString(), ver2, oldVer);
                        Console.WriteLine(sql1O);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd1O = new SqlCommand(sql1O, connO.connection);
                        connO.OpenConnection();
                        resultO = cmd1O.ExecuteNonQuery();
                        if (resultO == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connO.CloseConnection();
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("SPBOM Calculate Error 特殊包材計算錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateDDZL()
        {
            try
            {
                int maxBom = 0, maxUsage = 0;
                string xiexing = "", shehao = "";
                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    Console.WriteLine(Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value));
                    if (Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value))
                    {
                        //xiexing,shehao
                        DBconnect dbConnD = new DBconnect();
                        string sqlD = string.Format("select XieXing,SheHao from DDZL where DDBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                        Console.WriteLine(sqlD);
                        SqlCommand cmdD = new SqlCommand(sqlD, dbConnD.connection);
                        dbConnD.OpenConnection();
                        SqlDataReader readerD = cmdD.ExecuteReader();
                        if (readerD.Read())
                        {
                            xiexing = readerD["XieXing"].ToString();
                            shehao = readerD["SheHao"].ToString();
                        }
                        dbConnD.CloseConnection();
                        Console.WriteLine(xiexing);
                        Console.WriteLine(shehao);

                        //maxbom
                        DBconnect dbConnD3 = new DBconnect();
                        string sqlD3 = string.Format("select MAX(xxzlver) as xxzlver from Usage_R where XieXing = '{0}' and SheHao = '{1}'", xiexing, shehao);
                        Console.WriteLine(sqlD3);
                        SqlCommand cmdD3 = new SqlCommand(sqlD3, dbConnD3.connection);
                        dbConnD3.OpenConnection();
                        SqlDataReader readerD3 = cmdD3.ExecuteReader();
                        if (readerD3.Read())
                        {
                            maxBom = int.Parse(readerD3["xxzlver"].ToString());
                        }
                        dbConnD3.CloseConnection();


                        maxBom = 1; //BOM上限刪除

                        //maxUsage
                        DBconnect dbConnD2 = new DBconnect();
                        string sqlD2 = string.Format("select MAX(ver) as ver from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}'", xiexing, shehao, maxBom);
                        Console.WriteLine(sqlD2);
                        SqlCommand cmdD2 = new SqlCommand(sqlD2, dbConnD2.connection);
                        dbConnD2.OpenConnection();
                        SqlDataReader readerD2 = cmdD2.ExecuteReader();
                        if (readerD2.Read())
                        {
                            maxUsage = int.Parse(readerD2["ver"].ToString());
                        }
                        dbConnD2.CloseConnection();

                        maxUsage = 1;//BOM上限刪除
                        //Console.WriteLine(maxUsage);

                        //update
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZL set Version = '{0}' , UsageVer = '{1}', USERID = '{2}',USERDATE = GETDATE() where DDBH = '{3}'", maxBom, maxUsage, userid, dataGridView1.Rows[z].Cells[1].Value.ToString());

                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZL set Version = '{0}' , USERID = '{2}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{3}'", maxBom, maxUsage, userid, dataGridView1.Rows[z].Cells[1].Value.ToString());

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
                }
            }
            catch (Exception) { }
        }

        #endregion
        
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox4.Visible = false;
            }
            else 
            {
                comboBox4.Visible = true;
            }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                dgv1Load();
                if (dataGridView1.Rows.Count == 0)
                {
                    dataGridView2.Visible = false;
                }
                else
                {
                    dataGridView2.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                a = dataGridView1.Rows.Count;

                if (L0004.Checked == true)
                {
                    for (int i = 0; i < a; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = 1;
                    }
                }
                else if (L0004.Checked == false)
                {
                    for (int i = 0; i < a; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = 0;
                    }
                }
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.ReadOnly = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
            }
            catch (Exception)
            { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    #region NEWERP

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update DDZLs set Quantity1 = '{0}', USERID = '{3}', USERDATE = getdate() where DDBH = '{1}' and CC = '{2}'", dataGridView2.Rows[i].Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString(), userid);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }
                    con4.CloseConnection();

                    #endregion

                    #region LYSHOE

                    DBconnect2 con4Y = new DBconnect2();
                    StringBuilder sql4Y = new StringBuilder();
                    sql4Y.AppendFormat("update DDZLs set Quantity1 = '{0}', USERID = '{3}', USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{1}' and CC = '{2}'", dataGridView2.Rows[i].Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString(), userid);

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

                dataGridView2.ReadOnly = false;
                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
            }
            catch (Exception)
            { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.ReadOnly = false;
                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;

                dsL2 = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("select CC,Quantity,Quantity1 from ddzls where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL2, "棧板表");
                dataGridView2.DataSource = dsL2.Tables[0];
            }
            catch (Exception)
            { }
        }

        private void tsbCal_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.CurrentCell = null;
                dataGridView1.EndEdit();

                //update 版本
                updateDDZL();

                //計算ZLZLS2
                insertzlzl();

                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    string first = "";
                    first = dataGridView1.Rows[z].Cells[1].Value.ToString();
                    first = first.Substring(0, 1);
                    Console.WriteLine(first);
                    if (first != "Z")
                    {
                        Console.WriteLine(Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value));

                        if (Convert.ToBoolean(dataGridView1.Rows[z].Cells[0].Value))
                        {
                            Console.WriteLine(dataGridView1.Rows[z].Cells[1].Value.ToString());
                            #region 取資料

                            #region 修改DDZL
                            #region NEWERP

                            DBconnect cond = new DBconnect();
                            StringBuilder sqld = new StringBuilder();
                            sqld.AppendFormat("update ddzl set ZLBH  = '{0}' where DDBH = '{1}'", dataGridView1.Rows[z].Cells[1].Value.ToString(), dataGridView1.Rows[z].Cells[1].Value.ToString());

                            Console.WriteLine(sqld);
                            SqlCommand cmdd = new SqlCommand(sqld.ToString(), cond.connection);
                            cond.OpenConnection();
                            int resultd = cmdd.ExecuteNonQuery();
                            if (resultd == 1)
                            {

                            }
                            cond.CloseConnection();

                            #endregion

                            #region LYSHOE

                            DBconnect2 condY = new DBconnect2();
                            StringBuilder sqldY = new StringBuilder();
                            sqldY.AppendFormat("update ddzl set ZLBH  = '{0}' where DDBH = '{1}'", dataGridView1.Rows[z].Cells[1].Value.ToString(), dataGridView1.Rows[z].Cells[1].Value.ToString());

                            Console.WriteLine(sqldY);
                            SqlCommand cmddY = new SqlCommand(sqldY.ToString(), condY.connection);
                            condY.OpenConnection();
                            int resultdY = cmddY.ExecuteNonQuery();
                            if (resultdY == 1)
                            {

                            }
                            condY.CloseConnection();

                            #endregion
                            #endregion

                            int ver = 0, day = 0;
                            //取出版本號*1
                            DBconnect dbConnD = new DBconnect();
                            string sqlD = string.Format("select isnull(MAX(ver), 0)+1 as ver from zlzls2 where ZLBH = '{0}'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sqlD);
                            SqlCommand cmdD = new SqlCommand(sqlD, dbConnD.connection);
                            dbConnD.OpenConnection();
                            SqlDataReader readerD = cmdD.ExecuteReader();
                            if (readerD.Read())
                            {
                                ver = int.Parse(readerD["ver"].ToString());
                            }
                            dbConnD.CloseConnection();
                            Console.WriteLine(ver);

                            //刪除ZLZLS2
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete zlzls2 where ZLBH = '{0}' and YN = '1'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();


                            //insert 全材料
                            #region insert all

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver)( select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, sum(CLSL) as clsl, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from (select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left  join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH  left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'N' and BWLB != '3' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and xxgjs.SheHao = ddzl.SheHao and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'Y' and BWLB != '3') as a group by DDBH, BWBH, CSBH, CLBH, clzmlb, SIZE, USAGE) ", dataGridView1.Rows[z].Cells[1].Value.ToString(), userid, ver);
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

                            //刪除特殊材料

                            int resultD;
                            DBconnect connD = new DBconnect();
                            string sql1D = string.Format("delete zlzls2 where zlzls2.zlbh = '{0}' and  bwbh in (select bwbh from xxzlss left join ddzl on ddzl.XieXing = xxzlss.XieXing and ddzl.SheHao = xxzlss.SheHao and ddzl.Dest = xxzlss.cond where DDZL.DDBH = '{0}')", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sql1D);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1D = new SqlCommand(sql1D, connD.connection);
                            connD.OpenConnection();
                            resultD = cmd1D.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connD.CloseConnection();

                            #endregion



                            DataSet dsBOM = new DataSet();
                            DBconnect dbConnB = new DBconnect();
                            string sqlB = string.Format("select * from BOMAD where XieXing = '{0}' and SheHao = '{1}' and ADTYP = 'A' and cond = '{2}' and bwbh not in (select BWBH from xxzlss where XieXing = '{0}' and SheHao = '{1}')", dataGridView1.Rows[z].Cells[2].Value.ToString(), dataGridView1.Rows[z].Cells[3].Value.ToString(), dataGridView1.Rows[z].Cells[1].Value.ToString());
                            SqlDataAdapter adapterB = new SqlDataAdapter(sqlB, dbConnB.connection);
                            adapterB.Fill(dsBOM, "新增");
                            dataGridView3.DataSource = dsBOM.Tables[0];

                            for (int i = 0; i < dataGridView3.Rows.Count; i++)
                            {
                                int resultB2;
                                DBconnect connB2 = new DBconnect();
                                string sqlB2 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver)(select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, sum(CLSL) as clsl, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from(select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'N' and zlzlstemp.BWBH = '{3}' and BWLB = '3' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from(select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and  xxgjs.SheHao = ddzl.SheHao and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'Y' and zlzlstemp.BWBH = '{3}' and BWLB = '3') as a group by DDBH, BWBH, CSBH, CLBH, clzmlb, SIZE, USAGE)", dataGridView1.Rows[z].Cells[1].Value.ToString(), userid, ver, dataGridView3.Rows[i].Cells[4].Value.ToString());
                                Console.WriteLine(sqlB2);

                                SqlCommand cmdB2 = new SqlCommand(sqlB2, connB2.connection);
                                connB2.OpenConnection();
                                resultB2 = cmdB2.ExecuteNonQuery();
                                if (resultB2 == 1)
                                {

                                }
                                connB2.CloseConnection();
                            }


                            //insert 拆解母材料
                            #region insert ms

                            //select 母材料
                            int ycount = 0;

                            DBconnect dbConnY = new DBconnect();
                            string sqlY = string.Format("select count(CLBH) as count from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                            Console.WriteLine(sqlY);
                            SqlCommand cmdY = new SqlCommand(sqlY, dbConnY.connection);
                            dbConnY.OpenConnection();
                            SqlDataReader readerY = cmdY.ExecuteReader();
                            if (readerY.Read())
                            {
                                ycount = int.Parse(readerY["count"].ToString());
                            }
                            dbConnY.CloseConnection();
                            Console.WriteLine(ycount);

                            if (ycount > 0)
                            {
                                //取出母材料
                                dsY1 = new DataSet();
                                DBconnect dbConn = new DBconnect();
                                string sql = string.Format("select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,YN,ver from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", dataGridView1.Rows[z].Cells[1].Value.ToString());
                                Console.WriteLine(sql);
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                                adapter.Fill(dsY1, "棧板表");
                                dgvCAL.DataSource = dsY1.Tables[0];

                                for (int i = 0; i < dgvCAL.Rows.Count; i++)
                                {
                                    dsY2 = new DataSet();
                                    DBconnect dbConn2 = new DBconnect();
                                    string sql2 = string.Format("select * from clzhzl where cldh_M = '{0}'", dgvCAL.Rows[i].Cells[5].Value.ToString());
                                    Console.WriteLine(sql2);
                                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                                    adapter2.Fill(dsY2, "棧板表");
                                    dgvCAL2.DataSource = dsY2.Tables[0];
                                    Console.WriteLine("ROWSCOUNT:" + dgvCAL2.Rows.Count);
                                    //插入子材料
                                    for (int j = 0; j < dgvCAL2.Rows.Count; j++)
                                    {
                                        double clsl = 0;
                                        Console.WriteLine(dgvCAL.Rows[i].Cells[8].Value.ToString());
                                        Console.WriteLine(dgvCAL2.Rows[j].Cells[6].Value.ToString());
                                        clsl = double.Parse(dgvCAL.Rows[i].Cells[8].Value.ToString()) * double.Parse(dgvCAL2.Rows[j].Cells[6].Value.ToString());
                                        Console.WriteLine("CLCL:" + clsl);

                                        int result3;
                                        DBconnect conn3 = new DBconnect();
                                        string sql3 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN,ver) values ('{0}','{1}','{2}','{3}','{4}','{5}','N','{6}','{7}','{8}','{9}',GETDATE(),'1','{10}') ", dgvCAL.Rows[i].Cells[0].Value.ToString(), dgvCAL.Rows[i].Cells[1].Value.ToString(), dgvCAL.Rows[i].Cells[2].Value.ToString(), dgvCAL2.Rows[j].Cells[7].Value.ToString(), dgvCAL.Rows[i].Cells[5].Value.ToString(), dgvCAL2.Rows[j].Cells[0].Value.ToString(), dgvCAL.Rows[i].Cells[7].Value.ToString(), clsl, dgvCAL.Rows[i].Cells[9].Value.ToString(), userid, dgvCAL.Rows[i].Cells[11].Value.ToString());
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
                                }
                            }
                            #endregion

                            #endregion
                                                       
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can not Calculate");
                        break;
                    }

                }

                //特殊包裝
                special();


                //載入
                dgv1Load();

                if (dataGridView1.Rows.Count == 0)
                {
                    dataGridView2.Visible = false;
                }

                MessageBox.Show("插入資料完成 Insert Complete", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("插入資料失敗 Insert Error", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            }
            catch (Exception) { }
        }

        private void tsButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
