using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEWERPS
{
    /// <summary>
    /// DevelopModelCopy 開發型體複製
    /// </summary>
    public partial class DMC : Form
    {
        #region 變數

        public string oldshoemodel, oldcolor;
        public string 新鞋型, 新色號;
        public bool isCopy;

        #endregion

        #region 構造函式

        public DMC()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        #region 頁面載入

        private void DevelopModelCopy_Load(object sender, EventArgs e)
        {
            tbOldModel.Text = oldshoemodel;
            tbOldColor.Text = oldcolor;
        }

        #endregion

        #region 拷貝按鈕事件

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (tbShoeModelNo.Text.Trim().Length == 0 && tbColorNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("ShoeModel & ColorNum is null!", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                新鞋型 = this.tbShoeModelNo.Text;
                新色號 = this.tbColorNo.Text;
                isCopy = true;
                this.Close();
            }
        }

        #endregion

        #region 取消頁面按鈕事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCopy = false;
            this.Close();
        }  

        #endregion

        #endregion
    }
}
