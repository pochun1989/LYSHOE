﻿using System;
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
    public partial class DestinationQuery : Form
    {
        public DestinationQuery()
        {
            InitializeComponent();
        }

        public DataSet ds = new DataSet();


        //語言變數
        public DataSet dsL = new DataSet();
        public string languageType;
        public string userLanguage;
        string userForm = "DestinationQuery";

        private void button1_Click(object sender, EventArgs e)
        {
            QueryData();
            this.Close();
        }

        private void QueryData()
        {
            try
            {

                if (tb代號.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from DESTINATION where DESTINATION_ID like '{0}%'", tb代號.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else if (tb中文.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from DESTINATION where zwsm like '{0}%'", tb中文.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else if (tb英文.Text != "")
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from DESTINATION where ywsm like '{0}%'", tb英文.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);
                }
                else
                {
                    ds = new DataSet();
                    DBconnect dbConn = new DBconnect();
                    string sql = string.Format("select * from DESTINATION");
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, dbConn.connection);
                    adapter.Fill(ds, "棧板表");
                    Console.WriteLine(sql);

                }

            }
            catch (Exception) { }
        }

        private void tb英文_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb中文_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb代號_TextChanged(object sender, EventArgs e)
        {

        }

        private void L0003_Click(object sender, EventArgs e)
        {

        }

        private void L0002_Click(object sender, EventArgs e)
        {

        }

        private void L0001_Click(object sender, EventArgs e)
        {

        }

        private void DestinationQuery_Load(object sender, EventArgs e)
        {
            //獲取語言
            userLanguage = Program.LanguageType.userLanguage;

            ChangeLabel();

        }

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
                

            }
            catch (Exception) { }
        }

        #endregion

        #region 頁籤訂位

        private void LoadPage()
        {
            try
            {

            }
            catch (Exception) { }
        }

        #endregion

        #endregion
    }
}
