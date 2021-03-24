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
    public partial class CFXTZLCopy : Form
    {
        public CFXTZLCopy()
        {
            InitializeComponent();
        }

        #region 變數

        public string FXie = "", FShe = "";
        DataSet ds3B = new DataSet();
        public string shesho = "";
        public string Xiexing = "";
        public string userid = "";
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLCopy";

        #endregion

        #region 方法

        #region 備份

        private void BackXie()
        {
            #region 讀取廠商

            ds3B = new DataSet();
            DBconnect dbConn2 = new DBconnect();
            string sql2 = string.Format("select * from xxzl where XieXing = '{0}' and SheHao = '{1}'", textBox1.Text, textBox3.Text);
            Console.WriteLine(sql2);
            SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
            adapter.Fill(ds3B, "棧板表");

            Console.WriteLine(ds3B.Tables[0].Rows[0][0].ToString());
            Console.WriteLine(ds3B.Tables[0].Rows[0][1].ToString());

            #endregion
        }

        #endregion

        private void MaxShesho() 
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select isnull(MAX(SheHao)+1,0) as max from xxzl where XieXing = '{0}'", textBox2.Text); SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    shesho = reader2["max"].ToString();
                }

                if (shesho.Length == 1)
                {
                    shesho = "0" + shesho;
                }
                Console.WriteLine(shesho);
            }
            catch (Exception) { }
        }

        private void Insertxxzl() 
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxzl (XieXing,SheHao,VER,XieMing,YSSM,JiJie,CLID,ARTICLE,BZCC,XieGN,KFCQ,LOGO,KHDH,CCGB,XTGJ,XTMH,DMGJ,DDMH,MSGJ,MDMH,DAOGJ,DAOMH,IMGName,GENDER,USERID,USERDATE) values ('{0}', '{1}', '1', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}',GETDATE())", textBox2.Text, shesho, ds3B.Tables[0].Rows[0][3].ToString(), ds3B.Tables[0].Rows[0][4].ToString(), ds3B.Tables[0].Rows[0][5].ToString(), ds3B.Tables[0].Rows[0][6].ToString(), ds3B.Tables[0].Rows[0][7].ToString(), ds3B.Tables[0].Rows[0][8].ToString(), ds3B.Tables[0].Rows[0][9].ToString(), ds3B.Tables[0].Rows[0][10].ToString(), ds3B.Tables[0].Rows[0][11].ToString(), ds3B.Tables[0].Rows[0][12].ToString(), ds3B.Tables[0].Rows[0][13].ToString(), ds3B.Tables[0].Rows[0][14].ToString(), ds3B.Tables[0].Rows[0][15].ToString(), ds3B.Tables[0].Rows[0][16].ToString(), ds3B.Tables[0].Rows[0][17].ToString(), ds3B.Tables[0].Rows[0][18].ToString(), ds3B.Tables[0].Rows[0][19].ToString(), ds3B.Tables[0].Rows[0][20].ToString(), ds3B.Tables[0].Rows[0][21].ToString(), ds3B.Tables[0].Rows[0][22].ToString(), ds3B.Tables[0].Rows[0][34].ToString(), userid);
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

                #endregion

                #region LYSHOE

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete xxzl where XieXing = '{0}' and SheHao = '{1}' insert into xxzl SELECT[XieXing],[SheHao],[XieMing],[YSSM],[JiJie],[CLID],[ARTICLE],[BZCC],[XieGN],[KFCQ],[LOGO],[KHDH],[CCGB],[XTGJ],[XTMH],[DMGJ],[DDMH],[MSGJ],[MDMH],[DAOGJ],[DAOMH],[IMGName],[Currency],[QPrice],[OPrice],[IPrice],[CPrice],[USERID],CONVERT(varchar,USERDATE,11),[KFXXCZ],[KFXXCZ1],[KFXXCZ2],[KFXXCZ3],[GENDER],[pp],[memo1],[JiJie1],[MTF],[JZF],[xxlock] FROM [192.168.11.15].New_Erp.dbo.[xxzl] where XieXing = '{0}' and SheHao = '{1}'", textBox2.Text, shesho);
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

        private void Insertxxzls()
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxzls select '{0}','{1}', '1', BWBH, BWLB, xh,CLBH,CSBH,CLTX,CCQQ,CCQZ,LOSS,CLSL,CLDJ,Currency,Remark,'{2}',GETDATE(),JGZWSM,JGYWSM from xxzls where XieXing = '{3}' and SheHao = '{4}'", textBox2.Text, shesho, userid, textBox1.Text, textBox3.Text);
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
                string sql1Y = string.Format("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID],CONVERT(varchar,USERDATE,11),[JGZWSM],[JGYWSM] FROM [192.168.11.15].New_Erp.dbo.[xxzls] where XieXing = '{0}' and SheHao = '{1}' and VER = '1'", textBox2.Text, shesho);
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

        private void Insertxxgj()
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxgj select '{0}','{1}',GJLB,gjmh,'{2}',getdate(),bdate,edate,stat,bz from xxgj where XieXing = '{3}' and SheHao = '{4}'", textBox2.Text, shesho, userid, textBox1.Text, textBox3.Text);
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
                string sql1Y = string.Format("delete ly_shoe.dbo.xxgj where xiexing = '{0}' insert into ly_shoe.dbo.xxgj select xiexing, gjlb, MAX(userid), CONVERT(varchar,max(USERDATE),11), null, null, null, null from [192.168.11.15].New_Erp.dbo.xxgj where XieXing = '{0}' group by xiexing, gjlb", textBox2.Text);
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
            catch (Exception) { }
        }

        private void Insertxxgjs()
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into xxgjs select '{0}','{1}',GJLB,LineNum,XXCC,GJCC,'{2}',GETDATE(),Gjmh,BB,Mtdj,Crdj,stat,Bdate,Bz from xxgjs where XieXing = '{3}' and SheHao = '{4}'", textBox2.Text, shesho, userid, textBox1.Text, textBox3.Text);
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

                #region NEWERP

                int resultY;
                DBconnect2 connY = new DBconnect2();
                string sql1Y = string.Format("delete ly_shoe.dbo.xxgjs where xiexing='{0}'  insert into xxgjs select xiexing, gjlb, LineNum, xxcc, gjcc, max(USERID), CONVERT(varchar,max(USERDATE),11), gjmh, bb, Mtdj, crdj, stat, Bdate, Bz from [192.168.11.15].New_Erp.dbo.xxgjs where XieXing = '{0}' group by xiexing, gjlb, LineNum, xxcc, gjcc, gjmh, bb, Mtdj, crdj, stat, Bdate, Bz", textBox2.Text);
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
            catch (Exception) { }
        }

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
                    //dataGridView1.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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

        #endregion

        #region 事件

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("鞋型為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                //備份
                BackXie();
                //取最大值
                MaxShesho();
                //插入
                Insertxxzl();
                Insertxxzls();
                Insertxxgj();
                Insertxxgjs();
                Xiexing = textBox1.Text;
                this.Close();

                //XXGJ XXGJS
            }
        }

        #endregion

        #region 畫面載入

        private void CFXTZLCopy_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                textBox1.Text = FXie;
                textBox3.Text = FShe;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
            }
            catch (Exception) { }

        }

        #endregion

    }
}
