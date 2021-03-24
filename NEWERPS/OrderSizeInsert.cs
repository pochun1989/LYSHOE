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
    public partial class OrderSizeInsert : Form
    {
        public OrderSizeInsert()
        {
            InitializeComponent();
        }

        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "OrderSizeInsert";
        public string userid = "";

        private void OrderSizeInsert_Load(object sender, EventArgs e)
        {
            try
            {
                userid = Program.User.userID;

                int maxLine = 0;
                string Line = "";

                DBconnect dbConn1 = new DBconnect();
                string sql1 = string.Format("select isnull(MAX(LineNum),0) as MAX from ddzls where DDBH = '{0}'", tbDDBH.Text);
                Console.WriteLine(sql1);
                SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
                dbConn1.OpenConnection();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    maxLine = int.Parse(reader1["MAX"].ToString());
                }
                dbConn1.CloseConnection();

                maxLine += 1;

                Line = maxLine.ToString();
                if (Line.Length == 1) 
                {
                    Line = "0" + Line;
                }

                tbLineNum.Text = Line;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region NEWERP

                int result;
                DBconnect conn = new DBconnect();
                string sql1 = string.Format("insert DDZLs (DDBH,LineNum,CC,Quantity,IPrice,USERID,USERDATE,Quantity1,YN,Quantity2)values('{0}', '{1}', '{2}', '{3}', '{6}', '{4}', GETDATE(), '{5}', '1', '0')", tbDDBH.Text, tbLineNum.Text, tbCC.Text , tbQuantity.Text, userid, tbSample.Text, tbPrice.Text);

                Console.WriteLine(sql1);

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
                string sql1Y = string.Format("delete DDZLs where DDBH = '{0}' insert into ddzls SELECT[DDBH],[LineNum],[CC],[Quantity],[Price],[CPrice],[IPrice],[USERID], CAST(year(USERDATE) as NVARCHAR) +RIGHT(REPLICATE('0', 2) + CAST(month(USERDATE) as NVARCHAR), 2) +RIGHT(REPLICATE('0', 2) + CAST(day(USERDATE) as NVARCHAR), 2) ,[Quantity1],[mtdj],[Quantity2],[TestQty] FROM [192.168.11.15].New_Erp.dbo.[DDZLs] where DDBH = '{0}'", tbDDBH.Text);

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


                this.Close();
            }
            catch (Exception) { }
        }
    }
}
