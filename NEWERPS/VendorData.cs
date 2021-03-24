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
    public partial class VendorData : Form
    {

        #region 建構函式

        public VendorData()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        DataSet ds = new DataSet(); // 儲存資料表容器    
        string rowno = "";
        string sl = "";
        int index = 0;
        public DataSet dsl = new DataSet();
        Boolean checkName = true;
        public string userid = "";



        public string languageType;
        public string userLanguage;
        string userForm = "Vendor Inf.";

        #endregion

        #region 畫面載入
        private void VendorData_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

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
                L0021.Text = dgvWord.Rows[20].Cells[3].Value.ToString();
                L0022.Text = dgvWord.Rows[21].Cells[3].Value.ToString();


            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 新增載入

        private void NewData()
        {
            int result;
            DBconnect conn = new DBconnect();
            string sql1 = string.Format("insert into zszl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',NULL,NULL,'{16}',isnull('{17}',0),'{18}', '{19}','{20}',GETDATE())", tb廠代1.Text, tb廠名1.Text, tb簡稱1.Text, tb英文1.Text, tb統編1.Text, tb發票1.Text, tb郵寄1.Text, tb電話1.Text, tb傳真1.Text, tb負責人1.Text, tbMail11.Text, tb幣別1.Text, tb開發1.Text, tbMail21.Text, tb量產1.Text, tbMail31.Text, tb付款1.Text, tb扣趴1.Text, tb生產地1.Text, comboBox1.SelectedIndex + 1 , userid);
            Console.WriteLine(sql1);
            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
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
            string sql1Y = string.Format("delete zszl where zsdh = '{0}' insert into zszl SELECT[zsdh],[zsqm],[zsjc],[zsywjc],[tybh],[fpdz],[yjdz],[dh],[cz],[fzr],[bb],[llr2],[llr],[dybh],[mark],[USERID],CONVERT(varchar,USERDATE,11),[TRANDATE],[fktj],[fktj1],[scd],[fzr_mail],[llr2_mail],[llr_mail] FROM [192.168.11.15].New_Erp.dbo.[zszl] where zsdh = '{0}'", tb廠代1.Text);
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

        #endregion

        #region 檢查名稱重複

        private void CheckName()
        {
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select * from zszl where zsdh = '{0}'", tb廠代1.Text);
            SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
            dbConn2.OpenConnection();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                checkName = false;
            }
            dbConn2.CloseConnection();
        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            Console.WriteLine("Modify");
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update zszl set zsqm = '{0}',zsjc = '{1}',zsywjc = '{2}',tybh = '{3}',fpdz = '{4}',yjdz = '{5}',dh = '{6}',cz = '{7}',fzr = '{8}',bb = '{9}',llr2 = '{10}',llr = '{11}',scd = '{12}',fzr_mail = '{13}',llr2_mail = '{14}',llr_mail = '{15}',USERDATE = GETDATE() where zsdh = '{16}'", tb廠名1.Text, tb簡稱1.Text, tb英文1.Text, tb統編1.Text, tb發票1.Text, tb郵寄1.Text, tb電話1.Text, tb傳真1.Text, tb負責人1.Text, tb幣別1.Text, tb量產1.Text, tb開發1.Text, tb生產地1.Text, tbMail11.Text, tbMail21.Text, tbMail31.Text, tb廠代1.Text);
            Console.WriteLine(sql4);
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("修改資料失敗", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con4.CloseConnection();

            #region LYSHOE

            int resultY;
            DBconnect2 connY = new DBconnect2();
            string sql1Y = string.Format("delete zszl where zsdh = '{0}' insert into zszl SELECT[zsdh],[zsqm],[zsjc],[zsywjc],[tybh],[fpdz],[yjdz],[dh],[cz],[fzr],[bb],[llr2],[llr],[dybh],[mark],[USERID],CONVERT(varchar,USERDATE,11),[TRANDATE],[fktj],[fktj1],[scd],[fzr_mail],[llr2_mail],[llr_mail] FROM [192.168.11.15].New_Erp.dbo.[zszl] where zsdh = '{0}'", tb廠代1.Text);
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


        #endregion

        #region 載入文字

        private void LoadText()
        {
            try
            {
                tb廠代1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb廠名1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb簡稱1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb英文1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb統編1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tb發票1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tb郵寄1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tb付款1.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                tb扣趴1.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                tb幣別1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                tb最後交易日1.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                tb電話1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tb傳真1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tb負責人1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tbMail11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tb開發1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                tbMail21.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                tb量產1.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                tbMail31.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                tb生產地1.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();

                string a = "";
                a = dataGridView1.CurrentRow.Cells[21].Value.ToString();
                //MessageBox.Show(a);
                if ( a == "1") 
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (a == "2")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if(a == "3")
                {
                    comboBox1.SelectedIndex = 2;
                }

                tb用戶1.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
                tb異動日1.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #region 開啟輸入欄位

        private void OpenText()
        {
            tb廠代1.Enabled = true;
            tb廠名1.Enabled = true;
            tb簡稱1.Enabled = true;
            tb英文1.Enabled = true;
            tb統編1.Enabled = true;
            tb發票1.Enabled = true;
            tb郵寄1.Enabled = true;
            tb付款1.Enabled = true;
            tb扣趴1.Enabled = true;
            tb幣別1.Enabled = true;
            tb傳真1.Enabled = true;
            tb電話1.Enabled = true;
            //tb最後交易日1.Enabled = true;
            tb負責人1.Enabled = true;
            tbMail11.Enabled = true;
            tb開發1.Enabled = true;
            tbMail21.Enabled = true;
            tb量產1.Enabled = true;
            tbMail31.Enabled = true;
            //tb對應1.Text = "";
            tb生產地1.Enabled = true;
            //tb用戶1.Enabled = true;
            //tb異動日1.Enabled = true;
        }

        #endregion

        #region 復原按鍵

        private void RecoverBtn()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;
            tsbPrint.Enabled = false;
            tsbConfirm.Enabled = false;

            tb廠代1.Enabled = false;
            tb廠名1.Enabled = false;
            tb簡稱1.Enabled = false;
            tb英文1.Enabled = false;
            tb統編1.Enabled = false;
            tb發票1.Enabled = false;
            tb郵寄1.Enabled = false;
            tb付款1.Enabled = false;
            tb扣趴1.Enabled = false;
            tb幣別1.Enabled = false;
            tb傳真1.Enabled = false;
            tb電話1.Enabled = false;
            tb最後交易日1.Enabled = false;
            tb負責人1.Enabled = false;
            tbMail11.Enabled = false;
            tb開發1.Enabled = false;
            tbMail21.Enabled = false;
            tb量產1.Enabled = false;
            tbMail31.Enabled = false;
            tb生產地1.Enabled = false;
            tb用戶1.Enabled = false;
            tb異動日1.Enabled = false;
            comboBox1.Enabled = false;
        }

        #endregion

        #region 清空按紐

        private void Clean1()
        {
            tb廠代1.Text = "";
            tb廠名1.Text = "";
            tb簡稱1.Text = "";
            tb英文1.Text = "";
            tb統編1.Text = "";
            tb發票1.Text = "";
            tb郵寄1.Text = "";
            tb付款1.Text = "";
            tb扣趴1.Text = "";
            tb幣別1.Text = "";
            tb傳真1.Text = "";
            tb電話1.Text = "";
            tb最後交易日1.Text = "";
            tb負責人1.Text = "";
            tbMail11.Text = "";
            tb開發1.Text = "";
            tbMail21.Text = "";
            tb量產1.Text = "";
            tbMail31.Text = "";
            //tb對應1.Text = "";
            tb生產地1.Text = "";
            tb用戶1.Text = "";
            tb異動日1.Text = "";
        }

        #endregion

        #endregion

        #region 事件


        private void TspQuery_Click(object sender, EventArgs e)
        {
            VendorQuery Form = new VendorQuery();
            //Form.Show();

            DialogResult R = Form.ShowDialog();

            if (R == DialogResult.OK)
            {

            }
            dataGridView1.DataSource = Form.ds.Tables[0];
            LoadText();
            dataGridView1.Visible = true;
        }

        private void TspClear_Click(object sender, EventArgs e)
        {
            Clean1();
            //RecoverBtn();
        }

        private void TspInsert_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                tabControl1.SelectedTab = tabPage2;

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

                tb用戶1.Text = userid;

                OpenText();


                sl = "1";

                Clean1();
                dataGridView1.Visible = true;
            }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {

        }

        private void TspModify_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "1";
            OpenText();
            tsbQuery.Enabled = false;
            tsbInsert.Enabled = false;
            tsbFirst.Enabled = false;
            tsbNext.Enabled = false;
            tsbPrior.Enabled = false;
            tsbLast.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            sl = "2";
            dataGridView1.Visible = true;
            comboBox1.Enabled = true;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                if (tb廠代1.Text == "")
                { }
                else
                {
                    if (sl == "1")//新增
                    {
                        CheckName();
                        if (checkName == true)
                        {
                            if (tb扣趴1.Text == "")
                            {
                                tb扣趴1.Text = "0";
                            }
                            else
                            {
                            }
                            Console.WriteLine("checkName == true");
                            NewData();
                            Console.WriteLine("DATAOK");
                            RecoverBtn();
                            tsbPrior.Enabled = false;
                            tsbNext.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("該名稱已經被使用", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Clean1();
                            tb廠代1.Text = "";
                        }

                        sl = "";
                    }
                    else if (sl == "2")//修改
                    {
                        if (tb扣趴1.Text == "")
                        {
                            tb扣趴1.Text = "0";
                        }
                        else
                        {
                        }
                        Console.WriteLine("sl2");
                        ModifyData();
                        sl = "";
                        RecoverBtn();
                    }
                }
                dataGridView1.Visible = true;
            }
            catch (Exception)
            { }
        }

        private void TsbExit_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                RecoverBtn();
                dataGridView1.DataSource = zszlBindingSource;
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                LoadText();
            }
            catch (Exception) { }
        }

        private void TsbFirst_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            LoadText();
            tsbPrior.Enabled = false;
            tsbNext.Enabled = true;

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
            }
            tsbNext.Enabled = true;


        }

        private void TsbNext_Click(object sender, EventArgs e)
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

        private void TsbLast_Click(object sender, EventArgs e)
        {
            //CompanyDataLoading("select count(*) from zszl");
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            LoadText();
            tsbNext.Enabled = false;
            tsbPrior.Enabled = true;

        }

        private void TsbPrint_Click(object sender, EventArgs e)
        {

        }

        private void TsbConfirm_Click(object sender, EventArgs e)
        {

        }

        #endregion
               


        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void tb扣趴1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != '\b')//这是允许输入退格键
            //{
            //    if ((e.KeyChar < '0') || (e.KeyChar > '9') || ( (int)e.KeyChar == 46))//这是允许输入0-9数字
            //    {
            //        e.Handled = true;
            //    }
            //}

            TextBox textBoxSender = (TextBox)sender;

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
            {//输入的值是否在合理的范围内，如果不是，则标记为处理过，程序不在处理，为true时表示此次输入无效              
                e.Handled = true;
            }
            //小数点的处理。
            if ((int)e.KeyChar == 46)
            { //小数点               
                if (textBoxSender.Text.Length <= 0)
                { //小数点不能在第一位
                    e.Handled = true;
                }
                else
                {
                    float fOriginalAndInput;
                    float fOriginal;
                    bool bCovOriginalAndInput = false, bCovOriginal = false;
                    bCovOriginal = float.TryParse(textBoxSender.Text, out fOriginal);
                    bCovOriginalAndInput = float.TryParse(textBoxSender.Text + e.KeyChar.ToString(), out fOriginalAndInput);
                    if (bCovOriginalAndInput == false)
                    { //输入小数点时，如果输入框内容加上输入的内容不是浮点数
                        if (bCovOriginal == true)
                        {//输入框内容是浮点数，则此次不输入，限制输入小数点的个数，不做处理
                            //  eKeyPress.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                }
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            LoadText();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
