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
    public partial class LanguageNew : Form
    {
        public LanguageNew()
        {
            InitializeComponent();
        }

        #region 變數

        public string userid = "";
        DataSet ds2 = new DataSet();
        public string sl = ""; //1 insert //2 modify
        int index = 0;

        //語言變數
        public DataSet ds = new DataSet();
        public string userLanguage;
        string userForm = "1_11_2";

        #endregion

        private void LanguageNew_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;
                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.MMCLASS' 資料表。您可以視需要進行移動或移除。
                this.mMCLASSTableAdapter.Fill(this.lY_TESTDataSet.MMCLASS);

                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                LoadText();

                //更改語言
                ChangeLabel();
                ChangeDataView();
            }
            catch (Exception) { }
        }

        #region 方法

        #region 取出最大序號

        private void MaxNum()
        {
            try
            {
                string max = "";
                Console.WriteLine("MAX");
                ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select isnull(MAX(MM_ID)+1,1) as MAX from MMCLASS  ");
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    max = reader["MAX"].ToString();
                }
                //max = reader["count"].ToString();
                label3.Text = max;
            }
            catch (Exception) { }

        }

        #endregion

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'L%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            this.dgvWord.DataSource = this.ds.Tables[0];

            WordPosition();
        }

        #endregion

        #region 切換 dgv

        private void ChangeDataView()
        {

            int i;
            i = int.Parse(userLanguage) + 1;

            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'D%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            this.dgvWord.DataSource = this.ds.Tables[0];

            LoadDgv();
        }

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                int r = dgvWord.Rows.Count;

                for(int i = 0; i < r ; i++)
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 載入文字方法

        private void LoadText()
        {
            tb名稱.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            int result;
            DBconnect conn = new DBconnect();
            string sql1 = string.Format("insert into MMCLASS values('{0}','{1}','{2}',GETDATE())", label3.Text, tb名稱.Text, userid);
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




            tb名稱.Enabled = false;

        }

        #endregion

        #region 刪除

        private void DeleteFactory()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update cqzl set YN = 1 where cqdh = '{0}'");
            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            con4.OpenConnection();
            int result4 = cmd4.ExecuteNonQuery();
            if (result4 == 1)
            {
                MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //CompanyDataLoading("1");
            }
            else
            {
                MessageBox.Show("刪除資料失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 修改方法

        private void ModifyFactory()
        {
            DBconnect con4 = new DBconnect();
            StringBuilder sql4 = new StringBuilder();
            sql4.AppendFormat("update MMCLASS set MM_NAME = '{0}', userid = '{1}', UserDate = GETDATE() where MM_ID = '{2}'", tb名稱.Text, userid, label3.Text);

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

        #region 清空方法

        private void Clean()
        {
            tb名稱.Text = "";
        }

        #endregion

        #endregion

        #region 事件

        #endregion

        private void TsbClear_Click(object sender, EventArgs e)
        {
            Clean();
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
                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.MMCLASS' 資料表。您可以視需要進行移動或移除。
                this.mMCLASSTableAdapter.Fill(this.lY_TESTDataSet.MMCLASS);
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
                tb名稱.Enabled = true;
                sl = "2";
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
                if (tb名稱.Text != "")
                {
                    if (sl == "1") //insert
                    {

                        InsertData();
                        sl = "";
                        tsbBack();
                    }
                    else if (sl == "2") //midify
                    {
                        ModifyFactory();
                        sl = "";
                        tsbBack();
                    }
                }
                else
                {
                }
                // TODO: 這行程式碼會將資料載入 'lY_TESTDataSet.MMCLASS' 資料表。您可以視需要進行移動或移除。
                this.mMCLASSTableAdapter.Fill(this.lY_TESTDataSet.MMCLASS);
            }
            catch (Exception) { }
        }

        private void TsbCancel_Click(object sender, EventArgs e)
        {
            Program.Modifytype.modify = "0";
            tsbBack();
            sl = "";
            dataGridView1.DataSource = mMCLASSBindingSource;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            LoadText();

        }

        private void TsbFirst_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            LoadText();
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
        }

        private void TsbLast_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            LoadText();
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void TsbInsert_Click(object sender, EventArgs e)
        {
            Clean();
            MaxNum();
            tb名稱.Enabled = true;

            tsbClear.Enabled = true;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            tsbFirst.Enabled = false;
            tsbPrior.Enabled = false;
            tsbNext.Enabled = false;
            tsbLast.Enabled = false;

            tsbInsert.Enabled = true;
            tsbCancel.Enabled = true;
            tsbSave.Enabled = true;
            tsbInsert.Enabled = false;
            sl = "1";
        }
    }
}
