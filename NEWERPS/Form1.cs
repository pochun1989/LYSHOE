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
    public partial class ERPLogin : Form
    {
        public ERPLogin()
        {
            InitializeComponent();
        }

        #region 變數

        User user = new User();

        #endregion






        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput()) // 非空驗證
                {
                    if (DBLogin()) // 登入方法(驗證資料庫帳密)
                    {
                        Mainpage sp = new Mainpage();
                        sp.Show();
                        sp.WindowState = FormWindowState.Maximized;


                        Program.User.userID = tbAcc.Text;

                        this.Hide();

                    }
                }
            }
            catch (Exception) 
            {
            }
        }

        private bool CheckInput()
        {
            if (tbAcc.Text.Trim() == "" || tbPwd.Text.Trim() == "")
            {
                MessageBox.Show("請輸入帳號與密碼!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            return true;
        }

        private bool DBLogin()
        {
            bool flag = false;
            string acc = tbAcc.Text.Trim();
            string pwd = tbPwd.Text.Trim();
            DBconnect dBconnect = new DBconnect();
            try
            {
                // SQL語句(登入)
                string sql = string.Format("select UserID,PWD from USERlist where UserID='{0}' and PWD='{1}'", acc, pwd);
                // command命令
                SqlCommand cmd = new SqlCommand(sql, dBconnect.connection);
                // 開資料庫連接
                dBconnect.OpenConnection();
                // 執行
                SqlDataReader reader = cmd.ExecuteReader();
                // 判斷
                if (reader.Read()) // 下一筆資料(列)
                {

                    // 以列開始算(索引以欄)
                    user.userID = reader[0].ToString();


                    user.password = reader[1].ToString();
                    flag = true;


                }
                else
                {
                    MessageBox.Show("帳號密碼有誤!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登入異常 : " + ex.Message);
            }
            finally
            {
                // 關資料庫連接
                dBconnect.CloseConnection();
            }
            return flag;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ERPLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void tbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (CheckInput()) // 非空驗證
                    {
                        if (DBLogin()) // 登入方法(驗證資料庫帳密)
                        {
                            Mainpage sp = new Mainpage();
                            sp.Show();
                            sp.WindowState = FormWindowState.Maximized;


                            Program.User.userID = tbAcc.Text;

                            this.Hide();

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
