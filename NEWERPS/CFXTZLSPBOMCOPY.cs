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
    public partial class CFXTZLSPBOMCOPY : Form
    {
        public CFXTZLSPBOMCOPY()
        {
            InitializeComponent();
        }

        #region 變數

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet dsArticle = new DataSet();
        public string userid;

        #endregion

        #region 畫面載入

        private void CFXTZLSPBOMCOPY_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                ds = new DataSet();
                DBconnect dbconn3 = new DBconnect();
                string sql3 = "select * from DESTINATION";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, dbconn3.connection);
                adapter3.Fill(ds, "倉庫位置");

                this.comboBox3.DataSource = ds.Tables[0];
                this.comboBox3.ValueMember = "DESTINATION_ID";
                this.comboBox3.DisplayMember = "ywsm";

                comboBox3.MaxDropDownItems = 8;
                comboBox3.IntegralHeight = false;

                ds1 = new DataSet();
                DBconnect dbconn1 = new DBconnect();
                string sql1 = "select * from DESTINATION";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, dbconn1.connection);
                adapter1.Fill(ds1, "倉庫位置");

                this.comboBox4.DataSource = ds1.Tables[0];
                this.comboBox4.ValueMember = "DESTINATION_ID";
                this.comboBox4.DisplayMember = "ywsm";

                comboBox4.MaxDropDownItems = 8;
                comboBox4.IntegralHeight = false;

            }
            catch (Exception) { }
        }

        #endregion

        #region 事件

        private void L0005_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dr = MessageBox.Show("Replace? 確定要取代?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    if (checkBox1.Checked == false)
                    {
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}'", textBox3.Text, textBox4.Text, comboBox4.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();


                        int result;
                        DBconnect conn = new DBconnect();
                        string sql1 = string.Format("insert into xxzlss select '{0}', '{1}', '{2}', BWBH, CLBH,CSBH, LOSS, CLSL, '{3}', GETDATE() as USERDATE, YN from xxzlss where XieXing = '{4}' and SheHao = '{5}' and cond = '{6}'", textBox3.Text, textBox4.Text, comboBox4.SelectedValue.ToString().Trim(), userid, textBox1.Text, textBox2.Text, comboBox3.SelectedValue.ToString());
                        Console.WriteLine(sql1);

                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {

                        }
                        conn.CloseConnection();

                        #region LYSHOE

                        int resultY;
                        DBconnect2 connY = new DBconnect2();
                        string sql1Y = string.Format("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' insert into xxzlss(XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}' )", textBox1.Text, textBox2.Text, comboBox4.SelectedValue, comboBox3.SelectedValue.ToString());
                        Console.WriteLine(sql1Y);

                        SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                        connY.OpenConnection();
                        resultY = cmd1Y.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                        }
                        connY.CloseConnection();

                        #endregion

                        MessageBox.Show("Insert Success 新增資料完成");
                    }
                    else 
                    {
                        DBconnect con4 = new DBconnect();
                        StringBuilder sql4 = new StringBuilder();
                        sql4.AppendFormat("delete xxzlss where XieXing = '{0}' and SheHao = '{1}'", textBox3.Text, textBox4.Text, comboBox4.Text);
                        Console.WriteLine(sql4);
                        SqlCommand cmd4 = new SqlCommand(sql4.ToString(), con4.connection);

                        con4.OpenConnection();
                        int result4 = cmd4.ExecuteNonQuery();
                        if (result4 == 1)
                        {
                            //MessageBox.Show("刪除資料成功!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        con4.CloseConnection();


                        int result;
                        DBconnect conn = new DBconnect();
                        string sql1 = string.Format("insert into xxzlss select '{0}', '{1}', cond, BWBH, CLBH,CSBH, LOSS, CLSL, '{3}', GETDATE() as USERDATE, YN from xxzlss where XieXing = '{4}' and SheHao = '{5}'", textBox3.Text, textBox4.Text, comboBox4.SelectedValue.ToString().Trim(), userid, textBox1.Text, textBox2.Text, comboBox3.SelectedValue.ToString().Trim());
                        Console.WriteLine(sql1);

                        SqlCommand cmd1 = new SqlCommand(sql1, conn.connection);
                        conn.OpenConnection();
                        result = cmd1.ExecuteNonQuery();
                        if (result == 1)
                        {

                        }
                        conn.CloseConnection();

                        #region LYSHOE

                        int resultY;
                        DBconnect2 connY = new DBconnect2();
                        string sql1Y = string.Format("delete xxzlss where XieXing = '{0}' and SheHao = '{1}' insert into xxzlss(XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, USERDATE) (select XieXing, SheHao, cond, BWBH, CLBH, CSBH, LOSS, CLSL, USERID, CONVERT(varchar,USERDATE,11) from [192.168.11.15].New_Erp.dbo.xxzlss where XieXing = '{0}' and SheHao = '{1}')", textBox1.Text, textBox2.Text, comboBox4.SelectedValue);
                        Console.WriteLine(sql1Y);

                        SqlCommand cmd1Y = new SqlCommand(sql1Y, connY.connection);
                        connY.OpenConnection();
                        resultY = cmd1Y.ExecuteNonQuery();
                        if (resultY == 1)
                        {
                        }
                        connY.CloseConnection();

                        #endregion

                        MessageBox.Show("Insert Success 新增資料完成");
                    }

                    this.Close();
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Copy Fail 複製失敗!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds2 = new DataSet();
                DBconnect dbConn = new DBconnect();
                string sql = string.Format("select * from xxzlss where XieXing = '{0}' and SheHao = '{1}' and cond = '{2}'", textBox1.Text, textBox2.Text, comboBox3.SelectedValue);
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                adapter.Fill(ds2, "棧板表");
                this.dataGridView1.DataSource = this.ds2.Tables[0];
            }
            catch (Exception) { }
        }

        #endregion

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CFXTZLSPArticle Form = new CFXTZLSPArticle();
                Form.ShowDialog();
                textBox1.Text = Form.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = Form.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox3.Visible = false;
                comboBox4.Visible = false;
            }
            else 
            {
                comboBox3.Visible = true;
                comboBox4.Visible = true;
            }
        }
    }
}
