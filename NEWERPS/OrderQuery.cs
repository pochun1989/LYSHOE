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
    public partial class OrderQuery : Form
    {
        public OrderQuery()
        {
            InitializeComponent();
        }

        public DataSet ds = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "OrderQuery";

        private void OrderQuery_Load(object sender, EventArgs e)
        {
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();

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
                L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();


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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (L0007.Checked == false)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select DDBH,DDZT,ddzl.XieXing,XieMing,ddzl.SheHao,Version,ddzl.ARTICLE,ddzl.CCGB,KHBH,BB,KHPO,Trader, TraderPO, DDLB, CPLB, BZFS, DESTINATION.ywsm, COUNTRY.ywsm, DDRQ, MDDBH, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, ddzl.USERID, DDZL.USERDATE, DDCZ, DDPACKSM, LABELCHARGE, ddzl.Gender, SC01, SC02, PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, ddzl.YN, Pairs2, balance2, KFJD, Dest, DESTINATION.ywsm, UsageVer, DDGB, COUNTRY.ywsm, FinishedDay from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing and DDZL.SheHao = xxzl.SheHao left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID left join COUNTRY on DDZL.DDGB = COUNTRY.COUNTRY_ID where DDBH like '%{0}%'  and isnull(DDZL.XieXing,'') like '%{1}%' and isnull(DDZL.SheHao,'') like '%{2}%' and isnull(DDZL.ARTICLE,'') like '%{3}%' and isnull(KHPO,'') like '%{4}%' and isnull(KHBH,'') like '%{5}%' and isnull(Dest,'') like '%{6}%'and isnull(XieMing,'') like '%{7}%' and isnull(ddzl.CCGB,'') like '%{8}%' and isnull(DDGB,'') like '%{9}%'", tb訂單編號.Text, tb鞋型1.Text, tb色號.Text, tbArt.Text, tbKHPO.Text, tbKCBH.Text, tb目的地.Text , tb鞋名.Text, tb港口.Text, tb出口國.Text);
                    //tb鞋名.Text 移除
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    Console.WriteLine(sql);
                    adapter.Fill(ds, "棧板表");
                    this.Close();
                }                
                else 
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select DDBH,DDZT,ddzl.XieXing,XieMing,ddzl.SheHao,Version,ddzl.ARTICLE,ddzl.CCGB,KHBH,BB,KHPO,Trader, TraderPO, DDLB, CPLB, BZFS, DESTINATION.ywsm, COUNTRY.ywsm, DDRQ, MDDBH, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, ddzl.USERID, DDZL.USERDATE, DDCZ, DDPACKSM, LABELCHARGE, ddzl.Gender, SC01, SC02, PUMAPO, Pairs1, balance, mtgr, mtyf, BUYNO, ddzl.YN, Pairs2, balance2, KFJD, Dest, DESTINATION.ywsm, UsageVer, DDGB, COUNTRY.ywsm, FinishedDay from DDZL left join xxzl on DDZL.XieXing = xxzl.XieXing and DDZL.SheHao = xxzl.SheHao left join DESTINATION on DDZL.Dest = DESTINATION.DESTINATION_ID left join COUNTRY on DDZL.DDGB = COUNTRY.ywsm where DDBH like '%{0}%'  and isnull(DDZL.XieXing,'') like '%{1}%' and isnull(DDZL.SheHao,'') like '%{2}%' and isnull(DDZL.ARTICLE,'') like '%{3}%' and isnull(KHPO,'') like '%{4}%' and isnull(KHBH,'') like '%{5}%' and isnull(Dest,'') like '%{6}%'and isnull(XieMing,'') like '%{7}%' and isnull(ddzl.CCGB,'') like '%{8}%' and isnull(DDGB,'') like '%{9}%' and ShipDate between DATEADD(DAY,0,'{10}') and DATEADD(DAY,1,'{11}')", tb訂單編號.Text, tb鞋型1.Text, tb色號.Text, tbArt.Text, tbKHPO.Text, tbKCBH.Text, tb目的地.Text, tb鞋名.Text, tb港口.Text, tb出口國.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    this.Close();
                }
            }
            catch (Exception) { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (L0007.Checked == true) 
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else if (L0007.Checked == false)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }
    }
}
