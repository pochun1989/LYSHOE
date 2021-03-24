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
    public partial class TempQuery : Form
    {
        public TempQuery()
        {
            InitializeComponent();
        }

        #region 變數

        public DataSet ds = new DataSet();
        public DataSet ds2 = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "";

        #endregion

        #region 方法

        #region Class載入

        private void ClassB()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from CLASS_B";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cbClass.DataSource = ds.Tables[0];
                this.cbClass.ValueMember = "ywsm";
                this.cbClass.DisplayMember = "cllb";

                cbClass.MaxDropDownItems = 8;
                cbClass.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void TempQuery_Load(object sender, EventArgs e)
        {
            ClassB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDDBH.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where tempddbh like '{0}%' and cllb = '{1}'", tbDDBH.Text, cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds2, "棧板表");
                    this.Close();
                }
                else if (tbMC.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where zwpm  =  '{0}' and cllb = '{1}'", tbMC.Text, cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds2, "棧板表");
                    this.Close();
                }
                else if (tbME.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where ywpm  =  '{0}' and cllb = '{1}'", tbME.Text, cbClass.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds2, "棧板表");
                    this.Close();
                }
                else
                {
                    ds2 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from clzltemp where cllb = '{0}'", cbClass.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds2, "棧板表");

                    //dataGridView1.DataSource = ds2.Tables[0];
                    this.Close();
                }
            }
            catch (Exception) { }
        }
    }
}
