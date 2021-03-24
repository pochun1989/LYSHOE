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
    public partial class FactoryRecover : Form
    {
        public FactoryRecover()
        {
            InitializeComponent();
        }

        #region 變數
        DataSet ds = new DataSet();
        public string userid = "";

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "1_2_1";

        #endregion

        private void FactoryRecover_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                LoadData();

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //更改語言

                ChangeDataView();

            }
            catch (Exception)
            { }
        }

        #region 方法

        #region 載入資料
        private void LoadData()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();

                string sql = string.Format("select * from cqzl where YN = 1");


                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.SelectCommand.CommandTimeout = 900;
                adapter.Fill(ds, "訂單表");
                this.dataGridView1.DataSource = this.ds.Tables[0];
            }
            catch (Exception) { }
        }
        #endregion

        #region 還原資料

        private void RecoverData()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update cqzl set YN = 0, USERID = '{0}',USERDATE = GETDATE() where cqdh = '{1}'", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }
            catch (Exception) { }
        }

        #endregion



        #region 多語言



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

            LoadDgv();
        }

        #endregion


        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                dataGridView1.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView1.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView1.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dataGridView1.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView1.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView1.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView1.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView1.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView1.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView1.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView1.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                dataGridView1.Columns[11].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion




        #endregion

        #endregion



        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            RecoverData();
        }
    }
}
