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
    public partial class GlueDosage : Form
    {
        public GlueDosage()
        {
            InitializeComponent();
        }

        private void GlueDosage_Load(object sender, EventArgs e)
        {
            userid = Program.User.userID;
        }

        public string userid = "";
        DataSet ds = new DataSet();

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    if (tb01.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieXing like '{0}%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao", tb01.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb02.Text != "") 
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieMing like '{0}%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao", tb02.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb03.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.SheHao like '{0}%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao", tb03.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb04.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.ARTICLE like '{0}%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao", tb04.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb05.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.KHDH like '{0}%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao", tb05.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM,    XXZLSVN.VNBOM, XXZL.BZCC, (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing = XXBWFL.XieXing and XXBWFL.BWBH = XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieXing like '%'       and XXZL.SheHao like '%' and XXZL.ARTICLE like '%' and XXZL.XieMing like '%' and XXZL.KHDH like '%' and XXZL.YN = '1'order by XXZL.XieXing,XXZL.Shehao");
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else 
                {
                    if (tb01.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieXing like '{0}%' order by XXZL.XieXing,XXZL.Shehao", tb01.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb02.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieMing like '{0}%' order by XXZL.XieXing,XXZL.Shehao", tb02.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb03.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.SheHao like '{0}%' order by XXZL.XieXing,XXZL.Shehao", tb03.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb04.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.ARTICLE like '{0}%' order by XXZL.XieXing,XXZL.Shehao", tb04.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (tb05.Text != "")
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM, XXZLSVN.VNBOM,XXZL.BZCC,  (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing=XXBWFL.XieXing and XXBWFL.BWBH=XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.KHDH like '{0}%' order by XXZL.XieXing,XXZL.Shehao", tb05.Text);
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else 
                    {
                        ds = new DataSet();
                        DBconnect dbConn = new DBconnect();
                        string sql = string.Format("select XXZL.XieXing,XXZL.SheHao,XXZL.Article,XXZL.XieMing,XXZL.KHDH,XXZL.YSSM,    XXZLSVN.VNBOM, XXZL.BZCC, (select top 1 XXBWFL.XieXing  from XXZLS left join XXBWFL on XXZLS.XieXing = XXBWFL.XieXing and XXBWFL.BWBH = XXZLS.BWBH where XXZLS.XieXing = XXZL.XieXing and XXZLS.SheHao = XXZl.SheHao) as VNFL from XXZL left join (select distinct XieXing,SheHao,XieXing as VNBOM from XXZLSVN) XXZLSVN on XXZLSVN.XieXing = XXZL.XieXing and XXZLSVN.SheHao = XXZL.SheHao where XXZL.XieXing like '%'       and XXZL.SheHao like '%' and XXZL.ARTICLE like '%' and XXZL.XieMing like '%' and XXZL.KHDH like '%'  order by XXZL.XieXing,XXZL.Shehao");
                        Console.WriteLine(sql);
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                        adapter.Fill(ds, "棧板表");
                        dataGridView1.DataSource = ds.Tables[0];
                    }

                }
            }
            catch 
            (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MMI Form = new MMI();
            Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PS Form = new PS();
            Form.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tsbQuery.Enabled = true;
                    tsbDelete.Enabled = false;
                    tsbInsert.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;                    
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    tsbQuery.Enabled = false;
                    tsbDelete.Enabled = true;
                    tsbInsert.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbCancel.Enabled = false;

                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select  XXZLSVN.*, BWZL.YWSM, ZSZL.ZSYWJC, CLZL.YWPM, CLZL.DWBH, XXBWFLS.DFL,   XXBWFLS.XFL from XXZLSVN left join BWZL on BWZL.BWDH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.BWBH collate Chinese_Taiwan_Stroke_CI_AS left join ZSZL on ZSZL.ZSDH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.CSBH collate Chinese_Taiwan_Stroke_CI_AS left join CLZL on XXZLSVN.CLBH collate Chinese_Taiwan_Stroke_CI_AS = CLZL.CLDH collate Chinese_Taiwan_Stroke_CI_AS left join XXBWFLS on XXBWFLS.FLBH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.FLBH collate Chinese_Taiwan_Stroke_CI_AS where  XXZLSVN.XieXing = '{0}' and XXZLSVN.SheHao = '{1}' and XXZLSVN.YN = 1 order by userdate DESC", label10.Text, label13.Text);
                    Console.WriteLine(sql);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            catch (Exception) { }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("確定要刪除?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    DBconnect con4 = new DBconnect();
                    StringBuilder sql4 = new StringBuilder();
                    sql4.AppendFormat("update XXZLSVN set YN = 0  where XieXing='{0}' and SheHao='{1}' and BWBH = '{2}' and CLBH = '{3}'", label10.Text, label13.Text, dataGridView2.CurrentRow.Cells[2].Value.ToString(), dataGridView2.CurrentRow.Cells[3].Value.ToString());

                    Console.WriteLine(sql4);
                    SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);
                    con4.OpenConnection();
                    int result4 = cmd4.ExecuteNonQuery();
                    if (result4 == 1)
                    {

                    }
                    con4.CloseConnection();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception) { }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                GlueInsert Form = new GlueInsert();
                Form.label10.Text = label10.Text;
                Form.label13.Text = label13.Text;
                Form.ShowDialog();

                ds = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select  XXZLSVN.*, BWZL.YWSM, ZSZL.ZSYWJC, CLZL.YWPM, CLZL.DWBH, XXBWFLS.DFL,   XXBWFLS.XFL from XXZLSVN left join BWZL on BWZL.BWDH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.BWBH collate Chinese_Taiwan_Stroke_CI_AS left join ZSZL on ZSZL.ZSDH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.CSBH collate Chinese_Taiwan_Stroke_CI_AS left join CLZL on XXZLSVN.CLBH collate Chinese_Taiwan_Stroke_CI_AS = CLZL.CLDH collate Chinese_Taiwan_Stroke_CI_AS left join XXBWFLS on XXBWFLS.FLBH collate Chinese_Taiwan_Stroke_CI_AS = XXZLSVN.FLBH collate Chinese_Taiwan_Stroke_CI_AS where  XXZLSVN.XieXing = '{0}' and XXZLSVN.SheHao = '{1}' and XXZLSVN.YN = 1 order by userdate DESC", label10.Text, label13.Text);
                Console.WriteLine(sql);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds, "棧板表");
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception) { }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                label13.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                label11.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                label12.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception) { }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }
    }
}
