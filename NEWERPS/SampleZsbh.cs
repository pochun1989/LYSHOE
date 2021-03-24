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
    public partial class SampleZsbh : Form
    {
        public SampleZsbh()
        {
            InitializeComponent();
        }


        DataSet ds = new DataSet();
        public string zsdh,clbh,changezsdh;
        //public int t = 0;
        private void CSBH() 
        {
            try
            {

                    ds = new DataSet();
                    DBconnect dbconn = new DBconnect();
                    string sql1 = string.Format("select * from supplier_list where cldh = '{0}'", clbh);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                    adapter1.Fill(ds, "倉庫位置");
                    this.comboBox1.DataSource = ds.Tables[0];
                    this.comboBox1.ValueMember = "zsdh";
                    this.comboBox1.DisplayMember = "zsdh";
                    Console.WriteLine(sql1);

                    comboBox1.MaxDropDownItems = 8;
                    comboBox1.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        private void B0001_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") 
            {
                zsdh = comboBox1.Text;
                changezsdh = "1";
            }

            this.Close();
        }

        private void SampleZsbh_Load(object sender, EventArgs e)
        {
            CSBH();
        }
    }
}
