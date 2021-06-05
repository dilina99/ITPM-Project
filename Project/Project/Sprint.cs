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
    public partial class Sprint : Form
    {
        public Sprint()
        {
            InitializeComponent();
        }

        private void butLoca_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butStat_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint2();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sprint_Load(object sender, EventArgs e)
        {

        }
    }
}
