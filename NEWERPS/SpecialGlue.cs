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
    public partial class SpecialGlue : Form
    {
        public SpecialGlue()
        {
            InitializeComponent();
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

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "SpecialDosage";

        int sl = 0;

        private void SpecialGlue_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nEW_ERPDataSet.DDZL' 資料表。您可以視需要進行移動或移除。
            //this.dDZLTableAdapter.Fill(this.nEW_ERPDataSet.DDZL);
            try
            {
                userid = Program.User.userID;

                combobox();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
                //ChangeTabControl();

                comboBox3.DataSource = dsc1.Tables[0];
                comboBox3.ValueMember = "bwdh";
                comboBox3.DisplayMember = "bwdh";
                comboBox3.MaxDropDownItems = 8;
                comboBox3.IntegralHeight = false;
            }
            catch (Exception) { }
        }

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
                else if (tabControl1.SelectedTab == P0003)
                {
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    ds1 = new DataSet();
                    DBconnect dbConnL = new DBconnect();
                    string sqlL = string.Format("select * from xxzlsvn where xiexing= '{0}' and shehao= '{1}' and YN = '1'", textBox15.Text, textBox14.Text);
                    Console.WriteLine(sqlL);
                    SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                    adapterL.Fill(ds1, "棧板表");
                    dataGridView4.DataSource = ds1.Tables[0];
                }
            }
            catch (Exception) { }
        }

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

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;

                sl = 0;
                if (tabControl1.SelectedTab == P0003)
                {
                    comboBox3.Text = "";
                    textBox12.Text = "";
                    textBox9.Text = "";
                    textBox11.Text = "";

                    comboBox3.Enabled = true;
                    textBox12.Enabled = true;
                    textBox9.Enabled = true;
                    textBox11.Enabled = true;
                }
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
                else if (tabControl1.SelectedTab == P0003)
                {
                    comboBox3.Enabled = true;
                    textBox12.Enabled = true;
                    textBox9.Enabled = true;
                    textBox11.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void L0006_Click(object sender, EventArgs e)
        {
            try
            {

                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    //檢查xxzlsvn

                    int c2 = 0;
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select count(XieXing) as count from XXZLSVN where XieXing = '{0}' and SheHao = '{1}'", dataGridView1.Rows[j].Cells[2].Value.ToString(), dataGridView1.Rows[j].Cells[3].Value.ToString());
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
                        tabControl1.SelectedTab = P0003;
                    }
                    else
                    {
                        //檢查zlzls2
                        int c3 = 0;
                        DBconnect dbConn3 = new DBconnect();
                        string sql3 = string.Format("select COUNT(ZLBH) as count from zlzls2 where ZLBH = '{0}' and XH = 'VN'", dataGridView1.Rows[j].Cells[1].Value.ToString());
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
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'VN' as XH, XXZLSVN.BWBH, XXZLSVN.CSBH, 'ZZZZZZZZZZ' as MJBH, XXZLSVN.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity + DDZLs.Quantity1) * XXZLSVN.CLSL as CLSL, XXZLSVN.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '2' as YN, 1 as ver from XXZLSVN left join DDZL on XXZLSVN.XIEXING = DDZL.XIEXING AND XXZLSVN.SHEHAO = DDzl.SHEHAO  LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join zlzls2 on DDZL.DDBH = zlzls2.ZLBH left join CLZL on CLZL.CLDH = XXZLSVN.CLBH where zlZL.ZLBH = '{1}' and zlzls2.clbh is null", userid, dataGridView1.Rows[j].Cells[1].Value.ToString());
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            conn.CloseConnection();
                        }
                        else //有舊資料
                        {
                            int ver = 0;
                            double clsl = 0, usage = 0, count = 0;

                            //zlzls2 > xxzlsvn
                            ds2 = new DataSet();
                            DBconnect dbConnL = new DBconnect();
                            string sqlL = string.Format("select * from ZLZLS2 left join ddzl on ddzl.zlbh = zlzls2.zlbh   left join XXZLSVN on xxzlsvn.xiexing = ddzl.xiexing and xxzlsvn.shehao = ddzl.shehao and xxzlsvn.CLBH = ZLZLS2.CLBH where ZLZLS2.ZLBH = '{0}' and XH = 'VN' and xxzlsvn.userdate > zlzls2.userdate ", dataGridView1.Rows[j].Cells[1].Value.ToString());
                            Console.WriteLine(sqlL);
                            SqlDataAdapter adapterL9 = new SqlDataAdapter(sqlL, dbConnL.connection);
                            adapterL9.Fill(ds2, "棧板表");
                            dgvOldZlzls21.DataSource = ds2.Tables[0];

                            //插入舊資料版本
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
                                string sql5 = string.Format("select SUM(Quantity + Quantity1) as count from ddzls where DDBH = '{0}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString());
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
                                string sql6 = string.Format("select CLSL from XXZLSVN left join DDZL on XXZLSVN.XieXing = DDZL.XieXing and XXZLSVN.SheHao = DDZL.SheHao where DDBH = '{0}' and BWBH = '{1}' and CLBH = '{2}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString());
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
                                DBconnect con4 = new DBconnect();
                                StringBuilder sql4 = new StringBuilder();
                                sql4.AppendFormat("update zlzls2 set YN = 0 where ZLBH = '{0}' and BWBH = '{1}' and CLBH = '{2}' and ver = '{3}'", dgvOldZlzls21.Rows[i].Cells[0].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[1].Value.ToString(), dgvOldZlzls21.Rows[i].Cells[2].Value.ToString(), ver);
                                Console.WriteLine(sql4);
                                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                con4.OpenConnection();
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }



                            }

                            //插入剩餘資料
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select ZLZL.ZLBH, 'VN' as XH, XXZLSVN.BWBH, XXZLSVN.CSBH, 'ZZZZZZZZZZ' as MJBH, XXZLSVN.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE, (DDZLs.Quantity + DDZLs.Quantity1) * XXZLSVN.CLSL as CLSL, XXZLSVN.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE,             '2' as YN, 1 as ver from XXZLSVN left join DDZL on XXZLSVN.XIEXING = DDZL.XIEXING AND XXZLSVN.SHEHAO = DDzl.SHEHAO  LEFT join DDZLs on DDZL.DDBH = DDZLs.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join zlzls2 on DDZL.DDBH = zlzls2.ZLBH left join CLZL on CLZL.CLDH = XXZLSVN.CLBH where zlZL.ZLBH = '{1}' and zlzls2.clbh is null", userid, dataGridView1.Rows[j].Cells[1].Value.ToString());
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            conn.CloseConnection();

                        }



                    }

                }
                MessageBox.Show("計算完成");
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0003)
                {
                    DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        DBconnect con = new DBconnect();
                        StringBuilder sql = new StringBuilder();
                        sql.AppendFormat("delete xxzlsvn where XieXing = '{0}' and SheHao = '{1}'  and BWBH = '{2}' and CLBH = '{3}' and CSBH = '{4}'", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView4.CurrentRow.Cells[2].Value.ToString(), dataGridView4.CurrentRow.Cells[3].Value.ToString(), dataGridView4.CurrentRow.Cells[4].Value.ToString());
                        Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                        con.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con.CloseConnection();
                    }
                }
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

                //textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox16.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                //textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                //textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                //textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception) { }
        }
    }
}
