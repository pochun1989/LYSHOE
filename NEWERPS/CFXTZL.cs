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
    public partial class CFXTZL : Form
    {
        public CFXTZL()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds6 = new DataSet();
        DataSet dsI = new DataSet();
        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        public string userid = "";
        int index = 0;
        Boolean copy = false;
        string sAll;
        string xie = "", she = "";
        int confirmsave = 0;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZL";

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
                //int r = dgvWord.Rows.Count;

                //for (int i = 0; i < r; i++)
                //{
                //    dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
                //}

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
                dataGridView1.Columns[12].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView1.Columns[13].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                dataGridView1.Columns[14].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                dataGridView1.Columns[15].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                dataGridView1.Columns[16].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                dataGridView1.Columns[17].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();
                dataGridView1.Columns[18].HeaderText = dgvWord.Rows[18].Cells[3].Value.ToString();
                dataGridView1.Columns[19].HeaderText = dgvWord.Rows[19].Cells[3].Value.ToString();
                dataGridView1.Columns[20].HeaderText = dgvWord.Rows[20].Cells[3].Value.ToString();
                dataGridView1.Columns[21].HeaderText = dgvWord.Rows[21].Cells[3].Value.ToString();
                dataGridView1.Columns[22].HeaderText = dgvWord.Rows[22].Cells[3].Value.ToString();
                dataGridView1.Columns[23].HeaderText = dgvWord.Rows[23].Cells[3].Value.ToString();
                dataGridView1.Columns[24].HeaderText = dgvWord.Rows[24].Cells[3].Value.ToString();
                dataGridView1.Columns[25].HeaderText = dgvWord.Rows[25].Cells[3].Value.ToString();
                dataGridView1.Columns[26].HeaderText = dgvWord.Rows[26].Cells[3].Value.ToString();
                dataGridView1.Columns[27].HeaderText = dgvWord.Rows[27].Cells[3].Value.ToString();
                dataGridView1.Columns[28].HeaderText = dgvWord.Rows[28].Cells[3].Value.ToString();
                dataGridView1.Columns[29].HeaderText = dgvWord.Rows[29].Cells[3].Value.ToString();
                dataGridView1.Columns[30].HeaderText = dgvWord.Rows[30].Cells[3].Value.ToString();
                dataGridView1.Columns[31].HeaderText = dgvWord.Rows[31].Cells[3].Value.ToString();
                dataGridView1.Columns[32].HeaderText = dgvWord.Rows[32].Cells[3].Value.ToString();
                dataGridView1.Columns[33].HeaderText = dgvWord.Rows[33].Cells[3].Value.ToString();
                dataGridView1.Columns[34].HeaderText = dgvWord.Rows[34].Cells[3].Value.ToString();
                dataGridView1.Columns[35].HeaderText = dgvWord.Rows[35].Cells[3].Value.ToString();
                dataGridView1.Columns[36].HeaderText = dgvWord.Rows[36].Cells[3].Value.ToString();
                dataGridView1.Columns[37].HeaderText = dgvWord.Rows[37].Cells[3].Value.ToString();
                dataGridView1.Columns[38].HeaderText = dgvWord.Rows[38].Cells[3].Value.ToString();
                dataGridView1.Columns[39].HeaderText = dgvWord.Rows[39].Cells[3].Value.ToString();
                dataGridView1.Columns[40].HeaderText = dgvWord.Rows[40].Cells[3].Value.ToString();

                dgvBOM.Columns[0].HeaderText = dgvWord.Rows[41].Cells[3].Value.ToString();
                dgvBOM.Columns[1].HeaderText = dgvWord.Rows[42].Cells[3].Value.ToString();
                dgvBOM.Columns[2].HeaderText = dgvWord.Rows[43].Cells[3].Value.ToString();
                dgvBOM.Columns[3].HeaderText = dgvWord.Rows[44].Cells[3].Value.ToString();
                dgvBOM.Columns[4].HeaderText = dgvWord.Rows[45].Cells[3].Value.ToString();
                dgvBOM.Columns[5].HeaderText = dgvWord.Rows[46].Cells[3].Value.ToString();
                dgvBOM.Columns[6].HeaderText = dgvWord.Rows[47].Cells[3].Value.ToString();
                dgvBOM.Columns[7].HeaderText = dgvWord.Rows[48].Cells[3].Value.ToString();
                dgvBOM.Columns[8].HeaderText = dgvWord.Rows[49].Cells[3].Value.ToString();
                dgvBOM.Columns[9].HeaderText = dgvWord.Rows[50].Cells[3].Value.ToString();
                dgvBOM.Columns[10].HeaderText = dgvWord.Rows[51].Cells[3].Value.ToString();
                dgvBOM.Columns[11].HeaderText = dgvWord.Rows[52].Cells[3].Value.ToString();
                dgvBOM.Columns[12].HeaderText = dgvWord.Rows[53].Cells[3].Value.ToString();
                dgvBOM.Columns[13].HeaderText = dgvWord.Rows[54].Cells[3].Value.ToString();
                dgvBOM.Columns[14].HeaderText = dgvWord.Rows[55].Cells[3].Value.ToString();
                dgvBOM.Columns[15].HeaderText = dgvWord.Rows[56].Cells[3].Value.ToString();
                dgvBOM.Columns[16].HeaderText = dgvWord.Rows[57].Cells[3].Value.ToString();
                dgvBOM.Columns[17].HeaderText = dgvWord.Rows[58].Cells[3].Value.ToString();
                //dgvBOM.Columns[18].HeaderText = dgvWord.Rows[59].Cells[3].Value.ToString();
                dataGridView3.Columns[0].HeaderText = dgvWord.Rows[59].Cells[3].Value.ToString();
                dataGridView3.Columns[1].HeaderText = dgvWord.Rows[60].Cells[3].Value.ToString();
                dataGridView3.Columns[2].HeaderText = dgvWord.Rows[61].Cells[3].Value.ToString();
                dataGridView3.Columns[3].HeaderText = dgvWord.Rows[62].Cells[3].Value.ToString();
                dataGridView3.Columns[4].HeaderText = dgvWord.Rows[63].Cells[3].Value.ToString();
                dataGridView3.Columns[5].HeaderText = dgvWord.Rows[64].Cells[3].Value.ToString();
                dataGridView3.Columns[6].HeaderText = dgvWord.Rows[65].Cells[3].Value.ToString();
                dataGridView3.Columns[7].HeaderText = dgvWord.Rows[66].Cells[3].Value.ToString();
                dataGridView3.Columns[8].HeaderText = dgvWord.Rows[67].Cells[3].Value.ToString();
                dataGridView3.Columns[9].HeaderText = dgvWord.Rows[68].Cells[3].Value.ToString();
                dataGridView3.Columns[10].HeaderText = dgvWord.Rows[69].Cells[3].Value.ToString();
                dataGridView3.Columns[11].HeaderText = dgvWord.Rows[70].Cells[3].Value.ToString();
                dataGridView3.Columns[12].HeaderText = dgvWord.Rows[71].Cells[3].Value.ToString();
                dataGridView3.Columns[13].HeaderText = dgvWord.Rows[72].Cells[3].Value.ToString();
                dataGridView3.Columns[14].HeaderText = dgvWord.Rows[73].Cells[3].Value.ToString();
                dataGridView3.Columns[15].HeaderText = dgvWord.Rows[74].Cells[3].Value.ToString();
                dataGridView3.Columns[16].HeaderText = dgvWord.Rows[75].Cells[3].Value.ToString();
                dataGridView3.Columns[17].HeaderText = dgvWord.Rows[76].Cells[3].Value.ToString();
                dataGridView3.Columns[18].HeaderText = dgvWord.Rows[77].Cells[3].Value.ToString();
                dataGridView3.Columns[19].HeaderText = dgvWord.Rows[78].Cells[3].Value.ToString();
                dataGridView3.Columns[20].HeaderText = dgvWord.Rows[79].Cells[3].Value.ToString();

                dataGridView4.Columns[0].HeaderText = dgvWord.Rows[80].Cells[3].Value.ToString();
                dataGridView4.Columns[1].HeaderText = dgvWord.Rows[81].Cells[3].Value.ToString();
                dataGridView4.Columns[2].HeaderText = dgvWord.Rows[82].Cells[3].Value.ToString();
                dataGridView4.Columns[3].HeaderText = dgvWord.Rows[83].Cells[3].Value.ToString();
                dataGridView4.Columns[4].HeaderText = dgvWord.Rows[84].Cells[3].Value.ToString();
                dataGridView4.Columns[5].HeaderText = dgvWord.Rows[85].Cells[3].Value.ToString();
                dataGridView4.Columns[6].HeaderText = dgvWord.Rows[86].Cells[3].Value.ToString();
                dataGridView4.Columns[7].HeaderText = dgvWord.Rows[87].Cells[3].Value.ToString();

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
                L0028.Text = dgvWord.Rows[27].Cells[3].Value.ToString();
                L0029.Text = dgvWord.Rows[28].Cells[3].Value.ToString();
                L0030.Text = dgvWord.Rows[29].Cells[3].Value.ToString();
                L0031.Text = dgvWord.Rows[30].Cells[3].Value.ToString();
                L0032.Text = dgvWord.Rows[31].Cells[3].Value.ToString();
                L0033.Text = dgvWord.Rows[32].Cells[3].Value.ToString();
                L0034.Text = dgvWord.Rows[33].Cells[3].Value.ToString();
                L0035.Text = dgvWord.Rows[34].Cells[3].Value.ToString();
                L0036.Text = dgvWord.Rows[35].Cells[3].Value.ToString();
                L0037.Text = dgvWord.Rows[36].Cells[3].Value.ToString();
                L0038.Text = dgvWord.Rows[37].Cells[3].Value.ToString();
                L0039.Text = dgvWord.Rows[38].Cells[3].Value.ToString();
                L0040.Text = dgvWord.Rows[39].Cells[3].Value.ToString();
                L0041.Text = dgvWord.Rows[40].Cells[3].Value.ToString();
                L0042.Text = dgvWord.Rows[41].Cells[3].Value.ToString();
                L0043.Text = dgvWord.Rows[42].Cells[3].Value.ToString();
                L0044.Text = dgvWord.Rows[43].Cells[3].Value.ToString();
                L0045.Text = dgvWord.Rows[44].Cells[3].Value.ToString();
                L0046.Text = dgvWord.Rows[45].Cells[3].Value.ToString();
                L0047.Text = dgvWord.Rows[46].Cells[3].Value.ToString();
                L0048.Text = dgvWord.Rows[47].Cells[3].Value.ToString();
                L0049.Text = dgvWord.Rows[48].Cells[3].Value.ToString();
                L0050.Text = dgvWord.Rows[49].Cells[3].Value.ToString();
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 開啟TB

        private void TBedit()
        {
            try
            {
                textBox1.Enabled = true;
                //tb1.Enabled = true;
                tb2.Enabled = true;
                tb3.Enabled = true;
                tb4.Enabled = true;
                tb5.Enabled = true;
                tb6.Enabled = true;
                tb7.Enabled = true;
                tb8.Enabled = true;
                tb9.Enabled = true;
                tb10.Enabled = true;
                tb11.Enabled = true;
                tb12.Enabled = true;
                tb13.Enabled = true;
                //tb14.Enabled = true;
                tb15.Enabled = true;
                tb16.Enabled = true;
                tb17.Enabled = true;
                //tb18.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                tb22.Enabled = true;
                //tb23.Enabled = true;
                //tb24.Enabled = true;
                //tb25.Enabled = true;
                //tb26.Enabled = true;
                tb27.Enabled = true;
                tb28.Enabled = false;
                tb29.Enabled = false;
                tb30.Enabled = false;
                tb31.Enabled = false;
                tb32.Enabled = false;
                tb33.Enabled = false;
                tb34.Enabled = false;
                tb35.Enabled = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 清空文字

        private void TBClear()
        {
            try
            {
                //textBox1.Text = "";
                //tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "";
                tb6.Text = "";
                tb7.Text = "";
                tb8.Text = "";
                tb9.Text = "";
                tb10.Text = "";
                tb11.Text = "";
                tb12.Text = "";
                tb13.Text = "";
                //tb14.Enabled = true;
                tb15.Text = "";
                tb16.Text = "";
                tb17.Text = "";
                //tb18.Enabled = true;
                //tb19.Text = "";
                //tb20.Text = "";
                //tb21.Text = "";
                tb22.Text = "";
                //tb23.Enabled = true;
                //tb24.Enabled = true;
                //tb25.Enabled = true;
                //tb26.Enabled = true;
                tb27.Text = "";
                tb28.Text = "";
                tb29.Text = "";
                tb30.Text = "";
                tb31.Text = "";
                tb32.Text = "";
                tb33.Text = "";
                tb34.Text = "";
                tb35.Text = "";
            }
            catch (Exception) { }
        }

        #endregion

        #region 恢復按鈕

        private void TSBback()
        {
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
        }

        #endregion

        #region 關閉TB

        private void TBClose()
        {
            try
            {
                tb1.Enabled = false;
                tb2.Enabled = false;
                tb3.Enabled = false;
                tb4.Enabled = false;
                tb5.Enabled = false;
                tb6.Enabled = false;
                tb7.Enabled = false;
                tb8.Enabled = false;
                tb9.Enabled = false;
                tb10.Enabled = false;
                tb11.Enabled = false;
                tb12.Enabled = false;
                tb13.Enabled = false;
                //tb14.Enabled = true;
                tb15.Enabled = false;
                tb16.Enabled = false;
                tb17.Enabled = false;
                //tb18.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                tb22.Enabled = false;
                //tb23.Enabled = true;
                //tb24.Enabled = true;
                //tb25.Enabled = true;
                //tb26.Enabled = true;
                tb27.Enabled = false;
                tb28.Enabled = false;
                tb29.Enabled = false;
                tb30.Enabled = false;
                tb31.Enabled = false;
                tb32.Enabled = false;
                tb33.Enabled = false;
                tb34.Enabled = false;
                tb35.Enabled = false;
            }
            catch (Exception) { }
        }

        #endregion

        #region 讀取文字

        private void LoadText()
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //tb1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tb7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tb8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tb11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tb2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tb12.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tb10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tb3.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                tb16.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                tb15.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                tb28.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                tb29.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                tb30.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                tb31.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                tb32.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                tb33.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                tb34.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
                tb35.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
                tb27.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
                tb14.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();

                if (dataGridView1.CurrentRow.Cells[31].Value.ToString() == "")
                {
                    tb18.Text = "";
                }
                else
                {
                    tb18.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
                }

                tb22.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();

                //if (dataGridView1.CurrentRow.Cells[31].Value.ToString() == "")
                //{
                //    tb19.Text = "";
                //}
                //else 
                //{
                //    tb19.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
                //}

                //tb21.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
                //tb20.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();
                //tb6.Text = dataGridView1.CurrentRow.Cells[34].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #region 載入資料

        private void Searchdata() 
        {
            try
            {
                string classb = "", shoemode = "", kfzl = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select ywsm from CLASS_B where cllb = '{0}'", tb8.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    classb = reader2["ywsm"].ToString();
                }

                tb9.Text = classb;
                dbConn2.CloseConnection();

                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select ywsm from ShoeMode where Mode_ID = '{0}'", tb12.Text);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    shoemode = reader1["ywsm"].ToString();
                }

                tb13.Text = shoemode;
                dbConn1.CloseConnection();

                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select kfqm from kfzl where kfdh = '{0}'", tb16.Text);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    kfzl = reader3["kfqm"].ToString();
                }
                tb17.Text = kfzl;
                dbConn3.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region INSERT XXZL

        private void InsertXXZL() 
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxzl (XieXing, SheHao, VER, XieMing, YSSM, JiJie, CLID, ARTICLE, BZCC, XieGN, KFCQ, LOGO, KHDH, CCGB, XTGJ, XTMH, DMGJ, DDMH, MSGJ, MDMH, DAOGJ, DAOMH, IMGName, GENDER, USERID, USERDATE, KFXXCZ1, KFXXCZ2, KFXXCZ3, QPrice, OPrice, IPrice, CPrice, YN ) values ('{0}', '{1}', '0', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}','{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}','{19}', '{20}', '{21}', '{22}', '{23}', GETDATE(), '{24}', '{25}', '{26}', '0', '0', '0', '0', '1')", textBox1.Text, tb1.Text,tb4.Text,tb5.Text,tb7.Text,tb8.Text,tb11.Text,tb2.Text,tb12.Text,tb10.Text,tb3.Text,tb16.Text,tb15.Text,tb28.Text,tb29.Text,tb30.Text,tb31.Text,tb32.Text,tb33.Text,tb34.Text,tb35.Text,tb27.Text,tb6.Text,userid,comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
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

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete xxzl where XieXing = '{0}' and SheHao = '{1}' insert into xxzl SELECT [XieXing],[SheHao],[XieMing],[YSSM],[JiJie],[CLID],[ARTICLE],[BZCC],[XieGN],[KFCQ],[LOGO],[KHDH],[CCGB],[XTGJ],[XTMH],[DMGJ],[DDMH],[MSGJ],[MDMH],[DAOGJ],[DAOMH],[IMGName],[Currency],[QPrice],[OPrice],[IPrice],[CPrice],[USERID],CONVERT(varchar,USERDATE,11),[KFXXCZ],[KFXXCZ1],[KFXXCZ2],[KFXXCZ3],[GENDER],[pp],[memo1],[JiJie1],[MTF],[JZF],[xxlock] FROM [192.168.11.15].New_Erp.dbo.[xxzl] where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, tb1.Text, tb4.Text, tb5.Text, tb7.Text, tb8.Text, tb11.Text, tb2.Text, tb12.Text, tb10.Text, tb3.Text, tb16.Text, tb15.Text, tb28.Text, tb29.Text, tb30.Text, tb31.Text, tb32.Text, tb33.Text, tb34.Text, tb35.Text, tb27.Text, tb6.Text, userid, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
                Console.WriteLine(sql1);
                SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                connY.OpenConnection();
                resultY = cmd1Y.ExecuteNonQuery();
                if (resultY == 1)
                {
                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connY.CloseConnection();

                #endregion
            }
            catch (Exception) { }

        }

        #endregion

        #region updateKFXXZL

        private void UpdateKfxxzl() 
        {
            try
            {
                #region NEWERP

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update kfxxzl set CFMDATE = getdate(),USERID = '{0}', USERDATE = getdate() where XieXing = '{1}' and SheHao = '{2}' and CFMDATE is null", userid, textBox1.Text, tb1.Text);
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
                sql4Y.AppendFormat("update kfxxzl set CFMDATE = getdate(),USERID = '{0}', USERDATE = CONVERT(varchar,getdate(),11) where XieXing = '{1}' and SheHao = '{2}' and CFMDATE is null", userid, textBox1.Text, tb1.Text);
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
            catch (Exception) { }
        }

        #endregion

        #region deleteXXZL

        private void DeleteXXZL() 
        {
            try
            {
                int count = 0;
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(DDBH) as count  from DDZL where XieXing = '{0}'", textBox1.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    count = int.Parse(reader2["count"].ToString());
                }

                DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    if (count == 0)
                    {
                        #region NEWERP

                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, tb1.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("delete xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, tb1.Text);
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion

                        tabControl1.SelectedTab = P0001;
                    }
                    else
                    {
                        MessageBox.Show("已被使用 無法刪除", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 刪除COPY

        private void DeleteCopy() 
        {
            try
            {
                #region NEWERP

                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("delete xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, tb1.Text);
                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                #endregion

                #region LYSHOE

                DBconnect2 con4Y = new DBconnect2();
                StringBuilder sql4Y = new StringBuilder();
                sql4Y.AppendFormat("delete xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, tb1.Text);
                Console.WriteLine(sql4Y);
                SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                con4Y.OpenConnection();
                int result4Y = cmd4Y.ExecuteNonQuery();
                if (result4Y == 1)
                {
                    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4Y.CloseConnection();

                #endregion
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改COPY

        private void CopyUpdate() 
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("update xxzl set XieMing = '{0}',YSSM = '{1}',JiJie = '{2}',CLID = '{3}',ARTICLE = '{4}',BZCC = '{5}',XieGN = '{6}', KFCQ = '{7}',LOGO = '{8}',KHDH  = '{9}',CCGB = '{10}',XTGJ = '{11}',XTMH = '{12}',DMGJ = '{13}',DDMH = '{14}',MSGJ = '{15}',MDMH = '{16}',DAOGJ = '{17}',DAOMH = '{18}',IMGName = '{19}',GENDER = '{20}',USERID = '{21}',USERDATE = GETDATE() where  XieXing = '{22}' and SheHao = '{23}'", tb4.Text, tb5.Text, tb7.Text, tb8.Text, tb11.Text, tb2.Text, tb12.Text, tb10.Text, tb3.Text, tb16.Text, tb15.Text, tb28.Text, tb29.Text, tb30.Text, tb31.Text, tb32.Text, tb33.Text, tb34.Text, tb35.Text, tb27.Text, tb6.Text, userid, textBox1.Text, tb1.Text);
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

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("update xxzl set XieMing = '{0}',YSSM = '{1}',JiJie = '{2}',CLID = '{3}',ARTICLE = '{4}',BZCC = '{5}',XieGN = '{6}', KFCQ = '{7}',LOGO = '{8}',KHDH  = '{9}',CCGB = '{10}',XTGJ = '{11}',XTMH = '{12}',DMGJ = '{13}',DDMH = '{14}',MSGJ = '{15}',MDMH = '{16}',DAOGJ = '{17}',DAOMH = '{18}',IMGName = '{19}',GENDER = '{20}',USERID = '{21}',USERDATE = CONVERT(varchar,getdate(),11) where XieXing = '{22}' and SheHao = '{23}'", tb4.Text, tb5.Text, tb7.Text, tb8.Text, tb11.Text, tb2.Text, tb12.Text, tb10.Text, tb3.Text, tb16.Text, tb15.Text, tb28.Text, tb29.Text, tb30.Text, tb31.Text, tb32.Text, tb33.Text, tb34.Text, tb35.Text, tb27.Text, tb6.Text, userid, textBox1.Text, tb1.Text);
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
            }
            catch (Exception) { }
        }

        #endregion

        #region DATA2
        private void LoadData2()
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dgvBOM.DataSource = ds1.Tables[0];                
                dbConn11.CloseConnection();

                DataSet dsB = new DataSet();
                DBconnect dbConn1B = new DBconnect();
                string sqlB = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sqlB);
                SqlDataAdapter adapterB = new SqlDataAdapter(sqlB, dbConn1B.connection);
                adapterB.Fill(dsB, "棧板表");

                dgvBom2.DataSource = dsB.Tables[0];
                dbConn1B.CloseConnection();

            }
            catch (Exception) { }
        }

        #endregion

        #region DATAAVG
        private void LoadDataAVG()
        {
            try
            {
                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select b.VER, b.xh, b.BWBH, c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, b.LOSS, d.AVG, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分段'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER ,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing, SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh left join (select BWBH, AVG(CLSL) as AVG from Usage_R where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' group by BWBH) as d on b.BWBH = d.BWBH where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dgvBOM.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();

            }
            catch (Exception) { }
        }

        #endregion

        #region SAVE2

        private void savexxzls() 
        {
            try
            {
                int a = 0;
                a = ds1.Tables[0].Rows.Count;
                Console.WriteLine(a);

               DialogResult dr = MessageBox.Show("確定要修改嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    #region XXZLS

                    //insert 版本
                    //寫入XXZLS

                    #region NEWERP

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into xxzls (XieXing,SheHao,VER,BWBH,BWLB,xh,CLBH,CLTX,LOSS,CLSL,CLDJ,Currency,Remark,USERID,USERDATE,JGZWSM,JGYWSM,YN)(select XieXing, SheHao, MAX(VER)+1  as VER, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, USERDATE, JGZWSM, JGYWSM, YN from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = '1' group by XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, USERDATE, JGZWSM, JGYWSM, YN)", textBox2.Text, textBox3.Text, dgvBOM.CurrentRow.Cells[0].Value.ToString().Trim());
                    Console.WriteLine(sql1);
                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn.CloseConnection();

                    #endregion

                    #endregion
                    for (int i = 0; i < a; i++)
                    { 
                        Console.WriteLine(ds1.Tables[0].Rows[i].RowState.ToString());
                        if (ds1.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                        {

                        }
                        else if (ds1.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                        {
                            string d34 = "", d313 = "";
                            if (dgvBOM.CurrentRow.Cells[4].Value.ToString() == "一般") 
                            {
                                d34 = "1";
                            }
                            else if (dgvBOM.CurrentRow.Cells[4].Value.ToString() == "外包裝")
                            {
                                d34 = "2";
                            }
                            else if (dgvBOM.CurrentRow.Cells[4].Value.ToString() == "特殊")
                            {
                                d34 = "3";
                            }

                            if (dgvBOM.CurrentRow.Cells[13].Value.ToString() == "One On One")
                            {
                                d313 = "1";
                            }
                            else if (dgvBOM.CurrentRow.Cells[13].Value.ToString() == "分段")
                            {
                                d313 = "2";
                            }
                            else if (dgvBOM.CurrentRow.Cells[13].Value.ToString() == "No Size")
                            {
                                d313 = "3";
                            }

                            //max版本
                            string maxver = "";
                            DBconnect dbConn2 = new DBconnect();
                            string sql2 = string.Format("select MAX(VER) as ver  from xxzls where XieXing = '{0}' and SheHao = '{1}'", textBox2.Text, textBox3.Text);

                            Console.WriteLine(sql2);

                            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                            dbConn2.OpenConnection();
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.Read())
                            {
                                maxver = reader2["ver"].ToString();
                            }
                            dbConn2.CloseConnection();

                            //update 舊版
                            int maxver2 = 0;
                            maxver2 = int.Parse(maxver) - 1;

                            DBconnect conO = new DBconnect();
                            StringBuilder sqlO = new StringBuilder();
                            sqlO.AppendFormat("update xxzls set  YN = '0' where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", textBox2.Text, textBox3.Text, maxver2.ToString().Trim());
                            Console.WriteLine(sqlO);
                            SqlCommand cmdO = new SqlCommand(sqlO.ToString(), conO.connection);

                            conO.OpenConnection();
                            int resultO = cmdO.ExecuteNonQuery();
                            if (resultO == 1)
                            {

                            }
                            conO.CloseConnection();

                            #region modify
                            ////modifyxxzls
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update xxzls set  USERID = '{0}',USERDATE = GETDATE(), xh = '{1}',BWBH = '{2}',BWLB = '{3}',CLBH = '{4}',CSBH = '{5}', LOSS = '{6}' ,CLSL = '{7}',CLTX = '{8}',CCQQ = '{9}', CCQZ = '{10}' where XieXing = '{11}' and SheHao = '{12}' and VER = '{13}' and CLBH = '{14}' and YN = 1  and BWBH = '{15}'", userid, dgvBOM.Rows[i].Cells[1].Value.ToString(), dgvBOM.Rows[i].Cells[2].Value.ToString(), d34, dgvBOM.Rows[i].Cells[5].Value.ToString(), dgvBOM.Rows[i].Cells[10].Value.ToString(), dgvBOM.Rows[i].Cells[11].Value.ToString(), dgvBOM.Rows[i].Cells[12].Value.ToString(), d313, dgvBOM.Rows[i].Cells[14].Value.ToString(), dgvBOM.Rows[i].Cells[15].Value.ToString(), textBox2.Text, textBox3.Text, maxver, dgvBom2.Rows[i].Cells[5].Value.ToString(), dgvBom2.Rows[i].Cells[2].Value.ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {

                            }
                            con4.CloseConnection();
                            #endregion



                        }
                        else if (ds1.Tables[0].Rows[i].RowState.ToString() == "Deleted")//刪除過
                        {
                            //modifyxxzls

                            //DBconnect con4 = new DBconnect();
                            //StringBuilder sql4 = new StringBuilder();
                            //sql4.AppendFormat("update xxzls set YN = 0, USERID = '{0}',USERDATE = GETDATE() where XieXing = '{1}' and SheHao = '{2}' and VER = '{3}' and BWBH = '{4}' and CSBH = '{5}' and YN = 1", userid, textBox2.Text, textBox3.Text, dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[5].Value.ToString());
                            //Console.WriteLine(sql4);
                            //SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            //con4.OpenConnection();
                            //int result4 = cmd4.ExecuteNonQuery();
                            //if (result4 == 1)
                            //{
                            //    //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}

                        }
                    }

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sql1Y = string.Format("delete xxzls where  XieXing = '{0}' and SheHao = '{1}' insert into xxzls(XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, CONVERT(varchar,USERDATE,11) , JGZWSM, JGYWSM)(select XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, CONVERT(varchar,USERDATE,11), JGZWSM, JGYWSM from  [192.168.11.15].New_Erp.dbo.xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = '1')", textBox2.Text, textBox3.Text);
                    Console.WriteLine(sql1Y);
                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    connY.CloseConnection();

                    #endregion
                }
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 畫面載入

        private void CFXTZL_Load(object sender, EventArgs e)
        {

            try
            {
                userid = Program.User.userID;

                DBconnect dbconn = new DBconnect();
                string sql1 = "select Class_ID,zwsm,ywsm from CLASS_A";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dsc1, "倉庫");

                comboBox1.DataSource = dsc1.Tables[0];
                comboBox1.ValueMember = "Class_ID";
                comboBox1.DisplayMember = "ywsm";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                DBconnect dbconn2 = new DBconnect();
                string sql12 = "select Class_ID,zwsm,ywsm from CLASS_A";
                SqlDataAdapter adapter12 = new SqlDataAdapter(sql12, dbconn2.connection);
                adapter12.Fill(dsc2, "倉庫");

                comboBox2.DataSource = dsc2.Tables[0];
                comboBox2.ValueMember = "Class_ID";
                comboBox2.DisplayMember = "ywsm";
                comboBox2.MaxDropDownItems = 8;
                comboBox2.IntegralHeight = false;

                DBconnect dbconn3 = new DBconnect();
                string sql13 = "select Class_ID,zwsm,ywsm from CLASS_A";
                SqlDataAdapter adapter13 = new SqlDataAdapter(sql13, dbconn3.connection);
                adapter13.Fill(dsc3, "倉庫");

                comboBox3.DataSource = dsc3.Tables[0];
                comboBox3.ValueMember = "Class_ID";
                comboBox3.DisplayMember = "ywsm";
                comboBox3.MaxDropDownItems = 8;
                comboBox3.IntegralHeight = false;

                DBconnect dbconn4 = new DBconnect();
                string sql14 = "select GENDERE from GENDER";
                SqlDataAdapter adapter14 = new SqlDataAdapter(sql14, dbconn4.connection);
                adapter14.Fill(dsc4, "倉庫");                
                cbGENDER.DataSource = dsc4.Tables[0];
                cbGENDER.ValueMember = "GENDERE";
                cbGENDER.DisplayMember = "GENDERE";
                cbGENDER.MaxDropDownItems = 8;
                cbGENDER.IntegralHeight = false;

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //ChangeLabel();
                //ChangeDataView();
                //ChangeTabControl();
            }
            catch (Exception) { }

        }

        #endregion

        #region 事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                CFXTZLQuery Form = new CFXTZLQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Visible = true;
                sAll = Form.sqlAll;
            }
            catch (Exception)
            { }
        }


        private void tsbInsert_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == P0002)
            {
                //XieLoad();
                textBox1.Enabled = true;
                button1.Enabled = true;
                TBedit();
                textBox1.Text = "";
                tb1.Text = "";
                TBClear();
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                cbGENDER.Enabled = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadText();
                //tb1.Text = dataGridView1.CurrentRow.Cells[35].Value.ToString();
                tbVER.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[31].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[33].Value.ToString();
                comboBox3.SelectedValue = dataGridView1.CurrentRow.Cells[32].Value.ToString();

                tb6.Text = dataGridView1.CurrentRow.Cells[34].Value.ToString();

                LoadData2();
                xie = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                she = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string gen = "";
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select GENDERE from GENDER where GENDER_id = '{0}'", tb6.Text);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    gen = reader3["GENDERE"].ToString();
                }
                cbGENDER.Text = gen;
                dbConn3.CloseConnection();

            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb2.Text != "")
                {
                    CFXTZLBOM Form = new CFXTZLBOM();
                    Form.xiexing = textBox1.Text;
                    Form.shesho = tb1.Text;
                    Form.ShowDialog();
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tabControl1.SelectedTab = P0003;

                    if (Form.dataGridView1.Rows.Count != 0)
                    {
                        //XXZL
                        InsertXXZL();

                        //KFXXZL
                        UpdateKfxxzl();

                        TBClose();

                        //讀取檔案
                        ds1 = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select b.VER, b.xh,  b.BWBH , c.ywsm, case when b.BWLB = '1' then '一般'  when b.BWLB = '2' then '外包裝'  when b.BWLB = '3' then '特殊' end as bwlb, b.CLBH, e.ywpm, e.zwpm, e.dwbh,case when b.CLTX = 2 then 'Y' else 'N' END as 尺寸, b.CSBH, b.LOSS, b.CLSL, case when b.CLTX = 1 then 'One On One'  when b.CLTX = 2 then '分號'  when b.CLTX = 3 then 'No Size' end as CLTX , b.CCQQ, b.CCQZ, b.USERID, b.USERDATE from(select max(VER) as VER,XieXing,SheHao, xh,BWBH,BWLB,CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE from xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = 1 group by  XieXing,SheHao,xh, BWBH,BWLB, CLBH,CSBH, LOSS, CLSL, CLTX, CCQQ, CCQZ, USERID, USERDATE ) as b  left join  bwzl as c on b.BWBH = c.bwdh left join clzl as e on b.CLBH = e.cldh where b.XieXing = '{0}' and b.SheHao = '{1}' order by b.xh", textBox1.Text, tb1.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds1, "棧板表");

                        dgvBOM.DataSource = ds1.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    else
                    {
                        MessageBox.Show("查無自動BOM");
                    }
                }
                else 
                {
                    MessageBox.Show("缺少標準尺寸");
                }

            }
            catch (Exception) { }
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Enabled == true)
                {
                    CFXTXieXing Form = new CFXTXieXing();
                    Form.ShowDialog();
                    //textBox1.Text = Form.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox1.Enabled = false;
                    tb1.Enabled = false;

                    dsI = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from kfxxzl where XieXing= '{0}' and SheHao = '{1}'", Form.xie, Form.she);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsI, "棧板表");
                    Console.WriteLine(sql);
                    dataGridView6.DataSource = dsI.Tables[0];

                    #region TEXT

                    textBox1.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
                    tb1.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
                    //tb1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    tb4.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString();
                    tb5.Text = dataGridView6.CurrentRow.Cells[4].Value.ToString();
                    tb7.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();
                    tb8.Text = dataGridView6.CurrentRow.Cells[6].Value.ToString();
                    tb11.Text = dataGridView6.CurrentRow.Cells[7].Value.ToString();
                    //tb2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    tb12.Text = dataGridView6.CurrentRow.Cells[8].Value.ToString();
                    tb10.Text = dataGridView6.CurrentRow.Cells[9].Value.ToString();
                    tb3.Text = dataGridView6.CurrentRow.Cells[10].Value.ToString();
                    tb16.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
                    tb15.Text = dataGridView6.CurrentRow.Cells[11].Value.ToString();
                    tb28.Text = dataGridView6.CurrentRow.Cells[12].Value.ToString();
                    tb29.Text = dataGridView6.CurrentRow.Cells[13].Value.ToString();
                    tb30.Text = dataGridView6.CurrentRow.Cells[14].Value.ToString();
                    tb31.Text = dataGridView6.CurrentRow.Cells[15].Value.ToString();
                    tb32.Text = dataGridView6.CurrentRow.Cells[16].Value.ToString();
                    tb33.Text = dataGridView6.CurrentRow.Cells[17].Value.ToString();
                    tb34.Text = dataGridView6.CurrentRow.Cells[18].Value.ToString();
                    tb35.Text = dataGridView6.CurrentRow.Cells[19].Value.ToString();
                    tb27.Text = dataGridView6.CurrentRow.Cells[20].Value.ToString();

                    tb14.Text = dataGridView6.CurrentRow.Cells[21].Value.ToString();
                    tb18.Text = dataGridView6.CurrentRow.Cells[22].Value.ToString();
                    //tb22.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
                    //tb19.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
                    //tb21.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
                    //tb20.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();
                    tb6.Text = dataGridView6.CurrentRow.Cells[25].Value.ToString();
                    tbVER.Text = "1";

                    string gen = "";
                    DBconnect dbConn3 = new DBconnect(); 
                    string sql3 = string.Format("select GENDERE from GENDER where GENDER_id = '{0}'", tb6.Text);
                    SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                    dbConn3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.Read())
                    {
                        gen = reader3["GENDERE"].ToString();
                    }
                    cbGENDER.Text = gen;
                    dbConn3.CloseConnection();

                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;

                    #endregion

                    Searchdata();

                    xie = textBox1.Text;
                    she = tb1.Text;
                    cbGENDER.Enabled = true;

                    textBox2.Text = textBox1.Text;
                    textBox3.Text = tb1.Text;
                    textBox4.Text = tb2.Text;
                    textBox5.Text = tb4.Text;
                }
                else
                {

                }
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0002)
                {
                    if (confirmsave == 0) //新增
                    {
                        if (tb2.Text != "")
                        {
                            if (copy == false)
                            {
                                //XXZL
                                InsertXXZL();

                                //KFXXZL
                                UpdateKfxxzl();

                                TBClose();
                                TSBback();

                                cbGENDER.Enabled = false;
                            }
                            else if (copy == true) //拷貝修改
                            {
                                CopyUpdate();
                                copy = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("缺少標準尺寸");
                        }
                    }
                    else if (confirmsave == 1) //修改
                    {
                        #region NEWERP

                        Console.WriteLine(tb2.Text);
                        Console.WriteLine(tb3.Text);
                        Console.WriteLine(tb4.Text);
                        Console.WriteLine(tb5.Text);
                        Console.WriteLine(tb7.Text);
                        Console.WriteLine(tb8.Text);
                        Console.WriteLine(tb10.Text);
                        Console.WriteLine(tb11.Text);
                        Console.WriteLine(tb12.Text);
                        Console.WriteLine(tb15.Text);
                        Console.WriteLine(tb16.Text);
                        //Console.WriteLine(comboBox1.SelectedValue);
                        //Console.WriteLine(comboBox2.SelectedValue);
                        //Console.WriteLine(comboBox3.SelectedValue);
                        Console.WriteLine(tb22.Text);
                        Console.WriteLine(textBox1.Text);
                        Console.WriteLine(tb1.Text);
                        Console.WriteLine(tbVER.Text);


                        //update XXZL
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update xxzl set BZCC = '{0}', LOGO = '{1}',XieMing = '{2}', YSSM = '{3}', JiJie = '{4}', CLID = '{5}', KFCQ = '{6}', ARTICLE = '{7}',XieGN = '{8}', CCGB = '{9}', KHDH = '{10}',KFXXCZ1 = '{11}', KFXXCZ3 = '{12}', KFXXCZ2 = '{13}', KFXXCZ = '{14}', USERID = '{15}', USERDATE = GETDATE() where XieXing = '{16}' and SheHao = '{17}' and VER = '{18}'", tb2.Text != "" ? tb2.Text : null, tb3.Text != "" ? tb3.Text : null, tb4.Text != "" ? tb4.Text : null, tb5.Text != "" ? tb5.Text : null, tb7.Text != "" ? tb7.Text : null, tb8.Text != "" ? tb8.Text : null, tb10.Text != "" ? tb10.Text : null, tb11.Text != "" ? tb11.Text : null, tb12.Text != "" ? tb12.Text : null, tb15.Text != "" ? tb15.Text : null, tb16.Text != "" ? tb16.Text : null, null, null, null, tb22.Text != "" ? tb22.Text : null, userid, textBox1.Text != "" ? textBox1.Text : null, tb1.Text != "" ? tb1.Text : null, tbVER.Text != "" ? tbVER.Text : null);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update xxzl set BZCC = '{0}', LOGO = '{1}',XieMing = '{2}', YSSM = '{3}', JiJie = '{4}', CLID = '{5}', KFCQ = '{6}', ARTICLE = '{7}',XieGN = '{8}', CCGB = '{9}', KHDH = '{10}',KFXXCZ1 = '{11}', KFXXCZ3 = '{12}', KFXXCZ2 = '{13}', KFXXCZ = '{14}', USERID = '{15}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{16}' and SheHao = '{17}'", tb2.Text, tb3.Text, tb4.Text, tb5.Text, tb7.Text, tb8.Text, tb10.Text, tb11.Text, tb12.Text, tb15.Text, tb16.Text, null, null, null, tb22.Text, userid, textBox1.Text, tb1.Text);
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

                        #region OLD

                        //int a = 0;
                        //a = int.Parse(tbVER.Text);
                        //a += 1;

                        //舊版本
                        //DBconnect con4 = new DBconnect();
                        //StringBuilder sql4 = new StringBuilder();
                        //sql4.AppendFormat("update xxzl set YN = 0,USERID = '{0}', USERDATE = GETDATE() where XieXing = '{1}' and SheHao = '{2}'", userid, textBox1.Text, tb1.Text);
                        //Console.WriteLine(sql4);
                        //SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        //con4.OpenConnection();
                        //int result4 = cmd4.ExecuteNonQuery();
                        //if (result4 == 1)
                        //{
                        //    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        ////新版本
                        //int result;
                        //DBconnect conn = new DBconnect();
                        //string sql1 = string.Format("insert into xxzl (XieXing, SheHao, VER, XieMing, YSSM, JiJie, CLID, ARTICLE, BZCC, XieGN, KFCQ, LOGO, KHDH, CCGB, XTGJ, XTMH, DMGJ, DDMH, MSGJ, MDMH, DAOGJ, DAOMH, IMGName, GENDER, USERID, USERDATE, KFXXCZ1, KFXXCZ2, KFXXCZ3, QPrice, OPrice, IPrice, CPrice, YN ) values ('{0}', '{1}', '{27}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}','{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}','{19}', '{20}', '{21}', '{22}', '{23}', GETDATE(), '{24}', '{25}', '{26}', '0', '0', '0', '0', '1')", textBox1.Text, tb1.Text, tb4.Text, tb5.Text, tb7.Text, tb8.Text, tb11.Text, tb2.Text, tb12.Text, tb10.Text, tb3.Text, tb16.Text, tb15.Text, tb28.Text, tb29.Text, tb30.Text, tb31.Text, tb32.Text, tb33.Text, tb34.Text, tb35.Text, tb27.Text, tb6.Text, userid, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), a.ToString());
                        //Console.WriteLine(sql1);
                        ////, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        //SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        //conn.OpenConnection();
                        //result = cmd1.ExecuteNonQuery();
                        //if (result == 1)
                        //{
                        //    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        #endregion

                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                    }
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    savexxzls();
                    dgvBOM.ReadOnly = true;
                    MessageBox.Show("Success");
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    for (int i = 0; i < dgvBOM.Rows.Count; i ++)
                    {
                        int a = int.Parse(dgvBOM.Rows[i].Cells[0].Value.ToString()) + 1;
                        dgvBOM.Rows[i].Cells[0].Value = a;
                    }
                }
                else if (tabControl1.SelectedTab == P0006)
                {
                    
                }
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0002)
                {
                    if (copy == false)
                    {
                        TBClose();
                        TSBback();
                        textBox1.Enabled = false;
                    }
                    else if (copy == true) //刪除 
                    {
                        DeleteCopy();
                        copy = false;
                    }
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    LoadData2();
                    dgvBOM.ReadOnly = true;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                }
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == P0002)
            {
                DeleteXXZL();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            LoadText();
            tsbPrior.Enabled = false;
            tsbNext.Enabled = true;
        }

        private void tsbPrior_Click(object sender, EventArgs e)
        {
            int indexData;

            if (index == 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            }
            else
            {
                indexData = index - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];
                LoadText();
            }
            tsbNext.Enabled = true;

        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            int indexData;

            if (index == dataGridView1.RowCount - 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            }
            else
            {
                indexData = index + 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];
                LoadText();
            }
            tsbPrior.Enabled = true;
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            LoadText();
            tsbNext.Enabled = false;
            tsbPrior.Enabled = true;
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == P0002)
            {
                string confirm = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(XieXing) as count from xxzl where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and YN = '2'", textBox1.Text, tb1.Text, tbVER.Text);

                Console.WriteLine(sql2);

                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    confirm = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();

                if (confirm != "0")
                {
                    CFXTZLCopy Form = new CFXTZLCopy();
                    Form.FXie = textBox1.Text;
                    Form.FShe = tb1.Text;
                    Form.ShowDialog();
                    textBox1.Text = Form.Xiexing;
                    tb1.Text = Form.shesho;

                    TBedit();

                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    copy = true;
                }
                else 
                {
                    MessageBox.Show("請先確認");
                }

            }
        }

        private void tsbsize_Click(object sender, EventArgs e)
        {
            if (cbGENDER.Text != "")
            {
                if (tb15.Text != "")
                {
                    CFXTZLSize Form = new CFXTZLSize();
                    Form.Xie = textBox1.Text;
                    Form.She = tb1.Text;
                    Form.gjlb1 = tb28.Text;
                    Form.gjlb2 = tb30.Text;
                    Form.gjlb3 = tb32.Text;
                    Form.gjlb4 = tb34.Text;
                    Form.cssize = tb15.Text;
                    Form.gender = tb6.Text;
                    Form.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("國別不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("性別不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MMI Form = new MMI();
            Form.ShowDialog();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = dgvBOM.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dgvBOM.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tsbModify.Enabled == false)
                {
                    if (dgvBOM.CurrentCell.ColumnIndex == 1)
                    {
                        CFXTZLBWBH Form = new CFXTZLBWBH();
                        Form.ShowDialog();
                        if (Form.bwbh != "" && Form.ywsm != "")
                        {
                            dgvBOM.CurrentRow.Cells[2].Value = Form.bwbh;
                            dgvBOM.CurrentRow.Cells[3].Value = Form.ywsm;
                        }

                    }
                    else if (dgvBOM.CurrentCell.ColumnIndex == 2)
                    {
                        CFXTZLBWBH Form = new CFXTZLBWBH();
                        Form.ShowDialog();
                        if (Form.bwbh != "" && Form.ywsm != "")
                        {
                            dgvBOM.CurrentRow.Cells[2].Value = Form.bwbh;
                            dgvBOM.CurrentRow.Cells[3].Value = Form.ywsm;
                        }
                    }
                    else if (dgvBOM.CurrentCell.ColumnIndex == 4)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();

                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dgvBOM.CurrentRow.Cells[5].Value = Form.cldh;
                            dgvBOM.CurrentRow.Cells[6].Value = Form.ywsm;
                            dgvBOM.CurrentRow.Cells[7].Value = Form.zwsm;
                        }

                    }
                    else if (dgvBOM.CurrentCell.ColumnIndex == 5)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();
                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dgvBOM.CurrentRow.Cells[5].Value = Form.cldh;
                            dgvBOM.CurrentRow.Cells[6].Value = Form.ywsm;
                            dgvBOM.CurrentRow.Cells[7].Value = Form.zwsm;
                        }
                    }
                    else if (dgvBOM.CurrentCell.ColumnIndex == 6)
                    {
                        CFXTZLCLBH Form = new CFXTZLCLBH();
                        Form.ShowDialog();
                        if (Form.cldh != "" && Form.ywsm != "")
                        {
                            dgvBOM.CurrentRow.Cells[5].Value = Form.cldh;
                            dgvBOM.CurrentRow.Cells[6].Value = Form.ywsm;
                            dgvBOM.CurrentRow.Cells[7].Value = Form.zwsm;
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Modify First", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataAVG();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("請先選擇鞋型");
                }
                else 
                {
                    CFXTZLSPBOM Form = new CFXTZLSPBOM();
                    Form.textBox1.Text = textBox2.Text;
                    Form.textBox2.Text = textBox3.Text;
                    Form.textBox3.Text = textBox4.Text;
                    Form.ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                    if (tabControl1.SelectedTab == P0001)
                    {
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = false;
                        tsbSize.Enabled = false;
                        tsbM.Enabled = false;
                        tsbFirst.Enabled = true;
                        tsbNext.Enabled = true;
                        tsbPrior.Enabled = true;
                        tsbLast.Enabled = true;
                        tsbConfirm.Enabled = false;
                        cbGENDER.Enabled = false;

                        ds1 = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = sAll;
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds1, "棧板表");

                        dataGridView1.DataSource = ds1.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    else if (tabControl1.SelectedTab == P0002)
                    {
                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = true;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = true;
                        tsbSize.Enabled = true;
                        tsbM.Enabled = false;
                        tsbFirst.Enabled = true;
                        tsbNext.Enabled = true;
                        tsbPrior.Enabled = true;
                        tsbLast.Enabled = true;
                        tsbConfirm.Enabled = false;
                        cbGENDER.Enabled = false;
                        TBClose();
                    }
                    else if (tabControl1.SelectedTab == P0003)
                    {
                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = false;
                        tsbSize.Enabled = false;
                        tsbM.Enabled = true;
                        tsbFirst.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbPrior.Enabled = false;
                        tsbLast.Enabled = false;
                        tsbConfirm.Enabled = true;
                        cbGENDER.Enabled = false;

                        //if (tbVER.Text == "0") 
                        //{
                        //    tsbConfirm.Enabled = true;
                        //}
                    }
                    else if (tabControl1.SelectedTab == P0004)
                    {
                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = false;
                        tsbSize.Enabled = false;
                        tsbM.Enabled = false;
                        tsbFirst.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbPrior.Enabled = false;
                        tsbLast.Enabled = false;
                        tsbConfirm.Enabled = false;
                        cbGENDER.Enabled = false;

                        ds1 = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from xxzls left join Usage_R on xxzls.XieXing = Usage_R.XieXing and xxzls.SheHao = Usage_R.SheHao and xxzls.BWBH = Usage_R.BWBH where xxzls.XieXing = '{0}' and xxzls.SheHao = '{1}' and Usage_R.CLSL is null", textBox1.Text, tb1.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds1, "棧板表");

                        dataGridView3.DataSource = ds1.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    else if (tabControl1.SelectedTab == P0005)
                    {
                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = false;
                        tsbSize.Enabled = false;
                        tsbM.Enabled = false;
                        tsbFirst.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbPrior.Enabled = false;
                        tsbLast.Enabled = false;
                        tsbConfirm.Enabled = false;

                        ds1 = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from Usage_R where XieXing = '{0}' and SheHao = '{1}' and CLSL = 0", textBox1.Text, tb1.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds1, "棧板表");

                        dataGridView4.DataSource = ds1.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    else if (tabControl1.SelectedTab == P0006)
                    {
                        if (xie != "")
                        {
                        ds6 = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from xxzl where XieXing = '{0}' and SheHao = '{1}'", xie, she);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(ds6, "棧板表");
                        
                        dataGridView5.DataSource = ds6.Tables[0];
                        dbConn11.CloseConnection();

                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbDelete.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        tsbCopy.Enabled = false;
                        tsbSize.Enabled = false;
                        tsbM.Enabled = false;
                        tsbFirst.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbPrior.Enabled = false;
                        tsbLast.Enabled = false;
                        tsbConfirm.Enabled = false;

                        tb5_1.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                        tb5_2.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
                        tb5_3.Text = dataGridView5.CurrentRow.Cells[7].Value.ToString();
                        tb5_4.Text = dataGridView5.CurrentRow.Cells[23].Value.ToString();
                        tb5_5.Text = dataGridView5.CurrentRow.Cells[24].Value.ToString();
                        tb5_6.Text = dataGridView5.CurrentRow.Cells[25].Value.ToString();
                        tb5_7.Text = dataGridView5.CurrentRow.Cells[27].Value.ToString();
                        tb5_8.Text = dataGridView5.CurrentRow.Cells[26].Value.ToString();
                        tb5_9.Text = dataGridView5.CurrentRow.Cells[12].Value.ToString();
                        tb5_10.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
                        tb5_11.Text = dataGridView5.CurrentRow.Cells[38].Value.ToString();
                        tb5_12.Text = dataGridView5.CurrentRow.Cells[39].Value.ToString();
                        tb5_13.Text = dataGridView5.CurrentRow.Cells[36].Value.ToString();

                        }
                        else 
                        {
                            MessageBox.Show("請先選鞋型");
                            tabControl1.SelectedTab = P0001;
                        }
                    }

            }
            catch (Exception) { }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb5_1.Text != "" || tb5_2.Text != "" || tb15.Text != "" || tb6.Text != "")
                {
                    CFXTZLSepPrice Form = new CFXTZLSepPrice();
                    Form.tb1.Text = tb5_1.Text;
                    Form.tb2.Text = tb5_2.Text;
                    Form.country = dataGridView5.CurrentRow.Cells[23].Value.ToString(); ;
                    Form.gender = dataGridView5.CurrentRow.Cells[34].Value.ToString(); ;
                    Form.ShowDialog();
                    tb5_6.Text = Form.sum1;
                    tb5_7.Text = Form.sum2;
                    tb5_8.Text = Form.sum3;

                    #region NEWERP

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update xxzl set OPrice = '{0}', CPrice = '{1}', IPrice = '{2}', USERID = '{3}', USERDATE = GETDATE() where XieXing = '{4}' and SheHao = '{5}'", tb5_6.Text, tb5_7.Text, tb5_8.Text, userid, tb5_1.Text, tb5_2.Text);
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
                    sql4Y.AppendFormat("update xxzl set OPrice = '{0}', CPrice = '{1}', IPrice = '{2}', USERID = '{3}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{4}' and SheHao = '{5}'", tb5_6.Text, tb5_7.Text, tb5_8.Text, userid, tb5_1.Text, tb5_2.Text);
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
                else
                {
                    MessageBox.Show("資料為空");
                }
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                string confirm = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(XieXing) as count from xxzl where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and YN = '2'", textBox1.Text, tb1.Text, tbVER.Text);

                Console.WriteLine(sql2);

                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    confirm = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();

                if (tabControl1.SelectedTab == P0002)
                {
                    if (confirm == "0")
                    {
                        TBedit();
                        textBox1.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = true;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                    }
                    else 
                    {
                        tb4.Enabled = true;
                        tb11.Enabled = true;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                        confirmsave = 1;
                    }
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    if (confirm == "0")
                    {
                        dgvBOM.ReadOnly = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("已經確認");
                    }
                }
            }
            catch (Exception) { }
        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0003)
                {

                    DialogResult dr = MessageBox.Show("是否確認?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        #region OLD
                        ////更改狀態
                        //DBconnect con = new DBconnect();
                        //StringBuilder sql = new StringBuilder();
                        //sql.AppendFormat("update xxzls set  USERID = '{0}',USERDATE = GETDATE(), xh = '{1}',BWBH = '{2}',BWLB = '{3}',CLBH = '{4}',CSBH = '{5}', LOSS = '{6}' ,CLSL = '{7}',CLTX = '{8}',CCQQ = '{9}', CCQZ = '{10}', VER = VER+1  where XieXing = '{11}' and SheHao = '{12}' and VER = '{13}' and CLBH = '{14}' and YN = 1", userid, dgvBOM.Rows[i].Cells[1].Value.ToString(), dgvBOM.Rows[i].Cells[2].Value.ToString(), d34, dgvBOM.Rows[i].Cells[5].Value.ToString(), dgvBOM.Rows[i].Cells[10].Value.ToString(), dgvBOM.Rows[i].Cells[11].Value.ToString(), dgvBOM.Rows[i].Cells[12].Value.ToString(), d313, dgvBOM.Rows[i].Cells[14].Value.ToString(), dgvBOM.Rows[i].Cells[15].Value.ToString(), textBox2.Text, textBox3.Text, dgvBOM.Rows[i].Cells[0].Value.ToString(), dgvBOM.Rows[i].Cells[5].Value.ToString());
                        //Console.WriteLine(sql4);
                        //SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                        //con.OpenConnection();
                        //int result = cmd.ExecuteNonQuery();
                        //if (result == 1)
                        //{

                        //}
                        //con.CloseConnection();
                        #endregion                        

                        //檢查是否更改
                        string confirm = "";
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select count(XieXing) as count from xxzl where XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and YN = '2'", textBox2.Text, textBox3.Text, tbVER.Text);

                        Console.WriteLine(sql2);

                        SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                        dbConn2.OpenConnection();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            confirm = reader2["count"].ToString();
                        }
                        dbConn2.CloseConnection();

                        if (confirm == "1")
                        {
                            MessageBox.Show("已確認");
                        }
                        else
                        {
                            #region NEWERP

                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update xxzl set YN = '2',USERID = '{0}', USERDATE = GETDATE(), VER = '1' where XieXing = '{1}' and SheHao = '{2}' and VER = '{3}' ", userid, textBox1.Text, tb1.Text, tbVER.Text);
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
                            sql4Y.AppendFormat("update xxzl set USERID = '{0}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{1}' and SheHao = '{2}'", userid, textBox1.Text, tb1.Text, tbVER.Text);
                            Console.WriteLine(sql4Y);
                            SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                            con4Y.OpenConnection();
                            int result4Y = cmd4Y.ExecuteNonQuery();
                            if (result4Y == 1)
                            {

                            }
                            con4Y.CloseConnection();

                            #endregion


                            //modifyxxzls
                            DBconnect con = new DBconnect();
                            StringBuilder sql = new StringBuilder();
                            sql.AppendFormat("update xxzls set VER = '1' where XieXing = '{0}' and SheHao = '{1}'", textBox2.Text, textBox3.Text);
                            Console.WriteLine(sql);
                            SqlCommand cmd = new SqlCommand(sql.ToString(), con.connection);

                            con.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            con.CloseConnection();
                        }
                        tsbConfirm.Enabled = false;
                    }
                    
                }
            }
            catch (Exception) { }
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("report", dataGridView1);
        }

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                         //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                         //   {  
                                                         //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                         //      rg.NumberFormat = "00000000";  
                                                         //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("导出文件成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("报表为空,无表格需要导出", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
    }
}

