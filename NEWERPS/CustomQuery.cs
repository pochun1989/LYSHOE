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
    public partial class CustomQuery : Form
    {
        public CustomQuery()
        {
            InitializeComponent();
        }

        #region 變數

        public DataSet ds = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CustomQuery";

        #endregion

        #region 方法

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            try
            {
                //dt.Rows[0]["Pallet_NO"].ToString().Trim();
                int i;
                i = int.Parse(userLanguage) + 1;

                dsL = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsL, "棧板表");
                this.dgvWord.DataSource = this.dsL.Tables[0];

                WordPosition();
            }
            catch (Exception) { }
        }

        #endregion


        #region 文字定位

        private void WordPosition()
        {
            try
            {
                L0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                L0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                L0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();    
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void QueryData()
        {
            try
            {
                if (tb代號.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfzl where kfdh = '{0}' and YN = 0", tb代號.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");

                }
                else if (tb全稱.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfzl where kfqm like '%{0}%' and YN = 0", tb全稱.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");

                }
                else if (tb簡稱.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfzl where kfjc = '{0}' and YN = 0", tb簡稱.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");

                }
                else if (tb編號.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfzl where dybh = '{0}' and YN = 0", tb編號.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");

                }
                else
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfzl where YN = 1");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");

                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 事件

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            QueryData();
            this.Close();
        }

        private void CustomQuery_Load(object sender, EventArgs e)
        {
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            ChangeLabel();
        }
    }
}
