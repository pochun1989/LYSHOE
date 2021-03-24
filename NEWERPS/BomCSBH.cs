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
    public partial class BomCSBH : Form
    {
        public BomCSBH()
        {
            InitializeComponent();
        }

        DataSet ds1 = new DataSet();
        public string cldh = "",csbh = "";

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            csbh = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csbh = "";
            this.Close();
        }

        private void BomCSBH_Load(object sender, EventArgs e)
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from supplier_list where cldh = '{0}'", cldh);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView1.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();
            }
            catch (Exception) { }
        }
    }
}
