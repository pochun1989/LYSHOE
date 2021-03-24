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
    /// <summary>
    /// MoldSetSizeDetail 工制具尺寸明細
    /// </summary>
    public partial class MSSD : Form
    {
        #region 變數

        public int selectID; // 外部決定(0 新增 1 修改)
        public string 工具模號, 工具類別; // 外部附值
        public string 尺寸;
        DataSet ds = new DataSet(); // 儲存容器
        public string USERID;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "2_8_3";

        #endregion

        #region 構造函式

        public MSSD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MoldSetSizeDetail_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            if (selectID == 0) // 新增
            {
                tbSize.Text = "";
                tbQTY.Text = "";
                tbNonAmortization.Text = "";
                tbRemark.Text = "";
            }
            else // 修改
            {
                GetSizeDetailInformation();
            }

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        }

        #endregion

        #region 儲存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (selectID == 0) // 新增
                {
                    ds = new DataSet();
                    DBconnect dbconn = new DBconnect();
                    string sqlchk = string.Format("select * from gjzls where gjmh='{0}' and gjlb='{1}' and mjcc='{2}'"
                        , 工具模號, 工具類別, 尺寸);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlchk, dbconn.connection);
                    adapter.Fill(ds, "尺寸明細表");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Size! Please Input Another Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InsertSizeDetail();
                    }
                }
                else // 修改
                {
                    ModifySizeDetail();
                }
            }
        }

        #endregion

        #endregion

        #region 方法

        #region 多語言

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

        #region 切換 dgv

        private void ChangeDataView()
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

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                int r = dgvWord.Rows.Count;

                for (int i = 0; i < r; i++)
                {
                    dgvWord.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbSize.Text.Trim().Length == 0)
            {
                MessageBox.Show("Size Null!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region 載入資料(修改呼叫)

        private void GetSizeDetailInformation()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("select mjcc,mjss,mjss1,bz from gjzls " +
                    "where gjmh='{0}' and gjlb='{1}' and mjcc='{2}'", 工具模號, 工具類別, 尺寸);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.tbSize.Text = reader["mjcc"].ToString();
                    this.tbQTY.Text = reader["mjss"].ToString();
                    this.tbNonAmortization.Text = reader["mjss1"].ToString();
                    this.tbRemark.Text = reader["bz"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Search Size Data Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 新增尺寸明細方法

        private void InsertSizeDetail()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into gjzls(gjmh,gjlb,mjcc,mjss,mjss1,bz,USERID,USERDATE) " +
                    "values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}')"
                    , this.工具模號, this.工具類別, tbSize.Text, tbQTY.Text == "" ? "1" : tbQTY.Text
                    , tbNonAmortization.Text == "" ? "null" : "'" + tbNonAmortization.Text + "'"
                    , tbRemark.Text, USERID, DateTime.Today.ToString("yyyy-MM-dd"));
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Insert Success!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 編輯尺寸明細方法

        private void ModifySizeDetail()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update gjzls " +
                    "set mjcc='{0}',mjss='{1}',mjss1={2},bz='{3}',USERID='{4}',USERDATE='{5}' " +
                    "where gjmh='{6}' and gjlb='{7}' and mjcc='{8}'"
                    , tbSize.Text, tbQTY.Text == "" ? "1" : tbQTY.Text, tbNonAmortization.Text == "" ? "null" : "'" + tbNonAmortization.Text + "'", tbRemark.Text
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd")
                    , this.工具模號, this.工具類別, this.尺寸);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Modify Success!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion


    }
}
