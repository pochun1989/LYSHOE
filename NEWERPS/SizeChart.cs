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
    public partial class SizeChart : Form
    {
        #region 建構函式
        public SizeChart()
        {
            InitializeComponent();
        }

        #endregion

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataTable dtX = new DataTable();
        DataTable dtX2 = new DataTable();
        DataTable dtX3 = new DataTable();
        public string userid = "";
        int tlNum = 0;
        int num;
        int index;
        int sn = 0;
        string checkTool,checkGender,checkOS;
        string sizeid,sizename;
        string gid,tlid,gname,tlname,tlidname;
        int modifyindex = 0;

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "2_3";


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
                L0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                L0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                L0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 取出GJZL數量

        private void ToolNum() 
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(distinct gjlb) as count from gjzl  left join kfzl on gjzl.kfdh = kfzl.kfdh where gjzl.kfdh = '{0}' and gjzl.gb <> kfzl.CCGB", tb代號.Text);
                Console.WriteLine(sql2);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    tlNum = int.Parse(reader2["count"].ToString());
                }
                dbConn2.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 取出SIZE數量

        private void SizeNum()
        {
            try
            {                
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(Size_Number) as count from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'G' and GENDER_id = '{1}'", tb代號.Text, cbGender.SelectedValue.ToString());
                Console.WriteLine(sql2);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    num = int.Parse(reader2["count"].ToString());
                    Console.WriteLine(num);
                    Console.WriteLine("num");

                }
                dbConn2.CloseConnection();
            }
            catch (Exception) { }
        }

        #endregion

        #region 紀錄GJZL

        private void DataGJZL() 
        {
            try
            {
                DBconnect connX = new DBconnect();
                string sqlX = string.Format("select distinct gjlb,gb from gjzl left join kfzl on gjzl.kfdh = kfzl.kfdh where gjzl.kfdh = '{0}' and gjzl.gb <> kfzl.CCGB", tb代號.Text);
                Console.WriteLine(sqlX);
                SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                //DataTable dtX = new DataTable();
                sdaX.Fill(dtX);
                connX.OpenConnection();
                connX.CloseConnection();

            }
            catch (Exception) { }

        }

        #endregion

        #region 選出OS語言

        private void DataOS()
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sqlX = string.Format("select SIZE_ID from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'OS' and GENDER_id = '{1}' and CLASSID = 'AAAA'", tb代號.Text, cbGender.SelectedValue.ToString());
                Console.WriteLine(sqlX);
                SqlCommand cmd2 = new SqlCommand(sqlX, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    sizeid = reader2["SIZE_ID"].ToString();
                }
                dbConn2.CloseConnection();

                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select SIZE_Name from CSSize where SIZE_ID = '{0}'", sizeid);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sizename = reader["SIZE_Name"].ToString();
                }
                dbConn.CloseConnection();

            }
            catch (Exception) { }

        }

        #endregion

        #region 檢查GENDER

        private void SizeGen() 
        {
            try
            {
                //檢查有無資料
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(Size_Number) as count from SIZE_TR where kfdh = '{0}' and GENDER_id = '{1}' and SIZE_CLASS = 'G' and CLASSID = 'AAAA'", tb代號.Text, cbGender.SelectedValue.ToString());
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    checkGender = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();
                if (checkGender == "0") 
                {
                    InsertGender();
                    checkGender = "";
                }

            }
            catch (Exception) { }
        }

        #endregion

        #region 插入GENDER

        private void InsertGender() 
        {
            try
            {
                Console.WriteLine("InsertGender");
                double start, end, count;

                DBconnect connX = new DBconnect();
                string sqlX = string.Format("select Star_Size,End_Size from GENDER where Gender_Name = '{0}'", cbGender.SelectedValue.ToString());
                Console.WriteLine(sqlX);
                SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                //DataTable dtX = new DataTable();
                sdaX.Fill(dtX3);
                connX.OpenConnection();

                start = double.Parse(dtX3.Rows[0][0].ToString());
                end = double.Parse(dtX3.Rows[0][1].ToString());
                count = ((end * 10) - (start * 10)) / 5 + 1;

                Console.WriteLine(start);
                Console.WriteLine(end);
                Console.WriteLine(count);
                connX.CloseConnection();

                string sn3,sn4 = "";
                double sizeRange = 0;

                for (int i = 0; i < count; i++)
                {
                    sn3 = (i+1).ToString();
                    if (sn3.Length == 1)
                    {
                        sn4 = "00" + sn3;
                    }
                    else if (sn3.Length ==2) 
                    {
                        sn4 = "0" + sn3;
                    }
                    else if (sn3.Length == 3)
                    {
                        sn4 =  sn3;
                    }

                    sizeRange = start + 0.5*i;
                    Console.WriteLine(sizeRange);

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into SIZE_TR values('{0}','G','{1}','AAAA','{2}','U','{3}','{4}',GETDATE())", tb代號.Text, cbGender.SelectedValue.ToString(), sn4 , sizeRange, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                }
            }
            catch (Exception) 
            {
            }
        }

        #endregion

        #region 檢查OS

        private void SizeOS()
        {
            try
            {
                //檢查有無資料
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select count(Size_Number) as count from SIZE_TR where kfdh = '{0}' and GENDER_id = '{1}' and SIZE_CLASS = 'OS' and CLASSID = 'AAAA'", tb代號.Text, cbGender.SelectedValue.ToString());
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    checkOS = reader2["count"].ToString();
                }
                dbConn2.CloseConnection();
                if (checkOS == "0")
                {
                    InsertOS();
                    checkOS = "";
                }

            }
            catch (Exception) { }
        }

        #region 插入GENDER

        private void InsertOS()
        {
            try
            {
                Console.WriteLine("InsertOS");

                string ccgb = "";
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select CCGB from kfzl  where kfdh = '{0}'", tb代號.Text);
                SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                Console.WriteLine(sql2);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    ccgb = reader2["CCGB"].ToString();
                }

                dbConn2.CloseConnection();
                double start, end, count;

                DBconnect connX = new DBconnect();
                string sqlX = string.Format("select Star_Size,End_Size from GENDER where Gender_Name = '{0}'", cbGender.SelectedValue.ToString());
                Console.WriteLine(sqlX);
                SqlCommand cmdX = new SqlCommand(sqlX, connX.connection);
                SqlDataAdapter sdaX = new SqlDataAdapter(cmdX);
                //DataTable dtX = new DataTable();
                sdaX.Fill(dtX2);
                connX.OpenConnection();

                start = double.Parse(dtX2.Rows[0][0].ToString());
                end = double.Parse(dtX2.Rows[0][1].ToString());
                count = ((end * 10) - (start * 10)) / 5 + 1;

                Console.WriteLine(start);
                Console.WriteLine(end);
                Console.WriteLine(count);

                connX.CloseConnection();
                string sn3, sn4 = "";
                double sizeRange = 0;

                for (int i = 0; i < count; i++)
                {
                    sn3 = (i + 1).ToString();
                    if (sn3.Length == 1)
                    {
                        sn4 = "00" + sn3;
                    }
                    else if (sn3.Length == 2)
                    {
                        sn4 = "0" + sn3;
                    }
                    else if (sn3.Length == 3)
                    {
                        sn4 = sn3;
                    }

                    sizeRange = start + 0.5 * i;
                    Console.WriteLine(sizeRange);

                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into SIZE_TR values('{0}','OS','{1}','AAAA','{2}','{3}', NULL,'{4}',GETDATE())", tb代號.Text, cbGender.SelectedValue.ToString(), sn4, ccgb, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {

                    }
                    conn.CloseConnection();
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #endregion

        #region 檢查SIZETR有無工具號 加入TL

        private void SizeTool() 
        {
            try
            {
                SizeNum();
                ToolNum();
                DataGJZL();

                for (int j = 0; j < tlNum; j++)
                {
                    sn = 0;
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select count(SN) as SN from SIZE_TR where CLASSID = '{0}' and kfdh = '{1}' and GENDER_id = '{2}'", dtX.Rows[j][0].ToString(), tb代號.Text, cbGender.SelectedValue.ToString());
                    SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                    Console.WriteLine(sql2);
                    dbConn2.OpenConnection();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        checkTool = reader2["SN"].ToString();
                    }
                    dbConn2.CloseConnection();
                    for (int i = 0; i < num; i++)
                    {
                        if (checkTool == "0") //插入
                        {
                            //插入流水號
                            sn = sn +1;
                            string sn2;
                            if (sn.ToString().Length == 1)
                            {
                                sn2 = "00" + sn.ToString();
                            }
                            else if (sn.ToString().Length == 2)
                            {
                                sn2 = "0" + sn.ToString();
                            }
                            else
                            {
                                sn2 = sn.ToString();
                            }

                            //插入空白資料
                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into SIZE_TR values('{0}','TL','{1}','{2}','{3}','{4}',NULL,'{5}',GETDATE())", tb代號.Text, cbGender.SelectedValue.ToString(), dtX.Rows[j][0].ToString(), sn2, dtX.Rows[j][1].ToString(), userid);
                            Console.WriteLine(sql1);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {

                            }
                            conn.CloseConnection();
                        }
                        else //有資料不做新增 
                        {
                        }

                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 載入畫面

        private void LoadData()
        {
            try
            {
                DataGJZL();

                int i;
                DBconnect connX = new DBconnect();

                string sqlX = string.Format("select a.GENDER_id,a.SN,a.Size_Number,b.Size_Number");

                for(i = 0; i< tlNum; i++)
                {
                    sqlX += string.Format(",{0}.Size_Number ", Convert.ToChar(i+67));
                }
                sqlX += string.Format(" from (select GENDER_id,SN,Size_Number from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'G' and GENDER_id  = '{1}') as a left join (select SN, Size_Number from SIZE_TR where kfdh = '{2}' and SIZE_CLASS = 'OS'  and GENDER_id  = '{3}') as b on  a.SN = b.SN ", tb代號.Text, cbGender.SelectedValue.ToString(), tb代號.Text, cbGender.SelectedValue.ToString());


                for (i = 0; i < tlNum ; i++)
                {
                    sqlX += string.Format(" left join (select SN, Size_Number from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'TL' and CLASSID = '{1}' and GENDER_id  = '{2}') as {3} on  a.SN = {4}.SN", tb代號.Text, dtX.Rows[i][0].ToString(), cbGender.SelectedValue.ToString(), Convert.ToChar(i+67), Convert.ToChar(i + 67));
                }

                Console.WriteLine(sqlX);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlX, connX.connection);
                adapter.Fill(ds, "棧板表");
                this.dataGridView1.DataSource = this.ds.Tables[0];

                int z;
                z = dataGridView1.Rows.Count;
                for (int y = 0; y<z; y++) 
                {
                    dataGridView1.Rows[y].ReadOnly = true;
                    dataGridView1.Rows[y].Cells[0].Value = cbGender.Text;
                }
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dataGridView1.Columns[1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dataGridView1.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dataGridView1.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;

                 dataGridView1.Rows[0].Cells[0].Value = cbGender.Text ;

                connX.CloseConnection();
            }
            catch (Exception) { }

        }

        #endregion

        #region 查詢方法

        private void QueryData() 
        {
            try
            {
                if (tb代號.Text == "")
                {
                    MessageBox.Show("代號不能為空");
                }
                else 
                {
                    if (cbGender.Text == "")
                    {
                        MessageBox.Show("性別不能為空");
                    }
                    else
                    {
                        //新增資料
                        SizeGen();
                        SizeOS();
                        SizeTool();

                        //載入資料
                        LoadData();
                    }
                }               

            }
            catch (Exception) 
            {
            }
        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            try
            {                
                if (modifyindex == 3)
                {
                    DataOS();

                    int z,n = 0;
                    z = dataGridView1.Rows.Count;
                    for (int y = 0; y < z; y++)
                    {
                        if (dataGridView1.Rows[y].Cells[index].Value.ToString() != "")
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update SIZE_TR set Size_Number = '{0}',USERID = '{1}',USERDATE = GETDATE() where kfdh = '{2}' and SIZE_CLASS = 'OS' and GENDER_id = '{3}' and SN = '{4}' and CLASSID = 'AAAA' and SIZE_ID = '{5}' ", dataGridView1.Rows[y].Cells[index].Value.ToString(), userid, tb代號.Text, cbGender.SelectedValue.ToString(), dataGridView1.Rows[y].Cells[1].Value.ToString(), sizeid);

                            Console.WriteLine(sql4);

                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                n++;
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();
                        }
                        else 
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update SIZE_TR set Size_Number = NULL,USERID = '{0}',USERDATE = GETDATE() where kfdh = '{1}' and SIZE_CLASS = 'OS' and GENDER_id = '{2}' and SN = '{3}' and CLASSID = 'AAAA' and SIZE_ID = '{4}' ", userid, tb代號.Text, cbGender.SelectedValue.ToString(), dataGridView1.Rows[y].Cells[1].Value.ToString(), sizeid);

                            Console.WriteLine(sql4);

                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                n++;
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();
                        }
                    }
                    if (n > 0)
                    {
                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (modifyindex >= 4)
                {


                    int z,n = 0;
                    z = dataGridView1.Rows.Count;
                    for (int y = 0; y < z; y++)
                    {
                        if (dataGridView1.Rows[y].Cells[index].Value.ToString() != "")
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update SIZE_TR set Size_Number = '{0}',USERID = '{1}',USERDATE = GETDATE() where kfdh = '{2}' and SIZE_CLASS = 'TL' and GENDER_id = '{3}' and SN = '{4}' and CLASSID = '{5}' and SIZE_ID = '{6}' ", dataGridView1.Rows[y].Cells[index].Value.ToString(), userid, tb代號.Text, cbGender.SelectedValue.ToString(), dataGridView1.Rows[y].Cells[1].Value.ToString(), dtX.Rows[index - 4][0].ToString(), dtX.Rows[index - 4][1].ToString());

                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                n++;
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();
                        }
                        else 
                        {
                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update SIZE_TR set Size_Number = NULL,USERID = '{0}',USERDATE = GETDATE() where kfdh = '{1}' and SIZE_CLASS = 'TL' and GENDER_id = '{2}' and SN = '{3}' and CLASSID = '{4}' and SIZE_ID = '{5}' ", userid, tb代號.Text, cbGender.SelectedValue.ToString(), dataGridView1.Rows[y].Cells[1].Value.ToString(), dtX.Rows[index - 4][0].ToString(), dtX.Rows[index - 4][1].ToString());

                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                n++;
                                //MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();
                        }
                    }
                    if (n>0)
                    {

                        MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception) 
            {
            }
        }


        #endregion

        #region 選出G語言

        private void DataG()
        {
            try
            {
                DBconnect dbConn2 = new DBconnect();
                string sqlX = string.Format("select SIZE_ID from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'G' and GENDER_id = '{1}' and CLASSID = 'AAAA'", tb代號.Text, cbGender.SelectedValue.ToString());
                Console.WriteLine(sqlX);
                SqlCommand cmd2 = new SqlCommand(sqlX, dbConn2.connection);
                dbConn2.OpenConnection();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    gid = reader2["SIZE_ID"].ToString();
                }
                dbConn2.CloseConnection();

                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select SIZE_Name from CSSize where SIZE_ID = '{0}'", gid);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    gname = reader["SIZE_Name"].ToString();
                }
                dbConn.CloseConnection();

            }
            catch (Exception) { }

        }

        #endregion

        #region 選出TL語言

        private void DataTL()
        {
            try
            {
                for(int i = 0; i<tlNum; i++)
                {

                    DBconnect dbConn2 = new DBconnect();
                    string sqlX = string.Format("select SIZE_ID from SIZE_TR where kfdh = '{0}' and SIZE_CLASS = 'TL' and GENDER_id = '{1}' and CLASSID = '{2}'", tb代號.Text, cbGender.SelectedValue.ToString(), dtX.Rows[i][0].ToString());
                    Console.WriteLine(sqlX);
                    SqlCommand cmd2 = new SqlCommand(sqlX, dbConn2.connection);
                    dbConn2.OpenConnection();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        tlid = reader2["SIZE_ID"].ToString();
                    }
                    dbConn2.CloseConnection();

                    DBconnect dbConn3 = new DBconnect();
                    string sql3 = string.Format("select SIZE_Name from CSSize where SIZE_ID = '{0}'", tlid);
                    Console.WriteLine(sql3);
                    SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                    dbConn3.OpenConnection();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.Read())
                    {
                        tlidname = reader3["SIZE_Name"].ToString();
                    }
                    dbConn3.CloseConnection();

                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select ywsm from gjlbzl where gjlb = '{0}'", dtX.Rows[i][0].ToString());
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                    dbConn.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tlname = reader["ywsm"].ToString();
                    }

                    string textTL;
                    textTL = tlname + "(" + tlidname + ")";
                    dataGridView1.Columns[i+4].HeaderText = textTL;
                    dbConn.CloseConnection();
                }


            }
            catch (Exception) { }

        }

        #endregion

        #region 載入標題

        private void HeadText() 
        {
            try
            {
                dataGridView1.Columns[0].HeaderText = "GENDER";
                dataGridView1.Columns[1].HeaderText = "#";

                DataG();
                dataGridView1.Columns[2].HeaderText = gname;

                DataOS();
                dataGridView1.Columns[3].HeaderText = sizename;

                DataTL();
            }
            catch (Exception) { }
        }

        #endregion

        #region 客戶下拉選單

        private void Loadkfzl() 
        {
            try
            {
                DBconnect dbconn2 = new DBconnect();
                // 1.讀取類別明細
                string sql1 = "select * from kfzl";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql1, dbconn2.connection);
                adapter2.Fill(ds2, "類別明細表");
                this.cb簡稱.DataSource = ds2.Tables[0];
                this.cb簡稱.ValueMember = "kfdh";
                this.cb簡稱.DisplayMember = "kfqm";
            }
            catch (Exception) { }
        }

        #endregion

        #region 載入Gender

        private void LoadGender()
        {
            try
            {
                DBconnect dbconn2 = new DBconnect();
                // 1.讀取類別明細
                string sql1 = "select * from GENDER";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql1, dbconn2.connection);
                adapter2.Fill(ds3, "類別明細表");
                this.cbGender.DataSource = ds3.Tables[0];
                this.cbGender.ValueMember = "Gender_Name";
                this.cbGender.DisplayMember = "GENDERE";
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 事件

        #endregion

        #region 畫面載入
        private void SizeChart_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;

            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            Loadkfzl();
            LoadGender();

            ChangeLabel();
            //ChangeDataView();
        }

        #endregion

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tb代號.Text != "" && cbGender.Text != "")
            {
                QueryData();
                tsbClear.Enabled = true;
                tsbQuery.Enabled = false;
                tb代號.Enabled = false;
                cbGender.Enabled = false;
                tsbModify.Enabled = true;
                cb簡稱.Enabled = false;

                HeadText();
            }
            else
            {
                MessageBox.Show("代號與性別不能為空");
            }

        }

        private void cb簡稱_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tb代號.Text = cb簡稱.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "1";
                int x;
                x = index;
                if (index >= 3) 
                {
                    int z;
                    z = dataGridView1.Rows.Count;
                    for (int y = 0; y < z; y++)
                    {
                        dataGridView1.Rows[y].Cells[index].ReadOnly = false;
                    }

                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    tsbQuery.Enabled = false;
                    tsbModify.Enabled = false;
                    modifyindex = x;



                }

            }
            catch (Exception) { }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modifyindex == 0)
            {
                index = e.ColumnIndex;
            }

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try 
            {
                Program.Modifytype.modify = "0";
                ModifyData();

                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                tsbQuery.Enabled = true;
                tsbModify.Enabled = true;

                int z;
                z = dataGridView1.Rows.Count;
                for (int y = 0; y < z; y++)
                {
                    dataGridView1.Rows[y].Cells[index].ReadOnly = true;
                }
                modifyindex = 0;
            }
            catch (Exception) 
            {

            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Modifytype.modify = "0";
                int z;
                z = dataGridView1.Rows.Count;
                for (int y = 0; y < z; y++)
                {
                    dataGridView1.Rows[y].Cells[index].ReadOnly = true;
                }

                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                tsbQuery.Enabled = true;
                tsbModify.Enabled = true;
                cb簡稱.Enabled = false;
                modifyindex = 0;

            }
            catch (Exception) { }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            modifyindex = 0;
            index = 0;
            int z;
            z = dataGridView1.Rows.Count;
            for (int y = 0; y < z; y++)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
            tsbQuery.Enabled = true;

            cb簡稱.Enabled = true;

            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbClear.Enabled = false;
            tsbModify.Enabled = false;
            cbGender.Enabled = true;

            int c = 0;
            c = dtX.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtX.Rows.RemoveAt(0);
            }


            c = dtX2.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtX2.Rows.RemoveAt(0);
            }



            c = dtX3.Rows.Count;
            for (int i  =0; i<c; i++)
            {
                dtX3.Rows.RemoveAt(0);
            }



        }
    }
}
