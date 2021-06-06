using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IT19038988
{
    public partial class Tag : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pasindu\Desktop\ITPM last\IT19038988\IT19038988\DatabaseConnect.mdf;Integrated Security=True");

        public Tag()
        {
            InitializeComponent();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Manage_Tag();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("tagAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@Subject", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Tag", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Code", textBox2.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Saved suucessfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
