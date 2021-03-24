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
    public partial class LanguageQuery : Form
    {
        public LanguageQuery()
        {
            InitializeComponent();
        }
        #region 變數

        public DataSet ds2 = new DataSet();

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "1_10_3";

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


        #region 文字定位

        private void WordPosition()
        {
            try
            {
                L0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #endregion

        private void queryData()
        {
            try
            {
                ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select distinct a.FORM_ID,a.LAB_ID,b.SHOW_DATA as '中文', c.SHOW_DATA as '英文' ,d.SHOW_DATA as '越文' ,e.SHOW_DATA as '緬甸文' from MMDATA as a left join(select * from MMDATA where MM_ID = 1 ) as b on a.FORM_ID = b.FORM_ID and a.LAB_ID = b.LAB_ID left join(select * from MMDATA  where MM_ID = 2 ) as c on a.FORM_ID = c.FORM_ID and a.LAB_ID = c.LAB_ID left join(select * from MMDATA where MM_ID = 3 ) as d on a.FORM_ID = d.FORM_ID and a.LAB_ID = d.LAB_ID left join(select * from MMDATA where MM_ID = 4 ) as e on a.FORM_ID = e.FORM_ID and a.LAB_ID = e.LAB_ID where a.FORM_ID like '{0}%' order by a.FORM_ID  ", tb表單.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds2, "棧板表");
                //this.dataGridView1.DataSource = this.ds2.Tables[0];
                this.Close();
            }
            catch (Exception) { }
        }

        private void B0001_Click(object sender, EventArgs e)
        {
            queryData();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LanguageQuery_Load(object sender, EventArgs e)
        {
            ChangeLabel();
        }
    }
}
