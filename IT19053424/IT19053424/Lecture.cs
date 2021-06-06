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
    public partial class Lecture : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\IT19053424\IT19053424\Database1.mdf;Integrated Security=True");

        public Lecture()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new ManageLecture();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("AddLectures", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@lectureName", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Employ_ID", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Faculty", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Deoartment", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@center", textBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@bilding", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@level", textBox6.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@rank", textBox3.Text.Trim());
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

        private void Lecture_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = comboBox5.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox3.Text = "";

        }
    }
}
