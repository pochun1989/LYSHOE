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
    public partial class NewClassFeature : Form
    {
        public NewClassFeature()
        {
            InitializeComponent();
        }
        #region 變數


        DataSet ds = new DataSet();
        public string unitary = "";
        public string userid = "";
        public string sepID = "";
        public string classa = "";
        string sort = "";
        int num10 = 0, checkID = 0, checkID2 = 0;
        public string userLanguage;


        //語言變數
        public DataSet dsL = new DataSet();

        string userForm = "NCFeature";

        #endregion

        #region 方法

        #region 多語言

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

        #region 切換 Label

        private void ChangeLabel()
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

        #endregion

        #endregion

        #region 取出SORTKEY

        private void MaxSort()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select isnull(MAX(sortkey)+5,1) as sort from CLASS_fEATURE where Class_ID = '{0}' ", classa);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                sort = reader2["sort"].ToString();
            }
        }

        #endregion

        #region CBA方法

        private void ClassA()
        {

            #region CB載入

            comboBox1.MaxDropDownItems = 8;
            comboBox1.IntegralHeight = false;
            DBconnect dbconn = new DBconnect();
            string sql1 = "select * from feature";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(ds, "CLASSA");
            this.comboBox1.DataSource = ds.Tables[0];
            this.comboBox1.ValueMember = "Feature_ID";
            this.comboBox1.DisplayMember = "txywsm";



            #endregion
        }

        #endregion

        #region 新增方法

        private void InsertFeature()
        {
            if (L0003.Checked == false)
            {
                if (L0002.Checked == true)
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("insert into CLASS_fEATURE values ('{0}','{1}','{2}','{3}','1','{4}',GETDATE())", textBox1.Text, classa, comboBox1.SelectedValue.ToString(), sort, userid);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con4.CloseConnection();
                }
                else if (L0002.Checked == false)
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("insert into CLASS_fEATURE values ('{0}','{1}','{2}','{3}','1','{4}',GETDATE())", "999", classa, comboBox1.SelectedValue.ToString(), sort, userid);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con4.CloseConnection();
                }
            }
            else 
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("insert into CLASS_fEATURE values ('{0}','{1}','{2}','{3}','0','{4}',GETDATE())", "999", classa, comboBox1.SelectedValue.ToString(), sort, userid);

                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con4.CloseConnection();
            }
        }

        #endregion

        #region 新增檢查

        private void InsertCheck()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select isnull(count(Feature_ID),0) as count from CLASS_fEATURE where Class_ID = '{0}' and Feature_ID = '{1}'", classa, comboBox1.SelectedValue.ToString());
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                checkID = int.Parse(reader2["count"].ToString());
            }
        }

        #endregion

        #region 新增檢查

        private void InsertCheck2()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select isnull(count(Feature_ID),0) as count from CLASS_fEATURE where Class_ID = '{0}' and Feature_ID = '{1}' and cllb = '999'", classa, comboBox1.SelectedValue.ToString());
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                checkID2 = int.Parse(reader2["count"].ToString());
            }
        }

        #endregion


        #region 檢查10個

        private void Check10()
        {
            string x = "";
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select isnull(count(Class_ID),0) as num from CLASS_fEATURE where Class_ID = '{0}'", classa);

            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                x = reader["num"].ToString();
            }

            num10 = int.Parse(x);
        }

        #endregion

        #endregion

        #region 事件



        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //比對數量
                Check10();
                //比對重複
                InsertCheck();
                if (num10 < 10)
                {
                    if (checkID == 0) //沒重複
                    {
                        MaxSort();
                        InsertFeature();
                        unitary = "";
                        sepID = "";
                        classa = "";
                        sort = "";
                    }
                    else
                    {
                        InsertCheck2();
                        if (checkID2 == 0) //沒有999
                        {
                            if (L0003.Checked == false && L0002.Checked == true) //不是999
                            {
                                MaxSort();
                                InsertFeature();
                                unitary = "";
                                sepID = "";
                                classa = "";
                                sort = "";
                            }
                            else 
                            {
                                MessageBox.Show("特性重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("特性重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("特性超過10個", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {

            }
        }

        private void NewClassFeature_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            ClassA();

            //更改語言
            ChangeLabel();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (L0003.Checked == true)
            {
                L0002.Checked = false;
                L0002.Visible = false;
                //textBox2.Visible = false;
                textBox1.Visible = false;
                //textBox2.Visible = true;
            }
            else if (L0003.Checked == false)
            {
                L0002.Visible = true;
                //textBox2.Visible = true;
                //textBox1.Visible = true;
                //textBox2.Visible = false;
            }
        }

        private void L0002_CheckedChanged(object sender, EventArgs e)
        {
            if (L0002.Checked == true)
            {
                textBox1.Visible = true;
            }
            else if (L0002.Checked == false)
            {
                textBox1.Visible = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
