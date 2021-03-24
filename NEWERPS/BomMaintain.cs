using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEWERPS
{
    public partial class BomMaintain : Form
    {
        public BomMaintain()
        {
            InitializeComponent();
        }

        #region 變數
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsb = new DataSet();
        DataSet dsb2 = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        public string userid = "";
        string bomcopy;
        string sqlback = "";
        string dgv1select = "";
        #endregion

        #region 畫面載入

        private void BomMaintain_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                dsc1 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from gjzl where gjlb = '100'";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dsc1, "倉庫");

                cb楦頭.DataSource = dsc1.Tables[0];
                cb楦頭.ValueMember = "gjmh";
                cb楦頭.DisplayMember = "gjmh";
                cb楦頭.MaxDropDownItems = 8;
                cb楦頭.IntegralHeight = false;

                //dsc2 = new DataSet();
                //DBconnect dbconn2 = new DBconnect();
                //string sql2 = "select * from gjzl where gjlb = '101'";
                //SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbconn2.connection);
                //adapter2.Fill(dsc2, "倉庫");

                //comboBox2.DataSource = dsc2.Tables[0];
                //comboBox2.ValueMember = "gjmh";
                //comboBox2.DisplayMember = "gjmh";
                //comboBox2.MaxDropDownItems = 8;
                //comboBox2.IntegralHeight = false;

                dsc3 = new DataSet();
                DBconnect dbconn3 = new DBconnect();
                string sql3 = "select * from gjzl where gjlb = '102'";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbconn3.connection);
                adapter3.Fill(dsc3, "倉庫");

                cbMS.DataSource = dsc3.Tables[0];
                cbMS.ValueMember = "gjmh";
                cbMS.DisplayMember = "gjmh";
                cbMS.MaxDropDownItems = 8;
                cbMS.IntegralHeight = false;

                //dsc4 = new DataSet();
                //DBconnect dbconn4 = new DBconnect();
                //string sql4 = "select * from gjzl where gjlb = '200'";
                //SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbconn4.connection);
                //adapter4.Fill(dsc4, "倉庫");

                //comboBox4.DataSource = dsc4.Tables[0];
                //comboBox4.ValueMember = "gjmh";
                //comboBox4.DisplayMember = "gjmh";
                //comboBox4.MaxDropDownItems = 8;
                //comboBox4.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 方法

        #region 搜尋

        private void Search() 
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from xxzl where XieXing like '%{0}%' and SheHao like '%{1}%' and XieMing like '%{2}%' and JiJie like '%{3}%' and KHDH like '%{4}%' and ARTICLE like '%{5}%'", tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, textBox8.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView4.DataSource = ds.Tables[0];
                dbConn11.CloseConnection();
                sqlback = sql1;                
            }
            catch (Exception) { }
        }

        #endregion

        #region COPYQuery

        private void CopyQuery()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from xxzl where XieXing = '{0}'", textBox7.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds, "棧板表");

                dataGridView4.DataSource = ds.Tables[0];
                dbConn11.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region updateUSAGER

        private void UpdateUsageR()
        {
            try
            {
                //新增

                //取出版本號
                string ver = "";
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select MAX(VER) as VER from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}' ", textBox7.Text, textBox6.Text, dataGridView4.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql3);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    ver = reader3["VER"].ToString();
                }
                dbConn3.CloseConnection();
                Console.WriteLine(ver);

                int resultI;
                DBconnect connI = new DBconnect();
                string sqlI = string.Format("insert Usage_R(XieXing,SheHao,BWBH,XTCC,VER,CLSL,USERDATE,USERID,xxzlver)(select XieXing,SheHao,BWBH,XTCC, {2}+1,CLSL,GETDATE(),USERID,xxzlver from Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and xxzlver = '{4}')", textBox7.Text, textBox6.Text, ver, userid, dataGridView4.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sqlI);

                SqlCommand cmdI = new SqlCommand(sqlI, connI.connection);
                connI.OpenConnection();
                resultI = cmdI.ExecuteNonQuery();
                if (resultI == 1)
                {

                }
                connI.CloseConnection();

                //update
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    //Console.WriteLine(dataGridView2.Rows[i].Cells[2].Value.ToString());
                    //Console.WriteLine(textBox7.Text);
                    //Console.WriteLine(textBox6.Text);
                    //Console.WriteLine(dgv1select);
                    //Console.WriteLine(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    //Console.WriteLine(ver);
                    //Console.WriteLine(dataGridView4.CurrentRow.Cells[2].Value.ToString());
                    //修改
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update Usage_R set CLSL = '{0}',USERID = '{7}' where XieXing = '{1}' and SheHao = '{2}' and BWBH = '{3}' and XTCC = '{4}' and VER = {5}+1 and xxzlver = '{6}'", dataGridView2.Rows[i].Cells[2].Value.ToString(), textBox7.Text, textBox6.Text, dgv1select, dataGridView2.Rows[i].Cells[0].Value.ToString(), ver, dataGridView4.CurrentRow.Cells[2].Value.ToString(), userid);
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();
                }
                int a = 0;
                a = int.Parse(ver);
                a = a + 1;
                tbUsage.Text = a.ToString();

                #region LYSHOE                

                int resultIY;
                DBconnect2 connIY = new DBconnect2();
                string sqlIY = string.Format("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}' insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and xxzlver = '{3}'", textBox7.Text, textBox6.Text, a, dataGridView4.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sqlIY);

                SqlCommand cmdIY = new SqlCommand(sqlIY, connIY.connection);
                connIY.OpenConnection();
                resultIY = cmdIY.ExecuteNonQuery();
                if (resultIY == 1)
                {
                }
                connIY.CloseConnection();

                #endregion

                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception) 
            {
                MessageBox.Show("修改資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region SAVE2

        private void savexxzls()
        {
            try
            {
                int a = 0;
                a = dsb.Tables[0].Rows.Count;
                Console.WriteLine(a);

                DialogResult dr = MessageBox.Show("確定要修改嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    #region NEWERP

                    DBconnect con5 = new DBconnect();
                    StringBuilder sql5 = new StringBuilder();
                    sql5.AppendFormat("update xxzl set VER = VER +1, USERID = '{0}', USERDATE = GETDATE()  where XieXing = '{1}' and SheHao = '{2}'", userid, textBox2.Text, textBox1.Text);
                    Console.WriteLine(sql5);
                    SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                    con5.OpenConnection();
                    int result5 = cmd5.ExecuteNonQuery();
                    if (result5 == 1)
                    {

                    }
                    con5.CloseConnection();

                    #endregion

                    #region LYSHOE

                    DBconnect2 con5Y = new DBconnect2();
                    StringBuilder sql5Y = new StringBuilder();
                    sql5Y.AppendFormat("update xxzl set USERID = '{0}', USERDATE = CONVERT(varchar,GETDATE(),11)  where XieXing = '{1}' and SheHao = '{2}'", userid, textBox2.Text, textBox1.Text);
                    Console.WriteLine(sql5Y);
                    SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                    con5Y.OpenConnection();
                    int result5Y = cmd5Y.ExecuteNonQuery();
                    if (result5Y == 1)
                    {
                    }
                    con5Y.CloseConnection();

                    #endregion

                    string ver = "";
                    DBconnect dbConn3 = new DBconnect();
                    string sql3 = string.Format("select MAX(VER) as VER from xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox2.Text, textBox1.Text);
                    Console.WriteLine(sql3);
                    SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                    dbConn3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.Read())
                    {
                        ver = reader3["VER"].ToString();
                    }
                    dbConn3.CloseConnection();
                    Console.WriteLine("VER:" + ver);

                    //Insert 新版
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql = string.Format("insert xxzls select XieXing,SheHao,'{0}',BWBH,BWLB,xh,CLBH,CSBH,CLTX,CCQQ,CCQZ,LOSS,CLSL,CLDJ,Currency,Remark,USERID,GETDATE(),JGZWSM,JGYWSM,YN from xxzls  where XieXing = '{2}' and SheHao = '{3}' and VER = ({4}-1)", ver, userid, textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sql);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn.CloseConnection();

                    //update YN
                    DBconnect conm2 = new DBconnect();
                    StringBuilder sqlm2 = new StringBuilder();
                    sqlm2.AppendFormat("update xxzls set YN = 0 where XieXing = '{0}' and SheHao = '{1}' and VER <> '{2}'", textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sqlm2);
                    SqlCommand cmdm2 = new SqlCommand(sqlm2.ToString(), conm2.connection);

                    conm2.OpenConnection();
                    int resultm2 = cmdm2.ExecuteNonQuery();
                    if (resultm2 == 1)
                    {

                    }
                    conm2.CloseConnection();

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sqlY = string.Format("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID],CONVERT(varchar,USERDATE,11),[JGZWSM],[JGYWSM] FROM [192.168.11.15].New_Erp.[dbo].[xxzls] where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sqlY);

                    SqlCommand cmd1Y = new SqlCommand(sqlY, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connY.CloseConnection();

                    #endregion
                                       
                    //insert usager

                    string usagever = "";
                    DBconnect dbConn31 = new DBconnect();
                    string sql31 = string.Format("select MAX(ver) as ver from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = {2}-1", textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sql31);
                    SqlCommand cmd31 = new SqlCommand(sql31, dbConn31.connection);
                    dbConn31.OpenConnection();
                    SqlDataReader reader31 = cmd31.ExecuteReader();
                    if (reader31.Read())
                    {
                        usagever = reader31["ver"].ToString();
                    }
                    dbConn31.CloseConnection();

                    #region NEWERP

                    int resultur;
                    DBconnect connur = new DBconnect();
                    string sqlur = string.Format("insert Usage_R select XieXing, SheHao, BWBH, XTCC, 1, CLSL, GETDATE(), USERID, '{3}' from Usage_R where XieXing = '{1}' and SheHao = '{2}' and xxzlver = {3}-1 and ver = '{4}'", userid, textBox2.Text, textBox1.Text, ver, usagever);
                    Console.WriteLine(sqlur);

                    SqlCommand cmd1ur = new SqlCommand(sqlur, connur.connection);
                    connur.OpenConnection();
                    resultur = cmd1ur.ExecuteNonQuery();
                    if (resultur == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connur.CloseConnection();

                    #endregion

                    #region LYSHOE

                    int resulturY;
                    DBconnect2 connurY = new DBconnect2();
                    string sqlurY = string.Format("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}'  insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '1' and xxzlver = '{2}'", textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sqlurY);

                    SqlCommand cmd1urY = new SqlCommand(sqlurY, connurY.connection);
                    connurY.OpenConnection();
                    resulturY = cmd1urY.ExecuteNonQuery();
                    if (resulturY == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connurY.CloseConnection();

                    #endregion


                    for (int i = 0; i < a; i++)
                    {
                        Console.WriteLine(dsb.Tables[0].Rows[i].RowState.ToString());
                        if (dsb.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                        {

                        }
                        else if (dsb.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                        {
                            string d34 = "", d313 = "";
                            if (dataGridView3.Rows[i].Cells[4].Value.ToString() == "一般")
                            {
                                d34 = "1";
                            }
                            else if (dataGridView3.Rows[i].Cells[4].Value.ToString() == "外包裝")
                            {
                                d34 = "2";
                            }
                            else if (dataGridView3.Rows[i].Cells[4].Value.ToString() == "特殊")
                            {
                                d34 = "3";
                            }

                            if (dataGridView3.Rows[i].Cells[13].Value.ToString() == "One On One")
                            {
                                d313 = "1";
                            }
                            else if (dataGridView3.Rows[i].Cells[13].Value.ToString() == "分段")
                            {
                                d313 = "2";
                            }
                            else if (dataGridView3.Rows[i].Cells[13].Value.ToString() == "No Size")
                            {
                                d313 = "3";
                            }

                            Console.WriteLine(dataGridView3.Rows[i].Cells[5].Value.ToString());
                            Console.WriteLine(dataGridView3.Rows[i].Cells[10].Value.ToString());

                            //update xxzls                    
                            DBconnect conm = new DBconnect();
                            StringBuilder sqlm = new StringBuilder();
                            sqlm.AppendFormat("update xxzls set BWBH = '{0}',BWLB = '{1}',CLBH = '{2}',CSBH = '{3}',CLTX = '{4}', LOSS = '{5}',CLSL = '{6}',USERID = '{12}' where XieXing = '{7}' and SheHao = '{8}' and BWBH = '{9}' and CLBH = '{10}' and VER = '{11}'", dataGridView3.Rows[i].Cells[2].Value.ToString(), d34, dataGridView3.Rows[i].Cells[5].Value.ToString(), dataGridView3.Rows[i].Cells[10].Value.ToString(), d313, dataGridView3.Rows[i].Cells[12].Value.ToString(), dataGridView3.Rows[i].Cells[13].Value.ToString(), textBox2.Text, textBox1.Text, dataGridView5.Rows[i].Cells[2].Value.ToString(), dataGridView5.Rows[i].Cells[5].Value.ToString(), ver, userid);
                            Console.WriteLine(sqlm);
                            SqlCommand cmdm = new SqlCommand(sqlm.ToString(), conm.connection);

                            conm.OpenConnection();
                            int resultm = cmdm.ExecuteNonQuery();
                            if (resultm == 1)
                            {

                            }
                            conm.CloseConnection();
                        }
                        else if (dsb.Tables[0].Rows[i].RowState.ToString() == "Deleted")//刪除過
                        {

                        }
                    }

                    #region LYSHOE

                    DBconnect2 conmY = new DBconnect2();
                    StringBuilder sqlmY = new StringBuilder();
                    sqlmY.AppendFormat("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID],CONVERT(varchar,USERDATE,11),[JGZWSM],[JGYWSM] FROM [192.168.11.15].New_Erp.[dbo].[xxzls] where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", textBox2.Text, textBox1.Text, ver);
                    Console.WriteLine(sqlmY);
                    SqlCommand cmdmY = new SqlCommand(sqlmY.ToString(), conmY.connection);

                    conmY.OpenConnection();
                    int resultmY = cmdmY.ExecuteNonQuery();
                    if (resultmY == 1)
                    {

                    }
                    conmY.CloseConnection();

                    #endregion
                }

            }
            catch (Exception) { }
        }

        #endregion

        #region SAVE2

        private void savexxzl()
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要修改嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    #region newerp

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update xxzl set XTMH = '{0}',  DDMH = '{1}', MDMH = '{2}', DAOMH = '{3}',VER = VER +1, USERID = '{4}',USERDATE = GETDATE() where XieXing = '{5}'  and SheHao = '{6}'", cb楦頭.Text, cb底模.Text, cbMS.Text, cb面刀.Text, userid, textBox4.Text, textBox3.Text);
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        MessageBox.Show("儲存成功");
                    }
                    con4.CloseConnection();

                    #endregion

                    #region LYSHOE

                    DBconnect2 con4Y = new DBconnect2();
                    StringBuilder sql4Y = new StringBuilder();
                    sql4Y.AppendFormat("delete xxzl where XieXing = '{0}' and SheHao = '{1}' insert into xxzl SELECT[XieXing],[SheHao],[XieMing],[YSSM],[JiJie],[CLID],[ARTICLE],[BZCC],[XieGN],[KFCQ],[LOGO],[KHDH],[CCGB],[XTGJ],[XTMH],[DMGJ],[DDMH],[MSGJ],[MDMH],[DAOGJ],[DAOMH],[IMGName],[Currency],[QPrice],[OPrice],[IPrice],[CPrice],[USERID],CONVERT(varchar,USERDATE,11),[KFXXCZ],[KFXXCZ1],[KFXXCZ2] ,[KFXXCZ3],[GENDER],[pp],[memo1],[JiJie1],[MTF],[JZF],[xxlock] FROM New_Erp.[dbo].[xxzl] where XieXing = '{0}' and SheHao = '{1}'", textBox4.Text, textBox3.Text);
                    Console.WriteLine(sql4Y);
                    SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                    con4Y.OpenConnection();
                    int result4Y = cmd4Y.ExecuteNonQuery();
                    if (result4Y == 1)
                    {
                        //MessageBox.Show("儲存成功");
                    }
                    con4Y.CloseConnection();

                    #endregion
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV, string xiexing, string shehao, int bom, int usage)
        {
            try
            {
                if (0 == 0)
                {
                    DataSet dsexcel = new DataSet();
                    DataSet dsexcel2 = new DataSet();
                    DataSet dsexcel3 = new DataSet();
                    DataSet dsexcel4 = new DataSet();
                    DataSet dsexcel5 = new DataSet();
                    DataSet dsexcel6 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    DBconnect dbConn2 = new DBconnect();

                    Excel.Range wRange; //合併儲存格變數

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


                    string sql = string.Format("select * from xxzl where XieXing = '{0}' and SheHao = '{1}'", xiexing, shehao);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsexcel, "前身");


                    worksheet.Cells[1, 1] = "ART. NAME:";
                    worksheet.Cells[1, 2] = dsexcel.Tables[0].Rows[0][3].ToString();

                    worksheet.Cells[2, 1] = "ART. NO:";
                    worksheet.Cells[2, 2] = dsexcel.Tables[0].Rows[0][7].ToString();

                    worksheet.Cells[3, 1] = "MODEL#";
                    worksheet.Cells[3, 2] = dsexcel.Tables[0].Rows[0][0].ToString();
                    wRange = worksheet.Range[worksheet.Cells[3, 2], worksheet.Cells[3, 4]];
                    wRange.Select();
                    wRange.MergeCells = true;


                    worksheet.Cells[3, 5] = "Color:";
                    worksheet.Cells[3, 6] = dsexcel.Tables[0].Rows[0][1].ToString();

                    worksheet.Cells[4, 1] = "Part#";
                    worksheet.Cells[4, 2] = "Description";
                    wRange = worksheet.Range[worksheet.Cells[4, 2], worksheet.Cells[4, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[4, 4] = "Material description";
                    wRange = worksheet.Range[worksheet.Cells[4, 4], worksheet.Cells[4, 8]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[4, 9] = "Unit";

                    DBconnect dbConn3 = new DBconnect();
                    string sql3 = string.Format("select distinct XTCC from Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and xxzlver = '{3}'", xiexing, shehao, bom, usage);
                    Console.WriteLine(sql3);
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                    adapter3.Fill(dsexcel3, "SIZE");

                    List<string> myStringLists = new List<string>();

                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                    {
                        worksheet.Cells[4, 10 + i] = dsexcel3.Tables[0].Rows[i][0].ToString();

                        string xtcc = "";
                        xtcc = "a" + i;
                        myStringLists.Add(xtcc);
                    }

                    DBconnect dbConn5 = new DBconnect();
                    string sql5 = string.Format("select XieXing,SheHao,BWBH ");
                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                    {
                        sql5 += string.Format(", sum(" + myStringLists[i] + ") as '" + dsexcel3.Tables[0].Rows[i][0].ToString() + "'");
                    }
                    sql5 += string.Format("from (select xs.XieXing, xs.SheHao, xs.BWBH ");
                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                    {
                        sql5 += string.Format(",case when xtcc = '" + dsexcel3.Tables[0].Rows[i][0].ToString() + "' then ur.clsl end as '" + myStringLists[i] + "'");
                    }
                    sql5 += string.Format("from xxzls xs left join Usage_R ur on xs.xiexing = ur.XieXing and xs.bwbh = ur.BWBH and ur.xxzlver = '{2}' and ur.ver= '{3}' where ur.XieXing = '{0}' and ur.shehao = '{1}' and ur.xxzlver = '{2}') aa   group by XieXing, SheHao, BWBH", xiexing, shehao, bom, usage);
                    Console.WriteLine(sql5);

                    SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn5.connection);
                    adapter5.Fill(dsexcel5, "SIZE");
                    for (int i = 0; i < dsexcel5.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < dsexcel3.Tables[0].Rows.Count; j++)
                        {
                            worksheet.Cells[5 + i, 10 + j] = dsexcel5.Tables[0].Rows[i][3 + j].ToString();
                        }
                    }



                    DBconnect dbConn4 = new DBconnect();
                    string sql4 = string.Format("select distinct Usage_R.BWBH,bwzl.ywsm,clzl.ywpm, clzl.dwbh from Usage_R left join bwzl on Usage_R.BWBH = bwzl.bwdh left join(select * from xxzls where XieXing = '{0}' and SheHao = '{1}') as xxzls on xxzls.BWBH = Usage_R.BWBH left join clzl on clzl.cldh = xxzls.CLBH where Usage_R.XieXing = '{0}' and Usage_R.SheHao = '{1}' and Usage_R.VER = '{2}' and Usage_R.xxzlver = '{3}' ", xiexing, shehao, bom, usage);
                    Console.WriteLine(sql4);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn4.connection);
                    adapter4.Fill(dsexcel4, "SIZE");

                    for (int i = 0; i < dsexcel4.Tables[0].Rows.Count; i++)
                    {
                        worksheet.Cells[5 + i, 1] = dsexcel4.Tables[0].Rows[i][0].ToString();
                        worksheet.Cells[5 + i, 2] = dsexcel4.Tables[0].Rows[i][1].ToString();
                        worksheet.Cells[5 + i, 4] = dsexcel4.Tables[0].Rows[i][2].ToString();
                        worksheet.Cells[5 + i, 9] = dsexcel4.Tables[0].Rows[i][3].ToString();

                        //DBconnect dbConn5 = new DBconnect();
                        //string sql5 = string.Format("select XTCC,CLSL from Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and xxzlver = '{3}' and BWBH = '{4}'", xiexing, shehao, bom, usage, dsexcel4.Tables[0].Rows[i][0].ToString());
                        //Console.WriteLine(sql5);
                        //SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn5.connection);
                        //adapter5.Fill(dsexcel5, "SIZE");

                        //for (int j = 0; j < dsexcel5.Tables[0].Rows.Count; j++)
                        //{
                        //    for (int k = 0; k < dsexcel3.Tables[0].Rows.Count; k++)
                        //    {
                        //        //Console.WriteLine(dsexcel4.Tables[0].Rows[i][0].ToString() + "&" +dsexcel5.Tables[0].Rows[j][0].ToString() + "&" + dsexcel3.Tables[0].Rows[k][0].ToString());
                        //        if (dsexcel5.Tables[0].Rows[j][0].ToString() == dsexcel3.Tables[0].Rows[k][0].ToString())
                        //        {
                        //            worksheet.Cells[5 + k, 10 + j] = dsexcel5.Tables[0].Rows[j][1].ToString();
                        //        }
                        //    }
                        //}
                    }









                    worksheet.Columns.AutoFit();  //自動調整大小


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
            catch (Exception)
            {
                MessageBox.Show("導出文件失敗", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                Search();
            }
            else 
            {

            }
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPage2;
                textBox7.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();


                ds = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select XieXing,SheHao,a.BWBH, b.ywsm, a.CLBH, c.ywpm, c.dwbh, a.CCQQ, a.CCQZ from xxzls as a left join bwzl as b on a.BWBH = b.bwdh left join clzl as c on a.CLBH = c.cldh where XieXing = '{0}' and SheHao = '{1}' order by BWBH ", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds, "棧板表");

                dataGridView1.DataSource = ds.Tables[0];
                dbConn11.CloseConnection();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region OLD


                //#region 區間

                ////GENDER dgv34  country dgv13
                ////選出區間
                //int linenum = 0;
                //string comd = "", ssize = "", esize = "";
                //double a, b, c;

                //DBconnect dbConn2 = new DBconnect();
                //string sql2 = string.Format("select COMDIF from CSSize where SIZE_ID = '{0}'", dataGridView4.CurrentRow.Cells[13].Value.ToString());
                //Console.WriteLine(sql2);

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
                //string sql3 = string.Format("select Star_Size,End_Size from GENDER where GENDER_id = '{0}'", dataGridView4.CurrentRow.Cells[34].Value.ToString());
                //Console.WriteLine(sql3);
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

                //#endregion

                //#region useageC

                ////int z = dataGridView4.Rows.Count;
                ////for (int i = 0; i < z; i++)
                ////{
                ////檢查有無資料 userc
                //int countc = 0;
                //DBconnect dbConn4 = new DBconnect();
                //string sql4 = string.Format("select count(XTCC) as count from Usage_C where XieXing = '{0}' and  SheHao = '{1}' and BWBH = '{2}'", textBox7.Text, textBox6.Text, dataGridView1.CurrentRow.Cells[2].Value.ToString());
                //Console.WriteLine(sql4);
                //SqlCommand cmd4 = new SqlCommand(sql4, dbConn4.connection);
                //dbConn4.OpenConnection();
                //SqlDataReader reader4 = cmd4.ExecuteReader();
                //if (reader4.Read())
                //{
                //    countc = int.Parse(reader4["count"].ToString());
                //}

                //dbConn4.CloseConnection();
                ////無資料新增
                //if (countc == 0)
                //{
                //    //新增USAGEc
                //    do
                //    {
                //        int result;
                //        DBconnect conn = new DBconnect();
                //        string sql = string.Format("insert into Usage_C (XieXing,SheHao,BWBH,XTCC,CLSL,USERDATE,USERID) values ('{0}','{1}','{2}','{3}','0',GETDATE(),'{4}')", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), a, userid);
                //        Console.WriteLine(sql);
                //        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //        SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                //        conn.OpenConnection();
                //        result = cmd1.ExecuteNonQuery();
                //        if (result == 1)
                //        {
                //            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        }
                //        conn.CloseConnection();

                //        int result22;
                //        DBconnect conn22 = new DBconnect();
                //        string sql22 = string.Format("insert into Usage_R (XieXing,SheHao,BWBH,XTCC,VER,CLSL,USERDATE,USERID) values ('{0}','{1}','{2}','{3}','1','0',GETDATE(),'{4}')", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), a, userid);
                //        Console.WriteLine(sql22);
                //        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                //        SqlCommand cmd22 = new SqlCommand(sql22, conn22.connection);
                //        conn22.OpenConnection();
                //        result22 = cmd22.ExecuteNonQuery();
                //        if (result22 == 1)
                //        {
                //            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        }
                //        conn22.CloseConnection();


                //        a += c;
                //        Console.WriteLine(a);
                //        //a
                //    } while (a < b);

                //}
                ////}
                //#endregion

                #endregion

                //取出最大版本
                string ver = "";
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select isnull(MAX(VER),0) as VER from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}'", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView4.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ver = reader["ver"].ToString();
                }
                dbConn.CloseConnection();
                int maxver = 0;
                maxver = int.Parse(ver);
                tbUsage.Text = ver;
                if (maxver != 0)
                {
                    //讀取資料
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select b.XTCC,isnull(a.CLSL,0) as CLSL,b.CLSL from (select * from Usage_R where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}' and VER = '{3}' and xxzlver = '{4}') as b left join(select * from Usage_C where XieXing = '{0}' and SheHao = '{1}' and BWBH = '{2}') as a on a.XTCC = b.XTCC  order by cast(a.XTCC as float)", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), maxver, dataGridView4.CurrentRow.Cells[2].Value.ToString());

                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView2.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();

                    dataGridView2.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                    dgv1select = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
                else 
                {
                    MessageBox.Show("查無資料");
                }
            }
            catch (Exception) { }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            BomCopy Form = new BomCopy();
            Form.textBox1.Text = textBox7.Text;
            Form.textBox2.Text = textBox6.Text;
            Form.textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Form.ShowDialog();
            bomcopy = Form.shesho;
            CopyQuery();
            tabControl1.SelectedTab = tabPage1;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    UpdateUsageR();
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    dataGridView2.ReadOnly = true;
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbDelete.Enabled = false;
                    dataGridView3.ReadOnly = true;

                    savexxzls();

                    for (int i = 0; i < dataGridView3.Rows.Count; i++) 
                    {
                        int a = 0;
                        a = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        a += 1;
                        dataGridView3.Rows[i].Cells[0].Value = a;
                    }
                    tabControl1.SelectedTab = tabPage1;
                }
                else if (tabControl1.SelectedTab == tabPage4) 
                {
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    cb楦頭.Enabled = false;
                    cb底模.Enabled = false;
                    cbMS.Enabled = false;
                    cb面刀.Enabled = false;
                    savexxzl();
                }
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage3)
                {
                    DialogResult dr = MessageBox.Show("確定要刪除嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region NEWERP

                        DBconnect con5 = new DBconnect();
                        StringBuilder sql5 = new StringBuilder();
                        sql5.AppendFormat("update xxzl set VER = VER +1, USERID = '{0}', USERDATE = GETDATE()  where XieXing = '{1}' and SheHao = '{2}'", userid, textBox2.Text, textBox1.Text);
                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {

                        }
                        con5.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("update xxzl set USERID = '{0}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{1}' and SheHao = '{2}'", userid, textBox2.Text, textBox1.Text);
                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {

                        }
                        con5Y.CloseConnection();

                        #endregion

                        string ver = "";
                        DBconnect dbConn3 = new DBconnect();
                        string sql3 = string.Format("select VER from xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox2.Text, textBox1.Text);
                        Console.WriteLine(sql3);
                        SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                        dbConn3.OpenConnection();
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        if (reader3.Read())
                        {
                            ver = reader3["VER"].ToString();
                        }
                        dbConn3.CloseConnection();
                        Console.WriteLine("VER:" + ver);

                        //Insert 新版
                        int result;
                        DBconnect conn = new DBconnect();
                        string sql = string.Format("insert xxzls select XieXing,SheHao,'{0}',BWBH,BWLB,xh,CLBH,CSBH,CLTX,CCQQ,CCQZ,LOSS,CLSL,CLDJ,Currency,Remark,'{1}',GETDATE(),JGZWSM,JGYWSM,YN from xxzls  where XieXing = '{2}' and SheHao = '{3}' and VER = {4}-1", ver, userid, textBox2.Text, textBox1.Text, ver);
                        Console.WriteLine(sql);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        conn.CloseConnection();


                        //modifyxxzls
                        DBconnect con6 = new DBconnect();
                        StringBuilder sql6 = new StringBuilder();
                        sql6.AppendFormat("update xxzls set YN = 0, USERID = '{0}',USERDATE = GETDATE() where XieXing = '{1}' and SheHao = '{2}' and VER = {3}-1", userid, textBox2.Text, textBox1.Text, ver);
                        Console.WriteLine(sql6);
                        SqlCommand cmd6 = new SqlCommand(sql6.ToString(), con6.connection);

                        con6.OpenConnection();
                        int result6 = cmd6.ExecuteNonQuery();
                        if (result6 == 1)
                        {

                        }
                        con6.CloseConnection();

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update xxzls set YN = 0, USERID = '{0}',USERDATE = GETDATE() where XieXing = '{1}' and SheHao = '{2}' and VER = '{3}' and CLBH = '{4}'", userid, textBox2.Text, textBox1.Text, ver, dataGridView3.CurrentRow.Cells[5].Value.ToString());
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {

                        }
                        con4.CloseConnection();

                        #region LYSHOE

                        int resultY;
                        DBconnect2 connY = new DBconnect2();
                        string sqlY = string.Format("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID],CONVERT(varchar,USERDATE,11) ,[JGZWSM],[JGYWSM] FROM New_Erp.[dbo].[xxzls] where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", textBox2.Text, textBox1.Text, ver);
                        Console.WriteLine(sqlY);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd1Y = new SqlCommand(sqlY, connY.connection);
                        connY.OpenConnection();
                        resultY = cmd1Y.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        connY.CloseConnection();

                        #endregion


                        //insert USAGER
                        int resulta;
                        DBconnect conna = new DBconnect();
                        string sqla = string.Format("insert into Usage_R select XieXing,SheHao,BWBH,XTCC,'1',CLSL,USERDATE,'{0}','{1}' from Usage_R where  XieXing = '{2}' and SheHao = '{3}' and xxzlver = {4}-1", userid, ver, textBox2.Text, textBox1.Text, ver);

                        Console.WriteLine(sqla);
                        SqlCommand cmd1a = new SqlCommand(sqla, conna.connection);
                        conna.OpenConnection();
                        resulta = cmd1a.ExecuteNonQuery();
                        if (resulta == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conna.CloseConnection();



                        //delete USAGER
                        DBconnect con7 = new DBconnect();
                        StringBuilder sql7 = new StringBuilder();
                        sql7.AppendFormat("delete Usage_R where XieXing='{0}' and SheHao ='{1}' and xxzlver = '{2}' and BWBH = '{3}'", textBox2.Text, textBox1.Text, ver, dataGridView3.CurrentRow.Cells[2].Value.ToString());
                        Console.WriteLine(sql7);
                        SqlCommand cmd7 = new SqlCommand(sql7.ToString(), con7.connection);

                        con7.OpenConnection();
                        int result7 = cmd7.ExecuteNonQuery();
                        if (result7 == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con7.CloseConnection();

                        #region LYSHOE

                        DBconnect2 con7Y = new DBconnect2();
                        StringBuilder sql7Y = new StringBuilder();
                        sql7Y.AppendFormat("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}' insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}'", textBox2.Text, textBox1.Text, ver);
                        Console.WriteLine(sql7Y);
                        SqlCommand cmd7Y = new SqlCommand(sql7Y.ToString(), con7Y.connection);

                        con7Y.OpenConnection();
                        int result7Y = cmd7Y.ExecuteNonQuery();
                        if (result7Y == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con7Y.CloseConnection();

                        #endregion


                        MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tabControl1.SelectedTab = tabPage1;
                        //DataSet dsb3 = new DataSet();
                        //DBconnect dbConn11 = new DBconnect();
                        //string sql1 = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString());
                        //Console.WriteLine(sql1);
                        //SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        //adapter.Fill(dsb3, "棧板表");

                        //dataGridView3.DataSource = dsb3.Tables[0];

                        //dbConn11.CloseConnection();
                    }
                    //tsbModify.Enabled = true;
                    //tsbSave.Enabled = false;
                    //tsbCancel.Enabled = false;
                    //tsbDelete.Enabled = false;
                    //dataGridView3.ReadOnly = true;
                }
            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "";
            }
            else
            {

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tsbQuery.Enabled = true;
                    tsbClear.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    ds = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = sqlback;
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds, "棧板表");

                    dataGridView4.DataSource = ds.Tables[0];
                    dbConn11.CloseConnection();

                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (dataGridView4.Rows.Count != 0)
                    {
                        tsbQuery.Enabled = false;
                        tsbClear.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;

                        textBox7.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                        textBox6.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();

                        ds = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select XieXing,SheHao,a.BWBH, b.ywsm, a.CLBH, c.ywpm, c.dwbh, a.CCQQ, a.CCQZ from xxzls as a left join bwzl as b on a.BWBH = b.bwdh left join clzl as c on a.CLBH = c.cldh where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and a.YN = 1 order by BWBH", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView4.CurrentRow.Cells[2].Value.ToString());
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds, "棧板表");

                        dataGridView1.DataSource = ds.Tables[0];
                        dbConn11.CloseConnection();

                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView1.Rows[0].Selected = true;
                        dgv1select = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    }
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    if (dataGridView4.Rows.Count !=0)
                    {
                        
                        tsbQuery.Enabled = false;
                        tsbClear.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbInsert.Enabled = true;

                        textBox2.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                        textBox1.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();

                        dsb = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, z.zsjc, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh LEFT OUTER JOIN zszl AS z ON z.zsdh = b.CSBH where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString());
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(dsb, "棧板表");

                        dataGridView3.DataSource = dsb.Tables[0];

                        dbConn11.CloseConnection();
                        dataGridView3.Columns[5].Width = 200;
                        //dataGridView3.Columns[0].Visible = false;
                        //dataGridView3.Columns[1].Visible = false;
                        dataGridView3.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView3.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView3.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView3.Columns[10].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView3.Columns[14].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                        dsb2 = new DataSet();
                        DBconnect dbConn12 = new DBconnect();
                        string sql2 = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, z.zsjc, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh LEFT OUTER JOIN zszl AS z ON z.zsdh = b.CSBH where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString());
                        Console.WriteLine(sql2);
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn12.connection);
                        adapter2.Fill(dsb2, "棧板表");

                        dataGridView5.DataSource = dsb2.Tables[0];

                        dbConn12.CloseConnection();
                    }
                }
                else if (tabControl1.SelectedTab == tabPage4) 
                {
                    if (dataGridView4.Rows.Count != 0)
                    {
                        tsbQuery.Enabled = false;
                        tsbClear.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;

                        textBox4.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                        textBox3.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                        textBox5.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();

                        tb28.Text = dataGridView4.CurrentRow.Cells[14].Value.ToString();
                        cb楦頭.Text = dataGridView4.CurrentRow.Cells[15].Value.ToString();
                        tb30.Text = dataGridView4.CurrentRow.Cells[16].Value.ToString();
                        cb底模.Text = dataGridView4.CurrentRow.Cells[17].Value.ToString();
                        tb32.Text = dataGridView4.CurrentRow.Cells[18].Value.ToString();
                        cbMS.Text = dataGridView4.CurrentRow.Cells[19].Value.ToString();
                        tb34.Text = dataGridView4.CurrentRow.Cells[20].Value.ToString();
                        cb面刀.Text = dataGridView4.CurrentRow.Cells[21].Value.ToString();
                    }
                }
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage3)
                {
                    BomInsert Form = new BomInsert();
                    Form.xiexing = textBox2.Text; 
                    Form.shehao = textBox1.Text; 
                    Form.ShowDialog();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            string confirm = "";
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select count(XieXing) as count from xxzl where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and YN = '2'", dataGridView4.CurrentRow.Cells[0].Value.ToString(), dataGridView4.CurrentRow.Cells[1].Value.ToString(), dataGridView4.CurrentRow.Cells[2].Value.ToString());

            Console.WriteLine(sql2);

            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                confirm = reader2["count"].ToString();
            }
            dbConn2.CloseConnection();

            if (confirm != "0")
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    dataGridView2.ReadOnly = false;
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbDelete.Enabled = true;
                    dataGridView3.ReadOnly = false;
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    cb楦頭.Enabled = true;
                    cb底模.Enabled = true;
                    cbMS.Enabled = true;
                    cb面刀.Enabled = true;
                }
            }
            else 
            {
                MessageBox.Show("請先確認");
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbDelete.Enabled = false;
            dataGridView2.ReadOnly = true;
            tabControl1.SelectedTab = tabPage1;
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tsbSave.Enabled == true)
                {
                    if (dataGridView3.CurrentCell.ColumnIndex == 2)
                    {
                        CFXTZLBWBH Form = new CFXTZLBWBH();
                        Form.ShowDialog();
                        if (Form.bwbh != "" && Form.ywsm != "")
                        {
                            dataGridView3.CurrentRow.Cells[2].Value = Form.bwbh;
                            dataGridView3.CurrentRow.Cells[3].Value = Form.ywsm;
                        }

                    }
                    else if (dataGridView3.CurrentCell.ColumnIndex == 3)
                    {
                        CFXTZLBWBH Form = new CFXTZLBWBH();
                        Form.ShowDialog();
                        if (Form.bwbh != "" && Form.ywsm != "")
                        {
                            dataGridView3.CurrentRow.Cells[2].Value = Form.bwbh;
                            dataGridView3.CurrentRow.Cells[3].Value = Form.ywsm;
                        }
                    }
                    else if (dataGridView3.CurrentCell.ColumnIndex == 5)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();
                        //Console.WriteLine(Form.cldh);
                        //Console.WriteLine(Form.zwsm);
                        //Console.WriteLine(Form.ywsm);
                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dataGridView3.CurrentRow.Cells[5].Value = Form.cldh;
                            dataGridView3.CurrentRow.Cells[6].Value = Form.ywsm;
                            dataGridView3.CurrentRow.Cells[7].Value = Form.zwsm;
                        }

                    }
                    else if (dataGridView3.CurrentCell.ColumnIndex == 6)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();
                        Console.WriteLine(Form.cldh);
                        Console.WriteLine(Form.zwsm);
                        Console.WriteLine(Form.ywsm);
                        string a, b, c;
                        a = Form.cldh;
                        b = Form.ywsm;
                        c = Form.zwsm;
                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dataGridView3.CurrentRow.Cells[5].Value = a;
                            dataGridView3.CurrentRow.Cells[6].Value = b;
                            dataGridView3.CurrentRow.Cells[7].Value = c;
                        }
                    }
                    else if (dataGridView3.CurrentCell.ColumnIndex == 7)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();
                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dataGridView3.CurrentRow.Cells[5].Value = Form.cldh;
                            dataGridView3.CurrentRow.Cells[6].Value = Form.ywsm;
                            dataGridView3.CurrentRow.Cells[7].Value = Form.zwsm;
                        }
                    }
                    else if (dataGridView3.CurrentCell.ColumnIndex == 10)
                    {
                        CFXTZLCSBH Form = new CFXTZLCSBH();
                        Form.tbCLBH.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                        Form.ShowDialog();
                        dataGridView3.CurrentRow.Cells[10].Value = Form.scbh;
                        dataGridView3.CurrentRow.Cells[11].Value = Form.zsjc;
                    }

                    //BomClBH Form = new BomClBH();
                    //Form.ShowDialog();
                    //if (Form.cldh != "")
                    //{
                    //    dataGridView3.CurrentRow.Cells[5].Value = Form.cldh;
                    //    dataGridView3.CurrentRow.Cells[6].Value = Form.ywsm;
                    //    dataGridView3.CurrentRow.Cells[7].Value = Form.zwsm;
                    //    dataGridView3.CurrentRow.Cells[10].Value = Form.csbh;
                    //}
                }
            }
            catch (Exception) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            string sql1 = string.Format("select * from gjzl where gjlb = '101' and counter1 = '{0}'", cb楦頭.Text);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫位置");
            this.cb底模.DataSource = ds.Tables[0];
            this.cb底模.ValueMember = "gjmh";

            this.cb底模.DisplayMember = "gjmh";

            cb底模.MaxDropDownItems = 8;
            cb底模.IntegralHeight = false;
        }

        private void cb底模_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            DBconnect dbconn = new DBconnect();
            string sql1 = string.Format("select * from gjzl where gjlb = '200' and counter1 = '{0}'", cb楦頭.Text);
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "倉庫位置");
            this.cb面刀.DataSource = ds.Tables[0];
            this.cb面刀.ValueMember = "gjmh";

            this.cb面刀.DisplayMember = "gjmh";

            cb面刀.MaxDropDownItems = 8;
            cb面刀.IntegralHeight = false;
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage2) 
                {
                    InputBom Form = new InputBom();
                    Form.ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("Error");
        }

        private void tsbsize_Click(object sender, EventArgs e)
        {
            try
            {
                string xiexing = "", shehao = "";
                int bom = 0, usage = 0;
                xiexing = textBox7.Text;
                shehao = textBox6.Text;
                bom = int.Parse(dataGridView4.CurrentRow.Cells[2].Value.ToString());
                usage = int.Parse(tbUsage.Text);
                ExportExcel(xiexing, dgvSize, xiexing, shehao, bom, usage);
            }
            catch (Exception) { }
        }

        #endregion

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage3)
                {
                    ExportExcel("BOM", dataGridView3);
                }
            }
            catch (Exception) { }
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
    }
}
