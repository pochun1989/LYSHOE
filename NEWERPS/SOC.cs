using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEWERPS
{
    /// <summary>
    /// SampleOrderCreate 樣品單建立
    /// </summary>
    public partial class SOC : Form
    {
        #region 變數
        /// <summary>
        /// 輸出EXCEL內容容器
        /// </summary>
        DataSet dsexcel = new DataSet();
        /// <summary>
        /// 材料交期容器
        /// </summary>
        DataSet dsmdq = new DataSet();
        DataSet dsQQuery = new DataSet();
        /// <summary>
        /// 下拉選單容器
        /// </summary>
        DataSet dscb = new DataSet();
        /// <summary>
        /// 鞋型BOM容器
        /// </summary>
        DataSet dsBOM = new DataSet();
        /// <summary>
        /// 鞋型備註容器
        /// </summary>
        DataSet dsRE = new DataSet();
        /// <summary>
        /// 樣品單容器
        /// </summary>
        DataSet dsOrder = new DataSet();
        public string USERID;
        /// <summary>
        /// UI新增修改按鈕變數
        /// </summary>
        private string tsbIsInsertOrModify;
        /// <summary>
        /// 樣品單流水號
        /// </summary>
        private string orderSerialNum;
        /// <summary>
        /// 選擇樣式(1.樣品單 or 2.鞋型BOM or 3.鞋型備註)
        /// </summary>
        private int selectpart;
        /// <summary>
        /// 樣品編號
        /// </summary>
        private string sampleNo;
        /// <summary>
        /// 鞋型備註刪除表
        /// </summary>
        DataTable dtrd = new DataTable("鞋型備註刪除表");
        /// <summary>
        /// 鞋型BOM刪除表
        /// </summary>
        DataTable dtbd = new DataTable("鞋型BOM刪除表");
        /// <summary>
        /// 紀錄舊樣品單號(拷貝用)
        /// </summary>
        private string osampleorderno;
        private bool isCopy = false; // 拷貝是否成功
        private bool isCost = false; // 成本上傳成功
        private int tsbindex; // 存目前速查點擊格數

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "SOC";

        #endregion

        #region 構造函式

        public SOC()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void SampleOrderCreate_Load(object sender, EventArgs e)
        {
            USERID = Program.User.userID;
            
            GetCombobox();

            ////獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            ////更改語言
            ChangeLabel();
            ChangePanel();
            ChangeDataView();
        }

        #endregion

        #region 頁面最小值

        private void SOC_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height < 668)
            {
                this.Height = 668;
            }
            if (this.Width < 1034)
            {
                this.Width = 1034;
            }
        } 

        #endregion

        #region TabControls Event

        private void tcSampleOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcSampleOrder.SelectedIndex == 1)
            {
                tsbExcel.Enabled = tbSampleOrderNo.Text == "" ? false : true;
                tsbCost.Enabled = dgvDevBOM.RowCount > 0 ? true : false;
                tsbModify.Enabled = true;
                tsbCopy.Enabled = true;
                tsbInsert.Enabled = true;
            }
            else if (tcSampleOrder.SelectedIndex == 2)
            {
                tsbExcel.Enabled = false;
                tsbCost.Enabled = false;
                tsbModify.Enabled = false;
                tsbInsert.Enabled = false;
                tsbCopy.Enabled = false;
                MaterialDateTimeQuery();
            }
            else
            {
                tsbExcel.Enabled = false;
                tsbCost.Enabled = false;
            }
        } 

        #endregion

        #region 查詢按鈕事件

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            if (tcSampleOrder.SelectedIndex != 0)
            {
                tcSampleOrder.SelectedIndex = 0;
            }
            else if (dgvSampleOrder.DataSource == null || tcSampleOrder.SelectedIndex == 0)
            {
                SOCD socd = new SOCD();
                socd.ShowDialog();
                if (socd.isq)
                {
                    QueryDevSampleOrder(socd.樣品單號, socd.鞋型, socd.色號, socd.ART, socd.階段, socd.季節);
                    if (dgvSampleOrder.Rows.Count != 0)
                    {
                        tsbFirst.Enabled = true;
                        tsbPrior.Enabled = true;
                        tsbNext.Enabled = true;
                        tsbLast.Enabled = true;
                    }
                    else
                    {
                        tsbFirst.Enabled = false;
                        tsbPrior.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbLast.Enabled = false;
                    }
                }
            }
        }

        #endregion

        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            if (tbSampleOrderNo.Text == "")
            {
                btnOrder.Visible = true;
                btnOrder.PerformClick();
            }
            else
            {
                btnOrder.Visible = true;
                btnBOM.Visible = true;
                btnRemark.Visible = true;
            }
            tcSampleOrder.SelectedIndex = 1;
            tsbIsInsertOrModify = "Insert";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion
        
        #region 新增修改選擇項目按鈕事件

        // 樣品單
        private void btnOrder_Click(object sender, EventArgs e)
        {
            selectpart = 1;
            EnableUIColumns(true);
            tsbSave.Enabled = true;
            tcDevShoeModel.Enabled = false;
            btnBOM.Visible = false;
            btnRemark.Visible = false;
            if (tsbIsInsertOrModify == "Insert")
            {
                ClearTextbox();
                tbUserID.Text = USERID;
                DataTable dtbom = (DataTable)dgvDevBOM.DataSource;
                dtbom.Rows.Clear();
                dgvDevBOM.DataSource = dtbom;
                DataTable dtremark = (DataTable)dgvDevRemark.DataSource;
                dtremark.Rows.Clear();
                dgvDevRemark.DataSource = dtremark;
            }
        }

        // 鞋型BOM
        private void btnBOM_Click(object sender, EventArgs e)
        {
            selectpart = 2;
            tcDevShoeModel.SelectedIndex = 0;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            btnOrder.Visible = false;
            btnRemark.Visible = false;
            dgvDevBOM.ReadOnly = false;
            if (tsbIsInsertOrModify == "Insert")
            {
                dgvDevBOM.AllowUserToAddRows = true;
                dgvDevBOM.AllowUserToDeleteRows = true;
                if (dgvDevBOM.Rows.Count > 0)
                {
                    dgvDevBOM.CurrentCell = dgvDevBOM.Rows[dgvDevBOM.Rows.Count - 1].Cells[2];
                }
            }
            else if (tsbIsInsertOrModify == "Modify")
            {
                dgvDevBOM.AllowUserToDeleteRows = true;
            }
        }

        // 鞋型備註
        private void btnRemark_Click(object sender, EventArgs e)
        {
            selectpart = 3;
            tcDevShoeModel.SelectedIndex = 1;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            btnOrder.Visible = false;
            btnBOM.Visible = false;
            dgvDevRemark.ReadOnly = false;
            if (tsbIsInsertOrModify == "Insert")
            {
                dgvDevRemark.AllowUserToAddRows = true;
                dgvDevRemark.AllowUserToDeleteRows = true;
                if (dgvDevRemark.Rows.Count > 0)
                {
                    dgvDevRemark.CurrentCell = dgvDevRemark.Rows[dgvDevRemark.Rows.Count - 1].Cells[1];
                }
            }
            else if (tsbIsInsertOrModify == "Modify")
            {
                dgvDevRemark.AllowUserToDeleteRows = true;
            }
        }

        #endregion

        #region 清除按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {
            ClearTextbox();
        }

        #endregion
        
        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteSampleOrder();
        }

        #endregion

        #region 編輯按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            btnOrder.Visible = true;
            btnBOM.Visible = true;
            btnRemark.Visible = true;
            tcSampleOrder.SelectedIndex = 1;
            tsbIsInsertOrModify = "Modify";
            tsbChoice(tsbIsInsertOrModify);
        }

        #endregion
        
        #region 拷貝按鈕事件

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Copy " + tbSampleOrderNo.Text + " This Order?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                // 紀錄舊樣品單號
                osampleorderno = tbSampleOrderNo.Text;
                GetClientNoFromKFXXZL(tbShoeModel.Text); // 組合新樣品單號並複製
                // 新樣品單附值
                tbSampleOrderNo.Text = orderSerialNum;
                if (isCopy)
                {
                    tbSampleOrderNo.Text = orderSerialNum;
                    QueryMainFormSampleOrder(tbSampleOrderNo.Text);
                    MessageBox.Show("Copy Complete!");
                }
                // 開啟編輯模式
                tsbModify.PerformClick();
                btnOrder.PerformClick();
            }
        }

        #endregion

        #region 臨時料號按鈕事件

        private void tsbMaterial_Click(object sender, EventArgs e)
        {
            TempMaterial tm = new TempMaterial();
            tm.ShowDialog();
        }

        #endregion

        #region 成本計算按鈕事件

        private void tsbCost_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Input Cost " + tbSampleOrderNo.Text + " This SampleOrder?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                for (int i = 0; i < dgvDevBOM.RowCount; i++)
                {
                    YPZLScost(tbSampleOrderNo.Text, dgvDevBOM.Rows[i].Cells[5].Value.ToString());
                    if (!isCost)
                    {
                        break;
                    }
                }
            }
            if (isCost)
            {
                MessageBox.Show("BOM Cost Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QueryDevShoeModelBOM(tbSampleOrderNo.Text); // 重新載入查詢
            }
        } 

        #endregion

        #region 關閉頁面按鈕事件

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 樣品單移動資料按鈕事件

        // 上一筆
        private void tsbPrior_Click(object sender, EventArgs e)
        {
            if (dgvSampleOrder.Rows.Count != 0)
            {
                if (tsbindex > 0)
                {
                    dgvSampleOrder.CurrentCell = dgvSampleOrder.Rows[tsbindex - 1].Cells[0];
                    dgvSampleOrder_CellClick(dgvSampleOrder, new DataGridViewCellEventArgs(0, tsbindex - 1));
                }
            }
        }

        // 下一筆
        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (dgvSampleOrder.Rows.Count != 0)
            {
                if (tsbindex < dgvSampleOrder.Rows.Count - 1)
                {
                    dgvSampleOrder.CurrentCell = dgvSampleOrder.Rows[tsbindex + 1].Cells[0];
                    dgvSampleOrder_CellClick(dgvSampleOrder, new DataGridViewCellEventArgs(0, tsbindex + 1));
                }
            }
        }

        // 第一筆
        private void tsbFirst_Click(object sender, EventArgs e)
        {
            if (dgvSampleOrder.Rows.Count != 0)
            {
                dgvSampleOrder.CurrentCell = dgvSampleOrder.Rows[0].Cells[0];
                dgvSampleOrder_CellClick(dgvSampleOrder, new DataGridViewCellEventArgs(0, 0));
            }
        }

        // 最後一筆
        private void tsbLast_Click(object sender, EventArgs e)
        {
            if (dgvSampleOrder.Rows.Count != 0)
            {
                dgvSampleOrder.CurrentCell = dgvSampleOrder.Rows[dgvSampleOrder.Rows.Count - 1].Cells[0];
                dgvSampleOrder_CellClick(dgvSampleOrder, new DataGridViewCellEventArgs(0, dgvSampleOrder.Rows.Count - 1));
            }
        }

        #endregion

        #region 速查DGV

        // 單點
        private void dgvSampleOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbindex = e.RowIndex;
            QueryMainFormSampleOrder(dgvSampleOrder.CurrentRow.Cells[0].Value.ToString());
        }

        // 雙點
        private void dgvSampleOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbindex = e.RowIndex;
            tcSampleOrder.SelectedIndex = 1;
            QueryMainFormSampleOrder(dgvSampleOrder.CurrentRow.Cells[0].Value.ToString());
        }

        #endregion
        
        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (selectpart == 1) // 樣品單
                {
                    if (tsbIsInsertOrModify == "Insert") // 新增
                    {
                        InsertSampleOrder();
                    }
                    else // 修改
                    {
                        ModifySampleOrder();
                    }
                }
                else if (selectpart == 2) // 鞋型BOM
                {
                    dgvDevBOM.CurrentCell = null; // *去除Focus,使空白欄位正常被清除*
                    dgvDevBOM.ReadOnly = true;
                    dgvDevBOM.AllowUserToAddRows = false;
                    dgvDevBOM.AllowUserToDeleteRows = false;
                    dgvBOMRowState(dsBOM.Tables["開發鞋型BOM表"]); //判斷欄位狀態(dsBOM)
                    QueryDevShoeModelBOM(tbSampleOrderNo.Text); // 重新載入查詢
                }
                else if (selectpart == 3) // 鞋型備註
                {
                    dgvDevRemark.CurrentCell = null; // *去除Focus,使空白欄位正常被清除*
                    dgvDevRemark.ReadOnly = true;
                    dgvDevRemark.AllowUserToAddRows = false;
                    dgvDevRemark.AllowUserToDeleteRows = false;
                    dgvRemarkRowState(dsRE.Tables["開發鞋型備註表"]); //判斷欄位狀態(dsRE)
                    QueryDevShoeModelRemark(tbSampleOrderNo.Text); // 重新載入查詢
                }
                tsbIsInsertOrModify = "Recover";
                tsbChoice(tsbIsInsertOrModify);
                btnOrder.Visible = false;
                btnBOM.Visible = false;
                btnRemark.Visible = false;
            }
        }

        #endregion
        
        #region 取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (selectpart == 1) // 樣品單
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    ClearTextbox();
                }
                else // 修改
                {
                    QueryMainFormSampleOrder(tbSampleOrderNo.Text);
                }
            }
            else if (selectpart == 2) // 鞋型BOM
            {
                dgvDevBOM.CurrentCell = null; // *去除Focus,使空白欄位正常被清除*
                dgvDevBOM.ReadOnly = true;
                dgvDevBOM.AllowUserToAddRows = false;
                dgvDevBOM.AllowUserToDeleteRows = false;
                QueryDevShoeModelBOM(tbSampleOrderNo.Text); // 重新載入查詢
            }
            else if (selectpart == 3) // 鞋型備註
            {
                dgvDevRemark.CurrentCell = null; // *去除Focus,使空白欄位正常被清除*
                dgvDevRemark.ReadOnly = true;
                dgvDevRemark.AllowUserToAddRows = false;
                dgvDevRemark.AllowUserToDeleteRows = false;
                QueryDevShoeModelRemark(tbSampleOrderNo.Text); // 重新載入查詢
            }
            tsbIsInsertOrModify = "Recover";
            tsbChoice(tsbIsInsertOrModify);
            btnOrder.Visible = false;
            btnBOM.Visible = false;
            btnRemark.Visible = false;
            tcDevShoeModel.Enabled = true;
        }

        #endregion

        #region 輸出Excel按鈕事件

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(dgvDevBOM);
        }

        #endregion

        #region 下拉選單改變事件(幣別)

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbRate.Text = "";
            if (cbCurrency.SelectedIndex != -1)
            {
                tbRate.Text = dscb.Tables[2].Rows[cbCurrency.SelectedIndex]["NTTO"].ToString();
            }
        }

        #endregion

        #region 客人確定按鈕改變事件

        private void chkClientComfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClientComfirm.Checked)
            {
                tbFinallyDate.Text = DateTime.Today.ToString("yyyyMMdd");
            }
            else
            {
                tbFinallyDate.Text = "";
            }
        }

        #endregion

        #region 鞋型TEXTBOX雙點擊事件

        private void tbShoeModel_DoubleClick(object sender, EventArgs e)
        {
            SOSM sosm = new SOSM();
            sosm.ShowDialog();
            //判斷是否
            if (sosm.isc)
            {
                tbShoeModel.Text = sosm.鞋型;
                tbColorNo.Text = sosm.色號;
                tbART.Text = sosm.ART;
                tbSeason.Text = sosm.季節;
                tbDevType.Text = sosm.開發類型;
                tbSizeCountry.Text = sosm.尺寸國別;
                tbColorDetail.Text = sosm.顏色說明;
                sampleNo = sosm.樣品編號;
                tbDevUID.Text = sosm.開發人員;
                // 樣品單當月最大值
                if (tbShoeModel.Text != "")
                {
                    if (tsbIsInsertOrModify == "Insert")
                    {
                        SampleOrderNo(sosm.客戶代號.PadRight(4, '0') + DateTime.Today.ToString("yyyyMM"));
                        tbSampleOrderNo.Text = orderSerialNum;
                    }
                }
            }
        }

        #endregion

        #region 開發鞋型事件

        #region BOM事件

        #region 鞋型BOM限制編輯欄位事件

        private void dgvDevBOM_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.ColumnIndex != 4 && e.ColumnIndex != 6 && e.ColumnIndex != 7 && e.ColumnIndex != 11)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 鞋型BOM DGV點擊事件

        // 單點
        private void dgvDevBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDevBOM.CurrentRow.Cells[2].Value.ToString() == "" && e.ColumnIndex != 2)
            {
                MessageBox.Show("Please Insert ShoePart First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDevBOM.CurrentCell = dgvDevBOM.CurrentRow.Cells[2];
            }
            tbPartName.Text = dgvDevBOM.CurrentRow.Cells[4].Value.ToString();
            tbMaterialNameCN.Text = dgvDevBOM.CurrentRow.Cells[6].Value.ToString();
            tbMaterialNameEN.Text = dgvDevBOM.CurrentRow.Cells[7].Value.ToString() + dgvDevBOM.CurrentRow.Cells[8].Value.ToString();
        }

        // 雙點
        private void dgvDevBOM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDevBOM.CurrentRow.Cells[2].Value.ToString() == "" && e.ColumnIndex != 2)
            {
                MessageBox.Show("Please Insert ShoePart First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDevBOM.CurrentCell = dgvDevBOM.CurrentRow.Cells[2];
            }
            else
            {
                if (tsbIsInsertOrModify == "Insert" || tsbIsInsertOrModify == "Modify")
                {
                    if (e.ColumnIndex == 2 && e.RowIndex != -1) // 部位編號
                    {
                        SOSMBOMBWBH sosmbwbh = new SOSMBOMBWBH();
                        sosmbwbh.ShowDialog();
                        if (sosmbwbh.isc)
                        {
                            // 附值
                            dgvDevBOM.CurrentRow.Cells[2].Value = sosmbwbh.部位代號;
                            dgvDevBOM.CurrentRow.Cells[3].Value = sosmbwbh.部位分類;
                            dgvDevBOM.CurrentRow.Cells[4].Value = sosmbwbh.中文;
                            if (tsbIsInsertOrModify == "Insert")
                            {
                                dgvDevBOM.AllowUserToAddRows = false;
                                dgvDevBOM.AllowUserToAddRows = true;
                            }
                            dgvDevBOM.CurrentCell = dgvDevBOM.Rows[e.RowIndex].Cells[2];
                        }
                    }
                    else if (e.ColumnIndex == 5 && e.RowIndex != -1) // 材料編號
                    {
                        SOSMBOMCLBH sosmclbh = new SOSMBOMCLBH();
                        sosmclbh.材料編號 = dgvDevBOM.CurrentRow.Cells[5].Value.ToString();
                        sosmclbh.廠商編號 = dgvDevBOM.CurrentRow.Cells[9].Value.ToString();
                        sosmclbh.是否臨時料號 = dgvDevBOM.CurrentRow.Cells[8].Value.ToString();
                        sosmclbh.ShowDialog();
                        if (sosmclbh.isc)
                        {
                            dgvDevBOM.CurrentRow.Cells[6].Value = "";
                            dgvDevBOM.CurrentRow.Cells[7].Value = "";
                            dgvDevBOM.CurrentRow.Cells[8].Value = "";
                            dgvDevBOM.CurrentRow.Cells[9].Value = "";
                            dgvDevBOM.CurrentRow.Cells[10].Value = "";
                            // 附值
                            if (sosmclbh.selectmnum == "Formal") // 正式料號
                            {
                                dgvDevBOM.CurrentRow.Cells[6].Value = sosmclbh.中文;
                                dgvDevBOM.CurrentRow.Cells[7].Value = sosmclbh.英文;
                            }
                            else // 臨時料號
                            {
                                dgvDevBOM.CurrentRow.Cells[6].Value = sosmclbh.中文;
                                dgvDevBOM.CurrentRow.Cells[8].Value = sosmclbh.英文;
                            }
                            dgvDevBOM.CurrentRow.Cells[5].Value = sosmclbh.材料編號;
                            dgvDevBOM.CurrentRow.Cells[9].Value = sosmclbh.廠商編號;
                            dgvDevBOM.CurrentRow.Cells[10].Value = sosmclbh.廠商縮寫;
                        }
                    }
                }
            }
        }

        #endregion

        #region BOM新增與修改事件

        private void dgvDevBOM_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    dgvDevBOM.CurrentRow.Cells[0].Value = tbSampleOrderNo.Text;
                    if (dgvDevBOM.Rows.Count > 1) // 第二筆以上
                    {
                        if (dgvDevBOM.CurrentRow.Cells[1].Value.ToString() == "")
                        {
                            if (dgvDevBOM.CurrentCell == dgvDevBOM.Rows[1].Cells[2]) // 新增第二格
                            {
                                dgvDevBOM.CurrentRow.Cells[1].Value = "010";
                            }
                            else
                            {
                                dgvDevBOM.CurrentRow.Cells[1].Value = (Convert.ToInt32(dgvDevBOM.Rows[dgvDevBOM.Rows.Count - 2].Cells[1].Value) + 5).ToString().PadLeft(3, '0');
                            }
                        }
                    }
                    else if (dgvDevBOM.Rows.Count == 1) // 第一筆
                    {
                        dgvDevBOM.CurrentRow.Cells[1].Value = "005";
                    }
                }
            }
        }

        #endregion

        #endregion

        #region 備註事件

        #region 鞋型備註限制編輯欄位事件

        private void dgvDevRemark_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 備註新增與修改事件

        private void dgvDevRemark_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 4)
            {
                if (tsbIsInsertOrModify == "Insert")
                {
                    dgvDevRemark.CurrentRow.Cells[0].Value = tbSampleOrderNo.Text;
                    dgvDevRemark.CurrentRow.Cells[3].Value = DateTime.Today.ToString("yyyyMMdd");
                    if (dgvDevRemark.Rows.Count > 2) // 第二筆以上
                    {
                        if (dgvDevRemark.CurrentRow.Cells[1].Value.ToString() == "")
                        {
                            dgvDevRemark.CurrentRow.Cells[1].Value = (Convert.ToInt32(dgvDevRemark.Rows[dgvDevRemark.Rows.Count - 3].Cells[1].Value) + 1).ToString().PadLeft(3, '0');
                        }
                    }
                    else if (dgvDevRemark.Rows.Count == 2) // 第一筆
                    {
                        dgvDevRemark.CurrentRow.Cells[1].Value = "001";
                    }
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region 方法

        #region 多語言

        #region 切換 Label

        private void ChangeLabel()
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

        #endregion

        #region 切換 TB

        private void ChangePanel()
        {
            int i;
            i = int.Parse(userLanguage) + 1;

            dsL = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'P%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsL, "棧板表");
            this.dgvWord.DataSource = this.dsL.Tables[0];

            Wtabcontrol();
        }

        #endregion

        #region 切換 dgv

        private void ChangeDataView()
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

        #endregion

        #region 定位DGV

        private void LoadDgv()
        {
            try
            {
                int x;
                x = dgvWord.RowCount;
                for (int i = 0; i < x - 5; i++)
                {
                    dgvDevBOM.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
                }
                for (int i = 0; i < x - 17; i++)
                {
                    dgvDevRemark.Columns[i].HeaderText = dgvWord.Rows[i + 17].Cells[3].Value.ToString();
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region tabcontrol定位

        private void Wtabcontrol()
        {
            try
            {
                P0001.Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                P0002.Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                P0003.Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                P0004.Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                P0005.Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                P0006.Text = dgvWord.Rows[5].Cells[3].Value.ToString();
            }
            catch (Exception)
            {
            }
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
                L0009.Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                L0010.Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                L0011.Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                L0012.Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                L0013.Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                L0014.Text = dgvWord.Rows[13].Cells[3].Value.ToString();
                L0015.Text = dgvWord.Rows[14].Cells[3].Value.ToString();
                L0016.Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                L0017.Text = dgvWord.Rows[16].Cells[3].Value.ToString();
                L0018.Text = dgvWord.Rows[17].Cells[3].Value.ToString();
                L0019.Text = dgvWord.Rows[18].Cells[3].Value.ToString();
                L0020.Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                L0021.Text = dgvWord.Rows[20].Cells[3].Value.ToString();
                L0022.Text = dgvWord.Rows[21].Cells[3].Value.ToString();
                L0023.Text = dgvWord.Rows[22].Cells[3].Value.ToString();
                L0024.Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                L0025.Text = dgvWord.Rows[24].Cells[3].Value.ToString();
                L0026.Text = dgvWord.Rows[25].Cells[3].Value.ToString();
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region TSB判定

        private void tsbChoice(string insertormodify)
        {
            if (insertormodify == "Insert") // 新增模式
            {
                tsbQuery.Enabled = false;
                tsbClear.Enabled = true;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbCopy.Enabled = false;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Modify") // 修改模式
            {
                tsbQuery.Enabled = false;
                tsbInsert.Enabled = false;
                tsbModify.Enabled = false;
                tsbDelete.Enabled = false;
                tsbCopy.Enabled = false;
                tsbCancel.Enabled = true;
            }
            else if (insertormodify == "Recover")
            {
                dgvShoeBOMDelete.DataSource = null; // 清除刪除表資料
                dgvRemarkDelete.DataSource = null; // 清除刪除表資料
                EnableUIColumns(false);
                tsbQuery.Enabled = true;
                tsbClear.Enabled = false;
                tsbInsert.Enabled = true;
                if (tbSampleOrderNo.Text != "")
                {
                    tsbDelete.Enabled = dgvDevBOM.Rows.Count == 0 && dgvDevRemark.Rows.Count == 0 ? true : false;
                    tsbModify.Enabled = true;
                    tsbCopy.Enabled = true;
                }
                else
                {
                    tsbDelete.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbCopy.Enabled = false;
                }
                tsbSave.Enabled = false;
                tsbCancel.Enabled = false;
            }
        }

        #endregion

        #region UI欄位狀態開關

        private void EnableUIColumns(bool isEnable)
        {
            if (isEnable) // 開
            {
                tbShoeModel.Enabled = true;
                cbStage.Enabled = true;
                tbDevSize.Enabled = true;
                tbOutsoleSize.Enabled = true;
                tbFomSize.Enabled = true;
                tbRate.Enabled = true;
                cbCurrency.Enabled = true;
                chkClientComfirm.Enabled = true;
                tbMaterialDate.Enabled = true;
                tbQTY.Enabled = true;
                cbFactory.Enabled = true;
                tbFinallyDate.Enabled = true;
                tbLeadTime.Enabled = true;
                pcPic.Enabled = true;
            }
            else // 關
            {
                tbShoeModel.Enabled = false;
                cbStage.Enabled = false;
                tbDevSize.Enabled = false;
                tbOutsoleSize.Enabled = false;
                tbFomSize.Enabled = false;
                tbRate.Enabled = false;
                cbCurrency.Enabled = false;
                chkClientComfirm.Enabled = false;
                tbMaterialDate.Enabled = false;
                tbQTY.Enabled = false;
                cbFactory.Enabled = false;
                tbFinallyDate.Enabled = false;
                tbLeadTime.Enabled = false;
                pcPic.Enabled = false;
            }
        }

        #endregion

        #region 檢查輸入

        private bool CheckInput()
        {
            bool ok = true;
            if (tbShoeModel.Text.Trim().Length == 0 && tbSampleOrderNo.Text.Trim().Length == 0 && tbDevSize.Text.Trim().Length == 0)
            {
                MessageBox.Show("ShoeModel & DevSize Can't Be NULL!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        #endregion

        #region Combobox Function

        /// <summary>
        /// 載入樣品單下拉選單(廠區,開發階段,幣別)
        /// </summary>
        private void GetCombobox()
        {
            dscb = new DataSet();
            DBconnect dbconn = new DBconnect();
            try
            {
                // 讀取廠區表
                string sql1 = "select cqdh,gsywqm from cqzl";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn.connection);
                adapter1.Fill(dscb, "廠區表");
                this.cbFactory.DataSource = dscb.Tables[0];
                this.cbFactory.ValueMember = "cqdh";
                this.cbFactory.DisplayMember = "gsywqm";
                this.cbFactory.SelectedIndex = -1;

                // 讀取開發階段表
                string sql2 = "select DS_Number from Dev_stage";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbconn.connection);
                adapter2.Fill(dscb, "階段表");
                this.cbStage.DataSource = dscb.Tables[1];
                this.cbStage.ValueMember = "DS_Number";
                this.cbStage.DisplayMember = "DS_Number";
                this.cbStage.SelectedIndex = -1;

                // 讀取幣別表
                string sql3 = "select ywsm,CURRENCY_ID,NTTO from CURRENCY";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbconn.connection);
                adapter3.Fill(dscb, "幣別表");
                this.cbCurrency.DataSource = dscb.Tables[2];
                this.cbCurrency.ValueMember = "CURRENCY_ID";
                this.cbCurrency.DisplayMember = "ywsm";
                this.cbCurrency.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Combobox Error!");
            }
        }

        #endregion

        #region 清除TextBox方法

        private void ClearTextbox()
        {
            tbSampleOrderNo.Text = "";
            tbShoeModel.Text = "";
            tbColorNo.Text = "";
            cbStage.SelectedIndex = -1;
            tbART.Text = "";
            tbRate.Text = "";
            cbCurrency.SelectedIndex = -1;
            chkClientComfirm.Checked = false;
            tbDevSize.Text = "";
            tbOutsoleSize.Text = "";
            tbFomSize.Text = "";
            tbOrderListDate.Text = "";
            tbMaterialDate.Text = "";
            tbQTY.Text = "";
            cbFactory.SelectedIndex = -1;
            tbFinallyDate.Text = "";
            tbLeadTime.Text = "";
            tbSeason.Text = "";
            tbDevType.Text = "";
            tbUserID.Text = "";
            tbSizeCountry.Text = "";
            tbColorDetail.Text = "";
            tbPartName.Text = "";
            tbMaterialNameCN.Text = "";
            tbMaterialNameEN.Text = "";
            pcPic.Image = null;
        }

        #endregion

        #region 複製樣品單方法

        // 由鞋型抓取客戶編號並重組樣品單號
        private void GetClientNoFromKFXXZL(string xiexing)
        {
            dsOrder = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string khdh;
                int biggestorder;
                string sql1 = string.Format("select KHDH from kfxxzl where XieXing='{0}'", xiexing);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsOrder, "客戶編號");
                khdh = dsOrder.Tables[0].Rows[0][0].ToString().PadRight(4, '0');
                string sql2 = string.Format("select top 1 SUBSTRING(YPDH,11,5) from YPZL where YPDH like '{0}'+substring(convert(varchar,getdate(),112),1,6)+'%' order by YPDH desc", khdh);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(dsOrder, "樣品單流水號最大值");
                biggestorder = Convert.ToInt32(dsOrder.Tables[1].Rows[0][0].ToString());
                orderSerialNum = khdh + DateTime.Today.ToString("yyyyMM") + (biggestorder + 1).ToString().PadLeft(5, '0');
            }
            catch (Exception)
            {
                orderSerialNum = dsOrder.Tables[0].Rows[0][0].ToString().PadRight(4, '0') + DateTime.Today.ToString("yyyyMM") + "00001";
            }
            finally
            {
                CopySampleOrderAll(); // 複製Function
            }
        }

        // 複製所有單據方法
        private void CopySampleOrderAll()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 單頭複製
                string sqlcopy1 = string.Format("insert into YPZL (YPDH,XieXing,SheHao,ARTICLE,KFJD,YPCC,Rate,Currency,KFRQ,SDRQ,JHRQ,Quantity,PFC,CFM,FINDATE,GSDH,KFLX,YPCCO,YPCCL,YPOBH,PDYPZLBH,USERID,USERDATE) " +
                    "select 'COPY',XieXing,SheHao,ARTICLE,KFJD,YPCC,Rate,Currency,CONVERT(varchar(8),getdate(),112),SDRQ,JHRQ,Quantity,PFC,CFM,FINDATE,GSDH,KFLX,YPCCO,YPCCL,YPOBH,PDYPZLBH,'{0}',convert(varchar,getdate(),111) from YPZL where YPDH='{1}'"
                    , USERID, osampleorderno);
                SqlCommand cmdc1 = new SqlCommand(sqlcopy1, dbconn.connection);
                dbconn.OpenConnection();
                int rc1 = cmdc1.ExecuteNonQuery();
                if (rc1 == 1)
                {
                    // 單頭修改
                    string sqlupdate1 = string.Format("update YPZL set YPDH='{0}' where YPDH='COPY'", orderSerialNum);
                    SqlCommand cmdu1 = new SqlCommand(sqlupdate1, dbconn.connection);
                    int ru1 = cmdu1.ExecuteNonQuery();
                    if (ru1 == 1)
                    {
                        // BOM複製
                        string sqlcopy2 = string.Format("insert into YPZLS (YPDH,XH,BWBH,BWLB,CLBH,CSBH,LOSS,CLSL,CLDJ,Currency,Rate,Remark,JGZWSM,JGYWSM) " +
                            "select 'COPY',XH,BWBH,BWLB,CLBH,CSBH,LOSS,CLSL,CLDJ,Currency,Rate,Remark,JGZWSM,JGYWSM from YPZLS where YPDH='{0}'"
                            , osampleorderno);
                        SqlCommand cmdc2 = new SqlCommand(sqlcopy2, dbconn.connection);
                        int rc2 = cmdc2.ExecuteNonQuery();
                        if (rc2 > 0)
                        {
                            //BOM修改
                            string sqlupdate2 = string.Format("update YPZLS set YPDH='{0}' where YPDH='COPY'", orderSerialNum);
                            SqlCommand cmdu2 = new SqlCommand(sqlupdate2, dbconn.connection);
                            cmdu2.ExecuteNonQuery();
                            isCopy = true;
                        }
                        // 備註複製
                        string sqlcopy3 = string.Format("insert into ypzls2 (ypdh,LineNum,Remark,NoteRQ,UserSign) " +
                            "select 'COPY',LineNum,Remark,NoteRQ,UserSign from ypzls2 where ypdh='{0}'"
                            , osampleorderno);
                        SqlCommand cmdc3 = new SqlCommand(sqlcopy3, dbconn.connection);
                        int rc3 = cmdc3.ExecuteNonQuery();
                        if (rc3 > 0)
                        {
                            //備註修改
                            string sqlupdate3 = string.Format("update ypzls2 set ypdh='{0}' where ypdh='COPY'", orderSerialNum);
                            SqlCommand cmdu3 = new SqlCommand(sqlupdate3, dbconn.connection);
                            cmdu3.ExecuteNonQuery();
                            isCopy = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                isCopy = false;
                MessageBox.Show("Copy Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 樣品單

        #region 樣品單號最大值(當月)

        private void SampleOrderNo(string thismonth)
        {
            dsOrder = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                int bigestorder;
                string sql = string.Format("select top 1 SUBSTRING(YPDH,11,5) from YPZL where YPDH like '{0}%' order by YPDH desc", thismonth);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsOrder, "樣品單流水號最大值");
                bigestorder = Convert.ToInt32(dsOrder.Tables[0].Rows[0][0].ToString());
                orderSerialNum = thismonth + (bigestorder + 1).ToString().PadLeft(5, '0');
            }
            catch (Exception)
            {
                orderSerialNum = thismonth + "00001";
            }
        }

        #endregion
        
        #region 速查開發樣品單方法

        private void QueryDevSampleOrder(string orderno, string shoemodel, string colorno, string art, string stage, string season)
        {
            tsbModify.Enabled = false;
            tsbDelete.Enabled = false;
            tsbCopy.Enabled = false;
            dsQQuery = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select y.YPDH,y.XieXing,y.SheHao,y.ARTICLE,y.KFJD,y.YPCC 開發尺寸,y.Quantity,k.JiJie " +
                    "from YPZL y " +
                    "left join kfxxzl k on k.XieXing=y.XieXing and k.SheHao=y.SheHao " +
                    "where YPDH like'%{0}%' and (y.XieXing like '%{1}%' or y.XieXing is null) and (y.SheHao like '%{2}%' or y.SheHao is null) " +
                    "and KFJD {3}' and (y.ARTICLE like '%{4}%' or y.ARTICLE is null) and (k.JiJie like '%{5}%' or k.JiJie is null)"
                    , orderno, shoemodel, colorno, stage, art, season);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsQQuery, "開發樣品單");
                this.dgvSampleOrder.DataSource = this.dsQQuery.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion

        #region 樣品單主頁面查詢附值

        private void QueryMainFormSampleOrder(string ypdh)
        {
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select y.YPDH,y.XieXing,y.SheHao,y.ARTICLE,y.KFJD,y.Rate,y.Currency,y.CFM,y.YPCC,y.YPCCO,y.YPCCL,y.KFRQ,y.SDRQ,y.Quantity,y.PFC,y.FINDATE,y.JHRQ,k.JiJie,dc.DC_Number,y.USERID,k.YSSM,k.CCGB,y.YPOBH " +
                    "from YPZL y " +
                    "left join kfxxzl k on k.XieXing=y.XieXing and k.SheHao=y.SheHao " +
                    "left join Dev_Class dc on dc.DC_ID=k.DevType " +
                    "where y.YPDH='{0}'", ypdh);
                SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                dbConn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (tcSampleOrder.SelectedIndex == 1)
                    {
                        tsbModify.Enabled = true;
                        tsbCopy.Enabled = true;
                    }
                    else
                    {
                        tsbModify.Enabled = false;
                        tsbCopy.Enabled = false;
                    }
                    tbSampleOrderNo.Text = reader["YPDH"].ToString();
                    tbShoeModel.Text = reader["XieXing"].ToString();
                    tbColorNo.Text = reader["SheHao"].ToString();
                    tbART.Text = reader["ARTICLE"].ToString();
                    cbStage.SelectedValue = reader["KFJD"].ToString();
                    tbRate.Text = reader["Rate"].ToString();
                    cbCurrency.SelectedValue = reader["Currency"].ToString();
                    if (reader["CFM"].ToString() == "N")
                    {
                        chkClientComfirm.Checked = false;
                    }
                    else
                    {
                        chkClientComfirm.Checked = true;
                        tsbModify.Enabled = false;
                    }
                    tbDevSize.Text = reader["YPCC"].ToString();
                    tbOutsoleSize.Text = reader["YPCCO"].ToString();
                    tbFomSize.Text = reader["YPCCL"].ToString();
                    tbOrderListDate.Text = reader["KFRQ"].ToString();
                    tbMaterialDate.Text = reader["SDRQ"].ToString();
                    tbQTY.Text = reader["Quantity"].ToString();
                    cbFactory.SelectedValue = reader["PFC"].ToString();
                    tbFinallyDate.Text = reader["FINDATE"].ToString();
                    tbLeadTime.Text = reader["JHRQ"].ToString();
                    tbSeason.Text = reader["JiJie"].ToString();
                    tbDevType.Text = reader["DC_Number"].ToString();
                    tbUserID.Text = reader["USERID"].ToString();
                    tbColorDetail.Text = reader["YSSM"].ToString();
                    tbSizeCountry.Text = reader["CCGB"].ToString();
                    sampleNo = reader["YPOBH"].ToString();
                    QueryDevShoeModelBOM(tbSampleOrderNo.Text); // 鞋型BOM
                    QueryDevShoeModelRemark(tbSampleOrderNo.Text); // 鞋型備註
                    if (dsBOM.Tables[0].Rows.Count == 0 && dsRE.Tables[0].Rows.Count == 0)
                    {
                        tsbDelete.Enabled = true;
                    }
                    else
                    {
                        tsbDelete.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Main Form Get SampleOrder Error!");
            }
        }

        #endregion

        #region 新增樣品單方法

        private void InsertSampleOrder()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 新增資料
                // 0樣品單號 1鞋型 2色號 3ART 4開發階段 5開發尺寸 6匯率 7幣別
                // 8開單日期 9材料完成日 10交期 11雙數 12生產廠區 13確認(chk)
                // 14實際完成日 ,公司代號(null) 15開發類型 16大底尺寸 17楦頭尺寸 18樣品編號
                // 19使用者 20異動日期
                string sql = string.Format("insert into YPZL (YPDH,XieXing,SheHao,ARTICLE,KFJD,YPCC,Rate,Currency,KFRQ,SDRQ,JHRQ,Quantity,PFC,CFM,FINDATE,GSDH,KFLX,YPCCO,YPCCL,YPOBH,USERID,USERDATE) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}',{11},'{12}','{13}','{14}',null,'{15}','{16}','{17}','{18}','{19}','{20}')"
                    , tbSampleOrderNo.Text, tbShoeModel.Text, tbColorNo.Text, tbART.Text, cbStage.Text, tbDevSize.Text, tbRate.Text == "" ? "0" : tbRate.Text, cbCurrency.SelectedIndex == -1 ? "NULL" : "'" + cbCurrency.SelectedValue + "'"
                    , DateTime.Today.ToString("yyyyMMdd"), tbMaterialDate.Text, tbLeadTime.Text, tbQTY.Text == "" ? "0" : tbQTY.Text, cbFactory.SelectedValue, chkClientComfirm.Checked ? "Y" : "N"
                    , tbFinallyDate.Text, tbDevType.Text, tbOutsoleSize.Text, tbFomSize.Text, sampleNo
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd"));
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Insert Success!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 編輯樣品單方法

        private void ModifySampleOrder()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 編輯資料
                // 0鞋型 1色號 2ART 3開發階段 4開發尺寸 5匯率 6幣別
                // 7開單日期 8材料完成日 9交期 10雙數 11生產廠區 12確認(chk)
                // 13實際完成日 14開發類型 15大底尺寸 16楦頭尺寸 17樣品編號
                // 18使用者 19異動日期 20樣品單號
                string sql = string.Format("update YPZL " +
                    "set XieXing='{0}',SheHao='{1}',ARTICLE='{2}',KFJD='{3}',YPCC='{4}',Rate={5},Currency={6},SDRQ='{7}',JHRQ='{8}',Quantity={9},PFC='{10}',CFM='{11}',FINDATE='{12}',KFLX='{13}',YPCCO='{14}',YPCCL='{15}',YPOBH='{16}',USERID='{17}',USERDATE='{18}' " +
                    "where YPDH='{19}'"
                    , tbShoeModel.Text, tbColorNo.Text, tbART.Text, cbStage.Text, tbDevSize.Text, tbRate.Text == "" ? "0" : tbRate.Text, cbCurrency.SelectedIndex == -1 ? "NULL" : "'" + cbCurrency.SelectedValue + "'"
                    , tbMaterialDate.Text, tbLeadTime.Text, tbQTY.Text == "" ? "0" : tbQTY.Text, cbFactory.SelectedValue, chkClientComfirm.Checked ? "Y" : "N"
                    , tbFinallyDate.Text, tbDevType.Text, tbOutsoleSize.Text, tbFomSize.Text, sampleNo
                    , USERID, DateTime.Today.ToString("yyyy-MM-dd")
                    , tbSampleOrderNo.Text);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Modify Success!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 刪除樣品單方法

        private void DeleteSampleOrder()
        {
            DialogResult dr = MessageBox.Show("Delete " + tbSampleOrderNo.Text + " This SampleOrder?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                DBconnect dbConn = new DBconnect();
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("delete from YPZL where YPDH ='{0}'", tbSampleOrderNo.Text);
                    SqlCommand cmd = new SqlCommand(sb.ToString(), dbConn.connection);
                    dbConn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Delete Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextbox();
                        tsbChoice("Recover");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Delete Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConn.CloseConnection();
                }
            }
        }

        #endregion

        #endregion
        
        #region 鞋型
        
        #region BOM

        #region 查詢鞋型BOM方法

        private void QueryDevShoeModelBOM(string orderno)
        {
            dsBOM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // BOM
                string sql = string.Format("select y.YPDH,y.XH,y.BWBH,b.bwlb,b.zwsm,y.CLBH," +
                    "case when rtrim(isnull(c.zwpm,'')) <> '' then rtrim(c.zwpm) else rtrim(ct.zwpm) end zwpm,c.ywpm,ct.ywpm ywpm2" +
                    ",y.CSBH,z.zsjc,y.LOSS,y.CLSL,z.bb,cu.NTTO,y.CLDJ,y.Remark " +
                    "from YPZLS y " +
                    "left join bwzl b on b.bwdh=y.BWBH " +
                    "left join clzl c on c.cldh=y.CLBH " +
                    "left join clzltemp ct on ct.tempddbh=y.CLBH " +
                    "left join zszl z on z.zsdh=y.CSBH " +
                    "left join CURRENCY cu on cu.CURRENCY_ID=z.bb " +
                    "where y.YPDH='{0}' order by y.XH"
                    , orderno);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsBOM, "開發鞋型BOM表");
                this.dgvDevBOM.DataSource = this.dsBOM.Tables[0];
                this.dgvDevBOM.Columns[2].DefaultCellStyle.BackColor = Color.LightGray;
                this.dgvDevBOM.Columns[5].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                // BOM總數(該樣品單)
                string sqlqty = string.Format("select count(*) from YPZLS where YPDH='{0}'"
                    , orderno);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlqty, dbConn.connection);
                adapter2.Fill(dsBOM, "BOM總數");
                lbBOMQTY.Text = dsBOM.Tables[1].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ShoeModel Query Data Error!");
            }
        }

        #endregion
        
        #region 判斷鞋型BOM DataSet列狀態

        /// <summary>
        /// 判斷鞋型BOM dataset列狀態
        /// </summary>
        /// <param name="dtBOM">目標dataset</param>
        private void dgvBOMRowState(DataTable dtBOM)
        {
            if (tsbIsInsertOrModify == "Insert") // 新增模式
            {
                try
                {
                    int dcount = 0;
                    for (int i = 0; i < dtBOM.Rows.Count; i++)
                    {
                        if (dtBOM.Rows[i].RowState.ToString() == "Added")
                        {
                            if (dgvDevBOM.Rows[i].Cells[0].Value.ToString() != "")
                            {
                                InsertDevBOM(dgvDevBOM.Rows[i].Cells[0].Value.ToString(), dgvDevBOM.Rows[i].Cells[1].Value.ToString(), dgvDevBOM.Rows[i].Cells[2].Value.ToString(), dgvDevBOM.Rows[i].Cells[3].Value.ToString(), dgvDevBOM.Rows[i].Cells[5].Value.ToString(), dgvDevBOM.Rows[i].Cells[9].Value.ToString(), dgvDevBOM.Rows[i].Cells[11].Value.ToString(), dgvDevBOM.Rows[i].Cells[12].Value.ToString(), dgvDevBOM.Rows[i].Cells[16].Value.ToString());
                            }
                        }
                        else if (dtBOM.Rows[i].RowState.ToString() == "Modified")
                        {
                            ModifyDevBOM(dgvDevBOM.Rows[i].Cells[0].Value.ToString(), dgvDevBOM.Rows[i].Cells[1].Value.ToString(), dgvDevBOM.Rows[i].Cells[2].Value.ToString(), dgvDevBOM.Rows[i].Cells[3].Value.ToString(), dgvDevBOM.Rows[i].Cells[5].Value.ToString(), dgvDevBOM.Rows[i].Cells[9].Value.ToString(), dgvDevBOM.Rows[i].Cells[11].Value.ToString(), dgvDevBOM.Rows[i].Cells[12].Value.ToString(), dgvDevBOM.Rows[i].Cells[16].Value.ToString());
                        }
                        else if (dtBOM.Rows[i].RowState.ToString() == "Deleted")
                        {
                            if (dcount == 0)
                            {
                                for (int j = 0; j < dgvShoeBOMDelete.Rows.Count; j++)
                                {
                                    DeleteDevShoeBOM(dgvShoeBOMDelete.Rows[j].Cells[0].Value.ToString(), dgvShoeBOMDelete.Rows[j].Cells[1].Value.ToString());
                                }
                                dcount++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Insert Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tsbIsInsertOrModify == "Modify") // 修改模式
            {
                try
                {
                    int dcount = 0;
                    for (int i = 0; i < dtBOM.Rows.Count; i++)
                    {
                        if (dtBOM.Rows[i].RowState.ToString() == "Modified")
                        {
                            ModifyDevBOM(dgvDevBOM.Rows[i].Cells[0].Value.ToString(), dgvDevBOM.Rows[i].Cells[1].Value.ToString(), dgvDevBOM.Rows[i].Cells[2].Value.ToString(), dgvDevBOM.Rows[i].Cells[3].Value.ToString(), dgvDevBOM.Rows[i].Cells[5].Value.ToString(), dgvDevBOM.Rows[i].Cells[9].Value.ToString(), dgvDevBOM.Rows[i].Cells[11].Value.ToString(), dgvDevBOM.Rows[i].Cells[12].Value.ToString(), dgvDevBOM.Rows[i].Cells[16].Value.ToString());
                        }
                        else if (dtBOM.Rows[i].RowState.ToString() == "Deleted")
                        {
                            if (dcount == 0)
                            {
                                for (int j = 0; j < dgvShoeBOMDelete.Rows.Count; j++)
                                {
                                    DeleteDevShoeBOM(dgvShoeBOMDelete.Rows[j].Cells[0].Value.ToString(), dgvShoeBOMDelete.Rows[j].Cells[1].Value.ToString());
                                }
                                dcount++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Modify Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        
        #region 新增鞋型BOM方法

        private void InsertDevBOM(string ypdh, string xh, string bwbh, string bwlb, string cldh, string csdh, string loss, string clsl, string remark)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into YPZLS (YPDH,XH,BWBH,BWLB,CLBH,CSBH,LOSS,CLSL,Remark) " +
                    "values ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8})"
                    , ypdh, xh, bwbh, bwlb, cldh == "" ? "null" : "'" + cldh + "'", csdh == "" ? "null" : "'" + csdh + "'"
                    , loss == "" ? "0" : loss, clsl == "" ? "0" : clsl, remark == "" ? "null" : "'" + remark + "'");
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert BOM Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 更新鞋型BOM方法

        private void ModifyDevBOM(string ypdh, string xh, string bwbh, string bwlb, string cldh, string csdh, string loss, string clsl, string remark)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update YPZLS set BWBH='{0}',BWLB='{1}',CLBH={2},CSBH={3},LOSS={4},CLSL={5},Remark={6} " +
                    "where YPDH='{7}' and XH='{8}'"
                    , bwbh, bwlb, cldh == "" ? "null" : "'" + cldh + "'", csdh == "" ? "null" : "'" + csdh + "'"
                    , loss == "" ? "0" : loss, clsl == "" ? "0" : clsl, remark == "" ? "null" : "'" + remark + "'"
                    , ypdh, xh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Modify BOM Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 成本計算方法

        private void YPZLScost(string ypdh, string clbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update YPZLS " +
                    "set CLDJ=(select top 1 case when cgs.USPrice is null then convert(varchar,cgs.VNPrice) else convert(varchar,cgs.USPrice) end price " +
                    "from CGBJS cgs " +
                    "left join CGBJ cg on cg.BJNO=cgs.BJNO " +
                    "where cgs.CLBH='{0}' " +
                    "order by cg.CFMDate desc) " +
                    "where YPDH = '{1}' and CLBH='{2}'"
                    , clbh, ypdh, clbh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    isCost = true;
                }
            }
            catch (Exception)
            {
                isCost = false;
                MessageBox.Show("BOM Cost Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 把要刪除的資料放入DGV容器

        private void dgvDevBOM_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvShoeBOMDelete.DataSource == null)
            {
                dtbd = new DataTable("鞋型BOM刪除表");
                // 開表
                dtbd.Columns.Add("rypdh", typeof(string));
                dtbd.Columns.Add("rbwbh", typeof(string));
            }
            DataRow dr = dtbd.NewRow();
            dr[0] = dgvDevBOM.CurrentRow.Cells[0].Value.ToString();
            dr[1] = dgvDevBOM.CurrentRow.Cells[2].Value.ToString();
            dtbd.Rows.Add(dr);
            dgvShoeBOMDelete.DataSource = dtbd;
        }

        #endregion

        #region 刪除鞋型BOM方法

        private void DeleteDevShoeBOM(string ypdh, string bwbh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("delete from YPZLS where YPDH='{0}' and BWBH='{1}'", ypdh, bwbh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Delete BOM Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #endregion

        #region 備註

        #region 查詢鞋型備註方法

        private void QueryDevShoeModelRemark(string orderno)
        {
            dsRE = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 備註
                string sql = string.Format("select * from ypzls2 where ypdh='{0}'"
                    , orderno);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsRE, "開發鞋型備註表");
                this.dgvDevRemark.DataSource = this.dsRE.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("ShoeModel Remark Query Data Error!");
            }
        }

        #endregion

        #region 判斷鞋型備註DataSet列狀態

        /// <summary>
        /// 判斷鞋型備註 dataset列狀態
        /// </summary>
        /// <param name="dtr">目標dataset</param>
        private void dgvRemarkRowState(DataTable dtr)
        {
            if (tsbIsInsertOrModify == "Insert") // 新增模式
            {
                try
                {
                    int dcount = 0;
                    for (int i = 0; i < dtr.Rows.Count; i++)
                    {
                        if (dtr.Rows[i].RowState.ToString() == "Added")
                        {
                            InsertDevRemark(dgvDevRemark.Rows[i].Cells[0].Value.ToString(), dgvDevRemark.Rows[i].Cells[1].Value.ToString(), dgvDevRemark.Rows[i].Cells[2].Value.ToString(), dgvDevRemark.Rows[i].Cells[3].Value.ToString(), dgvDevRemark.Rows[i].Cells[4].Value.ToString());
                        }
                        else if (dtr.Rows[i].RowState.ToString() == "Modified")
                        {
                            ModifyDevRemark(dgvDevRemark.Rows[i].Cells[0].Value.ToString(), dgvDevRemark.Rows[i].Cells[1].Value.ToString(), dgvDevRemark.Rows[i].Cells[2].Value.ToString(), dgvDevRemark.Rows[i].Cells[4].Value.ToString());
                        }
                        else if (dtr.Rows[i].RowState.ToString() == "Deleted")
                        {
                            if (dcount == 0)
                            {
                                for (int j = 0; j < dgvRemarkDelete.Rows.Count; j++)
                                {
                                    DeleteDevRemark(dgvRemarkDelete.Rows[j].Cells[0].Value.ToString(), dgvRemarkDelete.Rows[j].Cells[1].Value.ToString());
                                }
                                dcount++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Insert Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tsbIsInsertOrModify == "Modify") // 修改模式
            {
                try
                {
                    int dcount = 0;
                    for (int i = 0; i < dtr.Rows.Count; i++)
                    {
                        if (dtr.Rows[i].RowState.ToString() == "Modified")
                        {
                            ModifyDevRemark(dgvDevRemark.Rows[i].Cells[0].Value.ToString(), dgvDevRemark.Rows[i].Cells[1].Value.ToString(), dgvDevRemark.Rows[i].Cells[2].Value.ToString(), dgvDevRemark.Rows[i].Cells[4].Value.ToString());
                        }
                        else if (dtr.Rows[i].RowState.ToString() == "Deleted")
                        {
                            if (dcount == 0)
                            {
                                for (int j = 0; j < dgvRemarkDelete.Rows.Count; j++)
                                {
                                    DeleteDevRemark(dgvRemarkDelete.Rows[j].Cells[0].Value.ToString(), dgvRemarkDelete.Rows[j].Cells[1].Value.ToString());
                                }
                                dcount++;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Modify Turn Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 新增鞋型備註方法

        private void InsertDevRemark(string ypdh, string linenum, string remark, string noterq, string usersign)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("insert into ypzls2 (ypdh,LineNum,Remark,NoteRQ,UserSign) " +
                    "values ('{0}','{1}','{2}','{3}','{4}')"
                    , ypdh, linenum, remark, noterq, usersign);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Insert Remark Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 更新鞋型備註方法

        private void ModifyDevRemark(string ypdh, string linenum, string remark, string usersign)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("update ypzls2 set Remark='{0}',UserSign='{1}' " +
                    "where ypdh='{2}' and LineNum='{3}'"
                    , remark, usersign, ypdh, linenum);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Modify Remark Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        
        #region 把要刪除的資料放入DGV容器

        private void dgvDevRemark_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvRemarkDelete.DataSource == null)
            {
                dtrd = new DataTable("鞋型備註刪除表");
                // 開表
                dtrd.Columns.Add("rypdh", typeof(string));
                dtrd.Columns.Add("rlinenum", typeof(string));
            }
            DataRow dr = dtrd.NewRow();
            dr[0] = dgvDevRemark.CurrentRow.Cells[0].Value.ToString();
            dr[1] = dgvDevRemark.CurrentRow.Cells[1].Value.ToString();
            dtrd.Rows.Add(dr);
            dgvRemarkDelete.DataSource = dtrd;
        }

        #endregion

        #region 刪除鞋型備註方法

        private void DeleteDevRemark(string ypdh, string linenum)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string sql = string.Format("delete from ypzls2 where ypdh='{0}' and LineNum='{1}'", ypdh, linenum);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Remark Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }



        #endregion

        #endregion

        #endregion

        #region 材料交期查詢

        private void MaterialDateTimeQuery()
        {
            dsmdq = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cgz.CGNO,cgz.CLBH,c.ywpm,cgz.XXCC,cgz.Qty,cgz.CLSL,cgzs.ETA " +
                    "from CGZLSS cgz " +
                    "left join clzl c on c.cldh=cgz.CLBH " +
                    "left join CGZLS cgzs on cgzs.CGNO=cgz.CGNO and cgzs.CLBH=cgz.CLBH " +
                    "where cgz.ZLBH='{0}'", tbSampleOrderNo.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsmdq, "材料交期");
                this.dgvMaterialDate.DataSource = this.dsmdq.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Quick Query Data Error!");
            }
        }

        #endregion

        #region 輸出EXCEL方法

        private void ExportExcel(DataGridView targetdgv)
        {
            dsexcel = new DataSet();
            DBconnect dbConn = new DBconnect();
            // 匯出EXCEL
            // 建立Excel實例化
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add();
            app.Visible = true;
            // DGV輸出EXCEL演算法
            try
            {
                // 資料附值
                // 單頭資訊
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Confirm Sample";
                worksheet.Cells.Font.Name = "Times New Roman"; // 設定字體
                worksheet.Cells.Font.Size = 10;
                // TITLE資訊
                worksheet.Cells[1, 1] = "Confirm Sample Order";
                var orng = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 10]];
                orng.MergeCells = true;
                orng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; // 水平置中
                // YPZL資訊
                worksheet.Cells[2, 1] = "樣品單號";
                worksheet.Cells[2, 2] = tbSampleOrderNo.Text;
                worksheet.Cells[2, 3] = "鞋型";
                worksheet.Cells[2, 4] = tbShoeModel.Text;
                worksheet.Cells[2, 5] = "色號";
                worksheet.Cells[2, 6] = tbColorNo.Text;
                worksheet.Cells[2, 7] = "階段";
                worksheet.Cells[2, 8] = cbStage.Text;
                worksheet.Cells[3, 1] = "尺寸國別";
                worksheet.Cells[3, 2] = tbSizeCountry.Text;
                worksheet.Cells[3, 3] = "開發尺寸";
                worksheet.Cells[3, 4] = tbDevSize.Text;
                worksheet.Cells[3, 5] = "大底尺寸";
                worksheet.Cells[3, 6] = tbOutsoleSize.Text;
                worksheet.Cells[3, 7] = "楦頭尺寸";
                worksheet.Cells[3, 8] = tbFomSize.Text;
                worksheet.Cells[4, 1] = "幣別";
                worksheet.Cells[4, 2] = cbCurrency.Text;
                worksheet.Cells[4, 3] = "報價匯率";
                worksheet.Cells[4, 4] = tbRate.Text;
                worksheet.Cells[4, 5] = "雙數";
                worksheet.Cells[4, 6] = tbQTY.Text;
                worksheet.Cells[4, 7] = "季節";
                worksheet.Cells[4, 8] = tbSeason.Text;
                worksheet.Cells[5, 1] = "開單日";
                worksheet.Cells[5, 2] = tbOrderListDate.Text;
                worksheet.Cells[5, 3] = "材料完成日";
                worksheet.Cells[5, 4] = tbMaterialDate.Text;
                worksheet.Cells[5, 5] = "實際完成日";
                worksheet.Cells[5, 6] = tbFinallyDate.Text;
                worksheet.Cells[5, 7] = "交期";
                worksheet.Cells[5, 8] = tbLeadTime.Text;
                worksheet.Cells[6, 1] = "生產廠區";
                worksheet.Cells[6, 2] = cbFactory.Text;
                worksheet.Cells[6, 5] = "顏色說明";
                worksheet.Cells[6, 6] = tbColorDetail.Text;
                worksheet.Range[worksheet.Cells[6, 2], worksheet.Cells[6, 4]].MergeCells = true;
                worksheet.Range[worksheet.Cells[6, 6], worksheet.Cells[6, 8]].MergeCells = true;
                var orng2 = worksheet.Range[worksheet.Cells[2, 9], worksheet.Cells[6, 10]];
                orng2.MergeCells = true;
                // YPZLS資訊
                worksheet.Cells[7, 1] = "部位";
                worksheet.Cells[7, 2] = "部位名稱";
                worksheet.Cells[7, 3] = "材料編號";
                worksheet.Cells[7, 4] = "材料名稱";
                worksheet.Cells[7, 5] = "單位";
                worksheet.Cells[7, 6] = "採區";
                worksheet.Cells[7, 7] = "用量";
                worksheet.Cells[7, 8] = "子母材料";
                worksheet.Cells[7, 9] = "LOSS%";
                worksheet.Cells[7, 10] = "廠商";
                string sql = string.Format("select ys.BWBH,b.ywsm,ys.CLBH,case when RTRIM(isnull(c.ywpm,''))!='' then rtrim(c.ywpm) else rtrim(ct.ywpm) end ywpm,c.dwbh,c.CQDH,ys.CLSL,c.clzmlb,ys.LOSS,z.zsywjc " +
                    "from YPZLS ys " +
                    "left join clzl c on c.cldh=ys.CLBH " +
                    "left join clzltemp ct on ct.tempddbh=ys.CLBH " +
                    "left join bwzl b on b.bwdh=ys.BWBH " +
                    "left join zszl z on z.zsdh=ys.CSBH " +
                    "where ys.YPDH='{0}' " +
                    "union all " +
                    "select ys.BWBH,'N/A',cz.cldh_S,c.ywpm,c.dwbh,c.CQDH,ys.CLSL*cz.syl as clsl,c.clzmlb,ys.LOSS,z.zsywjc " +
                    "from YPZLS ys " +
                    "left join clzhzl cz on cz.cldh_M=ys.CLBH " +
                    "left join clzl c on c.cldh=cz.cldh_S " +
                    "left join bwzl b on b.bwdh=ys.BWBH " +
                    "left join zszl z on z.zsdh=ys.CSBH " +
                    "where ys.YPDH='{1}' and cz.cldh_S is not null " +
                    "order by ys.BWBH"
                    , tbSampleOrderNo.Text, tbSampleOrderNo.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsexcel, "YPZLS表");
                for (int i = 0; i < dsexcel.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dsexcel.Tables[0].Columns.Count; j++)
                    {
                        worksheet.Cells[i + 8, j + 1] = dsexcel.Tables[0].Rows[i][j].ToString();
                    }
                }
                // YPZLS數量(計算輸出EXCEL格數用)
                string sql2 = string.Format("select count(*) from(select CLBH from YPZLS where YPDH='{0}' " +
                    "union all " +
                    "select cz.cldh_S from YPZLS ys left join clzl c on c.cldh=ys.CLBH left join clzhzl cz on cz.cldh_M=c.cldh " +
                    "where ys.YPDH='{1}' and cz.cldh_S is not null) a", tbSampleOrderNo.Text, tbSampleOrderNo.Text);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(dsexcel, "YPZLS數量");
                int count = Convert.ToInt32(dsexcel.Tables[1].Rows[0][0]);
                int count2 = 0;
                // YPZLS2資訊
                if (dgvDevRemark.RowCount > 0)
                {
                    worksheet.Cells[8 + count, 1] = "序號";
                    worksheet.Cells[8 + count, 2] = "註記內容";
                    worksheet.Cells[8 + count, 3] = "註記時間";
                    worksheet.Cells[8 + count, 4] = "註記人";
                    string sql3 = string.Format("select LineNum,Remark,NoteRQ,UserSign from ypzls2 where ypdh='{0}' order by LineNum"
                        , tbSampleOrderNo.Text);
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbConn.connection);
                    adapter3.Fill(dsexcel, "YPZLS2表");
                    for (int i = 0; i < dsexcel.Tables[2].Rows.Count; i++)
                    {
                        for (int j = 0; j < dsexcel.Tables[2].Columns.Count; j++)
                        {
                            worksheet.Cells[i + 8 + count + 1, j + 1] = dsexcel.Tables[2].Rows[i][j].ToString();
                        }
                    }
                    // YPZLS2數量(計算輸出EXCEL格數用)
                    string sql4 = string.Format("select count(*) from ypzls2 where ypdh='{0}'", tbSampleOrderNo.Text);
                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, dbConn.connection);
                    adapter4.Fill(dsexcel, "YPZLS2數量");
                    count2 = Convert.ToInt32(dsexcel.Tables[3].Rows[0][0]);
                }
                var orng3 = worksheet.Range[worksheet.Cells[8 + count, 5], worksheet.Cells[8 + count + count2, 10]];
                orng3.MergeCells = true;
                // 審核簽名欄位
                worksheet.Cells[8 + count + count2 + 2, 1] = "總經理";
                worksheet.Cells[8 + count + count2 + 2, 3] = "協理";
                worksheet.Cells[8 + count + count2 + 2, 5] = "經理";
                worksheet.Cells[8 + count + count2 + 2, 7] = "單位主管";
                worksheet.Cells[8 + count + count2 + 2, 9] = "審核";
                // 所有劃線(除了簽名欄位)
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[8 + count + count2, 10]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // 簽名欄位劃線

                orng.Font.Name = "標楷體"; // TITLE
                orng.Font.Size = 18;

                ((Excel.Range)worksheet.Cells[7, 1]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 2]).EntireColumn.ColumnWidth = 15;
                ((Excel.Range)worksheet.Cells[7, 3]).EntireColumn.ColumnWidth = 15;
                ((Excel.Range)worksheet.Cells[7, 4]).EntireColumn.ColumnWidth = 40;
                ((Excel.Range)worksheet.Cells[7, 5]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 6]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 7]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 8]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 9]).EntireColumn.ColumnWidth = 10;
                ((Excel.Range)worksheet.Cells[7, 10]).EntireColumn.ColumnWidth = 20;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("Excel Export Data Error!");
            }
        }

        #endregion

        #endregion

        
    }
}
