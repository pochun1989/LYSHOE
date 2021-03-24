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
    public partial class NewFeature : Form
    {
        #region 建構函式

        public NewFeature()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        public string property, propertyID,sep,cllb,classa = "";
        public string gridviewID = "";
        public string userid = "";
        string sort;
        public string userLanguage;


        //語言變數
        public DataSet dsL = new DataSet();

        string userForm = "1_6_4";

        #endregion

        #region 畫面載入

        private void NewFeature_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            textBox1.Text = property;

            //更改語言
            ChangeLabel();
        }

        #endregion

        #region 方法

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

        #region 取出SORTKEY

        private void MaxSort()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select isnull(max(sn)+5,5) as sn from feature_item where Feature_ID = '{0}'", propertyID);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                sort = reader2["sn"].ToString();
            }
            if (sort.Length == 1)
            {
                sort = "00" + sort; 
            }
            else if (sort.Length == 2)
            {
                sort = "0" + sort;
            }
            else if (sort.Length == 3)
            {
                
            }
            
        }

        #endregion

        #region 取出SORTKEY2

        private void MaxSort2()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select isnull(max(sn)+5,5) as sn from Separate_Item where cllb = '{0}' and Class_ID = '{1}' and Feature_ID = '{2}'",cllb,classa, propertyID);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                sort = reader2["sn"].ToString();
            }

            if (sort.Length == 1)
            {
                sort = "000" + sort;
            }
            else if (sort.Length == 2)
            {
                sort = "00" + sort;
            }
            else if (sort.Length == 3)
            {
                sort = "0" + sort;
            }

        }

        #endregion

        #region 新增方法

        private void InsertFeature()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("insert into feature_item values('{0}','{1}','{2}','{3}','{4}',GETDATE())", propertyID, sort, tbE.Text, tbC.Text, userid);

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

        #endregion

        #region 新增方法2

        private void InsertFeature2()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("insert into Separate_Item values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", cllb, classa, propertyID, sort, tbE.Text, tbC.Text, userid);

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

        #endregion

        #endregion

        #region 事件
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (gridviewID == "4")
                {
                    if (sep == "False")
                    {
                        MaxSort();                        
                        InsertFeature();
                    }
                    else if (sep == "True")
                    {
                        MaxSort2();
                        InsertFeature2();
                    }
                    this.Close();
                }


            }
            catch (Exception) 
            {
                MessageBox.Show("儲存失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

    }
}
