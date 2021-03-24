using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NEWERPS
{
    public partial class TempMaterial : Form
    {
        #region 建構函式

        public TempMaterial()
        {
            InitializeComponent();
        }

        #endregion


        #region 變數
        DataSet ds = new DataSet();

        int index = 0;
        public string userid = "";
        public string languageType;
        string max;
        string strRight;
        string insertID;
        int right;

        public DataSet dsl = new DataSet();
        public DataSet ds2 = new DataSet();
        public string userLanguage;
        string userForm = "";

        #endregion

        #region 畫面載入

        private void TempMaterial_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;

            ClassB();
            ClassZ();
        }

        #endregion

        #region 方法

        #region Class載入

        private void ClassB()
        {
            try
            {
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from CLASS_B";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.cbClass.DataSource = ds.Tables[0];
                this.cbClass.ValueMember = "ywsm";
                this.cbClass.DisplayMember = "cllb";

                cbClass.MaxDropDownItems = 8;
                cbClass.IntegralHeight = false;


            }
            catch (Exception) { }
        }

        #endregion

        #region 廠商載入

        private void ClassZ()
        {
            try
            {
                ds2 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from zszl order by zsywjc";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds2, "倉庫位置");
                this.comboBox1.DataSource = ds2.Tables[0];
                this.comboBox1.ValueMember = "zsdh";
                this.comboBox1.DisplayMember = "zsywjc";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;


            }
            catch (Exception) { }
        }

        #endregion

        #region 復原按鍵

        private void RecoverBtn()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;
            tsbPrint.Enabled = false;
            tsbConfirm.Enabled = false;

            cbClass.Enabled = false;
            tbMC.Enabled = false;
            tbME.Enabled = false;
            comboBox1.Enabled = false;

        }

        #endregion

        #region 取出最大流水號

        private void maxID()
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select isnull(max(tempddbh), 'XXXX000000') as tempddbh  from clzltemp where cllb ='{0}'", cbClass.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    max = reader2["tempddbh"].ToString();
                }

                Console.WriteLine(max);

                strRight = max.Substring(max.Length - 6, 6);

                right = int.Parse(strRight) + 1;

                strRight = right.ToString();


                Console.WriteLine(strRight);


            }
            catch (Exception) { }
        }

        #endregion

        #region 新增載入

        private void NewData()
        {
            int result;
            DBconnect conn = new DBconnect();
            string sql1 = string.Format("insert into clzltemp values('{0}','{1}','{2}','{3}', NULL,'{4}','{5}',GETDATE())", insertID, cbClass.Text, tbMC.Text, tbME.Text, comboBox1.SelectedValue.ToString(), userid);
            Console.WriteLine(sql1);

            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
            conn.OpenConnection();
            result = cmd1.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 新增資料

        private void insertData() 
        {
            try
            {                
                maxID();
                if (strRight.Length == 1)
                {
                    strRight = "00000" + right;
                }
                else if (strRight.Length == 2)
                {
                    strRight = "0000" + right;
                }
                else if (strRight.Length == 3)
                {
                    strRight = "000" + right;
                }
                else if (strRight.Length == 4)
                {
                    strRight = "00" + right;
                }
                else if (strRight.Length == 5)
                {
                    strRight = "0" + right;
                }
                else if (strRight.Length == 6)
                {

                }

                insertID = "T" + cbClass.Text + strRight;

                Console.WriteLine(insertID);

                NewData();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 事件

        #region 載入文字

        private void LoadText()
        {
            try
            {
                tbDDBH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbClass.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbMC.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbME.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }
        

        #endregion

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                TempQuery Form = new TempQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds2.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                //LoadText();
                dataGridView1.Visible = true;
            }
            catch (Exception) 
            {
                Console.WriteLine("ERROR");
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tbMC.Text = "";
            tbME.Text = "";
            cbClass.SelectedIndex = 0;

        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbPrior.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false;
                comboBox1.Enabled = true;
                cbClass.Enabled = true;
                tbMC.Enabled = true;
                tbME.Enabled = true;
                tabControl1.SelectedTab = tabPage2;

                tbMC.Text = "";
                tbME.Text = "";
                tbDDBH.Text = "";

                L0003.Visible = false;
            }
            else 
            {
                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbPrior.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false;
                comboBox1.Enabled = true;
                cbClass.Enabled = true;
                tbMC.Enabled = true;
                tbME.Enabled = true;
                //tabControl1.SelectedTab = tabPage2;

                tbMC.Text = "";
                tbME.Text = "";
                tbDDBH.Text = "";
                L0003.Visible = false;
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "1";
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            insertData();
            cbClass.Enabled = false;
            tbMC.Enabled = false;
            tbME.Enabled = false;
            RecoverBtn();
            Program.Modifytype.modify = "0";
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tbMC.Text = "";
            tbME.Text = "";
            cbClass.SelectedIndex = 0;
            RecoverBtn();
            Program.Modifytype.modify = "0";
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
                tsbPrior.Enabled = false;
                tsbNext.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbPrior_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception) { }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception) { }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                //CompanyDataLoading("select count(*) from zszl");
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                LoadText();
                tsbNext.Enabled = false;
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }

        #endregion

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                L0003.Visible = true;
                L0003.Text = cbClass.SelectedValue.ToString();
            }catch
            (Exception){ }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    OfficialMaterial Form = new OfficialMaterial();
                    Form.ShowDialog();
                    //dataGridView1.DataSource = Form.ds.Tables[0];
                    //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                    //LoadText();
                    dataGridView1.Visible = true;
                }
                catch (Exception) { }

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            LoadText();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void L0003_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tsbQuery.Enabled = true;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbFirst.Enabled = false;
                    tsbPrior.Enabled = false;
                    tsbNext.Enabled = false;
                    tsbLast.Enabled = false;

                    L0003.Visible = false;
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbFirst.Enabled = false;
                    tsbPrior.Enabled = false;
                    tsbNext.Enabled = false;
                    tsbLast.Enabled = false;
                    comboBox1.Enabled = false;
                    cbClass.Enabled = false;
                    tbMC.Enabled = false;
                    tbME.Enabled = false;

                    L0003.Visible = false;
                }
            }
            catch (Exception) { }
        }
    }
}
