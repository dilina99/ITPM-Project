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
    public partial class Sessions : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nishadi\source\repos\Project\Project\DatabaseConnect.mdf;Integrated Security=True");
        public Sessions()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sessions_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sessionAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@Lecturer_1", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lecturer_2", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Code", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Name", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Group_ID", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Tag", comboBox6.Text.Trim());
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

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint2();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Manage__Sessions();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        void Clear()
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
