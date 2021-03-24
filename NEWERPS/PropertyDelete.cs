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
    public partial class PropertyDelete : Form
    {
        public PropertyDelete()
        {
            InitializeComponent();
        }

        public string pass;

        private void PropertyDelete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pass = textBox1.Text;
            this.Close();
        }
    }
}
