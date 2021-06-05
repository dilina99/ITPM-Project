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

namespace Project
{
    public partial class Location : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nishadi\source\repos\Project\Project\DatabaseConnect.mdf;Integrated Security=True");

        public Location()
        {
            InitializeComponent();
        }

        private void Location_Load(object sender, EventArgs e)
        {

        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("locationAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@Building_Name", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Room_Name", textBox2.Text.Trim());
                if (radioButton1.Checked)
                    sqlCmd.Parameters.AddWithValue("@Room_Type", "Lecture Hall");
                else
                    sqlCmd.Parameters.AddWithValue("@Room_Type", "Laboratory");
                sqlCmd.Parameters.AddWithValue("@Capacity", textBox3.Text.Trim());
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Manage_Location();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }
    }
}
