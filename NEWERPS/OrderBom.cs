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
    public partial class OrderBom : Form
    {
        public OrderBom()
        {
            InitializeComponent();
        }

        DataSet dsDrop = new DataSet();
        DataSet dsLoad = new DataSet();
        public string userid = "";

        private void OrderBom_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                DBconnect dbconn2 = new DBconnect();
                string sql12 = "select * from bwzl";
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsDrop, "倉庫");

                comboBox1.DataSource = dsDrop.Tables[0];
                comboBox1.ValueMember = "bwdh";
                comboBox1.DisplayMember = "bwdh";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                FormLoad();
            }
            catch (Exception) 
            {
                MessageBox.Show("Load Data Error.載入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLoad() 
        {
            dsLoad = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from BOMAD where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}'", tbXiexing.Text, tbShehao.Text, tbOrder.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsLoad, "棧板表");
            dataGridView1.DataSource = dsLoad.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //delete
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete zlzls2 where zlbh = '{0}' and BWBH in (select bwbh from BOMAD where cond = '{0}' and ADTYP = 'D')", tbOrder.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();


                //insert

                //maxver
                int maxver = 0;
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select max(ver) as max from zlzls2 where ZLBH = '{0}'", tbOrder.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    maxver = int.Parse(reader1["max"].ToString());
                }
                dbConn1.CloseConnection();


                DataSet dsBOM = new DataSet();
                dsBOM = new DataSet();
                DBconnect dbConnB = new DBconnect();
                string sqlB = string.Format("select * from BOMAD where XieXing = '{0}' and SheHao = '{1}' and ADTYP = 'A' and cond = '{2}'", tbXiexing.Text, tbShehao.Text, tbOrder.Text);
                SqlDataAdapter adapterB = new SqlDataAdapter(sqlB, dbConnB.connection);
                adapterB.Fill(dsBOM, "新增");
                dataGridView2.DataSource = dsBOM.Tables[0];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver)(select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, sum(CLSL) as clsl, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from(select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join xxzls on ddzl.XieXing = xxzls.XieXing and DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'N' and zlzlstemp.BWBH = '{3}' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from(select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and  xxgjs.SheHao = ddzl.SheHao and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'Y' and zlzlstemp.BWBH = '{3}') as a group by DDBH, BWBH, CSBH, CLBH, clzmlb, SIZE, USAGE)", tbOrder.Text, userid, maxver, dataGridView2.Rows[i].Cells[4].Value.ToString());
                    Console.WriteLine(sql);

                    SqlCommand cmd = new SqlCommand(sql, conn.connection);
                    conn.OpenConnection();
                    result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                }

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete zlzls2 where ZLBH = '{0}' insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE)(select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", tbOrder.Text);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();


                this.Close();
            }
            catch (Exception) 
            {
                //MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into BOMAD (XieXing,SheHao,ctyp,cond,BWBH,ADTYP,USERID,USERDATE) values('{0}','{1}','1','{2}','{3}','D','{4}', GETDATE()) ",tbXiexing.Text, tbShehao.Text, tbOrder.Text, comboBox1.SelectedValue, userid);
                Console.WriteLine(sql1);

                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {

                }
                conn.CloseConnection();

                FormLoad();
            }
            catch (Exception) 
            {
                MessageBox.Show("Insert Data Error.插入資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int bom = 0; 
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select count(BWBH) as count from xxzls where XieXing = '{0}' and shehao = '{1}' and BWBH = '{2}'", tbXiexing.Text, tbShehao.Text, comboBox1.SelectedValue);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    bom = int.Parse(reader1["count"].ToString());
                }
                dbConn1.CloseConnection();

                if (bom > 0)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql = string.Format("insert into BOMAD (XieXing,SheHao,ctyp,cond,BWBH,ADTYP,USERID,USERDATE) values('{0}','{1}','1','{2}','{3}','A','{4}', GETDATE()) ", tbXiexing.Text, tbShehao.Text, tbOrder.Text, comboBox1.SelectedValue, userid);
                    Console.WriteLine(sql);

                    SqlCommand cmd = new SqlCommand(sql, conn.connection);
                    conn.OpenConnection();
                    result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                }
                else 
                {
                    MessageBox.Show("Cannot Find This Part In Bom");
                }

                FormLoad();
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete BOMAD where  XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}'", tbXiexing.Text,tbShehao.Text, tbOrder.Text, dataGridView1.CurrentRow.Cells[4].Value.ToString());
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                FormLoad();
            }
            catch (Exception) 
            {
                MessageBox.Show("Delete Data Error.刪除資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
