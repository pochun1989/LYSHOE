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
    public partial class CFXTZLSPArticle : Form
    {
        public CFXTZLSPArticle()
        {
            InitializeComponent();
        }

        DataSet dsArticle = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dsArticle = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from xxzl where XieXing like '%{0}%' and SheHao like '%{1}%' and XieMing like '%{2}%' and ARTICLE like '%{3}%'", textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(dsArticle , "棧板表");

                dataGridView1.DataSource = dsArticle.Tables[0];
                dbConn11.CloseConnection();

            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
