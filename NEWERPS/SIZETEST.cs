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
    public partial class SIZETEST : Form
    {
        public SIZETEST()
        {
            InitializeComponent();
        }

        public string ddbh = "";


        private void SIZETEST_Load(object sender, EventArgs e)
        {
            try
            {
                //listone
                DBconnect dbConn = new DBconnect();
                DataSet dsexcel = new DataSet();
                string sql = string.Format("select DDZL.DDBH,DDZL.DDBH,kfzl.kfjc,DDZL.XieXing,xxzl.XieMing, CONVERT(varchar(12), DDZL.ShipDate, 111 ) as shipdate , CONVERT(varchar(12), getdate(), 111 ) as Date, DDZL.SheHao,xxzl.YSSM, DDZL.ARTICLE,DDZL.Pairs,DDZL.KHPO,DESTINATION.DESTINATION_ID, xxzl.BZCC,xxzl.XTMH,xxzl.DDMH,xxzl.MDMH, xxzl.DAOMH from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing and DDZL.SheHao = xxzl.SheHao left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID left join kfzl on ddzl.KHBH = kfzl.kfdh where DDBH = '{0}'", ddbh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsexcel, "前身");
                Console.WriteLine(sql);

                listBox1.Items.Clear();
                listBox1.Items.Add("ORDER# : "+ dsexcel.Tables[0].Rows[0][0].ToString());
                listBox1.Items.Add("PROJECT# : " + dsexcel.Tables[0].Rows[0][1].ToString());
                listBox1.Items.Add("CUSTOMER# : " + dsexcel.Tables[0].Rows[0][2].ToString());
                listBox1.Items.Add("MODEL# : " + dsexcel.Tables[0].Rows[0][3].ToString());
                listBox1.Items.Add("MODEL : " + dsexcel.Tables[0].Rows[0][4].ToString());
                listBox1.Items.Add("ETD : " + dsexcel.Tables[0].Rows[0][5].ToString());
                listBox1.Items.Add("SHIPDATE : " + dsexcel.Tables[0].Rows[0][5].ToString());
                listBox1.Items.Add("DATE : " + dsexcel.Tables[0].Rows[0][6].ToString());
                listBox1.Items.Add("COLOR : " + dsexcel.Tables[0].Rows[0][7].ToString());
                listBox1.Items.Add("COLOR DESC : " + dsexcel.Tables[0].Rows[0][8].ToString());
                listBox1.Items.Add("RCVD : ");
                listBox1.Items.Add("ARTICLE : " + dsexcel.Tables[0].Rows[0][9].ToString());
                listBox1.Items.Add("PAIRS : " + dsexcel.Tables[0].Rows[0][10].ToString());
                listBox1.Items.Add("PO# : " + dsexcel.Tables[0].Rows[0][11].ToString());

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

                listBox1.Items.Add("DEST : " + dest);
                listBox1.Items.Add("STD# : " + dsexcel.Tables[0].Rows[0][13].ToString());
                listBox1.Items.Add("LAST : " + dsexcel.Tables[0].Rows[0][14].ToString());
                listBox1.Items.Add("O/S : " + dsexcel.Tables[0].Rows[0][15].ToString());
                listBox1.Items.Add("M/S : " + dsexcel.Tables[0].Rows[0][16].ToString());
                listBox1.Items.Add("CUT DIE : " + dsexcel.Tables[0].Rows[0][17].ToString());

                //dgv2

                #region SIZERUN

                DataSet dsexcel3 = new DataSet();
                DataSet dsexcel4 = new DataSet();
                DataSet dsexcel5 = new DataSet();
                DataSet dsexcel6 = new DataSet();
                //取DDZLS
                DataSet ds3 = new DataSet();
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select * from ddzls where DDBH = '{0}'", dsexcel.Tables[0].Rows[0][0].ToString());
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn3.connection);
                adapter3.Fill(dsexcel3, "SIZE");
                

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    dataGridView2.Columns.Add(col);

                    dataGridView2.Columns[2+i].HeaderText = dsexcel3.Tables[0].Rows[i][1].ToString();
                }
                dataGridView2.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells[0].Value = "SIZE RUN";
                dataGridView2.Rows[1].Cells[0].Value = "LAST";
                dataGridView2.Rows[2].Cells[0].Value = "OUTSOLE";
                dataGridView2.Rows[3].Cells[0].Value = "CUTDIE";
                dataGridView2.Rows[4].Cells[0].Value = "ORDER QTY";

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    dataGridView2.Rows[0].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][2].ToString();
                    //dataGridView2.Rows[1].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][3].ToString();
                }

                //100
                DataSet ds4 = new DataSet();
                DBconnect dbConn4 = new DBconnect();
                string sql4 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '100'", dsexcel.Tables[0].Rows[0][3].ToString(), dsexcel.Tables[0].Rows[0][7].ToString());
                SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn4.connection);
                adapter4.Fill(dsexcel4, "SIZE");

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dsexcel4.Tables[0].Rows.Count; j++)
                    {
                        if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel4.Tables[0].Rows[j][4].ToString().Trim()))
                        {
                            dataGridView2.Rows[1].Cells[2 + i].Value = dsexcel4.Tables[0].Rows[j][5].ToString();
                        }
                    }
                }

                //101
                DataSet ds5 = new DataSet();
                DBconnect dbConn5 = new DBconnect();
                string sql5 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '101'", dsexcel.Tables[0].Rows[0][3].ToString(), dsexcel.Tables[0].Rows[0][7].ToString());
                SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, dbConn5.connection);
                adapter5.Fill(dsexcel5, "SIZE");

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dsexcel5.Tables[0].Rows.Count; j++)
                    {
                        if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel5.Tables[0].Rows[j][4].ToString().Trim()))
                        {
                            dataGridView2.Rows[2].Cells[2 + i].Value = dsexcel5.Tables[0].Rows[j][5].ToString();
                        }
                    }
                }

                //200
                DataSet ds6 = new DataSet();
                DBconnect dbConn6 = new DBconnect();
                string sql6 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '200'", dsexcel.Tables[0].Rows[0][3].ToString(), dsexcel.Tables[0].Rows[0][7].ToString());
                SqlDataAdapter adapter6 = new SqlDataAdapter(sql6, dbConn6.connection);
                adapter6.Fill(dsexcel6, "SIZE");

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dsexcel6.Tables[0].Rows.Count; j++)
                    {
                        if (double.Parse(dsexcel3.Tables[0].Rows[i][2].ToString().Trim()) == double.Parse(dsexcel6.Tables[0].Rows[j][4].ToString().Trim()))
                        {
                            dataGridView2.Rows[3].Cells[2 + i].Value = dsexcel6.Tables[0].Rows[j][5].ToString();
                        }
                    }
                }

                for (int i = 0; i < dsexcel3.Tables[0].Rows.Count; i++)
                {
                    //dataGridView2.Rows[0].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][2].ToString();
                    dataGridView2.Rows[4].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][3].ToString();
                }

                //int sum = 0;
                //for (int i = 0; i < dsexcel3.Tables[0].Columns.Count-2; i++)
                //{
                //    sum += int.Parse(dataGridView2.Rows[4].Cells[2 + i].Value.ToString());
                //    //dataGridView2.Rows[0].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][2].ToString();
                //    //dataGridView2.Rows[4].Cells[2 + i].Value = dsexcel3.Tables[0].Rows[i][3].ToString();
                //}
                //dataGridView2.Rows[4].Cells[1].Value = sum;
                dataGridView2.Rows[4].Cells[1].Value = dsexcel.Tables[0].Rows[0][10].ToString();

                #endregion

                //dgv3
                DataSet dsexcel2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("if object_id('tempdb..#Material') is not null begin drop table #Material end ");
                sql2 += string.Format("SELECT ZLZLS2.XH, ZLZLS2.bwbh, max(BWZL.ywsm) AS BWMCY, zlzls2.clbh AS clbh, max(CLZL.ywpm) AS CLMCY, max(CLZL.dwbh) AS dwbh, max(zszl.zsywjc) as zsywjc, XXZLS.LOSS , sum(zlzls2.clsl) AS clsl , MAX(ZLZLS2.USAGE) AS USAGE, CLZL.CQDH, max(zlzls2.mjbh) AS mjbh, XXZLS.JGYWSM ,XXZLS.CCQQ,XXZLS.CCQZ into #Material FROM ZLZLS2 AS ZLZLS2 LEFT JOIN BWZL AS BWZL ON ZLZLS2.BWBH = BWZL.bwdh LEFT JOIN CLZL AS CLZL ON ZLZLS2.CLBH = CLZL.cldh LEFT JOIN DDZL AS DDZL ON ZLZLS2.ZLBH = DDZL.ZLBH left join zszl as zszl on zlzls2.csbh=zszl.zsdh LEFT JOIN XXZLS AS XXZLS ON DDZL.XIEXING = XXZLS.XIEXING  AND DDZL.SHEHAO = XXZLS.SHEHAO AND ZLZLS2.BWBH = XXZLS.BWBH where ZLZLS2.ZLBH= '");
                sql2 += dsexcel.Tables[0].Rows[0][0].ToString();
                sql2 += string.Format("' and ZLZLS2.MJBH='ZZZZZZZZZZ' GROUP BY ZLZLS2.XH,zlzls2.zlbh,zlzls2.bwbh,zlzls2.clbh,XXZLS.CLSL,CLZL.CQDH,XXZLS.LOSS,XXZLS.JGYWSM ,XXZLS.CCQQ,XXZLS.CCQZ ORDER BY zlzls2.zlbh ,ZLZLS2.XH, zlzls2.bwbh ASC ");
                sql2 += string.Format("update #Material set CLMCY=CLMCY+JGYWSM where JGYWSM is not Null ");
                sql2 += string.Format("update #Material set CLMCY=CLMCY+'('+CCQQ+'-' where CCQQ >' ' ");
                sql2 += string.Format("update #Material set CLMCY=CLMCY+CCQZ+')' where CCQZ >' '  ");
                sql2 += string.Format(" select * from #Material order by BWBH ");
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(dsexcel2, "尾身");
                Console.WriteLine(sql2);

                //Console.WriteLine(dsexcel2.Tables[0].Rows.Count);
                for (int i = 0; i < 15; i ++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    dataGridView3.Columns.Add(col);
                }
                dataGridView3.Columns[0].HeaderText = "XH";
                dataGridView3.Columns[1].HeaderText = "PART NO";
                dataGridView3.Columns[2].HeaderText = "PART DESCRIPTION";
                dataGridView3.Columns[3].HeaderText = "MAT. NO";
                dataGridView3.Columns[4].HeaderText = "MATERIAL DESCRIPTION";
                dataGridView3.Columns[5].HeaderText = "UNIT";
                dataGridView3.Columns[6].HeaderText = "zsqm";
                dataGridView3.Columns[7].HeaderText = "LOSS";
                dataGridView3.Columns[8].HeaderText = "QTY";
                dataGridView3.Columns[9].HeaderText = "USAGE";
                dataGridView3.Columns[10].HeaderText = "AR.";
                dataGridView3.Columns[11].HeaderText = "mjbh";
                dataGridView3.Columns[12].HeaderText = "jqywsm";
                dataGridView3.Columns[13].HeaderText = "ccqq";
                dataGridView3.Columns[14].HeaderText = "ccqz";


                for (int i = 0; i < dsexcel2.Tables[0].Rows.Count; i++)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[0].Value = dsexcel2.Tables[0].Rows[i][0].ToString();
                    dataGridView3.Rows[i].Cells[1].Value = dsexcel2.Tables[0].Rows[i][1].ToString();
                    dataGridView3.Rows[i].Cells[2].Value = dsexcel2.Tables[0].Rows[i][2].ToString();
                    dataGridView3.Rows[i].Cells[3].Value = dsexcel2.Tables[0].Rows[i][3].ToString();
                    dataGridView3.Rows[i].Cells[4].Value = dsexcel2.Tables[0].Rows[i][4].ToString();
                    dataGridView3.Rows[i].Cells[5].Value = dsexcel2.Tables[0].Rows[i][5].ToString();
                    dataGridView3.Rows[i].Cells[6].Value = dsexcel2.Tables[0].Rows[i][6].ToString();
                    dataGridView3.Rows[i].Cells[7].Value = dsexcel2.Tables[0].Rows[i][7].ToString();
                    dataGridView3.Rows[i].Cells[8].Value = dsexcel2.Tables[0].Rows[i][8].ToString();
                    dataGridView3.Rows[i].Cells[9].Value = dsexcel2.Tables[0].Rows[i][9].ToString();
                    dataGridView3.Rows[i].Cells[10].Value = dsexcel2.Tables[0].Rows[i][10].ToString();
                    dataGridView3.Rows[i].Cells[11].Value = dsexcel2.Tables[0].Rows[i][11].ToString();
                    dataGridView3.Rows[i].Cells[12].Value = dsexcel2.Tables[0].Rows[i][12].ToString();
                    dataGridView3.Rows[i].Cells[13].Value = dsexcel2.Tables[0].Rows[i][13].ToString();
                    dataGridView3.Rows[i].Cells[14].Value = dsexcel2.Tables[0].Rows[i][14].ToString();
                }


            }
            catch (Exception) { }
        }
    }
}
