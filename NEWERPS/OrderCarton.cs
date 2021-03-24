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
    public partial class OrderCarton : Form
    {
        public OrderCarton()
        {
            InitializeComponent();
        }

        public string userid = "";
        string cddbh = "";
        public string ddbh = "", ctn = "", pairs = "";
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;

        string userForm = "OrderCarton";

        private void OrderCarton_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            sizeround();
            //獲取語言
            //userLanguage = Program.LanguageType.userLanguage;

            //ChangeLabel();
            //ChangeDataView();
            //ChangeTabControl();

            if (dataGridView1.Rows.Count > 3) 
            {
                button2.Enabled = false;
                button1.Enabled = false;
                L0004.Enabled = false;
                textBox3.Enabled = false;
            }
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
                L0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                L0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                L0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();                
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Add();

                int a = 0,b = 0;
                string xh = "";
                a = dataGridView1.Rows.Count;

                b = (a - 2) * 5;
                if (b.ToString().Length == 1)
                {
                    xh = "00" + b.ToString();
                }
                else if (b.ToString().Length == 2)
                {
                    xh = "0" + b.ToString();
                }
                else if (b.ToString().Length == 2)
                {
                    xh =  b.ToString();
                }

                Console.WriteLine(xh);

                dataGridView1.Rows[a-1].Cells[0].Value = xh;
                dataGridView1.Rows[a - 1].Cells[1].Value = "0";
                dataGridView1.Rows[a - 1].Cells[2].Value = "0";
                dataGridView1.Rows[a - 1].Cells[3].Value = "0";
                for (int i = dataGridView1.Columns.Count-1; i > 3; i --)
                {
                    dataGridView1.Rows[a - 1].Cells[i].Value = "0";
                }

                L0004.Enabled = false;
                textBox3.Enabled = false;
            }
            catch (Exception) { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int num = 0; //數量
                //int CTN = 0;

                int a = 0, b = 0;
                a = dataGridView1.Columns.Count - 1;
                b = dataGridView1.Rows.Count - 1;
                int z = 0, y = 0;
                Console.WriteLine(a);
                Console.WriteLine(b);

                for (int i = a; i > 3; i--) 
                {
                    z = 0;
                    for (int j = b; j > 1; j--)
                    {
                        z += int.Parse(dataGridView1.Rows[j].Cells[i].Value.ToString()) * int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                    }
                    dataGridView1.Rows[1].Cells[i].Value = int.Parse(dataGridView1.Rows[0].Cells[i].Value.ToString()) - z;
                }



                //for (int i = 0; i < dataGridView1.Columns.Count - 4; i++)
                //{
                //    num = int.Parse(dataGridView1.Rows[0].Cells[4 + i].Value.ToString()) / int.Parse(textBox3.Text);


                //    if (dataGridView1.Rows[i + 1].Cells[3].Value.ToString() == "0")
                //    {
                //        dataGridView1.Rows[i + 2].Cells[2].Value = 1;
                //        dataGridView1.Rows[i + 2].Cells[3].Value = 1 + num - 1;
                //    }
                //    else
                //    {
                //        CTN = int.Parse(dataGridView1.Rows[i + 1].Cells[3].Value.ToString());
                //        dataGridView1.Rows[i + 2].Cells[2].Value = CTN + 1;
                //        dataGridView1.Rows[i + 2].Cells[3].Value = CTN + num;
                //    }
                //}
                int s = 0;
                s = int.Parse(dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[3].Value.ToString());
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = s + 1;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = s + int.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value.ToString());

                int ctn = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ctn += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
                textBox2.Text = ctn.ToString();

            }
            catch (Exception) { }
        }

        private void L0005_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DialogResult dr2 = MessageBox.Show("請確認是否不在成品倉", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr2 == DialogResult.OK)
                    {
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete YWBZPOS where DDBH = '{0}'", tb訂單編號.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();
                    }
                }

                //sizeround();
                this.Close();
            }
            catch (Exception) { }
        }

        private void L0004_Click(object sender, EventArgs e)
        {
            try 
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("請先輸入箱數");
                }
                else 
                {
                    int[] all;
                    int[] count;
                    int[] residue;

                    int size = 0; //尺寸數
                    int num = 0; //數量
                    int x = 5;
                    size = dataGridView1.Columns.Count - 4;

                    for (int i = 0; i < dataGridView1.Columns.Count-4; i++)
                    {
                        x = x * i + 5;
                        string y = "";
                        string z = "";

                        if (x.ToString().Length == 1)
                        {
                            y = "00" + x;
                        }
                        else if (x.ToString().Length == 2)
                        {
                            y = "0" + x;
                        }
                        else 
                        {
                            y = x.ToString();
                        }

                        num = int.Parse(dataGridView1.Rows[0].Cells[4 + i].Value.ToString()) / int.Parse(textBox3.Text);

                        dataGridView1.Rows.Add();

                        for (int j = 4; j < dataGridView1.Columns.Count; j++) 
                        {
                            dataGridView1.Rows[i + 2].Cells[j].Value = 0;
                        }

                        dataGridView1.Rows[i + 2].Cells[0].Value = y;
                        dataGridView1.Rows[i + 2].Cells[4 + i].Value =  int.Parse(textBox3.Text);
                        dataGridView1.Rows[i + 2].Cells[1].Value = num;
                        z = dataGridView1.Rows[1].Cells[4 + i].Value.ToString();
                        dataGridView1.Rows[1].Cells[4 + i].Value = int.Parse(z) - num * int.Parse(textBox3.Text);

                        int CTN = 0;
                        
                        if (dataGridView1.Rows[i + 1].Cells[3].Value.ToString() == "0")
                        {
                            dataGridView1.Rows[i + 2].Cells[2].Value = 1;
                            dataGridView1.Rows[i + 2].Cells[3].Value = 1 + num - 1;
                        }
                        else 
                        {
                            CTN = int.Parse(dataGridView1.Rows[i + 1].Cells[3].Value.ToString());
                            dataGridView1.Rows[i + 2].Cells[2].Value = CTN + 1;
                            dataGridView1.Rows[i + 2].Cells[3].Value = CTN + num ;
                        }                                                                     
                        x = 5;                        
                    }

                    int ctn = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i ++) 
                    {
                        ctn += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                    textBox2.Text = ctn.ToString();


                    L0004.Enabled = false;
                    textBox3.Enabled = false;
                }
            }
            catch(Exception){ }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0; //計數器
                int b = 0; //檢查數字

                for(int i = 1; i < dataGridView1.Columns.Count ; i ++)
                {
                    b = int.Parse(dataGridView1.Rows[1].Cells[i].Value.ToString());
                    if (b != 0)
                    {
                        a ++;
                    }
                }
                Console.WriteLine(a);

                if (a == 0) //沒有餘數 
                {
                    for (int i = 2; i < dataGridView1.Rows.Count ; i ++) 
                    {
                        //插入YWBZPOS
                        for (int j = 4; j < dataGridView1.Columns.Count; j++)
                        {
                            //Console.WriteLine(j);
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Trim() != "0")
                            {
                                int result;
                                DBconnect conn = new DBconnect();
                                string sql1 = string.Format("insert into YWBZPOS (DDBH,XH,DDCC,Qty,CTS,CTQ,CTZ,USERDATE,USERID,YN,GSBH) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE(),'{7}','1','LTY')", tb訂單編號.Text.Trim(), dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(), dataGridView1.Columns[j].HeaderText, dataGridView1.Rows[i].Cells[j].Value.ToString().Trim(), dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), dataGridView1.Rows[i].Cells[2].Value.ToString().Trim(), dataGridView1.Rows[i].Cells[3].Value.ToString().Trim(), userid);

                                Console.WriteLine(sql1);

                                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                                conn.OpenConnection();
                                result = cmd1.ExecuteNonQuery();
                                if (result == 1)
                                {

                                }
                                conn.CloseConnection();
                            }
                        }

                        //插入YWCP
                        string ctn = "";
                        string ctn2 = "";
                        for (int j = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString().Trim()); j <= int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString().Trim()); j++)
                        {
                            //外箱號
                            if (j.ToString().Length == 1)
                            {
                                ctn2 = "000" + j.ToString();
                                ctn = tb訂單編號.Text.Trim() + " " + ctn2;
                            }
                            else if (j.ToString().Length == 2)
                            {
                                ctn2 = "00" + j.ToString();
                                ctn = tb訂單編號.Text.Trim() + " " + ctn2;
                            }
                            else if (j.ToString().Length == 3)
                            {
                                ctn2 = "0" + j.ToString();
                                ctn = tb訂單編號.Text.Trim() + " " + ctn2;
                            }
                            else if (j.ToString().Length == 4)
                            {
                                ctn2 = j.ToString();
                                ctn = tb訂單編號.Text.Trim() + " " + ctn2;
                            }

                            //外箱數量
                            int sum = 0;
                            DBconnect dbConn = new DBconnect();
                            string sql = string.Format("select SUM(Qty) as sum from YWBZPOS where DDBH = '{0}' and XH = '{1}'", tb訂單編號.Text.Trim(), dataGridView1.Rows[i].Cells[0].Value.ToString().Trim());
                            Console.WriteLine(sql);
                            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                            dbConn.OpenConnection();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                sum = int.Parse(reader["sum"].ToString());
                            }
                            Console.WriteLine(sum);
                            dbConn.CloseConnection();

                            int result2;
                            DBconnect conn2 = new DBconnect();
                            string sql2 = string.Format("insert into YWCP (CARTONBAR,DDBH,CARTONNO,XH,Qty,SB,YN,gsbh,CTX,CTNO) values ('{0}','{1}','{2}','{3}','{4}','0','1','LTY','0','{5}')", ctn, tb訂單編號.Text.Trim(), j.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(), sum, ctn2);

                            Console.WriteLine(sql2);

                            SqlCommand cmd2 = new SqlCommand(sql2, conn2.connection);
                            conn2.OpenConnection();
                            result2 = cmd2.ExecuteNonQuery();
                            if (result2 == 1)
                            {

                            }
                            conn2.CloseConnection();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("還有餘數並未編箱完成");
                }

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {
                //P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                //P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        private void sizeround() 
        {
            try
            {
                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from ddzls where DDBH = '{0}' and Quantity <> 0", tb訂單編號.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dgvsizeround.DataSource = ds.Tables[0];

                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();

                for (int i = 0; i < dgvsizeround.Rows.Count; i++) 
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    dataGridView1.Columns.Add(col);

                    dataGridView1.Columns[4+i].HeaderText = dgvsizeround.Rows[i].Cells[2].Value.ToString();

                    dataGridView1.Rows[0].Cells[4+i].Value = dgvsizeround.Rows[i].Cells[3].Value.ToString();
                    dataGridView1.Rows[1].Cells[4 + i].Value = dgvsizeround.Rows[i].Cells[3].Value.ToString();
                }

                dataGridView1.Rows[0].Cells[0].Value = "ALL";
                dataGridView1.Rows[1].Cells[0].Value = "LEFT";
                dataGridView1.Rows[0].Cells[1].Value = "0";
                dataGridView1.Rows[1].Cells[1].Value = "0";
                dataGridView1.Rows[0].Cells[2].Value = "0";
                dataGridView1.Rows[0].Cells[3].Value = "0";
                dataGridView1.Rows[1].Cells[2].Value = "0";
                dataGridView1.Rows[1].Cells[3].Value = "0";

                ds2 = new DataSet();
                DBconnect dbConn2 = new DBconnect();
                string sql2 = string.Format("select * from YWBZPOS where DDBH = '{0}'", tb訂單編號.Text);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn2.connection);
                adapter2.Fill(ds2, "棧板表");
                dgvLoad.DataSource = ds2.Tables[0];

                for (int i = 0; i < dgvLoad.Rows.Count; i++) 
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[2 + i].Cells[0].Value = dgvLoad.Rows[i].Cells[1].Value.ToString().Trim();
                    dataGridView1.Rows[2 + i].Cells[1].Value = dgvLoad.Rows[i].Cells[4].Value.ToString().Trim();
                    dataGridView1.Rows[2 + i].Cells[2].Value = dgvLoad.Rows[i].Cells[5].Value.ToString().Trim();
                    dataGridView1.Rows[2 + i].Cells[3].Value = dgvLoad.Rows[i].Cells[6].Value.ToString().Trim();

                    for (int j = 4; j < dataGridView1.Columns.Count; j++) 
                    {
                        dataGridView1.Rows[i+2].Cells[j].Value = '0';
                        if (dataGridView1.Columns[j].HeaderText == dgvLoad.Rows[i].Cells[2].Value.ToString().Trim()) 
                        {
                            dataGridView1.Rows[i+2].Cells[j].Value = dgvLoad.Rows[i].Cells[3].Value.ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
