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
    public partial class CFXTZLBWBH : Form
    {
        public CFXTZLBWBH()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public string bwbh = "", ywsm = "";
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLBWBH";

        private void CFXTZLBWBH_Load(object sender, EventArgs e)
        {
            BWLB();
            LoadData();

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();
            ChangeDataView();

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
                    dataGridView2.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Enabled == true)
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from bwzl where bwdh = '{0}' order by bwdh", comboBox1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView2.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb1.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from bwzl where bwdh like '%{0}%' order by bwdh", tb1.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView2.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb2.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from bwzl where zwsm like '%{0}%' order by bwdh", tb2.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView2.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tb3.Text != "")
                {
                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from bwzl where ywsm like '%{0}%' order by bwdh", tb3.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView2.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception) { }
        }

        #region 部位載入

        private void BWLB()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from bwzl order by bwdh";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "bwdh";
                this.comboBox1.DisplayMember = "bwdh";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion

        #region DATA
        private void LoadData()
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from bwzl order by bwdh");
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView2.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();

            }
            catch (Exception) { }
        }

        #endregion

        #region DATA2
        private void LoadData2()
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from bwzl where bwdh = '{0}' order by bwdh", dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString(), dataGridView2.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView2.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();

            }
            catch (Exception) { }
        }

        #endregion

        private void textBox2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bwbh = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            ywsm = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }
    }
}
