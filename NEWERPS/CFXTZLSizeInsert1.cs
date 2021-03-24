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
    public partial class CFXTZLSizeInsert1 : Form
    {
        public CFXTZLSizeInsert1()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "";
        DataSet ds1 = new DataSet();
        DataSet dsSize = new DataSet();
        public string xie = "", she = "", gender = "", cssize = "";
        int linenum = 0;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLSizeInsert1";

        #endregion

        #region 畫面載入

        private void CFXTZLSizeInsert1_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select * from gjlbzl where gjlb not in (select GJLB from xxgj where XieXing  = '{0}' and SheHao = '{1}')", xie, she);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds1, "倉庫");

                comboBox1.DataSource = ds1.Tables[0];
                comboBox1.ValueMember = "gjlb";
                comboBox1.DisplayMember = "gjlb";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();

            }
            catch (Exception) { }
        }

        #endregion

        #region 方法

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string part = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select ywsm from gjlbzl where gjlb = '{0}'", comboBox1.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    part = reader2["ywsm"].ToString();
                }
                dbConn2.CloseConnection();
                textBox1.Text = part;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //插入XXGJ
                #region NEWERP

                int resultI;
                DBconnect connI = new DBconnect();
                string sql1I = string.Format("insert into xxgj (XieXing,SheHao,GJLB,USERID,USERDATE) values ('{0}','{1}','{2}','{3}', GETDATE())", xie, she, comboBox1.Text, userid);
                Console.WriteLine(sql1I);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                SqlCommand cmd1I = new SqlCommand(sql1I, connI.connection);
                connI.OpenConnection();
                resultI = cmd1I.ExecuteNonQuery();
                if (resultI == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connI.CloseConnection();

                #endregion

                #region LYSHOE

                int resultIY;
                DBconnect2 connIY = new DBconnect2();
                string sql1IY = string.Format("delete ly_shoe.dbo.xxgj where xiexing = '{0}' insert into ly_shoe.dbo.xxgj select xiexing, gjlb, MAX(userid),  CONVERT(varchar,max(USERDATE),11), null, null, null, null from [192.168.11.15].New_Erp.dbo.xxgj where XieXing = '{0}' group by xiexing, gjlb", xie);
                Console.WriteLine(sql1IY);

                SqlCommand cmd1IY = new SqlCommand(sql1IY, connIY.connection);
                connIY.OpenConnection();
                resultIY = cmd1IY.ExecuteNonQuery();
                if (resultIY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connIY.CloseConnection();

                #endregion

                //插入XXGJS

                //選出區間
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
                    int results;
                    DBconnect conns = new DBconnect();
                    string sql1s = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", xie, she, comboBox1.Text, num, dgvSize.Rows[i].Cells[0].Value.ToString(), dgvSize.Rows[i].Cells[0].Value.ToString(), userid);
                    Console.WriteLine(sql1s);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                    conns.OpenConnection();
                    results = cmd1s.ExecuteNonQuery();
                    if (results == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conns.CloseConnection();
                }

                #region LYSHOE

                int resultsY;
                DBconnect connsY = new DBconnect();
                string sql1sY = string.Format("delete ly_shoe.dbo.xxgjs where xiexing = '{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz", xie);
                Console.WriteLine(sql1sY);

                SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                connsY.OpenConnection();
                resultsY = cmd1sY.ExecuteNonQuery();
                if (resultsY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connsY.CloseConnection();

                #endregion

                this.Close();
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

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {
                //P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                //P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #endregion
    }
}
