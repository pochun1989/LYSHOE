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
    public partial class FactoryQuery : Form
    {
        public FactoryQuery()
        {
            InitializeComponent();
        }
        #region 變數

        public string 代號, 區域, 公司名, company, 電話, 傳真, 廠址, Address;

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "1_2_1";



        public int index = 0;
        public DataSet ds = new DataSet();
        public string userid = "";

        #endregion

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                try
                {
                    if (tb代號.Text != "")
                    {
                        string sql = string.Format("select * from cqzl where cqdh like '%{0}%' and YN = '0'", tb代號.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        this.Close();
                        //this.dataGridView1.DataSource = this.ds.Tables[0];
                    }
                    else if (tb公司名.Text != "")
                    {
                        string sql = string.Format("select * from cqzl where gszwqm like '%{0}%' and YN = '0'", tb公司名.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        this.Close();
                        //this.dataGridView1.DataSource = this.ds.Tables[0];

                    }
                    else if (tbCompany.Text != "")
                    {
                        string sql = string.Format("select * from cqzl where gsywqm like '%{0}%' and YN = '0'", tbCompany.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        this.Close();
                        //this.dataGridView1.DataSource = this.ds.Tables[0];
                    }
                    else
                    {
                        string sql = string.Format("select * from cqzl");
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        this.Close();
                    }

                }
                catch (Exception)
                { }






            }
            catch (Exception)
            {
                MessageBox.Show("搜尋失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FactoryQuery_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //更改語言
                ChangeLabel();
                ChangeDataView();
                ChangeButton();
            }
            catch (Exception)
            { }
        }

        #region 方法

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            dsl = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsl, "棧板表");
            this.dgvWord.DataSource = this.dsl.Tables[0];

            WordPosition();
        }

        #endregion

        #region 切換 dgv

        private void ChangeDataView()
        {
            
            int i;
            i = int.Parse(userLanguage) + 1;

            dsl = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsl, "棧板表");
            this.dgvWord.DataSource = this.dsl.Tables[0];


        }

        #endregion

        #region 切換 btn

        private void ChangeButton()
        {

            int i;
            i = int.Parse(userLanguage) + 1;

            dsl = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsl, "棧板表");
            this.dgvWord.DataSource = this.dsl.Tables[0];

            BtnPosition();
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
            }
            catch (Exception) { }
        }

        #endregion

        #region 按鈕定位

        private void BtnPosition()
        {
            try
            {
                B0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #endregion
    }
}
