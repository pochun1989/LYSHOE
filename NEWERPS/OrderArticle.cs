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
    public partial class OrderArticle : Form
    {
        public OrderArticle()
        {
            InitializeComponent();
        }

        public string article, xiexing, shehao;
        DataSet dsarticle = new DataSet();
        public string kfbh = "";

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                xiexing = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                shehao = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                article = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dsarticle = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from xxzl where ARTICLE like '%{0}%' and XieMing like '%{1}%' and KHDH = '{2}'", tbArticle.Text, textBox1.Text, kfbh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsarticle, "dsarticle");
                dataGridView1.DataSource = dsarticle.Tables[0];
            }
            catch (Exception) { }
        }

        private void OrderArticle_Load(object sender, EventArgs e)
        {
            label3.Text = kfbh;
        }
    }
}
