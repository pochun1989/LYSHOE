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
    public partial class OrderDiff : Form
    {
        public OrderDiff()
        {
            InitializeComponent();
        }

        private void OrderDiff_Load(object sender, EventArgs e)
        {

        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsL3 = new DataSet();
                DBconnect dbConnL = new DBconnect();
                string sqlL = string.Format("select * from zlzls2old as zo left join zlzls2 as zn on zo.zlbh=zn.zlbh and zo.bwbh=zn.bwbh and zo.clbh=zn.clbh and zo.clsl=zn.clsl and zo.csbh=zn.CSBH where zo.zlbh = '{0}'  and (zn.bwbh is null or zn.clbh is null or zn.clsl is null or zn.CSBH is null )", textBox1.Text);
                Console.WriteLine(sqlL);
                SqlDataAdapter adapterL = new SqlDataAdapter(sqlL, dbConnL.connection);
                adapterL.Fill(dsL3, "棧板表");
                dataGridView1.DataSource = dsL3.Tables[0];
            }
            catch (Exception) { }
        }
    }
}
