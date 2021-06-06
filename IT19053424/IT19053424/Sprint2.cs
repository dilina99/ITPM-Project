using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT19053424
{
    public partial class Sprint2 : Form
    {
        public Sprint2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Main();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new AddSession();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }
    }
}
