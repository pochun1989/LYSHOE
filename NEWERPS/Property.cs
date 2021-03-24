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
    public partial class Property : Form
    {
        #region 建構函式

        public Property()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        DataSet ds = new DataSet();
        public string userid = "";
        string insmod = "";
        string max;
        Boolean checkname = false;

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "PropertyI";

        #endregion

        #region 畫面載入

        private void Property_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            DgvData();

            //更改語言
            ChangeLabel();
            ChangeDataView();
        }


        #endregion

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

            LoadDgv();
        }

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                dgvPro.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dgvPro.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dgvPro.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                //dgvPro.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                //dgvPro.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                //dgvPro.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                //dgvPro.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                //dgvPro.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                //dgvPro.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                //dgvPro.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
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

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 載入DGV

        private void DgvData()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select Feature_ID,txzwsm,txywsm from feature");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                this.dgvPro.DataSource = this.ds.Tables[0];
            }
            catch (Exception)
            { }

        }

        #endregion

        #region 檢查中英文

        private void CheckInsert()
        {

            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from feature where txywsm = '{0}' or txzwsm = '{1}'", tbProC.Text, tbProE.Text);
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //max = reader["count"].ToString();
                checkname = true;
            }

        }

        #endregion

        #region 取出最大序號

        private void MaxNum()
        {
            Console.WriteLine("MAX");
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select COUNT(Feature_ID)+1 as count from feature");
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                max = reader["count"].ToString();
                Console.WriteLine(max);
            }
            //max = reader["count"].ToString();
            if (max.Length == 1)
            {
                max = "000" + max;
            }
            else if (max.Length == 2)
            {
                max = "00" + max;
            }
            else if (max.Length == 3)
            {
                max = "0" + max;
            }
            lblPro.Text = max ;

        }

        #endregion

        #region 修改

        private void ModifyData()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update feature set txywsm = '{0}' , txzwsm = '{1}',USERID = '{2}',USERDATE = GETDATE() where Feature_ID = '{3}'", tbProC.Text, tbProE.Text,userid, lblPro.Text);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
        }

        #endregion

        #region 新增特性

        private void IncertData()
        {
            int result;
            DBconnect conn = new DBconnect();
            string sql1 = string.Format("insert into feature values('{0}','{1}','{2}','{3}',GETDATE())", lblPro.Text, tbProC.Text, tbProE.Text, userid);
            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
            conn.OpenConnection();
            result = cmd1.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("新增資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 還原按鈕

        private void RecoverBtn()
        {
            tsbClear.Enabled = false;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbInsert.Enabled = true;
            tsbClear.Enabled = false;

            tbProC.Enabled = false;
            tbProE.Enabled = false;
        }

        #endregion

        #endregion

        #region 事件
        private void TsbClear_Click(object sender, EventArgs e)
        {
            tbProC.Text = "";
            tbProE.Text = "";

        }

        private void TsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                MaxNum();
                tbProC.Enabled = true;
                tbProE.Enabled = true;
                tbProC.Text = "";
                tbProE.Text = "";
                insmod = "1";

                tsbClear.Enabled = true;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbInsert.Enabled = false;
                tsbClear.Enabled = true;

            }
            catch (Exception) { }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    
                }
            }
            catch (Exception)
            {
            }
        }

        private void TsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "1";
                tbProC.Enabled = true;
                tbProE.Enabled = true;

                insmod = "2";

                tsbClear.Enabled = true;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbInsert.Enabled = false;


            }
            catch (Exception) { }
        }

        private void TsbSave_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "0";
            if (insmod == "1") //新增
            {
                CheckInsert();
                if (checkname == false)
                {
                    IncertData();
                    DgvData();
                    RecoverBtn();
                }
                else
                {
                    MessageBox.Show("名稱重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbProC.Text = "";
                    tbProE.Text = "";
                    checkname = false;
                }

            }
            else if (insmod == "2") //修改
            {
                CheckInsert();
                if (checkname == false)
                {
                    ModifyData();
                    DgvData();
                    RecoverBtn();
                }
                else
                {
                    MessageBox.Show("名稱重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbProC.Text = "";
                    tbProE.Text = "";
                    checkname = false;
                }
            }
        }

        private void TsbCancel_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "0";
            DgvData();
            RecoverBtn();
        }

        #endregion

        private void DgvPro_SelectionChanged(object sender, EventArgs e)
        {
            lblPro.Text = dgvPro.CurrentRow.Cells[0].Value.ToString();
            tbProC.Text = dgvPro.CurrentRow.Cells[1].Value.ToString();
            tbProE.Text = dgvPro.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
