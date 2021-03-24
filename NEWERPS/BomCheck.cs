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
    public partial class BomCheck : Form
    {
        public BomCheck()
        {
            InitializeComponent();
        }

        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();

        private void BomCheck_Load(object sender, EventArgs e)
        {

        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (tbXiexing.Text != "" && tbShehao.Text != "")
                    {
                        DataSet ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select * from xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", tbXiexing.Text, tbShehao.Text, tbVER.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView2.DataSource = ds.Tables[0];
                    }
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    DataSet dsI = new DataSet();
                    DBconnect dbConnI = new DBconnect();
                    string sqlI = string.Format("select BWBH,CLBH,CLSL from  xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and BWBH not in (select BWBH from xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = ({2}-1))", tbXiexing.Text, tbShehao.Text, textBox1.Text);
                    Console.WriteLine(sqlI);
                    SqlDataAdapter adapterI = new SqlDataAdapter(sqlI, dbConnI.connection);
                    adapterI.Fill(dsI, "Insert");
                    dgvInsert.DataSource = dsI.Tables[0];

                    DataSet dsD = new DataSet();
                    DBconnect dbConnD = new DBconnect();
                    string sqlD = string.Format("select BWBH,CLBH,CLSL from  xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = ({2}-1) and BWBH not in (select BWBH from xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}')", tbXiexing.Text, tbShehao.Text, textBox1.Text);
                    SqlDataAdapter adapterD = new SqlDataAdapter(sqlD, dbConnD.connection);
                    adapterD.Fill(dsD, "Delete");
                    dgvDelete.DataSource = dsD.Tables[0];

                    DataSet dsC = new DataSet();
                    DBconnect dbConnC = new DBconnect();
                    string sqlC = string.Format("(select a.BWBH as now, b.BWBH as old,isnull(a.CLBH,'') as clbhnow,isnull(b.CLBH,'') clbhold, isnull(a.CLSL, '0') as clslnow, isnull(b.CLSL, '0') as clslold from (select * from xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}') as a full join (select * from xxzls where XieXing = '{0}' and SheHao = '{1}' and VER = ({2}-1)) as b on a.XieXing = b.XieXing and a.SheHao = b.SheHao and a.BWBH = b.BWBH ) ", tbXiexing.Text, tbShehao.Text, textBox1.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlC, dbConnC.connection);
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
                }
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage2)
                {
                    ds2 = new DataSet();
                    DBconnect dbconn2 = new DBconnect();
                    string sql12 = string.Format("select distinct ver from xxzls where XieXing = '{0}' and SheHao = '{1}'", tbXiexing.Text, tbShehao.Text);
                    SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                    adapter12.Fill(ds2, "倉庫");

                    comboBox1.DataSource = ds2.Tables[0];
                    comboBox1.ValueMember = "ver";
                    comboBox1.DisplayMember = "ver";
                    comboBox1.MaxDropDownItems = 8;
                    comboBox1.IntegralHeight = false;
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    ds2 = new DataSet();
                    DBconnect dbconn2 = new DBconnect();
                    string sql12 = string.Format("select distinct ver from xxzls where XieXing = '{0}' and SheHao = '{1}'", tbXiexing.Text, tbShehao.Text);
                    SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                    adapter12.Fill(ds2, "倉庫");

                    cbBom.DataSource = ds2.Tables[0];
                    cbBom.ValueMember = "ver";
                    cbBom.DisplayMember = "ver";
                    cbBom.MaxDropDownItems = 8;
                    cbBom.IntegralHeight = false;
                }
            }
            catch (Exception) { }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime time = new DateTime();
                time = DateTime.Parse(textBox3.Text);

                string a = "";
                a = time.ToString("yyyy/MM/dd");

                ds3 = new DataSet();
                DBconnect dbconn2 = new DBconnect();
                string sql12 = string.Format("select * from xxzls where  XieXing = '{0}' and SheHao = '{1}' and(USERID <> '{2}' or USERDATE > '{3}') and VER = '{4}'", tbXiexing.Text, tbShehao.Text, textBox2.Text, a, comboBox1.SelectedValue);
                Console.WriteLine(sql12);
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(ds3, "倉庫");
                dataGridView1.DataSource = ds3.Tables[0];
            }
            catch (Exception) { }
        }

        private void cbUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds5 = new DataSet();
                DBconnect dbconn2 = new DBconnect();
                string sql12 = string.Format("select * from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}' and VER = '{3}'", tbXiexing.Text, tbShehao.Text, cbBom.SelectedValue, cbUsage.SelectedValue);

                Console.WriteLine(sql12);
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(ds5, "倉庫");
                dataGridView3.DataSource = ds5.Tables[0];
            }
            catch (Exception) { }
        }

        private void cbBom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds4 = new DataSet();
                DBconnect dbconn3 = new DBconnect();
                string sql13 = string.Format("select distinct ver from Usage_R where XieXing = '{0}' and SheHao = '{1}' and xxzlver = '{2}'", tbXiexing.Text, tbShehao.Text, cbBom.SelectedValue);
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(ds4, "倉庫");

                cbUsage.DataSource = ds4.Tables[0];
                cbUsage.ValueMember = "ver";
                cbUsage.DisplayMember = "ver";
                cbUsage.MaxDropDownItems = 8;
                cbUsage.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            //BomUsageExcel Form = new BomUsageExcel();
            //Form.tbXiexing.Text = this.tbXiexing.Text;
            //Form.tbShehao.Text = this.tbShehao.Text;
            //Form.ShowDialog();
        }
    }
}
