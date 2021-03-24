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
    public partial class SampleConfirm : Form
    {
        public SampleConfirm()
        {
            InitializeComponent();
        }
        #region 變數
        DataSet dsUS = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds12 = new DataSet();
        string date;
        DateTime mydate;
        public string userid = "";
        string modify = "";
        string sqlagain = "";
        #endregion

        #region 畫面載入
        private void SampleConfirm_Load(object sender, EventArgs e)
        {

            try
            {
                userid = Program.User.userID;
            }
            catch (Exception) 
            {
                MessageBox.Show("ERROR");
            }

        }
        #endregion

        #region 方法

        #region 查詢方法

        private void Query() 
        {
            try
            {
                if (textBox3.Text != "")
                {
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select zsdh from zszl where zsywjc like '{0}%'", textBox3.Text);
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                    dbConn.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) //有資料
                    {
                        textBox2.Text = reader["zsdh"].ToString();
                    }
                }


                if (textBox1.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select distinct a.CGNO,a.CKBH ,a.ZSBH,b.zsywjc,convert(varchar(10),a.CGDate,111) as CGDate, a.GSBH, a.USERID,convert(varchar(10),a.CFMdate,111) as CFMDate, a.YN,convert(varchar(10),a.USERDate,111) as USERDate from (select * from CGZL where YN != 0) as a left join (select * from zszl) as b on a.ZSBH = b.zsdh  where a.CGDate between DATEADD(DAY,-1 ,'{0}')  and '{1}' and a.CGNO = '{2}' ", dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), textBox1.Text);
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter.Fill(ds2, "棧板表");
                    sqlagain = sql2;
                    dataGridView1.DataSource = ds2.Tables[0];
                }
                else if (textBox2.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select distinct a.CGNO,a.CKBH ,a.ZSBH,b.zsywjc,convert(varchar(10),a.CGDate,111) as CGDate, a.GSBH, a.USERID,convert(varchar(10),a.CFMdate,111) as CFMDate, a.YN,convert(varchar(10),a.USERDate,111) as USERDate from (select * from CGZL where YN != 0) as a left join (select * from zszl) as b on a.ZSBH = b.zsdh where a.CGDate between DATEADD(DAY,-1 ,'{0}')  and '{1}' and a.ZSBH = '{2}'", dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), textBox2.Text);
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter.Fill(ds2, "棧板表");
                    sqlagain = sql2;
                    dataGridView1.DataSource = ds2.Tables[0];
                }
                else if (textBox3.Text != "")
                {
                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select distinct a.CGNO,a.CKBH ,a.ZSBH,b.zsywjc,convert(varchar(10),a.CGDate,111) as CGDate, a.GSBH, a.USERID,convert(varchar(10),a.CFMdate,111) as CFMDate, a.YN,convert(varchar(10),a.USERDate,111) as USERDate from (select * from CGZL where YN != 0) as a left join (select * from zszl) as b on a.ZSBH = b.zsdh where a.CGDate between DATEADD(DAY,-1 ,'{0}')  and '{1}' and a.ZSBH = '{2}'", dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), textBox2.Text);
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter.Fill(ds2, "棧板表");
                    sqlagain = sql2;
                    dataGridView1.DataSource = ds2.Tables[0];
                }
                else 
                {
                    ds2 = new DataSet();
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select distinct a.CGNO,a.CKBH ,a.ZSBH,b.zsywjc,convert(varchar(10),a.CGDate,111) as CGDate, a.GSBH, a.USERID,convert(varchar(10),a.CFMdate,111) as CFMDate, a.YN,convert(varchar(10),a.USERDate,111) as USERDate from (select * from CGZL where YN != 0) as a left join (select * from zszl) as b on a.ZSBH = b.zsdh where a.CGDate between DATEADD(DAY,-1 ,'{0}')  and '{1}' and a.YN != 0 ", dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
                    Console.WriteLine(sql2);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                    adapter.Fill(ds2, "棧板表");
                    sqlagain = sql2;
                    dataGridView1.DataSource = ds2.Tables[0];
                }                                             

            }
            catch (Exception) { }
        }



        #endregion

        #endregion

        #region 事件

        #endregion

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            Query();
            Color();
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {

            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                try
                {                  
                    
                        tsbSave.Enabled = true;
                        tsbModify.Enabled = false;
                        tsbCancel.Enabled = true;
                        //檢查日期
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select count(CGNO) as count from CGZL where CGNO  = '{0}' and CGDate > DATEADD(DAY,-10,GETDATE())", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            modify = reader["count"].ToString();
                        }


                        if (modify == "1")        //未超出10日
                        {
                            //SamConDate Form = new SamConDate();
                            //Form.ShowDialog();
                            //date = Form.sampledate;
                            //dataGridView2.CurrentRow.Cells[9].Value = date;
                            Console.WriteLine("ReadOnly");

                            dataGridView2.ReadOnly = false;
                        }
                        else
                        {
                            MessageBox.Show("超出修改期10天", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsbSave.Enabled = false;
                            tsbModify.Enabled = true;
                            tsbCancel.Enabled = false;
                        }
                    //}
                    //else 
                    //{
                    //    MessageBox.Show("NO YQDATE", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
                catch (Exception) { }
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView2.IsCurrentCellInEditMode)
                {
                    this.dataGridView2.CurrentCell = null;
                }

                Program.Modifytype.modify = "0";

                //檢查編輯行
                int a = 0;
                a = ds12.Tables[0].Rows.Count;
                Console.WriteLine(a);

                for (int i = 0; i < a; i++)
                {

                    if (ds12.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                    {

                    }
                    else if (ds12.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                    {
                        Console.WriteLine(ds12.Tables[0].Rows[i].RowState.ToString());
                        string dgdate = "";

                        //檢查DGDATE
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select count(CGNO) as CGNO from CGZLS where CGNO = '{0}'  and CLBH ='{1}' and DGDATE is null", dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            dgdate = reader["CGNO"].ToString();
                        }


                        if (dgdate == "1") //有第一次日期
                        {
                            if (dataGridView2.Rows[i].Cells[9].Value.ToString() != "")
                            {
                                DBconnect con4 = new DBconnect();
                                StringBuilder sql4 = new StringBuilder();
                                sql4.AppendFormat("update CGZLS set ETA = '{0}' , CFMDate = GETDATE(), USERDate = GETDATE(), USERID = '{1}', DGDATE = '{2}', Qty = '{3}', USPrice = '{4}', VNPrice = '{5}' where CGNO = '{6}' and CLBH = '{7}'", dataGridView2.Rows[i].Cells[9].Value.ToString(), userid, dataGridView2.Rows[i].Cells[9].Value.ToString(), dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[5].Value.ToString(), dataGridView2.Rows[i].Cells[6].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString());

                                Console.WriteLine(sql4);
                                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                con4.OpenConnection();
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {

                                }

                                con4.CloseConnection();
                            }
                        }
                        else if (dgdate == "0")  //DG不動
                        {
                            if (dataGridView2.Rows[i].Cells[9].Value.ToString() != "")
                            {
                                DBconnect con4 = new DBconnect();
                                StringBuilder sql4 = new StringBuilder();
                                sql4.AppendFormat("update CGZLS set ETA = '{0}' , CFMDate = GETDATE(), USERDate = GETDATE(), USERID = '{1}' , Qty = '{2}', USPrice = '{3}', VNPrice = '{4}' where CGNO = '{5}' and CLBH = '{6}'", dataGridView2.Rows[i].Cells[9].Value.ToString(), userid, dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[5].Value.ToString(), dataGridView2.Rows[i].Cells[6].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString());

                                Console.WriteLine(sql4);
                                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                                con4.OpenConnection();
                                int result4 = cmd4.ExecuteNonQuery();
                                if (result4 == 1)
                                {

                                }

                                con4.CloseConnection();
                            }
                        }

                        //update CGZL
                        DBconnect con4l = new DBconnect();
                        StringBuilder sql4l = new StringBuilder();
                        sql4l.AppendFormat("update CGZL set CFMdate = GETDATE(),USERID = '{0}', USERDate = GETDATE() where CGNO = '{1}' and ZSBH = '{2}'", userid, dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString());

                        Console.WriteLine(sql4l);
                        SqlCommand cmd4l = new SqlCommand(sql4l.ToString(), con4l.connection);
                        con4l.OpenConnection();
                        int result4l = cmd4l.ExecuteNonQuery();
                        if (result4l == 1)
                        {

                        }

                        con4l.CloseConnection();

                        DBconnect con5s = new DBconnect();
                        StringBuilder sql5s = new StringBuilder();
                        sql5s.AppendFormat("update CGZLS set Qty = '{0}', CFMDate = GETDATE() where CGNO = '{1}' and CLBH = '{2}'", dataGridView2.Rows[i].Cells[4].Value.ToString(), dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString());

                        Console.WriteLine(sql5s);
                        SqlCommand cmd5s = new SqlCommand(sql5s.ToString(), con5s.connection);
                        con5s.OpenConnection();
                        int result5s = cmd5s.ExecuteNonQuery();
                        if (result5s == 1)
                        {

                        }
                        con5s.CloseConnection();

                        DBconnect con5ss = new DBconnect();
                        StringBuilder sql5ss = new StringBuilder();
                        sql5ss.AppendFormat("update CGZLSS set CFMDate = GETDATE() where CGNO = '{0}' and CLBH = '{1}'", dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString());

                        Console.WriteLine(sql5ss);
                        SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                        con5ss.OpenConnection();
                        int result5ss = cmd5ss.ExecuteNonQuery();
                        if (result5ss == 1)
                        {

                        }
                        con5ss.CloseConnection();

                    }
                }
                                               
                YN();
                Color();
                //修改CGZLS


                    //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                tsbModify.Enabled = true;
                dataGridView2.ReadOnly = true;

            }
            catch (Exception) { }
        }

        private void YN() 
        {
            try
            {
                //選出CFM
                int CFM = 0;
                int count2 = 0;
                count2 = dataGridView2.Rows.Count;
                DBconnect dbConnCF = new DBconnect();
                string sqlCF = string.Format("select count(CGNO) as count from CGZLS where CGNO  ='{0}' and CFMDate is not null", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand cmdCF = new SqlCommand(sqlCF, dbConnCF.connection);
                dbConnCF.OpenConnection();
                SqlDataReader readerCF = cmdCF.ExecuteReader();
                if (readerCF.Read())
                {
                    CFM = int.Parse(readerCF["count"].ToString());
                }

                if (CFM == 0) //更改CGZL
                {
                    DBconnect con5C = new DBconnect();
                    //更改CFMDATE
                    StringBuilder sql5C = new StringBuilder();
                    sql5C.AppendFormat("update CGZL set YN = 1 where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql5C);
                    SqlCommand cmd5C = new SqlCommand(sql5C.ToString(), con5C.connection);
                    con5C.OpenConnection();
                    int result5C = cmd5C.ExecuteNonQuery();
                    if (result5C == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con5C.CloseConnection();
                }
                else if (CFM == count2)
                {
                    DBconnect con5C = new DBconnect();
                    //更改CFMDATE
                    StringBuilder sql5C = new StringBuilder();
                    sql5C.AppendFormat("update CGZL set YN = 3 where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql5C);
                    SqlCommand cmd5C = new SqlCommand(sql5C.ToString(), con5C.connection);
                    con5C.OpenConnection();
                    int result5C = cmd5C.ExecuteNonQuery();
                    if (result5C == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con5C.CloseConnection();
                }
                else
                {
                    DBconnect con5C = new DBconnect();
                    //更改CFMDATE
                    StringBuilder sql5C = new StringBuilder();
                    sql5C.AppendFormat("update CGZL set YN = 2 where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Console.WriteLine(sql5C);
                    SqlCommand cmd5C = new SqlCommand(sql5C.ToString(), con5C.connection);
                    con5C.OpenConnection();
                    int result5C = cmd5C.ExecuteNonQuery();
                    if (result5C == 1)
                    {
                        //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con5C.CloseConnection();
                }

                Color();

            }
            catch (Exception) { }
        }

        private void Color() 
        {
            try 
            {
                int a = 0;
                a = dataGridView1.Rows.Count;
                for (int i = 0 ; i < a; i++ ) 
                {
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "1")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "2")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "3")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch(Exception){ }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";


                //重新讀取
                ds12 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select distinct a.CGNO,a.CLBH,b.ywpm,a.XqQty,a.Qty,USPrice,VNPrice, (Qty*USPrice) as ACCUS , (Qty * VNPrice) as ACCVN, Convert(varchar, ETA, 111) as ETA, Convert(varchar,CFMDate, 111) as CFMDate, c.ZLBH, c.CSBH, Convert(varchar, a.YQDate, 111) as YQDate from(select * from CGZLS) as a left join(select * from clzl) as b  on a.CLBH = b.cldh left join(select CGNO, CLBH, CSBH, x.ZLBH from CGZL as x left join(select * from YPZLZLS1 ) as y on x.ZLBH = y.YPZLBH where x.CGNO = '{0}') as c on a.CGNO = c.CGNO  and a.CLBH = c.CLBH where a.CGNO = '{1}' order by a.CLBH", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds12, "棧板表");

                dataGridView2.DataSource = ds12.Tables[0];
                //tsbSave.Enabled = true;
                dataGridView2.Columns[0].Visible = false;

                dataGridView2.ReadOnly = true;

                dataGridView2.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView2.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                tsbSave.Enabled = false;
                tsbModify.Enabled = true;
                tsbCancel.Enabled = false;
            }
            catch (Exception) { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                tabControl1.SelectedTab = tabPage2;

                ds12 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select distinct a.CGNO,a.CLBH,b.ywpm,a.XqQty,a.Qty,USPrice,VNPrice, (Qty*USPrice) as ACCUS , (Qty * VNPrice) as ACCVN, Convert(varchar, ETA, 111) as ETA, Convert(varchar,CFMDate, 111) as CFMDate, c.ZLBH, c.CSBH, Convert(varchar, a.YQDate, 111) as YQDate from(select * from CGZLS) as a left join(select * from clzl) as b  on a.CLBH = b.cldh left join(select CGNO, CLBH, CSBH, x.ZLBH from CGZL as x left join(select * from YPZLZLS1 ) as y on x.ZLBH = y.YPZLBH where x.CGNO = '{0}') as c on a.CGNO = c.CGNO  and a.CLBH = c.CLBH where a.CGNO = '{1}' order by a.CLBH ", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter.Fill(ds12, "棧板表");

                dataGridView2.DataSource = ds12.Tables[0];
                //tsbSave.Enabled = true;
                //dataGridView2.Columns[0].Visible = false;

                dataGridView2.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView2.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                //int a = dataGridView2.Rows.Count;
                //Console.WriteLine(dataGridView2.Rows[0].Cells[0].Value.ToString());
                //for (int i = 0; i < a; i++)
                //{

                //}
            }
            catch (Exception) { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex].Name == "Column9")
            {
                dataGridView2.CurrentCell.Value = ((DateTimePicker)sender).Value.ToString("yyyy/MM/dd");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (dataGridView1.CurrentRow.Cells[7].Value.ToString() != "")
                    {
                        DialogResult dr = MessageBox.Show("確定要取消確認?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {

                            DBconnect con5 = new DBconnect();
                            StringBuilder sql5 = new StringBuilder();
                            sql5.AppendFormat("update CGZL set CFMdate = null where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                            Console.WriteLine(sql5);
                            SqlCommand cmd5 = new SqlCommand(sql5.ToString(), con5.connection);
                            con5.OpenConnection();
                            int result5 = cmd5.ExecuteNonQuery();
                            if (result5 == 1)
                            {
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con5.CloseConnection();

                            DBconnect con5s = new DBconnect();
                            StringBuilder sql5s = new StringBuilder();
                            sql5s.AppendFormat("update CGZLS set CFMDate = null, ETA = null where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                            Console.WriteLine(sql5s);
                            SqlCommand cmd5s = new SqlCommand(sql5s.ToString(), con5s.connection);
                            con5s.OpenConnection();
                            int result5s = cmd5s.ExecuteNonQuery();
                            if (result5s == 1)
                            {
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con5s.CloseConnection();

                            DBconnect con5ss = new DBconnect();
                            StringBuilder sql5ss = new StringBuilder();
                            sql5ss.AppendFormat("update CGZLSS set CFMDate = null where CGNO = '{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());

                            Console.WriteLine(sql5ss);
                            SqlCommand cmd5ss = new SqlCommand(sql5ss.ToString(), con5ss.connection);
                            con5ss.OpenConnection();
                            int result5ss = cmd5ss.ExecuteNonQuery();
                            if (result5ss == 1)
                            {
                                MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con5ss.CloseConnection();

                            YN();
                            Color();

                            Console.WriteLine(sqlagain);
                            ds2 = new DataSet();
                            DBconnect dbConn2 = new DBconnect();
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlagain, dbConn2.connection);
                            adapter.Fill(ds2, "棧板表");
                            dataGridView1.DataSource = ds2.Tables[0];
                            Color();
                        }
                    }
                }
            }
            catch (Exception) { }
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    textBox1.Text = "";
                    if (tabControl1.SelectedTab == tabPage1)
                    {
                        if (tsbSave.Enabled == true)
                        {
                            tsbModify.Enabled = true;
                            tsbSave.Enabled = true;
                            tsbCancel.Enabled = true;
                        }
                        Console.WriteLine(sqlagain);
                        ds2 = new DataSet();
                        DBconnect dbConn2 = new DBconnect();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlagain, dbConn2.connection);
                        adapter.Fill(ds2, "棧板表");
                        dataGridView1.DataSource = ds2.Tables[0];
                        Color();

                    }
                    else if (tabControl1.SelectedTab == tabPage2)
                    {
                        ds12 = new DataSet();
                        DBconnect dbConn2 = new DBconnect();
                        string sql2 = string.Format("select distinct a.CGNO,a.CLBH,b.ywpm,a.XqQty,a.Qty,USPrice,VNPrice, (Qty*USPrice) as ACCUS , (Qty * VNPrice) as ACCVN, Convert(varchar, ETA, 111) as ETA, Convert(varchar,CFMDate, 111) as CFMDate, c.ZLBH, c.CSBH, Convert(varchar, a.YQDate, 111) as YQDate from(select * from CGZLS) as a left join(select * from clzl) as b  on a.CLBH = b.cldh left join(select CGNO, CLBH, CSBH, x.ZLBH from CGZL as x left join(select * from YPZLZLS1 ) as y on x.ZLBH = y.YPZLBH where x.CGNO = '{0}') as c on a.CGNO = c.CGNO  and a.CLBH = c.CLBH where a.CGNO = '{1}' order by a.CLBH ", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        Console.WriteLine(sql2);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql2, dbConn2.connection);
                        adapter.Fill(ds12, "棧板表");

                        dataGridView2.DataSource = ds12.Tables[0];
                        //tsbSave.Enabled = true;
                        //dataGridView2.Columns[0].Visible = false;

                        dataGridView2.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        dataGridView2.Columns[9].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                    }
                }
                catch (Exception) { }



            }
            catch (Exception) { }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Cells[13].Value.ToString() != "")
                {
                    if (tsbSave.Enabled == true)
                    {
                        //更換CFM日期
                        mydate = DateTime.Now;
                        string myDateString = mydate.ToString("yyyy-MM-dd HH:mm:ss");
                        Console.WriteLine("myDateString");
                        dataGridView2.CurrentRow.Cells[10].Value = myDateString;

                        //開啟報價
                        int a;
                        Console.WriteLine(e.ColumnIndex);
                        a = e.ColumnIndex;
                        if (a == 6 || a == 7)
                        {
                            Console.WriteLine(e.ColumnIndex);
                            SamplePrice Form = new SamplePrice();
                            Form.sampleclbh = dataGridView2.CurrentRow.Cells[1].Value.ToString();


                            Form.ShowDialog();
                            //Form.sampleclbh = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                            if (Form.vnprice != "")
                            {
                                dataGridView2.CurrentRow.Cells[7].Value = Form.vnprice;
                            }
                            if (Form.usprice != "")
                            {
                                dataGridView2.CurrentRow.Cells[6].Value = Form.usprice;
                            }

                        }
                    }


                    if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
                    switch (dataGridView2.Columns[e.ColumnIndex].Name)
                    {
                        case "Column1":
                        case "Column2":
                        case "Column3":
                        case "Column4":
                        case "Column5":
                        case "Column6":

                        case "Column7":

                        case "Column8":
                        case "Column9":
                            dataGridView2.BeginEdit(true);
                            break;
                        case "Column10":
                        case "Column11":
                        case "Column12":
                        case "Column13":
                        case "Column14":
                        case "Column15":
                        default:
                            dataGridView2.EndEdit();
                            break;
                    }
                }
                else 
                {
                    MessageBox.Show("NO YQDATE", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.ReadOnly = true;
                    tsbModify.Enabled = true;
                    tsbCancel.Enabled = false;
                    tsbSave.Enabled = false;
                }


            }
            catch (Exception) { }
        }

        private void dataGridView2_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentCell.ColumnIndex < 0) return;
                Control parentCTL = e.Control.Parent;

                if ((dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex].Name == "Column9"))
                {
                    DateTimePicker dtPicker = new DateTimePicker();
                    dtPicker.Name = "dateTimePicker1";
                    dtPicker.Size = dataGridView2.CurrentCell.Size;
                    if (dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex].Name == "Column9")
                    {
                        dtPicker.CustomFormat = "yyyy/MM/dd";
                    }


                    dtPicker.Format = DateTimePickerFormat.Custom;
                    dtPicker.Location = new Point(e.Control.Location.X - e.Control.Margin.Left < 0 ? 0 : e.Control.Location.X - e.Control.Margin.Left, e.Control.Location.Y - e.Control.Margin.Top < 0 ? 0 : e.Control.Location.Y - e.Control.Margin.Top);

                    if (e.Control.Text != "")
                    {
                        dtPicker.Value = DateTime.ParseExact(e.Control.Text, dtPicker.CustomFormat, null);
                    }
                    e.Control.Visible = false;

                    foreach (Control tmpCTL in parentCTL.Controls)
                    {
                        if (tmpCTL.Name == dtPicker.Name) parentCTL.Controls.Remove(tmpCTL);
                    }
                    parentCTL.Controls.Add(dtPicker);

                    dtPicker.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                }
                else
                {
                    foreach (Control tmpCTL in parentCTL.Controls)
                    {
                        if (tmpCTL.Name == "dateTimePicker1") parentCTL.Controls.Remove(tmpCTL);
                    }
                }
            }
            catch (Exception) { }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                textBox7.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox8.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            }
            catch (Exception) { }
            
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
