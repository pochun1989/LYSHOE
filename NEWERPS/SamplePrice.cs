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
    public partial class SamplePrice : Form
    {
        public SamplePrice()
        {
            InitializeComponent();
        }

        public string sampleclbh,usprice = "",vnprice = "";

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            usprice = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            vnprice = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }

        DataSet ds12 = new DataSet();


        #region 方法

        #endregion

        #region 事件

        #endregion

        private void SamplePrice_Load(object sender, EventArgs e)
        {
            ds12 = new DataSet();
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select CLBH,USPrice,VNPrice, CASE BJLX  WHEN 1 THEN '開發報價' end as BJLX from CGBJS where BJLX = 1 and CLBH = '{0}'", sampleclbh);
            Console.WriteLine(sql2);
            SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
            adapter.Fill(ds12, "棧板表");

            dataGridView1.DataSource = ds12.Tables[0];
        }
    }
}
