using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT19038988
{
    public partial class Sprint2 : Form
    {
        public Sprint2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Main();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void butLoca_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Parallel();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void butStat_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new NonOverlapping();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }
    }
}
