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
    public partial class OrderSeperate : Form
    {
        public OrderSeperate()
        {
            InitializeComponent();
        }

        public string userid = "31912";
        DataSet ds = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsL = new DataSet();
        DataSet dsL2 = new DataSet();

        private void combobox()
        {
            try
            {
                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select kfdh from kfzl";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                comboBox1.DataSource = dsc3.Tables[0];
                comboBox1.ValueMember = "kfdh";
                comboBox1.DisplayMember = "kfdh";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;
            }
            catch (Exception)
            {
            }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                dsL = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("Select * from DDZL where DDZT = 'Y' and DDLB = 'N' and DDBH like '%{0}%' and KHBH like '%{1}%' and ddzl.ShipDate BETWEEN DATEADD(DAY, 0, '{2}') and DATEADD(DAY, 1, '{3}')", textBox1.Text, comboBox1.SelectedValue, dateTimePicker2.Text, dateTimePicker1.Text);
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL, "棧板表");
                dataGridView1.DataSource = dsL.Tables[0];

                dsL2 = new DataSet();
                DBconnect dbConnL2 = new DBconnect();
                string sqlL2 = string.Format("select sum(quantity) from ddzls left join ddzl on ddzls.ddbh = ddzl.ddbh and ddzl.ddzt = 'Y' where ddzl.MDDBH = '{0}' and ddzls.cc = '{1}' ", textBox1.Text, 123);
                Console.WriteLine(sqlL2);
                SqlDataAdapter adapterL2 = new SqlDataAdapter(sqlL2, dbConnL2.connection);
                adapterL.Fill(dsL2, "棧板表");
                dataGridView2.DataSource = dsL2.Tables[0];
            }
            catch (Exception) { }
        }

        private void OrderSeperate_Load(object sender, EventArgs e)
        {
            combobox();
        }
    }
}
