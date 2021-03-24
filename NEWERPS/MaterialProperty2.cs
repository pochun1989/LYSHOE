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
    public partial class MaterialProperty2 : Form
    {
        #region 建構函式

        public MaterialProperty2()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public string userid = "";
        string sep = "";
        int selectdgv = 0;
        public string languageType;
        //public string modify;
        string sort;

        string propertyid1, propertytext1;
        Boolean seperate1 = true;

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage ;
        string userForm = "PropertyM";



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
                int i;
                i = int.Parse(userLanguage) + 1;

                dsl = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsl, "棧板表");
                this.dgvWord.DataSource = this.dsl.Tables[0];


                dgvA.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dgvA.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dgvA.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();

                dgvB.Columns[0].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dgvB.Columns[2].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dgvB.Columns[3].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();

                dgv999.Columns[3].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dgv999.Columns[4].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dgv999.Columns[7].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dgv999.Columns[8].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion




        #endregion

        #region 載入A

        private void DataA()
        {
            try
            {
                dsl = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select Class_ID,zwsm,ywsm from CLASS_A");
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsl, "棧板表");
                this.dgvA.DataSource = this.dsl.Tables[0];
                dgvA.Columns[0].Width = 100;
            }
            catch (Exception) { }
        }

        #endregion        

        #region 切換CLASSFeature

        private void DataClassFeature() 
        {
            try
            {
                dsl = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("SELECT  CLASS_fEATURE.cllb, CLASS_fEATURE.Class_ID, CLASS_fEATURE.Feature_ID, CLASS_fEATURE.sortkey, CLASS_fEATURE.Separate, CLASS_fEATURE.USERID, CLASS_fEATURE.USERDATE, feature.txywsm, feature.txzwsm FROM CLASS_fEATURE INNER JOIN feature ON CLASS_fEATURE.Feature_ID = feature.Feature_ID where (Class_ID = '{0}' and cllb = '999') or( Class_ID = '{1}' and cllb = '{2}') order by sortkey , cllb", dgvA.CurrentRow.Cells[0].Value.ToString(), dgvA.CurrentRow.Cells[0].Value.ToString(), dgvB.CurrentRow.Cells[0].Value.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsl, "棧板表");
                this.dgv999.DataSource = this.dsl.Tables[0];

                dgv999.Columns[0].Visible = false;
                dgv999.Columns[1].Visible = false;
                dgv999.Columns[2].Visible = false;
                dgv999.Columns[5].Visible = false;
                dgv999.Columns[6].Visible = false;

                dgv999.Columns[3].Width = 80;
                dgv999.Columns[4].Width = 80;

                int c = dgv999.Rows.Count;
                for (int i = 0; i <c; i++)
                {
                    if (dgv999.Rows[i].Cells[0].Value.ToString() == "999")
                    {
                        dgv999.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        dgv999.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception) 
            {
                
            }
        }



        #endregion

        #region 切換CLASSB

        private void DataClassB()
        {
            try
            {
                dsl = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from CLASS_B where Class_ID = '{0}'", dgvA.CurrentRow.Cells[0].Value.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsl, "棧板表");
                this.dgvB.DataSource = this.dsl.Tables[0];

                dgvB.Columns[1].Visible = false;
                dgvB.Columns[4].Visible = false;
                dgvB.Columns[5].Visible = false;

                dgvB.Columns[0].Width = 80;

            }
            catch (Exception) { }
        }



        #endregion

        #region 載入特性

        private void LoadPro()
        {

            if (dgv999.CurrentRow.Cells[4].Value.ToString() == "True")
            {
                //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                ds3 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}' and cllb = '{2}'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString(), dgv999.CurrentRow.Cells[0].Value.ToString());
                //string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds3, "棧板表");
                this.dataGridView1.DataSource = this.ds3.Tables[0];

                //dataGridView1.Columns[0].Width = 80;
            }
            else if (dgv999.CurrentRow.Cells[4].Value.ToString() == "False") 
            {
                //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                ds3 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select sn,iteme,itemc from feature_item where Feature_ID = '{0}'", dgv999.CurrentRow.Cells[2].Value.ToString());
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds3, "棧板表");
                this.dataGridView1.DataSource = this.ds3.Tables[0];

                //dataGridView1.Columns[0].Width = 80;
            }
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].Width = 80;
        }

        #endregion

        #region 搜尋功能

        private void SearchPro()
        {
            if (textBox4.Text != "")
            {
                if (dgv999.CurrentRow.Cells[4].Value.ToString() == "True")
                {
                    //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                    ds3 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}' and cllb = '{2}' and iteme like '%{3}%'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString(), dgv999.CurrentRow.Cells[0].Value.ToString(), textBox4.Text);
                    //string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString());
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds3, "棧板表");
                    this.dataGridView1.DataSource = this.ds3.Tables[0];

                    //dataGridView1.Columns[0].Width = 80;
                }
                else if (dgv999.CurrentRow.Cells[4].Value.ToString() == "False")
                {
                    //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                    ds3 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select sn,iteme,itemc from feature_item where Feature_ID = '{0}' and iteme like '%{1}%'", dgv999.CurrentRow.Cells[2].Value.ToString(),textBox4.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds3, "棧板表");
                    this.dataGridView1.DataSource = this.ds3.Tables[0];

                    //dataGridView1.Columns[0].Width = 80;
                }
                //dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[4].Visible = false;
                //dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].Width = 80;
            }
            else if(textBox5.Text != "") 
            {
                if (dgv999.CurrentRow.Cells[4].Value.ToString() == "True")
                {
                    //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                    ds3 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}' and cllb = '{2}' and itemc like '%{3}%'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString(), dgv999.CurrentRow.Cells[0].Value.ToString(),textBox5.Text);
                    //string sql = string.Format("select sn,iteme,itemc from Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString());
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds3, "棧板表");
                    this.dataGridView1.DataSource = this.ds3.Tables[0];

                    //dataGridView1.Columns[0].Width = 80;
                }
                else if (dgv999.CurrentRow.Cells[4].Value.ToString() == "False")
                {
                    //Console.WriteLine(dgv999.CurrentRow.Cells[4].Value.ToString());

                    ds3 = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select sn,iteme,itemc from feature_item where Feature_ID = '{0}' and itemc like '%{1}%'", dgv999.CurrentRow.Cells[2].Value.ToString(), textBox5.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds3, "棧板表");
                    this.dataGridView1.DataSource = this.ds3.Tables[0];

                    //dataGridView1.Columns[0].Width = 80;
                }
                //dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[4].Visible = false;
                //dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].Width = 80;
            }
        }

        #endregion

        #region 還原按鈕

        private void RecoverBtn()
        {
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
        }

        #endregion

        #region 修改SN

        private void ModifySN() 
        {
            try
            {
                int x;
                x = dgv999.RowCount;

                for (int i = 0; i < x; i++)
                {
                    DBconnect con8 = new DBconnect();
                    StringBuilder sql8 = new StringBuilder();
                    sql8.AppendFormat("update CLASS_fEATURE set sortkey = '{0}', USERID = '{1}', USERDATE = GETDATE() where cllb = '{2}' and Class_ID = '{3}' and Feature_ID = '{4}'", dgv999.Rows[i].Cells[3].Value.ToString(), userid, dgv999.Rows[i].Cells[0].Value.ToString(), dgv999.Rows[i].Cells[1].Value.ToString(), dgv999.Rows[i].Cells[2].Value.ToString());

                    SqlCommand cmd8 = new SqlCommand(sql8.ToString(), con8.connection);
                    con8.OpenConnection();
                    int result8 = cmd8.ExecuteNonQuery();
                    if (result8 == 1)
                    {
                        //MessageBox.Show("修改資料成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con8.CloseConnection();                    
                }
                MessageBox.Show("修改資料成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 事件

        private void dgvA_SelectionChanged(object sender, EventArgs e)
        {
            DataClassFeature();
            DataClassB();
        }

        private void dgvB_SelectionChanged(object sender, EventArgs e)
        {
            DataClassFeature();
        }

        private void dgv999_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

            textBox1.Text = dgvA.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dgvB.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dgv999.CurrentRow.Cells[7].Value.ToString();

            LoadPro();
            selectdgv = 4;
            #region 變色
            dgvA.EnableHeadersVisualStyles = false;
            dgvA.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv999.EnableHeadersVisualStyles = false;
            dgv999.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvB.EnableHeadersVisualStyles = false;
            dgvB.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;


            int a, b, c, d, e1, f;
            a = dgvA.RowCount;
            for (int i = 0; i < a; i++)
            {
                dgvA.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            b = dgv999.RowCount;
            for (int i = 0; i < b; i++)
            {

                dgv999.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            d = dgvB.RowCount;
            for (int i = 0; i < d; i++)
            {

                dgvB.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            c = dataGridView1.RowCount;
            for (int i = 0; i < c; i++)
            {

                //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }

            #endregion
        }

        private void dgvA_Click(object sender, EventArgs e)
        {
            try
            {
                tsbModify.Enabled = false;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbQuery.Enabled = false;
                tsbClear.Enabled = false;

                //RecoverBtn();
                #region 變色
                dgvA.EnableHeadersVisualStyles = false;
                dgvA.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;
                dgv999.EnableHeadersVisualStyles = false;
                dgv999.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgvB.EnableHeadersVisualStyles = false;
                dgvB.ColumnHeadersDefaultCellStyle.BackColor = Color.White;


                int a, b, c, d, e1, f;
                a = dgvA.RowCount;
                for (int i = 0; i < a; i++)
                {
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }

                b = dgv999.RowCount;
                for (int i = 0; i < b; i++)
                {

                    dgv999.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                d = dgvB.RowCount;
                for (int i = 0; i < d; i++)
                {

                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                #endregion
                Program.Modifytype.modify = "0";
            }
            catch (Exception) { }

            selectdgv = 1;
        }

        private void dgv999_Click(object sender, EventArgs e)
        {
            tsbModify.Enabled = true;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = true;
            tsbQuery.Enabled = false;
            tsbClear.Enabled = false;

            selectdgv = 3;
            textBox4.Text = "";
            textBox5.Text = "";
            try
            {
                //RecoverBtn();
                #region 變色
                dgvA.EnableHeadersVisualStyles = false;
                dgvA.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgv999.EnableHeadersVisualStyles = false;
                dgv999.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;

                dgvB.EnableHeadersVisualStyles = false;
                dgvB.ColumnHeadersDefaultCellStyle.BackColor = Color.White;


                int a, b, c, d, e1, f;
                a = dgvA.RowCount;
                for (int i = 0; i < a; i++)
                {
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                b = dgv999.RowCount;
                for (int i = 0; i < b; i++)
                {

                    dgv999.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }
                               
                d = dgvB.RowCount;
                for (int i = 0; i < d; i++)
                {

                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                #endregion

                LoadPro();
                Program.Modifytype.modify = "0";
            }
            catch (Exception) { }
        }

        private void dgvB_Click(object sender, EventArgs e)
        {
            tsbModify.Enabled = false;
            tsbInsert.Enabled = false;
            tsbDelete.Enabled = false;
            tsbQuery.Enabled = false;
            tsbClear.Enabled = false;


            selectdgv = 2;

            try
            {
                //RecoverBtn();
                #region 變色
                dgvA.EnableHeadersVisualStyles = false;
                dgvA.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgv999.EnableHeadersVisualStyles = false;
                dgv999.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgvB.EnableHeadersVisualStyles = false;
                dgvB.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;


                int a, b, c, d, e1, f;
                a = dgvA.RowCount;
                for (int i = 0; i < a; i++)
                {
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                b = dgv999.RowCount;
                for (int i = 0; i < b; i++)
                {

                    dgv999.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }


                d = dgvB.RowCount;
                for (int i = 0; i < d; i++)
                {

                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }

                               
                #endregion
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {

            if (selectdgv == 3) 
            {
                try
                {

                    dgv999.ReadOnly = false;

                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    Program.Modifytype.modify = "1";
                }
                catch (Exception)
                {
                }
            }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectdgv == 4)
                {
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;

                    NewFeature Form = new NewFeature();
                    Form.property = dgv999.CurrentRow.Cells[8].Value.ToString();
                    Form.propertyID = dgv999.CurrentRow.Cells[2].Value.ToString();
                    Form.sep = dgv999.CurrentRow.Cells[4].Value.ToString();
                    Form.cllb = dgv999.CurrentRow.Cells[0].Value.ToString();
                    Form.classa = dgv999.CurrentRow.Cells[1].Value.ToString();
                    Form.gridviewID = "4";
                    Form.ShowDialog();


                    RecoverBtn();

                    LoadPro();
                    //ChangeFeature();

                }
                else if (selectdgv == 3)
                {
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;

                    NewClassFeature Form = new NewClassFeature();
                    Form.textBox1.Text = dgvB.CurrentRow.Cells[0].Value.ToString();
                    //Form.unitary = "sep";
                    Form.sepID = dgv999.CurrentRow.Cells[0].Value.ToString();
                    Form.classa = dgvA.CurrentRow.Cells[0].Value.ToString();
                    Form.textBox2.Text = dgvA.CurrentRow.Cells[0].Value.ToString();
                    
                    Form.ShowDialog();


                    RecoverBtn();

                    //DataElse();
                    DataClassFeature();
                }

            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                selectdgv = 3;
            }
            else 
            {
                tsbModify.Enabled = true;
                tsbInsert.Enabled = true;
                tsbDelete.Enabled = true;
                tsbQuery.Enabled = true;
                tsbClear.Enabled = true;

                selectdgv = 4;
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            RecoverBtn();
            Program.Modifytype.modify = "0";
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                ModifySN();
                RecoverBtn();
                DataClassFeature();

            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PropertyDelete FormD = new PropertyDelete();
                FormD.ShowDialog();
                if (FormD.pass == "31912")
                {
                    Console.WriteLine(selectdgv);
                    if (selectdgv == 3)
                    {
                        DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            DBconnect dbconn2 = new DBconnect();
                            StringBuilder sqlD = new StringBuilder();
                            sqlD.AppendFormat("delete CLASS_fEATURE where Class_ID = '{0}' and Feature_ID = '{1}' and cllb = '{2}'", dgv999.CurrentRow.Cells[1].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString(), dgv999.CurrentRow.Cells[0].Value.ToString());
                            SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn2.connection);
                            dbconn2.OpenConnection();
                            int resultD = cmdD.ExecuteNonQuery();
                            if (resultD == 1)
                            {
                                MessageBox.Show("刪除資料成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        DataClassFeature();
                    }
                    else if (selectdgv == 4)
                    {
                        DialogResult dr = MessageBox.Show("確定要刪除這筆資料嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            if (dgv999.CurrentRow.Cells[4].Value.ToString() == "True")
                            {
                                Console.WriteLine("True4");
                                Console.WriteLine(dgv999.CurrentRow.Cells[2].Value.ToString());
                                Console.WriteLine(dataGridView1.CurrentRow.Cells[2].Value.ToString());

                                //刪除CLASSFEATURE
                                DBconnect dbconn2 = new DBconnect();
                                StringBuilder sqlD = new StringBuilder();
                                sqlD.AppendFormat("delete Separate_Item where Class_ID = '{0}' and Feature_ID = '{1}' and iteme = '{2}'", dgvA.CurrentRow.Cells[0].Value.ToString(), dgv999.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn2.connection);
                                Console.WriteLine(sqlD.ToString());
                                dbconn2.OpenConnection();
                                int resultD = cmdD.ExecuteNonQuery();
                                if (resultD == 1)
                                {
                                    MessageBox.Show("刪除資料成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (dgv999.CurrentRow.Cells[4].Value.ToString() == "False")
                            {
                                Console.WriteLine("False4");
                                Console.WriteLine(dgv999.CurrentRow.Cells[2].Value.ToString());
                                Console.WriteLine(dataGridView1.CurrentRow.Cells[2].Value.ToString());

                                //刪除CLASSFEATURE
                                DBconnect dbconn2 = new DBconnect();
                                StringBuilder sqlD = new StringBuilder();
                                sqlD.AppendFormat("delete feature_item where Feature_ID = '{0}' and iteme = '{1}'", dgv999.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                SqlCommand cmdD = new SqlCommand(sqlD.ToString(), dbconn2.connection);
                                dbconn2.OpenConnection();
                                int resultD = cmdD.ExecuteNonQuery();
                                if (resultD == 1)
                                {
                                    MessageBox.Show("刪除資料成功", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        LoadPro();
                    }
                }
                else 
                {
                    MessageBox.Show("PASSWORD ERROR");
                }
            }
            catch (Exception) { }
        }

        private void MaterialProperty2_Leave(object sender, EventArgs e)
        {
            
        }

        private void MaterialProperty2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void MaterialProperty2_Deactivate(object sender, EventArgs e)
        {
            //MessageBox.Show("123");
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "" || textBox5.Text != "")
                {
                    SearchPro();
                }
                else
                {

                }
            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
        }

        #endregion

        #region 畫面載入

        private void MaterialProperty2_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            DataA();
            ChangeDataView();

            //Console.WriteLine();
        }



        #endregion


    }
}
