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
    public partial class CFXTZLSizeCopy : Form
    {
        public CFXTZLSizeCopy()
        {
            InitializeComponent();
        }

        public string userid = "";

        private void L0004_Click(object sender, EventArgs e)
        {
            try
            {
                CFXTZLSCCheck Form = new CFXTZLSCCheck();
                Form.xie = textBox40.Text;
                Form.she = textBox41.Text;
                Form.ShowDialog();
            }
            catch (Exception) { }
        }

        private void L0003_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要覆蓋?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    //xxgj delete
                    DBconnect con3 = new DBconnect();
                    StringBuilder sql3 = new StringBuilder();
                    sql3.AppendFormat("delete xxgj where XieXing  = '{0}' and SheHao = '{1}'", textBox1.Text, textBox2.Text);
                    Console.WriteLine(sql3);
                    SqlCommand cmd3 = new SqlCommand(sql3.ToString(), con3.connection);
                    con3.OpenConnection();
                    int result3 = cmd3.ExecuteNonQuery();
                    if (result3 == 1)
                    {

                    }
                    con3.CloseConnection();

                    //delete xxgjs
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete xxgjs where XieXing  = '{0}' and SheHao = '{1}'", textBox1.Text, textBox2.Text);
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        
                    }
                    con4.CloseConnection();

                    //insert xxgj
                    #region xxgj
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert xxgj (XieXing,SheHao,GJLB, gjmh,USERID,USERDATE,bdate,edate,stat,bz) (select '{0}', '{1}', GJLB, gjmh, '{2}', GETDATE(), bdate, edate, stat, bz from xxgj where XieXing = '{3}' and SheHao = '{4}')", textBox1.Text, textBox2.Text, userid, textBox40.Text, textBox41.Text);

                    Console.WriteLine(sql1);
                    
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                    #endregion

                    //insert xxgjs
                    #region xxgjs
                    int results;
                    DBconnect conns = new DBconnect();
                    string sql1s = string.Format("insert xxgjs (XieXing,SheHao,GJLB, LineNum,XXCC,GJCC,USERID,USERDATE,Gjmh,BB,Mtdj,Crdj,stat,Bdate,Bz) (select '{0}', '{1}', GJLB, LineNum, XXCC, GJCC, '{2}', GETDATE(), Gjmh, BB, Mtdj, Crdj, stat, Bdate, Bz from xxgjs where XieXing = '{3}' and SheHao = '{4}')", textBox1.Text, textBox2.Text, userid, textBox40.Text, textBox41.Text);

                    Console.WriteLine(sql1s);
                    
                    SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                    conns.OpenConnection();
                    results = cmd1s.ExecuteNonQuery();
                    if (results == 1)
                    {

                    }
                    conns.CloseConnection();
                    #endregion

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sql1Y = string.Format("delete ly_shoe.dbo.xxgj where xiexing = '{0}' insert into ly_shoe.dbo.xxgj select xiexing, gjlb, MAX(userid),  CONVERT(varchar,max(USERDATE),11),  null, null, null, null from [192.168.11.15].New_Erp.dbo.xxgj where XieXing = '{0}' group by xiexing, gjlb ", textBox1.Text);
                    Console.WriteLine(sql1Y);
                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {
                    }
                    connY.CloseConnection();

                    int resultsY;
                    DBconnect2 connsY = new DBconnect2();
                    string sql1sY = string.Format("delete ly_shoe.dbo.xxgjs where xiexing = '{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID),  CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz", textBox1.Text);
                    Console.WriteLine(sql1sY);
                    SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                    connsY.OpenConnection();
                    resultsY = cmd1sY.ExecuteNonQuery();
                    if (resultsY == 1)
                    {
                    }
                    connsY.CloseConnection();

                    #endregion

                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception) { }
        }

        private void CFXTZLSizeCopy_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception) { }
        }
    }
}
