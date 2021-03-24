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
    public partial class Destination : Form
    {
        public Destination()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet(); // 儲存資料表容器  
        string sl = "";
        string idcheck = "";
        public string userid = "";
        int index = 0;

        public string languageType;
        public string userLanguage;
        public DataSet dsL = new DataSet();
        string userForm = "Destination";
        public DataSet dsl = new DataSet();

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
                P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 方法

        #region 清空文字

        private void Clean()
        {
            tb代號.Text = "";
            tb英文.Text = "";
            tb中文.Text = "";
            tb備註.Text = "";
            tb備註1.Text = "";
        }

        #endregion

        #region 允許編輯

        private void Edit()
        {

            tb中文.Enabled = true;
            tb英文.Enabled = true;
            tb備註.Enabled = true;
            tb備註1.Enabled = true;
        }

        #endregion

        #region 檢查新增ID

        private void CheckID()
        {
            try
            {
                //ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select count(DESTINATION_ID) as count from DESTINATION where DESTINATION_ID = '{0}'", tb代號.Text);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idcheck = reader["count"].ToString();
                }
                dbConn.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 插入方法

        private void InsertData()
        {
            try
            {
                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert into DESTINATION values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE())", tb代號.Text, tb中文.Text, tb英文.Text, tb備註.Text, tb備註1.Text, userid);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                conn.OpenConnection();
                result = cmd1.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception) { }

        }

        #endregion

        #region 還原按鈕

        private void TsbBack()
        {
            tsbQuery.Enabled = true;
            tsbClear.Enabled = false;
            tsbInsert.Enabled = true;
            tsbDelete.Enabled = true;
            tsbModify.Enabled = true;
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbFirst.Enabled = true;
            tsbPrior.Enabled = true;
            tsbNext.Enabled = true;
            tsbLast.Enabled = true;

            tb代號.Enabled = false;
            tb英文.Enabled = false;
            tb中文.Enabled = false;
            tb備註.Enabled = false;
            tb備註1.Enabled = false;
        }

        #endregion

        #region 修改方法

        private void ModifyData()
        {
            try
            {
                DBconnect con4 = new DBconnect();
                StringBuilder sql4 = new StringBuilder();
                sql4.AppendFormat("update DESTINATION set zwsm = '{0}', ywsm = '{1}', bz = '{2}', bz1 = '{3}', USERID = '{4}', USERDATE = GETDATE() where DESTINATION_ID = '{5}'", tb中文.Text, tb英文.Text, tb備註.Text, tb備註1.Text, userid, tb代號.Text);

                Console.WriteLine(sql4);
                SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                con4.OpenConnection();
                int result4 = cmd4.ExecuteNonQuery();
                if (result4 == 1)
                {
                    MessageBox.Show("修改資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con4.CloseConnection();
            }
            catch (Exception) { }
        }


        #endregion

        #region 重新讀取

        private void Reload()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from DESTINATION");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(ds, "棧板表");
            dataGridView1.DataSource = ds.Tables[0];
        }

        #endregion

        #endregion

        #region 事件

        #endregion

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DestinationQuery Form = new DestinationQuery();
                Form.ShowDialog();
                dataGridView1.DataSource = Form.ds.Tables[0];
                //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Visible = true;

                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            catch (Exception)
            { 
            }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            sl = "1";
            Clean();
            Edit();
            tb代號.Enabled = true;


            tsbQuery.Enabled = false;
            tsbClear.Enabled = true;
            tsbInsert.Enabled = false;
            tsbDelete.Enabled = false;
            tsbModify.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            tsbFirst.Enabled = false;
            tsbPrior.Enabled = false;
            tsbNext.Enabled = false;
            tsbLast.Enabled = false;

            tabControl1.SelectedTab = P0002;
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                sl = "2";
                Edit();
                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                tsbFirst.Enabled = false;
                tsbPrior.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false;
            }
            catch (Exception) { }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sl == "1") //新增
                {
                    CheckID();
                    if (idcheck == "1")
                    {
                        MessageBox.Show("ID重複", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (tb代號.Text == "" || tb英文.Text == "" || tb中文.Text == "")
                        {
                            MessageBox.Show("內容不能為空", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            InsertData();
                        }
                    }
                }
                else if (sl == "2") //修改
                {
                    Console.WriteLine("MODIFY");
                    ModifyData();
                }

                sl = "";
                TsbBack();
                Reload();
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            TsbBack();
            Reload();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tb英文.Text = "";
            tb中文.Text = "";
            tb備註.Text = "";
            tb備註1.Text = "";
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

                tsbPrior.Enabled = false;
                tsbNext.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb備註1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbPrior_Click(object sender, EventArgs e)
        {
            try
            {
                int indexData;

                if (index == 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
                else
                {
                    indexData = index - 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];

                }
                tsbNext.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb備註1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            try
            {
                int indexData;

                if (index == dataGridView1.RowCount - 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                }
                else
                {
                    indexData = index + 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[indexData].Cells[0];

                }
                tsbPrior.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb備註1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }

        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                tsbNext.Enabled = false;
                tsbPrior.Enabled = true;
                tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tb備註.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tb備註1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tb代號.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb英文.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb中文.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb備註.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tb備註1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void Destination_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();
            ChangeDataView();
            ChangeTabControl();
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string shehao = "";
                shehao = dataGridView1.Rows[i].Cells[0].Value.ToString();
                shehao = "'" + shehao;
                dataGridView1.Rows[i].Cells[4].Value = shehao;
            }

            ExportExcel("report", dataGridView1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string shehao = "";
                shehao = dataGridView1.Rows[i].Cells[4].Value.ToString();
                shehao = shehao.Substring(1);
                dataGridView1.Rows[i].Cells[0].Value = shehao;
            }
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
    }
}
