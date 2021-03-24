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
    public partial class OBUSelect : Form
    {

        #region 建構函式

        #endregion
        public OBUSelect()
        {
            InitializeComponent();
        }

        #region 變數
        DataSet ds = new DataSet(); // 儲存資料表容器     
        public string obucode;
        public string userid = "";
        public string 廠代, OBU名, OBU, 地址, OBU址, 統編, OBU電話, OBU傳真, 採購地址, 採購電話;

        public DataSet dsl = new DataSet();
        public string userLanguage;
        string userForm = "1_2_2";

        #endregion

        #region 畫面載入

        private void OBUSelect_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            LoadOBU();

            ChangeDataView();
        }

        #endregion

        #region 方法

        #region 多語言



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
                dgvOBU.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dgvOBU.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dgvOBU.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dgvOBU.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dgvOBU.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dgvOBU.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dgvOBU.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dgvOBU.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dgvOBU.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dgvOBU.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dgvOBU.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();
                dgvOBU.Columns[11].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dgvOBU.Columns[12].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dgvOBU.Columns[13].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion



        #endregion

        #region 載入方法

        private void LoadOBU()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {

                string sql = "select * from gszl";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                this.dgvOBU.DataSource = this.ds.Tables[0];

                //dgvPallet.Columns[2].FillWeight = 180;
                //dgvPallet.Columns[4].FillWeight = 180;
            }
            catch (Exception)
            {
                MessageBox.Show("OBU資料載入失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #endregion

        #region 事件        

        private void DgvOBU_DoubleClick_1(object sender, EventArgs e)
        {
            廠代 = dgvOBU.CurrentRow.Cells[0].Value.ToString();
            OBU名 = dgvOBU.CurrentRow.Cells[1].Value.ToString();
            OBU = dgvOBU.CurrentRow.Cells[2].Value.ToString();
            地址 = dgvOBU.CurrentRow.Cells[3].Value.ToString();
            OBU址 = dgvOBU.CurrentRow.Cells[4].Value.ToString();
            統編 = dgvOBU.CurrentRow.Cells[5].Value.ToString();
            OBU電話 = dgvOBU.CurrentRow.Cells[7].Value.ToString();
            OBU傳真 = dgvOBU.CurrentRow.Cells[6].Value.ToString();
            採購地址 = dgvOBU.CurrentRow.Cells[3].Value.ToString();
            採購電話 = dgvOBU.CurrentRow.Cells[7].Value.ToString();

            this.Close();


            //DBconnect con4 = new DBconnect();
            //StringBuilder sql4 = new StringBuilder();
            //sql4.AppendFormat("update cqzl set OBU  = '{0}',USERID = '{1}' where cqdh = '{2}'", dgvOBU.CurrentRow.Cells[0].Value.ToString(),userid, obucode);
            //SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
            //con4.OpenConnection();
            //int result4 = cmd4.ExecuteNonQuery();
            //if (result4 == 1)
            //{
            //    MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
        }
        #endregion
    }

}
