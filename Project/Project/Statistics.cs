using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            fillChart();
        }

        void fillChart()
        {
            chart1.Series["Lecturer Rooms"].Points.AddXY("Locatons", "6");
            chart1.Series["Laboratories"].Points.AddXY("Locatons", "8");

            //chart title  
            chart1.Titles.Add("Lecturer Rooms & Laboratories");
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }
    }
}
