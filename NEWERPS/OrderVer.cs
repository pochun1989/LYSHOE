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
    public partial class OrderVer : Form
    {
        public OrderVer()
        {
            InitializeComponent();
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    DataSet ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from zlzls2 where ZLBH = '{0}'", tbDDBH.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView2.DataSource = ds.Tables[0];
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (tbDDBH.Text != "" && tbVER.Text != "") 
                    {
                        DataSet ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select * from zlzls2old where ZLBH = '{0}' and PLUS = '{1}'", tbDDBH.Text, tbVER.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表"); 
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {

                    if (tbDDBH.Text != "" && tbVER2.Text != "")
                    {
                        DataSet dsI = new DataSet();
                        DBconnect dbConnI = new DBconnect();
                        string sqlI = string.Format("select * from zlzls2old where ZLBH = '{0}' and PLUS = '{1}' and BWBH not in (select BWBH from zlzls2old where ZLBH = '{0}' and PLUS = ({1}-1))", tbDDBH.Text, tbVER2.Text);
                        Console.WriteLine(sqlI);
                        SqlDataAdapter adapterI = new SqlDataAdapter(sqlI, dbConnI.connection);
                        adapterI.Fill(dsI, "Insert");
                        dgvInsert.DataSource = dsI.Tables[0];

                        DataSet dsD = new DataSet();
                        DBconnect dbConnD = new DBconnect();
                        string sqlD = string.Format("select * from zlzls2old where ZLBH = '{0}' and PLUS = ({1}-1) and BWBH not in (select BWBH from zlzls2old where ZLBH = '{0}' and PLUS = '{1}')", tbDDBH.Text, tbVER2.Text);
                        Console.WriteLine(sqlD);
                        SqlDataAdapter adapterD = new SqlDataAdapter(sqlD, dbConnD.connection);
                        adapterD.Fill(dsD, "Delete");
                        dgvDelete.DataSource = dsD.Tables[0];

                        DataSet dsC = new DataSet();
                        DBconnect dbConnC = new DBconnect();
                        string sqlC = string.Format("(select a.BWBH as now, b.BWBH as old,isnull(a.CLBH,'') as clbhnow,isnull(b.CLBH,'') clbhold, isnull(a.CLSL, '0') as clslnow, isnull(b.CLSL, '0') as clslold, a.SIZE as sizenew, b.SIZE as sizeold, a.ZMLB as zmlbnew, b.ZMLB as zmlbold, a.USERID as usernow, b.USERID as userold,a.USERDATE as datenow, b.USERDATE as dateold from (select * from zlzls2old where ZLBH = '{0}' and PLUS = '{1}') as a full join (select * from zlzls2old where ZLBH = '{0}' and PLUS = ({1} - 1)) as b on a.ZLBH = b.ZLBH and a.BWBH = b.BWBH and a.SIZE = b.SIZE and a.ZMLB = b.ZMLB) ", tbDDBH.Text, tbVER2.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlC, dbConnC.connection);
                        Console.WriteLine(sqlC);
                        adapter.Fill(dsC, "棧板表");
                        dgvChange.DataSource = dsC.Tables[0];

                        for (int i = 0; i < dgvChange.Rows.Count; i++)
                        {
                            if (dgvChange.Rows[i].Cells[2].Value.ToString() != dgvChange.Rows[i].Cells[3].Value.ToString())
                            {
                                dgvChange.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.LightGray;
                                dgvChange.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                            }

                            if (dgvChange.Rows[i].Cells[4].Value.ToString() != dgvChange.Rows[i].Cells[5].Value.ToString())
                            {
                                dgvChange.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Aqua;
                                dgvChange.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Aqua;
                            }
                        }

                        for (int i = 0; i < dgvChange.Rows.Count; i++)
                        {
                            if (dgvChange.Rows[i].Cells[8].Value.ToString() == "Y")
                            {

                                for (int j = 0; j < dgvChange.Rows.Count; j++)
                                {
                                    if (dgvChange.Rows[i].Cells[0].Value.ToString() == dgvChange.Rows[j].Cells[0].Value.ToString())
                                    {
                                        if (dgvChange.Rows[j].Cells[8].Value.ToString() == "N")
                                        {
                                            dgvChange.Rows[j].Visible = false;

                                            if (dgvChange.Rows[j].Cells[2].Value.ToString() == dgvChange.Rows[j].Cells[3].Value.ToString()) 
                                            {
                                                dgvChange.Rows[j].Visible = true;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    if (tbDDBH.Text != "")
                    {
                        DataSet ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select * from xxzlss where XieXing in (select XieXing from ddzl where DDBH = '{0}') and shehao in (select shehao from ddzl where DDBH = '{0}')", tbDDBH.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView3.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception) { }
        }

        private void OrderVer_Load(object sender, EventArgs e)
        {

        }
    }
}
