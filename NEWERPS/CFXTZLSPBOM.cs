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
    public partial class CFXTZLSPBOM : Form
    {
        public CFXTZLSPBOM()
        {
            InitializeComponent();
        }

        #region 變數

        int sl = 0;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet dsN = new DataSet();
        DataSet dsN2 = new DataSet();
        DataSet dsZ = new DataSet();
        DataSet dsR = new DataSet();
        public string userid = "";
        public string bwbh = "", ywsm = "";
        string bwbhb = "";
        string sqlR = "";
        Boolean modify = false;
        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "CFXTZLSPBOM";

        #endregion

        #region 畫面載入

        private void CFXTZLSPBOM_Load(object sender, EventArgs e)
        {
            try
            {

                userid = Program.User.userID;

                BWLB();

                dataGridView1.Columns[3].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView1.Columns[5].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView1.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;

                ChangeLabel();
                ChangeDataView();
                ChangeTabControl();

                part();
            }
            catch (Exception) { }
        }

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

                dataGridView1.Columns[0].HeaderText = dgvWord.Rows[0].Cells[3].Value.ToString();
                dataGridView1.Columns[1].HeaderText = dgvWord.Rows[1].Cells[3].Value.ToString();
                dataGridView1.Columns[2].HeaderText = dgvWord.Rows[2].Cells[3].Value.ToString();
                dataGridView1.Columns[3].HeaderText = dgvWord.Rows[3].Cells[3].Value.ToString();
                dataGridView1.Columns[4].HeaderText = dgvWord.Rows[4].Cells[3].Value.ToString();
                dataGridView1.Columns[5].HeaderText = dgvWord.Rows[5].Cells[3].Value.ToString();
                dataGridView1.Columns[6].HeaderText = dgvWord.Rows[6].Cells[3].Value.ToString();
                dataGridView1.Columns[7].HeaderText = dgvWord.Rows[7].Cells[3].Value.ToString();
                dataGridView1.Columns[8].HeaderText = dgvWord.Rows[8].Cells[3].Value.ToString();
                dataGridView1.Columns[9].HeaderText = dgvWord.Rows[9].Cells[3].Value.ToString();
                dataGridView1.Columns[10].HeaderText = dgvWord.Rows[10].Cells[3].Value.ToString();

                dataGridView2.Columns[0].HeaderText = dgvWord.Rows[11].Cells[3].Value.ToString();
                dataGridView2.Columns[1].HeaderText = dgvWord.Rows[12].Cells[3].Value.ToString();
                dataGridView2.Columns[2].HeaderText = dgvWord.Rows[13].Cells[3].Value.ToString();
                dataGridView2.Columns[3].HeaderText = dgvWord.Rows[14].Cells[3].Value.ToString();
                dataGridView2.Columns[4].HeaderText = dgvWord.Rows[15].Cells[3].Value.ToString();
                dataGridView2.Columns[5].HeaderText = dgvWord.Rows[16].Cells[3].Value.ToString();
                dataGridView2.Columns[6].HeaderText = dgvWord.Rows[17].Cells[3].Value.ToString();
                dataGridView2.Columns[7].HeaderText = dgvWord.Rows[18].Cells[3].Value.ToString();

                dataGridView1.Columns[0].HeaderText = dgvWord.Rows[19].Cells[3].Value.ToString();
                dataGridView1.Columns[1].HeaderText = dgvWord.Rows[20].Cells[3].Value.ToString();
                dataGridView1.Columns[2].HeaderText = dgvWord.Rows[21].Cells[3].Value.ToString();
                dataGridView1.Columns[3].HeaderText = dgvWord.Rows[22].Cells[3].Value.ToString();
                dataGridView1.Columns[4].HeaderText = dgvWord.Rows[23].Cells[3].Value.ToString();
                dataGridView1.Columns[5].HeaderText = dgvWord.Rows[24].Cells[3].Value.ToString();
                dataGridView1.Columns[6].HeaderText = dgvWord.Rows[25].Cells[3].Value.ToString();
                dataGridView1.Columns[7].HeaderText = dgvWord.Rows[26].Cells[3].Value.ToString();
                dataGridView1.Columns[8].HeaderText = dgvWord.Rows[27].Cells[3].Value.ToString();
                dataGridView1.Columns[9].HeaderText = dgvWord.Rows[28].Cells[3].Value.ToString();
                dataGridView1.Columns[10].HeaderText = dgvWord.Rows[29].Cells[3].Value.ToString();
                dataGridView1.Columns[11].HeaderText = dgvWord.Rows[30].Cells[3].Value.ToString();
                dataGridView1.Columns[12].HeaderText = dgvWord.Rows[31].Cells[3].Value.ToString();
                dataGridView1.Columns[13].HeaderText = dgvWord.Rows[32].Cells[3].Value.ToString();
                dataGridView1.Columns[14].HeaderText = dgvWord.Rows[33].Cells[3].Value.ToString();
                dataGridView1.Columns[15].HeaderText = dgvWord.Rows[34].Cells[3].Value.ToString();
                dataGridView1.Columns[16].HeaderText = dgvWord.Rows[35].Cells[3].Value.ToString();
                dataGridView1.Columns[17].HeaderText = dgvWord.Rows[36].Cells[3].Value.ToString();
                dataGridView1.Columns[18].HeaderText = dgvWord.Rows[37].Cells[3].Value.ToString();
                dataGridView1.Columns[19].HeaderText = dgvWord.Rows[38].Cells[3].Value.ToString();
                dataGridView1.Columns[20].HeaderText = dgvWord.Rows[39].Cells[3].Value.ToString();
                dataGridView1.Columns[21].HeaderText = dgvWord.Rows[40].Cells[3].Value.ToString();
                dataGridView1.Columns[22].HeaderText = dgvWord.Rows[41].Cells[3].Value.ToString();
                dataGridView1.Columns[23].HeaderText = dgvWord.Rows[42].Cells[3].Value.ToString();

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
                L0007.Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                L0008.Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                //L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                //L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {
                P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 部位載入

        private void BWLB()
        {
            try
            {
                
                ds = new DataSet();
                DBconnect dbconn = new DBconnect();
                string sql1 = "select * from DESTINATION";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(ds, "倉庫位置");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.ValueMember = "DESTINATION_ID";
                this.comboBox1.DisplayMember = "ywsm";

                comboBox1.MaxDropDownItems = 8;
                comboBox1.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion

        private void part() 
        {
            try
            {
                DataSet dsP = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select distinct BWBH from xxzls where XieXing = '{0}' and SheHao = '{1}' and BWLB <> 3 ", textBox1.Text, textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsP, "棧板表");
                dgvPart.DataSource = dsP.Tables[0];
            }
            catch (Exception) { }
        }

        private void ZSDH()
        {
            dsZ = new DataSet();
            DBconnect dbconn = new DBconnect();
            string sql1 = string.Format("select * from supplier_list where cldh = '{0}' order by zsdh", dataGridView3.CurrentRow.Cells[1].Value.ToString());
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
            adapter1.Fill(dsZ, "倉庫");
            Console.WriteLine(sql1);
            this.comboBox2.DataSource = dsZ.Tables[0];
            this.comboBox2.ValueMember = "zsdh";
            this.comboBox2.DisplayMember = "zsdh";

            comboBox2.MaxDropDownItems = 8;
            comboBox2.IntegralHeight = false;
        }

        #region EXCEL

        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                         //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                         //   {  
                                                         //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                         //      rg.NumberFormat = "00000000";  
                                                         //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("导出文件成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("报表为空,无表格需要导出", "提示", MessageBoxButtons.OK);
            }

        }

        #endregion

        #endregion

        #region 事件


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0,b = 0,c = 0;
                a = ds1.Tables[0].Rows.Count;
                b = ds1.Tables[0].Rows.Count;
                Console.WriteLine(a);

                for (int i = 0; i < a; i++)
                {
                    DialogResult dr = MessageBox.Show("Modify? 確定要修改嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        Console.WriteLine(ds1.Tables[0].Rows[i].RowState.ToString());
                        if (ds1.Tables[0].Rows[i].RowState.ToString() == "Unchanged") //未動
                        {
                        }
                        else if (ds1.Tables[0].Rows[i].RowState.ToString() == "Modified")//修改過
                        {
                            #region NEWERP

                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("update xxzlss set cond = '{0}', BWBH = '{1}', CLBH = '{2}',CSBH = '{3}', LOSS = '{4}',CLSL = '{5}',USERID = '{6}',USERDATE = GETDATE() where XieXing = '{7}' and SheHao = '{8}' and cond = '{9}' and BWBH = '{10}'", comboBox1.SelectedValue.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString(), userid, textBox1.Text, textBox2.Text, ds2.Tables[0].Rows[i][2].ToString(), ds2.Tables[0].Rows[i][3].ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            #endregion

                            #region LYSHOE

                            DBconnect2 con4Y = new DBconnect2();
                            StringBuilder sql4Y = new StringBuilder();
                            sql4Y.AppendFormat("update xxzlss set cond = '{0}', BWBH = '{1}', CLBH = '{2}',CSBH = '{3}', LOSS = '{4}',CLSL = '{5}',USERID = '{6}',USERDATE = CONVERT(varchar, GETDATE(), 11) where XieXing = '{7}' and SheHao = '{8}' and cond = '{9}' and BWBH = '{10}'", comboBox1.SelectedValue.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString(), userid, textBox1.Text, textBox2.Text, ds2.Tables[0].Rows[i][2].ToString(), ds2.Tables[0].Rows[i][3].ToString());
                            Console.WriteLine(sql4Y);
                            SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                            con4Y.OpenConnection();
                            int result4Y = cmd4Y.ExecuteNonQuery();
                            if (result4Y == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4Y.CloseConnection();

                            #endregion
                        }
                        else if (ds1.Tables[0].Rows[i].RowState.ToString() == "Deleted")//修改過
                        {
                            #region NEWERP

                            DBconnect con4 = new DBconnect();
                            StringBuilder sql4 = new StringBuilder();
                            sql4.AppendFormat("delete xxzlss  where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}'", textBox1.Text, textBox2.Text, ds2.Tables[0].Rows[i][2].ToString(), ds2.Tables[0].Rows[i][3].ToString());
                            Console.WriteLine(sql4);
                            SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                            con4.OpenConnection();
                            int result4 = cmd4.ExecuteNonQuery();
                            if (result4 == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4.CloseConnection();

                            #endregion

                            #region LYSHOE

                            DBconnect2 con4Y = new DBconnect2();
                            StringBuilder sql4Y = new StringBuilder();
                            sql4Y.AppendFormat("delete xxzlss  where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}'", textBox1.Text, textBox2.Text, ds2.Tables[0].Rows[i][2].ToString(), ds2.Tables[0].Rows[i][3].ToString());
                            Console.WriteLine(sql4Y);
                            SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                            con4Y.OpenConnection();
                            int result4Y = cmd4Y.ExecuteNonQuery();
                            if (result4Y == 1)
                            {
                                //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            con4Y.CloseConnection();

                            #endregion
                        }
                        else if (ds1.Tables[0].Rows[i].RowState.ToString() == "Added")//新增
                        {
                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE())", textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString(), userid);
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
                            string sql1Y = string.Format("insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text, textBox2.Text);
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
                    }
                }
            }
            catch (Exception) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbpart.Text = "";
                //tbpartE.Text = "";
                tbmaterial.Text = "";
                tbmaterialE.Text = "";
                tbloss.Text = "0";
                tbclsl.Text = "0";


                ds1 = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select XieXing,SheHao,cond,BWBH,b.ywsm, a.CLBH,c.ywpm,c.dwbh,a.CSBH,LOSS,CLSL from xxzlss as a left join bwzl as b on a.BWBH = b.bwdh left join clzl as c on a.CLBH = c.cldh where cond = '{0}' and XieXing = '{1}' and SheHao = '{2}'", comboBox1.SelectedValue.ToString(), textBox1.Text, textBox2.Text);
                Console.WriteLine(sql1);
                sqlR = sql1;
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(ds1, "棧板表");

                dataGridView1.DataSource = ds1.Tables[0];
                dbConn11.CloseConnection();


                ds2 = new DataSet();
                DBconnect dbConn12 = new DBconnect();
                string sql2 = string.Format("select XieXing,SheHao,cond,BWBH,b.ywsm, a.CLBH,c.ywpm,c.dwbh,a.CSBH,LOSS,CLSL from xxzlss as a left join bwzl as b on a.BWBH = b.bwdh left join clzl as c on a.CLBH = c.cldh where cond = '{0}'", comboBox1.SelectedValue.ToString());
                Console.WriteLine(sql2);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn12.connection);
                adapter.Fill(ds2, "棧板表");

                dataGridView1.DataSource = ds2.Tables[0];
                dbConn12.CloseConnection();

                L0005.Enabled = true;
            }
            catch (Exception) { }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbpart_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    if (tbpart.Text != "")
                    {
                        dsN = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from bwzl where bwdh like '%{0}%' and ywsm like '%{1}%' order by bwdh", tbpart.Text, textBox8.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(dsN, "棧板表");

                        dataGridView2.DataSource = dsN.Tables[0];
                        dbConn11.CloseConnection();
                    }

                }
            }
            catch (Exception) { }

        }

        private void tbmaterial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    dsN = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' and  ywpm like '%{1}%' AND ywpm LIKE '%{2}%' order by cldh", tbmaterial.Text, textBox6.Text, textBox7.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(dsN, "棧板表");

                    dataGridView3.DataSource = dsN.Tables[0];
                    dbConn11.CloseConnection();

                    dataGridView3.Columns[0].Width = 50;
                    dataGridView3.Columns[1].Width = 150;
                    comboBox2.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void tbmaterialE_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    if (tbmaterial.Text != "" && tbmaterialE.Text != "")
                    {
                        dsN = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from clzl where cldh like '%{0}%' and  ywpm like '%{1}%' order by cldh", tbmaterial.Text, tbmaterialE.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(dsN, "棧板表");

                        dataGridView3.DataSource = dsN.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    else if (tbmaterialE.Text != "")
                    {
                        dsN = new DataSet();
                        DBconnect dbConn11 = new DBconnect();
                        string sql1 = string.Format("select * from clzl where ywpm like '%{0}%' order by cldh", tbmaterialE.Text);
                        Console.WriteLine(sql1);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                        adapter.Fill(dsN, "棧板表");

                        dataGridView3.DataSource = dsN.Tables[0];
                        dbConn11.CloseConnection();
                    }
                    dataGridView3.Columns[0].Width = 50;
                    dataGridView3.Columns[1].Width = 150;
                    comboBox2.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select count(zsdh) as count from supplier_list where cldh = '{0}'", dataGridView3.CurrentRow.Cells[1].Value.ToString());
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    a = int.Parse(reader1["count"].ToString());
                }
                dbConn1.CloseConnection();

                if (a != 0)
                {
                    comboBox2.Visible = true;
                    ZSDH();
                }
                else 
                {
                    comboBox2.Visible = false;
                }
            }
            catch (Exception) { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001)
                {
                    tbpart.Enabled = false;
                    tbmaterial.Enabled = false;
                    comboBox2.Enabled = false;
                    tbloss.Enabled = false;
                    tbclsl.Enabled = false;

                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbDelete.Enabled = true;

                    dsR = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlR, dbConn11.connection);
                    adapter.Fill(dsR, "棧板表");

                    dataGridView1.DataSource = dsR.Tables[0];
                    dbConn11.CloseConnection();
                }
                else if (tabControl1.SelectedTab == P0002)
                {
                    tsbQuery.Enabled = false;
                    tsbClear.Enabled = true;
                    tsbInsert.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbDelete.Enabled = false;
                }
                else if (tabControl1.SelectedTab == P0003)
                {
                    DataSet ds9 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select DESTINATION.ywsm as country,xxzlss.BWBH,bwzl.ywsm as part,CLBH ,clzl.ywpm,zszl.zsywjc as supplier,CLSL as qty from xxzlss left join DESTINATION on xxzlss.cond = DESTINATION.DESTINATION_ID left join bwzl on xxzlss.BWBH = bwzl.bwdh left join clzl on xxzlss.CLBH = clzl.cldh left join zszl on zszl.zsdh = xxzlss.CSBH where XieXing = '{0}' and SheHao = '{1}' order by country, BWBH", textBox1.Text, textBox2.Text);
                    Console.WriteLine(sql1);
                    //sqlR = sql1;
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds9, "棧板表");

                    dataGridView4.DataSource = ds9.Tables[0];
                    dbConn11.CloseConnection();
                }
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {                
                sl = 0;
                //tsbSave.Enabled = true;
                //tsbCancel.Enabled = true;
                tsbDelete.Enabled = false;
                tbpart.Text = "";
                //tbpartE.Text = "";
                tbmaterial.Text = "";
                tbmaterialE.Text = "";
                tbloss.Text = "0";
                tbclsl.Text = "0";
                comboBox2.Visible = false;
                tbpart.Enabled = true;
                //tbpartE.Enabled = true;
                tbmaterial.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                tbmaterialE.Enabled = true;
                tbloss.Enabled = true;
                tbclsl.Enabled = true;
                tabControl1.SelectedTab = P0002;
                textBox8.Enabled = true;
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbInsert.Enabled = true;
            tsbModify.Enabled = true;
            tsbDelete.Enabled = false;
            tbpart.Text = "";
            //tbpartE.Text = "";
            tbmaterial.Text = "";
            tbmaterialE.Text = "";
            comboBox2.Visible = false;
            tbpart.Enabled = false;
            //tbpartE.Enabled = false;
            tbmaterial.Enabled = false;
            tbmaterialE.Enabled = false;
            tbloss.Enabled = false;
            tbclsl.Enabled = false;
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                bwbhb = tbpart.Text;
                sl = 1;
                tabControl1.SelectedTab = P0002;
                //tsbSave.Enabled = true;
                //tsbCancel.Enabled = true;
                tsbDelete.Enabled = true;
                comboBox2.Visible = true;
                tbpart.Enabled = false;
                //tbpartE.Enabled = true;
                tbmaterial.Enabled = true;
                tbmaterialE.Enabled = true;
                comboBox2.Enabled = true;
                tbloss.Enabled = true;
                tbclsl.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = false;

                dsN = new DataSet();
                DBconnect dbConn11 = new DBconnect();
                string sql1 = string.Format("select * from bwzl where bwdh like '%{0}%' order by bwdh", tbpart.Text);
                Console.WriteLine(sql1);
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                adapter.Fill(dsN, "棧板表");

                dataGridView2.DataSource = dsN.Tables[0];
                dbConn11.CloseConnection();

                dsN2 = new DataSet();
                DBconnect dbConn112 = new DBconnect();
                string sql12 = string.Format("select * from clzl where cldh like '%{0}%' order by cldh", tbmaterial.Text);
                Console.WriteLine(sql12);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql12, dbConn112.connection);
                adapter2.Fill(dsN2, "棧板表");

                dataGridView3.DataSource = dsN2.Tables[0];
                dbConn112.CloseConnection();

                modify = true;

                comboBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch(Exception){ }

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Delete? 確定要刪除嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    #region NEWERP

                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("delete xxzlss  where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}'", textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString() , tbpart.Text);
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();

                    #endregion

                    #region LYSHOE

                    DBconnect2 con4Y = new DBconnect2();
                    StringBuilder sql4Y = new StringBuilder();
                    sql4Y.AppendFormat("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' and BWBH = '{3}'", textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), tbpart.Text);
                    Console.WriteLine(sql4Y);
                    SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                    con4Y.OpenConnection();
                    int result4Y = cmd4Y.ExecuteNonQuery();
                    if (result4Y == 1)
                    {
                        //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4Y.CloseConnection();

                    #endregion

                    ds1 = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select XieXing,SheHao,cond,BWBH,b.ywsm, a.CLBH,c.ywpm,c.dwbh,a.CSBH,LOSS,CLSL from xxzlss as a left join bwzl as b on a.BWBH = b.bwdh left join clzl as c on a.CLBH = c.cldh where cond = '{0}' and XieXing = '{1}' and SheHao = '{2}'", comboBox1.SelectedValue.ToString(), textBox1.Text, textBox2.Text);
                    Console.WriteLine(sql1);
                    sqlR = sql1;
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(ds1, "棧板表");

                    dataGridView1.DataSource = ds1.Tables[0];
                    dbConn11.CloseConnection();
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbpart.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //tbpartE.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tbmaterial.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tbmaterialE.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tbloss.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tbclsl.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                if (sl == 0)
                {
                    int partcount = 0;
                    for (int a = 0; a < dgvPart.Rows.Count; a ++) 
                    {
                        if (dgvPart.Rows[a].Cells[0].Value.ToString() == dataGridView2.CurrentRow.Cells[0].Value.ToString()) 
                        {
                            partcount++;
                        }
                    }
                    if (partcount == 0)
                    {
                        if (comboBox2.Visible == false) //無廠商
                        {
                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE())", textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString(), dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), "", tbloss.Text.Trim(), tbclsl.Text.Trim(), userid);
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
                            string sql1Y = string.Format("DELETE xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
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
                        else
                        {
                            #region NEWERP

                            int result;
                            DBconnect conn = new DBconnect();
                            string sql1 = string.Format("insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',GETDATE())", textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString(), dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), comboBox2.SelectedValue.ToString(), tbloss.Text.Trim(), tbclsl.Text.Trim(), userid);
                            Console.WriteLine(sql1);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                            conn.OpenConnection();
                            result = cmd1.ExecuteNonQuery();
                            if (result == 1)
                            {
                                MessageBox.Show("Insert Success新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn.CloseConnection();

                            #endregion

                            #region LYSHOE

                            int resultY;
                            DBconnect2 connY = new DBconnect2();
                            string sql1Y = string.Format("DELETE xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
                            Console.WriteLine(sql1Y);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                            connY.OpenConnection();
                            resultY = cmd1Y.ExecuteNonQuery();
                            if (resultY == 1)
                            {
                                
                            }
                            connY.CloseConnection();

                            #endregion
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Exist in Bom 該部位已在一般BOM表中");
                    }
                }
                else if (sl == 1)
                {
                    if (comboBox2.Visible == false)
                    {
                        //修改
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update xxzlss set CLBH = '{1}', CSBH = '{2}', LOSS = '{3}', CLSL = '{4}', USERID = '{5}', USERDATE = GETDATE() where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}' and BWBH = '{0}' ", tbpart.Text.Trim(), tbmaterial.Text.Trim(), "", tbloss.Text.Trim(), tbclsl.Text.Trim(), userid, textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString());
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #region LYSHOE

                        int resultY;
                        DBconnect2 connY = new DBconnect2();
                        string sql1Y = string.Format("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
                        Console.WriteLine(sql1Y);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                        connY.OpenConnection();
                        resultY = cmd1Y.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                        }
                        connY.CloseConnection();

                        #endregion

                    }
                    else 
                    {
                        #region NEWERP

                        //修改
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("update xxzlss set CLBH = '{1}', CSBH = '{2}', LOSS = '{3}', CLSL = '{4}', USERID = '{5}', USERDATE = GETDATE() where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}' and BWBH = '{0}'", tbpart.Text.Trim(), tbmaterial.Text.Trim(), comboBox2.Text.Trim(), tbloss.Text.Trim(), tbclsl.Text.Trim(), userid, textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString());
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();

                        #endregion

                        #region LYSHOE

                        //修改
                        DBconnect2 con4Y = new DBconnect2();
                        StringBuilder sql4Y = new StringBuilder();
                        sql4Y.AppendFormat("update xxzlss set CLBH = '{1}', CSBH = '{2}', LOSS = '{3}', CLSL = '{4}', USERID = '{5}', USERDATE = CONVERT(varchar,GETDATE(),11) where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}' and BWBH = '{0}'", tbpart.Text.Trim(), tbmaterial.Text.Trim(), comboBox2.Text.Trim(), tbloss.Text.Trim(), tbclsl.Text.Trim(), userid, textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.SelectedValue.ToString());
                        Console.WriteLine(sql4Y);
                        SqlCommand cmd4Y = new SqlCommand(sql4Y.ToString(), con4Y.connection);

                        con4Y.OpenConnection();
                        int result4Y = cmd4Y.ExecuteNonQuery();
                        if (result4Y == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4Y.CloseConnection();

                        #endregion
                    }

                    tabControl1.SelectedTab = P0001;
                }

                //tsbSave.Enabled = false;
                //tsbCancel.Enabled = false;
                //tsbInsert.Enabled = true;
                //tsbModify.Enabled = true;
                //tsbDelete.Enabled = false;
                //tbpart.Text = "";
                //tbpartE.Text = "";
                //tbmaterial.Text = "";
                //tbmaterialE.Text = "";
                comboBox2.Visible = false;
                tbpart.Enabled = false;
                tbmaterial.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                tbmaterialE.Enabled = false;
                tbloss.Enabled = false;
                tbclsl.Enabled = false;
                tabControl1.SelectedTab = P0001;
            }
            catch(Exception)
            {
                MessageBox.Show("Same Part 部位重複插入");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string gen = "";
                DBconnect dbConn3 = new DBconnect();
                string sql3 = string.Format("select zsywjc from zszl where zsdh = '{0}'", comboBox2.Text.Trim());
                Console.WriteLine(sql3);
                SqlCommand cmd3 = new SqlCommand(sql3, dbConn3.connection);
                dbConn3.OpenConnection();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    gen = reader3["zsywjc"].ToString();
                }
                textBox4.Text = gen;
                dbConn3.CloseConnection();
            }
            catch (Exception) { }
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {               
                ds4 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' order by BWBH ", textBox1.Text, textBox2.Text, comboBox1.SelectedValue);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds4, "棧板表");
                this.dataGridView1.DataSource = this.ds4.Tables[0];
            }
            catch (Exception) { }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0001) 
                {
                    CFXTZLSPBOMCOPY Form = new CFXTZLSPBOMCOPY();
                    Form.textBox1.Text = textBox1.Text;
                    Form.textBox3.Text = textBox1.Text;
                    Form.textBox2.Text = textBox2.Text;
                    Form.textBox4.Text = textBox2.Text;
                    Form.ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == P0003)
                {
                    ExportExcel("report", dataGridView4);
                }
            }
            catch (Exception) { }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    dsN = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' and  ywpm like '%{1}%' AND ywpm LIKE '%{2}%' order by cldh", tbmaterial.Text, textBox6.Text, textBox7.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(dsN, "棧板表");

                    dataGridView3.DataSource = dsN.Tables[0];
                    dbConn11.CloseConnection();

                    dataGridView3.Columns[0].Width = 50;
                    dataGridView3.Columns[1].Width = 150;
                    comboBox2.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    dsN = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from clzl where cldh like '%{0}%' and  ywpm like '%{1}%' AND ywpm LIKE '%{2}%' order by cldh", tbmaterial.Text, textBox6.Text, textBox7.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(dsN, "棧板表");

                    dataGridView3.DataSource = dsN.Tables[0];
                    dbConn11.CloseConnection();

                    dataGridView3.Columns[0].Width = 50;
                    dataGridView3.Columns[1].Width = 150;
                    comboBox2.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {

                    dsN = new DataSet();
                    DBconnect dbConn11 = new DBconnect();
                    string sql1 = string.Format("select * from bwzl where bwdh like '%{0}%' and ywsm like '%{1}%' order by bwdh", tbpart.Text, textBox8.Text);
                    Console.WriteLine(sql1);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, dbConn11.connection);
                    adapter.Fill(dsN, "棧板表");

                    dataGridView2.DataSource = dsN.Tables[0];
                    dbConn11.CloseConnection();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Visible = false;
                textBox4.Visible = false;
            }
            else 
            {
                comboBox2.Visible = true;
                textBox4.Visible = true;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modify == false)
                {
                    int result;
                    DBconnect conn = new DBconnect();
                    string sql1 = string.Format("insert into xxzlss (XieXing,SheHao,cond,BWBH,CLBH,CSBH,LOSS,CLSL,USERID,USERDATE,YN) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', GETDATE(), '1')", textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), comboBox2.Text, tbloss.Text, tbclsl.Text, userid);
                    Console.WriteLine(sql1);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text

                    SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                    conn.OpenConnection();
                    result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Insert Success 新增資料成功");
                    }
                    conn.CloseConnection();

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sql1Y = string.Format("DELETE xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
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
                else 
                {
                    //修改
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update xxzlss set BWBH = '{0}' , CLBH = '{1}', CSBH = '{2}', LOSS = '{3}', CLSL = '{4}', USERID = '{5}', USERDATE = GETDATE() where XieXing = '{6}' and SheHao = '{7}' and cond = '{8}'", dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), comboBox2.Text, tbloss.Text, tbclsl.Text, userid, textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString());
                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {
                        //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con4.CloseConnection();

                    #region LYSHOE

                    int resultY;
                    DBconnect2 connY = new DBconnect2();
                    string sql1Y = string.Format("DELETE xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss (XieXing,SheHao,cond, BWBH, CLBH,CSBH, LOSS,CLSL,USERID,USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text.Trim(), textBox2.Text.Trim());
                    Console.WriteLine(sql1Y);
                    //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                    SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                    connY.OpenConnection();
                    resultY = cmd1Y.ExecuteNonQuery();
                    if (resultY == 1)
                    {
                        MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connY.CloseConnection();

                    #endregion
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Insert Fail 新增資料失敗");
            }
            
            
            //bwbh = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //ywsm = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        #endregion
    }
}
