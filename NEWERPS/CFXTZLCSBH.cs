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
    public partial class CFXTZLCSBH : Form
    {
        public CFXTZLCSBH()
        {
            InitializeComponent();
        }

        DataSet ds1 = new DataSet();
        public string scbh = "", zsjc = "";

        private void CFXTZLCSBH_Load(object sender, EventArgs e)
        {
            ds1 = new DataSet();
            DBconnect dbConn11 = new DBconnect();
            string sql1 = string.Format("select zszl.zsdh,zszl.zsjc,zszl.zsywjc from supplier_list left join zszl on supplier_list.zsdh = zszl.zsdh where cldh = '{0}'", tbCLBH.Text);
            Console.WriteLine(sql1);
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
            adapter.Fill(ds1, "棧板表");

            dataGridView1.DataSource = ds1.Tables[0];
            dbConn11.CloseConnection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                scbh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                zsjc = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            catch (Exception) { }
        }
    }
}
