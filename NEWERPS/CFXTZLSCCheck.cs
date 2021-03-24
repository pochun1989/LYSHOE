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
    public partial class CFXTZLSCCheck : Form
    {
        public CFXTZLSCCheck()
        {
            InitializeComponent();
        }

        public string xie = "", she = "";
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select * from xxgjs where XieXing  = '{0}' and SheHao = '{1}' and GJLB = '{2}'", xie, she, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds2, "棧板表");

                dataGridView2.DataSource = ds2.Tables[0];

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;
            }
            catch (Exception) { }
        }

        private void CFXTZLSCCheck_Load(object sender, EventArgs e)
        {
            try
            {
                if (xie != "" && she != "") 
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select a.GJLB,ywsm,zwsm from (select * from xxgj where XieXing = '{0}' and SheHao = '{1}' and gjlb != '') as a left join (select * from gjlbzl where gjlb != '') as b on a.GJLB = b.gjlb", xie, she);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
            }
            catch (Exception) { }
        }
    }
}
