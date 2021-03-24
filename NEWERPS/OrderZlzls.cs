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
    public partial class OrderZlzls : Form
    {
        public OrderZlzls()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        //語言變數
        public DataSet dsL = new DataSet();
        DataSet dsexcel = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "OrderZlzls";
        public string userid = "";

        private void OrderZlzls_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select ZLBH,BWBH,CLBH,clzl.ywpm,SIZE,YN,xh,CSBH,MJBH,ZMLB,CLSL,USAGE,zlzls2.USERID,zlzls2.USERDATE,CLSL2,Usage2,Qbuy,QWin,Udate,LTDBH,ver from zlzls2 left join clzl on zlzls2.CLBH = clzl.cldh where ZLBH = '{0}'", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView7.DataSource = ds.Tables[0];

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //ChangeLabel();
                //ChangeDataView();
                //ChangeTabControl();
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

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void L0002_Click(object sender, EventArgs e)
        {

        }

        #region 輸出EXCEL

        private void ExportCheckComparativeList(DataGridView topdgv)
        {
            dsexcel = new DataSet();
            DBconnect dbConn = new DBconnect();
            // 匯出EXCEL
            // 建立Excel實例化
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add();
            app.Visible = true;
            //DGV輸出EXCEL演算法
            try
            {
                // 資料附值
                // 單頭資訊
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "FOOTGEAR CO., LTD.";
                worksheet.Cells[1, 1] = "FOOTGEAR CO., LTD.";
                worksheet.Cells[2, 1] = "PROJECT ORDER(PRODUCTION USAGE)";

                //var orng = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]];
                //orng.MergeCells = true;
                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select DDBH,DDBH,kfzl.kfjc,DDZL.XieXing,xxzl.XieMing,ShipDate,GETDATE() as date,DDZL.SheHao,xxzl.YSSM,DDRQ,DDZL.ARTICLE,Pairs,KHPO,ywsm,xxzl.BZCC, xxzl.XTMH, xxzl.DDMH,xxzl.MSGJ,xxzl.DAOMH from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing and DDZL.SheHao = xxzl.SheHao left join kfzl on DDZL.KHBH = kfzl.kfdh left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where DDBH = '{0}'", textBox1.Text);
                Console.WriteLine(sql2);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds2, "棧板表");
                dataGridView1.DataSource = ds2.Tables[0];
                Console.WriteLine(dataGridView1.Rows[0].Cells[0].Value.ToString());

                worksheet.Cells[3, 1] = "ORDER:" + dataGridView1.Rows[0].Cells[0].Value.ToString();
                worksheet.Cells[3, 4] = "PROJECT:" + dataGridView1.Rows[0].Cells[1].Value.ToString();
                worksheet.Cells[3, 7] = "CUSTOMER:" + dataGridView1.Rows[0].Cells[2].Value.ToString();

                worksheet.Cells[4, 1] = "XieXing:" + dataGridView1.Rows[0].Cells[3].Value.ToString();
                worksheet.Cells[4, 4] = "XieMing:" + dataGridView1.Rows[0].Cells[4].Value.ToString();
                worksheet.Cells[4, 7] = "ShipDate:" + dataGridView1.Rows[0].Cells[5].Value.ToString();
                worksheet.Cells[4, 10] = "Date:" + dataGridView1.Rows[0].Cells[6].Value.ToString();

                worksheet.Cells[5, 1] = "SheHao:" + dataGridView1.Rows[0].Cells[7].Value.ToString();
                worksheet.Cells[5, 4] = "Color:" + dataGridView1.Rows[0].Cells[8].Value.ToString();
                worksheet.Cells[5, 7] = "RCVD:" + dataGridView1.Rows[0].Cells[9].Value.ToString();
                worksheet.Cells[5, 10] = "Article:" + dataGridView1.Rows[0].Cells[10].Value.ToString();

                worksheet.Cells[6, 1] = "Pairs:" + dataGridView1.Rows[0].Cells[11].Value.ToString();
                worksheet.Cells[6, 4] = "PO:" + dataGridView1.Rows[0].Cells[12].Value.ToString();
                worksheet.Cells[6, 7] = "Destination:" + dataGridView1.Rows[0].Cells[13].Value.ToString();
                worksheet.Cells[6, 10] = "Size:" + dataGridView1.Rows[0].Cells[14].Value.ToString();

                worksheet.Cells[7, 1] = "Last:" + dataGridView1.Rows[0].Cells[15].Value.ToString();
                worksheet.Cells[7, 4] = "O/S:" + dataGridView1.Rows[0].Cells[16].Value.ToString();
                worksheet.Cells[7, 7] = "M/S:" + dataGridView1.Rows[0].Cells[17].Value.ToString();
                worksheet.Cells[7, 10] = "CUT DIE:" + dataGridView1.Rows[0].Cells[18].Value.ToString();

                size();

                for (int z = 0; z < dataGridView3.Columns.Count; z++)
                {
                    worksheet.Cells[ 8, z + 1] = dataGridView3.Columns[z].HeaderText;
                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 9, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //// 盤差(沒盤點到的,盤點到但是儲位不相同)
                //string sql = string.Format("select ai.AssetNo,acs.ASSETS_NAME,acs.MODEL_NAME,sl.Name orgLocation,acs.IS_CHECK,acs.CHECK_DATE,sl2.Name scanLocation " +
                //    "from ASSETS_CHECK_SUB acs " +
                //    "left join ASSETS_INFORMATION ai on ai.ASSETS_ID=acs.ASSETS_ID " +
                //    "left join StorageLocation sl on sl.StorageLocationNo=acs.ORIGINAL_Location " +
                //    "left join StorageLocation sl2 on sl2.StorageLocationNo=acs.CHECK_Location " +
                //    "where acs.CHECK_BATCH_NO='{0}' and (acs.IS_CHECK='N' or (acs.IS_CHECK='Y' and acs.ORIGINAL_Location!=acs.CHECK_Location)) " +
                //    "order by acs.IS_CHECK,acs.ASSETS_NAME"
                //    , topdgv.CurrentRow.Cells[0].Value.ToString());
                //SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                //adapter.Fill(dsexcel, "盤點差異表");
                //for (int i = 0; i < dsexcel.Tables[0].Rows.Count; i++)
                //{
                //    for (int j = 0; j < dsexcel.Tables[0].Columns.Count; j++)
                //    {
                //        worksheet.Cells[i + 3, j + 1] = dsexcel.Tables[0].Rows[i][j].ToString();
                //    }
                //}
                ////((Excel.Range)worksheet.Cells[2, 1]).EntireColumn.ColumnWidth = 10;
                ////((Excel.Range)worksheet.Cells[2, 2]).EntireColumn.ColumnWidth = 30;
                ////((Excel.Range)worksheet.Cells[2, 3]).EntireColumn.ColumnWidth = 10;
                ////((Excel.Range)worksheet.Cells[2, 4]).EntireColumn.ColumnWidth = 25;
                ////((Excel.Range)worksheet.Cells[2, 5]).EntireColumn.ColumnWidth = 4;
                ////((Excel.Range)worksheet.Cells[2, 6]).EntireColumn.ColumnWidth = 20;
                ////((Excel.Range)worksheet.Cells[2, 7]).EntireColumn.ColumnWidth = 25;



                //// 第二頁(原始盤點資料)
                //workbook.Sheets.Add(Type.Missing, worksheet, 1, Type.Missing);
                //Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[2];
                //worksheet2.Name = "Original_Inventory_Information";
                //worksheet2.Cells[1, 1] = "CHECK_BATCH_NO:" + topdgv.CurrentRow.Cells[0].Value.ToString() + "    Dep:" + topdgv.CurrentRow.Cells[2].Value.ToString();
                //var orng2 = worksheet2.Range[worksheet2.Cells[1, 1], worksheet2.Cells[1, 7]];
                //orng2.MergeCells = true;
                //// TITLE資訊
                //worksheet2.Cells[2, 1] = "AssetsNo";
                //worksheet2.Cells[2, 2] = "AssetsName";
                //worksheet2.Cells[2, 3] = "Model";
                //worksheet2.Cells[2, 4] = "OrgLocation";
                //worksheet2.Cells[2, 5] = "CHK";
                //worksheet2.Cells[2, 6] = "ScanDate";
                //worksheet2.Cells[2, 7] = "ScanLocation";
                //// 盤點原始資料
                //string sql2 = string.Format("select ai.AssetNo,acs.ASSETS_NAME,acs.MODEL_NAME,sl.Name orgLocation,acs.IS_CHECK,acs.CHECK_DATE,sl2.Name scanLocation " +
                //    "from ASSETS_CHECK_SUB acs " +
                //    "left join ASSETS_INFORMATION ai on ai.ASSETS_ID=acs.ASSETS_ID " +
                //    "left join StorageLocation sl on sl.StorageLocationNo=acs.ORIGINAL_Location " +
                //    "left join StorageLocation sl2 on sl2.StorageLocationNo=acs.CHECK_Location " +
                //    "where acs.CHECK_BATCH_NO='{0}' " +
                //    "order by acs.IS_CHECK,acs.ASSETS_NAME"
                //    , topdgv.CurrentRow.Cells[0].Value.ToString());
                //SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                //adapter2.Fill(dsexcel, "用量檢查表");
                //for (int i = 0; i < dsexcel.Tables[1].Rows.Count; i++)
                //{
                //    for (int j = 0; j < dsexcel.Tables[1].Columns.Count; j++)
                //    {
                //        worksheet2.Cells[i + 3, j + 1] = dsexcel.Tables[1].Rows[i][j].ToString();
                //    }
                //}
                //((Excel.Range)worksheet2.Cells[2, 1]).EntireColumn.ColumnWidth = 10;
                //((Excel.Range)worksheet2.Cells[2, 2]).EntireColumn.ColumnWidth = 30;
                //((Excel.Range)worksheet2.Cells[2, 3]).EntireColumn.ColumnWidth = 10;
                //((Excel.Range)worksheet2.Cells[2, 4]).EntireColumn.ColumnWidth = 25;
                //((Excel.Range)worksheet2.Cells[2, 5]).EntireColumn.ColumnWidth = 4;
                //((Excel.Range)worksheet2.Cells[2, 6]).EntireColumn.ColumnWidth = 20;
                //((Excel.Range)worksheet2.Cells[2, 7]).EntireColumn.ColumnWidth = 25;
            }
            catch (Exception)
            {
                MessageBox.Show("Excel Export Data Error!");
            }
        }

        #endregion


        #region SIZE RUN

        private void size() 
        {
            try
            {
                //取出SIZE
                ds3 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select ddzls.CC from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh where ddzl.DDBH = '{0}' group by ddzls.cc order by ddzls.cc", textBox1.Text);

                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds3, "棧板表");
                dataGridView2.DataSource = ds3.Tables[0];

                //取出SIZE
                ds4 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = "select ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO,xxzl.Article, xxzl.XieMing, xxzl.YSSM, DDZL.DDGB,DESTINATION.ywsm ";

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    sql2 += string.Format(",sum(isnull(case when CC= '{0}' then Quantity end ,0)) as '{0}'", dataGridView2.Rows[i].Cells[0].Value.ToString());
                }

                sql2 += string.Format("from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh left join xxzl on ddzl.XieXing = xxzl.XieXing   and ddzl.SheHao = xxzl.SheHao left join DESTINATION on ddzl.Dest = DESTINATION.DESTINATION_ID where ddzl.ddbh  =  '{0}' group by ddzls.DDBH, DDZL.ShipDate, DDZL.KHPO, xxzl.Article, xxzl.XieMing, xxzl.YSSM, DDZL.DDGB, DESTINATION.ywsm", textBox1.Text);

                Console.WriteLine(sql2);

                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds4, "棧板表");
                dataGridView3.DataSource = ds4.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion
    }
}
