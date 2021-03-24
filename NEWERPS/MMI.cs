using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace NEWERPS
{
    /// <summary>
    /// MaterialMainInformation 材料主檔
    /// </summary>
    public partial class MMI : Form
    {
        #region 變數

        /// <summary>
        /// 速查DGV容器
        /// </summary>
        DataSet ds = new DataSet();
        /// <summary>
        /// 材料大分類容器(速查頁面)
        /// </summary>
        DataSet dsqA = new DataSet();
        /// <summary>
        /// 材料小分類容器(速查頁面)
        /// </summary>
        DataSet dsqB = new DataSet();
        /// <summary>
        /// 材料大分類容器(主檔頁面)
        /// </summary>
        DataSet dsA = new DataSet();
        /// <summary>
        /// 材料小分類容器(主檔頁面)
        /// </summary>
        DataSet dsB = new DataSet();
        /// <summary>
        /// 主檔下拉選單容器(顏色,單位)
        /// </summary>
        DataSet dsmcb = new DataSet();
        /// <summary>
        /// 主檔特性容器(特性與內容)
        /// </summary>
        DataSet dsfeature = new DataSet();
        /// <summary>
        /// 主頁最大值容器(新增時)
        /// </summary>
        DataSet dsBigest = new DataSet();
        /// <summary>
        /// 材料供應商容器
        /// </summary>
        DataSet dsSupply = new DataSet();
        /// <summary>
        /// RSL文件容器
        /// </summary>
        DataSet dsRSL = new DataSet();
        /// <summary>
        /// 子材料容器
        /// </summary>
        DataSet dsDetailM = new DataSet();

        public string USERID;
        private string classA;
        /// <summary>
        /// 材料名稱中英文(變數承接)
        /// </summary>
        private string omnameCN, omnameEN;
        /// <summary>
        /// 編輯儲存前存當前材料資訊(若取消編輯則使用值呼叫主頁資訊)
        /// </summary>
        private string mcldh;
        /// <summary>
        /// 編輯儲存前存當前小分類index
        /// </summary>
        private int mcbindex;
        // 陣列資訊
        private string[] encryption = new string[10]; // 暗碼(特行序號)
        private string[] materialCN = new string[10]; // 中文名稱
        private string[] materialEN = new string[10]; // 英文名稱
        private int counter = 0; // 陣列計數器
        private int clicktime = 0; // 點擊次數(已選過的灰框)

        private string IorM; // 新增或修改
        private bool isDetailBack = false; // 是否返回材料主檔
        // 速查頁面
        private int cbcbindex; // 儲存下拉單index(材料小分類)
        private string cbcbpercent; // 材料小分類查詢字串

        //語言變數
        public DataSet dsL = new DataSet();
        public string userLanguage;
        string userForm = "MMI";

        #endregion

        #region 構造函式

        public MMI()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void MaterialMainInformation_Load(object sender, EventArgs e)
        {
            try
            { 
                USERID = Program.User.userID;
                //初始呼叫
                ClassAComboboxDisplayQ(cbClassAQuery); // 速查頁面材料下拉選單
                ClassAComboboxDisplayM(cbClassA); // 主檔頁面材料下拉選單
                MainMaterialGetCombobox(); // 主檔下拉選單(顏色,單位)
                cbcbpercent = "";
                cbGJLB.SelectedIndex = 0;

                // 暗碼組成
                lbEncryption.Text = "";
                for (int i = 0; i <= 9; i++)
                {
                    encryption[i] = "zzzz";
                    lbEncryption.Text = lbEncryption.Text + encryption[i];
                }

                //獲取語言
                userLanguage = Program.LanguageType.userLanguage;
                //更改語言
                ChangeLabel();
                ChangeDataView();
            }
            catch (Exception) { }
        }

        #endregion

        #region CheckBox Event

        #region 安全庫存選項改變事件

        // 主檔
        private void chkIsInStockM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IsInStockStatus();
            }
            catch (Exception) { }
        }

        #endregion

        #region 組合材料選項改變事件

        private void chkCombination_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IsCombination();
            }
            catch (Exception) { }
        }

        #endregion

        #region 速查材料小分類開關事件

        private void chkAllClassB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllClassB.Checked)
                {
                    cbcbpercent = "%";
                    cbcbindex = cbClassBQuery.SelectedIndex;
                    cbClassBQuery.SelectedIndex = -1;
                    cbClassBQuery.Enabled = false;
                }
                else
                {
                    cbcbpercent = "";
                    ClassBComboboxDisplayQ(classA, cbClassBQuery);
                    if (cbClassBQuery.Items.Count < cbcbindex)
                    {
                        cbClassBQuery.SelectedIndex = 0;
                    }
                    else
                    {
                        cbClassBQuery.SelectedIndex = cbcbindex;
                    }
                    cbClassBQuery.Enabled = true;
                }
            }
            catch (Exception) { }
        } 

        #endregion

        #endregion

        #region PictureBox Event

        #region 雙擊PictureBox事件

        private void pcPic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pcPic.ImageLocation = openFileDialog1.FileName;
                string picname = Path.GetFileName(pcPic.ImageLocation);
            }
            catch (Exception) { }
        }

        #endregion

        #region RSL文件位置點擊事件

        private void btnRSLFileName_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                lbURL.Text = Path.GetFileName(openFileDialog1.FileName);
            }
            catch (Exception) { }
        }

        #endregion 

        #endregion
        
        #region TabControl項目頁籤改變

        private void tcMaterialMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((sender as TabControl).SelectedIndex)
                {
                    case 0: // 材料速查頁籤
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true; //暫時關閉
                        tsbModify.Enabled = true;
                        tsbDelete.Enabled = false;
                        break;
                    case 1: // 材料基本檔頁籤
                        tsbQuery.Enabled = true;
                        //tsbInsert.Enabled = false; //暫時關閉
                        tsbInsert.Enabled = true; //暫時關閉
                        if (tbCLDH.Text != "")
                        {
                            if (dgvMaterialQueryData.CurrentCell != null)
                            {
                                QueryCallMaterialData(dgvMaterialQueryData.CurrentRow.Cells[0].Value.ToString()); // 刷新頁面資訊
                            }
                            //tsbDelete.Enabled = true; //暫時關閉
                            if (chkIsDisable.Checked)
                            {
                                tsbDelete.Enabled = false;
                            }
                            tsbModify.Enabled = true; //暫時關閉
                        }
                        else
                        {
                            tsbDelete.Enabled = false;
                            tsbModify.Enabled = false;
                        }
                        if (isDetailBack) // 是否有新增子材料
                        {
                            QueryMainFromDetail(); // 重刷材料名稱(+子材料)
                            isDetailBack = false;
                        }
                        break;
                    case 2: // 材料供應商頁籤
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                        if (tbCLDH.Text != "")
                        {
                            QuerySupplierList(); // 供應商查詢
                            dgvSupplierList.ClearSelection();
                        }
                        else
                        {
                            tcMaterialMain.SelectedIndex = 1;
                            MessageBox.Show("No Material Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 3: // RSL文件頁籤
                        tsbQuery.Enabled = true;
                        tsbInsert.Enabled = true; //暫時關閉
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                        if (chkRSL.Checked == true)
                        {
                            RSLGetCombobox(tbCLDH.Text); // RSL下拉選單
                            QueryRSL(); // RSL查詢
                            dgvRSL.ClearSelection();
                        }
                        else
                        {
                            tcMaterialMain.SelectedIndex = 1;
                            MessageBox.Show("No RSL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 4: // 子材料頁籤
                        tsbQuery.Enabled = false;
                        tsbInsert.Enabled = true; //暫時關閉
                        tsbModify.Enabled = false;
                        tsbDelete.Enabled = false;
                        if (chkCombination.Checked == true)
                        {
                            tbCLZHMaterialCN.Text = tbMainMaterialCN.Text;
                            tbCLZHMaterialEN.Text = tbMainMaterialEN.Text;
                            QueryDetail();
                            if (dgvCLZH.Rows.Count > 0)
                            {
                                dgvCLZH_CellClick(dgvCLZH, new DataGridViewCellEventArgs(0, 0));
                            }
                        }
                        else
                        {
                            tcMaterialMain.SelectedIndex = 1;
                            MessageBox.Show("No Combination", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception) { }
        }

        #endregion
        
        #region Combobox Event

        #region 速查頁

        // 大類
        private void cbClassAQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbClassBQuery.Text = "";
                classA = dsqA.Tables[0].Rows[cbClassAQuery.SelectedIndex]["Class_ID"].ToString();
                if (!chkAllClassB.Checked)
                {
                    ClassBComboboxDisplayQ(classA, cbClassBQuery);
                }
            }
            catch (Exception) { }
        }

        #endregion
        
        #region 主檔頁

        // 材料大分類
        private void cbClassA_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                tbCLDH.Text = "";
                classA = dsA.Tables[0].Rows[cbClassA.SelectedIndex]["Class_ID"].ToString();
                ClassBComboboxDisplayM(classA, cbClassB);
                if (cbClassA.SelectedIndex == 3) // 組合材料
                {
                    chkCombination.Checked = true;
                }
                else
                {
                    chkCombination.Checked = false;
                }
                dgvFeatureItem.DataSource = null; // 清除DGV資料
            }
            catch(Exception){ }
        }

        // 材料小分類
        private void cbClassB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbCLDH.Text = "";
                // 顯示特性至DGV
                QueryFeatureData();
                if (cbClassB.SelectedValue.ToString().Length == 3) // 新增
                {
                    if (IorM == "Modify")
                    {
                        if (mcbindex == cbClassB.SelectedIndex)
                        {
                            QueryCallMaterialData(mcldh); // 重新呼叫主頁面資訊
                        }
                        else
                        {
                            lbEncryption.Text = "";
                            for (int i = 0; i <= 9; i++)
                            {
                                encryption[i] = "zzzz";
                                lbEncryption.Text = lbEncryption.Text + encryption[i];
                                materialCN[i] = "";
                                materialEN[i] = "";
                            }
                            cbColor.SelectedIndex = 0;
                            tbMainMaterialCN.Text = "";
                            tbMainMaterialEN.Text = "";
                        }
                    }
                }
                dgvFeatureItem.DataSource = null; // 清除DGV資料
            }
            catch (Exception) { }
        }

        // 顏色
        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbColor.SelectedValue.ToString().Length == 4)
                {
                    if (IorM == "Insert" || IorM == "Modify")
                    {
                        ReorganizationStringM(); // 重組字串
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region 特性內容模糊查詢按鈕事件

        private void btnQueryFeatureItem_Click(object sender, EventArgs e)
        {
            try
            {
                FuzzyQueryFeatureItemData(this.dgvFeature.CurrentRow.Cells[2].Value.ToString(), this.dgvFeature.CurrentRow.Cells[3].Value.ToString(), this.dgvFeature.CurrentRow.Cells[4].Value.ToString(), Convert.ToBoolean(this.dgvFeature.CurrentRow.Cells[5].Value));
            }
            catch (Exception) { }
        } 

        #endregion
        //打勾切換未完成
        #region DGV Event

        #region 速查DGV事件(顯示於主檔畫面)

        // 單點擊
        private void dgvMaterialQueryData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMaterialQueryData.CurrentRow.Cells[0].Value.ToString() != "") // 可以印Excel
                {
                    tsbPrint.Enabled = true;
                }
                QueryCallMaterialData(dgvMaterialQueryData.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception) { }
        }

        // 雙點擊
        private void dgvMaterialQueryData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tcMaterialMain.SelectedIndex = 1;
            }
            catch (Exception) { }
        }

        #endregion
        //
        #region 特性DGV點擊事件

        // 上DGV [單點擊]
        private void dgvFeature_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbQueryFeatureItem.Text = "";
                counter = e.RowIndex;
                dgvFeatureItem.DataSource = null;
                QueryFeatureItemData(this.dgvFeature.CurrentRow.Cells[2].Value.ToString(), this.dgvFeature.CurrentRow.Cells[3].Value.ToString(), this.dgvFeature.CurrentRow.Cells[4].Value.ToString(), Convert.ToBoolean(this.dgvFeature.CurrentRow.Cells[5].Value));
                dgvFeatureItem.ColumnHeadersVisible = true; // 行隱藏
            }
            catch (Exception) { }
        }

        // 下DGV [判斷DGV是否有值變更且尚未被認可]
        private void dgvFeatureItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFeatureItem.IsCurrentCellDirty)
                {
                    this.dgvFeatureItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception) { }
        }

        // 下DGV [打勾更改值與附值]
        private void dgvFeatureItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCheckBoxCell checkCell = null;
                if (this.dgvFeatureItem.Columns[e.ColumnIndex].Name.Equals("chkSelected"))
                {
                    if (dgvFeature.CurrentRow.DefaultCellStyle.BackColor == Color.Empty) // 未勾選 [白框]
                    {
                        // 取得當前checkbox欄位
                        checkCell = this.dgvFeatureItem.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                        if ((bool)checkCell.EditedFormattedValue) // chk打勾
                        {
                            // 暗碼與名稱附值
                            if (counter <= 9)
                            {
                                encryption[counter] = dgvFeatureItem.CurrentRow.Cells[3].Value.ToString().PadLeft(4, 'z');
                                materialCN[counter] = dgvFeatureItem.CurrentRow.Cells[1].Value.ToString().Trim();
                                materialEN[counter] = dgvFeatureItem.CurrentRow.Cells[2].Value.ToString().Trim();
                                ReorganizationStringM(); // 重組字串
                                this.dgvFeature.CurrentRow.DefaultCellStyle.BackColor = Color.Gray; // 上DGV改色
                                cbClassA.Enabled = false;
                                cbClassB.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Out of range!", "Warning!");
                            }
                            /*
                            foreach (DataGridViewRow row in dgvFeatureItem.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                                {
                                    row.Cells[0].Value = false;
                                }
                            }
                            */
                        }
                        else // 取消打勾
                        {
                            encryption[counter] = "zzzz";
                            materialCN[counter] = "";
                            materialEN[counter] = "";
                            ReorganizationStringM(); // 重組字串
                            this.dgvFeature.CurrentRow.DefaultCellStyle.BackColor = Color.Empty; // 上DGV顏色恢復
                                                                                                 // 上DGV沒顏色即可改變大小類
                            for (int i = 0; i < dgvFeature.Rows.Count; i++)
                            {
                                if (dgvFeature.Rows[i].DefaultCellStyle.BackColor == Color.Gray)
                                {
                                    cbClassA.Enabled = false;
                                    cbClassB.Enabled = false;
                                    break;
                                }
                                else
                                {
                                    cbClassA.Enabled = true;
                                    cbClassB.Enabled = true;
                                }
                            }
                        }
                    }
                    else // 已勾選 [灰框]
                    {
                        if (clicktime == 0)
                        {
                            clicktime++;
                        }
                        else
                        {
                            // 取得當前checkbox欄位
                            checkCell = this.dgvFeatureItem.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                            if ((bool)checkCell.EditedFormattedValue) // chk打勾
                            {
                                // 暗碼與名稱附值
                                if (counter <= 9)
                                {
                                    encryption[counter] = dgvFeatureItem.CurrentRow.Cells[3].Value.ToString().PadLeft(4, 'z');
                                    materialCN[counter] = dgvFeatureItem.CurrentRow.Cells[1].Value.ToString().Trim();
                                    materialEN[counter] = dgvFeatureItem.CurrentRow.Cells[2].Value.ToString().Trim();
                                    ReorganizationStringM(); // 重組字串
                                    this.dgvFeature.CurrentRow.DefaultCellStyle.BackColor = Color.Gray; // 上DGV改色
                                    cbClassA.Enabled = false;
                                    cbClassB.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Out of range!", "Warning!");
                                }
                                /*
                                foreach (DataGridViewRow row in dgvFeatureItem.Rows)
                                {
                                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                                    {
                                        row.Cells[0].Value = false;
                                    }
                                }
                                */
                            }
                            else // 取消打勾
                            {
                                encryption[counter] = "zzzz";
                                materialCN[counter] = "";
                                materialEN[counter] = "";
                                ReorganizationStringM(); // 重組字串
                                this.dgvFeature.CurrentRow.DefaultCellStyle.BackColor = Color.Empty; // 上DGV顏色恢復
                                                                                                     // 上DGV沒顏色即可改變大小類
                                for (int i = 0; i < dgvFeature.Rows.Count; i++)
                                {
                                    if (dgvFeature.Rows[i].DefaultCellStyle.BackColor == Color.Gray)
                                    {
                                        cbClassA.Enabled = false;
                                        cbClassB.Enabled = false;
                                        break;
                                    }
                                    else
                                    {
                                        cbClassA.Enabled = true;
                                        cbClassB.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 供應商DGV點擊事件

        private void dgvSupplierList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tsbModify.Enabled = true;
                tsbDelete.Enabled = true;
            }
            catch (Exception) { }
        }

        #endregion

        #region RSL DGV點擊事件

        private void dgvRSL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tsbModify.Enabled = true;
                tsbDelete.Enabled = true;
                if (IorM == "Modify")
                {
                    cbSupplierVendorR.SelectedValue = dgvRSL.CurrentRow.Cells[0].Value.ToString();
                    dtpExpiryDate.Value = Convert.ToDateTime(dgvRSL.CurrentRow.Cells[2].Value);
                    lbURL.Text = dgvRSL.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 子材料DGV點擊事件

        // 單點
        private void dgvCLZH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 只有材料可修改
                if (dgvCLZH.CurrentCell != null)
                {
                    tsbDelete.Enabled = true;
                    if (dgvCLZH.CurrentRow.Cells[10].Value.ToString() == "ZZZZ")
                    {
                        tsbModify.Enabled = true;
                    }
                    else
                    {
                        tsbModify.Enabled = false;
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region TSB按鈕事件

        #region 查詢事件按鈕

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcMaterialMain.SelectedIndex == 0)
                {
                    if (cbClassBQuery.SelectedIndex == -1)
                    {
                        QueryMaterialData(cbClassAQuery.SelectedValue + cbcbpercent, tbCLDHQuery.Text, tbMaterialNameQuery.Text);
                    }
                    else
                    {
                        QueryMaterialData(cbClassBQuery.SelectedValue.ToString(), tbCLDHQuery.Text, tbMaterialNameQuery.Text);
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 1)
                {
                    tcMaterialMain.SelectedIndex = 0;
                }
                else if (tcMaterialMain.SelectedIndex == 2)
                {
                    QuerySupplierList();
                }
                else if (tcMaterialMain.SelectedIndex == 3)
                {
                    QueryRSL();
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 清除欄位按鈕事件

        private void tsbClear_Click(object sender, EventArgs e)
        {
            try
            {
                UIDataClear();
            }
            catch (Exception) { }
        } 

        #endregion
        
        #region 新增按鈕事件

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                IorM = "Insert";
                TSBstatus("Insert");
            }
            catch (Exception) { }
        } 

        #endregion
        
        #region 刪除按鈕事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteMaterialInformation();
            }
            catch (Exception) { }
        }

        #endregion

        #region 修改按鈕事件

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                IorM = "Modify";
                TSBstatus("Modify");
            }
            catch (Exception) { }
        }

        #endregion
        
        #region 儲存按鈕事件

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcMaterialMain.SelectedIndex == 4)
                {
                    // 檢查子材料中英是否超過1024
                    if (tbCLZHMaterialCN.Text.Length > 1024 || tbCLZHMaterialEN.Text.Length > 1024)
                    {
                        MessageBox.Show("Length Over Overflow(1024), Please Modify To Below 1024!");
                        tbCLZHMaterialCN.Enabled = true;
                        tbCLZHMaterialEN.Enabled = true;
                        tsbClear.Enabled = false; // 彈出視窗無清除按鈕
                        tsbCancel.Enabled = false; // 只能儲存
                    }
                    else if (IorM == "Insert")
                    {
                        InsertMaterialInformation();
                        IorM = "none";
                        TSBstatus("Recover");
                    }
                }
                else
                {
                    if (IorM == "Insert")
                    {
                        InsertMaterialInformation();
                    }
                    else if (IorM == "Modify")
                    {
                        ModifyMaterialInformation();
                    }
                    IorM = "none";
                    TSBstatus("Recover");
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 儲存取消按鈕事件

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (IorM == "Insert" && (tcMaterialMain.SelectedIndex == 1 || tcMaterialMain.SelectedIndex == 3))
                {
                    UIDataClear();
                }
                IorM = "none";
                TSBstatus("Recover");
            }
            catch (Exception) { }
        }

        #endregion

        #region 列印Excel按鈕事件

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcelQuery();
            }
            catch (Exception) { }
        } 

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
                int r = dgvWord.Rows.Count;

                for (int i = 0; i < r; i++)
                {
                    dgvWord.Columns[i].HeaderText = dgvWord.Rows[i].Cells[3].Value.ToString();
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
            }
            catch (Exception) { }
        }

        #endregion

        #endregion
        
        #region 字串重組(母子材料)
        
        private void ReorganizationStringM()
        {
            try
            {
                lbEncryption.Text = "";
                tbMainMaterialCN.Text = "";
                tbMainMaterialEN.Text = "";
                // 暗碼組合
                for (int i = 0; i <= 9; i++)
                {
                    lbEncryption.Text = lbEncryption.Text + encryption[i];
                }
                // 名稱組合
                omnameCN = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}"
                    , materialCN[0] == null || materialCN[0] == "" ? "" : materialCN[0], materialCN[1] == null || materialCN[1] == "" ? "" : " " + materialCN[1], materialCN[2] == null || materialCN[2] == "" ? "" : " " + materialCN[2], materialCN[3] == null || materialCN[3] == "" ? "" : " " + materialCN[3], materialCN[4] == null || materialCN[4] == "" ? "" : " " + materialCN[4]
                    , materialCN[5] == null || materialCN[5] == "" ? "" : " " + materialCN[5], materialCN[6] == null || materialCN[6] == "" ? "" : " " + materialCN[6], materialCN[7] == null || materialCN[7] == "" ? "" : " " + materialCN[7], materialCN[8] == null || materialCN[8] == "" ? "" : " " + materialCN[8], materialCN[9] == null || materialCN[9] == "" ? "" : " " + materialCN[9]);
                omnameEN = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}"
                    , materialEN[0] == null || materialEN[0] == "" ? "" : materialEN[0], materialEN[1] == null || materialEN[1] == "" ? "" : " " + materialEN[1], materialEN[2] == null || materialEN[2] == "" ? "" : " " + materialEN[2], materialEN[3] == null || materialEN[3] == "" ? "" : " " + materialEN[3], materialEN[4] == null || materialEN[4] == "" ? "" : " " + materialEN[4]
                    , materialEN[5] == null || materialEN[5] == "" ? "" : " " + materialEN[5], materialEN[6] == null || materialEN[6] == "" ? "" : " " + materialEN[6], materialEN[7] == null || materialEN[7] == "" ? "" : " " + materialEN[7], materialEN[8] == null || materialEN[8] == "" ? "" : " " + materialEN[8], materialEN[9] == null || materialEN[9] == "" ? "" : " " + materialEN[9]);
                if (chkCombination.Checked)
                {
                    QueryDetail(); // 刷出子材料DGV
                    for (int i = 0; i < dgvCLZH.Rows.Count; i++) // 重組子材料
                    {
                        // 判斷格子是子材料還是加工方式
                        if (dgvCLZH.Rows[i].Cells[0].Value.ToString() != "ZZZZ") // 子材料
                        {
                            omnameCN = omnameCN + " + " + dgvCLZH.Rows[i].Cells[2].Value.ToString(); // 材料中文
                            omnameEN = omnameEN + " + " + dgvCLZH.Rows[i].Cells[1].Value.ToString(); // 材料英文
                        }
                        else // 加工方式
                        {
                            omnameCN = omnameCN + " / " + dgvCLZH.Rows[i].Cells[5].Value.ToString(); // 加工方式中文
                            omnameEN = omnameEN + " / " + dgvCLZH.Rows[i].Cells[6].Value.ToString(); // 加工方式英文
                        }
                    }
                    tbCLZHMaterialCN.Text = string.Format(dsmcb.Tables[1].Rows[cbColor.SelectedIndex][1].ToString() + "{0}", omnameCN == "" ? "" : " " + omnameCN);
                    tbCLZHMaterialEN.Text = string.Format(dsmcb.Tables[1].Rows[cbColor.SelectedIndex][2].ToString() + "{0}", omnameEN == "" ? "" : " " + omnameEN);
                }
                // 補顏色名稱
                tbMainMaterialCN.Text = string.Format(dsmcb.Tables[1].Rows[cbColor.SelectedIndex][1].ToString() + "{0}", omnameCN == "" ? "" : " " + omnameCN);
                tbMainMaterialEN.Text = string.Format(dsmcb.Tables[1].Rows[cbColor.SelectedIndex][2].ToString() + "{0}", omnameEN == "" ? "" : " " + omnameEN);
            }
            catch (Exception) { }
        }

        #endregion

        #region 材料中英文陣列字串重組(刷新時才觸發)

        private void ReorganizationMainMaterialName(string cllb, string classid, string featureid, bool cfisseparate, string sn, int group)
        {
            dsfeature = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (cfisseparate) // 專用特性 Separate
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from Separate_Item where cllb='{0}' and Class_ID='{1}' and Feature_ID='{2}'", cllb, classid, featureid);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料專用特性內容表");
                }
                else // 共用特性 Feature
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from feature_item where Feature_ID='{0}'", featureid);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料共用特性內容表");
                }
                DataRow[] rows = dsfeature.Tables[0].Select("sn='" + sn + "'");
                if (rows.Length == 0)
                {
                    //MessageBox.Show("空");
                }
                else
                {
                    int index = dsfeature.Tables[0].Rows.IndexOf(rows[0]);
                    //dgvFeatureItem.CurrentCell = dgvFeatureItem.Rows[index].Cells[0];
                    materialCN[group] = dsfeature.Tables[0].Rows[index][0].ToString().Trim();
                    materialEN[group] = dsfeature.Tables[0].Rows[index][1].ToString().Trim();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Item Query Error!");
            }
        }

        #endregion

        #region UI邏輯

        #region UI按鈕狀態判斷方法

        private void TSBstatus(string status)
        {
            try
            {
                switch (status)
                {
                    case "Recover":
                        EnableUIColumns(false);
                        if (tcMaterialMain.SelectedIndex == 1)
                        {
                            QueryCallMaterialData(mcldh); // 重新呼叫主頁面資訊(刷新)
                            TSBchange("Recover");
                            if (chkIsDisable.Checked)
                            {
                                tsbDelete.Enabled = false;
                            }
                        }
                        else if (tcMaterialMain.SelectedIndex == 2) // 供應商
                        {
                            TSBchange("Recover");
                            tsbModify.Enabled = false;
                            tsbDelete.Enabled = false;
                        }
                        else if (tcMaterialMain.SelectedIndex == 3) // RSL
                        {
                            TSBchange("Recover");
                        }
                        else if (tcMaterialMain.SelectedIndex == 4) // 子材料
                        {
                            TSBchange("Recover");
                            tsbModify.Enabled = false;
                            tsbDelete.Enabled = false;
                        }
                        break;
                    case "Insert": // 新增
                        if (tcMaterialMain.SelectedIndex == 0)
                        {
                            tcMaterialMain.SelectedIndex = 1;
                            tsbInsert.PerformClick();
                        }
                        else if (tcMaterialMain.SelectedIndex == 1) // 主檔
                        {
                            EnableUIColumns(true);
                            UIDataClear();
                            TSBchange("Insert");
                        }
                        else if (tcMaterialMain.SelectedIndex == 2) // 供應商
                        {
                            MMIS mmis = new MMIS();
                            mmis.cldh = this.tbCLDH.Text;
                            mmis.moq = this.tbMOQM.Text;
                            mmis.highstock = this.tbHighStockM.Text;
                            mmis.lowstock = this.tbLowStockM.Text;
                            mmis.highpurchqty = this.tbHighPurchQTYM.Text;
                            mmis.unit = this.cbUnit.SelectedValue.ToString();
                            mmis.cqdh = this.cbCQDH.Text;
                            mmis.ShowDialog();
                            TSBchange("Insert");
                            if (mmis.isSave)
                            {
                                QuerySupplierList(); //重新綁定
                                tsbSave.PerformClick();
                            }
                            else
                            {
                                tsbCancel.PerformClick();
                            }
                        }
                        else if (tcMaterialMain.SelectedIndex == 3) // RSL
                        {
                            EnableUIColumns(true);
                            UIDataClear();
                            TSBchange("Insert");
                        }
                        else if (tcMaterialMain.SelectedIndex == 4) // 子材料
                        {
                            EnableUIColumns(true);
                            // 子材料頁面
                            MMID mmd = new MMID();
                            mmd.cldhM = tbCLDH.Text;
                            mmd.clzhzlcount = this.dgvCLZH.Rows.Count;
                            // 材料與加工的SN需分開
                            if (dgvCLZH.Rows.Count != 0)
                            {
                                for (int i = 0; i < dgvCLZH.Rows.Count; i++)
                                {
                                    if (dgvCLZH.Rows[i].Cells[0].Value.ToString() != "ZZZZ") // 附值材料加工組
                                    {
                                        mmd.msn = Convert.ToInt32(dgvCLZH.Rows[i].Cells[7].Value);
                                    }
                                    else if (dgvCLZH.Rows[i].Cells[0].Value.ToString() == "ZZZZ") // 附值加工方式加工組
                                    {
                                        mmd.psn = Convert.ToInt32(dgvCLZH.Rows[i].Cells[7].Value);
                                    }
                                }
                            }
                            mmd.ShowDialog();
                            if (mmd.isSave)
                            {
                                ReorganizationStringM(); // 子母材料重組
                                TSBchange("Insert");
                                tsbInsert.Enabled = true; // 可重複新增
                                tsbClear.Enabled = false; // 彈出視窗無清除按鈕
                                tsbCancel.Enabled = false; // 只能儲存
                            }
                            else
                            {
                                tsbInsert.Enabled = true; // 可重複新增
                                tsbCancel.Enabled = true;
                            }
                        }
                        break;
                    case "Modify": // 修改
                        if (tcMaterialMain.SelectedIndex == 1) // 主檔
                        {
                            EnableUIColumns(true);
                            // 暫時關閉修改為組合材料與改大類
                            chkCombination.Enabled = false;
                            cbClassA.Enabled = false;
                            // 存當前資訊
                            mcldh = this.tbCLDH.Text;
                            mcbindex = this.cbClassB.SelectedIndex;
                            TSBchange("Modify");
                        }
                        else if (tcMaterialMain.SelectedIndex == 2) // 供應商
                        {
                            MMIS mmis = new MMIS();
                            mmis.cldh = this.tbCLDH.Text;
                            mmis.zsdh = this.dgvSupplierList.CurrentRow.Cells[0].Value.ToString();
                            mmis.client = this.dgvSupplierList.CurrentRow.Cells[2].Value.ToString();
                            mmis.unit = this.dgvSupplierList.CurrentRow.Cells[14].Value.ToString();
                            mmis.cqdh = this.dgvSupplierList.CurrentRow.Cells[15].Value.ToString();
                            mmis.ShowDialog();
                            TSBchange("Modify");
                            if (mmis.isSave)
                            {
                                QuerySupplierList(); //重新綁定
                                tsbSave.PerformClick();
                            }
                            else
                            {
                                tsbCancel.PerformClick();
                            }
                        }
                        else if (tcMaterialMain.SelectedIndex == 3) // RSL
                        {
                            EnableUIColumns(true);
                            TSBchange("Modify");
                        }
                        else if (tcMaterialMain.SelectedIndex == 4) // 子材料
                        {
                            MMIDM mmidm = new MMIDM();
                            mmidm.cldhm = tbCLDH.Text;
                            mmidm.cldhs = dgvCLZH.CurrentRow.Cells[0].Value.ToString();
                            mmidm.usage = dgvCLZH.CurrentRow.Cells[4].Value.ToString();
                            mmidm.sn = dgvCLZH.CurrentRow.Cells[7].Value.ToString();
                            mmidm.vendor = dgvCLZH.CurrentRow.Cells[11].Value.ToString();
                            mmidm.ShowDialog();
                            if (mmidm.isSave)
                            {
                                MessageBox.Show("Modify Detail Material Success!");
                                QueryDetail();
                            }
                        }
                        break;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region UI按鈕改變方法

        private void TSBchange(string status)
        {
            try
            {
                switch (status)
                {
                    case "Recover":
                        tsbQuery.Enabled = true;
                        tsbClear.Enabled = false;
                        tsbInsert.Enabled = true;
                        tsbModify.Enabled = true;
                        tsbSave.Enabled = false;
                        tsbCancel.Enabled = false;
                        break;
                    case "Insert":
                        tsbQuery.Enabled = false;
                        tsbClear.Enabled = true;
                        tsbInsert.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                        break;
                    case "Modify":
                        tsbQuery.Enabled = false;
                        tsbClear.Enabled = false;
                        tsbInsert.Enabled = false;
                        tsbModify.Enabled = false;
                        tsbSave.Enabled = true;
                        tsbCancel.Enabled = true;
                        break;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region UI輸入欄位狀態開關方法

        private void EnableUIColumns(bool isEnable)
        {
            try
            {
                if (isEnable) // 開
                {
                    if (tcMaterialMain.SelectedIndex == 1) // 主檔
                    {
                        cbClassA.Enabled = true;
                        cbClassB.Enabled = true;
                        cbGJLB.Enabled = true;
                        cbCQDH.Enabled = true;
                        cbUnit.Enabled = true;
                        cbColor.Enabled = true;
                        tbMOQM.Enabled = true;
                        chkCombination.Enabled = true;
                        chkRSL.Enabled = true;
                        chkRiskColYN.Enabled = true;
                        chkIsInStockM.Enabled = true;
                        chkIsDisable.Enabled = true;
                        chkXHCL.Enabled = true;
                        chkLYCC.Enabled = true;
                        tbHighStockM.Enabled = true;
                        tbLowStockM.Enabled = true;
                        tbHighPurchQTYM.Enabled = true;
                        pcPic.Enabled = true;
                        dgvFeatureItem.DataSource = null; // 清除DGV資料
                        splitContainer1.Enabled = true; // 右DGV(上)
                        splitContainer2.Enabled = true; // 右DGV(下)
                    }
                    else if (tcMaterialMain.SelectedIndex == 3) // RSL
                    {
                        cbSupplierVendorR.Enabled = true;
                        dtpExpiryDate.Enabled = true;
                        btnRSLFileName.Enabled = true;
                    }
                }
                else // 關
                {
                    if (tcMaterialMain.SelectedIndex == 1) // 主檔
                    {
                        cbClassA.Enabled = false;
                        cbClassB.Enabled = false;
                        cbGJLB.Enabled = false;
                        cbCQDH.Enabled = false;
                        cbUnit.Enabled = false;
                        cbColor.Enabled = false;
                        tbMOQM.Enabled = false;
                        chkCombination.Enabled = false;
                        chkRSL.Enabled = false;
                        chkRiskColYN.Enabled = false;
                        chkIsInStockM.Enabled = false;
                        chkIsDisable.Enabled = false;
                        chkXHCL.Enabled = false;
                        chkLYCC.Enabled = false;
                        tbHighStockM.Enabled = false;
                        tbLowStockM.Enabled = false;
                        tbHighPurchQTYM.Enabled = false;
                        pcPic.Enabled = false;
                        splitContainer1.Enabled = false; // 右DGV(上)
                        splitContainer2.Enabled = false; // 右DGV(下)
                    }
                    else if (tcMaterialMain.SelectedIndex == 3) // RSL
                    {
                        cbSupplierVendorR.Enabled = false;
                        dtpExpiryDate.Enabled = false;
                        btnRSLFileName.Enabled = false;
                    }
                    else if (tcMaterialMain.SelectedIndex == 4) // 子材料(長度超過1024且修改後會觸發)
                    {
                        tbCLZHMaterialCN.Enabled = false;
                        tbCLZHMaterialEN.Enabled = false;
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region CheckBox Function

        #region 安全庫存改變狀態方法

        private void IsInStockStatus()
        {
            try
            {
                if (chkIsInStockM.Checked)
                {
                    G0001.Enabled = true;
                }
                else
                {
                    G0001.Enabled = false;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 組合材料改變狀態方法

        private void IsCombination()
        {
            try
            {
                if (chkCombination.Checked)
                {
                    cbClassA.SelectedIndex = 3;
                    cbClassA.Enabled = false;
                }
                else
                {
                    cbClassA.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        #endregion 

        #endregion
        
        #region Combobox Function

        #region 顯示下拉選單項目方法(速查與主檔)

        #region 顯示下拉選單項目(材料大分類CLASS_A)

        // 速查
        private void ClassAComboboxDisplayQ(ComboBox comboBox)
        {
            dsqA = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料大分類
                string sql1 = "select Class_ID,ywsm from CLASS_A";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqA, "CLASS_A");
                comboBox.DataSource = dsqA.Tables[0];
                comboBox.ValueMember = "Class_ID";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Q Class A Combobox Error!");
            }
        }

        // 主頁
        private void ClassAComboboxDisplayM(ComboBox comboBox)
        {
            dsA = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料大分類
                string sql1 = "select Class_ID,ywsm from CLASS_A";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsA, "CLASS_A");
                comboBox.DataSource = dsA.Tables[0];
                comboBox.ValueMember = "Class_ID";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("M Class A Combobox Error!");
            }
        }

        #endregion

        #region 顯示下拉選單項目(材料分類CLASS_B)

        // 速查
        private void ClassBComboboxDisplayQ(string classID, ComboBox comboBox)
        {
            dsqB = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料分類
                string sql1 = string.Format("select cllb,ywsm,Class_ID from CLASS_B where Class_ID='{0}'", classID);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsqB, "CLASS_B");
                comboBox.DataSource = dsqB.Tables[0];
                comboBox.ValueMember = "cllb";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Q Class B Combobox Error!");
            }
        }

        // 主頁
        private void ClassBComboboxDisplayM(string classID, ComboBox comboBox)
        {
            dsB = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 材料分類
                string sql1 = string.Format("select cllb,ywsm,Class_ID from CLASS_B where Class_ID='{0}'", classID);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsB, "CLASS_B");
                comboBox.DataSource = dsB.Tables[0];
                comboBox.ValueMember = "cllb";
                comboBox.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("M Class B Combobox Error!");
            }
        }

        #endregion

        #region 主檔頁下拉選單載入(用量單位,顏色)

        private void MainMaterialGetCombobox()
        {
            dsmcb = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 用量單位
                string sql1 = "select Unit_ID,ywsm from UNIT";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsmcb, "Unit");
                cbUnit.DataSource = dsmcb.Tables[0];
                cbUnit.ValueMember = "Unit_ID";
                cbUnit.DisplayMember = "ywsm";
                
                // 顏色
                string sql2 = "select COLOR_ID,zwsm,ywsm from color";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, dbConn.connection);
                adapter2.Fill(dsmcb, "Color");
                cbColor.DataSource = dsmcb.Tables[1];
                cbColor.ValueMember = "COLOR_ID";
                cbColor.DisplayMember = "ywsm";
            }
            catch (Exception)
            {
                MessageBox.Show("Material Main Combobox Error!");
            }
        }

        #endregion

        #endregion
        
        #region 顯示下拉選單項目方法(RSL文件)

        // 廠商
        private void RSLGetCombobox(string cldh)
        {
            dsRSL = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                // 廠商
                string sql1 = string.Format("select distinct s.zsdh,z.zsjc from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh where cldh='{0}' order by zsdh", cldh);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsRSL, "廠商表");
                cbSupplierVendorR.DataSource = dsRSL.Tables[0];
                cbSupplierVendorR.ValueMember = "zsdh";
                cbSupplierVendorR.DisplayMember = "zsjc";
            }
            catch (Exception)
            {
                MessageBox.Show("RSL Combobox Error!");
            }
        }

        #endregion

        #endregion

        #region 主檔小分類改變顯示材料編號最大值方法(儲存時呼叫)

        private void GetClassBBigest(string cllb)
        {
            dsBigest = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql1 = string.Format("select top 1 cldh from clzl where cllb='{0}' order by cldh desc", cllb);
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbConn.connection);
                adapter1.Fill(dsBigest, "小分類最大值");
                tbCLDH.Text = cllb + (Convert.ToInt32(dsBigest.Tables[0].Rows[0][0].ToString().Substring(3, 7)) + 1).ToString().PadLeft(7, '0');
            }
            catch (Exception)
            {
                tbCLDH.Text = cllb + "0000001";
            }
        }

        #endregion
        
        #region 清除欄位方法(清除,保存,取消按鈕觸發)

        private void UIDataClear()
        {
            try
            {
                if (tcMaterialMain.SelectedIndex == 1) // 主檔
                {
                    cbClassA.Enabled = true;
                    cbClassA.SelectedIndex = 0;
                    cbClassB.Enabled = true;
                    cbClassB.SelectedIndex = 0;
                    tbCLDH.Text = "";
                    tbUSERID.Text = "";
                    tbUSERDATE.Text = "";
                    lbEncryption.Text = "";
                    cbGJLB.SelectedIndex = 0;
                    cbCQDH.SelectedIndex = -1;
                    for (int i = 0; i <= 9; i++)
                    {
                        encryption[i] = "zzzz";
                        lbEncryption.Text = lbEncryption.Text + encryption[i];
                        materialCN[i] = "";
                        materialEN[i] = "";
                    }
                    QueryFeatureData();
                    cbColor.SelectedIndex = 0;
                    tbMainMaterialCN.Text = "";
                    tbMainMaterialEN.Text = "";
                    cbUnit.SelectedIndex = 0;
                    chkCombination.Checked = false;
                    chkRSL.Checked = false;
                    chkRiskColYN.Checked = false;
                    chkIsInStockM.Checked = false;
                    chkIsDisable.Checked = false;
                    chkXHCL.Checked = false;
                    chkLYCC.Checked = false;
                    tbMOQM.Text = "0";
                    tbHighStockM.Text = "";
                    tbLowStockM.Text = "";
                    tbHighPurchQTYM.Text = "";
                    dgvFeatureItem.ColumnHeadersVisible = false;
                    pcPic.Image = null;
                }
                else if (tcMaterialMain.SelectedIndex == 3) // RSL文件
                {
                    if (cbSupplierVendorR.Text != "")
                    {
                        cbSupplierVendorR.SelectedIndex = 0;
                    }
                    dtpExpiryDate.Value = DateTime.Today;
                    lbURL.Text = "File Name";
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region 匯出EXCEL方法

        private void ExportExcelQuery()
        {
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cldh,cllb,dwbh,ywpm from clzl where cldh='{0}'"
                    , dgvMaterialQueryData.CurrentRow.Cells[0].Value.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "材料主檔匯出EXCEL表");
                // 匯出EXCEL
                // 建立Excel實例化
                Excel.Application excel = new Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                // 資料附值
                excel.Cells[1, 1] = ds.Tables[0].Rows[0][0].ToString();
                excel.Cells[1, 2] = ds.Tables[0].Rows[0][1].ToString();
                excel.Cells[1, 3] = ds.Tables[0].Rows[0][2].ToString();
                excel.Cells[1, 4] = ds.Tables[0].Rows[0][3].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Material Export Excel Error!");
            }
        }

        #endregion

        #region 查詢方法(含所有頁籤)

        #region 查詢材料方法(速查頁面)

        /// <summary>
        /// 速查function(材料編號,名稱中英文)
        /// </summary>
        /// <param name="cbcbq">材料小類</param>
        /// <param name="mnq">材料中英文名稱 zwpm</param>
        private void QueryMaterialData(string cbcbq, string cldh, string mnq)
        {
            tsbPrint.Enabled = false;
            ds = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cldh 材料編號,zwpm '材料名稱(中)',ywpm '材料名稱(英)' " +
                    "from clzl " +
                    "where tyjh='N' and cllb like'{0}' and cldh like'%{1}%' and (zwpm like'%{2}%' or ywpm like'%{3}%') " +
                    "order by cldh"
                    , cbcbq, cldh, mnq, mnq);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "速查材料主檔表");
                this.dgvMaterialQueryData.DataSource = this.ds.Tables[0];
                this.dgvMaterialQueryData.Columns[0].Width = 180; // 欄位寬度
                this.dgvMaterialQueryData.CurrentCell = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Material Quick Query Error!");
            }
        }

        #endregion

        #region 查詢材料主檔引數呼叫(顯示或更新主頁時呼叫)

        /// <summary>
        /// 重新綁定主檔資料
        /// </summary>
        /// <param name="cldh">材料編號</param>
        private void QueryCallMaterialData(string cldh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                // 0暗碼 1材料英文 2材料中文 3材料大分類 4材料小分類 5材料代號 6用量單位 7顏色 8MOQ 9組合材料 10RSL 11危險材料 12安全庫存 13停用 14消耗材料 15高標存量 16低標存量 17最大採購量 18圖片
                string sql = string.Format("select substring(clbm,9,40) clbm,ywpm,zwpm,substring(cllb,1,1) classA,cllb,cldh,dwbh,ysbh,MOQ,clzmlb,PDYN,RiskColYN,IS_SAFE_STOCK,tyjh,xhcl,HIGH_STOCK,LOW_STOCK,HIGH_PURCH_QTY,CLTD,USERID,convert(varchar,USERDATE,111) USERDATE,GJLB,CQDH,LYCC " +
                    "from clzl where cldh='{0}'"
                    , cldh);
                SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cbGJLB.Text = reader["GJLB"].ToString() == "" ? "000" : reader["GJLB"].ToString();
                    if(reader["CQDH"].ToString() == "")
                    {
                        cbCQDH.SelectedIndex = -1;
                    }
                    else
                    {
                        cbCQDH.Text = reader["CQDH"].ToString();
                    }
                    cbClassA.SelectedValue = reader["classA"].ToString();
                    cbClassB.SelectedValue = reader["cllb"].ToString();
                    QueryFeatureData();
                    // 暗碼
                    lbEncryption.Text= reader["clbm"].ToString();
                    if (tcMaterialMain.SelectedIndex == 1) // 到主頁面才呼叫
                    {
                        // 附值回寫給陣列(暗碼部分)
                        int subindex = 0;
                        for (int i = 0; i < encryption.Length; i++)
                        {
                            encryption[i] = lbEncryption.Text.Substring(subindex, 4);
                            subindex += 4;
                            if (encryption[i] != "zzzz")
                            {
                                dgvFeature.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                                // 回寫陣列中英文 [i > 第幾組]
                                ReorganizationMainMaterialName(dgvFeature.Rows[i].Cells[2].Value.ToString(), dgvFeature.Rows[i].Cells[3].Value.ToString(), dgvFeature.Rows[i].Cells[4].Value.ToString(), Convert.ToBoolean(dgvFeature.Rows[i].Cells[5].Value.ToString()), encryption[i], i);
                            }
                            else
                            {
                                if (i < dgvFeature.Rows.Count)
                                {
                                    dgvFeature.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
                                }
                            }
                        }
                    }
                    tbUSERID.Text = reader["USERID"].ToString();
                    tbUSERDATE.Text = reader["USERDATE"].ToString();
                    cbColor.SelectedValue = reader["ysbh"].ToString();
                    tbMainMaterialCN.Text= reader["zwpm"].ToString();
                    tbMainMaterialEN.Text = reader["ywpm"].ToString();
                    cbUnit.SelectedValue = reader["dwbh"].ToString();
                    tbMOQM.Text = reader["MOQ"].ToString();
                    chkCombination.Checked = reader["clzmlb"].ToString() == "Y" ? true : false;
                    chkRSL.Checked = reader["PDYN"].ToString() == "Y" ? true : false;
                    chkRiskColYN.Checked = reader["RiskColYN"].ToString() == "Y" ? true : false;
                    chkIsInStockM.Checked = Convert.ToBoolean(reader["IS_SAFE_STOCK"]);
                    chkIsDisable.Checked = reader["tyjh"].ToString() == "Y" ? true : false;
                    chkXHCL.Checked = reader["xhcl"].ToString() == "Y" ? true : false;
                    chkLYCC.Checked = reader["LYCC"].ToString() == "Y" ? true : false;
                    tbHighStockM.Text = reader["HIGH_STOCK"].ToString();
                    tbLowStockM.Text = reader["LOW_STOCK"].ToString();
                    tbHighPurchQTYM.Text = reader["HIGH_PURCH_QTY"].ToString();
                    tbCLDH.Text = reader["cldh"].ToString();
                    dgvFeature.ClearSelection();
                    // 修改點
                    //LoadImage(this.dgvMaterialQueryData.CurrentRow.Cells[5].Value.ToString()); // 讀照片
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("Refresh MainMaterial Data Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion
        //
        #region 查詢材料特性方法(主檔頁面)
        
        private void QueryFeatureData()
        {
            dsfeature = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cf.sortkey 組合排序,f.txzwsm 特性名稱,cf.cllb,cf.Class_ID,cf.Feature_ID,cf.Separate " +
                    "from CLASS_fEATURE cf " +
                    "left join feature f on f.Feature_ID=cf.Feature_ID " +
                    "where cf.Class_ID='{0}' and (cf.cllb='999' or cf.cllb='{1}') " +
                    "order by cf.sortkey"
                    , cbClassA.SelectedValue, cbClassB.SelectedValue);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsfeature, "材料特性表");
                this.dgvFeature.DataSource = this.dsfeature.Tables[0];
                // 隱藏class feature的cllb,classid,FeatureID,Separate
                for (int i = 2; i <= 5; i++)
                {
                    this.dgvFeature.Columns[i].Visible = false;
                }
                dgvFeature.Columns[0].Width = 100;
                dgvFeature.Columns[1].Width = 400;
            }
            catch (Exception)
            {
                MessageBox.Show("Class Feature Query Error!");
            }
        }

        #endregion
        //
        #region 全部查詢材料特性內容方法(主檔頁面)

        private void QueryFeatureItemData(string cllb, string classid, string featureid, bool cfisseparate)
        {
            dsfeature = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (cfisseparate) // 專用特性 Separate
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from Separate_Item where cllb='{0}' and Class_ID='{1}' and Feature_ID='{2}'", cllb, classid, featureid);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料專用特性內容表");
                    this.dgvFeatureItem.DataSource = this.dsfeature.Tables[0];
                }
                else // 共用特性 Feature
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from feature_item where Feature_ID='{0}'", featureid);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料共用特性內容表");
                    this.dgvFeatureItem.DataSource = this.dsfeature.Tables[0];
                }
                this.dgvFeatureItem.Columns[3].Visible = false; // 隱藏點
                this.dgvFeatureItem.Columns[0].Width = 70;
                // 針對已選的特性locate欄位
                if (dgvFeature.CurrentRow.DefaultCellStyle.BackColor == Color.Gray)
                {
                    DataRow[] rows = dsfeature.Tables[0].Select("sn='" + encryption[counter] + "'");
                    if (rows.Length == 0)
                    {
                        //MessageBox.Show("空");
                    }
                    else
                    {
                        int index = dsfeature.Tables[0].Rows.IndexOf(rows[0]);
                        dgvFeatureItem.CurrentCell = dgvFeatureItem.Rows[index].Cells[0];
                        dgvFeatureItem.Rows[index].Cells[0].Value = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Item Query Error!");
            }
        }

        #endregion

        #region 模糊查詢材料特性內容方法(主檔頁面)

        private void FuzzyQueryFeatureItemData(string cllb, string classid, string featureid, bool cfisseparate)
        {
            dsfeature = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                if (cfisseparate) // 專用特性 Separate
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from Separate_Item where cllb='{0}' and Class_ID='{1}' and Feature_ID='{2}' and (itemc like'%{3}%' or iteme like'%{4}%')"
                        , cllb, classid, featureid, tbQueryFeatureItem.Text, tbQueryFeatureItem.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料專用特性內容表");
                    this.dgvFeatureItem.DataSource = this.dsfeature.Tables[0];
                }
                else // 共用特性 Feature
                {
                    string sql = string.Format("select itemc CN,iteme EN,sn from feature_item where Feature_ID='{0}' and (itemc like'%{1}%' or iteme like'%{2}%')"
                        , featureid, tbQueryFeatureItem.Text, tbQueryFeatureItem.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(dsfeature, "材料共用特性內容表");
                    this.dgvFeatureItem.DataSource = this.dsfeature.Tables[0];
                }
                this.dgvFeatureItem.Columns[3].Visible = false; // 隱藏點
                this.dgvFeatureItem.Columns[0].Width = 70;
            }
            catch (Exception)
            {
                MessageBox.Show("Item Fuzzy Query Error!");
            }
        }

        #endregion

        #region 查詢材料供應商

        private void QuerySupplierList()
        {
            dsSupply.Clear();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select s.zsdh 廠商代號,z.zsjc 廠商名稱,s.kfdh 客戶代號,k.kfqm 客戶名稱,u.zwsm 採購單位," +
                    "case z.JKCL when '1' then 'VN' when '2' then 'TW' when '3' then 'CN' end 廠商國別,s.leadtime 交期,s.MOQ 最低購量,s.Packing_Min_Qty 最小包裝數,weight 最小包裝整數重量,HIGH_STOCK 高存,LOW_STOCK 低存,HIGH_PURCH_QTY 最大採購量,s.PM_ID,s.unit_id,CQDH 採購區域 " +
                    "from supplier_list s " +
                    "left join zszl z on z.zsdh=s.zsdh " +
                    "left join kfzl k on k.kfdh=s.kfdh " +
                    "left join UNIT u on u.Unit_ID=s.unit_id " +
                    "left join produce_method pm on pm.PM_ID=s.PM_ID " +
                    "where s.cldh='{0}'"
                    , tbCLDH.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsSupply, "材料供應商表");
                this.dgvSupplierList.DataSource = this.dsSupply.Tables[0];
                this.dgvSupplierList.Columns[13].Visible = false;
                this.dgvSupplierList.Columns[14].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier List Query Error!");
            }
        }

        #endregion
        
        #region 查詢RSL文件

        private void QueryRSL()
        {
            dsRSL = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select s.zsdh 廠商代號,z.zsjc 廠商名稱,s.Validity 文件有效期,s.URL 文件存放位置 " +
                    "from SGSLIST s " +
                    "left join zszl z on z.zsdh=s.zsdh " +
                    "where s.cldh='{0}'"
                    , tbCLDH.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsRSL, "RSL文件表");
                this.dgvRSL.DataSource = this.dsRSL.Tables[0];

                //檢查日期
                for (int i = 0; i < dgvRSL.Rows.Count; i++)
                {
                    DateTime ddt = Convert.ToDateTime(dgvRSL.Rows[i].Cells[2].Value.ToString());
                    int dmcount = ddt.Month - DateTime.Today.Month;
                    int ddcount = ddt.Day - DateTime.Today.Day;
                    if (dmcount <= 3 && dmcount >= 0 )
                    {
                        dgvRSL.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                        if (dmcount == 0 && ddcount < 0)
                        {
                            dgvRSL.Rows[i].Cells[2].Style.BackColor = Color.Red;
                        }
                    }
                    else if (dmcount < 0)
                    {
                        dgvRSL.Rows[i].Cells[2].Style.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("RSL Query Error!");
            }
        }

        #endregion
        
        #region 查詢子材料

        private void QueryDetail()
        {
            dsDetailM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cl.cldh_S 子材料編號,c.ywpm '材料名稱(英文)',c.zwpm '材料名稱(中文)',z.zsjc 廠商,cl.syl 使用量,pm.ywsm 加工方式,pm.zwsm,cl.SN 加工組,cl.ccqS 尺寸起,cl.ccqE 尺寸止,cl.PM_ID,cl.zsdh " +
                    "from clzhzl cl " +
                    "left join clzl c on c.cldh=cl.cldh_S left join clzl c2 on c2.cldh=cl.cldh_M " +
                    "left join produce_method pm on pm.PM_ID=cl.PM_ID " +
                    "left join zszl z on z.zsdh=cl.zsdh " +
                    "where cl.cldh_M='{0}' " +
                    "order by cl.SN,cl.cldh_S"
                    , tbCLDH.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsDetailM, "子材料表");
                this.dgvCLZH.DataSource = this.dsDetailM.Tables[0];
                this.dgvCLZH.Columns[6].Visible = false; // 加工方式中文
                this.dgvCLZH.Columns[10].Visible = false; // PMID
                this.dgvCLZH.Columns[11].Visible = false; // 廠商編號
                this.dgvCLZH.CurrentCell = null;
                this.dgvCLZH.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Detail Query Error");
            }
        }

        #endregion

        #region 子材料頁面回寫材料主檔(新增模式按save時呼叫,刪除子材料呼叫)

        private void QueryMainFromDetail()
        {
            dsDetailM = new DataSet();
            DBconnect dbConn = new DBconnect();
            try
            {
                string sql = string.Format("select cldh,zwpm,ywpm from clzl where cldh='{0}'"
                    , tbCLDH.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(dsDetailM, "子材料返回主材料查詢表");
                tbCLDH.Text = dsDetailM.Tables[0].Rows[0][0].ToString();
                tbMainMaterialCN.Text = dsDetailM.Tables[0].Rows[0][1].ToString();
                tbMainMaterialEN.Text = dsDetailM.Tables[0].Rows[0][2].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Detail Back Main Data Query Error");
            }
        }

        #endregion

        #endregion
        
        #region 新增材料方法

        private void InsertMaterialInformation()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tcMaterialMain.SelectedIndex == 1) // 主檔
                {
                    GetClassBBigest(cbClassB.SelectedValue.ToString()); // 最大值
                    // 0暗碼 
                    // 1材料編號 2小分類 3圖片 4材料英文 5材料中文 
                    // 6組合材料 7單位編號 8檢驗文件(SGS) 9危險材料 10顏色編號 
                    // 11MOQ 12是否安全存量 13最大庫存 14最低庫存 15最大採購量 
                    // 16消耗材料 17停用 18最後交易日 
                    // 19使用者ID 20異動日 21GJLB 22CQDH 23LYCC
                    string sqlmain = string.Format("insert into clzl (clbm,cldh,cllb,CLTD,ywpm,zwpm,clzmlb,dwbh,PDYN,RiskColYN,ysbh,MOQ,IS_SAFE_STOCK,HIGH_STOCK,LOW_STOCK,HIGH_PURCH_QTY,xhcl,tyjh,TRANDATE,USERID,USERDATE,GJLB,CQDH,LYCC) " +
                        "values('{0}','{1}','{2}',null,'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}','{16}',null,'{17}','{18}','{19}',{20},'{21}')"
                        , cbClassB.SelectedValue.ToString().PadRight(4, 'z') + cbColor.SelectedValue.ToString() + lbEncryption.Text + tbCLDH.Text
                        , tbCLDH.Text, cbClassB.SelectedValue, tbMainMaterialEN.Text, tbMainMaterialCN.Text
                        , chkCombination.Checked ? "Y" : "N", cbUnit.SelectedValue, chkRSL.Checked ? "Y" : "N", chkRiskColYN.Checked ? "Y" : "N", cbColor.SelectedValue
                        , tbMOQM.Text == "" ? "0.000" : tbMOQM.Text, chkIsInStockM.Checked ? 1 : 0, tbHighStockM.Text == "" ? "0.000" : tbHighStockM.Text, tbLowStockM.Text == "" ? "0.000" : tbLowStockM.Text, tbHighPurchQTYM.Text == "" ? "0.000" : tbHighPurchQTYM.Text
                        , chkXHCL.Checked ? "Y" : "N", chkIsDisable.Checked ? "Y" : "N"
                        , USERID, DateTime.Today.ToString("yyyy-MM-dd"), cbGJLB.Text, cbCQDH.Text == "" ? "null" : "'" + cbCQDH.Text + "'", chkLYCC.Checked ? "Y" : "N");
                    SqlCommand cmd = new SqlCommand(sqlmain, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        InsertImage();
                        MessageBox.Show("Insert MaterialMainData Success!");
                        QueryCallMaterialData(tbCLDH.Text);
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 3) // RSL
                {
                    string sqlRSL = string.Format("insert into SGSLIST (cldh,zsdh,URL,Validity,USERID,Userdate) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}')"
                        , tbCLDH.Text, cbSupplierVendorR.SelectedValue, lbURL.Text, dtpExpiryDate.Value.ToString("yyyy-MM-dd")
                        , USERID, DateTime.Today.ToString("yyyy-MM-dd"));
                    SqlCommand cmd = new SqlCommand(sqlRSL, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Insert RSL File Success!");
                        QueryRSL();
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 4) // 子材料(僅更新主檔clzl中英文)
                {
                    string sqlDetail = string.Format("update clzl set ywpm='{0}',zwpm='{1}' " +
                        "where cldh='{2}'", tbCLZHMaterialEN.Text, tbCLZHMaterialCN.Text, tbCLDH.Text);
                    SqlCommand cmd = new SqlCommand(sqlDetail, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Insert Detail Material Success!");
                        QueryDetail();
                        isDetailBack = true;
                    }
                }
            }
            catch (Exception)
            {
                isDetailBack = false;
                MessageBox.Show("Insert Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbconn.CloseConnection();
            }
        }

        #endregion

        #region 編輯材料方法

        private void ModifyMaterialInformation()
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                if (tcMaterialMain.SelectedIndex == 1) // 主檔
                {
                    if (mcbindex != cbClassB.SelectedIndex) // 修改成別的類別時呼叫最大值
                    {
                        GetClassBBigest(cbClassB.SelectedValue.ToString());
                    }
                    // 0暗碼 
                    // 1材料編號 2小分類 3材料英文 4材料中文 
                    // 5組合材料 6單位編號 7檢驗文件(SGS) 8危險材料 9顏色編號 
                    // 10MOQ 11是否安全存量 12最大庫存 13最低庫存 14最大採購量 
                    // 15消耗材料 16停用 17使用者ID 18異動日 19LYCC
                    // 19原材料編號
                    string sql = string.Format("update clzl set clbm='{0}',cldh='{1}',cllb='{2}',ywpm='{3}',zwpm='{4}'" +
                        ",clzmlb='{5}',dwbh='{6}',PDYN='{7}',RiskColYN='{8}',ysbh='{9}',MOQ='{10}',IS_SAFE_STOCK={11},HIGH_STOCK='{12}',LOW_STOCK='{13}',HIGH_PURCH_QTY='{14}',xhcl='{15}',tyjh='{16}',USERID='{17}',USERDATE='{18}',GJLB='{19}',CQDH={20},LYCC='{21}' " +
                        "where cldh='{22}'"
                        , cbClassB.SelectedValue.ToString().PadRight(4, 'z') + cbColor.SelectedValue.ToString() + lbEncryption.Text + tbCLDH.Text
                        , tbCLDH.Text, cbClassB.SelectedValue, tbMainMaterialEN.Text, tbMainMaterialCN.Text
                        , chkCombination.Checked ? "Y" : "N", cbUnit.SelectedValue, chkRSL.Checked ? "Y" : "N", chkRiskColYN.Checked ? "Y" : "N", cbColor.SelectedValue
                        , tbMOQM.Text == "" ? "0.000" : tbMOQM.Text, chkIsInStockM.Checked ? 1 : 0, tbHighStockM.Text == "" ? "0.000" : tbHighStockM.Text, tbLowStockM.Text == "" ? "0.000" : tbLowStockM.Text, tbHighPurchQTYM.Text == "" ? "0.000" : tbHighPurchQTYM.Text
                        , chkXHCL.Checked ? "Y" : "N", chkIsDisable.Checked ? "Y" : "N", USERID, DateTime.Today.ToString("yyyy-MM-dd"), cbGJLB.Text, cbCQDH.Text == "" ? "null" : "'" + cbCQDH.Text + "'", chkLYCC.Checked ? "Y" : "N"
                        , mcldh);
                    SqlCommand cmd = new SqlCommand(sql, dbconn.connection);
                    dbconn.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        InsertImage();
                        MessageBox.Show("Modify MaterialMainData Success!");
                        QueryCallMaterialData(tbCLDH.Text);
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 3) // RSL
                {
                    if (dgvRSL.CurrentCell != null)
                    {
                        string sqlRSL = string.Format("update SGSLIST set zsdh='{0}',Validity='{1}',URL='{2}',USERID='{3}',Userdate='{4}' " +
                            "where cldh='{5}' and zsdh='{6}'"
                            , cbSupplierVendorR.SelectedValue, dtpExpiryDate.Value.ToString("yyyy-MM-dd"), lbURL.Text, USERID, DateTime.Today.ToString("yyyy-MM-dd")
                            , tbCLDH.Text, dgvRSL.CurrentRow.Cells[0].Value);
                        SqlCommand cmd = new SqlCommand(sqlRSL, dbconn.connection);
                        dbconn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Modify RSL File Success!");
                            QueryRSL();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select 1 Data To Update!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        #region 刪除材料方法

        private void DeleteMaterialInformation()
        {
            DBconnect dbConn = new DBconnect();
            try
            {
                if (tcMaterialMain.SelectedIndex == 1) // 主頁
                {
                    DialogResult dr = MessageBox.Show("Disable " + tbCLDH.Text + " this data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        DataSet dschk = new DataSet();
                        string sqlc = string.Format("select count(*) from clzl " +
                            "left join YPZLS on clzl.cldh=YPZLS.CLBH " +
                            "left join xxzls on clzl.cldh=xxzls.CLBH " +
                            "where clzl.cldh ='{0}' and YPZLS.YPDH is null and xxzls.XieXing is null", tbCLDH.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlc, dbConn.connection);
                        adapter.Fill(dschk, "是否存在表");
                        if (dschk.Tables[0].Rows[0][0].ToString() != "0")
                        {
                            string sql = string.Format("update clzl set tyjh='Y' where cldh='{0}'", tbCLDH.Text);
                            SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                            dbConn.OpenConnection();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                MessageBox.Show(tbCLDH.Text + " Has Been Disable!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                QueryCallMaterialData(tbCLDH.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Data Already Exists!", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 2) // 供應商
                {
                    DialogResult dr = MessageBox.Show("Delete " + dgvSupplierList.CurrentRow.Cells[1].Value + " this data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("delete from supplier_list where cldh='{0}' and zsdh='{1}' and kfdh='{2}'"
                            , tbCLDH.Text, dgvSupplierList.CurrentRow.Cells[0].Value.ToString(), dgvSupplierList.CurrentRow.Cells[2].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Supplyer Delete Success", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QuerySupplierList();
                        }
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 3) // RSL
                {
                    DialogResult dr = MessageBox.Show("Delete " + dgvRSL.CurrentRow.Cells[1].Value + " this data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("delete from SGSLIST where cldh='{0}' and zsdh='{1}'"
                            , tbCLDH.Text, dgvRSL.CurrentRow.Cells[0].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("RSL Delete Success", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsbCancel.PerformClick();
                            QueryRSL();
                        }
                    }
                }
                else if (tcMaterialMain.SelectedIndex == 4) // 子材料
                {
                    DialogResult dr = MessageBox.Show("Delete Detail Material : " + dgvCLZH.CurrentRow.Cells[0].Value + ", PM_ID : " + dgvCLZH.CurrentRow.Cells[10].Value + " this data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        string sql = string.Format("delete from clzhzl where cldh_M='{0}' and cldh_S='{1}' and SN='{2}' and PM_ID='{3}'"
                            , tbCLDH.Text, dgvCLZH.CurrentRow.Cells[0].Value.ToString(), dgvCLZH.CurrentRow.Cells[7].Value.ToString(), dgvCLZH.CurrentRow.Cells[10].Value.ToString());
                        SqlCommand cmd = new SqlCommand(sql, dbConn.connection);
                        dbConn.OpenConnection();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("Detail Material Delete Success", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReorganizationStringM();
                            string sqlDetail = string.Format("update clzl set ywpm='{0}',zwpm='{1}' " +
                                "where cldh='{2}'", tbCLZHMaterialEN.Text, tbCLZHMaterialCN.Text, tbCLDH.Text);
                            SqlCommand cmdup = new SqlCommand(sqlDetail, dbConn.connection);
                            dbConn.OpenConnection();
                            cmdup.ExecuteNonQuery();
                            QueryMainFromDetail(); // 回寫主檔資料
                        }
                    }
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

        #endregion

        // 載入url需修改
        #region 圖片處裡方法

        #region 輸入圖片方法(新增主檔完呼叫)

        private void InsertImage()
        {
            DBconnect conn = new DBconnect();
            try
            {
                string picname = Path.GetFileName(pcPic.ImageLocation);
                string strSql = string.Format("update clzl set CLTD='{0}' " +
                    "where cldh='{1}'"
                    , picname, tbCLDH.Text);
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(strSql, conn.connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Picture Error!");
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        #endregion

        // 需修改
        // picturebox.load(url)
        #region 載入圖片方法(速查頁DGV觸發)

        private void LoadImage(string cldh)
        {
            DBconnect dbconn = new DBconnect();
            try
            {
                string strSql = string.Format("select CLTD from clzl where cldh='{0}'", cldh);
                SqlCommand cmd = new SqlCommand(strSql, dbconn.connection);
                dbconn.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && !(reader["CLTD"] is DBNull))
                {
                    MemoryStream ms = new MemoryStream((byte[])reader["CLTD"]);
                    Image image = Image.FromStream(ms, true);
                    pcPic.Image = image;
                    ms.Close();
                }
                else
                {
                    pcPic.Image = null;
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("載入圖片錯誤");
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
