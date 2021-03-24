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
    public partial class OrderShippingCopy : Form
    {
        public OrderShippingCopy()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        public string userid = "";
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "OrderShippingCopy";

        #endregion

        #region 畫面載入

        private void OrderShippingCopy_Load(object sender, EventArgs e)
        {

            userid = Program.User.userID;

            cbLoad2();

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();
            ChangeDataView();
            //ChangeTabControl();
        }

        #endregion

        #region 方法
        private void cbLoad() 
        {
            try
            {
                comboBox1.Text = "";
                dsc1 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql = string.Format("select DDBH from ddzl where XieXing = '{0}' and DDGB = '{1}'", textBox1.Text, comboBox2.SelectedValue);
                Console.WriteLine(sql);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql, dbconn.connection);
                adapter1.Fill(dsc1, "倉庫");

                comboBox1.DataSource = dsc1.Tables[0];
                comboBox1.ValueMember = "DDBH";
                comboBox1.DisplayMember = "DDBH";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void cbLoad2()
        {
            try
            {
                dsc2 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql = string.Format("select * from COUNTRY");
                Console.WriteLine(sql);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql, dbconn.connection);
                adapter1.Fill(dsc2, "倉庫");

                comboBox2.DataSource = dsc2.Tables[0];
                comboBox2.ValueMember = "COUNTRY_ID";
                comboBox2.DisplayMember = "ywsm";
                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;
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
                L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
               
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

        #endregion

        #region 事件

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select YWDDMT.DDBH,XH,MTBH1,MTLR1,MTBH2,MTLR2,MTBH3,MTLR3,MTBH4,MTLR4,YWDDMT.USERDATE,YWDDMT.USERID,YWDDMT.YN from YWDDMT left join DDZL on YWDDMT.DDBH = DDZL.DDBH where YWDDMT.DDBH = '{0}' and DDGB = '{1}'", comboBox1.Text, comboBox2.SelectedValue);
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要覆蓋資料?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    //刪除資料
                    #region NEWERP

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete YWDDMT  where DDBH = '{0}'", textBox3.Text);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }
                    con4.CloseConnection();

                    //插入資料

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into YWDDMT  (DDBH, XH,MTBH1, MTLR1, MTBH2, MTLR2, MTBH3, MTLR3, MTBH4, MTLR4, USERDATE, USERID, YN) select '{0}', XH, MTBH1, MTLR1, MTBH2, MTLR2, MTBH3, MTLR3, MTBH4, MTLR4, GETDATE(), '{1}', YN from YWDDMT where DDBH = '{2}'", textBox3.Text, userid, comboBox1.Text);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                    #endregion
                    this.Close();
                }
            }
            catch (Exception) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbLoad();
            }
            catch (Exception) { }
        }

        #endregion
    }
}
