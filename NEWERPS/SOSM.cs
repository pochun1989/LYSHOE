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
    /// <summary>
    /// SampleOrderShoeModel 樣品單鞋型附值
    /// </summary>
    public partial class SOSM : Form
    {
        #region 變數

        DataSet ds = new DataSet();
        DataSet dsBrand = new DataSet();
        public string 鞋型, 色號, ART, 季節, 開發類型, 尺寸國別, 顏色說明, 客戶代號, 樣品編號, 開發人員;
        public bool isc = false; // 是否選擇資料

        #endregion

        #region 構造函式

        public SOSM()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void SampleOrderShoeModel_Load(object sender, EventArgs e)
        {
            GetBrand();
        } 

        #endregion

        #region 查詢按鈕事件

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryDevModel(cbBrand.SelectedValue.ToString(), tbShoeModel.Text);
        }

        #endregion

        #region DGV雙點擊事件
        
        private void dgvShowModel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.鞋型 = this.dgvShowModel.CurrentRow.Cells[0].Value.ToString();
            this.色號 = this.dgvShowModel.CurrentRow.Cells[1].Value.ToString();
            this.ART = this.dgvShowModel.CurrentRow.Cells[2].Value.ToString();
            this.季節 = this.dgvShowModel.CurrentRow.Cells[3].Value.ToString();
            this.開發類型 = this.dgvShowModel.CurrentRow.Cells[4].Value.ToString();
            this.尺寸國別 = this.dgvShowModel.CurrentRow.Cells[5].Value.ToString();
            this.顏色說明 = this.dgvShowModel.CurrentRow.Cells[6].Value.ToString();
            this.客戶代號 = this.dgvShowModel.CurrentRow.Cells[7].Value.ToString();
            this.樣品編號 = this.dgvShowModel.CurrentRow.Cells[8].Value.ToString();
            this.開發人員 = this.dgvShowModel.CurrentRow.Cells[9].Value.ToString();
            this.isc = true;
            this.Close();
        }

        #endregion

        #endregion

        #region 方法

        #region 下拉選單載入(品牌)

        private void GetBrand()
        {
            dsBrand = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 品牌
                string sql = "select kfdh,kfjc from kfzl order by kfjc";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsBrand, "品牌表");
                cbBrand.DataSource = dsBrand.Tables[0];
                cbBrand.ValueMember = "kfdh";
                cbBrand.DisplayMember = "kfjc";
            }
            catch (Exception)
            {
                MessageBox.Show("Brand Combobox Diplay Error");
            }
        }

        #endregion

        #region 查詢開發型體方法

        private void QueryDevModel(string brand,string XieXing)
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select kx.XieXing 鞋型,kx.SheHao 色號,kx.ARTICLE 'ART.NAME',kx.JiJie 季節,dc.DC_Number 開發類型,kx.CCGB 尺寸國別,kx.YSSM 顏色說明,kx.KHDH,kx.DEVCODE,kx.USERID " +
                    "from kfxxzl kx " +
                    "left join Dev_Class dc on dc.DC_ID=kx.DevType " +
                    "where kx.KHDH ='{0}' and kx.XieXing like'%{1}%'"
                    , brand, XieXing);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "開發類型表");
                this.dgvShowModel.DataSource = this.ds.Tables[0];
                this.dgvShowModel.Columns[7].Visible = false;
                this.dgvShowModel.Columns[8].Visible = false;
                this.dgvShowModel.Columns[9].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Query Data Error!");
            }
        }

        #endregion

        #endregion


    }
}
