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
    public partial class OrderSizeRun : Form
    {
        public OrderSizeRun()
        {
            InitializeComponent();
        }

        public string userid = "";
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        DataSet dsc1 = new DataSet();
        string ddbh = "";

        private void OrderSizeRun_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select kfdh from kfzl";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc1, "倉庫");

                cb客戶.DataSource = dsc1.Tables[0];
                cb客戶.ValueMember = "kfdh";
                cb客戶.DisplayMember = "kfdh";
                cb客戶.MaxDropDownItems = 8;
                cb客戶.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void cb客戶_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string 客戶 = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select kfqm from kfzl where kfdh = '{0}'", cb客戶.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    客戶 = reader1["kfqm"].ToString();                    
                }
                dbConn1.CloseConnection();
                tb客戶編號2.Text = 客戶;
            }
            catch (Exception) { }
        }

        private void L0008_Click(object sender, EventArgs e)
        {
            try
            {                
                //取出SIZE
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select ddzls.CC from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh where ddzl.KHBH = '{0}' and ShipDate > GETDATE() group by ddzls.cc order by ddzls.cc", cb客戶.Text);

                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];

                //取出SIZE
                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = "select ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO,xxzl.Article, xxzl.XieMing, xxzl.YSSM, DDZL.DDGB,DESTINATION.ywsm ";

                for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                {
                    sql2 += string.Format(",sum(isnull(case when CC= '{0}' then Quantity end ,0)) as '{0}'", dataGridView1.Rows[i].Cells[0].Value.ToString());
                }

                sql2 += string.Format("from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh left join xxzl on ddzl.XieXing = xxzl.XieXing   and ddzl.SheHao = xxzl.SheHao left join DESTINATION on ddzl.Dest = DESTINATION.DESTINATION_ID where ddzl.KHBH = '{0}' and ddzl.ddbh between '{1}' and '{2}' group by ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO, xxzl.Article, xxzl.XieMing, xxzl.YSSM, DDZL.DDGB, DESTINATION.ywsm ", cb客戶.Text, tb訂單編號.Text, tb訂單編號2.Text);

                Console.WriteLine(sql2);

                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds2, "棧板表");
                dgvSize.DataSource = ds2.Tables[0];

                //function2
                //取出SIZE
                DataSet ds3 = new DataSet();
                DBconnect dbConn3 = new DBconnect();
                string sql3 = "select ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO,xxzl.Article, xxzl.XieMing, xxzl.YSSM, COUNTRY.zwsm,DESTINATION.ywsm, DDZL.Pairs ";

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sql3 += string.Format(",sum(isnull(case when CC= '{0}' then Quantity end ,0)) as '{0}'", dataGridView1.Rows[i].Cells[0].Value.ToString());
                }

                sql3 += string.Format("from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh left join country on country.COUNTRY_ID = ddzl.DDGB left join xxzl on ddzl.XieXing = xxzl.XieXing   and ddzl.SheHao = xxzl.SheHao left join DESTINATION on ddzl.Dest = DESTINATION.DESTINATION_ID where ddzl.KHBH = '{0}' and ddzl.ddbh between '{1}' and '{2}' group by ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO, xxzl.Article, xxzl.XieMing, xxzl.YSSM, DDZL.DDGB, DESTINATION.ywsm, country.zwsm,ddzl.Pairs", cb客戶.Text, tb訂單編號.Text, tb訂單編號2.Text);

                Console.WriteLine(sql3);

                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                adapter3.Fill(ds3, "棧板表");
                dgvSize2.DataSource = ds3.Tables[0];

                dgvSize.Columns[0].Width = 150;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ddbh = dgvSize2.CurrentRow.Cells[0].Value.ToString();
                ExportExcel("report", dgvSize2, ddbh);
            }
            catch (Exception) { MessageBox.Show("Error"); }

        }

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV, string DDBH)
        {
            //try
            //{
                

                if (myDGV.Rows.Count > 0)
                {
                    DataSet dsexcel = new DataSet();
                    DataSet dsexcel2 = new DataSet();
                    DataSet dsexcel3 = new DataSet();
                    DataSet dsexcel4 = new DataSet();
                    DataSet dsexcel5 = new DataSet();
                    DataSet dsexcel6 = new DataSet();
                    DataSet dsexcel7 = new DataSet();
                    DataSet dsexcel8 = new DataSet();
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
                    
                    string sql = string.Format("select DDZL.DDBH,DDZL.DDBH,kfzl.kfjc,DDZL.XieXing,xxzl.XieMing, CONVERT(varchar(12), DDZL.ShipDate, 111 ) as shipdate , CONVERT(varchar(12), getdate(), 111 ) as Date, DDZL.SheHao,xxzl.YSSM, DDZL.ARTICLE,DDZL.Pairs,DDZL.KHPO,DESTINATION.DESTINATION_ID, xxzl.BZCC,xxzl.XTMH,xxzl.DDMH,xxzl.MDMH, xxzl.DAOMH from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing and DDZL.SheHao = xxzl.SheHao left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID left join kfzl on ddzl.KHBH = kfzl.kfdh where DDBH = '{0}'", myDGV.CurrentRow.Cells[0].Value.ToString());
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsexcel, "前身");
                    Console.WriteLine(sql);
                    
                    worksheet.Cells[1, 6] = "YI CHAN FOOTGEAR CO., LTD.";
                    wRange = worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[1, 14]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    wRange.Font.Size = 20;

                    worksheet.Cells[2, 6] = "PROJECT ORDER(PRODUCTION USAGE)";
                    wRange = worksheet.Range[worksheet.Cells[2, 6], worksheet.Cells[2, 14]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    wRange.Font.Size = 20;

                    worksheet.Cells[4, 1] = "Order#:";
                    worksheet.Cells[4, 2] = dsexcel.Tables[0].Rows[0][0].ToString();
                    wRange = worksheet.Range[worksheet.Cells[4, 2], worksheet.Cells[4, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[4, 5] = "Projuct#:";
                    worksheet.Cells[4, 6] = dsexcel.Tables[0].Rows[0][1].ToString();
                    wRange = worksheet.Range[worksheet.Cells[4, 6], worksheet.Cells[4, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[4, 9] = "Customer:";
                    worksheet.Cells[4, 10] = dsexcel.Tables[0].Rows[0][2].ToString();
                    wRange = worksheet.Range[worksheet.Cells[4, 10], worksheet.Cells[4, 11]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[5, 1] = "MODEL#:";
                    worksheet.Cells[5, 2] = dsexcel.Tables[0].Rows[0][3].ToString();
                    wRange = worksheet.Range[worksheet.Cells[5, 2], worksheet.Cells[5, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[5, 5] = "MODEL:";
                    worksheet.Cells[5, 6] = dsexcel.Tables[0].Rows[0][4].ToString();
                    wRange = worksheet.Range[worksheet.Cells[5, 6], worksheet.Cells[5, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[5, 9] = "ETD:";
                    worksheet.Cells[5, 10] = dsexcel.Tables[0].Rows[0][5].ToString();
                    wRange = worksheet.Range[worksheet.Cells[5, 10], worksheet.Cells[5, 11]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[5, 13] = "ShipDate:";
                    worksheet.Cells[5, 14] = dsexcel.Tables[0].Rows[0][5].ToString();
                    wRange = worksheet.Range[worksheet.Cells[5, 14], worksheet.Cells[5, 15]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[5, 17] = "DATE:";
                    worksheet.Cells[5, 18] = dsexcel.Tables[0].Rows[0][6].ToString();
                    wRange = worksheet.Range[worksheet.Cells[5, 18], worksheet.Cells[5, 19]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[6, 1] = "COLOR:";
                    string color = "";
                    color = dsexcel.Tables[0].Rows[0][7].ToString();
                    Console.WriteLine(color);
                    if (color.Length == 1) 
                    {
                        color = "0" + color;
                    }
                    Console.WriteLine(color);
                    worksheet.Cells[6, 2] = "'"+ color;
                    wRange = worksheet.Range[worksheet.Cells[6, 2], worksheet.Cells[6, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[6, 5] = "COLOR DESC:";
                    worksheet.Cells[6, 6] = dsexcel.Tables[0].Rows[0][8].ToString();
                    wRange = worksheet.Range[worksheet.Cells[6, 6], worksheet.Cells[6, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[6, 9] = "RCVD";
                    worksheet.Cells[6, 10] = "RCVD";
                    wRange = worksheet.Range[worksheet.Cells[6, 10], worksheet.Cells[6, 11]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[6, 13] = "ARTICLE:";
                    worksheet.Cells[6, 14] = dsexcel.Tables[0].Rows[0][9].ToString();
                    wRange = worksheet.Range[worksheet.Cells[6, 14], worksheet.Cells[6, 15]];
                    wRange.Select();
                    wRange.MergeCells = true;


                    worksheet.Cells[7, 1] = "Pairs:";
                    worksheet.Cells[7, 2] = dsexcel.Tables[0].Rows[0][10].ToString();
                    wRange = worksheet.Range[worksheet.Cells[7, 2], worksheet.Cells[7, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;


                    worksheet.Cells[7, 5] = "PO#:";
                    worksheet.Cells[7, 6] = dsexcel.Tables[0].Rows[0][11].ToString();
                    wRange = worksheet.Range[worksheet.Cells[7, 6], worksheet.Cells[7, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[7, 9] = "Destination:";
                    string dest = "";
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select ywsm from DESTINATION where DESTINATION_ID like '%{0}'", dsexcel.Tables[0].Rows[0][12].ToString());
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        dest = reader1["ywsm"].ToString();
                    }
                    dbConn1.CloseConnection();

                    worksheet.Cells[7, 10] = dest;
                    wRange = worksheet.Range[worksheet.Cells[7, 10], worksheet.Cells[7, 11]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[7, 13] = "STD#:";
                    worksheet.Cells[7, 14] = dsexcel.Tables[0].Rows[0][13].ToString();
                    wRange = worksheet.Range[worksheet.Cells[7, 14], worksheet.Cells[7, 15]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[8, 1] = "LAST:";
                    worksheet.Cells[8, 2] = dsexcel.Tables[0].Rows[0][14].ToString();
                    wRange = worksheet.Range[worksheet.Cells[8, 2], worksheet.Cells[8, 3]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[8, 5] = "O/S:";
                    worksheet.Cells[8, 6] = dsexcel.Tables[0].Rows[0][15].ToString();
                    wRange = worksheet.Range[worksheet.Cells[8, 6], worksheet.Cells[8, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[8, 9] = "M/S:";
                    worksheet.Cells[8, 10] = dsexcel.Tables[0].Rows[0][16].ToString();
                    wRange = worksheet.Range[worksheet.Cells[8, 10], worksheet.Cells[8, 11]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[8, 13] = "CUT DIE:";
                    worksheet.Cells[8, 14] = dsexcel.Tables[0].Rows[0][17].ToString();
                    wRange = worksheet.Range[worksheet.Cells[8, 14], worksheet.Cells[8, 15]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[10, 1] = "SEO";
                    wRange = worksheet.Range[worksheet.Cells[10, 1], worksheet.Cells[10, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[10, 3] = "SIZES";

                    worksheet.Cells[11, 1] = "SIZE RUN";
                    wRange = worksheet.Range[worksheet.Cells[11, 1], worksheet.Cells[11, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[12, 1] = "LAST";
                    wRange = worksheet.Range[worksheet.Cells[12, 1], worksheet.Cells[12, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[13, 1] = "OUTSOLE";
                    wRange = worksheet.Range[worksheet.Cells[13, 1], worksheet.Cells[13, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[14, 1] = "CUT DIE";
                    wRange = worksheet.Range[worksheet.Cells[14, 1], worksheet.Cells[14, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;

                    worksheet.Cells[15, 1] = "ORDER QTY";
                    wRange = worksheet.Range[worksheet.Cells[15, 1], worksheet.Cells[15, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[15, 3] = dsexcel.Tables[0].Rows[0][10].ToString();

                    #region SIZERUN

                    //取DDZLS
                    DataSet ds3 = new DataSet();
                    DBconnect dbConn3 = new DBconnect();
                    string sql3 = string.Format("select * from ddzls where DDBH = '{0}'", dsexcel.Tables[0].Rows[0][0].ToString());                    
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                    adapter3.Fill(dsexcel3, "SIZE");
                    
                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++) 
                    {
                        worksheet.Cells[10, 3 + 1 + i] = dsexcel3.Tables[0].Rows[i][1].ToString();
                        worksheet.Cells[11, 3 + 1 + i] = dsexcel3.Tables[0].Rows[i][2].ToString();
                        worksheet.Cells[15, 3 + 1 + i] = dsexcel3.Tables[0].Rows[i][3].ToString();
                    }

                    //100
                    DataSet ds4 = new DataSet();
                    DBconnect dbConn4 = new DBconnect();
                    string sql4 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '100'", dsexcel.Tables[0].Rows[0][3].ToString(), color);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn4.connection);
                    adapter4.Fill(dsexcel4, "SIZE");

                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++) 
                    {
                        for (int j = 0; j < dsexcel4.Tables[0].Rows.Count; j++)
                        {
                            if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel4.Tables[0].Rows[j][4].ToString().Trim()))
                            {
                                worksheet.Cells[12, 3 + 1 + i] = dsexcel4.Tables[0].Rows[j][5].ToString();
                            }
                        }
                    }
                    

                    //101
                    DataSet ds5 = new DataSet();
                    DBconnect dbConn5 = new DBconnect();
                    string sql5 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '101'", dsexcel.Tables[0].Rows[0][3].ToString(), color);
                    SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn5.connection);
                    adapter5.Fill(dsexcel5, "SIZE");

                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < dsexcel5.Tables[0].Rows.Count; j++)
                        {
                            if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel5.Tables[0].Rows[j][4].ToString().Trim()))
                            {
                                worksheet.Cells[13, 3 + 1 + i] = dsexcel5.Tables[0].Rows[j][5].ToString();
                            }
                        }
                    }

                    //200
                    DataSet ds6 = new DataSet();
                    DBconnect dbConn6 = new DBconnect();
                    string sql6 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '200'", dsexcel.Tables[0].Rows[0][3].ToString(), color);
                    SqlDataAdapter adapter6 = new SqlDataAdapter(sql6, dbConn6.connection);
                    adapter6.Fill(dsexcel6, "SIZE");

                    for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < dsexcel6.Tables[0].Rows.Count; j++)
                        {
                            if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel6.Tables[0].Rows[j][4].ToString().Trim()))
                            {
                                worksheet.Cells[14, 3 + 1 + i] = dsexcel6.Tables[0].Rows[j][5].ToString();
                            }
                        }
                    }

                    #endregion

                    //string sql2 = string.Format("select xxzls.BWBH,bwzl.ywsm,xxzls.CLBH,clzl.ywpm,clzl.dwbh,zszl.zsywjc,xxzls.LOSS,zlzls2.USAGE, zlzls2.CLSL,clzl.CQDH from xxzls left join bwzl on xxzls.BWBH = bwzl.bwdh left join clzl on xxzls.CLBH = clzl.cldh left join zszl on xxzls.CSBH = zszl.zsdh left join DDZL on DDZL.XieXing = xxzls.XieXing left join zlzls2 on DDZL.DDBH = zlzls2.ZLBH where xxzls.XieXing = '{0}' and DDZL.DDBH = '{1}' order by BWBH", dsexcel.Tables[0].Rows[0][3].ToString(), myDGV.CurrentRow.Cells[0].Value.ToString());
                    dsexcel2 = new DataSet();
                    DBconnect dbConn2S = new DBconnect();
                    string sql2 = string.Format("if object_id('tempdb..#Material') is not null begin drop table #Material end ");
                    sql2 += string.Format("SELECT ZLZLS2.XH, ZLZLS2.bwbh, max(BWZL.ywsm) AS BWMCY, zlzls2.clbh AS clbh, max(CLZL.ywpm) AS CLMCY, max(CLZL.dwbh) AS dwbh, max(zszl.zsywjc) as zsywjc, XXZLS.LOSS , sum(zlzls2.clsl) AS clsl , MAX(ZLZLS2.USAGE) AS USAGE, CLZL.CQDH, max(zlzls2.mjbh) AS mjbh, XXZLS.JGYWSM ,XXZLS.CCQQ,XXZLS.CCQZ into #Material FROM ZLZLS2 AS ZLZLS2 LEFT JOIN BWZL AS BWZL ON ZLZLS2.BWBH = BWZL.bwdh LEFT JOIN CLZL AS CLZL ON ZLZLS2.CLBH = CLZL.cldh LEFT JOIN DDZL AS DDZL ON ZLZLS2.ZLBH = DDZL.ZLBH left join zszl as zszl on zlzls2.csbh=zszl.zsdh LEFT JOIN XXZLS AS XXZLS ON DDZL.XIEXING = XXZLS.XIEXING  AND DDZL.SHEHAO = XXZLS.SHEHAO AND ZLZLS2.BWBH = XXZLS.BWBH where ZLZLS2.ZLBH= '");
                    sql2 += DDBH;
                    sql2 += string.Format("' and ZLZLS2.MJBH='ZZZZZZZZZZ' GROUP BY ZLZLS2.XH,zlzls2.zlbh,zlzls2.bwbh,zlzls2.clbh,XXZLS.CLSL,CLZL.CQDH,XXZLS.LOSS,XXZLS.JGYWSM ,XXZLS.CCQQ,XXZLS.CCQZ ORDER BY zlzls2.zlbh ,ZLZLS2.XH, zlzls2.bwbh ASC ");
                    sql2 += string.Format("update #Material set CLMCY=CLMCY+JGYWSM where JGYWSM is not Null ");
                    sql2 += string.Format("update #Material set CLMCY=CLMCY+'('+CCQQ+'-' where CCQQ >' ' ");
                    sql2 += string.Format("update #Material set CLMCY=CLMCY+CCQZ+')' where CCQZ >' '  ");
                    sql2 += string.Format(" select * from #Material order by clbh,BWBH ");
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2S.connection);
                    adapter2.Fill(dsexcel2, "尾身");


                    Console.WriteLine(dsexcel2.Tables[0].Rows.Count);

                    for (int i = 0; i <= dsexcel2.Tables[0].Rows.Count; i++)
                    {
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 3], worksheet.Cells[17 + i, 6]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 7], worksheet.Cells[17 + i, 9]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 10], worksheet.Cells[17 + i, 18]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 20], worksheet.Cells[17 + i, 26]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 28], worksheet.Cells[17 + i, 29]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 30], worksheet.Cells[17 + i, 31]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        wRange = worksheet.Range[worksheet.Cells[17 + i, 33], worksheet.Cells[17 + i, 36]];
                        wRange.Select();
                        wRange.MergeCells = true;
                    }

                    //wRange = worksheet.Range[worksheet.Cells[17, 2], worksheet.Cells[17, 5]];
                    //wRange.Select();
                    //wRange.MergeCells = true;
                    //wRange = worksheet.Range[worksheet.Cells[17, 6], worksheet.Cells[17, 7]];
                    //wRange.Select();
                    //wRange.MergeCells = true;
                    //wRange = worksheet.Range[worksheet.Cells[17, 8], worksheet.Cells[17, 18]];
                    //wRange.Select();
                    //wRange.MergeCells = true;
                    //wRange = worksheet.Range[worksheet.Cells[17, 20], worksheet.Cells[17, 21]];
                    //wRange.Select();
                    //wRange.MergeCells = true;
                    //wRange = worksheet.Range[worksheet.Cells[17, 23], worksheet.Cells[17, 24]];
                    //wRange.Select();
                    //wRange.MergeCells = true;
                    //wRange = worksheet.Range[worksheet.Cells[17, 25], worksheet.Cells[17, 26]];
                    //wRange.Select();
                    //wRange.MergeCells = true;

                    worksheet.Cells[17, 1] = "XH";
                    worksheet.Cells[17, 2] = "PART NO";
                    worksheet.Cells[17, 3] = "PART DESCRIPTION";
                    worksheet.Cells[17, 7] = "MAT. NO";
                    worksheet.Cells[17, 10] = "MATERIAL DESCRIPTION";
                    worksheet.Cells[17, 19] = "UNIT";
                    worksheet.Cells[17, 20] = "zsqm";
                    worksheet.Cells[17, 27] = "LOSS";
                    worksheet.Cells[17, 28] = "QTY";
                    worksheet.Cells[17, 30] = "USAGE";
                    worksheet.Cells[17, 32] = "AR.";
                    worksheet.Cells[17, 33] = "mjbh";
                    worksheet.Cells[17, 37] = "jqywsm";
                    worksheet.Cells[17, 38] = "ccqq";
                    worksheet.Cells[17, 39] = "ccqz";


                    for (int i = 0; i < dsexcel2.Tables[0].Rows.Count; i++)
                    {
                        worksheet.Cells[i + 18, 1] = dsexcel2.Tables[0].Rows[i][0].ToString();
                        worksheet.Cells[i + 18, 2] = dsexcel2.Tables[0].Rows[i][1].ToString();
                        worksheet.Cells[i + 18, 3] = dsexcel2.Tables[0].Rows[i][2].ToString();
                        worksheet.Cells[i + 18, 7] = dsexcel2.Tables[0].Rows[i][3].ToString();
                        worksheet.Cells[i + 18, 10] = dsexcel2.Tables[0].Rows[i][4].ToString();
                        worksheet.Cells[i + 18, 19] = dsexcel2.Tables[0].Rows[i][5].ToString();
                        worksheet.Cells[i + 18, 20] = dsexcel2.Tables[0].Rows[i][6].ToString();
                        worksheet.Cells[i + 18, 27] = dsexcel2.Tables[0].Rows[i][7].ToString();
                        worksheet.Cells[i + 18, 28] = dsexcel2.Tables[0].Rows[i][8].ToString();
                        worksheet.Cells[i + 18, 30] = dsexcel2.Tables[0].Rows[i][9].ToString();
                        worksheet.Cells[i + 18, 32] = dsexcel2.Tables[0].Rows[i][10].ToString();
                        worksheet.Cells[i + 18, 33] = dsexcel2.Tables[0].Rows[i][11].ToString();
                        worksheet.Cells[i + 18, 37] = dsexcel2.Tables[0].Rows[i][12].ToString();
                        worksheet.Cells[i + 18, 38] = dsexcel2.Tables[0].Rows[i][13].ToString();
                        worksheet.Cells[i + 18, 39] = dsexcel2.Tables[0].Rows[i][14].ToString();
                    }
                    //worksheet.Columns.AutoFit();  //自動調整大小

                    int rowscount = dsexcel2.Tables[0].Rows.Count;

                    wRange = worksheet.Range[worksheet.Cells[20 + dsexcel2.Tables[0].Rows.Count, 1], worksheet.Cells[20 + dsexcel2.Tables[0].Rows.Count , 6]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[20 + dsexcel2.Tables[0].Rows.Count, 1] = "-----------------------";
                    worksheet.Cells[21 + dsexcel2.Tables[0].Rows.Count, 1] = "ORDER MEMO";

                    DBconnect dbConn7 = new DBconnect();
                    string sql7 = string.Format("select bz from DDBZZL where DDBH = '{0}' and zylb = 'E'", dsexcel.Tables[0].Rows[0][0].ToString());
                    SqlDataAdapter adapter7 = new SqlDataAdapter(sql7, dbConn7.connection);
                    adapter7.Fill(dsexcel7, "前身");
                    Console.WriteLine(sql7);

                    for (int i = 0; i < dsexcel7.Tables[0].Rows.Count; i++) 
                    {
                        wRange = worksheet.Range[worksheet.Cells[22 + dsexcel2.Tables[0].Rows.Count + i, 1], worksheet.Cells[22 + dsexcel2.Tables[0].Rows.Count + i, 6]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        worksheet.Cells[22 + rowscount + i, 1] = dsexcel7.Tables[0].Rows[i][0].ToString();
                    }

                    rowscount += dsexcel7.Tables[0].Rows.Count;
                    wRange = worksheet.Range[worksheet.Cells[23 + rowscount, 1], worksheet.Cells[23 + rowscount, 6]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[23 + rowscount , 1] = "-----------------------";

                    worksheet.Cells[24 + rowscount, 1] = "COMPLEX";

                    wRange = worksheet.Range[worksheet.Cells[25 + rowscount, 1], worksheet.Cells[25 + rowscount, 2]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[25 + rowscount, 1] = "COMPLEX MAT";

                    wRange = worksheet.Range[worksheet.Cells[25 + rowscount, 3], worksheet.Cells[25 + rowscount, 4]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[25 + rowscount, 3] = "MATERIAL";

                    wRange = worksheet.Range[worksheet.Cells[25 + rowscount, 6], worksheet.Cells[25 + rowscount, 7]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[25 + rowscount, 6] = "USAGE";

                    worksheet.Cells[25 + rowscount, 8] = "UNIT";

                    wRange = worksheet.Range[worksheet.Cells[25 + rowscount, 9], worksheet.Cells[25 + rowscount, 15]];
                    wRange.Select();
                    wRange.MergeCells = true;
                    worksheet.Cells[25 + rowscount, 9] = "DESCRIPTION";

                    DBconnect dbConn8 = new DBconnect();
                    string sql8 = string.Format("select zlzls2.CLBH,cldh_S,syl,clzl.dwbh,clzl.ywpm  from zlzls2 left join clzhzl on zlzls2.clbh = clzhzl.cldh_M left join clzl on clzl.cldh = clzhzl.cldh_S where zlbh = '{0}' and zmlb = 'Y' group by zlzls2.CLBH, syl, clzhzl.cldh_S, clzhzl.cldh_M, clzl.dwbh, clzl.ywpm order by clzhzl.cldh_M", dsexcel.Tables[0].Rows[0][0].ToString());
                    SqlDataAdapter adapter8 = new SqlDataAdapter(sql8, dbConn8.connection);
                    adapter8.Fill(dsexcel8, "前身");
                    Console.WriteLine(sql8);

                    for (int i = 0; i < dsexcel8.Tables[0].Rows.Count; i++)
                    {
                        wRange = worksheet.Range[worksheet.Cells[26 + rowscount + i, 1], worksheet.Cells[26 + rowscount + i, 2]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        if (i == 0)
                        {

                            worksheet.Cells[26 + rowscount + i, 1] = dsexcel8.Tables[0].Rows[i][0].ToString();
                            
                        }
                        else 
                        {
                            
                            Console.WriteLine(dsexcel8.Tables[0].Rows[i][0].ToString());
                            Console.WriteLine(dsexcel8.Tables[0].Rows[i-1][0].ToString());
                            if (dsexcel8.Tables[0].Rows[i][0].ToString() == dsexcel8.Tables[0].Rows[i - 1][0].ToString())
                            {
                                worksheet.Cells[26 + rowscount + i, 1] = "";
                            }
                            else 
                            {
                                worksheet.Cells[26 + rowscount + i, 1] = dsexcel8.Tables[0].Rows[i][0].ToString();
                            }
                        }

                        wRange = worksheet.Range[worksheet.Cells[26 + rowscount + i, 3], worksheet.Cells[26 + rowscount + i, 4]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        worksheet.Cells[26 + rowscount + i, 3] = dsexcel8.Tables[0].Rows[i][1].ToString();

                        wRange = worksheet.Range[worksheet.Cells[26 + rowscount + i, 6], worksheet.Cells[26 + rowscount + i, 7]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        worksheet.Cells[26 + rowscount + i, 6] = dsexcel8.Tables[0].Rows[i][2].ToString();

                        worksheet.Cells[26 + rowscount + i, 8] = dsexcel8.Tables[0].Rows[i][3].ToString();

                        wRange = worksheet.Range[worksheet.Cells[26 + rowscount + i, 9], worksheet.Cells[26 + rowscount + i, 15]];
                        wRange.Select();
                        wRange.MergeCells = true;
                        worksheet.Cells[26 + rowscount + i, 9] = dsexcel8.Tables[0].Rows[i][4].ToString(); ;
                    }
                    //rowscount += dsexcel8.Tables[0].Rows.Count;
                    //Console.WriteLine(rowscount);
                    //Console.WriteLine(rowscount - dsexcel8.Tables[0].Rows.Count);

                    //for (int i = rowscount ; i > rowscount - dsexcel8.Tables[0].Rows.Count; i --)
                    //{
                    //    Console.WriteLine(worksheet.Cells[i, 1]);
                    //    Console.WriteLine(worksheet.Cells[i-1, 1]);
                    //    if (worksheet.Cells[i, 1] == worksheet.Cells[i - 1, 1])
                    //    {
                    //        worksheet.Cells[i, 1] = "";
                    //    }
                    //}


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
            //}
            //catch (Exception) 
            //{
            //    MessageBox.Show("導出文件失敗", "提示", MessageBoxButtons.OK);
            //}

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            ExportExcel("sizerun", dgvSize2);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SIZETEST Form = new SIZETEST();
                Form.ddbh = dgvSize2.CurrentRow.Cells[0].Value.ToString();
                Form.ShowDialog();

            }
            catch (Exception) { }
        }
    }
}
