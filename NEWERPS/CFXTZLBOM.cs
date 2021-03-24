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
    public partial class CFXTZLBOM : Form
    {
        public CFXTZLBOM()
        {
            InitializeComponent();
        }

        #region 變數

        public DataSet ds = new DataSet();
        public DataSet dsY = new DataSet();
        public string userid = "";
        public string xiexing,shesho;
        string ypdh;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLBOM";

        #endregion

        #region 畫面載入

        private void CFXTZLBOM_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from YPZL where XieXing = '{0}' and SheHao = '{1}' order by YPDH", xiexing, shesho);
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView1.DataSource = ds.Tables[0];

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;
                ChangeDataView();
            }
            catch (Exception) { }

        }

        #endregion

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


            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //取出YPDH
                ypdh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //存取YPZLS
                dsY = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from YPZLS where YPDH = '{0}' order by XH", ypdh);
                Console.WriteLine(sql);

                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsY, "棧板表");

                int a = 0;
                a = dsY.Tables[0].Rows.Count;

                //檢查重複
                int co = 0;
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select count(XieXing) as count from xxzls  where XieXing = '{0}' and SheHao = '{1}'", xiexing, shesho);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    co = int.Parse(reader3["count"].ToString());
                }
                dbConn3.CloseConnection();

                int t = 0;
                DBconnect dbConn31 = new DBconnect();
                string sql31 = string.Format("select count(YPDH) as count from YPZLS where YPDH = '{0}' and CLBH like 'T%'", ypdh);
                SqlCommand cmd31 = new SqlCommand(sql31, dbConn31.connection);
                dbConn31.OpenConnection();
                SqlDataReader reader31 = cmd31.ExecuteReader();
                if (reader31.Read())
                {
                    t = int.Parse(reader31["count"].ToString());
                }
                dbConn31.CloseConnection();

                if (t == 0)
                {
                    if (co == 0)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            string cldj;
                            cldj = dsY.Tables[0].Rows[i][8].ToString();
                            if (cldj == "")
                            {
                                cldj = "0";
                            }

                            //寫入XXZLS

                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into xxzls (XieXing,SheHao,VER,BWBH,BWLB,xh,CLBH,CLTX,LOSS,CLSL,CLDJ,Currency,Remark,USERID,USERDATE,JGZWSM,JGYWSM,YN) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','1','{7}','{8}','{9}','{10}','{11}','{12}',GETDATE(),'{13}','{14}','1')", xiexing, shesho, "0", dsY.Tables[0].Rows[i][2].ToString(), "1", dsY.Tables[0].Rows[i][1].ToString(), dsY.Tables[0].Rows[i][4].ToString(), dsY.Tables[0].Rows[i][6].ToString(), dsY.Tables[0].Rows[i][7].ToString(), cldj, dsY.Tables[0].Rows[i][9].ToString(), dsY.Tables[0].Rows[i][11].ToString(), userid, dsY.Tables[0].Rows[i][12].ToString(), dsY.Tables[0].Rows[i][13].ToString());
                            Console.WriteLine(sql1);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();

                            #endregion

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete xxzls where  XieXing = '{0}' and SheHao = '{1}' insert into xxzls(XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, USERDATE, JGZWSM, JGYWSM)(select XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, CONVERT(varchar,USERDATE,11), JGZWSM, JGYWSM from [192.168.11.15].New_Erp.dbo.xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = '1')", xiexing, shesho);
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
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("資料重複 刪除舊資料?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete xxzls where XieXing = '{0}' and SheHao = '{1}'", xiexing, shesho);
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            for (int i = 0; i < a; i++)
                            {
                                string cldj;
                                cldj = dsY.Tables[0].Rows[i][8].ToString();
                                if (cldj == "")
                                {
                                    cldj = "0";
                                }

                                //寫入XXZLS
                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert into xxzls (XieXing,SheHao,VER,BWBH,BWLB,xh,CLBH,CLTX,LOSS,CLSL,CLDJ,Currency,Remark,USERID,USERDATE,JGZWSM,JGYWSM,YN) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','1','{7}','{8}','{9}','{10}','{11}','{12}',GETDATE(),'{13}','{14}','1')", xiexing, shesho, "0", dsY.Tables[0].Rows[i][2].ToString(), "1", dsY.Tables[0].Rows[i][1].ToString(), dsY.Tables[0].Rows[i][4].ToString(), dsY.Tables[0].Rows[i][6].ToString(), dsY.Tables[0].Rows[i][7].ToString(), cldj, dsY.Tables[0].Rows[i][9].ToString(), dsY.Tables[0].Rows[i][11].ToString(), userid, dsY.Tables[0].Rows[i][12].ToString(), dsY.Tables[0].Rows[i][13].ToString());
                                Console.WriteLine(sql1);
                                //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                conn.OpenConnection();
                                result = cmd1.ExecuteNonQuery();
                                if (result == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                conn.CloseConnection();
                            }

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("delete xxzls where  XieXing = '{0}' and SheHao = '{1}' insert into xxzls(XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, USERDATE, JGZWSM, JGYWSM)(select XieXing, SheHao, BWBH, BWLB, xh, CLBH, CLTX, LOSS, CLSL, CLDJ, Currency, Remark, USERID, CONVERT(varchar,USERDATE,11), JGZWSM, JGYWSM from [192.168.11.15].New_Erp.dbo.xxzls where XieXing = '{0}' and SheHao = '{1}' and YN = '1')", xiexing, shesho);
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
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("有臨時料號");
                }
            }
            catch (Exception) { }
        }
    }
}
