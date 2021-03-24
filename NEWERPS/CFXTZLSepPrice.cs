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
    public partial class CFXTZLSepPrice : Form
    {
        public CFXTZLSepPrice()
        {
            InitializeComponent();
        }

        #region 變數

        public string sum1, sum2, sum3;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsXXDJ = new DataSet(); //存放XXDJ
        DataSet dsSize = new DataSet();
        public string userid = "";
        public string country,gender;
        string sp;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLSepPrice";

        #endregion

        #region 畫面載入

        private void CFXTZLSepPrice_Load(object sender, EventArgs e)
        {

            //this.xXDJTableAdapter.Fill(this.nEW_ERPDataSet.XXDJ);
            try
            {
                userid = Program.User.userID;
                Shehao();

                //判斷INSERT OR LOAD
                Checkxxdj();

                if (sp == "0") // 新增
                {
                    InsertXXDJ();
                }

                //讀取
                LOad();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
;
            }
            catch (Exception) { }
        }

        #endregion

        #region 方法

        private void button2_Click(object sender, EventArgs e)
        {
            //SAVE
            try
            {
                double s1 = 0, s2 = 0, s3 = 0;
                int a = dataGridView3.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    #region NEWERP

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update XXDJ set OPrice = '{0}', IPrice = '{1}' ,CPrice = '{2}'  where  XieXing = '{3}' and SheHao = '{4}' and LineNum = '{5}'",dataGridView3.Rows[i].Cells[5].Value.ToString(), dataGridView3.Rows[i].Cells[6].Value.ToString(), dataGridView3.Rows[i].Cells[7].Value.ToString(), tb1.Text, tb2.Text, dataGridView3.Rows[i].Cells[2].Value.ToString());
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();

                    #endregion

                    #region LYSHOE

                    DBconnect2 con4Y = new DBconnect2();
                    StringBuilder sql4Y = new StringBuilder();
                    sql4Y.AppendFormat("update XXDJ set OPrice = '{0}', IPrice = '{1}' ,CPrice = '{2}'  where  XieXing = '{3}' and SheHao = '{4}' and LineNum = '{5}'", dataGridView3.Rows[i].Cells[5].Value.ToString(), dataGridView3.Rows[i].Cells[6].Value.ToString(), dataGridView3.Rows[i].Cells[7].Value.ToString(), tb1.Text, tb2.Text, dataGridView3.Rows[i].Cells[2].Value.ToString());
                    Console.WriteLine(sql4Y);
                    SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                    con4Y.OpenConnection();
                    int result4Y = cmd4Y.ExecuteNonQuery();
                    if (result4Y == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4Y.CloseConnection();

                    #endregion

                    s1 += double.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                    s2 += double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    s3 += double.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                }
                s1 = s1 / a;
                s2 = s2 / a;
                s3 = s3 / a;
                Console.WriteLine(s1);
                Console.WriteLine(s2);
                Console.WriteLine(s3);
                sum1 = s1.ToString();
                sum2 = s2.ToString();
                sum3 = s3.ToString();

                
            }
            catch (Exception) { }

        }

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

        #region 鞋型載入

        private void Shehao()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select distinct SheHao from XXDJ where XieXing = '{0}' and SheHao != '{1}'", tb1.Text, tb2.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //COPY
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from XXDJ where XieXing = '{0}' and SheHao = '{1}'", tb1.Text, comboBox1.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView3.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();

                int a = dataGridView3.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    dataGridView3.Rows[i].Cells[1].Value = tb2.Text;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 檢查重複

        private void Checkxxdj()
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(XieXing) as count from XXDJ where XieXing  = '{0}' and SheHao = '{1}'", tb1.Text, tb2.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    sp = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();
            }
            catch (Exception)
            { }
        }

        #endregion

        #region 讀取

        private void LOad() 
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from XXDJ  where XieXing = '{0}' and SheHao = '{1}'", tb1.Text, tb2.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");
                dataGridView3.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region INSERT XXDJ

        private void InsertXXDJ()
        {
            try
            {
                string gender = "", khdh = "";

                //取出性別跟客戶
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select KHDH,GENDER from xxzl where XieXing = '{0}' and SheHao = '{1}'", tb1.Text, tb2.Text);
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

                int linenum = 0;

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
                    int result3;
                    DBconnect conn3 = new DBconnect();
                    string sql3 = string.Format("insert into XXDJ (XieXing,SheHao,LineNum,Size_CLASS,Size_Number,OPrice,IPrice,CPrice) values('{0}','{1}','{2}','{3}','{4}','0','0','0')", tb1.Text, tb2.Text, linenum, country, dgvSize.Rows[i].Cells[0].Value.ToString().Trim());
                    Console.WriteLine(sql3);

                    SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                    conn3.OpenConnection();
                    result3= cmd3.ExecuteNonQuery();
                    if (result3 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn3.CloseConnection();   
                }

                #region LYSHOE

                dsXXDJ = new DataSet();
                DBconnect dbConnX = new DBconnect();
                string sqlX = string.Format("select * from New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}'", tb1.Text, tb2.Text);
                Console.WriteLine(sqlX);
                SqlDataAdapter adapterX = new SqlDataAdapter(sqlX, dbConnX.connection);
                adapterX.Fill(dsXXDJ, "棧板表");

                dgvXXDJ.DataSource = dsXXDJ.Tables[0];
                dbConnX.CloseConnection();

                for (int i = 0 ; i < dgvXXDJ.Rows.Count; i ++)
                {
                    if (dgvXXDJ.Rows[i].Cells[3].Value.ToString() == "A") 
                    {
                        int result3X;
                        DBconnect conn3X = new DBconnect();
                        string sql3X = string.Format("insert into ly_shoe.dbo.xxdj(xiexing,shehao,lienum,");
                        sql3X += " US_Size";
                        sql3X += string.Format(",Oprice,iprice,cprice select xiexing, shehao, lienum, size_number, oprice, Iprice, cprice from [192.168.11.15].New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}' and LineNum = '{2}'", tb1.Text, tb2.Text, dgvXXDJ.Rows[i].Cells[2].Value.ToString());
                        Console.WriteLine(sql3X);

                        SqlCommand cmd3X = new SqlCommand(sql3X, conn3X.connection);
                        conn3X.OpenConnection();
                        result3X = cmd3X.ExecuteNonQuery();
                        if (result3X == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn3X.CloseConnection();
                    }
                    else if (dgvXXDJ.Rows[i].Cells[3].Value.ToString() == "C")
                    {
                        int result3X;
                        DBconnect conn3X = new DBconnect();
                        string sql3X = string.Format("insert into ly_shoe.dbo.xxdj(xiexing,shehao,lienum,");
                        sql3X += " OTH_Size";
                        sql3X += string.Format(",Oprice,iprice,cprice select xiexing, shehao, lienum, size_number, oprice, Iprice, cprice from [192.168.11.15].New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}' and LineNum = '{2}'", tb1.Text, tb2.Text, dgvXXDJ.Rows[i].Cells[2].Value.ToString());
                        Console.WriteLine(sql3X);

                        SqlCommand cmd3X = new SqlCommand(sql3X, conn3X.connection);
                        conn3X.OpenConnection();
                        result3X = cmd3X.ExecuteNonQuery();
                        if (result3X == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn3X.CloseConnection();
                    }
                    else if (dgvXXDJ.Rows[i].Cells[3].Value.ToString() == "E")
                    {
                        int result3X;
                        DBconnect conn3X = new DBconnect();
                        string sql3X = string.Format("insert into ly_shoe.dbo.xxdj(xiexing,shehao,lienum,");
                        sql3X += " EUR_Size";
                        sql3X += string.Format(",Oprice,iprice,cprice select xiexing, shehao, lienum, size_number, oprice, Iprice, cprice from [192.168.11.15].New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}' and LineNum = '{2}'", tb1.Text, tb2.Text, dgvXXDJ.Rows[i].Cells[2].Value.ToString());
                        Console.WriteLine(sql3X);

                        SqlCommand cmd3X = new SqlCommand(sql3X, conn3X.connection);
                        conn3X.OpenConnection();
                        result3X = cmd3X.ExecuteNonQuery();
                        if (result3X == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn3X.CloseConnection();
                    }
                    else if (dgvXXDJ.Rows[i].Cells[3].Value.ToString() == "J")
                    {
                        int result3X;
                        DBconnect conn3X = new DBconnect();
                        string sql3X = string.Format("insert into ly_shoe.dbo.xxdj(xiexing,shehao,lienum,");
                        sql3X += " JPN_Size";
                        sql3X += string.Format(",Oprice,iprice,cprice select xiexing, shehao, lienum, size_number, oprice, Iprice, cprice from [192.168.11.15].New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}' and LineNum = '{2}'", tb1.Text, tb2.Text, dgvXXDJ.Rows[i].Cells[2].Value.ToString());
                        Console.WriteLine(sql3X);

                        SqlCommand cmd3X = new SqlCommand(sql3X, conn3X.connection);
                        conn3X.OpenConnection();
                        result3X = cmd3X.ExecuteNonQuery();
                        if (result3X == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn3X.CloseConnection();
                    }
                    else if (dgvXXDJ.Rows[i].Cells[3].Value.ToString() == "U")
                    {
                        int result3X;
                        DBconnect conn3X = new DBconnect();
                        string sql3X = string.Format("insert into ly_shoe.dbo.xxdj(xiexing,shehao,lienum,");
                        sql3X += " UK_Size";
                        sql3X += string.Format(",Oprice,iprice,cprice select xiexing, shehao, lienum, size_number, oprice, Iprice, cprice from [192.168.11.15].New_Erp.dbo.XXDJ where XieXing = '{0}' and SheHao = '{1}' and LineNum = '{2}'", tb1.Text, tb2.Text, dgvXXDJ.Rows[i].Cells[2].Value.ToString());
                        Console.WriteLine(sql3X);

                        SqlCommand cmd3X = new SqlCommand(sql3X, conn3X.connection);
                        conn3X.OpenConnection();
                        result3X = cmd3X.ExecuteNonQuery();
                        if (result3X == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn3X.CloseConnection();
                    }

                }

                #endregion

            }
            catch (Exception) { }

        }

        #endregion

        #endregion
    }
}
