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
    public partial class PurchaseMerge : Form
    {
        public PurchaseMerge()
        {
            InitializeComponent();
        }

        private void PurchaseMerge_Load(object sender, EventArgs e)
        {

        }

        public DataSet dsQuery = new DataSet();

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1) 
                {
                    dsQuery = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("SELECT HBCGZL.* ,KFZL.kfjc FROM HBCGZL AS HBCGZL LEFT JOIN KFZL AS KFZL ON HBCGZL.kfdh = KFZL.kfdh where(HBCGZL.CGLB = 'A' AND HBCGZL.GSDH = 'LIN' AND HBCGZL.CGBH LIKE '{0}%'  AND HBCGZL.kfdh LIKE '{1}%' AND HBCGZL.CGBH IN(SELECT CGBH FROM ZLZL WHERE ZLBH LIKE '{2}%')) ORDER BY hbcgzl.userdate DESC", tbSearchP.Text, tbSearchC.Text, tbSearchZ.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    Console.WriteLine(sql);
                    adapter.Fill(dsQuery, "搜尋");
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {

                }
                else if (tabControl1.SelectedTab == tabPage3)
                {

                }
                else if (tabControl1.SelectedTab == tabPage4)
                {

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Search Error");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {

                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    dsQuery = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("SELECT ZLZL.* ,DDZL.XieXing ,DDZL.SheHao ,DDZL.Pairs ,DDZL.KHBH , SPACE(1) AS SW, XXZL.ARTICLE, DDZL.ShipDate, 'N' MARK, DDZL.DDZT, VZLZLS2.USERDATE FROM ZLZL LEFT JOIN DDZL ON ZLZL.DDBH = DDZL.DDBH LEFT JOIN XXZL  ON DDZL.XieXing = XXZL.XieXing AND DDZL.SheHao = XXZL.SheHao LEFT JOIN VZLZLS2 ON ZLZL.ZLBH = VZLZLS2.ZLBH where((ZLZL.CGBH = '{0}'))", textBox1.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    Console.WriteLine(sql);
                    adapter.Fill(dsQuery, "搜尋");
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {

                }
                else if (tabControl1.SelectedTab == tabPage4)
                {

                }
            }
            catch (Exception) { }
        }
    }
}
