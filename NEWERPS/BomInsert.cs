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
    public partial class BomInsert : Form
    {
        public BomInsert()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet dsc1 = new DataSet();
        DataSet dsc2 = new DataSet();
        DataSet dsc3 = new DataSet();
        DataSet dsc4 = new DataSet();
        public string xiexing = "", shehao = "";
        public string userid = "";

        #endregion

        #region 畫面載入

        private void BomInsert_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(xiexing + shehao);
                tbxiexing.Text = xiexing;
                tbshehao.Text = shehao;

                userid = Program.User.userID;

                dsc1 = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select bwdh from bwzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dsc1, "倉庫");

                comboBox1.DataSource = dsc1.Tables[0];
                comboBox1.ValueMember = "bwdh";
                comboBox1.DisplayMember = "bwdh";
                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

                dsc2 = new DataSet();
                DBconnect dbconn2 = new DBconnect();
                string sql2 = "select * from zszl";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbconn2.connection);
                adapter2.Fill(dsc2, "倉庫");

                comboBox3.DataSource = dsc2.Tables[0];
                comboBox3.ValueMember = "zsdh";
                comboBox3.DisplayMember = "zsywjc";
                comboBox3.MaxDropDownItems = 8;
                comboBox3.IntegralHeight = false;

                //dsc3 = new DataSet();
                //DBconnect dbconn3 = new DBconnect();
                //string sql3 = "select cldh from clzl order by cldh";
                //SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbconn3.connection);
                //adapter3.Fill(dsc3, "倉庫");

                //comboBox3.DataSource = dsc3.Tables[0];
                //comboBox3.ValueMember = "cldh";
                //comboBox3.DisplayMember = "cldh";
                //comboBox3.MaxDropDownItems = 8;
                //comboBox3.IntegralHeight = false;

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        #endregion

        #region 事件

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    DataSet ds = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select cldh,ywpm,zwpm from clzl where cldh like '%{0}%' order by cldh", textBox3.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView2.DataSource = ds.Tables[0];
                    dbConn11.CloseConnection();
                }
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ver = "";
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select VER from xxzl where XieXing = '{0}' and SheHao = '{1}'", tbxiexing.Text, tbshehao.Text);
                Console.WriteLine(sql3);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    ver = reader3["VER"].ToString();
                }
                dbConn3.CloseConnection();
                Console.WriteLine("VER:" + ver);

                int count = 0;
                DBconnect dbConnc = new DBconnect();
                string sqlc = string.Format("select count(VER) as count from xxzls where BWBH = '{3}' and  XieXing = '{0}' and SheHao = '{1}' and VER = '{2}'", tbxiexing.Text, tbshehao.Text, ver, comboBox1.SelectedValue);
                Console.WriteLine(sqlc);
                SqlCommand cmdc = new SqlCommand(sqlc, dbConnc.connection);
                dbConnc.OpenConnection();
                SqlDataReader readerc = cmdc.ExecuteReader();
                if (readerc.Read())
                {
                    count = int.Parse(readerc["count"].ToString());
                }
                dbConnc.CloseConnection();
                Console.WriteLine("count:" + count);

                if (count == 0) 
                {
                    if (dataGridView2.Rows.Count != 0)
                    {
                        #region xxzls

                        #region NEWERP

                        DBconnect con5 = new DBconnect();
                        StringBuilder sql5 = new StringBuilder();
                        sql5.AppendFormat("update xxzl set VER = VER +1, USERID = '{0}', USERDATE = GETDATE()  where XieXing = '{1}' and SheHao = '{2}'", userid, tbxiexing.Text, tbshehao.Text);

                        Console.WriteLine(sql5);
                        SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                        con5.OpenConnection();
                        int result5 = cmd5.ExecuteNonQuery();
                        if (result5 == 1)
                        {

                        }
                        con5.CloseConnection();

                        #endregion

                        #region LYSHOE

                        DBconnect2 con5Y = new DBconnect2();
                        StringBuilder sql5Y = new StringBuilder();
                        sql5Y.AppendFormat("update xxzl set USERID = '{0}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{1}' and SheHao = '{2}'", userid, tbxiexing.Text, tbshehao.Text);

                        Console.WriteLine(sql5Y);
                        SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                        con5Y.OpenConnection();
                        int result5Y = cmd5Y.ExecuteNonQuery();
                        if (result5Y == 1)
                        {

                        }
                        con5Y.CloseConnection();

                        #endregion

                        int result;
                        DBconnect conn = new DBconnect();
                        string sql = string.Format("insert xxzls select XieXing,SheHao,{0}+1,BWBH,BWLB,xh,CLBH,CSBH,CLTX,CCQQ,CCQZ,LOSS,CLSL,CLDJ,Currency,Remark,'{1}',GETDATE(),JGZWSM,JGYWSM,YN from xxzls  where XieXing = '{2}' and SheHao = '{3}' and VER = {4}", ver, userid, tbxiexing.Text, tbshehao.Text, ver);
                        Console.WriteLine(sql);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn.CloseConnection();

                        //update YN
                        DBconnect conm2 = new DBconnect();
                        StringBuilder sqlm2 = new StringBuilder();
                        sqlm2.AppendFormat("update xxzls set YN = 0 where XieXing = '{0}' and SheHao = '{1}' and VER <> {2}+1", tbxiexing.Text, tbshehao.Text, ver);
                        Console.WriteLine(sqlm2);
                        SqlCommand cmdm2 = new SqlCommand(sqlm2.ToString(), conm2.connection);

                        conm2.OpenConnection();
                        int resultm2 = cmdm2.ExecuteNonQuery();
                        if (resultm2 == 1)
                        {

                        }
                        conm2.CloseConnection();

                        string xh = "";
                        DBconnect dbConn6 = new DBconnect();
                        string sql6 = string.Format("select MAX(xh)+5 as xh from xxzls  where  XieXing='{0}' and SheHao='{1}' and VER = {2}+1", tbxiexing.Text, tbshehao.Text, ver);
                        Console.WriteLine(sql6);
                        SqlCommand cmd6 = new SqlCommand(sql6, dbConn6.connection);
                        dbConn6.OpenConnection();
                        SqlDataReader reader6 = cmd6.ExecuteReader();
                        if (reader6.Read())
                        {
                            xh = reader6["xh"].ToString();
                        }
                        dbConn6.CloseConnection();
                        Console.WriteLine(xh);

                        int result4;
                        DBconnect conn4 = new DBconnect();
                        string sql4 = string.Format("insert into xxzls values('{0}','{1}',{2}+1,'{3}','{4}','{5}','{6}','{7}','{8}',null,null,'{9}','{10}',null,null,null,'{11}',GETDATE(),null,null,'1')", tbxiexing.Text, tbshehao.Text, ver, comboBox1.SelectedValue, comboBox2.SelectedIndex + 1, xh, dataGridView2.CurrentRow.Cells[0].Value.ToString(), comboBox3.SelectedValue, comboBox5.SelectedIndex + 1, textBox1.Text, textBox2.Text, userid);
                        Console.WriteLine(sql4);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd4 = new SqlCommand(sql4, conn4.connection);
                        conn4.OpenConnection();
                        result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn4.CloseConnection();

                        #region LYSHOE

                        int result4Y;
                        DBconnect2 conn4Y = new DBconnect2();
                        string sql4Y = string.Format("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID], CONVERT(varchar,USERDATE,11),[JGZWSM],[JGYWSM] FROM New_Erp.[dbo].[xxzls] where XieXing = '{0}' and SheHao = '{1}'", tbxiexing.Text, tbshehao.Text);
                        Console.WriteLine(sql4Y);

                        SqlCommand cmd4Y = new SqlCommand(sql4Y, conn4Y.connection);
                        conn4Y.OpenConnection();
                        result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {

                        }
                        conn4Y.CloseConnection();

                        #endregion

                        #endregion


                        #region USAGER

                        DataSet dsb = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select distinct XTCC from Usage_R where  XieXing='{0}' and SheHao= '{1}' and xxzlver = {2} ", tbxiexing.Text, tbshehao.Text, ver);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(dsb, "棧板表");

                        dataGridView1.DataSource = dsb.Tables[0];

                        dbConn11.CloseConnection();


                        int resulta;
                        DBconnect conna = new DBconnect();
                        string sqla = string.Format("insert into Usage_R select XieXing,SheHao,BWBH,XTCC,'1',CLSL,USERDATE,'{0}',{1}+1 from Usage_R where  XieXing = '{2}' and SheHao = '{3}' and xxzlver = {4}", userid, ver, tbxiexing.Text, tbshehao.Text, ver);

                        Console.WriteLine(sqla);
                        SqlCommand cmd1a = new SqlCommand(sqla, conna.connection);
                        conna.OpenConnection();
                        resulta = cmd1a.ExecuteNonQuery();
                        if (resulta == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conna.CloseConnection();


                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            int resultb;
                            DBconnect connb = new DBconnect();
                            string sqlb = string.Format("insert into Usage_R values('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE(),'{6}',{7}+1)", tbxiexing.Text, tbshehao.Text, comboBox1.SelectedValue, dataGridView1.Rows[i].Cells[0].Value.ToString(), "1", "0", userid, ver);

                            Console.WriteLine(sqlb);
                            SqlCommand cmd1b = new SqlCommand(sqlb, connb.connection);
                            connb.OpenConnection();
                            resultb = cmd1b.ExecuteNonQuery();
                            if (resultb == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connb.CloseConnection();
                        }

                        #region LYSHOE

                        int resultbY;
                        DBconnect2 connbY = new DBconnect2();
                        string sqlbY = string.Format("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}'  insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' ", tbxiexing.Text, tbshehao.Text);

                        Console.WriteLine(sqlbY);
                        SqlCommand cmd1bY = new SqlCommand(sqlbY, connbY.connection);
                        connbY.OpenConnection();
                        resultbY = cmd1bY.ExecuteNonQuery();
                        if (resultbY == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connbY.CloseConnection();

                        #endregion

                        #endregion

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("請選擇料號");
                    }
                }
                else 
                {
                    int count2 = 0;
                    DBconnect dbConnc2 = new DBconnect();
                    string sqlc2 = string.Format("select count(VER) as count from xxzls where BWBH = '{3}' and  XieXing = '{0}' and SheHao = '{1}' and VER = '{2}' and YN = 0", tbxiexing.Text, tbshehao.Text, ver, comboBox1.SelectedValue);
                    Console.WriteLine(sqlc2);
                    SqlCommand cmdc2 = new SqlCommand(sqlc2, dbConnc2.connection);
                    dbConnc2.OpenConnection();
                    SqlDataReader readerc2 = cmdc2.ExecuteReader();
                    if (readerc2.Read())
                    {
                        count2 = int.Parse(readerc2["count"].ToString());
                    }
                    dbConnc2.CloseConnection();
                    Console.WriteLine("count:" + count2);

                    if (count2 == 1)
                    {
                        if (dataGridView2.Rows.Count != 0)
                        {
                            #region xxzls

                            DBconnect con5 = new DBconnect();
                            StringBuilder sql5 = new StringBuilder();
                            sql5.AppendFormat("update xxzl set VER = VER +1, USERID = '{0}', USERDATE = GETDATE()  where XieXing = '{1}' and SheHao = '{2}'", userid, tbxiexing.Text, tbshehao.Text);

                            Console.WriteLine(sql5);
                            SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);

                            con5.OpenConnection();
                            int result5 = cmd5.ExecuteNonQuery();
                            if (result5 == 1)
                            {

                            }
                            con5.CloseConnection();

                            #region LYSHOE

                            DBconnect2 con5Y = new DBconnect2();
                            StringBuilder sql5Y = new StringBuilder();
                            sql5Y.AppendFormat("update xxzl set USERID = '{0}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{1}' and SheHao = '{2}'", userid, tbxiexing.Text, tbshehao.Text);

                            Console.WriteLine(sql5Y);
                            SqlCommand cmd5Y = new SqlCommand(sql5Y.ToString(), con5Y.connection);

                            con5Y.OpenConnection();
                            int result5Y = cmd5Y.ExecuteNonQuery();
                            if (result5Y == 1)
                            {

                            }
                            con5Y.CloseConnection();

                            #endregion


                            int result;
                            DBconnect conn = new DBconnect();
                            string sql = string.Format("insert xxzls select XieXing,SheHao,{0}+1,BWBH,BWLB,xh,CLBH,CSBH,CLTX,CCQQ,CCQZ,LOSS,CLSL,CLDJ,Currency,Remark,'{1}',GETDATE(),JGZWSM,JGYWSM,YN from xxzls  where XieXing = '{2}' and SheHao = '{3}' and VER = {4}", ver, userid, tbxiexing.Text, tbshehao.Text, ver);
                            Console.WriteLine(sql);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1 = new SqlCommand(sql, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();

                            //update YN
                            DBconnect conm2 = new DBconnect();
                            StringBuilder sqlm2 = new StringBuilder();
                            sqlm2.AppendFormat("update xxzls set YN = 0 where XieXing = '{0}' and SheHao = '{1}' and VER <> {2}+1", tbxiexing.Text, tbshehao.Text, ver);
                            Console.WriteLine(sqlm2);
                            SqlCommand cmdm2 = new SqlCommand(sqlm2.ToString(), conm2.connection);

                            conm2.OpenConnection();
                            int resultm2 = cmdm2.ExecuteNonQuery();
                            if (resultm2 == 1)
                            {

                            }
                            conm2.CloseConnection();


                            string xh = "";
                            DBconnect dbConn6 = new DBconnect();
                            string sql6 = string.Format("select MAX(xh)+5 as xh from xxzls  where  XieXing='{0}' and SheHao='{1}' and VER = {2}+1", tbxiexing.Text, tbshehao.Text, ver);
                            Console.WriteLine(sql6);
                            SqlCommand cmd6 = new SqlCommand(sql6, dbConn6.connection);
                            dbConn6.OpenConnection();
                            SqlDataReader reader6 = cmd6.ExecuteReader();
                            if (reader6.Read())
                            {
                                xh = reader6["xh"].ToString();
                            }
                            dbConn6.CloseConnection();
                            Console.WriteLine(xh);



                            DBconnect conm4 = new DBconnect();
                            StringBuilder sqlm4 = new StringBuilder();
                            sqlm4.AppendFormat("update xxzls set BWBH = '{0}',BWLB = '{1}',CLBH = '{2}',CSBH = '{3}',CLTX = '{4}' ,LOSS = '{5}',CLSL = '{6}', YN = 1 where XieXing = '{7}' and SheHao = '{8}' and VER = {9}+1 and BWBH = '{0}'", comboBox1.SelectedValue, comboBox2.SelectedIndex + 1, dataGridView2.CurrentRow.Cells[0].Value.ToString(), comboBox3.SelectedValue, comboBox5.SelectedIndex + 1, textBox1.Text, textBox2.Text, tbxiexing.Text, tbshehao.Text, ver);
                            Console.WriteLine(sqlm4);
                            SqlCommand cmdm4 = new SqlCommand(sqlm4.ToString(), conm4.connection);

                            conm4.OpenConnection();
                            int resultm4 = cmdm4.ExecuteNonQuery();
                            if (resultm4 == 1)
                            {

                            }
                            conm4.CloseConnection();

                            #region LYSHOE

                            int result4Y;
                            DBconnect2 conn4Y = new DBconnect2();
                            string sql4Y = string.Format("delete xxzls where XieXing = '{0}' and SheHao = '{1}' insert into xxzls SELECT[XieXing],[SheHao],[xh],[BWBH],[BWLB],[CLBH],[CSBH],[CLTX],[CCQQ],[CCQZ],[LOSS],[CLSL],[CLDJ],[Currency],[Remark],[USERID], CONVERT(varchar,USERDATE,11),[JGZWSM],[JGYWSM] FROM New_Erp.[dbo].[xxzls] where XieXing = '{0}' and SheHao = '{1}'", tbxiexing.Text, tbshehao.Text);
                            Console.WriteLine(sql4Y);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd4Y = new SqlCommand(sql4Y, conn4Y.connection);
                            conn4Y.OpenConnection();
                            result4Y = cmd4Y.ExecuteNonQuery();
                            if (result4Y == 1)
                            {

                            }
                            conn4Y.CloseConnection();

                            #endregion

                            #endregion


                            #region USAGER

                            DataSet dsb = new DataSet();
                            DBconnect dbConn11 = new DBconnect();
                            string sql1 = string.Format("select distinct XTCC from Usage_R where  XieXing='{0}' and SheHao= '{1}' and xxzlver = {2} ", tbxiexing.Text, tbshehao.Text, ver);
                            Console.WriteLine(sql1);
                            SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                            adapter.Fill(dsb, "棧板表");

                            dataGridView1.DataSource = dsb.Tables[0];

                            dbConn11.CloseConnection();


                            int resulta;
                            DBconnect conna = new DBconnect();
                            string sqla = string.Format("insert into Usage_R select XieXing,SheHao,BWBH,XTCC,'1',CLSL,USERDATE,'{0}',{1}+1 from Usage_R where  XieXing = '{2}' and SheHao = '{3}' and xxzlver = {4}", userid, ver, tbxiexing.Text, tbshehao.Text, ver);

                            Console.WriteLine(sqla);
                            SqlCommand cmd1a = new SqlCommand(sqla, conna.connection);
                            conna.OpenConnection();
                            resulta = cmd1a.ExecuteNonQuery();
                            if (resulta == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conna.CloseConnection();


                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                int resultb;
                                DBconnect connb = new DBconnect();
                                string sqlb = string.Format("insert into Usage_R values('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE(),'{6}',{7}+1)", tbxiexing.Text, tbshehao.Text, comboBox1.SelectedValue, dataGridView1.Rows[i].Cells[0].Value.ToString(), "1", "0", userid, ver);

                                Console.WriteLine(sqlb);
                                SqlCommand cmd1b = new SqlCommand(sqlb, connb.connection);
                                connb.OpenConnection();
                                resultb = cmd1b.ExecuteNonQuery();
                                if (resultb == 1)
                                {
                                    //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                connb.CloseConnection();
                            }

                            #region LYSHOE

                            int resultbY;
                            DBconnect2 connbY = new DBconnect2();
                            string sqlbY = string.Format("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}'  insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}' ", tbxiexing.Text, tbshehao.Text);

                            Console.WriteLine(sqlbY);
                            SqlCommand cmd1bY = new SqlCommand(sqlbY, connbY.connection);
                            connbY.OpenConnection();
                            resultbY = cmd1bY.ExecuteNonQuery();
                            if (resultbY == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            connbY.CloseConnection();

                            #endregion

                            #endregion

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("請選擇料號");
                        }
                    }
                    else
                    {
                        MessageBox.Show("部位重複");
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion
    }
}
