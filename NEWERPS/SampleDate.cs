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
    public partial class SampleDate : Form
    {
        public SampleDate()
        {
            InitializeComponent();
        }
        public string sampledate;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sampledate = dateTimePicker1.Text;
                //sampledate = dateTimePicker1.Value.ToString();

                Console.WriteLine(sampledate);
                this.Close();
            }
            catch (Exception) { }
        }

        private void SampleDate_Load(object sender, EventArgs e)
        {

        }
    }
}
