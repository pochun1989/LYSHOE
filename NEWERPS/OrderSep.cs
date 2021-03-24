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
    public partial class OrderSep : Form
    {
        public OrderSep()
        {
            InitializeComponent();
        }

        #region 變數

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "080100";//OrderSep

        public string userid = "";
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        DataSet dsY1 = new DataSet();
        DataSet dsY2 = new DataSet();
        Boolean insert = false;

        string[] Alpha = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string DDBH = "";
        string ddbhnormal = "";
        string ddbhold = "";
        #endregion

        #region 畫面載入
        private void OrderSep_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
                ChangeTabControl();

                DBconnect dbconn2 = new DBconnect();
                string sql12 = "select * from KFZL";
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsc1, "倉庫");

                comboBox1.DataSource = dsc1.Tables[0];
                comboBox1.ValueMember = "kfdh";
                comboBox1.DisplayMember = "kfqm";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select * from DESTINATION";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                cbDest.DataSource = dsc3.Tables[0];
                cbDest.ValueMember = "DESTINATION_ID";
                cbDest.DisplayMember = "ywsm";
                cbDest.MaxDropDownItems = 8;
                cbDest.IntegralHeight = false;
                cbDest.SelectedIndex = 1;

                DBconnect dbconn4 = new DBconnect();
                string sql14 = "select * from COUNTRY";
                SqlDataAdapter adapter14 = new SqlDataAdapter(sql14, dbconn4.connection);
                adapter14.Fill(dsc4, "倉庫");

                cbCountry.DataSource = dsc4.Tables[0];
                cbCountry.ValueMember = "COUNTRY_ID";
                cbCountry.DisplayMember = "ywsm";
                cbCountry.MaxDropDownItems = 8;
                cbCountry.IntegralHeight = false;

                dataGridView1.Columns[0].Width = 200;
                dataGridView3.Columns[0].Width = 200;
            }
            catch (Exception) 
            {
                MessageBox.Show("Load Data Error.載入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            }
            catch (Exception) { }
        }

        #endregion

        #region 文字定位

        private void WordPosition()
        {
            try
            {
                //L0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                //L0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                //L0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                //L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                //L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                //L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                //L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                //L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                //L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                //L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                //L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                //L0012.Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                //L0013.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                //L0014.Text = dgvWord.Rows[13].Cells[3].Value.ToString();
                //L0015.Text = dgvWord.Rows[14].Cells[3].Value.ToString();
                //L0016.Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                //L0017.Text = dgvWord.Rows[16].Cells[3].Value.ToString();
                //L0018.Text = dgvWord.Rows[17].Cells[3].Value.ToString();
                //L0019.Text = dgvWord.Rows[18].Cells[3].Value.ToString();
                //L0020.Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                //L0021.Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                //L0022.Text = dgvWord.Rows[25].Cells[3].Value.ToString();
                //L0023.Text = dgvWord.Rows[26].Cells[3].Value.ToString();

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

        private void insertDDZL()
        {
            try
            {
                DDBH = tbDDBH.Text;
                if (checkBox1.Checked == true)
                {
                    #region NEWERP

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into DDZL select '{0}',DDZT,XieXing,SheHao,Version,ARTICLE,CCGB,KHBH,BB,KHPO,Trader,TraderPO,DDLB,CPLB,BZFS,Dest,DDGB,DDRQ,'{1}',JYTJ,FKTJ,ShipDate,Pairs,Totals,ZLBH,GSDH,CFNO,'{2}',GETDATE(),DDCZ,DDPACKSM,LABELCHARGE,Gender,'Y',SC02,PUMAPO,Pairs1,balance,mtgr,mtyf,BUYNO,YN,Pairs2,balance2,KFJD,RYTYPE,FCD,FinishedDay,UsageVer from DDZL where DDBH = '{1}'", DDBH, tbMDDBH.Text, userid);
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
                    string sql1Y = string.Format("delete DDZL where DDBH = '{0}' insert into DDZL select DDBH, XieXing, SheHao, ARTICLE, CCGB, KHBH, BB, KHPO, Version, Trader, TraderPO, DDLB, DDZT, CPLB, BZFS, Dest, DDGB, DDRQ, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) , DDCZ, DDPACKSM, LABELCHARGE, SC01, SC02, PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, Pairs2, balance2, RYTYPE from [192.168.11.15].New_Erp.dbo.DDZL where DDBH = '{0}'", DDBH);
                    Console.WriteLine(sql1Y);

                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {

                    }
                    connY.CloseConnection();

                    #endregion
                }
                else
                {
                    #region NEWERP

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into DDZL select '{0}',DDZT,XieXing,SheHao,Version,ARTICLE,CCGB,KHBH,BB,KHPO,Trader,TraderPO,DDLB,CPLB,BZFS,Dest,DDGB,DDRQ,MDDBH,JYTJ,FKTJ,ShipDate,Pairs,Totals,ZLBH,GSDH,CFNO,'{2}',GETDATE(),DDCZ,DDPACKSM,LABELCHARGE,Gender,'N',SC02,PUMAPO,Pairs1,balance,mtgr,mtyf,BUYNO,YN,Pairs2,balance2,KFJD,RYTYPE,FCD,FinishedDay from DDZL where DDBH = '{1}'", DDBH, tbMDDBH.Text, userid);
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
                    string sql1Y = string.Format("delete DDZL where DDBH = '{0}' insert into DDZL select DDBH, XieXing, SheHao, ARTICLE, CCGB, KHBH, BB, KHPO, Version, Trader, TraderPO, DDLB, DDZT, CPLB, BZFS, Dest, DDGB, DDRQ, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2), DDCZ, DDPACKSM, LABELCHARGE, SC01, SC02, PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, Pairs2, balance2, RYTYPE from [192.168.11.15].New_Erp.dbo.DDZL where DDBH = '{0}'", DDBH);
                    Console.WriteLine(sql1Y);

                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {

                    }
                    connY.CloseConnection();

                    #endregion
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertDDZLs()
        {
            try
            {
                DDBH = tbDDBH.Text;

                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into DDZLs select '{0}',LineNum,CC,NULL,Price,CPrice,IPrice,'{2}',GETDATE(),Quantity1,mtdj,YN,Quantity2,TestQty from DDZLs where DDBH = '{1}'", DDBH, tbMDDBH.Text, userid);
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
                string sql1Y = string.Format("delete DDZLs where DDBH = '{0}' insert into ddzls SELECT[DDBH],[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID], CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2),[Quantity1],[mtdj],[Quantity2],[TestQty] FROM [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{0}'", DDBH);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                }
                connY.CloseConnection();

                int resultY2;
                DBconnect2 connY2 = new DBconnect2();
                string sql1Y2 = string.Format("delete OrderSplit where ddbh='{0}' insert into OrderSplit select ddbh, Pairs, null, MDDBH, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.DDZL where mddbh = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());

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
            catch (Exception)
            {
                MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertzlzl()
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into zlzl select '{0}','{1}',CQDH,KDRQ,CGBH,'N','N',YLBB,'N',GSDH,'{2}',GETDATE(),trandate,transw,YN,'1' from zlzl where DDBH = '{3}'", ddbhnormal, dataGridView3.CurrentRow.Cells[0].Value.ToString(), userid, textBox2.Text);
                Console.WriteLine(sql1);

                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete zlzl where DDBH = '{0}' insert into zlzl(ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, USERDATE, trandate, transw)(select ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2), trandate, transw from [192.168.11.15].New_Erp.dbo.zlzl where DDBH = '{0}')", ddbhnormal);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertzlzls2()
        {
            try
            {
                int ver = 1;

                //刪除ZLZLS2
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete zlzls2 where ZLBH = '{0}'", ddbhnormal);
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

                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                ver = ver - 1;
                string sql1 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver) (select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, CLSL, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from (select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh,  xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null and Usage_R.clsl <> '0' group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh  left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null and Usage_R.clsl <> '0') as zlzlstemp where lycc = 'N' and BWLB != '3' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null and Usage_R.clsl <> '0' group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null and Usage_R.clsl <> '0') as zlzlstemp where lycc = 'Y' and BWLB != '3') as a)", ddbhnormal, userid, ver);

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

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate)(select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", ddbhnormal);

                Console.WriteLine(sql1Y);
                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion

                #endregion
                //insert 拆解母材料
                #region insert ms

                //select 母材料
                int ycount = 0;

                DBconnect dbConnY = new DBconnect();
                string sqlY = string.Format("select count(CLBH) as count from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", ddbhnormal);
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
                    string sql = string.Format("select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,YN,ver from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", ddbhnormal);
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

                            #region NEWERP

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

                            #endregion

                            #region LYSHOE

                            int result3Y;
                            DBconnect2 conn3Y = new DBconnect2();
                            string sql3Y = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2 (zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate)(select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}') ", dgvCAL.Rows[i].Cells[0].Value.ToString());
                            Console.WriteLine(sql3);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd3Y = new SqlCommand(sql3Y, conn3Y.connection);
                            conn3Y.OpenConnection();
                            result3Y = cmd3Y.ExecuteNonQuery();
                            if (result3Y == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn3Y.CloseConnection();

                            #endregion
                        }
                    }
                }

                #endregion

                //MessageBox.Show("插入資料完成", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) 
            {
                //MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("Select * from DDZL where DDZT = 'Y' and DDLB = 'N' and DDBH like '%{0}%' and KHBH like '%{1}%' and ddzl.ShipDate BETWEEN CONVERT(date, '{2}') and convert(date, '{3}') and DDZT <> 'C'", textBox1.Text, comboBox1.SelectedValue, dateTimePicker1.Value.ToShortDateString().ToString(), dateTimePicker2.Value.ToShortDateString().ToString());
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if (tabControl1.SelectedTab == tabPage2) 
                {

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Query Data Error.查詢資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ds3 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select a.CC,Quantity,Pairs from (select DDZLs.CC, DDZLs.Quantity from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh and ddzl.ddzt = 'Y' where ddzl.DDBH = '{0}') as a left join (select CC, sum(quantity) as Pairs from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh and ddzl.ddzt = 'Y' where ddzl.DDBH = '{0}' group by CC) as b on a.CC = b.CC", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds3, "棧板表");
                dataGridView2.DataSource = ds3.Tables[0];
                
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                tbKFBH.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                //textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cbDest.SelectedIndex = 0;
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select CC,isnull(Quantity,0) as Quantity from DDZLs where DDBH = '{0}'", dataGridView3.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView4.DataSource = ds.Tables[0];

                dataGridView4.Visible = true;

                dtpFrom.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                dtpTo.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                cbDest.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                cbCountry.SelectedValue = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();

                tbDDBH.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                tbKHPO.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                insert = true;

                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;

                tbDDBH.Enabled = true;
                tbDDBH.Text = "";

            }
            catch (Exception) 
            {
                //MessageBox.Show("Seperate Error. 分單錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            //int count = 0;
            //count = dataGridView3.Rows.Count;
            //Console.WriteLine(Alpha[count]);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1) 
                {
                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    //tsbSave.Enabled = false;
                    tsbModify.Enabled = false;
                    
                    //tsbConfirm.Enabled = false;
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbModify.Enabled = true;
                    //tsbConfirm.Enabled = false;

                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("No MomOrder.沒有母訂單", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabPage1;
                    }
                    else 
                    {
                        ds2 = new DataSet();
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select distinct  DDZL.DDBH,DDZL.FinishedDay,DDZL.ShipDate,DESTINATION.ywsm,DDZL.DDGB,DDZL.XieXing,DDZL.SheHao,xxzl.XieMing,DDZL.KHPO from DDZL left  join xxzl on DDZL.XieXing = xxzl.XieXing left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where ddzl.MDDBH = '{0}' and ddzl.ddzt = 'Y' and DDZL.DDBH <> '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "棧板表");
                        dataGridView3.DataSource = ds2.Tables[0];

                        if (dataGridView3.Rows.Count == 0) 
                        {
                            dataGridView4.Visible = false;
                        }
                        else 
                        {
                            dataGridView4.Visible = true;
                            tsbModify.Enabled = true;
                        }

                        tbMDDBH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error. 錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (insert == false)
                {
                    dataGridView4.EndEdit();

                    if (tabControl1.SelectedTab == tabPage2)
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
                        sql5.AppendFormat("update DDZL set FinishedDay = '{0}', ShipDate = '{1}', Dest = '{2}', DDGB = '{3}', KHPO = '{5}' where DDBH = '{4}'", dtpFrom.Value.ToString("yyyy/MM/dd"), dtpTo.Value.ToString("yyyy/MM/dd"), cbDest.SelectedValue, cbCountry.SelectedValue, dataGridView3.CurrentRow.Cells[0].Value.ToString().Trim(), tbKHPO.Text);
                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con5.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("update DDZL set  ShipDate = CAST(year('{1}') as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month('{1}') as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day('{1}') as NVARCHAR), 2), Dest = '{2}', DDGB = '{3}', KHPO = '{5}' where DDBH = '{4}'", dtpFrom.Value.ToString("yyyyMMdd"), dtpTo.Value.ToString("yyyyMMdd"), cbDest.SelectedValue, cbCountry.SelectedValue, dataGridView3.CurrentRow.Cells[0].Value.ToString().Trim(), tbKHPO.Text);
                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con5Y.CloseConnection();

                        #endregion

                        #endregion

                        int sum = 0;
                        for (int i = 0; i < dataGridView4.Rows.Count; i++)
                        {
                            sum += int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                            //DDZLS
                            #region NEWERP

                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update DDZLs set Quantity = '{0}',USERID = '{1}',USERDATE = GETDATE() where DDBH = '{2}' and CC = '{3}'", dataGridView4.Rows[i].Cells[1].Value.ToString(), userid, dataGridView3.CurrentRow.Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[0].Value.ToString());
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
                            sql4Y.AppendFormat("update DDZLs set Quantity = '{0}',USERID = '{1}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{2}' and CC = '{3}'", dataGridView4.Rows[i].Cells[1].Value.ToString(), userid, dataGridView3.CurrentRow.Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[0].Value.ToString());
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
                        }

                        DBconnect con4s = new DBconnect();
                        StringBuilder sql4s = new StringBuilder();
                        sql4s.AppendFormat("update ddzl set Pairs = '{0}' where DDBH  = '{1}'", sum, dataGridView3.CurrentRow.Cells[0].Value.ToString());
                        Console.WriteLine(sql4s);
                        SqlCommand cmd4s = new SqlCommand(sql4s.ToString(), con4s.connection);

                        con4s.OpenConnection();
                        int result4s = cmd4s.ExecuteNonQuery();
                        if (result4s == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4s.CloseConnection();


                        dtpFrom.Enabled = false;
                        dtpTo.Enabled = false;
                        cbDest.Enabled = false;
                        cbCountry.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbSave.Enabled = false;
                        tbKHPO.Enabled = false;
                        dataGridView4.ReadOnly = true;

                        #region RELOAD

                        ds2 = new DataSet();
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select distinct  DDZL.DDBH,DDZL.FinishedDay,DDZL.ShipDate,DESTINATION.ywsm,DDZL.DDGB,DDZL.XieXing,DDZL.SheHao,xxzl.XieMing,DDZL.KHPO from DDZL left  join xxzl on DDZL.XieXing = xxzl.XieXing left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where ddzl.MDDBH = '{0}' and ddzl.ddzt = 'Y'", textBox2.Text);
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(ds2, "棧板表");
                        dataGridView3.DataSource = ds2.Tables[0];

                        #endregion
                    }
                }
                else if (insert == true)
                {
                    if (dataGridView3.Rows.Count == 26)
                    {
                        MessageBox.Show("Over Seperate Time.超出分單限制", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Keep Seperate Order? 確定要拆分?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            OrderCheck oc = new OrderCheck();

                            if (oc.check(tbDDBH.Text.Trim()) == true)
                            {
                                if (tbMDDBH.TextLength == 13) //第一次分單
                                {
                                    //int count = 0;

                                    //DBconnect dbConn = new DBconnect();
                                    //string sql = string.Format("select count(DDBH) as count from DDZL where MDDBH = '{0}'", textBox2.Text);
                                    //SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                                    //dbConn.OpenConnection();
                                    //SqlDataReader reader = cmd.ExecuteReader();
                                    //if (reader.Read())
                                    //{
                                    //    count = int.Parse(reader["count"].ToString());
                                    //}
                                    //dbConn.CloseConnection();

                                    //Console.WriteLine(Alpha[count]);

                                    //DDBH = textBox2.Text;
                                    //DDBH = "Z" + DDBH + Alpha[count];
                                    //Console.WriteLine(DDBH);

                                    insertDDZL();
                                    insertDDZLs();
                                }
                                else if (tbMDDBH.TextLength == 14) //第二次分單
                                {
                                    int count = 0;

                                    DBconnect dbConn = new DBconnect();
                                    string sql = string.Format("select count(DDBH) as count from DDZL where MDDBH = '{0}'", textBox2.Text);
                                    SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                                    dbConn.OpenConnection();
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        count = int.Parse(reader["count"].ToString());
                                    }
                                    dbConn.CloseConnection();

                                    Console.WriteLine(Alpha[count]);

                                    DDBH = textBox2.Text;
                                    DDBH = "Z" + DDBH + Alpha[count];
                                    Console.WriteLine(DDBH);

                                    insertDDZL();
                                    insertDDZLs();
                                }
                                else
                                {
                                    MessageBox.Show("Over Seperate Time. 訂單號長度有誤，超過分單次數", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                ds2 = new DataSet();
                                DBconnect dbConn2 = new DBconnect();
                                string sql2 = string.Format("select distinct  DDZL.DDBH,DDZL.FinishedDay,DDZL.ShipDate,DESTINATION.ywsm,DDZL.DDGB,DDZL.XieXing,DDZL.SheHao,xxzl.XieMing,DDZL.KHPO from DDZL left  join xxzl on DDZL.XieXing = xxzl.XieXing left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where ddzl.MDDBH = '{0}' and ddzl.ddzt = 'Y'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                Console.WriteLine(sql2);
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                                adapter2.Fill(ds2, "棧板表");
                                dataGridView3.DataSource = ds2.Tables[0];

                                tsbSave.Enabled = true;
                                tsbCancel.Enabled = true;
                                dataGridView4.ReadOnly = false;
                                tsbConfirm.Enabled = true;
                            }
                            else 
                            {
                                MessageBox.Show("DDBH ERROR", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }

                tsbInsert.Enabled = true;
                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;

                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cbDest.Enabled = false;
                cbCountry.Enabled = false;
                tbDDBH.Enabled = false;
                tbKFBH.Enabled = false;
                tbKHPO.Enabled = false;
            }
            catch (Exception) 
            {
                MessageBox.Show("Save Error. 儲存錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    DialogResult dr = MessageBox.Show("Keep Delete? 確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZL set DDZT = 'C', USERID = '{1}', USERDATE = GETDATE() where DDBH = '{0}'", dataGridView3.CurrentRow.Cells[0].Value.ToString(), userid);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("Delete Success.停用資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZL set DDZT = 'C', USERID = '{1}', USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) where DDBH = '{0}'", dataGridView3.CurrentRow.Cells[0].Value.ToString(), userid);
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("停用資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion
                    }

                    for (int i = 0; i < dataGridView3.Rows.Count; i++) 
                    {
                        dataGridView3.Rows.RemoveAt(0);
                    }

                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("Select ddzl.*,zlzl.CQDH from DDZL left join zlzl on ddzl.ddbh = zlzl.DDBH where ddzl.MDDBH = '{0}' and ddzl.ddzt = 'Y'", textBox2.Text);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter2.Fill(ds2, "棧板表");
                    dataGridView3.DataSource = ds2.Tables[0];

                    if (dataGridView3.Rows.Count == 0)
                    {
                        dataGridView4.Visible = false;
                        tsbConfirm.Enabled = false;
                    }
                    else
                    {
                        dataGridView4.Visible = true;
                        tsbConfirm.Enabled = true;
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Delete Error. 刪除錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from (select ddzls.CC,sum(isnull(ddzls.Quantity,0)) as sq ,isnull(f.Quantity,0) as Quantity from ddzls left join ddzl on ddzl.ddbh=ddzls.ddbh left join (select cc,Quantity from DDZLs where ddbh='{0}') as F on f.cc=ddzls.cc where ddzl.MDDBH like '{0}%' and ddzt <> 'C' group by ddzls.CC,f.Quantity) as p where sq <> Quantity", textBox2.Text);

                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dgvconfirm.DataSource = ds.Tables[0];

                if (dgvconfirm.Rows.Count == 0) //數量正確
                {
                    tsbConfirm.Enabled = false;

                    tsbConfirm.Enabled = false;

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        //插入刪除Z訂單號
                        ddbhnormal = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        ddbhold = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        //ddbhnormal = dataGridView3.Rows[i].Cells[0].Value.ToString().Substring(1);
                        Console.WriteLine(ddbhnormal);
                        Console.WriteLine(ddbhold);

                        SepConfirm();

                        //刪除Z訂單號
                        //SepDelete();

                        //zlzl
                        //insertzlzl();

                        //zlzls2
                        //insertzlzls2();

                        //修改母訂單

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update ddzl set DDZT = 'S' where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {

                        }
                        con4.CloseConnection();

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update ddzl set DDZT = 'S' where DDBH = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);
                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {

                        }
                        con4Y.CloseConnection();

                        DBconnect con4M = new DBconnect();
                        StringBuilder sql4M = new StringBuilder();
                        sql4M.AppendFormat("update ddzl set MDDBH = '{0}' where DDBH = '{1}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView3.Rows[i].Cells[0].Value.ToString().Substring(1));

                        Console.WriteLine(sql4M);
                        SqlCommand cmd4M = new SqlCommand(sql4M.ToString(), con4M.connection);
                        con4M.OpenConnection();
                        int result4M = cmd4M.ExecuteNonQuery();
                        if (result4M == 1)
                        {

                        }
                        con4M.CloseConnection();

                    }

                    //顯示資料
                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select distinct  DDZL.DDBH,DDZL.FinishedDay,DDZL.ShipDate,DESTINATION.ywsm,DDZL.DDGB,DDZL.XieXing,DDZL.SheHao,xxzl.XieMing,DDZL.KHPO from DDZL left  join xxzl on DDZL.XieXing = xxzl.XieXing left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID where ddzl.MDDBH = '{0}' and ddzl.ddzt = 'Y'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter2.Fill(ds2, "棧板表");
                    dataGridView3.DataSource = ds2.Tables[0];


                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    dataGridView4.ReadOnly = false;
                    tsbConfirm.Enabled = false;

                    MessageBox.Show("Seperate Success.拆單成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Size Number Not Currect.拆單數量不正確 請重新計算!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Seperate Fail. 分單失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SepConfirm()
        {
            try
            {
                //ddzl
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into DDZL select '{0}',DDZT,XieXing,SheHao,Version,ARTICLE,CCGB,KHBH,BB,KHPO,Trader,TraderPO,DDLB,CPLB,BZFS,Dest,DDGB,DDRQ,DDBH,JYTJ,FKTJ,ShipDate,Pairs,Totals,ZLBH,GSDH,CFNO,'{2}',GETDATE(),DDCZ,DDPACKSM,LABELCHARGE,Gender,SC01,SC02,PUMAPO,Pairs1,balance,mtgr,mtyf,BUYNO,YN,Pairs2,balance2,KFJD,RYTYPE,FCD,FinishedDay,UsageVer from DDZL where DDBH = '{1}'", ddbhnormal, ddbhold, userid);
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
                string sql1Y = string.Format("delete DDZL where DDBH = '{0}' insert into DDZL select '{1}', XieXing, SheHao, ARTICLE, CCGB, KHBH, BB, KHPO, Version, Trader, TraderPO, DDLB, DDZT, CPLB, BZFS, Dest, DDGB, DDRQ, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) , DDCZ, DDPACKSM, LABELCHARGE, SC01, SC02, PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, Pairs2, balance2, RYTYPE from [192.168.11.15].New_Erp.dbo.DDZL where DDBH = '{1}'", ddbhold, ddbhnormal);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {

                }
                connY.CloseConnection();

                #endregion

                //ddzls
                #region NEWERP

                int resultS;
                DBconnect connS = new DBconnect();
                string sql1S = string.Format("insert into DDZLs select '{0}',LineNum,CC,Quantity,Price,CPrice,IPrice,'{2}',GETDATE(),Quantity1,mtdj,YN,Quantity2,TestQty from DDZLs where DDBH = '{1}'", ddbhnormal, ddbhold, userid);
                Console.WriteLine(sql1S);

                SqlCommand cmd1S = new SqlCommand(sql1S, connS.connection);
                connS.OpenConnection();
                resultS = cmd1S.ExecuteNonQuery();
                if (resultS == 1)
                {

                }
                connS.CloseConnection();


                #endregion

                #region LYSHOE

                int resultYS;
                DBconnect2 connYS = new DBconnect2();
                string sql1YS = string.Format("delete DDZLs where DDBH = '{0}' insert into ddzls SELECT '{1}',[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID],CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) ,[Quantity1],[mtdj],[Quantity2],[TestQty] FROM [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{1}'", ddbhold, ddbhnormal);
                Console.WriteLine(sql1YS);

                SqlCommand cmd1YS = new SqlCommand(sql1YS, connYS.connection);
                connYS.OpenConnection();
                resultYS = cmd1YS.ExecuteNonQuery();
                if (resultYS == 1)
                {
                }
                connYS.CloseConnection();

                int resultY2;
                DBconnect2 connY2 = new DBconnect2();
                string sql1Y2 = string.Format("delete OrderSplit where ddbh='{0}' insert into OrderSplit select '{1}', Pairs, null, MDDBH, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.DDZL where mddbh = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim(), ddbhnormal);

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
            catch (Exception) 
            {
                //MessageBox.Show("Insert Fail. 新增DDZL失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SepDelete() 
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete ddzl where DDBH = '{0}'", ddbhold);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                DBconnect con5 = new DBconnect();
                StringBuilder sql5 = new StringBuilder();
                sql5.AppendFormat("delete ddzls where DDBH = '{0}'", ddbhold);
                Console.WriteLine(sql5);
                SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                con5.OpenConnection();
                int result5 = cmd5.ExecuteNonQuery();
                if (result5 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con5.CloseConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Fail. 刪除失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderSep_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tsbConfirm.Enabled == true) 
            {
                MessageBox.Show("Confirm First.請先拆單確認", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cbDest.Enabled = false;
                cbCountry.Enabled = false;
                tsbCancel.Enabled = false;
                tsbSave.Enabled = false;
                tbKHPO.Enabled = false;
                dataGridView4.ReadOnly = true;
                tabControl1.SelectedTab = tabPage1;

                tsbInsert.Enabled = true;
                tsbModify.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;

                tbDDBH.Enabled = false;
                tbKFBH.Enabled = false;
                tbKHPO.Enabled = false;
                tbDDBH.Text = "";
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    insert = false;

                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    cbDest.Enabled = true;
                    cbCountry.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbSave.Enabled = true;
                    tbKHPO.Enabled = true;
                    dataGridView4.ReadOnly = false;
                }
            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {

        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {

        }

        private void tsbSize_Click(object sender, EventArgs e)
        {

        }

        private void tsbM_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
