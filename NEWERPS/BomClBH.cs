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
    public partial class BomClBH : Form
    {
        public BomClBH()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public string cldh = "", ywsm = "", zwsm = "",csbh = "";

        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BomCSBH BOM = new BomCSBH();
                BOM.cldh = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                BOM.ShowDialog();
                csbh = BOM.csbh;

                cldh = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                zwsm = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                ywsm = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //csbh = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                this.Close();
            }
            catch (Exception) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Enabled == true)
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cllb = '{0}' order by cldh", comboBox1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb1.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", tb1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb2.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where zwpm like '%{0}%' order by cldh", tb2.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb3.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where ywpm like '%{0}%' order by cldh", tb3.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }

                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception)
            {
            }
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void BomClBH_Load(object sender, EventArgs e)
        {
            try
            {
                CLBH();
            }
            catch (Exception) { }
        }

        #region 部位載入

        private void CLBH()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select distinct cllb from clzl order by cllb";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "cllb";
                this.comboBox1.DisplayMember = "cllb";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;


            }
            catch (Exception) { }
        }

        #endregion

    }
}
