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
    /// QuoteOrder 報價單
    /// </summary>
    public partial class QO : Form
    {
        #region 變數

        /// <summary>
        /// 採購單頭容器
        /// </summary>
        DataSet dsQO = new DataSet();
        /// <summary>
        /// 採購單頭最大值容器
        /// </summary>
        DataSet dsbigQO = new DataSet();
        /// <summary>
        /// 採購單身容器
        /// </summary>
        DataSet dsQOM = new DataSet();
        /// <summary>
        /// 報價單頭刪除表
        /// </summary>
        DataTable dtcgbjd = new DataTable("報價單頭刪除表");
        /// <summary>
        /// 報價單身刪除表
        /// </summary>
        DataTable dtcgbjsd = new DataTable("報價單身刪除表");
        /// <summary>
        /// Locate報價單頭欄位
        /// </summary>
        private string mbjno, mzsdh;
        public string USERID;
        /// <summary>
        /// UI新增修改按鈕變數
        /// </summary>
        private string tsbIsInsertOrModify;
        /// <summary>
        /// 報價單頭號
        /// </summary>
        private string bjno;
        private bool detailvalueischange = false;

        #endregion

        #region 構造函式

        public QO()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void QuoteOrder_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            // DGV單頭附值(無值)
            QueryCGBJ("=''", "", "", "");
            //tcQuoteOrder.SelectedIndex=
        }

        #endregion

        #region TabControl Event

        private void tcQuoteOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: // 報價單頭
                    tsbDelete.Enabled = dgvQuoteOrderMaster.Rows.Count > 0 ? true : false;
                    tsbModify.Enabled = false;
                    break;
                case 1: // 報價單身
                    tsbDelete.Enabled = false;
                    if (tbBJNO.Text != "")
                    {
                        QueryCGBJS();
                        tsbModify.Enabled = dgvQuoteOrderDetail.Rows.Count > 0 ? true : false;
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Quote Order!");
                        tcQuoteOrder.SelectedIndex = 0;
                    }
                    break;
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcQuoteOrder.SelectedIndex != 0)
            {
                tcQuoteOrder.SelectedIndex = 0;
            }
            else if (dgvQuoteOrderMaster.DataSource == null || tcQuoteOrder.SelectedIndex == 0)
            {
                QOD qod = new QOD();
                qod.ShowDialog();
                if (qod.isq)
                {
                    QueryCGBJ(qod.廠商, qod.報價單號, qod.開單日起, qod.開單日止);
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteCGBJ(dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString(), dgvQuoteOrderMaster.CurrentRow.Cells[1].Value.ToString());
        }

        #endregion

        #region 編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            tsbIsInsertOrModify = "Modify";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 報價單確認按鈕事件

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            QOC qoc = new QOC();
            qoc.ShowDialog();
        } 

        #endregion

        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (tcQuoteOrder.SelectedIndex == 0) // 報價單頭
            {
                if (dgvQuoteOrderMaster.CurrentRow.Cells[4].Value.ToString() == "" || dgvQuoteOrderMaster.CurrentRow.Cells[5].Value.ToString() == "")
                {
                    MessageBox.Show("Can't Save When User Didn't Input Dedate or Endate!");
                }
                else
                {
                    dgvQuoteOrderMaster.CurrentCell = null; // 去除指標
                    dgvQuoteOrderMaster.AllowUserToAddRows = false;
                    dgvQuoteOrderMaster.ReadOnly = true;
                    dgvQuoteOrderRowState(dsQO.Tables["報價單頭速查表"]); //判斷欄位狀態(dsQO)
                    QueryCGBJ(mbjno, mzsdh); // 重新載入查詢
                    tsbIsInsertOrModify = "Recover";
                    tsbChoice(tsbIsInsertOrModify);
                }
            }
            else if (tcQuoteOrder.SelectedIndex == 1) // 報價單身
            {
                dgvQuoteOrderDetail.CurrentCell = null; // 去除指標
                dgvQuoteOrderDetail.AllowUserToAddRows = false;
                dgvQuoteOrderDetail.AllowUserToDeleteRows = false;
                dgvQuoteOrderDetail.ReadOnly = true;
                dgvQuoteOrderDetailRowState(dsQOM.Tables["報價單身速查表"], dsQOM.Tables["報價單身速查原始表"]); //判斷欄位狀態(dsQOM)
                QueryCGBJS(); // 重新載入查詢
                tsbIsInsertOrModify = "Recover";
                tsbChoice(tsbIsInsertOrModify);
            }
        }

        #endregion

        #region 取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (tcQuoteOrder.SelectedIndex == 0) // 報價單頭
            {
                dgvQuoteOrderMaster.CurrentCell = null; // 去除指標
                dgvQuoteOrderMaster.AllowUserToAddRows = false;
                dgvQuoteOrderMaster.ReadOnly = true;
                QueryCGBJ("", ""); // 重新載入查詢
            }
            else if (tcQuoteOrder.SelectedIndex == 1) // 報價單身
            {
                dgvQuoteOrderDetail.CurrentCell = null; // 去除指標
                dgvQuoteOrderDetail.AllowUserToAddRows = false;
                dgvQuoteOrderDetail.AllowUserToDeleteRows = false;
                dgvQuoteOrderDetail.ReadOnly = true;
                QueryCGBJS(); // 重新載入查詢
            }
            tsbIsInsertOrModify = "Recover";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion

        #region 離開頁面按鈕事件

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //MessageBox.Show(dgvQuoteOrderDetail.CurrentRow.Cells[5].Value.ToString());
        } 

        #endregion

        #region 報價單事件

        #region 報價單頭事件

        #region 報價單頭限制編輯欄位事件

        private void dgvQuoteOrderMaster_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tsbIsInsertOrModify == "Insert")
            {
                if (e.ColumnIndex != 0 && e.ColumnIndex != 1 && e.ColumnIndex != 2 && e.ColumnIndex != 6 && e.ColumnIndex != 7)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region DGV點擊事件

        // 單點
        private void dgvQuoteOrderMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bjno = dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString();
            if (dgvQuoteOrderMaster.CurrentRow.Cells[1].Value.ToString() == "")
            {
                tsbDelete.Enabled = false;
                if (e.ColumnIndex != 1)
                {
                    MessageBox.Show("Please Insert Vendor First!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.CurrentRow.Cells[1];
                }
            }
            else if (dgvQuoteOrderMaster.CurrentRow.Cells[4].Value.ToString() == "")
            {
                tsbDelete.Enabled = false;
                if (e.ColumnIndex != 4)
                {
                    MessageBox.Show("Please Insert Dedate!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.CurrentRow.Cells[4];
                }
            }
            else if (dgvQuoteOrderMaster.CurrentRow.Cells[5].Value.ToString() == "")
            {
                tsbDelete.Enabled = false;
                if (e.ColumnIndex != 5)
                {
                    MessageBox.Show("Please Insert Endate!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.CurrentRow.Cells[5];
                }
            }
            else
            {
                tsbDelete.Enabled = true;
            }
        }

        // 雙點
        private void dgvQuoteOrderMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbIsInsertOrModify == "Insert" || tsbIsInsertOrModify == "Modify")
            {
                if (dgvQuoteOrderMaster.CurrentRow.Cells[1].Value.ToString() == "" && e.ColumnIndex != 1)
                {
                    MessageBox.Show("Please Insert Vendor First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.CurrentRow.Cells[1];
                }
                else
                {
                    if (tsbIsInsertOrModify == "Insert")
                    {
                        if (e.ColumnIndex == 1 && e.RowIndex != -1) // 廠商編號
                        {
                            QOSZSBH qosz = new QOSZSBH();
                            qosz.廠商編號 = dgvQuoteOrderMaster.CurrentRow.Cells[1].Value.ToString();
                            qosz.廠商簡寫 = dgvQuoteOrderMaster.CurrentRow.Cells[2].Value.ToString();
                            qosz.ShowDialog();
                            if (qosz.isSave)
                            {
                                dgvQuoteOrderMaster.CurrentRow.Cells[1].Value = qosz.廠商編號;
                                dgvQuoteOrderMaster.CurrentRow.Cells[2].Value = qosz.廠商簡寫;
                                if (tsbIsInsertOrModify == "Insert")
                                {
                                    dgvQuoteOrderMaster.AllowUserToAddRows = false;
                                    dgvQuoteOrderMaster.AllowUserToAddRows = true;
                                }
                                dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.Rows[e.RowIndex].Cells[1];
                            }
                        }
                    }
                }
            }
            else
            {
                bjno = dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString();
                tbBJNO.Text = bjno;
                tbSUppID.Text = dgvQuoteOrderMaster.CurrentRow.Cells[1].Value.ToString();
                tbSUppName.Text = dgvQuoteOrderMaster.CurrentRow.Cells[2].Value.ToString();
                tbBJDate.Text = dgvQuoteOrderMaster.CurrentRow.Cells[6].Value.ToString();
                tbCFMID.Text = dgvQuoteOrderMaster.CurrentRow.Cells[7].Value.ToString();
                tcQuoteOrder.SelectedIndex = 1;
            }
        }

        #endregion

        #region 報價單頭新增與修改事件

        private void dgvQuoteOrderMaster_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (tsbIsInsertOrModify == "Insert" && dgvQuoteOrderMaster.CurrentRow.Cells[0].Value.ToString() == "")
                {
                    dgvQuoteOrderMaster.CurrentRow.Cells[7].Value = USERID;
                }
            }
        }

        #endregion

        #region 報價單頭DGV欄位改DTP事件

        private void dgvQuoteOrderMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvQuoteOrderMaster.CurrentCell.ColumnIndex < 0) return;
            Control parentCTL = e.Control.Parent;

            if ((dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbdedate") || (dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbendate"))
            {
                DateTimePicker dtPicker = new DateTimePicker();
                dtPicker.Name = "dateTimePicker1";
                dtPicker.Size = dgvQuoteOrderMaster.CurrentCell.Size;
                if (dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbdedate" || dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbendate")
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

        #endregion

        #region 第三方控件DTP值改變事件

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbdedate")
            {
                dgvQuoteOrderMaster.CurrentCell.Value = ((DateTimePicker)sender).Value.ToString("yyyy/MM/dd");
            }
            else if (dgvQuoteOrderMaster.Columns[dgvQuoteOrderMaster.CurrentCell.ColumnIndex].Name == "tbendate")
            {
                dgvQuoteOrderMaster.CurrentCell.Value = ((DateTimePicker)sender).Value.ToString("yyyy/MM/dd");
            }
        }

        #endregion

        #endregion

        #region 報價單身事件

        #region 報價單身限制編輯欄位事件

        private void dgvQuoteOrderDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.ColumnIndex != 2 && e.ColumnIndex != 8)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion
        
        #region DGV點擊事件

        // 單點
        private void dgvQuoteOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuoteOrderDetail.CurrentRow.Cells[0].Value.ToString() == "" && e.ColumnIndex != 0)
            {
                MessageBox.Show("Please Insert CLDH First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvQuoteOrderDetail.CurrentCell = dgvQuoteOrderDetail.CurrentRow.Cells[0];
            }
        }

        // 雙點
        private void dgvQuoteOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbIsInsertOrModify == "Insert" || tsbIsInsertOrModify == "Modify")
            {
                if (dgvQuoteOrderDetail.CurrentRow.Cells[0].Value.ToString() == "" && e.ColumnIndex != 0)
                {
                    MessageBox.Show("Please Insert CLDH First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvQuoteOrderDetail.CurrentCell = dgvQuoteOrderDetail.CurrentRow.Cells[0];
                }
                else
                {
                    if (e.ColumnIndex == 0 && e.RowIndex != -1) // 材料編號
                    {
                        QODSCLBH qosc = new QODSCLBH();
                        qosc.材料編號 = dgvQuoteOrderDetail.CurrentRow.Cells[0].Value.ToString();
                        qosc.ShowDialog();
                        if (qosc.isSave)
                        {
                            dgvQuoteOrderDetail.CurrentRow.Cells[0].Value = qosc.材料編號;
                            dgvQuoteOrderDetail.CurrentRow.Cells[1].Value = qosc.材料名稱;
                            dgvQuoteOrderDetail.CurrentRow.Cells[2].Value = qosc.單位編號;
                            if (tsbIsInsertOrModify == "Insert")
                            {
                                dgvQuoteOrderDetail.AllowUserToAddRows = false;
                                dgvQuoteOrderDetail.AllowUserToAddRows = true;
                            }
                            dgvQuoteOrderDetail.CurrentCell = dgvQuoteOrderDetail.Rows[e.RowIndex].Cells[1];
                        }
                    }
                }
            }
        }

        #endregion

        #region 報價單身新增與修改事件

        private void dgvQuoteOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbIsInsertOrModify == "Insert" || tsbIsInsertOrModify == "Modify")
            {
                if (e.ColumnIndex == 3 && dgvQuoteOrderDetail.CurrentRow.Cells[4].Value.ToString() != "")
                {
                    if (!detailvalueischange)
                    {
                        detailvalueischange = true;
                        dgvQuoteOrderDetail.CurrentRow.Cells[4].Value = DBNull.Value;
                    }
                }
                else if (e.ColumnIndex == 4 && dgvQuoteOrderDetail.CurrentRow.Cells[3].Value.ToString() != "")
                {
                    if (!detailvalueischange)
                    {
                        detailvalueischange = true;
                        dgvQuoteOrderDetail.CurrentRow.Cells[3].Value = DBNull.Value;
                    }
                }
            }
            detailvalueischange = false;
        } 

        #endregion

        #endregion

        #endregion

        #endregion

        #region 方法

        #region UI邏輯

        #region TSB判定

        private void tsbChoice(string insertormodify)
        {
            if (insertormodify == "Insert")
            {
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbDelete.Enabled = false;
                tsbModify.Enabled = false;
                tsbSave.Enabled = true;
                tsbCancel.Enabled = true;
                if (tcQuoteOrder.SelectedIndex == 0) // 報價單頭
                {
                    dgvQuoteOrderMaster.ReadOnly = false;
                    dgvQuoteOrderMaster.AllowUserToAddRows = true;
                    if (dgvQuoteOrderMaster.Rows.Count > 0)
                    {
                        dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.Rows[dgvQuoteOrderMaster.Rows.Count - 1].Cells[1];
                    }
                }
                else if (tcQuoteOrder.SelectedIndex == 1) // 報價單身
                {
                    dgvQuoteOrderDetail.ReadOnly = false;
                    dgvQuoteOrderDetail.AllowUserToAddRows = true;
                    dgvQuoteOrderDetail.AllowUserToDeleteRows = true;
                    if (dgvQuoteOrderDetail.Rows.Count > 0)
                    {
                        dgvQuoteOrderDetail.CurrentCell = dgvQuoteOrderDetail.Rows[dgvQuoteOrderDetail.Rows.Count - 1].Cells[1];
                    }
                }
            }
            else if (insertormodify == "Modify")
            {
                if (tcQuoteOrder.SelectedIndex == 1) // 報價單身
                {
                    tsbQuery.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = true;
                    tsbCancel.Enabled = true;
                    dgvQuoteOrderDetail.ReadOnly = false;
                    dgvQuoteOrderDetail.AllowUserToDeleteRows = true;
                }
            }
            else if (insertormodify == "Recover")
            {
                dgvCGBJSDelete.DataSource = null; // 清除刪除表資料
                tsbQuery.Enabled = true;
                tsbInsert.Enabled = true;
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
                if (tcQuoteOrder.SelectedIndex == 0) // 報價單頭
                {
                    tsbDelete.Enabled = dgvQuoteOrderMaster.Rows.Count > 0 ? true : false;
                    tsbModify.Enabled = false;
                }
                else if (tcQuoteOrder.SelectedIndex == 1) // 報價單身
                {
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = dgvQuoteOrderDetail.Rows.Count > 0 ? true : false;
                }
            }
        }

        #endregion

        #endregion
        
        #region 報價單頭

        #region 查詢報價單頭方法

        private void QueryCGBJ(string zsbh, string bjno, string datestart, string dateend)
        {
            dsQO = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bj.BJNO,bj.ZSBH,z.zsjc,bj.Vbjno,bj.dedate,bj.endate,bj.CFMDate,bj.CFMID " +
                    "from CGBJ bj left join zszl z on z.zsdh=bj.ZSBH " +
                    "where bj.YN='1' and bj.ZSBH {0} and bj.BJNO like'%{1}%' and bj.USERDATE between '{2}' and '{3}' order by BJNO desc"
                    , zsbh, bjno, datestart, dateend);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQO, "報價單頭速查表");
                this.dgvQuoteOrderMaster.DataSource = dsQO.Tables[0];
                this.dgvQuoteOrderMaster.Columns[1].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                this.dgvQuoteOrderMaster.CurrentCell = null;
                this.dgvQuoteOrderDetail.DataSource = null;
                tsbDelete.Enabled = dgvQuoteOrderMaster.Rows.Count > 0 ? true : false;
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        /// <summary>
        /// 存檔重新載入呼叫
        /// </summary>
        private void QueryCGBJ(string bjno, string zsbh)
        {
            dsQO = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bj.BJNO,bj.ZSBH,z.zsjc,bj.Vbjno,bj.dedate,bj.endate,bj.CFMDate,bj.CFMID " +
                    "from CGBJ bj left join zszl z on z.zsdh=bj.ZSBH " +
                    "where ZSBH like'{0}%' and bj.YN='1' order by BJNO desc"
                    , zsbh);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQO, "報價單頭速查表");
                this.dgvQuoteOrderMaster.DataSource = dsQO.Tables[0];
                this.dgvQuoteOrderMaster.Columns[1].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                this.dgvQuoteOrderMaster.CurrentCell = null;
                this.dgvQuoteOrderDetail.DataSource = null;
                tsbDelete.Enabled = dgvQuoteOrderMaster.Rows.Count > 0 ? true : false;
                if (bjno != "")
                {
                    DataRow[] rows = dsQO.Tables[0].Select("BJNO='" + bjno + "'");
                    if (rows.Length == 0)
                    {
                        MessageBox.Show("空");
                    }
                    else
                    {
                        int index = dsQO.Tables[0].Rows.IndexOf(rows[0]);
                        dgvQuoteOrderMaster.CurrentCell = dgvQuoteOrderMaster.Rows[index].Cells[0];
                        dgvQuoteOrderMaster_CellClick(dgvQuoteOrderMaster, new DataGridViewCellEventArgs(index, 0));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion

        #region 判斷報價單頭DataSet列狀態

        /// <summary>
        /// 判斷報價單頭DataSet列狀態
        /// </summary>
        /// <param name="dtBOM">目標dataset</param>
        private void dgvQuoteOrderRowState(DataTable dtBOM)
        {
            try
            {
                for (int i = 0; i < dtBOM.Rows.Count; i++)
                {
                    if (dtBOM.Rows[i].RowState.ToString() == "Added")
                    {
                        InsertCGBJ(dgvQuoteOrderMaster.Rows[i].Cells[1].Value.ToString(), dgvQuoteOrderMaster.Rows[i].Cells[3].Value.ToString(), Convert.ToDateTime(dgvQuoteOrderMaster.Rows[i].Cells[4].Value).ToString("yyyy-MM-dd"), Convert.ToDateTime(dgvQuoteOrderMaster.Rows[i].Cells[5].Value).ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Status Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region 新增報價單頭方法

        private void InsertCGBJ(string zsbh, string vbjno, string dedate, string endate)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string bjno = null;
                // 採購單號最大值
                dsbigQO = new DataSet();
                try
                {
                    string sqlb = "select top 1 SUBSTRING(BJNO,7,5) from CGBJ where BJNO like SUBSTRING(convert(varchar, GETDATE(), 112),1,6)+'%' order by BJNO desc";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlb, dbconn.connection);
                    adapter.Fill(dsbigQO, "採購單最大值");
                    bjno = DateTime.Today.ToString("yyyyMM") + (Convert.ToInt32(dsbigQO.Tables[0].Rows[0][0]) + 1).ToString().PadLeft(5, '0');
                }
                catch (Exception)
                {
                    bjno = DateTime.Today.ToString("yyyyMM") + "00001";
                }
                string sql = string.Format("insert into CGBJ(BJNO,ZSBH,Vbjno,dedate,endate,YN,USERDATE,USERID) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','1',getdate(),'{5}')"
                    , bjno, zsbh, vbjno, dedate, endate, USERID);
                mbjno = bjno;
                mzsdh = zsbh;
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert CGBJ Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 刪除報價單頭方法

        private void DeleteCGBJ(string bjno, string zsbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                DialogResult dr = MessageBox.Show("Delete : " + bjno + " This QuoteOrder?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = string.Format("update CGBJ set YN='0' where BJNO='{0}' and ZSBH='{1}' " +
                    "update CGBJS set YN='0' where BJNO='{2}'"
                    , bjno, zsbh, bjno);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Delete CGBJ Success!");
                        QueryCGBJ("", zsbh);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Delete CGBJ Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion

        #region 報價單身
        
        #region 查詢報價單身方法

        private void QueryCGBJS()
        {
            dsQOM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select bs.CLBH,c.ywpm,c.dwbh,bs.USPrice,bs.VNPrice" +
                    ",case when bs.BJLX='1' then N'開發材料' when bs.BJLX='2' then N'生產材料' when bs.BJLX='3' then N'其他' when bs.BJLX='4' then N'總務' when bs.BJLX='5' then N'外箱' when bs.BJLX='7' then N'化學' when bs.BJLX='8' then N'模製具' end BJLX" +
                    ",bs.BJClass,bs.Memo,bs.YN,bs.BOQ,bs.TOQ,bs.ddays " +
                    "from CGBJS bs " +
                    "left join CGBJ b on b.BJNO=bs.BJNO " +
                    "left join clzl c on c.cldh=bs.CLBH " +
                    "where bs.BJNO='{0}' order by bs.CLBH", tbBJNO.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQOM, "報價單身速查表");
                this.dgvQuoteOrderDetail.DataSource = dsQOM.Tables[0];
                // 原始
                string sqlorg = string.Format("select bs.CLBH,c.ywpm,c.dwbh,bs.USPrice,bs.VNPrice" +
                    ",case when bs.BJLX='1' then N'開發材料' when bs.BJLX='2' then N'生產材料' when bs.BJLX='3' then N'其他' when bs.BJLX='4' then N'總務' when bs.BJLX='5' then N'外箱' when bs.BJLX='7' then N'化學' when bs.BJLX='8' then N'模製具' end BJLX" +
                    ",bs.BJClass,bs.Memo,bs.YN,bs.BOQ,bs.TOQ,bs.ddays " +
                    "from CGBJS bs " +
                    "left join CGBJ b on b.BJNO=bs.BJNO " +
                    "left join clzl c on c.cldh=bs.CLBH " +
                    "where bs.BJNO='{0}' order by bs.CLBH", tbBJNO.Text);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlorg, dbConn.connection);
                adapter2.Fill(dsQOM, "報價單身速查原始表");
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion

        #region 判斷報價單身DataSet列狀態

        /// <summary>
        /// 判斷報價單身DataSet列狀態
        /// </summary>
        /// <param name="dtBOM">目標dataset</param>
        private void dgvQuoteOrderDetailRowState(DataTable dtBOM, DataTable dtBOMorg)
        {
            try
            {
                int dcount = 0;
                for (int i = 0; i < dtBOM.Rows.Count; i++)
                {
                    if (dtBOM.Rows[i].RowState.ToString() == "Added")
                    {
                        if (dgvQuoteOrderDetail.Rows[i].Cells[3].Value.ToString() == "" && dgvQuoteOrderDetail.Rows[i].Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("USPrice and VNprice at least enter one!");
                            continue;
                        }
                        else
                        {
                            InsertCGBJS(tbBJNO.Text, dgvQuoteOrderDetail.Rows[i].Cells[0].Value.ToString(), BJLXno(dgvQuoteOrderDetail.Rows[i].Cells[5].Value.ToString()), dgvQuoteOrderDetail.Rows[i].Cells[6].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[3].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[4].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[11].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[9].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[10].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[7].Value.ToString());
                        }
                    }
                    else if (dtBOM.Rows[i].RowState.ToString() == "Modified")
                    {
                        if (dgvQuoteOrderDetail.Rows[i].Cells[3].Value.ToString() == "" && dgvQuoteOrderDetail.Rows[i].Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("USPrice and VNprice at least enter one!");
                            continue;
                        }
                        else
                        {
                            UpdateCGBJS(tbBJNO.Text, dtBOMorg.Rows[i][0].ToString(), BJLXno(dtBOMorg.Rows[i][5].ToString()), dgvQuoteOrderDetail.Rows[i].Cells[0].Value.ToString(), BJLXno(dgvQuoteOrderDetail.Rows[i].Cells[5].Value.ToString()), dgvQuoteOrderDetail.Rows[i].Cells[6].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[3].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[4].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[11].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[9].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[10].Value.ToString(), dgvQuoteOrderDetail.Rows[i].Cells[7].Value.ToString());
                        }
                    }
                    else if (dtBOM.Rows[i].RowState.ToString() == "Deleted")
                    {
                        if (dcount == 0)
                        {
                            for (int j = 0; j < dgvCGBJSDelete.Rows.Count; j++)
                            {
                                DeleteCGBJS(dgvCGBJSDelete.Rows[j].Cells[0].Value.ToString(), dgvCGBJSDelete.Rows[j].Cells[1].Value.ToString(), dgvCGBJSDelete.Rows[j].Cells[2].Value.ToString());
                            }
                            dcount++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("RowState Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region 新增報價單身方法

        private void InsertCGBJS(string bjno, string clbh, string bjlx, string bjclass, string usprice, string vnprice, string ddays, string boq, string toq, string memo)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into CGBJS (BJNO,CLBH,BJLX,BJClass,USPrice,VNPrice,ddays,BOQ,TOQ,Memo,YN,USERDate,USERID) " +
                    "values ('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},'1',getdate(),'{10}')"
                    , bjno, clbh, bjlx, bjclass==""?"null":"'"+ bjclass+"'", usprice == "" ? "null" : usprice, vnprice == "" ? "null" : vnprice, ddays == "" ? "0" : ddays, boq == "" ? "0" : boq, toq == "" ? "0" : toq, memo == "" ? "null" : "'" + memo + "'", USERID);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert CGBJS Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 修改報價單身方法

        private void UpdateCGBJS(string orgbjno, string orgclbh, string orgbjlx, string clbh, string bjlx, string bjclass, string usprice, string vnprice, string ddays, string boq, string toq, string memo)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update CGBJS set CLBH='{0}',BJLX='{1}',BJClass={2},USPrice={3},VNPrice={4},ddays={5},BOQ={6},TOQ={7},Memo={8},USERDate=GETDATE(),USERID='{9}' " +
                    "where BJNO='{10}' and CLBH='{11}' and BJLX='{12}'"
                    , clbh, bjlx, bjclass == "" ? "null" : "'" + bjclass + "'", usprice == "" ? "null" : usprice, vnprice == "" ? "null" : vnprice, ddays == "" ? "0" : ddays, boq == "" ? "0" : boq, toq == "" ? "0" : toq, memo == "" ? "null" : "'" + memo + "'", USERID
                    , orgbjno, orgclbh, orgbjlx);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("Modify CGBJS Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region BJLX選項代號

        private string BJLXno(string bjlxinput)
        {
            switch (bjlxinput)
            {
                case "開發材料":
                    bjlxinput = "1";
                    break;
                case "生產材料":
                    bjlxinput = "2";
                    break;
                case "其他":
                    bjlxinput = "3";
                    break;
                case "總務":
                    bjlxinput = "4";
                    break;
                case "外箱":
                    bjlxinput = "5";
                    break;
                case "化學":
                    bjlxinput = "7";
                    break;
                case "模製具":
                    bjlxinput = "8";
                    break;
            }
            return bjlxinput;
        }

        #endregion

        #region 把要刪除的資料放入DGV容器

        private void dgvQuoteOrderDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvCGBJSDelete.DataSource == null)
            {
                dtcgbjsd = new DataTable("報價單身刪除表");
                // 開表
                dtcgbjsd.Columns.Add("rbjno", typeof(string));
                dtcgbjsd.Columns.Add("rcldh", typeof(string));
                dtcgbjsd.Columns.Add("rbjlx", typeof(string));
            }
            DataRow dr = dtcgbjsd.NewRow();
            dr[0] = tbBJNO.Text;
            dr[1] = dgvQuoteOrderDetail.CurrentRow.Cells[0].Value.ToString();
            dr[2] = dgvQuoteOrderDetail.CurrentRow.Cells[5].Value.ToString();
            dtcgbjsd.Rows.Add(dr);
            dgvCGBJSDelete.DataSource = dtcgbjsd;
        }

        #endregion

        #region 刪除報價單身方法

        private void DeleteCGBJS(string bjno, string clbh,string bjlx)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("delete CGBJS where BJNO='{0}' and CLBH='{1}' and BJLX='{2}'"
                    , bjno, clbh, bjlx);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Delete CGBJS Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion

        #endregion

        
    }
}
