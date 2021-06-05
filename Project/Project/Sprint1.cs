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
    public partial class Sprint1 : Form
    {
        public Sprint1()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void butLoca_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Location();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void butStat_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Statistics();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }
    }
}
