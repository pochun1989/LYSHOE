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
    /// MaterialClassSetDetail 材料分類操作頁
    /// </summary>
    public partial class MaterialCSD : Form
    {
        #region 變數

        public string USERID;
        public bool dgvAOrB = true; // 判斷主材料表或子材料表 
        public string InsorMod; // 判斷新增或編輯
        public string publicText, classID, publicTextEN; // 外部附值字串(中文說明), 類別代號, 英文說明

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MaterialCSD";

        #endregion

        #region 構造函式

        public MaterialCSD()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MaterialClassSetDetail_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            SelectFunction(); // 判斷主材料或子材料觸發

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            //更改語言
            ChangeLabel();
            ChangeDataView();
        } 

        #endregion

        #region 保存按鈕事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(InsorMod == "Insert") // 新增資料
            {
                InsertMaterialClass();
            }
            else // 編輯資料
            {
                ModifyMaterialClass();
            }
        }

        #endregion

        #region 離開頁面事件

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

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
                int r = dgvWord.Rows.Count;

                for (int i = 0; i < r; i++)
                {
                    dgvWord.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 判斷主材料或子材料觸發

        private void SelectFunction()
        {
            if (this.dgvAOrB && InsorMod == "Insert") // 主材料新增
            {
                lbMCSD.Text = "Insert Main";
                L0001.Text = "類別代號";
                tbClass.MaxLength = 1;
            }
            else if (this.dgvAOrB && InsorMod == "Modify") // 主材料編輯
            {
                lbMCSD.Text = "編輯 " + publicText + " 主材料";
                L0001.Text = "類別代號";
                tbClass.MaxLength = 1;
                GetModifyData();
            }
            else if (!this.dgvAOrB && InsorMod == "Insert") // 子材料新增
            {
                lbMCSD.Text = "新增 " + publicText + " 的子材料";
                L0001.Text = "材料類別";
                tbClass.MaxLength = 3;
            }
            else if (!this.dgvAOrB && InsorMod == "Modify") // 子材料編輯
            {
                lbMCSD.Text = "編輯" + publicText + " 的子材料";
                L0001.Text = "材料類別";
                tbClass.MaxLength = 3;
                GetModifyData();
            }
        }

        #endregion

        #region 編輯載入TEXTBOX

        private void GetModifyData()
        {
            tbClass.Text = classID;
            tbClassNameCN.Text = publicText;
            tbClassNameEN.Text = publicTextEN;
        }

        #endregion

        #region 新增材料方法

        private void InsertMaterialClass()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (this.dgvAOrB) // 主材料新增
                {
                    string sql = string.Format("insert into CLASS_A " +
                        "values('{0}','{1}','{2}','{3}','{4}')"
                        , tbClass.Text, tbClassNameCN.Text, tbClassNameEN.Text
                        , USERID, DateTime.Today.ToString("yyyyMMdd"));
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Insert Main Success!");
                        this.Close();
                    }
                }
                else // 子材料新增
                {
                    string sql = string.Format("insert into CLASS_B " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}')"
                        , tbClass.Text, classID, tbClassNameCN.Text, tbClassNameEN.Text
                        , USERID, DateTime.Today.ToString("yyyyMMdd"));
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Insert " + publicText + " Detail Success!");
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }

        }

        #endregion

        #region 編輯材料方法

        private void ModifyMaterialClass()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (this.dgvAOrB) // 主材料編輯
                {
                    string sql = string.Format("update CLASS_A " +
                        "set Class_ID='{0}',zwsm='{1}',ywsm='{2}',USERID='{3}',USERDATE='{4}' " +
                        "where Class_ID='{5}'"
                        , tbClass.Text, tbClassNameCN.Text, tbClassNameEN.Text
                        , USERID, DateTime.Today.ToString("yyyyMMdd"), classID);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Modify Main Success!");
                        this.Close();
                    }
                }
                else // 子材料編輯
                {
                    string sql = string.Format("update CLASS_B " +
                        "set cllb='{0}',zwsm='{1}',ywsm='{2}',USERID='{3}',USERDATE='{4}' " +
                        "where Class_ID='{5}'"
                        , tbClass.Text, tbClassNameCN.Text, tbClassNameEN.Text
                        , USERID, DateTime.Today.ToString("yyyyMMdd"), classID);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Modify " + publicText + " Detail Success!");
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion


    }
}
