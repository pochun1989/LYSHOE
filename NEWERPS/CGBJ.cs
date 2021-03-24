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
    public partial class CGBJ : Form
    {
        public CGBJ()
        {
            InitializeComponent();
        }

        public string zsbh = "", clbh = "";
        public string US = "", VN = "";
        DataSet ds = new DataSet();

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    US = "0";
                }
                else 
                {
                    US = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }

                if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "")
                {
                    VN = "0";
                }
                else
                {
                    VN = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                }


                this.Close();
            }
            catch (Exception) { }
        }

        private void CGBJ_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = zsbh;
                textBox2.Text = clbh;

                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select a.BJNO,a.ZSBH,b.CLBH,b.USPrice,b.VNPrice,a.CFMDate from CGBJ as a left join CGBJS as b on a.BJNO = b.BJNO where a.ZSBH = '{0}' and b.CLBH  ='{1}' and a.YN = 1 and b.YN = 1  order by CFMDate DESC", zsbh,clbh);
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
        }
    }
}
