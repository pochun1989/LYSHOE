using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;

namespace NEWERPS
{
    public partial class InputBom : Form
    {
        public InputBom()
        {
            InitializeComponent();
        }

        #region 變數

        DataTableCollection tableCollection;
        public string userid = "";

        #endregion


        private void InputBom_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtFilename.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cboSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cboSheet.Items.Add(table.TableName);//add sheet to combobox
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("開啟檔案路徑失敗");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInput.Rows.Count == 0)
                {
                    DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
                    dgvInput.DataSource = dt;
                    BOM();
                    dgvInput.Columns[0].Width = 150;
                }
                else
                {
                    MessageBox.Show("資料已插入");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("載入資料失敗");
            }
        }

        private void BOM() 
        {
            try
            {
                string shehao = ""; //取出鞋號欄
                shehao = dgvInput.Rows[1].Cells[3].Value.ToString().Trim();      
                string[] condition = { "/" };
                string[] result = shehao.Split(condition, StringSplitOptions.None);
                //结果

                //選出第一個
                string tSt;
                int b = 2;
                tSt = result[0].Substring(result[0].Length - b);
                result[0] = tSt;
                int a = result.Length;

                for (int i = 0; i < a; i++) 
                {
                    Console.WriteLine(dgvInput.Rows[1].Cells[1].Value.ToString().Trim()); //鞋型
                    Console.WriteLine(result[i]); //色號


                    //max版本
                    string maxver = "";
                    DBconnect dbConn2 = new DBconnect();
                    string sql2 = string.Format("select isnull(MAX(VER),1) as ver  from xxzls where XieXing = '{0}' and SheHao = '{1}'", dgvInput.Rows[1].Cells[1].Value.ToString().Trim(), result[i]);

                    Console.WriteLine(sql2);

                    SqlCommand cmd2 = new SqlCommand(sql2, dbConn2.connection);
                    dbConn2.OpenConnection();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        maxver = reader2["ver"].ToString();
                    }
                    dbConn2.CloseConnection();

                    //maxBOM版本
                    string ver = "";
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select isnull(MAX(VER),0)+1 as VER from Usage_R where XieXing = '{0}' and SheHao = '{1}'", dgvInput.Rows[1].Cells[1].Value.ToString().Trim(), result[i]);
                    Console.WriteLine(sql);

                    SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                    dbConn.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ver = reader["ver"].ToString();
                    }
                    dbConn.CloseConnection();


                    //部位
                    for (int j = 3; j < dgvInput.Rows.Count; j ++) 
                    {
                        Console.WriteLine(dgvInput.Rows[j].Cells[0].Value.ToString().Trim()); //部位

                        for (int k = 5; k < dgvInput.Columns.Count -2; k++)
                        {
                            //Console.WriteLine(dgvInput.Rows[2].Cells[k].Value.ToString().Trim()); //尺碼
                            //Console.WriteLine(dgvInput.Rows[j].Cells[k].Value.ToString().Trim()); //數量
                            int result22;
                            DBconnect conn22 = new DBconnect();
                            string sql22 = string.Format("insert into Usage_R (XieXing,SheHao,BWBH,XTCC,VER,CLSL,USERDATE,USERID,xxzlver) values ('{0}','{1}','{2}','{3}','{7}','{4}',GETDATE(),'{5}', '{6}')", dgvInput.Rows[1].Cells[1].Value.ToString().Trim(), result[i], dgvInput.Rows[j].Cells[0].Value.ToString().Trim(), dgvInput.Rows[2].Cells[k].Value.ToString().Trim(), dgvInput.Rows[j].Cells[k].Value.ToString().Trim(), userid, maxver, ver);
                            Console.WriteLine(sql22);
                            //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                            SqlCommand cmd22 = new SqlCommand(sql22, conn22.connection);
                            conn22.OpenConnection();
                            result22 = cmd22.ExecuteNonQuery();
                            if (result22 == 1)
                            {
                                //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            conn22.CloseConnection();
                        }

                        #region LYSHOE

                        int result22Y;
                        DBconnect2 conn22Y = new DBconnect2();
                        string sql22Y = string.Format("delete xtbwyl1 where XieXing = '{0}' and SheHao = '{1}' insert into xtbwyl1 select XieXing, SheHao, BWBH, XTCC, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.Usage_R where XieXing = '{0}' and SheHao = '{1}'", dgvInput.Rows[1].Cells[1].Value.ToString().Trim(), result[i]);
                        Console.WriteLine(sql22Y);
                        //, tb對應1.Text, tb付款1.Text, tb扣趴1.Text, tb用戶1.Text
                        SqlCommand cmd22Y = new SqlCommand(sql22Y, conn22Y.connection);
                        conn22Y.OpenConnection();
                        result22Y = cmd22Y.ExecuteNonQuery();
                        if (result22Y == 1)
                        {
                            //MessageBox.Show("新增資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn22Y.CloseConnection();

                        #endregion
                    }
                                       
                }
            }
            catch (Exception) { }
        }
    }
}
