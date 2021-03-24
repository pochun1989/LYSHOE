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
    public partial class SpeCLBH : Form
    {
        public SpeCLBH()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public string cldh = "", sup = "";
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "SpeCLBH";

        private void L0005_Click(object sender, EventArgs e)
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from clzl where cllb = '{0}' and  cldh like '%{1}%' order by cldh", comboBox1.Text, tb1.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView1.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();

                //if (comboBox1.Enabled == true)
                //{

                //}
                //else if (tb1.Text != "")
                //{
                //    ds1 = new DataSet();
                //    DBconnect dbConn11 = new DBconnect();
                //    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", tb1.Text);
                //    Console.WriteLine(sql1);
                //    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                //    adapter.Fill(ds1, "棧板表");

                //    dataGridView1.DataSource = ds1.Tables[0];
                //    dbConn11.CloseConnection(); 
                //}

                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception) { }
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select * from supplier_list where cldh = '{0}' ", dataGridView1.CurrentRow.Cells[1].Value.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox2.DataSource = ds.Tables[0];
                this.comboBox2.ValueMember = "zsdh";
                this.comboBox2.DisplayMember = "zsdh";

                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                cldh = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                sup = comboBox2.Text;
                this.Close();
            }
            catch (Exception) { }
        }

        private void SpeCLBH_Load(object sender, EventArgs e)
        {
            try
            {
                CLBH();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //ChangeLabel();
                //ChangeDataView();
                //ChangeTabControl();
            }
            catch (Exception) { }
        }

        #region 部位載入

        private void CLBH()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select distinct cllb from clzl order by cllb";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "cllb";
                this.comboBox1.DisplayMember = "cllb";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion
    }
}
