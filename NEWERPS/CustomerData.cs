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
    public partial class CustomerData : Form
    {
        public CustomerData()
        {
            InitializeComponent();
        }
        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器    
        DataSet dsc2 = new DataSet(); // 儲存資料表容器 
        DataSet dsc3 = new DataSet(); // 儲存資料表容器 
        int index = 0;
        string sl = "";
        Boolean idcheck = true;
        public string userid = "";

        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "Customerdata";

        #endregion

        #region 畫面載入

        private void CustomerData_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();
            ChangeDataView();
            ChangeTabControl();

            DBconnect dbconn = new DBconnect();
            string sql1 = "select SIZE_ID,SIZE_Name from CSSize";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(dsc3, "倉庫");

            comboBox2.DataSource = dsc3.Tables[0];
            comboBox2.ValueMember = "SIZE_ID";
            comboBox2.DisplayMember = "SIZE_Name";
            comboBox2.MaxDropDownItems = 8;
            comboBox2.IntegralHeight = false;
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
                L0020.Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                L0021.Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                L0022.Text = dgvWord.Rows[25].Cells[3].Value.ToString();
                L0023.Text = dgvWord.Rows[26].Cells[3].Value.ToString();

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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 清空文字

        private void Clean() 
        {
            tb代號.Text = "";
            tb全稱.Text = "";
            tb簡稱.Text = "";
            tb編號.Text = "";
            tb電話.Text = "";
            tb傳真.Text = "";
            tb發票.Text = "";
            tb郵寄.Text = "";
            tb負責人.Text = "";
            tb負責人電話.Text = "";
            tb統編.Text = "";
            tb品別.Text = "";
            tb幣別.Text = "";
            //tb尺寸國別.Text = "";
            tb聯絡人1.Text = "";
            tb電話1.Text = "";
            tb聯絡人2.Text = "";
            tb電話2.Text = "";
            tb聯絡人3.Text = "";
            tb電話3.Text = "";
            tb聯絡人4.Text = "";
            tb電話4.Text = "";
            tb備註.Text = "";
        }

        #endregion

        #region 允許編輯

        private void Edit() 
        {
            //tb代號.Enabled = true;
            tb全稱.Enabled = true;
            tb簡稱.Enabled = true;
            tb編號.Enabled = true;
            tb電話.Enabled = true;
            tb傳真.Enabled = true;
            tb發票.Enabled = true;
            tb郵寄.Enabled = true;
            tb負責人.Enabled = true;
            tb負責人電話.Enabled = true;
            tb統編.Enabled = true;
            tb品別.Enabled = true;
            tb幣別.Enabled = true;
            comboBox2.Enabled = true;
            tb聯絡人1.Enabled = true;
            tb電話1.Enabled = true;
            tb聯絡人2.Enabled = true;
            tb電話2.Enabled = true;
            tb聯絡人3.Enabled = true;
            tb電話3.Enabled = true;
            tb聯絡人4.Enabled = true;
            tb電話4.Enabled = true;
            tb備註.Enabled = true;
        }

        #endregion

        #region 還原按鈕

        private void TsbBack() 
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;

            tb代號.Enabled = false;
            tb全稱.Enabled = false;
            tb簡稱.Enabled = false;
            tb編號.Enabled = false;
            tb電話.Enabled = false;
            tb傳真.Enabled = false;
            tb發票.Enabled = false;
            tb郵寄.Enabled = false;
            tb負責人.Enabled = false;
            tb負責人電話.Enabled = false;
            tb統編.Enabled = false;
            tb品別.Enabled = false;
            tb幣別.Enabled = false;
            comboBox2.Enabled = false;
            tb聯絡人1.Enabled = false;
            tb電話1.Enabled = false;
            tb聯絡人2.Enabled = false;
            tb電話2.Enabled = false;
            tb聯絡人3.Enabled = false;
            tb電話3.Enabled = false;
            tb聯絡人4.Enabled = false;
            tb電話4.Enabled = false;
            tb備註.Enabled = false;
        }

        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from kfzl where  kfdh = '{0}'", tb代號.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idcheck = false;
                }
                dbConn.CloseConnection();
            }
            catch (Exception)
            { 
            }
        }

        #endregion

        #region 新增方法

        #region 插入方法
        private void InsertData()
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert kfzl ([kfdh],[kfqm],[kfjc],[tybh],[fpdz],[yjdz],[dh],[cz],[fzr],[fzrdh],[bb],[llr1],[llrdh1],[llr2],[llrdh2],[llr3],[llrdh3],[llr4],[llrdh4],[dybh],[USERID],[USERDATE],[TRANDATE],[pb],[YN],[CCGB],[BZ],[pass0],[pass1],[pass2],[paydays],[useyn]) values ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}' ,'{12}' ,'{13}' ,'{14}' ,'{15}' ,'{16}' ,'{17}' ,'{18}' ,'{19}' ,'{20}' ,GETDATE() ,null ,'{21}' ,'1' ,'{22}' ,'{23}' ,null ,null ,null ,'31' ,'1') ", tb代號.Text, tb全稱.Text, tb簡稱.Text, tb統編.Text, tb發票.Text, tb郵寄.Text, tb電話.Text, tb傳真.Text, tb負責人.Text, tb負責人電話.Text, tb幣別.Text, tb聯絡人1.Text, tb電話1.Text, tb聯絡人2.Text, tb電話2.Text, tb聯絡人3.Text, tb電話3.Text, tb聯絡人4.Text, tb電話4.Text, tb編號.Text, userid, tb品別.Text, comboBox2.SelectedValue, tb備註.Text);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.CloseConnection();

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete kfzl where kfdh = '{0}' insert into kfzl SELECT[kfdh],[kfqm],[kfjc],[tybh],[fpdz],[yjdz],[dh],[cz],[fzr],[fzrdh],[bb],[llr1],[llrdh1],[llr2],[llrdh2],[llr3],[llrdh3],[llr4],[llrdh4],[dybh],[USERID],CONVERT(varchar,USERDATE,11),CONVERT(varchar,TRANDATE,11),[pb],[CCGB],[BZ], null FROM New_Erp.[dbo].[kfzl] where kfdh = '{0}'", tb代號.Text);
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
            catch (Exception) 
            {
                MessageBox.Show("ERROR", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update kfzl set kfqm = '{0}', kfjc = '{1}', tybh = '{2}', fpdz = '{3}', yjdz = '{4}', dh = '{5}', cz = '{6}', fzr = '{7}', fzrdh = '{8}', bb = '{9}', llr1 = '{10}',llrdh1 = '{11}', llr2 = '{12}', llrdh2 = '{13}', llr3 = '{14}', llrdh3 = '{15}',llr4 = '{16}', llrdh4 = '{17}',dybh = '{18}',USERID = '{19}',USERDATE = GETDATE(), pb = '{20}', CCGB = '{21}', BZ = '{22}' where kfdh = '{23}'", tb全稱.Text, tb簡稱.Text, tb統編.Text, tb發票.Text, tb郵寄.Text, tb電話.Text, tb傳真.Text, tb負責人.Text, tb負責人電話.Text, tb幣別.Text, tb聯絡人1.Text, tb電話1.Text, tb聯絡人2.Text, tb電話2.Text, tb聯絡人3.Text, tb電話3.Text, tb聯絡人4.Text, tb電話4.Text, tb編號.Text, userid, tb品別.Text, comboBox2.SelectedValue, tb備註.Text, tb代號.Text);

                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete kfzl where kfdh = '{0}' insert into kfzl SELECT[kfdh],[kfqm],[kfjc],[tybh],[fpdz],[yjdz],[dh],[cz],[fzr],[fzrdh],[bb],[llr1],[llrdh1],[llr2],[llrdh2],[llr3],[llrdh3],[llr4],[llrdh4],[dybh],[USERID],CONVERT(varchar,USERDATE,11),CONVERT(varchar,TRANDATE,11),[pb],[CCGB],[BZ], null FROM New_Erp.[dbo].[kfzl] where kfdh = '{0}'", tb代號.Text);
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
            catch (Exception) { }
        }


        #endregion

        #region 重新讀取

        private void Reload()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from kfzl where YN = 1");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            dataGridView1.DataSource = ds.Tables[0];
        }

        #endregion

        #region 刪除方法
        public void DeleteData()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update kfzl set YN = 1 where kfdh = '{0}'", tb代號.Text);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con4.CloseConnection();
        }
        #endregion

        #endregion

        #region 事件


        private void tsbClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clean();
            }
            catch (Exception) 
            {
            }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                CustomQuery Form = new CustomQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Visible = true;
            }
            catch (Exception) 
            { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                sl = "1";
                Clean();
                Edit();
                tb代號.Enabled = true;

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
                //comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try 
            {
                DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DeleteData();
                }
                Reload();
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "1";
                sl = "2";
                Edit();
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
                //comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (sl == "1") //新增
                {
                    CheckID();
                    if (idcheck == false)
                    {
                        MessageBox.Show("ID重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        if (tb代號.Text == "" || tb全稱.Text == "" || tb簡稱.Text == "" || tb編號.Text == "" )
                        {
                            MessageBox.Show("內容不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                            InsertData();
                        }
                    }
                }
                else if (sl =="2") //修改
                {
                    Console.WriteLine("MODIFY");
                    ModifyData();
                }

                sl = "";
                TsbBack();
                //comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                //Reload();
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                TsbBack();
                //comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            catch (Exception) { }
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

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

                }
                tsbPrior.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb全稱.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb簡稱.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb統編.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb發票.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tb郵寄.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tb電話.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tb傳真.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tb負責人.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tb負責人電話.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tb幣別.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tb聯絡人1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                tb電話1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                tb聯絡人2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                tb電話2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                tb聯絡人3.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                tb電話3.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                tb聯絡人4.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                tb電話4.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                tb編號.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                //ID
                //DATE
                //轉出時間
                tb品別.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
                //YN
                label2.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
                //pass0
                //pass1
                //pass2
                //payday
                //useyn

                string sizename = "";
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select SIZE_Name from CSSize where SIZE_ID = '{0}'", label2.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sizename = reader["SIZE_Name"].ToString();
                }
                dbConn.CloseConnection();

                comboBox2.Text = sizename;

            }
            catch (Exception) { }
        }

        private void tsButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
            tabControl1.SelectedTab = P0002;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception) { }
        }
    }
}
