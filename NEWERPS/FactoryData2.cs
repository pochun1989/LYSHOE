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
    public partial class FactoryData2 : Form
    {
        #region 建構函式

        public FactoryData2()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        int index = 0;
        string rowno = "";
        public string userid = "";
        public string sl = ""; //1 insert //2 modify
        Boolean checkcq = true;
        DataSet ds2 = new DataSet();


        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "Factory Inf.";

        #endregion

        #region 畫面載入
        private void FactoryData2_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                //LoadText();
                LoadOBU();

                //更改語言
                ChangeLabel();
                ChangeDataView();
                ChangePanel();


            }
            catch (Exception) { }
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

            dsL = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsL, "棧板表");
            this.dgvWord.DataSource = this.dsL.Tables[0];

            WordPosition();
        }

        #endregion

        #region 切換 TB

        private void ChangePanel()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            dsL = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'P%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsL, "棧板表");
            this.dgvWord.DataSource = this.dsL.Tables[0];

            Wtabcontrol();
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
                int x;
                x = dgvWord.RowCount;
                for (int i = 0; i <= x  ; i++) 
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
                //L0020.Text = dgvWord.Rows[18].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #region tabcontrol定位

        private void Wtabcontrol() 
        {
            if (dgvWord.Rows[0].Cells[3].Value.ToString() != "") 
            {
                tabPage1.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
            }
            if (dgvWord.Rows[1].Cells[3].Value.ToString() != "") 
            {
                tabPage2.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }            
        }

        #endregion

        #endregion

        #region 載入文字方法

        private void LoadText()
        {
            try
            {
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb廠址.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb區域.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb傳真.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tb電話.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tbCompany.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tb公司名.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #region 清空方法

        private void Clean()
        {
            tb代號.Text = "";
            tb區域.Text = "";
            tb電話.Text = "";
            tb傳真.Text = "";
            tb公司名.Text = "";
            tb廠址.Text = "";
            tbCompany.Text = "";
            tbAddress.Text = "";
            tb代號.Enabled = true;
            panel1.Visible = false;
        }

        #endregion

        #region 開啟編輯

        private void UseText()
        {
            tb代號.Enabled = true;
            tb區域.Enabled = true;
            tb公司名.Enabled = true;
            tbCompany.Enabled = true;
            tb電話.Enabled = true;
            tb傳真.Enabled = true;
            tb廠址.Enabled = true;
            tbAddress.Enabled = true;
        }
        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from cqzl where cqdh = '{0}'", tb代號.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    checkcq = false;
                }


            }
            catch (Exception)
            { }
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into cqzl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',NULL,'0','{8}',GETDATE())", tb代號.Text, tb廠址.Text, tb區域.Text, tbAddress.Text, tb傳真.Text, tb電話.Text, tbCompany.Text, tb公司名.Text, userid);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 按鈕還原

        private void tsbBack()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbDelete.Enabled = true;
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;
            tsbPrint.Enabled = false;
            tsbOBU.Enabled = false;

            panel1.Visible = true;

            tb代號.Enabled = false;
            tb區域.Enabled = false;
            tb公司名.Enabled = false;
            tbCompany.Enabled = false;
            tb電話.Enabled = false;
            tb傳真.Enabled = false;
            tb廠址.Enabled = false;
            tbAddress.Enabled = false;
        }

        #endregion

        #region 刪除

        private void DeleteFactory()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update cqzl set YN = 1 where cqdh = '{0}'", tb代號.Text);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //CompanyDataLoading("1");
                LoadOBU();
            }
            else
            {
                MessageBox.Show("刪除資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 載入OBU

        private void LoadOBU()
        {
            try
            {
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select OBU from cqzl where OBU is not null and cqdh = '{0}'", tb代號.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //有資料
                {
                    LogData();
                    panel1.Visible = true;
                    Console.WriteLine("讀取");
                    //string zsdh;
                    //zsdh = reader.GetString(0);
                    //panel1.Controls.Clear(); // 清空工作表介面                                         
                    //OBUData al = new OBUData();
                    //al.gsdh = zsdh;
                    //al.TopLevel = false; // 在最上層
                    //al.FormBorderStyle = FormBorderStyle.None; // 清除邊框
                    //panel1.Controls.Add(al); // 工作表加視窗
                    //al.Width = panel1.Width;
                    //al.Height = panel1.Height;

                    ////al.WindowState = FormWindowState.Maximized;
                    //al.Show(); // 視窗顯示
                }
                else
                {
                    panel1.Visible = false;
                }


            }
            catch (Exception)
            {
                //MessageBox.Show("載入OBU資料錯誤", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region OBU2

        private void LogData()
        {
            string OBU = "";
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select OBU from cqzl where cqdh = '{0}'", tb代號.Text);
            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
            dbConn.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) //有資料
            {
                OBU = reader.GetString(0);
            }

            DBconnect conn = new DBconnect();
            string sqln = string.Format("select * from gszl where gsdh = '{0}'", OBU);

            Console.WriteLine(sqln);


            SqlCommand cmdn = new SqlCommand(sqln, conn.connection);
            SqlDataAdapter sdan = new SqlDataAdapter(cmdn);
            DataTable dtn = new DataTable();
            sdan.Fill(dtn);
            conn.OpenConnection();

            tb廠代.Text = dtn.Rows[0]["gsdh"].ToString().Trim();
            tbOBU名.Text = dtn.Rows[0]["gszwqm"].ToString().Trim();
            tbOBU.Text = dtn.Rows[0]["gsywqm"].ToString().Trim();
            tb地址.Text = dtn.Rows[0]["gszwdz"].ToString().Trim();
            tbAddress.Text = dtn.Rows[0]["gsywdz"].ToString().Trim();
            tb統編.Text = dtn.Rows[0]["tybh"].ToString().Trim();
            tb電話.Text = dtn.Rows[0]["dh"].ToString().Trim();
            tb傳真.Text = dtn.Rows[0]["cz"].ToString().Trim();
            tb採購地址.Text = dtn.Rows[0]["gsywdz"].ToString().Trim();
            tb採購電話.Text = dtn.Rows[0]["dh"].ToString().Trim();

            panel1.Visible = true;
        }

        #endregion

        #endregion

        #region 修改方法

        private void ModifyFactory()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update cqzl set cqlocate = '{0}', gszwqm = '{1}', gsywqm = '{2}', dh = '{3}', cz = '{4}',cqdz = '{5}', cqywdz = '{6}'  where cqdh = '{7}'", tb區域.Text, tb公司名.Text, tbCompany.Text, tb電話.Text, tb傳真.Text, tb廠址.Text, tbAddress.Text, tb代號.Text);

            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con4.CloseConnection();
        }

        #endregion

        #region 修改OBU

        private void ModifyOBU()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update cqzl set OBU  = '{0}',USERID = '{1}' where cqdh = '{2}'", tb廠代.Text, userid, tb代號.Text);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("修改OBU資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
        }

        #endregion

        #endregion

        #region 事件



        private void TsbClear_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void TsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FactoryQuery al = new FactoryQuery();
                al.TopLevel = false; // 在最上層
                                     //al.obucode = tb代號.Text;
                al.TopLevel = true; // 在最上層
                                    //al.ShowDialog(); // 視窗顯示

                DialogResult R = al.ShowDialog();

                if (R == DialogResult.OK)
                {

                }
                dataGridView1.DataSource = al.ds.Tables[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[al.index].Cells[0];
                LoadText();
                dataGridView1.Visible = true;
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
                    DeleteFactory();
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
                tb區域.Enabled = true;
                tb公司名.Enabled = true;
                tbCompany.Enabled = true;
                tb電話.Enabled = true;
                tb傳真.Enabled = true;
                tb廠址.Enabled = true;
                tbAddress.Enabled = true;
                tsbOBU.Enabled = true;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbPrior.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false;
                sl = "2";
                dataGridView1.Visible = true;

            }
            catch (Exception)
            {

            }
        }

        private void TsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (tb代號.Text != "")
                {
                    if (sl == "1") //insert
                    {
                        CheckID();
                        if (checkcq == false)
                        {
                            Console.WriteLine(checkcq);
                            MessageBox.Show("代號重複 請重新輸入", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clean();
                        }
                        else
                        {
                            Console.WriteLine(checkcq);
                            InsertData();
                            sl = "";
                            tsbBack();
                        }

                    }
                    else if (sl == "2") //midify
                    {
                        ModifyFactory();
                        sl = "";
                        tsbBack();
                    }

                    if (checkcq == false)
                    {

                    }
                    else
                    {
                        if (panel1.Visible == false)
                        {

                        }
                        else //修改OBU
                        {
                            ModifyOBU();
                        }
                    }
                    checkcq = true;


                }
                else
                {
                }
            }
            catch (Exception) { }
        }

        private void TsbInsert_Click(object sender, EventArgs e)
        {
            Clean();
            UseText();
            tsbClear.Enabled = true;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            tsbFirst.Enabled = false;
            tsbPrior.Enabled = false;
            tsbNext.Enabled = false;
            tsbLast.Enabled = false;
            tsbOBU.Enabled = true;
            tsbInsert.Enabled = true;
            tsbCancel.Enabled = true;
            tsbSave.Enabled = true;
            tsbInsert.Enabled = false;
            sl = "1";
            dataGridView1.Visible = true;

        }

        private void TsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                tsbBack();
                sl = "";
                dataGridView1.DataSource = cqzlBindingSource;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
                LoadOBU();
            }
            catch (Exception) { }
        }

        private void TsbFirst_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            LoadText();
            LoadOBU();

        }

        private void TsbPrior_Click(object sender, EventArgs e)
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
                LoadOBU();
            }

        }

        private void TsbNext_Click(object sender, EventArgs e)
        {
            //cqzlBindingSource.MoveNext();
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
                LoadOBU();
            }
        }

        private void TsbLast_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            LoadText();
            LoadOBU();
        }

        private void TsbOBU_Click(object sender, EventArgs e)
        {
            OBUSelect al = new OBUSelect();
            al.TopLevel = false; // 在最上層
            al.obucode = tb代號.Text;
            al.TopLevel = true; // 在最上層
            //al.ShowDialog(); // 視窗顯示

            DialogResult R = al.ShowDialog();

            if (R == DialogResult.OK)
            {

            }

            tb廠代.Text = al.廠代;
            tbOBU名.Text = al.OBU名;
            tbOBU.Text = al.OBU;
            tb地址.Text = al.地址;
            tbOBU址.Text = al.OBU址;
            tb統編.Text = al.統編;
            tbOBU電話.Text = al.OBU電話;
            tbOBU傳真.Text = al.OBU傳真;
            tb採購地址.Text = al.採購地址;
            tb採購電話.Text = al.採購電話;

            panel1.Visible = true;
        }

        #endregion



        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            FactoryRecover Form = new FactoryRecover();
            Form.Show();
        }

        private void FactoryData2_Shown(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadText();
            }
            catch (Exception) { }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tsbBankInfo_Click(object sender, EventArgs e)
        {
            BI al = new BI();
            al.TopLevel = false; // 在最上層
            al.TopLevel = true; // 在最上層
            al.tbCompanyNo.Text = tb代號.Text;
            al.ShowDialog(); // 視窗顯示
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
