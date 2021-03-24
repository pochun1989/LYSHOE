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
    public partial class CFXTZLCLBH : Form
    {
        public CFXTZLCLBH()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public string cldh = "", ywsm = "", zwsm = "";
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLCLBH";

        private void CFXTZLCLBH_Load(object sender, EventArgs e)
        {
            try
            {
                CLBH();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
                //ChangeTabControl();
            }
            catch (Exception) { }

        }

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

        #region 切換 dgv

        private void ChangeDataView()
        {
            try
            {
                int i;
                i = int.Parse(userLanguage) + 1;

                dsL = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsL, "棧板表");
                this.dgvWord.DataSource = this.dsL.Tables[0];

                LoadDgv();
            }
            catch (Exception) { }
        }

        #endregion

        #region 切換tabcontrol

        private void ChangeTabControl()
        {
            try
            {
                int i;
                i = int.Parse(userLanguage) + 1;

                dsL = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'P%'", userForm, i);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsL, "棧板表");
                this.dgvWord.DataSource = this.dsL.Tables[0];

                LoadPage();
            }
            catch (Exception) { }
        }

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                int r = dgvWord.Rows.Count;

                for (int i = 0; i < r; i++)
                {
                    dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
                }

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
                L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();                

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            cldh = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            zwsm = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            ywsm = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Console.WriteLine(cldh);
            Console.WriteLine(zwsm);
            Console.WriteLine(ywsm);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Enabled == true)
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cllb = '{0}' order by cldh", comboBox1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb1.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", tb1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb2.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where zwpm like '%{0}%' order by cldh", tb2.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb3.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where ywpm like '%{0}%' order by cldh", tb3.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }

                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception) 
            {
            }
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }
    }
}
