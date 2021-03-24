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
    public partial class PaymentTermQuery : Form
    {
        public PaymentTermQuery()
        {
            InitializeComponent();
        }

        public DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            QueryData();
            this.Close();
        }

        private void QueryData()
        {
            try
            {

                if (tb代號.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from PAYEMNT_TERM where PAYEMNT_TERM_ID like '{0}%'", tb代號.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else if (tb中文.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from PAYEMNT_TERM where zwsm like '{0}%'", tb中文.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else if (tb英文.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from PAYEMNT_TERM where ywsm like '{0}%'", tb英文.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from PAYEMNT_TERM");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);

                }

            }
            catch (Exception) { }
        }

        private void PaymentTermQuery_Load(object sender, EventArgs e)
        {

        }
    }
}
