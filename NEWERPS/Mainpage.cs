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
    public partial class Mainpage : Form
    {
        #region 變數
        
        int i = 0;
        bool b = false;

        //語言變數
        public DataSet dsl = new DataSet();
        public string userLanguage;
        public string modifySL = "0";
        string userForm = "Main";

        #endregion

        #region 構造函式

        public Mainpage()
        {
            InitializeComponent();

            int W = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int H = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            this.Width = W;
            this.Height = H;
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void Mainpage_Load(object sender, EventArgs e)
        {
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;
            cbLanguage.SelectedIndex = 0;
            ChangeTree();

            splitContainer1.Height = pDown.Height;
            splitContainer1.Width = pDown.Width;
        }

        #endregion

        #region 頁面關閉

        // 按鈕
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 整體關閉
        private void Mainpage_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0); // 強制關閉
        }

        #endregion

        #region 多國語言下拉選單改變事件

        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.LanguageType.userLanguage = cbLanguage.SelectedIndex.ToString();
            userLanguage = Program.LanguageType.userLanguage;
            ChangeTree();
            panel1.Controls.Clear(); // 清空工作表介面
        }

        #endregion

        #region 菜單開關按鈕事件
        private void BtnMunuSwitch_Click(object sender, EventArgs e)
        {
            i = i ^ 1; //做 xor 運算 ，按一下 True ，再按一下 False......... 
            b = Convert.ToBoolean(i);
            if (b)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
            }
        }
        #endregion

        #region Menu選項更換(在工作表呼叫新的form)

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            modifySL = Program.Modifytype.modify;
            Console.WriteLine(modifySL);
            if (modifySL == "0")
            {
                string tvMenuSelect = e.Node.Name;
                switch (tvMenuSelect)
                {
                    case "010000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "010100":
                        ERPCompanyData();
                        break;
                    case "010200":
                        ERPFactoryArea();
                        break;
                    case "010300":
                        ERPVendor();
                        break;
                    case "010400":
                        ERPColor();
                        break;
                    case "010500":
                        //ERPProClass();
                        break;
                    case "010600":
                        ERPUnit();
                        break;
                    case "010700":
                        ERPProduce();
                        break;
                    case "010800":
                        CustData();
                        break;
                    case "010900":
                        CountryLoad();
                        break;
                    case "011000":
                        DestinationLoad();
                        break;
                    case "011100":
                        CURRENCYLOAD();
                        break;
                    case "011200":
                        TRADELOAD();
                        break;
                    case "011300":
                        PAYEMNTLOAD();
                        break;
                    case "011400":
                        DistributorsLOAD();
                        break;
                    case "011500":

                        break;
                    case "011600":
                        CAUSELOAD();
                        break;
                    case "011700":

                        break;
                    case "011800":

                        break;
                    case "011801":
                        ERPLanguage();
                        break;
                    case "011802":
                        ERPWordChange();
                        break;
                    case "020000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "020100":
                        ERPMaterialPro();
                        break;
                    case "020200":
                        ERPMaterialPro2();
                        break;
                    case "020300":
                        MI();
                        break;
                    case "030000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "030100":
                        SizeBlock();
                        break;
                    case "030200":
                        SizeCountry();
                        break;
                    case "030300":
                        SiChart();
                        break;
                    case "030400":
                        ShoeApp();
                        break;
                    case "030500":
                        DepSec();
                        break;
                    case "030600":
                        DevClass();
                        break;
                    case "030700":
                        MoldClassSet();
                        break;
                    case "030800":
                        MoldSet();
                        break;
                    case "030900":
                        DevelopModel();
                        break;
                    case "031000":
                        PartSet();
                        break;
                    case "031100":
                        CardData();
                        break;
                    case "040000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "040100":
                        TempMa();
                        break;
                    case "040200":
                        OfficalM();
                        break;
                    case "050000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "050100":
                        SOC1();
                        break;
                    case "050200":
                        MSO1();
                        break;
                    case "050300":
                        QO1();
                        break;
                    case "050401":
                        Sample();
                        break;
                    case "050402":
                        SamConfirm();
                        break;
                    case "060000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "060100":
                        Cfxlload();
                        break;
                    case "060200":
                        BomLoad();
                        break;
                    case "060300":
                        BomDetail();
                        break;
                    case "070000":
                        tvMain.SelectedNode.ExpandAll();
                        break;
                    case "070100":
                        Order1();
                        break;
                    case "070200":
                        Advance();
                        break;
                    case "070300":
                        Batch();
                        break;
                    case "070400":
                        GDosage();
                        break;
                    case "070500":
                        SDosage();
                        break;
                    case "070600":
                        SDosage2();
                        break;
                    case "080100":
                        OSep();
                        break;
                    case "080200":
                        OChange();
                        break;
                    case "080300":
                        OrderDetail();
                        break;
                    case "080400":
                        OrderVER();
                        break;
                }
            }
            else
            {
                MessageBox.Show("PLZ SAVE OR CANCEL FIRST");
            }
        } 

        #endregion

        #endregion

        #region 方法

        #region 子視窗顯示方法

        #region 公司基本資料

        private void ERPCompanyData()
        {                                        
            CBI al = new CBI();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            //al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 廠區

        private void ERPFactoryArea()
        {                                       
            FactoryData2 al = new FactoryData2();
            al.MdiParent = this; // 指定父視窗
            al.TopMost = true;
            al.Parent = this.panel1; // 存放位置
            al.Show(); // 視窗顯示
        }

        #endregion

        #region 廠商

        private void ERPVendor()
        {                                        
            VendorData al = new VendorData();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 顏色

        private void ERPColor()
        {                                        
            CI al = new CI();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 材料類別

        private void ERPProClass()
        {                                        
            MaterialCS al = new MaterialCS();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 單位維護

        private void ERPUnit()
        {                                         
            UI al = new UI();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 加工維護

        private void ERPProduce()
        {                                      
            PM al = new PM();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 特性

        private void ERPMaterialPro()
        {                                        
            MaterialProperty2 al = new MaterialProperty2();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 特性2

        private void ERPMaterialPro2()
        {                                       
            Property al = new Property();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 材料主檔

        private void MI()
        {                                        
            MMI al = new MMI();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 尺寸區間

        private void SizeBlock()
        {                                         
            SizeBlockStandard al = new SizeBlockStandard();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 尺寸國別

        private void SizeCountry()
        {                                       
            SizeCountry al = new SizeCountry();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 鞋型用途

        private void ShoeApp()
        {                                       
            ShoeApplication al = new ShoeApplication();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 鞋型用途

        private void SiChart()
        {                                         
            SizeChart al = new SizeChart();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 開發階段

        private void DepSec()
        {                                       
            DevelopSection al = new DevelopSection();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 新語言

        private void ERPLanguage()
        {                                         
            LanguageNew al = new LanguageNew();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 語言改

        private void ERPWordChange()
        {                                        
            LanguageModify al = new LanguageModify();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 採購確認

        private void SamConfirm()
        {                                         
            SampleConfirm al = new SampleConfirm();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 客戶資料

        private void CustData()
        {                                       
            CustomerData al = new CustomerData();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 樣品合併單

        private void Sample()
        {                                         
            SamplePurchase2 al = new SamplePurchase2();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #region 紙板資料

        private void CardData()
        {
            CardboardData al = new CardboardData();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 紙板資料

        private void TempMa()
        {
            TempMaterial al = new TempMaterial();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 正式料號

        private void OfficalM()
        {
            OfficialMaterial al = new OfficialMaterial();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #endregion

        #region 開發類型

        private void DevClass()
        {                                     
            DC al = new DC();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 工制具類別設定

        private void MoldClassSet()
        {                                       
            MoldCS al = new MoldCS();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 工制具設定

        private void MoldSet()
        {                                        
            MS al = new MS();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 開發形體設定

        private void DevelopModel()
        {                                        
            DM al = new DM();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 部位設定

        private void PartSet()
        {                                       
            PS al = new PS();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 國別設定

        private void CountryLoad()
        {                                       
            Country al = new Country();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 目的地設定

        private void DestinationLoad()
        {                                       
            Destination al = new Destination();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 幣別設定

        private void CURRENCYLOAD()
        {                                        
            Currency al = new Currency();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 交易條件設定

        private void TRADELOAD()
        {                                      
            TradeTerm al = new TradeTerm();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 付款條件設定

        private void PAYEMNTLOAD()
        {                                       
            PaymentTerm al = new PaymentTerm();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 通路商設定

        private void DistributorsLOAD()
        {                                       
            Distributors al = new Distributors();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 請付款理由設定

        private void CAUSELOAD()
        {                                       
            CAUSE al = new CAUSE();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 形體基本資料

        private void Cfxlload()
        {                                       
            CFXTZL al = new CFXTZL();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 形體基本資料

        private void BomLoad()
        {                                       
            BomMaintain al = new BomMaintain();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 樣品單建立

        private void SOC1()
        {                                         
            SOC al = new SOC();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 採購併單

        private void MSO1()
        {                                      
            MSO al = new MSO();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 報價單

        private void QO1()
        {                                     
            QO al = new QO();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 訂單建立

        private void Order1()
        {                                       
            OrderMain al = new OrderMain();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 預告訂單轉正式訂單

        private void Advance()
        {                                      
            AdvanceOrder al = new AdvanceOrder();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 批次計算用量表

        private void Batch()
        {
            BatchCalculation al = new BatchCalculation();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 膠藥水車線用量表

        private void GDosage()
        {
            GlueDosage al = new GlueDosage();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 特殊材料重算

        private void SDosage()
        {
            SpecialDosage al = new SpecialDosage();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 特殊材料重算

        private void SDosage2()
        {
            SpecialGlue al = new SpecialGlue();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 訂單分單

        private void OSep()
        {
            OrderSep al = new OrderSep();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 訂單變更

        private void OChange()
        {
            OrdChange al = new OrdChange();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region BOM變更對造

        private void BomDetail()
        {
            BomCheck al = new BomCheck();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 訂單變更

        private void OrderDetail()
        {
            OrderDiff al = new OrderDiff();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 訂單版本

        private void OrderVER()
        {
            OrderVer al = new OrderVer();
            al.MdiParent = this; // 指定父視窗
            al.Parent = this.panel1; // 存放位置
            al.TopMost = true;
            al.Show(); // 視窗顯示
            al.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #endregion

        #region 樹狀文字方法

        private void ChangeTree()
        {
            //dt.Rows[0]["Pallet_NO"].ToString().Trim();
            int i;
            i = int.Parse(userLanguage) + 1;

            dsl = new DataSet();
            DBconnect dbConn = new DBconnect();
            string sql = string.Format("select * from MMDATA where FORM_ID = '{0}' and MM_ID = '{1}' and LAB_ID like 'T%'", userForm, i);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
            adapter.Fill(dsl, "棧板表");
            this.dgvWord.DataSource = this.dsl.Tables[0];

            WordPosition();
        }

        #endregion

        #region 文字定位

        private void WordPosition()
        {
            try
            {
                // 管理資訊
                tvMain.Nodes[0].Text = dgvWord.Rows[0].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[0].Text = dgvWord.Rows[1].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[1].Text = dgvWord.Rows[2].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[2].Text = dgvWord.Rows[3].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[3].Text = dgvWord.Rows[4].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[4].Text = dgvWord.Rows[5].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[5].Text = dgvWord.Rows[6].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[6].Text = dgvWord.Rows[7].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[7].Text = dgvWord.Rows[8].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[8].Text = dgvWord.Rows[9].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[9].Text = dgvWord.Rows[10].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[10].Text = dgvWord.Rows[11].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[11].Text = dgvWord.Rows[12].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[12].Text = dgvWord.Rows[13].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[13].Text = dgvWord.Rows[14].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[14].Text = dgvWord.Rows[15].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[15].Text = dgvWord.Rows[16].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[16].Text = dgvWord.Rows[17].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[17].Text = dgvWord.Rows[18].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[17].Nodes[0].Text = dgvWord.Rows[19].Cells[3].Value.ToString();
                tvMain.Nodes[0].Nodes[17].Nodes[1].Text = dgvWord.Rows[20].Cells[3].Value.ToString();

                // 材料特性
                tvMain.Nodes[1].Text = dgvWord.Rows[21].Cells[3].Value.ToString();
                tvMain.Nodes[1].Nodes[0].Text = dgvWord.Rows[22].Cells[3].Value.ToString();
                tvMain.Nodes[1].Nodes[1].Text = dgvWord.Rows[23].Cells[3].Value.ToString();
                tvMain.Nodes[1].Nodes[2].Text = dgvWord.Rows[24].Cells[3].Value.ToString();

                // 型體資訊
                tvMain.Nodes[2].Text = dgvWord.Rows[25].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[0].Text = dgvWord.Rows[26].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[1].Text = dgvWord.Rows[27].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[2].Text = dgvWord.Rows[28].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[3].Text = dgvWord.Rows[29].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[4].Text = dgvWord.Rows[30].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[5].Text = dgvWord.Rows[31].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[6].Text = dgvWord.Rows[32].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[7].Text = dgvWord.Rows[33].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[8].Text = dgvWord.Rows[34].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[9].Text = dgvWord.Rows[35].Cells[3].Value.ToString();
                tvMain.Nodes[2].Nodes[10].Text = dgvWord.Rows[36].Cells[3].Value.ToString();

                // 開發
                tvMain.Nodes[3].Text = dgvWord.Rows[37].Cells[3].Value.ToString();
                tvMain.Nodes[3].Nodes[0].Text = dgvWord.Rows[38].Cells[3].Value.ToString();
                tvMain.Nodes[3].Nodes[1].Text = dgvWord.Rows[39].Cells[3].Value.ToString();

                // 樣品單物料採購
                tvMain.Nodes[4].Text = dgvWord.Rows[40].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[0].Text = dgvWord.Rows[41].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[1].Text = dgvWord.Rows[42].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[2].Text = dgvWord.Rows[43].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[3].Text = dgvWord.Rows[44].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[3].Nodes[0].Text = dgvWord.Rows[45].Cells[3].Value.ToString();
                tvMain.Nodes[4].Nodes[3].Nodes[1].Text = dgvWord.Rows[46].Cells[3].Value.ToString();

                // 量產BOM轉入
                tvMain.Nodes[5].Text = dgvWord.Rows[47].Cells[3].Value.ToString();
                tvMain.Nodes[5].Nodes[0].Text = dgvWord.Rows[48].Cells[3].Value.ToString();
                tvMain.Nodes[5].Nodes[1].Text = dgvWord.Rows[49].Cells[3].Value.ToString();

                // 訂單接單作業
                tvMain.Nodes[6].Text = dgvWord.Rows[50].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[0].Text = dgvWord.Rows[51].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[1].Text = dgvWord.Rows[52].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[2].Text = dgvWord.Rows[53].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[3].Text = dgvWord.Rows[54].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[4].Text = dgvWord.Rows[55].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[5].Text = dgvWord.Rows[56].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[6].Text = dgvWord.Rows[57].Cells[3].Value.ToString();
                tvMain.Nodes[6].Nodes[7].Text = dgvWord.Rows[58].Cells[3].Value.ToString();

                // 訂單變更作業
                tvMain.Nodes[7].Text = dgvWord.Rows[59].Cells[3].Value.ToString();
                tvMain.Nodes[7].Nodes[0].Text = dgvWord.Rows[60].Cells[3].Value.ToString();
                tvMain.Nodes[7].Nodes[1].Text = dgvWord.Rows[61].Cells[3].Value.ToString();
                tvMain.Nodes[7].Nodes[2].Text = dgvWord.Rows[62].Cells[3].Value.ToString();

                // 請付款作業
                tvMain.Nodes[8].Text = dgvWord.Rows[63].Cells[3].Value.ToString();
                tvMain.Nodes[8].Nodes[0].Text = dgvWord.Rows[64].Cells[3].Value.ToString();
                tvMain.Nodes[8].Nodes[1].Text = dgvWord.Rows[65].Cells[3].Value.ToString();
                tvMain.Nodes[8].Nodes[2].Text = dgvWord.Rows[66].Cells[3].Value.ToString();

            }
            catch (Exception) { }
        }

        #endregion

        #endregion        
    }
}
