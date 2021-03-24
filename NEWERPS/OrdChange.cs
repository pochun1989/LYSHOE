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
    public partial class OrdChange : Form
    {
        public OrdChange()
        {
            InitializeComponent();
        }

        #region 變數

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "070100"; //OrderMain

        int sl2 = 0;
        int sl3 = 0;
        public string userid = "";
        string cddbh = "";
        int ver = 0;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dsload = new DataSet();
        DataSet dsY1 = new DataSet();
        DataSet dsY2 = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        DataSet dsc5 = new DataSet();
        DataSet dsc6 = new DataSet();
        DataSet dsc7 = new DataSet();
        DataSet dsc8 = new DataSet();

        DataSet dsc10 = new DataSet();
        DataSet dsm1 = new DataSet();
        DataSet dsm2 = new DataSet();

        #endregion

        #region 畫面載入

        private void OrdChange_Load(object sender, EventArgs e)
        {

            try
            {
                userid = Program.User.userID;

                DBconnect dbconn2 = new DBconnect();
                string sql12 = "select SIZE_ID from CSSize";
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsc2, "倉庫");

                cb尺寸國別.DataSource = dsc2.Tables[0];
                cb尺寸國別.ValueMember = "SIZE_ID";
                cb尺寸國別.DisplayMember = "SIZE_ID";
                cb尺寸國別.MaxDropDownItems = 8;
                cb尺寸國別.IntegralHeight = false;

                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select kfdh from kfzl";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                cb客戶.DataSource = dsc3.Tables[0];
                cb客戶.ValueMember = "kfdh";
                cb客戶.DisplayMember = "kfdh";
                cb客戶.MaxDropDownItems = 8;
                cb客戶.IntegralHeight = false;

                DBconnect dbconn4 = new DBconnect();
                string sql14 = "select * from COUNTRY";
                SqlDataAdapter adapter14 = new SqlDataAdapter(sql14, dbconn4.connection);
                adapter14.Fill(dsc4, "倉庫");

                cb國別2.DataSource = dsc4.Tables[0];
                cb國別2.ValueMember = "COUNTRY_ID";
                cb國別2.DisplayMember = "ywsm";
                cb國別2.MaxDropDownItems = 8;
                cb國別2.IntegralHeight = false;

                DBconnect dbconn5 = new DBconnect();
                string sql15 = "select * from DESTINATION";
                SqlDataAdapter adapter15 = new SqlDataAdapter(sql15, dbconn5.connection);
                adapter15.Fill(dsc5, "倉庫");

                cb出口港2.DataSource = dsc5.Tables[0];
                cb出口港2.ValueMember = "DESTINATION_ID";
                cb出口港2.DisplayMember = "ywsm";
                cb出口港2.MaxDropDownItems = 8;
                cb出口港2.IntegralHeight = false;

                DBconnect dbconn6 = new DBconnect();
                string sql16 = "select * from cqzl";
                SqlDataAdapter adapter16 = new SqlDataAdapter(sql16, dbconn6.connection);
                adapter16.Fill(dsc6, "倉庫");

                cb生產廠區.DataSource = dsc6.Tables[0];
                cb生產廠區.ValueMember = "cqdh";
                cb生產廠區.DisplayMember = "cqdh";
                cb生產廠區.MaxDropDownItems = 8;
                cb生產廠區.IntegralHeight = false;

                //cb鞋型.SelectedIndex = 0;
                cb尺寸國別.SelectedIndex = 0;
                cb客戶.SelectedIndex = 0;
                //cb國別.SelectedIndex = 0;
                //cb出口港.SelectedIndex = 0;


                DBconnect dbconn22 = new DBconnect();
                string sql122 = string.Format("select distinct XieXing from xxzl ");
                SqlDataAdapter adapter122 = new SqlDataAdapter(sql122, dbconn22.connection);
                adapter122.Fill(dsc10, "倉庫");

                cb鞋型.DataSource = dsc10.Tables[0];
                cb鞋型.ValueMember = "XieXing";
                cb鞋型.DisplayMember = "XieXing";
                cb鞋型.MaxDropDownItems = 8;
                cb鞋型.IntegralHeight = false;

                //dgvSize.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //ChangeLabel();
                //ChangeDataView();
                //ChangeTabControl();

            }
            catch (Exception) 
            {
                MessageBox.Show("Load Error");
            }
        }

        #endregion

        #region 方法

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

                D0001.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                D0001.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                D0001.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                D0001.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                D0001.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                D0001.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                D0001.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                D0001.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                D0001.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                D0001.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                D0001.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                D0001.Columns[11].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                D0001.Columns[12].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                D0001.Columns[13].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                D0001.Columns[14].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                D0001.Columns[15].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                D0001.Columns[16].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                D0001.Columns[17].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();
                D0001.Columns[18].HeaderText = dgvWord.Rows[18].Cells[3].Value.ToString();
                D0001.Columns[19].HeaderText = dgvWord.Rows[19].Cells[3].Value.ToString();
                D0001.Columns[20].HeaderText = dgvWord.Rows[20].Cells[3].Value.ToString();
                D0001.Columns[21].HeaderText = dgvWord.Rows[21].Cells[3].Value.ToString();
                D0001.Columns[22].HeaderText = dgvWord.Rows[22].Cells[3].Value.ToString();
                D0001.Columns[23].HeaderText = dgvWord.Rows[23].Cells[3].Value.ToString();
                D0001.Columns[24].HeaderText = dgvWord.Rows[24].Cells[3].Value.ToString();
                D0001.Columns[25].HeaderText = dgvWord.Rows[25].Cells[3].Value.ToString();
                D0001.Columns[26].HeaderText = dgvWord.Rows[26].Cells[3].Value.ToString();
                D0001.Columns[27].HeaderText = dgvWord.Rows[27].Cells[3].Value.ToString();
                D0001.Columns[28].HeaderText = dgvWord.Rows[28].Cells[3].Value.ToString();
                D0001.Columns[29].HeaderText = dgvWord.Rows[29].Cells[3].Value.ToString();
                D0001.Columns[30].HeaderText = dgvWord.Rows[30].Cells[3].Value.ToString();
                D0001.Columns[31].HeaderText = dgvWord.Rows[31].Cells[3].Value.ToString();
                D0001.Columns[32].HeaderText = dgvWord.Rows[32].Cells[3].Value.ToString();
                D0001.Columns[33].HeaderText = dgvWord.Rows[33].Cells[3].Value.ToString();
                D0001.Columns[34].HeaderText = dgvWord.Rows[34].Cells[3].Value.ToString();
                D0001.Columns[35].HeaderText = dgvWord.Rows[35].Cells[3].Value.ToString();
                D0001.Columns[36].HeaderText = dgvWord.Rows[36].Cells[3].Value.ToString();
                D0001.Columns[37].HeaderText = dgvWord.Rows[37].Cells[3].Value.ToString();
                D0001.Columns[38].HeaderText = dgvWord.Rows[38].Cells[3].Value.ToString();
                D0001.Columns[39].HeaderText = dgvWord.Rows[39].Cells[3].Value.ToString();
                D0001.Columns[40].HeaderText = dgvWord.Rows[40].Cells[3].Value.ToString();
                D0001.Columns[41].HeaderText = dgvWord.Rows[41].Cells[3].Value.ToString();
                D0001.Columns[42].HeaderText = dgvWord.Rows[42].Cells[3].Value.ToString();
                D0001.Columns[43].HeaderText = dgvWord.Rows[43].Cells[3].Value.ToString();
                D0001.Columns[44].HeaderText = dgvWord.Rows[44].Cells[3].Value.ToString();
                D0001.Columns[45].HeaderText = dgvWord.Rows[45].Cells[3].Value.ToString();

                D0002.Columns[0].HeaderText = dgvWord.Rows[46].Cells[3].Value.ToString();
                D0002.Columns[1].HeaderText = dgvWord.Rows[47].Cells[3].Value.ToString();
                D0002.Columns[2].HeaderText = dgvWord.Rows[48].Cells[3].Value.ToString();
                D0002.Columns[3].HeaderText = dgvWord.Rows[49].Cells[3].Value.ToString();
                D0002.Columns[4].HeaderText = dgvWord.Rows[50].Cells[3].Value.ToString();
                D0002.Columns[5].HeaderText = dgvWord.Rows[51].Cells[3].Value.ToString();
                D0002.Columns[6].HeaderText = dgvWord.Rows[52].Cells[3].Value.ToString();
                D0002.Columns[7].HeaderText = dgvWord.Rows[53].Cells[3].Value.ToString();
                D0002.Columns[8].HeaderText = dgvWord.Rows[54].Cells[3].Value.ToString();
                D0002.Columns[9].HeaderText = dgvWord.Rows[55].Cells[3].Value.ToString();
                D0002.Columns[10].HeaderText = dgvWord.Rows[56].Cells[3].Value.ToString();
                D0002.Columns[11].HeaderText = dgvWord.Rows[57].Cells[3].Value.ToString();
                D0002.Columns[12].HeaderText = dgvWord.Rows[58].Cells[3].Value.ToString();
                D0002.Columns[13].HeaderText = dgvWord.Rows[59].Cells[3].Value.ToString();

                dataGridView5.Columns[0].HeaderText = dgvWord.Rows[60].Cells[3].Value.ToString();
                dataGridView5.Columns[1].HeaderText = dgvWord.Rows[61].Cells[3].Value.ToString();
                dataGridView5.Columns[2].HeaderText = dgvWord.Rows[62].Cells[3].Value.ToString();
                dataGridView6.Columns[0].HeaderText = dgvWord.Rows[60].Cells[3].Value.ToString();
                dataGridView6.Columns[1].HeaderText = dgvWord.Rows[61].Cells[3].Value.ToString();
                dataGridView6.Columns[2].HeaderText = dgvWord.Rows[62].Cells[3].Value.ToString();

                dataGridView2.Columns[0].HeaderText = dgvWord.Rows[63].Cells[3].Value.ToString();
                dataGridView2.Columns[1].HeaderText = dgvWord.Rows[64].Cells[3].Value.ToString();
                dataGridView2.Columns[2].HeaderText = dgvWord.Rows[65].Cells[3].Value.ToString();
                dataGridView2.Columns[3].HeaderText = dgvWord.Rows[66].Cells[3].Value.ToString();
                dataGridView2.Columns[4].HeaderText = dgvWord.Rows[67].Cells[3].Value.ToString();
                dataGridView2.Columns[5].HeaderText = dgvWord.Rows[68].Cells[3].Value.ToString();
                dataGridView2.Columns[6].HeaderText = dgvWord.Rows[69].Cells[3].Value.ToString();
                dataGridView2.Columns[7].HeaderText = dgvWord.Rows[70].Cells[3].Value.ToString();
                dataGridView2.Columns[8].HeaderText = dgvWord.Rows[71].Cells[3].Value.ToString();
                dataGridView2.Columns[9].HeaderText = dgvWord.Rows[72].Cells[3].Value.ToString();
                dataGridView2.Columns[10].HeaderText = dgvWord.Rows[73].Cells[3].Value.ToString();
                dataGridView2.Columns[11].HeaderText = dgvWord.Rows[74].Cells[3].Value.ToString();
                dataGridView2.Columns[12].HeaderText = dgvWord.Rows[75].Cells[3].Value.ToString();

                dataGridView3.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView3.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView3.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dataGridView3.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView3.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView3.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView3.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView3.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView3.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView3.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView3.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                dataGridView3.Columns[11].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dataGridView3.Columns[12].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView3.Columns[13].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                dataGridView3.Columns[14].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                dataGridView3.Columns[15].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                dataGridView3.Columns[16].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                dataGridView3.Columns[17].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();
                dataGridView3.Columns[18].HeaderText = dgvWord.Rows[18].Cells[3].Value.ToString();
                dataGridView3.Columns[19].HeaderText = dgvWord.Rows[19].Cells[3].Value.ToString();
                dataGridView3.Columns[20].HeaderText = dgvWord.Rows[20].Cells[3].Value.ToString();
                dataGridView3.Columns[21].HeaderText = dgvWord.Rows[21].Cells[3].Value.ToString();
                dataGridView3.Columns[22].HeaderText = dgvWord.Rows[22].Cells[3].Value.ToString();
                dataGridView3.Columns[23].HeaderText = dgvWord.Rows[23].Cells[3].Value.ToString();
                dataGridView3.Columns[24].HeaderText = dgvWord.Rows[24].Cells[3].Value.ToString();
                dataGridView3.Columns[25].HeaderText = dgvWord.Rows[25].Cells[3].Value.ToString();
                dataGridView3.Columns[26].HeaderText = dgvWord.Rows[26].Cells[3].Value.ToString();
                dataGridView3.Columns[27].HeaderText = dgvWord.Rows[27].Cells[3].Value.ToString();
                dataGridView3.Columns[28].HeaderText = dgvWord.Rows[28].Cells[3].Value.ToString();
                dataGridView3.Columns[29].HeaderText = dgvWord.Rows[29].Cells[3].Value.ToString();
                dataGridView3.Columns[30].HeaderText = dgvWord.Rows[30].Cells[3].Value.ToString();
                dataGridView3.Columns[31].HeaderText = dgvWord.Rows[31].Cells[3].Value.ToString();
                dataGridView3.Columns[32].HeaderText = dgvWord.Rows[32].Cells[3].Value.ToString();
                dataGridView3.Columns[33].HeaderText = dgvWord.Rows[33].Cells[3].Value.ToString();
                dataGridView3.Columns[34].HeaderText = dgvWord.Rows[34].Cells[3].Value.ToString();
                dataGridView3.Columns[35].HeaderText = dgvWord.Rows[35].Cells[3].Value.ToString();
                dataGridView3.Columns[36].HeaderText = dgvWord.Rows[36].Cells[3].Value.ToString();
                dataGridView3.Columns[37].HeaderText = dgvWord.Rows[37].Cells[3].Value.ToString();
                dataGridView3.Columns[38].HeaderText = dgvWord.Rows[38].Cells[3].Value.ToString();
                dataGridView3.Columns[39].HeaderText = dgvWord.Rows[39].Cells[3].Value.ToString();
                dataGridView3.Columns[40].HeaderText = dgvWord.Rows[40].Cells[3].Value.ToString();
                dataGridView3.Columns[41].HeaderText = dgvWord.Rows[41].Cells[3].Value.ToString();
                dataGridView3.Columns[42].HeaderText = dgvWord.Rows[42].Cells[3].Value.ToString();
                dataGridView3.Columns[43].HeaderText = dgvWord.Rows[43].Cells[3].Value.ToString();
                dataGridView3.Columns[44].HeaderText = dgvWord.Rows[44].Cells[3].Value.ToString();
                dataGridView3.Columns[45].HeaderText = dgvWord.Rows[45].Cells[3].Value.ToString();

                dataGridView7.Columns[0].HeaderText = dgvWord.Rows[46].Cells[3].Value.ToString();
                dataGridView7.Columns[1].HeaderText = dgvWord.Rows[47].Cells[3].Value.ToString();
                dataGridView7.Columns[2].HeaderText = dgvWord.Rows[48].Cells[3].Value.ToString();
                dataGridView7.Columns[3].HeaderText = dgvWord.Rows[49].Cells[3].Value.ToString();
                dataGridView7.Columns[4].HeaderText = dgvWord.Rows[50].Cells[3].Value.ToString();
                dataGridView7.Columns[5].HeaderText = dgvWord.Rows[51].Cells[3].Value.ToString();
                dataGridView7.Columns[6].HeaderText = dgvWord.Rows[52].Cells[3].Value.ToString();
                dataGridView7.Columns[7].HeaderText = dgvWord.Rows[53].Cells[3].Value.ToString();
                dataGridView7.Columns[8].HeaderText = dgvWord.Rows[54].Cells[3].Value.ToString();
                dataGridView7.Columns[9].HeaderText = dgvWord.Rows[55].Cells[3].Value.ToString();
                dataGridView7.Columns[10].HeaderText = dgvWord.Rows[56].Cells[3].Value.ToString();
                dataGridView7.Columns[11].HeaderText = dgvWord.Rows[57].Cells[3].Value.ToString();
                dataGridView7.Columns[12].HeaderText = dgvWord.Rows[58].Cells[3].Value.ToString();
                dataGridView7.Columns[13].HeaderText = dgvWord.Rows[59].Cells[3].Value.ToString();

                dataGridView4.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView4.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView4.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dataGridView4.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView4.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView4.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView4.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView4.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView4.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView4.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView4.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                dataGridView4.Columns[11].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dataGridView4.Columns[12].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView4.Columns[13].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                dataGridView4.Columns[14].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                dataGridView4.Columns[15].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                dataGridView4.Columns[16].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                dataGridView4.Columns[17].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();
                dataGridView4.Columns[18].HeaderText = dgvWord.Rows[18].Cells[3].Value.ToString();
                dataGridView4.Columns[19].HeaderText = dgvWord.Rows[19].Cells[3].Value.ToString();
                dataGridView4.Columns[20].HeaderText = dgvWord.Rows[20].Cells[3].Value.ToString();
                dataGridView4.Columns[21].HeaderText = dgvWord.Rows[21].Cells[3].Value.ToString();
                dataGridView4.Columns[22].HeaderText = dgvWord.Rows[22].Cells[3].Value.ToString();
                dataGridView4.Columns[23].HeaderText = dgvWord.Rows[23].Cells[3].Value.ToString();
                dataGridView4.Columns[24].HeaderText = dgvWord.Rows[24].Cells[3].Value.ToString();
                dataGridView4.Columns[25].HeaderText = dgvWord.Rows[25].Cells[3].Value.ToString();
                dataGridView4.Columns[26].HeaderText = dgvWord.Rows[26].Cells[3].Value.ToString();
                dataGridView4.Columns[27].HeaderText = dgvWord.Rows[27].Cells[3].Value.ToString();
                dataGridView4.Columns[28].HeaderText = dgvWord.Rows[28].Cells[3].Value.ToString();
                dataGridView4.Columns[29].HeaderText = dgvWord.Rows[29].Cells[3].Value.ToString();
                dataGridView4.Columns[30].HeaderText = dgvWord.Rows[30].Cells[3].Value.ToString();
                dataGridView4.Columns[31].HeaderText = dgvWord.Rows[31].Cells[3].Value.ToString();
                dataGridView4.Columns[32].HeaderText = dgvWord.Rows[32].Cells[3].Value.ToString();
                dataGridView4.Columns[33].HeaderText = dgvWord.Rows[33].Cells[3].Value.ToString();
                dataGridView4.Columns[34].HeaderText = dgvWord.Rows[34].Cells[3].Value.ToString();
                dataGridView4.Columns[35].HeaderText = dgvWord.Rows[35].Cells[3].Value.ToString();
                dataGridView4.Columns[36].HeaderText = dgvWord.Rows[36].Cells[3].Value.ToString();
                dataGridView4.Columns[37].HeaderText = dgvWord.Rows[37].Cells[3].Value.ToString();
                dataGridView4.Columns[38].HeaderText = dgvWord.Rows[38].Cells[3].Value.ToString();
                dataGridView4.Columns[39].HeaderText = dgvWord.Rows[39].Cells[3].Value.ToString();
                dataGridView4.Columns[40].HeaderText = dgvWord.Rows[40].Cells[3].Value.ToString();
                dataGridView4.Columns[41].HeaderText = dgvWord.Rows[41].Cells[3].Value.ToString();
                dataGridView4.Columns[42].HeaderText = dgvWord.Rows[42].Cells[3].Value.ToString();
                dataGridView4.Columns[43].HeaderText = dgvWord.Rows[43].Cells[3].Value.ToString();
                dataGridView4.Columns[44].HeaderText = dgvWord.Rows[44].Cells[3].Value.ToString();
                dataGridView4.Columns[45].HeaderText = dgvWord.Rows[45].Cells[3].Value.ToString();
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
                L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                L0012.Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                L0013.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                L0014.Text = dgvWord.Rows[13].Cells[3].Value.ToString();
                L0015.Text = dgvWord.Rows[14].Cells[3].Value.ToString();
                L0016.Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                L0017.Text = dgvWord.Rows[16].Cells[3].Value.ToString();
                L0018.Text = dgvWord.Rows[17].Cells[3].Value.ToString();
                L0019.Text = dgvWord.Rows[18].Cells[3].Value.ToString();
                L0020.Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                L0021.Text = dgvWord.Rows[20].Cells[3].Value.ToString();
                L0022.Text = dgvWord.Rows[21].Cells[3].Value.ToString();
                L0023.Text = dgvWord.Rows[22].Cells[3].Value.ToString();
                L0024.Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                L0025.Text = dgvWord.Rows[24].Cells[3].Value.ToString();
                L0026.Text = dgvWord.Rows[25].Cells[3].Value.ToString();
                L0027.Text = dgvWord.Rows[26].Cells[3].Value.ToString();
                //L0028.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                //L0029.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                //L0030.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                //L0031.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                //L0032.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                L0033.Text = dgvWord.Rows[27].Cells[3].Value.ToString();
                L0034.Text = dgvWord.Rows[28].Cells[3].Value.ToString();
                L0035.Text = dgvWord.Rows[29].Cells[3].Value.ToString();
                L0036.Text = dgvWord.Rows[30].Cells[3].Value.ToString();
                L0037.Text = dgvWord.Rows[31].Cells[3].Value.ToString();
                L0038.Text = dgvWord.Rows[32].Cells[3].Value.ToString();
                //L0039.Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                L0040.Text = dgvWord.Rows[33].Cells[3].Value.ToString();
                L0041.Text = dgvWord.Rows[34].Cells[3].Value.ToString();
                L0042.Text = dgvWord.Rows[35].Cells[3].Value.ToString();
                L0043.Text = dgvWord.Rows[36].Cells[3].Value.ToString();
                L0044.Text = dgvWord.Rows[37].Cells[3].Value.ToString();
                L0045.Text = dgvWord.Rows[38].Cells[3].Value.ToString();
                L0046.Text = dgvWord.Rows[39].Cells[3].Value.ToString();
                L0047.Text = dgvWord.Rows[40].Cells[3].Value.ToString();
                L0048.Text = dgvWord.Rows[41].Cells[3].Value.ToString();
                L0049.Text = dgvWord.Rows[42].Cells[3].Value.ToString();
                L0050.Text = dgvWord.Rows[43].Cells[3].Value.ToString();
                L0051.Text = dgvWord.Rows[44].Cells[3].Value.ToString();
                L0052.Text = dgvWord.Rows[45].Cells[3].Value.ToString();
                L0053.Text = dgvWord.Rows[46].Cells[3].Value.ToString();
                L0054.Text = dgvWord.Rows[47].Cells[3].Value.ToString();
                L0055.Text = dgvWord.Rows[48].Cells[3].Value.ToString();
                L0056.Text = dgvWord.Rows[49].Cells[3].Value.ToString();
                L0057.Text = dgvWord.Rows[50].Cells[3].Value.ToString();
                L0058.Text = dgvWord.Rows[51].Cells[3].Value.ToString();
                L0059.Text = dgvWord.Rows[52].Cells[3].Value.ToString();
                L0060.Text = dgvWord.Rows[53].Cells[3].Value.ToString();
                L0061.Text = dgvWord.Rows[54].Cells[3].Value.ToString();
                L0062.Text = dgvWord.Rows[55].Cells[3].Value.ToString();
                L0063.Text = dgvWord.Rows[56].Cells[3].Value.ToString();
                L0064.Text = dgvWord.Rows[57].Cells[3].Value.ToString();
                L0065.Text = dgvWord.Rows[58].Cells[3].Value.ToString();
                L0066.Text = dgvWord.Rows[59].Cells[3].Value.ToString();
                L0067.Text = dgvWord.Rows[60].Cells[3].Value.ToString();
                L0068.Text = dgvWord.Rows[61].Cells[3].Value.ToString();
                L0069.Text = dgvWord.Rows[62].Cells[3].Value.ToString();
                L0070.Text = dgvWord.Rows[63].Cells[3].Value.ToString();
                L0071.Text = dgvWord.Rows[64].Cells[3].Value.ToString();
                L0072.Text = dgvWord.Rows[65].Cells[3].Value.ToString();
                L0073.Text = dgvWord.Rows[66].Cells[3].Value.ToString();
                L0074.Text = dgvWord.Rows[67].Cells[3].Value.ToString();
                L0075.Text = dgvWord.Rows[68].Cells[3].Value.ToString();
                L0076.Text = dgvWord.Rows[69].Cells[3].Value.ToString();
                L0077.Text = dgvWord.Rows[70].Cells[3].Value.ToString();
                L0078.Text = dgvWord.Rows[71].Cells[3].Value.ToString();
                L0079.Text = dgvWord.Rows[72].Cells[3].Value.ToString();
                L0080.Text = dgvWord.Rows[73].Cells[3].Value.ToString();
                L0081.Text = dgvWord.Rows[74].Cells[3].Value.ToString();
                //L0082.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                L0083.Text = dgvWord.Rows[75].Cells[3].Value.ToString();
                L0084.Text = dgvWord.Rows[76].Cells[3].Value.ToString();
                L0085.Text = dgvWord.Rows[77].Cells[3].Value.ToString();
                L0086.Text = dgvWord.Rows[78].Cells[3].Value.ToString();
                L0087.Text = dgvWord.Rows[79].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {
                P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                P0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                P0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                P0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                P0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                P0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region DDBH

        private void createddbh()
        {
            try
            {
                string dybh = "", year = "", day = "", max = "";
                //取出
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select dybh,datepart(yy,GETDATE()) as year,datepart(mm, GETDATE()) as month from kfzl where kfdh = '{0}'", cb客戶.Text);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dybh = reader["dybh"].ToString();
                    year = reader["year"].ToString();
                    day = reader["month"].ToString();
                }
                Console.WriteLine(dybh);

                if (dybh.Length == 2)
                {
                    year = year.Substring(2, 2);

                    Console.WriteLine(year);
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    Console.WriteLine(day);

                    cddbh = dybh + year + day;

                    Console.WriteLine(cddbh);

                    //取出最大值
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select max(substring(DDBH,9,4)) as a  from DDZL where SUBSTRING(DDBH, 1, 6) = '{0}'", cddbh);
                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        max = reader1["a"].ToString();
                    }
                    Console.WriteLine(max);

                    if (max == "") //沒有資料帶0001 
                    {
                        cddbh = cddbh + cb訂單類型.Text + "-" + "0001";
                    }
                    else
                    {
                        int z = 0;
                        z = int.Parse(max);
                        z = z + 1;
                        max = z.ToString();
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
                        cddbh = cddbh + cb訂單類型.Text + "-" + max;
                    }

                    tb訂單編號.Text = cddbh;

                    Console.WriteLine(cddbh);
                }
                else
                {
                    MessageBox.Show("Customer Code Error 客戶簡稱超過兩碼，請重新選擇");
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Create DDBH Error");
            }
        }

        #endregion

        #region 讀取DDZLS

        private void loadddzls()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from DDZLs where DDBH = '{0}'", tb訂單編號.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                D0002.DataSource = ds.Tables[0];
                D0002.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                D0002.Columns[0].Visible = false;
                D0002.Columns[1].Visible = false;
                D0002.Columns[4].Visible = false;
                D0002.Columns[5].Visible = false;
                D0002.Columns[7].Visible = false;
                D0002.Columns[8].Visible = false;
                D0002.Columns[10].Visible = false;
                D0002.Columns[11].Visible = false;
                D0002.Columns[12].Visible = false;
                D0002.Columns[13].Visible = false;
            }
            catch (Exception) 
            {
                MessageBox.Show("Load DDZLS Error");
            }
        }

        #endregion

        #region 讀取YWDDMT

        private void loadywddmt()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from YWDDMT where DDBH = '{0}'", textBox36.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView2.DataSource = ds.Tables[0];
                //dgvSize.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
            }
            catch (Exception) 
            {
                MessageBox.Show("Load YWDDMT Error");
            }
        }

        #endregion

        #region 插入DDZL

        private void insertddzl()
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into DDZL (DDBH, DDZT, XieXing, SheHao, Version, ARTICLE, CCGB, KHBH, BB, KHPO, Trader, TraderPO, DDLB, CPLB, BZFS, Dest, DDGB, DDRQ, JYTJ, FKTJ, ShipDate, Pairs, Totals, ZLBH, GSDH, CFNO, USERID, USERDATE, DDCZ, DDPACKSM, LABELCHARGE, Gender, SC01, SC02, PUMAPO, balance, mtgr, mtyf, BUYNO, YN, RYTYPE) values ('{0}', '{1}', '{2}', '{3}', '1', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{4}', '{12}', '{13}', '{14}', '{15}', '{16}', NULL, NULL, '{17}', '{18}', '{19}', NULL, 'LIN', 'ZZZZZZZZZZZZZZZZZZZZ', '{21}', GETDATE(), '{22}', NULL, '{23}', '{24}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '1', NULL)", tb訂單編號.Text, cb狀態.Text, cb鞋型.Text, cb色號.Text, cb訂單類型.Text, tbArticle.Text, cb尺寸國別.Text, cb客戶.Text, tb幣別.Text, tb客戶PO.Text, tb通路商1.Text, tb通路商PO.Text, cb產品類別.Text, cb包裝方式.Text, cb出口港.Text, cb國別.Text, tb接單日期.Text, tb離廠日期.Text, tb總雙數.Text, tb總金額.Text, tb製令編號.Text, userid, tb材質.Text, tbLabeelCharge.Text, tb性別.Text);
                Console.WriteLine(sql1);
                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {

                }
                conn.CloseConnection();
            }
            catch (Exception) 
            {

            }
        }

        #endregion

        #region 插入DDZLS

        private void insertddzls()
        {
            try
            {
                //取出資料
                double a = 0.0, b = 0.0, c = 0.0;
                int count = 0;

                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select Star_Size,End_Size,COMDIF from GENDER where GENDER_id = '{0}'", tb性別.Text);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = double.Parse(reader["Star_Size"].ToString());
                    b = double.Parse(reader["End_Size"].ToString());
                    c = double.Parse(reader["COMDIF"].ToString());
                }
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);

                dbConn.CloseConnection();



                do
                {
                    count += 1;
                    //Console.WriteLine(count);
                    Console.WriteLine(a);

                    string linenum = "";
                    linenum = count.ToString();
                    if (linenum.Length == 1)
                    {
                        linenum = "0" + linenum;
                    }
                    Console.WriteLine(linenum);

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into DDZLs (DDBH, LineNum, CC, Quantity,Price,CPrice,IPrice,USERID,USERDATE,Quantity1,mtdj,YN,Quantity2,TestQty) values ('{0}', '{1}','{2}', '0','0','0','0','{3}', GETDATE(),'0','0','1','0', '0')", tb訂單編號.Text.Trim(), linenum, a, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();


                    a = c + a;
                }
                while (a <= b);

                //MessageBox.Show("新增資料成功");
            }
            catch (Exception) { }
        }

        #endregion

        #region 插入zlzl

        private void insertzlzl()
        {
            try
            {
                #region NEWERP

                //insert zlzl
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert zlzl (ZLBH,DDBH,CQDH,KDRQ,CGBH,GJJH,YLJS,YLBB,SHQR,GSDH,USERID,USERDATE, YN,ver) values ('{0}','{1}','{2}', GETDATE(), NULL, 'Y', 'N', 'B', 'Y', 'LIN', '{3}',GETDATE(), '1', '1')", textBox38.Text, textBox39.Text, cb生產廠區.Text, userid);
                Console.WriteLine(sql1);

                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {

                }
                conn.CloseConnection();
                #endregion

                #region LYSHOE

                //insert zlzl
                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete zlzl where ZLBH = '{0}' insert zlzl(ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, USERDATE)(select ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2)  from[192.168.11.15].New_Erp.dbo.zlzl where ZLBH = '{0}')", textBox38.Text);
                Console.WriteLine(sql1Y);

                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {

                }
                connY.CloseConnection();
                #endregion

                //insert zlzls
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from ddzls where DDBH = '{0}'", textBox38.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView9.DataSource = ds.Tables[0];


                int b = 0;
                b = dataGridView9.Rows.Count;

                for (int i = 0; i < b; i++)
                {
                    #region NERERP

                    int results;
                    DBconnect conns = new DBconnect();
                    string sql1s = string.Format("insert into zlzls (ZLBH, ZLCC,XXCC,QTY,LAST,OS,MS,CUT,USERID,USERDATE,YN) values ('{0}', '{1}','{2}','{3}','0', '0', '0', '0', '{4}', GETDATE(), '1')", textBox38.Text, dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[3].Value.ToString(), userid);
                    Console.WriteLine(sql1s);

                    SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                    conns.OpenConnection();
                    results = cmd1s.ExecuteNonQuery();
                    if (results == 1)
                    {

                    }
                    conns.CloseConnection();
                    #endregion
                }

                #region LYSHOE

                int resultsY;
                DBconnect2 connsY = new DBconnect2();
                string sql1sY = string.Format("delete zlzls where ZLBH = '{0}' insert into zlzls(ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, USERDATE) (select ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from[192.168.11.15].New_Erp.dbo.zlzls where ZLBH = '{0}')", textBox38.Text);
                Console.WriteLine(sql1sY);

                SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                connsY.OpenConnection();
                resultsY = cmd1sY.ExecuteNonQuery();
                if (resultsY == 1)
                {
                }
                connsY.CloseConnection();
                #endregion

                #region NEWERP

                DBconnect con4u = new DBconnect();
                StringBuilder sql4u = new StringBuilder();
                sql4u.AppendFormat("update DDZL set GSDH = '{0}',USERID = '{1}',USERDATE = GETDATE(),ZLBH = '{2}' where DDBH = '{3}'", cb生產廠區.Text, userid, textBox38.Text, textBox38.Text);

                Console.WriteLine(sql4u);
                SqlCommand cmd4u = new SqlCommand(sql4u.ToString(), con4u.connection);
                con4u.OpenConnection();
                int result4u = cmd4u.ExecuteNonQuery();
                if (result4u == 1)
                {

                }
                con4u.CloseConnection();
                #endregion

                #region LYSHOE

                DBconnect2 con4uY = new DBconnect2();
                StringBuilder sql4uY = new StringBuilder();
                sql4uY.AppendFormat("update DDZL set GSDH = '{0}',USERID = '{1}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) ,ZLBH = '{2}' where DDBH = '{3}'", cb生產廠區.Text, userid, textBox38.Text, textBox38.Text);

                Console.WriteLine(sql4uY);
                SqlCommand cmd4uY = new SqlCommand(sql4uY.ToString(), con4uY.connection);
                con4uY.OpenConnection();
                int result4uY = cmd4uY.ExecuteNonQuery();
                if (result4uY == 1)
                {
                }
                con4uY.CloseConnection();

                #endregion

                MessageBox.Show("Insert Complete 插入資料完成", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) 
            {
                MessageBox.Show("Insert zlzl Error");
            }
        }

        #endregion

        #region TB還原
        private void tbback()
        {
            try
            {
                tb訂單編號.Enabled = false;
                cb訂單類型.Enabled = false;
                cb鞋型.Enabled = false;
                cb色號.Enabled = false;
                cb尺寸國別.Enabled = false;
                tbArticle.Enabled = false;
                tb幣別.Enabled = false;
                cb客戶.Enabled = false;
                tb材質.Enabled = false;
                tb客戶PO.Enabled = false;
                tb通路商PO.Enabled = false;
                tb通路商1.Enabled = false;
                tb離廠日期.Enabled = false;
                tbLabeelCharge.Enabled = false;
                tb版本.Enabled = false;
                cb產品類別.Enabled = false;
                cb包裝方式.Enabled = false;
                cb出口港.Enabled = false;
                tb接單日期.Enabled = false;
                //tb安全標代碼.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb總雙數.Enabled = false;
                tb總金額.Enabled = false;
                cb國別.Enabled = false;
                cb狀態.Enabled = false;
                //tbBUY別.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //tb訂單說明.Enabled = false;
                //tbRYTYPE.Enabled = false;
                //tbXX說明.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb製令編號.Enabled = false;
                tb最後異動日.Enabled = false;
                tb用戶編號.Enabled = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 特殊包材

        private void special()
        {
            try
            {
                int c2 = 0;
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(XieXing) as count from xxzlss where XieXing = '{0}' and SheHao = '{1}'", D0001.CurrentRow.Cells[2].Value.ToString().Trim
                    (), D0001.CurrentRow.Cells[4].Value.ToString().Trim
                    ());
                Console.WriteLine(sql2);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    c2 = int.Parse(reader2["count"].ToString());
                }

                dbConn2.CloseConnection();

                if (c2 == 0) //沒有資料
                {
                    MessageBox.Show("SPBOM NO DATA 特殊包材計算失敗，請先建立資料");
                }
                else
                {
                    #region NEWERP

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH  , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE , DDZL.Pairs * xxzlss.CLSL as CLSL , xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '{2}' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 1 UNION select DDZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB, 'ZZZZZZ' as SIZE , sum(DDZLs.Quantity * isnull(Usage_R.CLSL, 0)) as CLSL , xxzlss.CLSL as USAGE, '{0}' as USERID, getdate() as USERDATE, '1' as YN, '{2}' as ver from DDZLs left join DDZL on DDZL.DDBH = DDZLs.DDBH left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join xxzls on xxzls.XIEXING = DDZL.XIEXING AND xxzls.SHEHAO = DDzl.SHEHAO and xxzlss.bwbh = xxzls.BWBH left join Usage_R on ddzl.XieXing = Usage_R.XieXing and ddzl.SheHao = Usage_R.shehao and ddzls.cc = Usage_R.XTCC and xxzls.BWBH = Usage_R.BWBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'N' and xxzls.cltx = 2 and Usage_R.clsl is not null group by DDZL.ZLBH, xxzlss.BWBH, xxzlss.CSBH, xxzlss.CLBH, xxzlss.CLSL, CLZL.CLZMLB", userid, textBox38.Text, ver);
                    Console.WriteLine(sql1);

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();

                    int result2;
                    DBconnect conn2 = new DBconnect();
                    string sql12 = string.Format("insert ZLZLS2 (zlbh,xh,bwbh,csbh,mjbh,clbh,zmlb,size,clsl,usage,userid,userdate,yn,ver) select  ZLZL.ZLBH, 'SPL' as xh, xxzlss.BWBH, xxzlss.CSBH, 'ZZZZZZZZZZ' as MJBH , xxzlss.CLBH, isnull(CLZL.CLZMLB, 'N') as ZMLB , ddzls.CC as SIZE , DDZLs.Quantity * xxzlss.CLSL as CLSL, xxzlss.CLSL as USAGE, '{0}' as USERID , getdate() as USERDATE, '1' as YN, '{2}' as ver from ddzl left join xxzlss on xxzlss.XIEXING = DDZL.XIEXING AND xxzlss.SHEHAO = DDzl.SHEHAO and xxzlss.cond = ddzl.dest left join ddzls on ddzls.ddbh = ddzl.DDBH left join ZLZL on DDZL.DDBH = ZLZL.DDBH left join CLZL on CLZL.CLDH = xxzlss.CLBH where DDZL.ddbh = '{1}' and clzl.lycc = 'Y' and ddzls.Quantity <> 0 ", userid, textBox38.Text, ver);
                    Console.WriteLine(sql12);

                    SqlCommand cmd12 = new SqlCommand(sql12, conn2.connection);
                    conn2.OpenConnection();
                    result2 = cmd12.ExecuteNonQuery();
                    if (result2 == 1)
                    {

                    }
                    conn2.CloseConnection();

                    #endregion

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sql1Y = string.Format("delete zlzls2 where zlbh = '{0}' insert ZLZLS2(zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, userdate)(select zlbh, xh, bwbh, csbh, mjbh, clbh, zmlb, size, clsl, usage, userid, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}' and xh <> 'VN')", textBox38.Text);
                    Console.WriteLine(sql1Y);

                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {

                    }
                    connY.CloseConnection();
                    #endregion
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Calculate Error");
            }
        }

        #endregion

        #region 修改ZLZL
        private void updatezlzl()
        {
            try
            {
                //檢查有無資料
                int count = 0;
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select COUNT(ZLBH) as count from zlzl where DDBH = '{0}'", tb訂單編號.Text.Trim());
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    count = int.Parse(reader1["count"].ToString());
                }
                dbConn1.CloseConnection();

                //有資料
                if (count > 0)
                {
                    #region NEWERP

                    //update zlzl
                    DBconnect con4u = new DBconnect();
                    StringBuilder sql4u = new StringBuilder();
                    sql4u.AppendFormat("update zlzl set YLJS = 'N',USERID = '{0}',USERDATE = GETDATE(), ver = isnull(ver, 0)+1 where ZLBH = '{1}'", userid, tb訂單編號.Text.Trim());
                    Console.WriteLine(sql4u);
                    SqlCommand cmd4u = new SqlCommand(sql4u.ToString(), con4u.connection);
                    con4u.OpenConnection();
                    int result4u = cmd4u.ExecuteNonQuery();
                    if (result4u == 1)
                    {

                    }
                    con4u.CloseConnection();
                    #endregion

                    #region LYSHOE

                    //update zlzl
                    DBconnect2 con4uY = new DBconnect2();
                    StringBuilder sql4uY = new StringBuilder();
                    sql4uY.AppendFormat("update zlzl set YLJS = 'N',USERID = '{0}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where ZLBH = '{1}'", userid, tb訂單編號.Text.Trim());
                    Console.WriteLine(sql4uY);
                    SqlCommand cmd4uY = new SqlCommand(sql4uY.ToString(), con4uY.connection);
                    con4uY.OpenConnection();
                    int result4uY = cmd4uY.ExecuteNonQuery();
                    if (result4uY == 1)
                    {

                    }
                    con4uY.CloseConnection();
                    #endregion

                    //取出zlzls版本
                    int ver = 0;
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select isnull(MAX(VER),0)+1 as ver from zlzls where ZLBH = '{0}'", tb訂單編號.Text.Trim());
                    SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                    dbConn2.OpenConnection();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        ver = int.Parse(reader2["ver"].ToString());
                    }
                    dbConn2.CloseConnection();

                    //刪除zlzls

                    DBconnect con3 = new DBconnect();
                    StringBuilder sql3 = new StringBuilder();
                    sql3.AppendFormat("delete zlzls where ZLBH = '{0}'", tb訂單編號.Text.Trim());
                    Console.WriteLine(sql3);
                    SqlCommand cmd3 = new SqlCommand(sql3.ToString(), con3.connection);

                    con3.OpenConnection();
                    int result3 = cmd3.ExecuteNonQuery();
                    if (result3 == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con3.CloseConnection();


                    //insert zlzls
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from ddzls where DDBH = '{0}'", tb訂單編號.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView9.DataSource = ds.Tables[0];


                    int b = 0;
                    b = dataGridView9.Rows.Count;

                    for (int i = 0; i < b; i++)
                    {
                        #region NEWERP

                        int results;
                        DBconnect conns = new DBconnect();
                        string sql1s = string.Format("insert into zlzls (ZLBH, ZLCC,XXCC,QTY,LAST,OS,MS,CUT,USERID,USERDATE,YN,ver) values ('{0}', '{1}','{2}','{3}','0', '0', '0', '0', '{4}', GETDATE(), '1', '{5}')", tb訂單編號.Text.Trim(), dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[2].Value.ToString(), dataGridView9.Rows[i].Cells[3].Value.ToString(), userid, ver);
                        Console.WriteLine(sql1s);

                        SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                        conns.OpenConnection();
                        results = cmd1s.ExecuteNonQuery();
                        if (results == 1)
                        {

                        }
                        conns.CloseConnection();
                        #endregion
                    }

                    #region LYSHOE

                    int resultsY;
                    DBconnect2 connsY = new DBconnect2();
                    string sql1sY = string.Format("delete zlzls where ZLBH = '{0}'insert into zlzls(ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, USERDATE)(select ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls where ZLBH = '{0}')", tb訂單編號.Text.Trim());
                    Console.WriteLine(sql1sY);

                    SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                    connsY.OpenConnection();
                    resultsY = cmd1sY.ExecuteNonQuery();
                    if (resultsY == 1)
                    {
                    }
                    connsY.CloseConnection();
                    #endregion
                }
                else //無資料
                {

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Update zlzl Error");
            }
        }
        #endregion

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {
                    OrderQuery Form = new OrderQuery();
                    Form.ShowDialog();
                    D0001.DataSource = Form.ds.Tables[0];
                }
                else if (tabControl1.SelectedTab == P0005)
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("Select * from DDZL where MDDBH = '{0}'", textBox37.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView3.DataSource = ds.Tables[0];
                }
                else if (tabControl1.SelectedTab == P0007)
                {

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Query Error");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region rewrite
                tb訂單編號.Text = D0001.CurrentRow.Cells[0].Value.ToString();
                cb狀態.Text = D0001.CurrentRow.Cells[1].Value.ToString();
                cb鞋型.Text = D0001.CurrentRow.Cells[2].Value.ToString();
                tb鞋名.Text = D0001.CurrentRow.Cells[3].Value.ToString();
                cb色號.Text = D0001.CurrentRow.Cells[4].Value.ToString();
                tb版本.Text = D0001.CurrentRow.Cells[5].Value.ToString();
                tbArticle.Text = D0001.CurrentRow.Cells[6].Value.ToString();
                cb尺寸國別.Text = D0001.CurrentRow.Cells[7].Value.ToString();
                cb客戶.Text = D0001.CurrentRow.Cells[8].Value.ToString();
                tb幣別.Text = D0001.CurrentRow.Cells[9].Value.ToString();
                tb客戶PO.Text = D0001.CurrentRow.Cells[10].Value.ToString();
                tb通路商1.Text = D0001.CurrentRow.Cells[11].Value.ToString();
                tb通路商PO.Text = D0001.CurrentRow.Cells[12].Value.ToString();
                cb訂單類型.Text = D0001.CurrentRow.Cells[13].Value.ToString();
                cb產品類別.Text = D0001.CurrentRow.Cells[14].Value.ToString();
                cb包裝方式.Text = D0001.CurrentRow.Cells[15].Value.ToString();
                tb接單日期.Text = D0001.CurrentRow.Cells[16].Value.ToString();
                //tb訂單編號.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                //tb訂單編號.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                //tb訂單編號.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                tb離廠日期.Text = D0001.CurrentRow.Cells[20].Value.ToString();
                tb總雙數.Text = D0001.CurrentRow.Cells[21].Value.ToString();
                tb總金額.Text = D0001.CurrentRow.Cells[22].Value.ToString();
                tb製令編號.Text = D0001.CurrentRow.Cells[23].Value.ToString();
                //cb廠區.Text = D0001.CurrentRow.Cells[24].Value.ToString();
                //tb訂單編號.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
                tb用戶編號.Text = D0001.CurrentRow.Cells[26].Value.ToString();
                tb最後異動日.Text = D0001.CurrentRow.Cells[27].Value.ToString();
                tb材質.Text = D0001.CurrentRow.Cells[28].Value.ToString();
                //tb訂單編號.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
                tbLabeelCharge.Text = D0001.CurrentRow.Cells[30].Value.ToString();
                //tb性別.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
                tb領料.Text = D0001.CurrentRow.Cells[32].Value.ToString();

                tb完成日期.Text = D0001.CurrentRow.Cells[49].Value.ToString();

                if (D0001.CurrentRow.Cells[44].Value.ToString() != "")
                {
                    cb出口港.Visible = true;
                    cb出口港2.Visible = true;
                    cb出口港.Text = D0001.CurrentRow.Cells[44].Value.ToString();
                    cb出口港2.Text = D0001.CurrentRow.Cells[45].Value.ToString();
                }
                else
                {
                    cb出口港.Visible = false;
                    cb出口港2.Visible = false;
                }

                tb用量版本.Text = D0001.CurrentRow.Cells[46].Value.ToString();

                //Console.WriteLine(dataGridView1.CurrentRow.Cells[48].Value.ToString());
                //Console.WriteLine(dataGridView1.CurrentRow.Cells[49].Value.ToString());

                if (D0001.CurrentRow.Cells[47].Value.ToString() != "")
                {
                    cb國別.Visible = true;
                    cb國別2.Visible = true;
                    cb國別.Text = D0001.CurrentRow.Cells[47].Value.ToString();
                    cb國別2.Text = D0001.CurrentRow.Cells[48].Value.ToString();
                }
                else
                {
                    cb國別.Visible = false;
                    cb國別2.Visible = false;
                }

                #endregion

                DateTime a, b, c, d;
                string aa, bb, cc, dd;

                if (tb離廠日期.Text != "")
                {
                    a = DateTime.Parse(tb離廠日期.Text);
                    aa = a.ToString("yyyy/MM/dd");
                    tb離廠日期.Text = aa;
                }
                if (tb完成日期.Text != "")
                {
                    b = DateTime.Parse(tb完成日期.Text);
                    bb = b.ToString("yyyy/MM/dd");
                    tb完成日期.Text = bb;
                }
                if (tb接單日期.Text != "")
                {
                    c = DateTime.Parse(tb接單日期.Text);
                    cc = c.ToString("yyyy/MM/dd");
                    tb接單日期.Text = cc;
                }
                if (tb最後異動日.Text != "")
                {
                    d = DateTime.Parse(tb最後異動日.Text);
                    dd = d.ToString("yyyy/MM/dd");
                    tb最後異動日.Text = dd;
                }

                string 鞋型 = "", xtmh = "", ddmh = "", daomh = "", gender = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select distinct XieXing,XTMH,DDMH,DAOMH, GENDER from xxzl where XieXing = '{0}'", D0001.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    鞋型 = reader1["XieXing"].ToString();
                    xtmh = reader1["XTMH"].ToString();
                    ddmh = reader1["DDMH"].ToString();
                    daomh = reader1["DAOMH"].ToString();
                    //gender = reader1["GENDER"].ToString();
                }
                dbConn1.CloseConnection();

                tb鞋型2.Text = 鞋型;
                tb楦頭模號.Text = xtmh;
                tb大底模號.Text = ddmh;
                tb面刀模號.Text = daomh;
                //tb性別.Text = gender;

                string 客戶 = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select kfqm from kfzl where kfdh = '{0}'", cb客戶.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    客戶 = reader2["kfqm"].ToString();
                }

                dbConn2.CloseConnection();
                tb客戶編號2.Text = 客戶;

                string 目的地 = "";
                DBconnect dbConn4 = new DBconnect();
                string sql4 = string.Format("select ywsm from DESTINATION where DESTINATION_ID = '{0}'", cb出口港.Text);
                SqlCommand cmd4 = new SqlCommand(sql4, dbConn4.connection);
                dbConn4.OpenConnection();
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    目的地 = reader4["ywsm"].ToString();
                }
                dbConn4.CloseConnection();
                cb出口港2.Text = 目的地;

                //訂單號
                textBox35.Text = D0001.CurrentRow.Cells[0].Value.ToString();
                textBox36.Text = D0001.CurrentRow.Cells[0].Value.ToString();
                textBox37.Text = D0001.CurrentRow.Cells[0].Value.ToString();

                //string XX = "";
                //DBconnect dbConn5 = new DBconnect();
                //string sql5 = string.Format("select Remark from DDZL left join xxzls2 on DDZL.XieXing = xxzls2.XieXing and DDZL.SheHao = xxzls2.SheHao where DDBH = '{0}' and ddzl.XieXing = '{1}' and ddzl.SheHao = '{2}' and zylb = 'c'", D0001.CurrentRow.Cells[0].Value.ToString(), D0001.CurrentRow.Cells[2].Value.ToString(), D0001.CurrentRow.Cells[4].Value.ToString());
                //SqlCommand cmd5 = new SqlCommand(sql5, dbConn5.connection);
                //dbConn5.OpenConnection();
                //SqlDataReader reader5 = cmd5.ExecuteReader();
                //if (reader5.Read())
                //{
                //    XX = reader5["Remark"].ToString();
                //}
                //dbConn5.CloseConnection();
                //textBox4.Text = XX;

                tb性別.Text = "";
                string gendertext = "";
                DBconnect dbConn4g = new DBconnect();
                string sql4g = string.Format("select GENDERE from GENDER where GENDER_id = '{0}'", D0001.CurrentRow.Cells[31].Value.ToString());
                SqlCommand cmd4g = new SqlCommand(sql4g, dbConn4g.connection);
                dbConn4g.OpenConnection();
                SqlDataReader reader4g = cmd4g.ExecuteReader();
                if (reader4g.Read())
                {
                    gendertext = reader4g["GENDERE"].ToString();
                }

                dbConn4g.CloseConnection();
                tb性別.Text = gendertext;
                //tb性別.Text = D0001.CurrentRow.Cells[31].Value.ToString();
            }
            catch (Exception) { }
        }

        private void cb客戶_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0002)
                {
                    if (tsbInsert.Enabled == false)
                    {
                        string 客戶 = "", bb = "";
                        DBconnect dbConn1 = new DBconnect();
                        string sql1 = string.Format("select kfqm,bb from kfzl where kfdh = '{0}'", cb客戶.Text);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                        dbConn1.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            客戶 = reader1["kfqm"].ToString();
                            bb = reader1["bb"].ToString();
                        }

                        dbConn1.CloseConnection();
                        tb客戶編號2.Text = 客戶;
                        tb幣別.Text = bb;

                        createddbh();

                        DBconnect dbconn = new DBconnect();
                        string sql = string.Format("select* from xxzl where KHDH = '{0}'", cb客戶.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn.connection);
                        adapter.Fill(dsc1, "倉庫");

                        cb鞋型.DataSource = dsc1.Tables[0];
                        cb鞋型.ValueMember = "XieXing";
                        cb鞋型.DisplayMember = "XieXing";
                        cb鞋型.MaxDropDownItems = 8;
                        cb鞋型.IntegralHeight = false;
                    }
                }
            }
            catch (Exception) { }
        }

        private void cb鞋型_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dsc7 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql = string.Format("select* from xxzl where KHDH = '{0}' and XieXing = '{1}'", cb客戶.Text, cb鞋型.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn.connection);
                adapter.Fill(dsc7, "倉庫");

                cb色號.DataSource = dsc7.Tables[0];
                cb色號.ValueMember = "SheHao";
                cb色號.DisplayMember = "SheHao";
                cb色號.MaxDropDownItems = 8;
                cb色號.IntegralHeight = false;
            }
            catch (Exception) { }
        }

        private void cb色號_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string art = "", mart = "";
                string 鞋型 = "", xtmh = "", ddmh = "", daomh = "", gender = "", ver = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select* from xxzl where KHDH = '{0}' and XieXing = '{1}' and SheHao = '{2}'", cb客戶.Text, cb鞋型.Text, cb色號.Text);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    art = reader1["ARTICLE"].ToString();
                    mart = reader1["CLID"].ToString();
                    鞋型 = reader1["XieXing"].ToString();
                    xtmh = reader1["XTMH"].ToString();
                    ddmh = reader1["DDMH"].ToString();
                    daomh = reader1["DAOMH"].ToString();
                    gender = reader1["GENDER"].ToString();
                    ver = reader1["VER"].ToString();
                }

                dbConn1.CloseConnection();

                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select GENDERE from GENDER where GENDER_id = '{0}'", gender);
                Console.WriteLine(sql2);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    gender = reader2["GENDERE"].ToString();
                }

                dbConn2.CloseConnection();

                tbArticle.Text = art;
                tb材質.Text = mart;
                tb鞋型2.Text = 鞋型;
                tb楦頭模號.Text = xtmh;
                tb大底模號.Text = ddmh;
                tb面刀模號.Text = daomh;
                tb性別.Text = gender;
                tb版本.Text = ver;
            }
            catch (Exception) { }
        }

        private void cb國別_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string 國別 = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select ywsm from COUNTRY where COUNTRY_ID = '{0}'", cb國別.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    國別 = reader1["ywsm"].ToString();
                }

                dbConn1.CloseConnection();
                cb國別2.Text = 國別;
            }
            catch (Exception) { }
        }

        private void cb出口港_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string 目的地 = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select ywsm from DESTINATION where DESTINATION_ID = '{0}'", cb出口港.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    目的地 = reader1["ywsm"].ToString();
                }

                dbConn1.CloseConnection();
                cb出口港2.Text = 目的地;
            }
            catch (Exception) { }
        }

        private void L0071_Click(object sender, EventArgs e)
        {
            try
            {
                string mom = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select COUNT(DDBH) as count from DDZL where DDBH = '{0}' ", tb訂單編號.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    mom = reader1["count"].ToString();
                }

                dbConn1.CloseConnection();

                if (mom == "1")
                {
                    string ddbhm = "";
                    OrderMom Form = new OrderMom();
                    Form.textBox1.Text = cb鞋型.Text;
                    Form.textbox2.Text = cb色號.Text;
                    Form.ShowDialog();
                    ddbhm = Form.ddbh;

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update DDZL set MDDBH = '{0}', USERID = '{1}', USERDATE = GETDATE() where DDBH = '{2}'", ddbhm, userid, tb訂單編號.Text);

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }

                    con4.CloseConnection();
                }
                else
                {
                    MessageBox.Show("SAVE FIRST");
                }
            }
            catch (Exception) { }
        }

        private void L0072_Click(object sender, EventArgs e)
        {
            OrderCarton Form = new OrderCarton();
            Form.ShowDialog();
        }

        private void L0073_Click(object sender, EventArgs e)
        {
            try
            {
                D0002.Visible = true;
                D0002.ReadOnly = false;
                L0074.Enabled = true;
                L0075.Enabled = true;
            }
            catch (Exception) { }
        }

        private void L0074_Click(object sender, EventArgs e)
        {
            try
            {
                double pairs = 0, price = 0;

                int a = 0;
                a = ds.Tables[0].Rows.Count;
                Console.WriteLine(a);

                for (int i = 0; i < a; i++)
                {
                    if (ds.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                    {

                    }
                    else if (ds.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZLs set IPrice = '{0}', USERID = '{1}' , USERDATE = GETDATE(),Quantity = '{5}',Quantity1 = '{6}' where DDBH = '{2}' and LineNum = '{3}' and CC = '{4}'", D0002.Rows[i].Cells[6].Value.ToString(), userid, D0002.Rows[i].Cells[0].Value.ToString(), D0002.Rows[i].Cells[1].Value.ToString(), D0002.Rows[i].Cells[2].Value.ToString(), D0002.Rows[i].Cells[3].Value.ToString(), D0002.Rows[i].Cells[9].Value.ToString());

                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {

                        }

                        con4.CloseConnection();

                        DBconnect con5 = new DBconnect();
                        StringBuilder sql5 = new StringBuilder();
                        sql5.AppendFormat("update zlzl set SHQR = 'N',USERID = '{0}',USERDATE = GETDATE() where DDBH = '{1}'", userid, tb訂單編號.Text);

                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {

                        }

                        con5.CloseConnection();
                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZLs set IPrice = '{0}', USERID = '{1}' , USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) ,Quantity = '{5}',Quantity1 = '{6}' where DDBH = '{2}' and LineNum = '{3}' and CC = '{4}'", D0002.Rows[i].Cells[6].Value.ToString(), userid, D0002.Rows[i].Cells[0].Value.ToString(), D0002.Rows[i].Cells[1].Value.ToString(), D0002.Rows[i].Cells[2].Value.ToString(), D0002.Rows[i].Cells[3].Value.ToString(), D0002.Rows[i].Cells[9].Value.ToString());

                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);
                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {

                        }
                        con4Y.CloseConnection();

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("update zlzl set SHQR = 'N',USERID = '{0}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{1}'", userid, tb訂單編號.Text);

                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);
                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {

                        }
                        con5Y.CloseConnection();
                        #endregion
                    }

                    pairs += double.Parse(D0002.Rows[i].Cells[3].Value.ToString());

                    price += double.Parse(D0002.Rows[i].Cells[3].Value.ToString()) * double.Parse(D0002.Rows[i].Cells[6].Value.ToString());

                }
                Console.WriteLine(pairs);
                Console.WriteLine(price);

                tb總雙數.Text = pairs.ToString();
                tb總金額.Text = price.ToString();

                //update總數、總價

                #region NEWERP

                DBconnect con = new DBconnect();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("update DDZL set Pairs = '{0}' , Totals = '{1}',USERID = '{2}',USERDATE = GETDATE() where DDBH = '{3}'", pairs, price, userid, tb訂單編號.Text);

                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);
                con.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {

                }
                con.CloseConnection();

                #endregion

                #region LYSHOE

                DBconnect2 conY = new DBconnect2();
                StringBuilder sqlY = new StringBuilder();
                sqlY.AppendFormat("update DDZL set Pairs = '{0}' , Totals = '{1}',USERID = '{2}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) where DDBH = '{3}'", pairs, price, userid, tb訂單編號.Text);

                Console.WriteLine(sqlY);
                SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);
                conY.OpenConnection();
                int resultY = cmdY.ExecuteNonQuery();
                if (resultY == 1)
                {

                }
                conY.CloseConnection();

                #endregion

                updatezlzl();

                D0002.ReadOnly = true;
                L0074.Enabled = false;
                L0075.Enabled = false;
            }
            catch (Exception) 
            {
                MessageBox.Show("Update ddzls Error");
            }
        }

        private void L0075_Click(object sender, EventArgs e)
        {
            loadddzls();
            D0002.ReadOnly = true;
            L0074.Enabled = false;
            L0075.Enabled = false;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0006)
                {
                    if (textBox57.Text == "Y")
                    {
                        DialogResult dr = MessageBox.Show("Delete? 確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            //檢查ZLZL
                            int zlzl = 0;
                            DBconnect dbConn1 = new DBconnect();
                            string sql1 = string.Format("select COUNT(ZLBH) as count from zlzl where ZLBH = '{0}' and zlzl.CGBH is null", textBox38.Text);
                            SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                            dbConn1.OpenConnection();
                            SqlDataReader reader1 = cmd1.ExecuteReader();
                            if (reader1.Read())
                            {
                                zlzl = int.Parse(reader1["count"].ToString());
                            }
                            dbConn1.CloseConnection();

                            if (zlzl == 0)
                            {
                                MessageBox.Show("Can't Delete. Already Cal 已經計算無法刪除");
                            }
                            else
                            {
                                //檢查DDZL
                                int ddzl = 0;
                                DBconnect dbConn2 = new DBconnect();
                                string sql2 = string.Format("select COUNT(DDBH) as count from ddzl where DDBH  ='{0}' balance = 'Y'", textBox38.Text);
                                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                                dbConn2.OpenConnection();
                                SqlDataReader reader2 = cmd2.ExecuteReader();
                                if (reader2.Read())
                                {
                                    ddzl = int.Parse(reader2["count"].ToString());
                                }
                                dbConn2.CloseConnection();

                                if (ddzl == 1)
                                {
                                    #region NEWERP

                                    //刪除ZLZL
                                    DBconnect con4 = new DBconnect();
                                    StringBuilder sql4 = new StringBuilder();
                                    sql4.AppendFormat("delete zlzl where ZLBH = '{0}'", textBox38.Text);
                                    Console.WriteLine(sql4);
                                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                                    con4.OpenConnection();
                                    int result4 = cmd4.ExecuteNonQuery();
                                    if (result4 == 1)
                                    {
                                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con4.CloseConnection();
                                    //刪除ZLZLS
                                    DBconnect con = new DBconnect();
                                    StringBuilder sql = new StringBuilder();
                                    sql.AppendFormat("delete zlzls where ZLBH = '{0}'", textBox38.Text);
                                    Console.WriteLine(sql);
                                    SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                                    con.OpenConnection();
                                    int result = cmd.ExecuteNonQuery();
                                    if (result == 1)
                                    {

                                    }
                                    con.CloseConnection();

                                    #endregion

                                    #region LYSHOE

                                    //刪除ZLZL
                                    DBconnect2 con4Y = new DBconnect2();
                                    StringBuilder sql4Y = new StringBuilder();
                                    sql4Y.AppendFormat("delete zlzl where ZLBH = '{0}'", textBox38.Text);
                                    Console.WriteLine(sql4Y);
                                    SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                                    con4Y.OpenConnection();
                                    int result4Y = cmd4Y.ExecuteNonQuery();
                                    if (result4Y == 1)
                                    {
                                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    con4Y.CloseConnection();
                                    //刪除ZLZLS
                                    DBconnect2 conY = new DBconnect2();
                                    StringBuilder sqlY = new StringBuilder();
                                    sqlY.AppendFormat("delete zlzls where ZLBH = '{0}'", textBox38.Text);
                                    Console.WriteLine(sqlY);
                                    SqlCommand cmdY = new SqlCommand(sqlY.ToString(), conY.connection);

                                    conY.OpenConnection();
                                    int resultY = cmdY.ExecuteNonQuery();
                                    if (resultY == 1)
                                    {

                                    }
                                    conY.CloseConnection();

                                    #endregion
                                }
                                else
                                {
                                    MessageBox.Show("DDZL.Balance有誤");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("請先確認");
                    }
                }
                else if (tabControl1.SelectedTab == P0002) 
                {
                    DialogResult dr = MessageBox.Show("Delete? 確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZL set DDZT = 'C', USERID = '{1}', USERDATE = GETDATE() where DDBH = '{0}'", tb訂單編號.Text, userid);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("Delete Success 停用資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZL set DDZT = 'C', USERID = '{1}', USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) where DDBH = '{0}'", tb訂單編號.Text, userid);
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("停用資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion

                        cb狀態.Text = "C";
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Delete ddzl Error");
            }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            { 
                if (tabControl1.SelectedTab == P0003)
                {
                    L0076.Enabled = true;
                    L0077.Enabled = true;
                    textBox1.Enabled = true;
                    textBox3.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    textBox1.Text = "";
                    textBox3.Text = "";
                    sl3 = 0;

                    string maxxh = "";
                    int a = 0;
                    if (L0076.Checked == true)
                    {
                        //取出最大值                    
                        DBconnect dbConn1 = new DBconnect();
                        string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'E' and DDBH = '{0}'", textBox35.Text);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                        dbConn1.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            maxxh = reader1["max"].ToString();
                        }
                        dbConn1.CloseConnection();
                    }
                    else
                    {
                        //取出最大值

                        DBconnect dbConn1 = new DBconnect();
                        string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'C' and DDBH = '{0}'", textBox35.Text);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                        dbConn1.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            maxxh = reader1["max"].ToString();
                        }
                        dbConn1.CloseConnection();
                    }
                    a = int.Parse(maxxh);
                    a += 1;
                    maxxh = a.ToString();
                    if (maxxh.Length == 1)
                    {
                        maxxh = "00" + maxxh;
                    }
                    else if (maxxh.Length == 2)
                    {
                        maxxh = "0" + maxxh;
                    }
                    Console.WriteLine(maxxh);
                    textBox2.Text = maxxh;

                }
                else if (tabControl1.SelectedTab == P0004)
                {
                    int a = 0;
                    a = dataGridView2.Rows.Count;
                    a = (a + 1) * 3;

                    OrderShippingMark Form = new OrderShippingMark();
                    Form.savestyle = "1";
                    Form.tb1.Enabled = false;
                    Form.tb1.Text = a.ToString();
                    Form.ddbh = tb訂單編號.Text;
                    Form.ShowDialog();

                    loadywddmt();
                }
                else if (tabControl1.SelectedTab == P0006)
                {
                    //檢查ZLZL
                    int zlzl = 0;
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select COUNT(ZLBH) as count from zlzl where ZLBH = '{0}'", textBox38.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        zlzl = int.Parse(reader1["count"].ToString());
                    }

                    dbConn1.CloseConnection();

                    if (zlzl == 0)
                    {
                        //檢查DDZL
                        int ddzl = 0;
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select COUNT(DDBH) as count from ddzl where DDBH  ='{0}' and (DDLB = 'N' or DDLB  = 'S') and DDZT = 'Y' and balance = 'Y'", textBox38.Text);
                        SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                        dbConn2.OpenConnection();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            ddzl = int.Parse(reader2["count"].ToString());
                        }
                        dbConn2.CloseConnection();

                        if (ddzl == 1)
                        {
                            tsbSave.Enabled = true;
                            tsbCancel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("DDZL Error. DDZL資料有誤");
                        }

                        tsbInsert.Enabled = false;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                        //tb總雙數.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("ZLZL exist. 已產生制令");
                    }
                }

            }
            catch (Exception) 
            {
                MessageBox.Show("Insert Error");
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0004)
                {
                    OrderShippingMark Form = new OrderShippingMark();
                    Form.savestyle = "2";
                    Form.tb1.Enabled = true;
                    Form.tb1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    Form.tb2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    Form.tb3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    Form.tb4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    Form.tb5.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                    Form.tb6.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                    Form.tb7.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                    Form.tb8.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                    Form.tb9.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                    Form.ddbh = tb訂單編號.Text;
                    Form.ShowDialog();
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    sl3 = 1;
                    textBox1.Enabled = true;
                    textBox3.Enabled = true;
                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    sl2 = 1;
                    tb離廠日期.Enabled = true;
                    tbLabeelCharge.Enabled = true;
                    //cb出口港.Enabled = true;
                    //cb國別.Enabled = true;
                    cb出口港2.Enabled = true;
                    cb國別2.Enabled = true;
                    tb完成日期.Enabled = true;
                    //tb總雙數.Enabled = true;
                    //tb總金額.Enabled = true;
                    //tb版本.Enabled = true;
                    tb客戶PO.Enabled = true;
                    tb用量版本.Enabled = true;
                    tbArticle.Enabled = true;

                    cb鞋型.Enabled = true;
                    tb鞋型2.Visible = false;
                    cb鞋型.Visible = true;
                    cb色號.Enabled = true;
                    //tbArticle.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {

                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    if (tb完成日期.Text != "")
                    {
                        DateTime a, b;
                        string c, d;
                        a = DateTime.Parse(tb離廠日期.Text);
                        b = DateTime.Parse(tb完成日期.Text);
                        c = a.ToString("yyyy/MM/dd");
                        d = b.ToString("yyyy/MM/dd");
                        if (tbLabeelCharge.Text == "")
                        {
                            tbLabeelCharge.Text = "0";
                        }

                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDZL set ShipDate = '{0}', LABELCHARGE = '{1}', Dest = '{2}', USERID = '{3}', USERDATE = GETDATE(), DDGB = '{5}', FinishedDay = '{6}', Pairs = '{7}', Totals = '{8}', Version = '{9}', KHPO = '{10}', UsageVer = '{11}', XieXing = '{12}', SheHao = '{13}', ARTICLE = '{14}' where DDBH = '{4}' update zlzl set YLJS = 'N' where  ZLBH = '{4}'", c, tbLabeelCharge.Text, cb出口港.Text, userid, tb訂單編號.Text, cb國別.Text, d, tb總雙數.Text, tb總金額.Text, tb版本.Text, tb客戶PO.Text, tb用量版本.Text, cb鞋型.Text, cb色號.Text, tbArticle.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {

                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE
                        //string shipdate;
                        //shipdate = c.Replace("/", "");
                        //Console.WriteLine(shipdate.Trim());

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDZL set ShipDate = CAST(year('{0}') as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month('{0}') as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day('{0}') as NVARCHAR), 2) , LABELCHARGE = '{1}', Dest = '{2}', USERID = '{3}', USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) , DDGB = '{5}', Pairs = '{7}', Totals = '{8}', Version = '{9}', KHPO = '{10}', XieXing = '{12}', SheHao = '{13}', ARTICLE = '{14}' where DDBH = '{4}'  update zlzl set YLJS = 'N' where  ZLBH = '{4}'", c, tbLabeelCharge.Text, cb出口港.Text, userid, tb訂單編號.Text, cb國別.Text, d, tb總雙數.Text, tb總金額.Text, tb版本.Text, tb客戶PO.Text, tb用量版本.Text, cb鞋型.Text, cb色號.Text, tbArticle.Text);
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("修改資料成功! 請重新計算", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion

                        tb離廠日期.Enabled = false;
                        tbLabeelCharge.Enabled = false;
                        cb出口港.Enabled = false;
                        cb國別.Enabled = false;
                        cb出口港2.Enabled = false;
                        cb國別2.Enabled = false;
                        tb完成日期.Enabled = false;
                        tb總雙數.Enabled = false;
                        tb總金額.Enabled = false;
                        tb用量版本.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tb版本.Enabled = false;
                        tb客戶PO.Enabled = false;
                        tb總雙數.Enabled = false;
                        cb鞋型.Enabled = false;
                        cb色號.Enabled = false;
                        tbArticle.Enabled = false;
                        textBox56.Text = "N";

                        MessageBox.Show("Save Success. Calculate Again.修改資料成功! 請重新計算", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //tabControl1.SelectedTab = P0006;
                    }
                    else 
                    {
                        MessageBox.Show("No Finished Day. 未輸入完成日期");
                    }
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    if (sl3 == 0)
                    {
                        if (textBox1.Text != "" && textBox3.Text != "")
                        {
                            if (L0076.Checked == true) //英文
                            {
                                #region NEWERP

                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert into DDBZZL (DDBH, zylb, xh, SEQ,bz, USERID, USERDATE,YN) values ('{0}', 'E', '{1}', '{2}','{3}', '{4}', GETDATE(), '1')", textBox35.Text, textBox2.Text, textBox1.Text, textBox3.Text, userid);
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

                                #region LYSHOE

                                int resultY;
                                DBconnect2 connY = new DBconnect2();
                                string sql1Y = string.Format("delete DDBZZL where DDBH = '{0}'insert into DDBZZL(DDBH, zylb, xh, SEQ, bz, USERID, USERDATE) (select DDBH, zylb, xh, SEQ, bz, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.DDBZZL where DDBH = '{0}')", textBox35.Text, textBox2.Text, textBox1.Text, textBox3.Text, userid);
                                Console.WriteLine(sql1Y);

                                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                                connY.OpenConnection();
                                resultY = cmd1Y.ExecuteNonQuery();
                                if (resultY == 1)
                                {

                                }
                                connY.CloseConnection();

                                #endregion
                            }
                            else if (L0077.Checked == true) //中文
                            {
                                #region NEWERP

                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert into DDBZZL (DDBH, zylb, xh, SEQ,bz, USERID, USERDATE,YN) values ('{0}', 'C', '{1}', '{2}','{3}', '{4}', GETDATE(), '1')", textBox35.Text, textBox2.Text, textBox1.Text, textBox3.Text, userid);
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

                                #region LYSHOE

                                int resultY;
                                DBconnect2 connY = new DBconnect2();
                                string sql1Y = string.Format("delete DDBZZL where DDBH = '{0}'insert into DDBZZL(DDBH, zylb, xh, SEQ, bz, USERID, USERDATE) (select DDBH, zylb, xh, SEQ, bz, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.DDBZZL where DDBH = '{0}' )", textBox35.Text, textBox2.Text, textBox1.Text, textBox3.Text, userid);
                                Console.WriteLine(sql1Y);

                                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                                connY.OpenConnection();
                                resultY = cmd1Y.ExecuteNonQuery();
                                if (resultY == 1)
                                {

                                }
                                connY.CloseConnection();

                                #endregion
                            }
                            dsm1 = new DataSet();
                            DBconnect dbConn = new DBconnect();
                            string sql = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'E' and DDBH = '{0}' ", textBox35.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.Fill(dsm1, "棧板表");
                            dataGridView5.DataSource = dsm1.Tables[0];

                            dsm2 = new DataSet();
                            DBconnect dbConn2 = new DBconnect();
                            string sql2 = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'C' and DDBH = '{0}' ", textBox35.Text);
                            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                            adapter2.Fill(dsm2, "棧板表");
                            dataGridView6.DataSource = dsm2.Tables[0];
                            L0076.Enabled = false;
                            L0077.Enabled = false;
                            textBox1.Enabled = false;
                            textBox3.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No Data, 請輸入列印序跟備註");
                        }
                    }
                    else if (sl3 == 1)
                    {
                        string ec = "";
                        if (L0076.Checked == true)
                        {
                            ec = "E";
                        }
                        else
                        {
                            ec = "C";
                        }

                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update DDBZZL set SEQ = '{0}' , bz = '{1}',USERID  ='{2}',USERDATE = GETDATE() where DDBH = '{3}' and zylb = '{4}' and xh = '{5}'", textBox1.Text, textBox3.Text, userid, textBox35.Text, ec, textBox2.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update DDBZZL set SEQ = '{0}' , bz = '{1}',USERID  ='{2}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2)  where DDBH = '{3}' and zylb = '{4}' and xh = '{5}'", textBox1.Text, textBox3.Text, userid, textBox35.Text, ec, textBox2.Text);
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion
                    }

                    textBox1.Enabled = true;
                    textBox3.Enabled = true;
                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0004)
                {

                }
                else if (tabControl1.SelectedTab == P0005)
                {

                }
                else if (tabControl1.SelectedTab == P0006)
                {
                    if (textBox57.Text == "N")
                    {
                        insertzlzl();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Change Factory Area? 確定要修改廠區?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            #region NEWERP

                            DBconnect con4u = new DBconnect();
                            StringBuilder sql4u = new StringBuilder();
                            sql4u.AppendFormat("update zlzl set CQDH = '{0}',USERID = '{1}',USERDATE = GETDATE(), ver = isnull(ver, 0)+1 where ZLBH = '{2}' ", cb生產廠區.Text, userid, textBox38.Text);

                            Console.WriteLine(sql4u);
                            SqlCommand cmd4u = new SqlCommand(sql4u.ToString(), con4u.connection);
                            con4u.OpenConnection();
                            int result4u = cmd4u.ExecuteNonQuery();
                            if (result4u == 1)
                            {

                            }
                            con4u.CloseConnection();

                            #endregion

                            #region LYSHOE

                            DBconnect2 con4uY = new DBconnect2();
                            StringBuilder sql4uY = new StringBuilder();
                            sql4uY.AppendFormat("update zlzl set CQDH = '{0}',USERID = '{1}',USERDATE = CAST(year(getdate()) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(getdate()) as NVARCHAR), 2)+RIGHT(REPLICATE('0', 2) + CAST(day(getdate()) as NVARCHAR), 2) where ZLBH = '{2}'", cb生產廠區.Text, userid, textBox38.Text);

                            Console.WriteLine(sql4uY);
                            SqlCommand cmd4uY = new SqlCommand(sql4uY.ToString(), con4uY.connection);
                            con4uY.OpenConnection();
                            int result4uY = cmd4uY.ExecuteNonQuery();
                            if (result4uY == 1)
                            {
                            }
                            con4uY.CloseConnection();

                            #endregion
                        }
                        //MessageBox.Show("已經審核");
                    }

                    //tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    cb生產廠區.Enabled = false;
                    tb總雙數.Enabled = false;
                    textBox57.Text = "Y";
                    textBox55.Text = "Y";
                    textBox55.Enabled = false;
                    textBox56.Enabled = false;
                    textBox57.Enabled = false;
                    textBox58.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0007)
                {

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Save Error");
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {

                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    tbback();
                    tabControl1.SelectedTab = P0001;

                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tb用量版本.Enabled = false;
                    tb離廠日期.Enabled = false;
                    tbLabeelCharge.Enabled = false;
                    cb出口港.Enabled = false;
                    cb國別.Enabled = false;
                    tb完成日期.Enabled = false;
                    tb總雙數.Enabled = false;
                    tb總金額.Enabled = false;

                    tb版本.Enabled = false;
                    tb客戶PO.Enabled = false;
                    cb鞋型.Enabled = false;
                    cb色號.Enabled = false;
                    tbArticle.Enabled = false;
                    cb出口港2.Enabled = false;
                    cb國別2.Enabled = false;
                    //tb總雙數.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    dsm1 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'E' and DDBH = '{0}' ", textBox35.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsm1, "棧板表");
                    dataGridView5.DataSource = dsm1.Tables[0];

                    dsm2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'C' and DDBH = '{0}' ", textBox35.Text);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter2.Fill(dsm2, "棧板表");
                    dataGridView6.DataSource = dsm2.Tables[0];

                    L0076.Enabled = false;
                    L0077.Enabled = false;
                    textBox1.Enabled = false;
                    textBox3.Enabled = false;

                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                }
                else if (tabControl1.SelectedTab == P0004)
                {
                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0005)
                {
                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0006)
                {
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    cb生產廠區.Enabled = false;
                    tb總雙數.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0007)
                {
                    tsbInsert.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Cancel Error");
            }
        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0006)
                {
                    if (textBox57.Text == "N")
                    {
                        DialogResult dr = MessageBox.Show("Confirm?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            #region zlzl


                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert zlzl (ZLBH,DDBH,CQDH,KDRQ,CGBH,GJJH,YLJS,YLBB,SHQR,GSDH,USERID,USERDATE, YN,ver) values ('{0}','{1}','{2}', GETDATE(), '', 'Y', 'N', 'B', 'Y', 'LIN', '{3}',GETDATE(), '1', '1')", textBox39.Text, textBox39.Text, cb生產廠區.SelectedValue, userid);
                            Console.WriteLine(sql1);

                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                            }
                            conn.CloseConnection();

                            #endregion

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete zlzl where ZLBH = '{0}' insert zlzl(ZLBH, DDBH, CQDH, KDRQ, CGBH, GJJH, YLJS, YLBB, SHQR, GSDH, USERID, USERDATE)(select ZLBH, DDBH, CQDH, CAST(year(KDRQ) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(KDRQ) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(KDRQ) as NVARCHAR), 2), 'ZERO', GJJH, YLJS, YLBB, SHQR, GSDH, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzl where ZLBH = '{0}')", textBox39.Text, textBox39.Text, cb生產廠區.SelectedValue, userid);
                            Console.WriteLine(sql1Y);

                            SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                            connY.OpenConnection();
                            resultY = cmd1Y.ExecuteNonQuery();
                            if (resultY == 1)
                            {

                            }
                            connY.CloseConnection();

                            #endregion

                            //insert zlzls
                            ds = new DataSet();
                            DBconnect dbConn = new DBconnect();
                            string sql = string.Format("select * from ddzls where DDBH = '{0}'", textBox39.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                            adapter.Fill(ds, "棧板表");
                            dgvzlzls.DataSource = ds.Tables[0];


                            int b = 0;
                            b = dgvzlzls.Rows.Count;

                            for (int i = 0; i < b; i++)
                            {
                                #region NEWERP

                                int results;
                                DBconnect conns = new DBconnect();
                                string sql1s = string.Format("insert into zlzls (ZLBH, ZLCC,XXCC,QTY,LAST,OS,MS,CUT,USERID,USERDATE,YN) values ('{0}', '{1}','{2}','{3}','0', '0', '0', '0', '{4}', GETDATE(), '1')", textBox39.Text, dgvzlzls.Rows[i].Cells[2].Value.ToString(), dgvzlzls.Rows[i].Cells[2].Value.ToString(), dgvzlzls.Rows[i].Cells[3].Value.ToString(), userid);
                                Console.WriteLine(sql1s);

                                SqlCommand cmd1s = new SqlCommand(sql1s, conns.connection);
                                conns.OpenConnection();
                                results = cmd1s.ExecuteNonQuery();
                                if (results == 1)
                                {

                                }
                                conns.CloseConnection();

                                #endregion
                            }

                            #region LYSHOE

                            int resultsY;
                            DBconnect2 connsY = new DBconnect2();
                            string sql1sY = string.Format("delete zlzls where ZLBH = '{0}' insert into zlzls(ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, USERDATE)(select ZLBH, ZLCC, XXCC, QTY, LAST, OS, MS, CUT, USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls where ZLBH = '{0}')", textBox39.Text);
                            Console.WriteLine(sql1sY);

                            SqlCommand cmd1sY = new SqlCommand(sql1sY, connsY.connection);
                            connsY.OpenConnection();
                            resultsY = cmd1sY.ExecuteNonQuery();
                            if (resultsY == 1)
                            {
                            }
                            connsY.CloseConnection();

                            #endregion

                            #endregion

                            textBox55.Text = "Y";
                            textBox57.Text = "Y";

                            textBox55.Enabled = false;
                            textBox56.Enabled = false;
                            textBox57.Enabled = false;
                            textBox58.Enabled = false;
                            cb生產廠區.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Already Confirm, 已經確認過");
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Confirm Error");
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0004)
                {
                    OrderShippingCopy Form = new OrderShippingCopy();
                    Form.textBox3.Text = tb訂單編號.Text;
                    //Form.textBox2.Text = cb鞋型.Text;
                    Form.textBox1.Text = cb鞋型.Text;
                    Form.ShowDialog();
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Copy Error");
            }
        }

        private void tsbCal_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0006)
                {
                    string first = "";
                    first = textBox39.Text;
                    first = first.Substring(0, 1);
                    Console.WriteLine(first);
                    if (first != "Z")
                    {
                        if (textBox55.Text == "Y" && textBox57.Text == "Y")
                        {
                            #region zlzls2
                            #region 取資料

                            //取出版本號*1
                            DBconnect dbConnD = new DBconnect();
                            string sqlD = string.Format("select isnull(MAX(ver), 0)+1 as ver from zlzls2 where ZLBH = '{0}'", textBox38.Text);
                            Console.WriteLine(sqlD);
                            SqlCommand cmdD = new SqlCommand(sqlD, dbConnD.connection);
                            dbConnD.OpenConnection();
                            SqlDataReader readerD = cmdD.ExecuteReader();
                            if (readerD.Read())
                            {
                                ver = int.Parse(readerD["ver"].ToString());
                            }
                            dbConnD.CloseConnection();
                            Console.WriteLine(ver);

                            #endregion

                            //刪除ZLZLS2
                            #region NEWERP

                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete zlzls2 where ZLBH = '{0}' and YN = '1'", textBox38.Text);
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            #endregion

                            #region LYSHOE

                            //DBconnect2 con4Y = new DBconnect2();
                            //StringBuilder sql4Y = new StringBuilder();
                            //sql4Y.AppendFormat("delete zlzls2 where ZLBH = '{0}' and xh = 'SQL'", textBox38.Text);
                            //Console.WriteLine(sql4Y);
                            //SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                            //con4Y.OpenConnection();
                            //int result4Y = cmd4Y.ExecuteNonQuery();
                            //if (result4Y == 1)
                            //{
                            //    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //con4Y.CloseConnection();

                            #endregion

                            //insert 全材料
                            #region insert all

                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver)( select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, sum(CLSL) as clsl, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from (select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left  join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH  left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'N' and BWLB != '3' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and xxgjs.SheHao = ddzl.SheHao and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'Y' and BWLB != '3') as a group by DDBH, BWBH, CSBH, CLBH, clzmlb, SIZE, USAGE) ", textBox39.Text, userid, ver);
                            Console.WriteLine(sql1);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();

                            //刪除特殊材料
                            int resultD;
                            DBconnect connD = new DBconnect();
                            string sql1D = string.Format("delete zlzls2 where zlzls2.zlbh = '{0}' and  bwbh in (select bwbh from xxzlss left join ddzl on ddzl.XieXing = xxzlss.XieXing and ddzl.SheHao = xxzlss.SheHao and ddzl.Dest = xxzlss.cond where DDZL.DDBH = '{0}')", textBox39.Text);
                            Console.WriteLine(sql1D);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1D = new SqlCommand(sql1D, connD.connection);
                            connD.OpenConnection();
                            resultD = cmd1D.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connD.CloseConnection();

                            #endregion



                            DataSet dsBOM = new DataSet();
                            dsBOM = new DataSet();
                            DBconnect dbConnB = new DBconnect();
                            string sqlB = string.Format("select * from BOMAD where XieXing = '{0}' and SheHao = '{1}' and ADTYP = 'A' and cond = '{2}' and bwbh not in (select BWBH from xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox40.Text, textBox41.Text, tb訂單編號.Text);
                            SqlDataAdapter adapterB = new SqlDataAdapter(sqlB, dbConnB.connection);
                            adapterB.Fill(dsBOM, "新增");
                            dataGridView1.DataSource = dsBOM.Tables[0];

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                int resultB2;
                                DBconnect connB2 = new DBconnect();
                                string sqlB2 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN, ver)(select DDBH, Right('000' + Cast((ROW_NUMBER() OVER(ORDER BY DDBH DESC) * 5) as varchar), 3) as xh, BWBH, CSBH, 'ZZZZZZZZZZ' as MJBH, CLBH, clzmlb, SIZE, sum(CLSL) as clsl, USAGE, '{1}' as USERID, GETDATE() as USERDATE, '1' as YN, '{2}' as ver from(select ddbh, 'zzzzzz' as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, sum(CLSLtotal) as clsl, avg(clsl) as usage from (select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join bwzl on xxzls.bwbh = bwzl.bwdh where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'N' and zlzlstemp.BWBH = '{3}' and BWLB = '3' group by ddbh, bwbh, clbh, csbh, clzmlb, cltx, bws union select ddbh, isnull(gjcc, CC) as size, case when bws = 'U' then 1 when bws = 'B' then 2 when bws = 'A' then 3 when bws = 'P' then 4 when bws = 'O' then 5 end as bws, bwbh, clbh, csbh, clzmlb, cltx, CLSLtotal as clsl, clsl as usage from(select DDZLs.DDBH, ddzls.cc, DDZLs.Quantity, Usage_R.bwbh, xxzls.CLBH, xxzls.CSBH, clzl.clzmlb, xxzls.CLTX, xxzls.BWLB, xxzls.CLSL, (DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL as CLSLtotal, total.total, clzl.lycc, xxgjs.GJCC, bwzl.bwlb as bws from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC  and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER left join (select * from xxzls where YN != 0) as xxzls on ddzl.XieXing = xxzls.XieXing and  DDZL.SheHao = xxzls.SheHao and Usage_R.BWBH = xxzls.BWBH left join clzl on xxzls.clbh = clzl.cldh left join xxgjs on xxgjs.GJLB = clzl.gjlb and xxgjs.XieXing = ddzl.XieXing  and  xxgjs.SheHao = ddzl.SheHao and xxgjs.XXCC = ddzls.cc left join bwzl on xxzls.bwbh = bwzl.bwdh left join(select Usage_R.bwbh, sum((DDZLs.Quantity + isnull(DDZLs.Quantity1, 0)) * Usage_R.CLSL) as total from DDZLs left join ddzl on DDZL.DDBH = DDZLs.DDBH left join Usage_R on DDZL.XieXing = Usage_R.XieXing and DDZL.SheHao = Usage_R.SheHao and DDZLs.CC = Usage_R.XTCC and DDZL.Version = Usage_R.xxzlver and DDZL.UsageVer = Usage_R.VER where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null group by Usage_R.bwbh) as total on Usage_R.BWBH = total.BWBH where DDZLs.DDBH = '{0}' and Usage_R.CLSL is not null) as zlzlstemp where lycc = 'Y' and zlzlstemp.BWBH = '{3}' and BWLB = '3') as a group by DDBH, BWBH, CSBH, CLBH, clzmlb, SIZE, USAGE)", tb訂單編號.Text, userid, ver, dataGridView1.Rows[i].Cells[4].Value.ToString());
                                Console.WriteLine(sqlB2);

                                SqlCommand cmdB2 = new SqlCommand(sqlB2, connB2.connection);
                                connB2.OpenConnection();
                                resultB2 = cmdB2.ExecuteNonQuery();
                                if (resultB2 == 1)
                                {

                                }
                                connB2.CloseConnection();
                            }




                            #endregion
                            //insert 拆解母材料
                            #region insert ms

                            //select 母材料
                            int ycount = 0;

                            DBconnect dbConnY = new DBconnect();
                            string sqlY = string.Format("select count(CLBH) as count from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", textBox39.Text);
                            Console.WriteLine(sqlY);
                            SqlCommand cmdY = new SqlCommand(sqlY, dbConnY.connection);
                            dbConnY.OpenConnection();
                            SqlDataReader readerY = cmdY.ExecuteReader();
                            if (readerY.Read())
                            {
                                ycount = int.Parse(readerY["count"].ToString());
                            }
                            dbConnY.CloseConnection();
                            Console.WriteLine(ycount);

                            if (ycount > 0)
                            {
                                //取出母材料
                                dsY1 = new DataSet();
                                DBconnect dbConn = new DBconnect();
                                string sql = string.Format("select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,YN,ver from zlzls2 where ZLBH = '{0}' and ZMLB = 'Y'", textBox39.Text);
                                Console.WriteLine(sql);
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                                adapter.Fill(dsY1, "棧板表");
                                dgvCAL.DataSource = dsY1.Tables[0];

                                for (int i = 0; i < dgvCAL.Rows.Count; i++)
                                {
                                    dsY2 = new DataSet();
                                    DBconnect dbConn2 = new DBconnect();
                                    string sql2 = string.Format("select * from clzhzl where cldh_M = '{0}'", dgvCAL.Rows[i].Cells[5].Value.ToString());
                                    Console.WriteLine(sql2);
                                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                                    adapter2.Fill(dsY2, "棧板表");
                                    dgvCAL2.DataSource = dsY2.Tables[0];
                                    Console.WriteLine("ROWSCOUNT:" + dgvCAL2.Rows.Count);
                                    //插入子材料
                                    for (int j = 0; j < dgvCAL2.Rows.Count; j++)
                                    {
                                        double clsl = 0;
                                        Console.WriteLine(dgvCAL.Rows[i].Cells[8].Value.ToString());
                                        Console.WriteLine(dgvCAL2.Rows[j].Cells[6].Value.ToString());
                                        clsl = double.Parse(dgvCAL.Rows[i].Cells[8].Value.ToString()) * double.Parse(dgvCAL2.Rows[j].Cells[6].Value.ToString());
                                        Console.WriteLine("CLCL:" + clsl);

                                        #region NEWERP

                                        int result3;
                                        DBconnect conn3 = new DBconnect();
                                        string sql3 = string.Format("insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE,YN,ver) values ('{0}','{1}','{2}','{3}','{4}','{5}','N','{6}','{7}','{8}','{9}',GETDATE(),'1','{10}') ", dgvCAL.Rows[i].Cells[0].Value.ToString(), dgvCAL.Rows[i].Cells[1].Value.ToString(), dgvCAL.Rows[i].Cells[2].Value.ToString(), dgvCAL2.Rows[j].Cells[7].Value.ToString(), dgvCAL.Rows[i].Cells[5].Value.ToString(), dgvCAL2.Rows[j].Cells[0].Value.ToString(), dgvCAL.Rows[i].Cells[7].Value.ToString(), clsl, dgvCAL.Rows[i].Cells[9].Value.ToString(), userid, dgvCAL.Rows[i].Cells[11].Value.ToString());
                                        Console.WriteLine(sql3);
                                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                                        SqlCommand cmd3 = new SqlCommand(sql3, conn3.connection);
                                        conn3.OpenConnection();
                                        result3 = cmd3.ExecuteNonQuery();
                                        if (result3 == 1)
                                        {
                                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        conn3.CloseConnection();
                                        #endregion

                                        #region LYSHOE

                                        int result3Y;
                                        DBconnect2 conn3Y = new DBconnect2();
                                        string sql3Y = string.Format("delete zlzls2 where ZLBH = '{0}' insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE)(select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", dgvCAL.Rows[i].Cells[0].Value.ToString());
                                        Console.WriteLine(sql3Y);
                                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                                        SqlCommand cmd3Y = new SqlCommand(sql3Y, conn3Y.connection);
                                        conn3Y.OpenConnection();
                                        result3Y = cmd3Y.ExecuteNonQuery();
                                        if (result3Y == 1)
                                        {
                                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        conn3Y.CloseConnection();
                                        #endregion
                                    }
                                }

                            }

                            #endregion

                            MessageBox.Show("插入資料完成", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #endregion

                            #region 修改DDZL

                            #region NEWERP

                            DBconnect cond = new DBconnect();
                            StringBuilder sqld = new StringBuilder();
                            sqld.AppendFormat("update ddzl set ZLBH  = '{0}' where DDBH = '{1}'", textBox38.Text, textBox38.Text);

                            Console.WriteLine(sqld);
                            SqlCommand cmdd = new SqlCommand(sqld.ToString(), cond.connection);
                            cond.OpenConnection();
                            int resultd = cmdd.ExecuteNonQuery();
                            if (resultd == 1)
                            {

                            }
                            cond.CloseConnection();
                            #endregion

                            #region LYSHOE
                            DBconnect2 condY = new DBconnect2();
                            StringBuilder sqldY = new StringBuilder();
                            sqldY.AppendFormat("update ddzl set ZLBH  = '{0}' where DDBH = '{1}'", textBox38.Text, textBox38.Text);

                            Console.WriteLine(sqldY);
                            SqlCommand cmddY = new SqlCommand(sqldY.ToString(), condY.connection);
                            condY.OpenConnection();
                            int resultdY = cmddY.ExecuteNonQuery();
                            if (resultdY == 1)
                            {
                            }
                            condY.CloseConnection();

                            #endregion

                            #endregion

                            #region 修改ZLZL

                            #region NEWERP

                            DBconnect cond2 = new DBconnect();
                            StringBuilder sqld2 = new StringBuilder();
                            sqld2.AppendFormat("update zlzl set YLJS = 'Y' where ZLBH = '{0}'", textBox38.Text);

                            Console.WriteLine(sqld2);
                            SqlCommand cmdd2 = new SqlCommand(sqld2.ToString(), cond2.connection);
                            cond2.OpenConnection();
                            int resultd2 = cmdd2.ExecuteNonQuery();
                            if (resultd2 == 1)
                            {

                            }
                            cond2.CloseConnection();
                            #endregion

                            #region LYSHOE

                            DBconnect2 cond2Y = new DBconnect2();
                            StringBuilder sqld2Y = new StringBuilder();
                            sqld2Y.AppendFormat("update zlzl set YLJS = 'Y' where ZLBH = '{0}'", textBox38.Text);

                            Console.WriteLine(sqld2Y);
                            SqlCommand cmdd2Y = new SqlCommand(sqld2Y.ToString(), cond2Y.connection);
                            cond2Y.OpenConnection();
                            int resultd2Y = cmdd2Y.ExecuteNonQuery();
                            if (resultd2Y == 1)
                            {

                            }
                            cond2Y.CloseConnection();
                            #endregion



                            //計算特殊材料
                            special();

                            //刪除BOM
                            DBconnect con4B = new DBconnect();
                            StringBuilder sql4B = new StringBuilder();
                            sql4B.AppendFormat("delete zlzls2 where zlbh = '{0}' and BWBH in (select bwbh from BOMAD where cond = '{0}' and ADTYP = 'D')", textBox38.Text);
                            Console.WriteLine(sql4B);
                            SqlCommand cmd4B = new SqlCommand(sql4B.ToString(), con4B.connection);
                            con4B.OpenConnection();
                            int result4B = cmd4B.ExecuteNonQuery();
                            if (result4B == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4B.CloseConnection();

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete zlzls2 where ZLBH = '{0}' insert into zlzls2 (ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID,USERDATE)(select ZLBH,xh,BWBH,CSBH,MJBH,CLBH,ZMLB,SIZE,CLSL,USAGE,USERID, CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) from [192.168.11.15].New_Erp.dbo.zlzls2 where ZLBH = '{0}')", textBox39.Text);
                            Console.WriteLine(sql1Y);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                            connY.OpenConnection();
                            resultY = cmd1Y.ExecuteNonQuery();
                            if (resultY == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connY.CloseConnection();

                            #endregion

                            //新增OLD
                            int oldVer = 0;
                            DBconnect dbConnV = new DBconnect();
                            string sqlV = string.Format("select isnull(MAX(plus), 0)+1 as ver from zlzls2old where ZLBH = '{0}'", textBox38.Text);
                            Console.WriteLine(sqlV);
                            SqlCommand cmdV = new SqlCommand(sqlV, dbConnV.connection);
                            dbConnV.OpenConnection();
                            SqlDataReader readerV = cmdV.ExecuteReader();
                            if (readerV.Read())
                            {
                                oldVer = int.Parse(readerV["ver"].ToString());
                            }
                            dbConnV.CloseConnection();
                            Console.WriteLine(oldVer);

                            int resultO;
                            DBconnect connO = new DBconnect();
                            string sql1O = string.Format("insert into zlzls2old select ZLBH, BWBH, CLBH, SIZE, YN, xh, CSBH, MJBH, ZMLB, CLSL, USAGE, USERID, USERDATE, CLSL2, Usage2, Qbuy, QWin, Qwot, Udate, LTDBH, '{2}' from zlzls2 where ZLBH = '{0}' and ver = ('{1}')", textBox38.Text, ver, oldVer);
                            Console.WriteLine(sql1O);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1O = new SqlCommand(sql1O, connO.connection);
                            connO.OpenConnection();
                            resultO = cmd1O.ExecuteNonQuery();
                            if (resultO == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connO.CloseConnection();

                            #endregion
                            textBox56.Text = "Y";
                        }
                        else
                        {
                            MessageBox.Show("Save First, 請先審核和確認工具");
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Can not Calculate");
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Calculate Error 計算錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void L0076_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string maxxh = "";
                int a = 0;
                if (L0076.Checked == true)
                {
                    //取出最大值                    
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'E' and DDBH = '{0}'", textBox35.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        maxxh = reader1["max"].ToString();
                    }
                    dbConn1.CloseConnection();
                }
                else
                {
                    //取出最大值

                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'C' and DDBH = '{0}'", textBox35.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        maxxh = reader1["max"].ToString();
                    }
                    dbConn1.CloseConnection();
                }
                a = int.Parse(maxxh);
                a += 1;
                maxxh = a.ToString();
                if (maxxh.Length == 1)
                {
                    maxxh = "00" + maxxh;
                }
                else if (maxxh.Length == 2)
                {
                    maxxh = "0" + maxxh;
                }
                Console.WriteLine(maxxh);
                textBox2.Text = maxxh;
            }
            catch (Exception) { }
        }

        private void L0077_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string maxxh = "";
                int a = 0;
                if (L0076.Checked == true)
                {
                    //取出最大值                    
                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'E' and DDBH = '{0}'", textBox35.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        maxxh = reader1["max"].ToString();
                    }
                    dbConn1.CloseConnection();
                }
                else
                {
                    //取出最大值

                    DBconnect dbConn1 = new DBconnect();
                    string sql1 = string.Format("select isnull(MAX(xh),0) as max from DDBZZL where zylb  = 'C' and DDBH = '{0}'", textBox35.Text);
                    SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                    dbConn1.OpenConnection();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        maxxh = reader1["max"].ToString();
                    }
                    dbConn1.CloseConnection();
                }
                a = int.Parse(maxxh);
                a += 1;
                maxxh = a.ToString();
                if (maxxh.Length == 1)
                {
                    maxxh = "00" + maxxh;
                }
                else if (maxxh.Length == 2)
                {
                    maxxh = "0" + maxxh;
                }
                Console.WriteLine(maxxh);
                textBox2.Text = maxxh;
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {
                    #region btn

                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;

                    #endregion

                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    tb離廠日期.Enabled = false;
                    tbLabeelCharge.Enabled = false;
                    cb出口港.Enabled = false;
                    cb國別.Enabled = false;
                    tb完成日期.Enabled = false;
                    tb總雙數.Enabled = false;
                    tb總金額.Enabled = false;
                    tb用量版本.Enabled = false;
                    cb出口港2.Enabled = false;
                    cb國別2.Enabled = false;

                    tb版本.Enabled = false;
                    tb客戶PO.Enabled = false;
                    tb總雙數.Enabled = false;
                    cb鞋型.Enabled = false;
                    cb色號.Enabled = false;
                    tbArticle.Enabled = false;

                    #region btn

                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = true;
                    tsbConfirm.Enabled = false;

                    string facarea = D0001.CurrentRow.Cells[0].Value.ToString();
                    facarea = facarea.Substring(0, 1);
                    if (facarea == "S")
                    {
                        cb廠區.SelectedIndex = 0;
                    }
                    else if (facarea == "C")
                    {
                        cb廠區.SelectedIndex = 2;
                    }
                    else if (facarea == "F")
                    {
                        cb廠區.SelectedIndex = 1;
                    }

                    #endregion
                    loadddzls();
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    #region btn

                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;

                    #endregion

                    L0076.Enabled = false;
                    L0077.Enabled = false;
                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    if (textBox35.Text == "")
                    {
                        MessageBox.Show("No Order Number.沒有訂單號");
                        tabControl1.SelectedTab = P0001;
                    }
                    else
                    {
                        dsm1 = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'E' and DDBH = '{0}' ", textBox35.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(dsm1, "棧板表");
                        dataGridView5.DataSource = dsm1.Tables[0];

                        dsm2 = new DataSet();
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select xh,SEQ,bz from DDBZZL where zylb  = 'C' and DDBH = '{0}' ", textBox35.Text);
                        SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter2.Fill(dsm2, "棧板表");
                        dataGridView6.DataSource = dsm2.Tables[0];
                    }
                }
                else if (tabControl1.SelectedTab == P0004)
                {
                    #region btn

                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = true;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;

                    #endregion

                    if (textBox36.Text == "")
                    {
                        MessageBox.Show("No Order Number.沒有訂單號");
                        tabControl1.SelectedTab = P0001;
                    }
                    else
                    {
                        loadywddmt();
                    }
                }
                else if (tabControl1.SelectedTab == P0005)
                {
                    #region btn

                    tsbQuery.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;

                    #endregion

                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("Select * from DDZL where MDDBH = '{0}'", textBox37.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView3.DataSource = ds.Tables[0];
                }
                else if (tabControl1.SelectedTab == P0006)
                {
                    #region btn

                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = true;
                    tsbDelete.Enabled = true;
                    tsbConfirm.Enabled = true;
                    cb生產廠區.Enabled = true;
                    tb總雙數.Enabled = true;
                    cb生產廠區.SelectedIndex = 5;

                    #endregion

                    if (tb訂單編號.Text == "")
                    {
                        MessageBox.Show("No Order Number.無訂單號");
                        tabControl1.SelectedTab = P0001;
                    }
                    else
                    {
                        int exist = 0;
                        textBox38.Text = tb訂單編號.Text;
                        textBox39.Text = tb訂單編號.Text;
                        textBox40.Text = tbArticle.Text;
                        textBox44.Text = cb尺寸國別.Text;
                        textBox45.Text = cb客戶.Text;
                        textBox46.Text = tb客戶編號2.Text;
                        textBox47.Text = tb離廠日期.Text;
                        textBox49.Text = cb產品類別.Text;
                        textBox50.Text = cb包裝方式.Text;
                        textBox52.Text = tb接單日期.Text;
                        textBox54.Text = cb狀態.Text;

                        DBconnect dbConn1 = new DBconnect();
                        string sql1 = string.Format("select COUNT(ZLBH) as count from zlzl where ZLBH = '{0}'", textBox39.Text);
                        SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                        dbConn1.OpenConnection();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            exist = int.Parse(reader1["count"].ToString());
                        }
                        dbConn1.CloseConnection();

                        dsload = new DataSet();
                        DBconnect dbConnload = new DBconnect();
                        string sqlload = string.Format("select * from zlzl where ZLBH = '{0}'", textBox39.Text);
                        Console.WriteLine(sqlload);
                        SqlDataAdapter adapterload = new SqlDataAdapter(sqlload, dbConnload.connection);
                        adapterload.Fill(dsload, "棧板表");
                        dataGridView8.DataSource = dsload.Tables[0];

                        if (exist > 0)
                        {
                            textBox55.Text = dataGridView8.Rows[0].Cells[5].Value.ToString();
                            textBox56.Text = dataGridView8.Rows[0].Cells[6].Value.ToString();
                            textBox57.Text = dataGridView8.Rows[0].Cells[8].Value.ToString();
                            textBox58.Text = dataGridView8.Rows[0].Cells[7].Value.ToString();
                            textBox59.Text = dataGridView8.Rows[0].Cells[10].Value.ToString();
                            textBox60.Text = dataGridView8.Rows[0].Cells[11].Value.ToString();
                            textBox55.Enabled = false;
                            textBox56.Enabled = false;
                            textBox58.Enabled = false;
                            textBox57.Enabled = false;
                            textBox59.Enabled = false;
                            textBox60.Enabled = false;
                            //cb生產廠區.Enabled = false;
                        }
                        else 
                        {
                            textBox55.Text = "N";
                            textBox56.Text = "N";
                            textBox57.Text = "N";
                        }

                        if (D0001.Rows[0].Cells[24].Value.ToString() != "")
                        {
                            cb生產廠區.Text = D0001.Rows[0].Cells[24].Value.ToString();
                        }

                        if (textBox57.Text == "Y") 
                        {
                            tsbConfirm.Enabled = false;
                        }
                    }

                }
                else if (tabControl1.SelectedTab == P0007)
                {
                    #region btn

                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbCopy.Enabled = false;
                    tsbCal.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbConfirm.Enabled = false;

                    #endregion
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("tabControl Error");
            }
        }

        private void L0087_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox57.Text == "N")
                {
                    MessageBox.Show("Not Confirm yet.尚未確認");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Unlock?確定要解鎖?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update zlzl set SHQR = 'N' where ZLBH = '{0}' ", textBox38.Text);

                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update zlzl set SHQR = 'N' where ZLBH = '{0}'", textBox38.Text);

                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);
                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                        }
                        con4Y.CloseConnection();

                        #endregion

                        textBox57.Text = "N";
                        cb生產廠區.Enabled = true;
                    }
                }
            }
            catch (Exception) { }
        }

        private void L0085_Click(object sender, EventArgs e)
        {
            try
            {
                OrderZlzls Form = new OrderZlzls();
                Form.textBox1.Text = textBox38.Text;
                Form.ShowDialog();
            }
            catch (Exception) { }
        }

        private void L0086_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from DDZLs where DDBH = '{0}'", textBox38.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView7.DataSource = ds.Tables[0];


                dataGridView7.Columns[0].Visible = false;
                dataGridView7.Columns[1].Visible = false;
                dataGridView7.Columns[4].Visible = false;
                dataGridView7.Columns[5].Visible = false;
                dataGridView7.Columns[7].Visible = false;
                dataGridView7.Columns[8].Visible = false;
                dataGridView7.Columns[10].Visible = false;
                dataGridView7.Columns[11].Visible = false;
                dataGridView7.Columns[12].Visible = false;
                dataGridView7.Columns[13].Visible = false;

                dataGridView7.Columns[9].HeaderText = "sample";

            }
            catch (Exception) { }
        }

        private void L0083_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("Select * from ddzl where khbh='客戶' and ddbh not in (select ddbh from zlzl)and ShipDate BETWEEN DAYADD(day,0,'{0}') and DAYADD(day,1,'{1}') ", dateTimePicker1.Text, dateTimePicker2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView4.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
        }

        private void L0084_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("Select * from zlzl left join ddzl on ddzl.ddbh=zlzl.ddbh where ddzl.khbh='客戶' and cgbh is null and ddzl.ShipDate BETWEEN CONVERT ( date, '{0}') and convert(date, '{1}') ", dateTimePicker1.Text, dateTimePicker2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView4.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb訂單編號.Text != "")
            {
                OrderSizeInsert Form = new OrderSizeInsert();
                Form.tbDDBH.Text = tb訂單編號.Text;                
                Form.ShowDialog();
                loadddzls();
                updatezlzl();
            }
        }

        private void cb國別2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb國別.Text = cb國別2.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void cb出口港2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb出口港.Text = cb出口港2.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void cb色號_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                tbArticle.Text = "";
                tb性別.Text = "";

                string article = "";
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select ARTICLE from xxzl where XieXing = '{0}' and SheHao = '{1}'", cb鞋型.Text.Trim(), cb色號.Text.Trim());
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    article = reader1["ARTICLE"].ToString();
                }
                dbConn1.CloseConnection();

                tbArticle.Text = article;
            }
            catch (Exception) { }
        }

        private void cb鞋型_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                tbArticle.Text = "";
                tb性別.Text = "";

                DataSet dsc9 = new DataSet();
                DBconnect dbconn2 = new DBconnect();
                string sql12 = string.Format("select distinct SheHao from xxzl where XieXing = '{0}'", cb鞋型.Text.Trim());
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsc9, "倉庫");

                cb色號.DataSource = dsc9.Tables[0];
                cb色號.ValueMember = "SheHao";
                cb色號.DisplayMember = "SheHao";
                cb色號.MaxDropDownItems = 8;
                cb色號.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion

        private void tsbNext_Click(object sender, EventArgs e)
        {

        }

        private void tsbPrior_Click(object sender, EventArgs e)
        {

        }

        private void tbArticle_Click(object sender, EventArgs e)
        {
            OrderArticle Form = new OrderArticle();
            Form.kfbh = cb客戶.SelectedValue.ToString().Trim();
            Form.ShowDialog();
            cb鞋型.Text = Form.xiexing;
            cb色號.Text = Form.shehao;
            tbArticle.Text = Form.article;
        }
    }
}
