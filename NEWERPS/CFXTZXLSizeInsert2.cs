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
    public partial class CFXTZXLSizeInsert2 : Form
    {
        public CFXTZXLSizeInsert2()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "";
        DataSet ds1 = new DataSet();
        public string xie = "", she = "", gjlb = "", line = "";
        int a = 0;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZXLSizeInsert2";

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //插入XXGJS
                #region NEWERP

                int results;
                DBconnect conns = new DBconnect();
                string sql1s = string.Format("insert into xxgjs (XieXing,SheHao,GJLB,LineNum,XXCC,GJCC,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE())", xie, she, gjlb, label1.Text, textBox1.Text, textBox2.Text, userid);
                Console.WriteLine(sql1s);

                SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                conns.OpenConnection();
                results = cmd1s.ExecuteNonQuery();
                if (results == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conns.CloseConnection();

                #endregion

                #region LYSHOE

                int resultsY;
                DBconnect2 connsY = new DBconnect2();
                string sql1sY = string.Format("delete ly_shoe.dbo.xxgjs where xiexing='{0}' insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz", xie);
                Console.WriteLine(sql1sY);

                SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                connsY.OpenConnection();
                resultsY = cmd1sY.ExecuteNonQuery();
                if (resultsY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connsY.CloseConnection();

                #endregion

                this.Close();
            }
            catch (Exception) { }
        }

        private void CFXTZXLSizeInsert2_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                a = int.Parse(line);

                a += 1;

                line = a.ToString();
                if (line.Length == 1)
                {
                    line = "0" + line;
                }
                label1.Text = line;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();

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
                   //dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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
    }
}
