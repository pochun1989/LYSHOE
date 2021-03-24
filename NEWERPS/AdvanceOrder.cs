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
    public partial class AdvanceOrder : Form
    {
        public AdvanceOrder()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "31912";
        DataSet ds = new DataSet();
        DataSet dsSize = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        DataSet dsL3 = new DataSet();
        DataSet dsL2 = new DataSet();
        DataSet dsLL = new DataSet();
        DataSet dsL4 = new DataSet();
        //string ddbh = "";
        Boolean insert = true;

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "070200";

        #endregion

        #region 方法

        private void mainload() 
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("Select * from DDZL where DDZT = 'Y' and DDLB = 'F' and DDBH like '%{0}%' and KHBH like '%{1}%' and ddzl.ShipDate BETWEEN  DATEADD (day , 0 , '{2}') and DATEADD (day , 1 , '{3}')", textBox1.Text, comboBox1.SelectedValue, dateTimePicker2.Text, dateTimePicker1.Text);
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection); 
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
        }

        private void insertload() 
        {
            try
            {
                dsL4 = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("select distinct DDZL.DDBH,DDZL.KHPO,DDZL.FinishedDay,DDZL.ShipDate,DESTINATION.ywsm,DDZL.DDGB,DDZL.XieXing,DDZL.SheHao,xxzl.XieMing from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where MDDBH = '{0}' and ddzt != 'C'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL4, "棧板表");
                dataGridView4.DataSource = dsL4.Tables[0];
            }
            catch (Exception) { }
        }

        private void insertddzls()
        {
            try
            {
                string gender = "", khdh = "";
                string Xie = "", She = "";
                Xie = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                She = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
                int linenum = 0;
                string num = "";

                for (int k = 0; k < dgvSize.Rows.Count; k++)
                {
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

                    #region NEWERP

                    int result11;
                    DBconnect conn11 = new DBconnect();
                    string sql11 = string.Format("insert into DDZLs (DDBH,LineNum,CC,Quantity,Price,CPrice,IPrice,USERID,USERDATE,Quantity1,mtdj,YN,Quantity2,TestQty) values('{0}','{1}','{2}','0','0','0','0','{3}',GETDATE(),'0','0','1','0','0')", tbDDBH.Text.Trim(), num, dgvSize.Rows[k].Cells[0].Value.ToString(), userid);
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

                    #endregion

                    #region LYSHOE

                    int result11Y;
                    DBconnect conn11Y = new DBconnect();
                    string sql11Y = string.Format("delete DDZLs where DDBH = '{0}'insert into ddzls SELECT[DDBH],[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID], CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) ,[Quantity1],[mtdj],[Quantity2],[TestQty] FROM [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{0}'", tbDDBH.Text.Trim());
                    Console.WriteLine(sql11Y);

                    SqlCommand cmd11Y = new SqlCommand(sql11Y, conn11Y.connection);
                    conn11Y.OpenConnection();
                    result11Y = cmd11Y.ExecuteNonQuery();
                    if (result11Y == 1)
                    {
                    }
                    conn11Y.CloseConnection();

                    #endregion
                }
            }
            catch (Exception) 
            {
                //MessageBox.Show("No SizeRun");
            }
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
                //L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                //L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                //L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();               
            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {
                P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #endregion

        #region 畫面載入

        private void AdvanceOrder_Load(object sender, EventArgs e)
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

            DBconnect dbconn2 = new DBconnect();
            string sql12 = "select * from DESTINATION";
            SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
            adapter12.Fill(dsc2, "倉庫");

            cbDest.DataSource = dsc2.Tables[0];
            cbDest.ValueMember = "DESTINATION_ID";
            cbDest.DisplayMember = "ywsm";
            cbDest.MaxDropDownItems = 8;
            cbDest.IntegralHeight = false;

            DBconnect dbconn4 = new DBconnect();
            string sql14 = "select * from COUNTRY";
            SqlDataAdapter adapter14 = new SqlDataAdapter(sql14, dbconn4.connection);
            adapter14.Fill(dsc4, "倉庫");

            cbCountry.DataSource = dsc4.Tables[0];
            cbCountry.ValueMember = "COUNTRY_ID";
            cbCountry.DisplayMember = "ywsm";
            cbCountry.MaxDropDownItems = 8;
            cbCountry.IntegralHeight = false;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            //ChangeLabel();
            //ChangeDataView();
            //ChangeTabControl();
            //dataGridView4.Columns[0].Width = 200;
        }

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {
                    mainload();

                    dataGridView1.Columns[0].Width = 200;
                }
                else if (tabControl1.SelectedTab == P0002) 
                {

                }
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001) 
                {
                }
                else if (tabControl1.SelectedTab == P0002)
                {

                    DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZL set DDZT = 'C',USERID = '{0}',USERDATE = GETDATE() where DDBH = '{1}'", userid, dataGridView4.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("刪除資料成功");
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZL set DDZT = 'C',USERID = '{0}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) where DDBH = '{1}'", userid, dataGridView4.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);
                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("刪除資料成功");
                        }
                        con4Y.CloseConnection();

                        #endregion

                        insertload();
                    }
                }
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                insert = true;

                tbDDBH.Enabled = true;
                tbKFBH.Enabled = true;
                //tbKHPO.Enabled = true;
                //dtpFrom.Enabled = true;
                //dtpTo.Enabled = true;
                //cbDest.Enabled = true;
                //cbCountry.Enabled = true;

                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;

                tabControl1.SelectedTab = P0002;
                tbDDBH.Text = "";
                tbKFBH.Text = "";
                tbKHPO.Text = "";
                cbDest.SelectedIndex = 0;
                cbCountry.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbKFBH.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                //textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dsL2 = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("select * from DDZLS where DDBH = '{0}'", dataGridView4.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL2, "棧板表");
                dataGridView3.DataSource = dsL2.Tables[0];

                tbDDBH.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                tbKHPO.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();


                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[1].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.Columns[7].Visible = false;
                dataGridView3.Columns[8].Visible = false;
                dataGridView3.Columns[10].Visible = false;
                dataGridView3.Columns[11].Visible = false;
                dataGridView3.Columns[12].Visible = false;
                dataGridView3.Columns[13].Visible = false;

                dataGridView3.Columns[9].HeaderText = "sample";
            }
            catch (Exception) { }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            ////取出GENDER
            //string gender = "";
            //DBconnect dbConn4 = new DBconnect();
            //string sql4 = string.Format("select gender from DDZL where DDBH = '{0}'", textBox2.Text);
            //Console.WriteLine(sql4);
            //SqlCommand cmd4 = new SqlCommand(sql4, dbConn4.connection);
            //dbConn4.OpenConnection();
            //SqlDataReader reader4 = cmd4.ExecuteReader();
            //if (reader4.Read())
            //{
            //    gender = reader4["gender"].ToString();
            //}
            //dbConn4.CloseConnection();

            //double ss = 0, es = 0, com = 0;
            //DBconnect dbConn5 = new DBconnect();
            //string sql5 = string.Format("select Star_Size,End_Size,COMDIF from gender where GENDER_id = '{0}'", gender);
            //Console.WriteLine(sql5);
            //SqlCommand cmd5 = new SqlCommand(sql5, dbConn5.connection);
            //dbConn5.OpenConnection();
            //SqlDataReader reader5 = cmd5.ExecuteReader();
            //if (reader5.Read())
            //{
            //    ss = double.Parse(reader5["Star_Size"].ToString());
            //    es = double.Parse(reader5["End_Size"].ToString());
            //    com = double.Parse(reader5["COMDIF"].ToString());
            //}
            //dbConn5.CloseConnection();


            //while (ss <= es)
            //{
            //    Console.WriteLine(ss);
            //    ss += com;
            //}
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
                    tsbCopy.Enabled = false;

                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        insertload();

                        tbDDBH.Enabled = false;
                        tbKFBH.Enabled = false;
                        tbKHPO.Enabled = false;
                        dtpFrom.Enabled = false;
                        dtpTo.Enabled = false;
                        cbDest.Enabled = false;
                        cbCountry.Enabled = false;

                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;

                        tsbDelete.Enabled = true;
                        tsbConfirm.Enabled = false;
                        dataGridView4.Columns[0].Width = 200;
                    }
                    else
                    {
                        MessageBox.Show("沒有訂單號");
                        tabControl1.SelectedTab = P0001;
                    }
                }
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            insert = false;
            tsbInsert.Enabled = false;
            tsbModify.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            cbDest.Enabled = true;
            cbCountry.Enabled = true;
            tbKHPO.Enabled = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0002)
                {
                    if (insert == false)
                    {
                        #region DDZL

                        //update DDZL
                        Console.WriteLine(dtpFrom.Value.ToString());
                        Console.WriteLine(dtpTo.Value.ToString());
                        Console.WriteLine(cbDest.SelectedValue);
                        Console.WriteLine(cbCountry.SelectedValue);

                        #region NEWERP

                        DBconnect con5 = new DBconnect();
                        StringBuilder sql5 = new StringBuilder();
                        sql5.AppendFormat("update DDZL set FinishedDay = '{0}', ShipDate = '{1}', Dest = '{2}', DDGB = '{3}',KHPO = '{5}' where DDBH = '{4}'", dtpFrom.Value.ToString("yyyy/MM/dd"), dtpTo.Value.ToString("yyyy/MM/dd"), cbDest.SelectedValue, cbCountry.SelectedValue, textBox2.Text, tbDDBH.Text);
                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {
                            MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con5.CloseConnection();

                        #endregion

                        #region LYSHOE 

                        Console.WriteLine(dtpTo.Value.ToString("yyyyMMdd"));

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("update DDZL set ShipDate = '{1}', Dest = '{2}', DDGB = '{3}',KHPO = '{5}' where DDBH = '{4}'", dtpFrom.Value.ToString("yyyyMMdd"), dtpTo.Value.ToString("yyyyMMdd"), cbDest.SelectedValue, cbCountry.SelectedValue, textBox2.Text, tbDDBH.Text);
                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {
                            //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con5Y.CloseConnection();

                        #endregion

                        #endregion
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        dtpFrom.Enabled = false;
                        dtpTo.Enabled = false;
                        cbDest.Enabled = false;
                        cbCountry.Enabled = false;
                        tbKHPO.Enabled = false;
                        insertload();
                    }
                    else 
                    {
                        if (tbDDBH.Text != "")
                        {
                            OrderCheck oc = new OrderCheck();

                            if (oc.check(tbDDBH.Text.Trim()) == true)
                            {
                                if (tabControl1.SelectedTab == P0002)
                                {
                                    tbDDBH.Enabled = false;
                                    tbKFBH.Enabled = false;
                                    tbKHPO.Enabled = false;
                                    dtpFrom.Enabled = false;
                                    dtpTo.Enabled = false;
                                    cbDest.Enabled = false;
                                    cbCountry.Enabled = false;

                                    tsbModify.Enabled = true;
                                    tsbCancel.Enabled = false;
                                    tsbSave.Enabled = false;
                                    tsbInsert.Enabled = true;

                                    insert = true;

                                    string no = "";
                                    int count = 0;
                                    int max = 0;
                                    string ddbhload = "";

                                    #region NEWERP

                                    //insert
                                    int result;
                                    DBconnect conn = new DBconnect();
                                    string sql = string.Format("insert into DDZL select '{0}', DDZT,XieXing,SheHao,Version,ARTICLE,CCGB,KHBH,BB,KHPO,Trader,TraderPO,'N',CPLB,BZFS,Dest,DDGB,DDRQ,'{3}',JYTJ,FKTJ,ShipDate,Pairs,Totals,ZLBH,GSDH,CFNO,'{1}',GETDATE(),DDCZ,DDPACKSM,LABELCHARGE,Gender,SC01,SC02,PUMAPO,Pairs1,balance,mtgr,mtyf,BUYNO,YN,Pairs,balance2,KFJD,RYTYPE,FCD,FinishedDay,UsageVer from DDZL where DDBH = '{2}'", tbDDBH.Text.Trim(), userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                    Console.WriteLine(sql);
                                    SqlCommand cmd = new SqlCommand(sql, conn.connection);
                                    conn.OpenConnection();
                                    result = cmd.ExecuteNonQuery();
                                    if (result == 1)
                                    {

                                    }
                                    conn.CloseConnection();

                                    #endregion


                                    #region ddzls

                                    insertddzls();


                                    #endregion

                                    #region LYSHOE

                                    int resultY;
                                    DBconnect2 connY = new DBconnect2();
                                    string sqlY = string.Format("delete DDZLs where DDBH = '{0}' insert into ddzls SELECT[DDBH],[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID], CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) ,[Quantity1],[mtdj],[Quantity2],[TestQty] FROM  [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{0}' ", tbDDBH.Text.Trim());
                                    Console.WriteLine(sqlY);
                                    SqlCommand cmdY = new SqlCommand(sqlY, connY.connection);
                                    connY.OpenConnection();
                                    resultY = cmdY.ExecuteNonQuery();
                                    if (resultY == 1)
                                    {
                                    }
                                    connY.CloseConnection();

                                    int resultY2;
                                    DBconnect2 connY2 = new DBconnect2();
                                    string sqlY2 = string.Format("delete OrderSplit where ddbh = '{0}' insert into OrderSplit select ddbh, Pairs, null, MDDBH, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from  [192.168.11.15].New_Erp.dbo.DDZL where mddbh = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                    Console.WriteLine(sqlY2);
                                    SqlCommand cmdY2 = new SqlCommand(sqlY2, connY2.connection);
                                    connY2.OpenConnection();
                                    resultY2 = cmdY2.ExecuteNonQuery();
                                    if (resultY2 == 1)
                                    {

                                    }
                                    connY2.CloseConnection();

                                    #endregion

                                    insertload();


                                }
                            }
                            else 
                            {
                                MessageBox.Show("DDBH Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO DDBH");
                        }
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("SAVE ERROR");
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tbDDBH.Enabled = false;
            tbKFBH.Enabled = false;
            tbKHPO.Enabled = false;
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            cbDest.Enabled = false;
            cbCountry.Enabled = false;
            tbKHPO.Enabled = false;
            tabControl1.SelectedTab = P0001;
        }

        private void L0073_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = false;
            L0074.Enabled = true;
            L0075.Enabled = true;
        }

        private void L0074_Click(object sender, EventArgs e)
        {
            try
            {
                double pairs = 0, price = 0;

                int a = 0;
                a = dsL2.Tables[0].Rows.Count;
                Console.WriteLine(a);

                for (int i = 0; i < a; i++)
                {
                    if (dsL2.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                    {

                    }
                    else if (dsL2.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZLs set IPrice = '{0}', USERID = '{1}' , USERDATE = GETDATE(),Quantity = '{5}',Quantity1 = '{6}' where DDBH = '{2}' and LineNum = '{3}' and CC = '{4}'", dataGridView3.Rows[i].Cells[6].Value.ToString(), userid, dataGridView3.Rows[i].Cells[0].Value.ToString(), dataGridView3.Rows[i].Cells[1].Value.ToString(), dataGridView3.Rows[i].Cells[2].Value.ToString(), dataGridView3.Rows[i].Cells[3].Value.ToString(), dataGridView3.Rows[i].Cells[9].Value.ToString());

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
                        sql4Y.AppendFormat("update DDZLs set IPrice = '{0}', USERID = '{1}' , USERDATE = CAST(year(getdate()) as NVARCHAR) + RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2) + RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2), Quantity = '{5}',Quantity1 = '{6}' where DDBH = '{2}' and LineNum = '{3}' and CC = '{4}'", dataGridView3.Rows[i].Cells[6].Value.ToString(), userid, dataGridView3.Rows[i].Cells[0].Value.ToString(), dataGridView3.Rows[i].Cells[1].Value.ToString(), dataGridView3.Rows[i].Cells[2].Value.ToString(), dataGridView3.Rows[i].Cells[3].Value.ToString(), dataGridView3.Rows[i].Cells[9].Value.ToString());

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

                    pairs += double.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());

                    price += double.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString()) * double.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());

                }
                Console.WriteLine(pairs);
                Console.WriteLine(price);

                //tb總雙數.Text = pairs.ToString();
                //tb總金額.Text = price.ToString();

                //update總數、總價
                #region NEWERP

                DBconnect con = new DBconnect();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("update DDZL set Pairs = '{0}' , Totals = '{1}',USERID = '{2}',USERDATE = GETDATE() where DDBH = '{3}'", pairs, price, userid, dataGridView4.CurrentRow.Cells[0].Value.ToString());

                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);
                con.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {

                }
                con.CloseConnection();

                #endregion

                #region LYSHOE

                DBconnect2 conY = new DBconnect2();
                StringBuilder sqlY = new StringBuilder();
                sqlY.AppendFormat("update DDZL set Pairs = '{0}' , Totals = '{1}',USERID = '{2}',USERDATE = CAST(year(getdate()) as NVARCHAR) + RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2) + RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{3}'", pairs, price, userid, dataGridView4.CurrentRow.Cells[0].Value.ToString());

                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                conY.OpenConnection();
                int resultY = cmdY.ExecuteNonQuery();
                if (resultY == 1)
                {
                }
                conY.CloseConnection();

                #endregion

                dataGridView3.ReadOnly = true;
                L0074.Enabled = false;
                L0075.Enabled = false;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderSizeInsert Form = new OrderSizeInsert();
            Form.tbDDBH.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            Form.ShowDialog();

            #region LOAD

            dsL2 = new DataSet();
            DBconnect dbConnL = new DBconnect();
            string sqlL = string.Format("select * from DDZLS where DDBH = '{0}'", dataGridView4.CurrentRow.Cells[0].Value.ToString());
            Console.WriteLine(sqlL);
            SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
            adapterL.Fill(dsL2, "棧板表");
            dataGridView3.DataSource = dsL2.Tables[0];

            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[11].Visible = false;
            dataGridView3.Columns[12].Visible = false;
            dataGridView3.Columns[13].Visible = false;

            dataGridView3.Columns[9].HeaderText = "sample";
            #endregion
        }

        #endregion

        private void L0075_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.ReadOnly = true;
                L0074.Enabled = false;
                L0075.Enabled = false;
            }
            catch (Exception) { }
        }
    }
}
