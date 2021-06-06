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

namespace IT19053424
{
    public partial class AddSession : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\IT19053424\IT19053424\Database1.mdf;Integrated Security=True");

        public AddSession()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint2();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new ManageSession();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sesAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@group1", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@subject", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@lectuer", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@tag", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@student", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@duration", textBox7.Text.Trim());
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

        void Clear()
        {
            comboBox4.Text = comboBox3.Text = comboBox5.Text = comboBox2.Text = textBox5.Text = textBox7.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
