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
    public partial class CardboardQuery : Form
    {
        public CardboardQuery()
        {
            InitializeComponent();
        }

        #region 變數

        public DataSet ds = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "1_11_1";

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

        #region 查詢

        private void Query()
        {
            if (textBox1.Text != "")
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from PAPER where kfdh = '{0}' and Lastsgjmh = '{1}' and Outsolegjmh = '{2}' and Paper_Name = '{3}'", cb品牌.SelectedValue, cb楦頭.Text, cb底模.Text, textBox1.Text);
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
            }
            else if (textBox1.Text == "")
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from PAPER where kfdh = '{0}' and Lastsgjmh = '{1}' and Outsolegjmh = '{2}'", cb品牌.SelectedValue, cb楦頭.Text, cb底模.Text);
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
            }
        }

        #endregion

        #region 品牌載入

        private void Kfzl()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from kfzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cb品牌.DataSource = ds.Tables[0];
                this.cb品牌.ValueMember = "kfdh";
                this.cb品牌.DisplayMember = "kfjc";

                cb品牌.MaxDropDownItems = 8;
                cb品牌.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 楦頭載入

        private void Gjzl100()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = string.Format("select * from gjzl where gjlb = '100' and kfdh = '{0}'", cb品牌.SelectedValue.ToString());
                Console.WriteLine(sql1);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cb楦頭.DataSource = ds.Tables[0];
                this.cb楦頭.ValueMember = "gjmh";
                this.cb楦頭.DisplayMember = "gjmh";

                cb楦頭.MaxDropDownItems = 8;
                cb楦頭.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 底膜載入

        private void Gjzl101()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                //string sql1 = string.Format("select * from gjzl where gjlb = '101' and kfdh = '{0}'", cb品牌.SelectedValue.ToString());
                string sql1 = string.Format("select * from gjzl where gjlb = '101' and kfdh = '{0}' and counter1 = '{1}'", cb品牌.SelectedValue.ToString(), cb楦頭.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cb底模.DataSource = ds.Tables[0];
                this.cb底模.ValueMember = "gjmh";
                this.cb底模.DisplayMember = "gjmh";

                cb底模.MaxDropDownItems = 8;
                cb底模.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void CardboardQuery_Load(object sender, EventArgs e)
        {
            //獲取語言
            //userLanguage = Program.LanguageType.userLanguage;
            //ChangeLabel();
            Kfzl();
            Gjzl100(); 
            Gjzl101();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb底模.Visible == true)
            {
                Query();
                this.Close();
            }
        }

        private void cb品牌_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gjzl100();
            //Gjzl101();
        }

        private void cb楦頭_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gjzl101();
        }

        private void cb品牌_Click(object sender, EventArgs e)
        {
            cb楦頭.Visible = true;
        }

        private void cb楦頭_Click(object sender, EventArgs e)
        {
            cb底模.Visible = true;
        }
    }
}
