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
    public partial class AddSubject : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\IT19053424\IT19053424\Database1.mdf;Integrated Security=True");

        public AddSubject()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint1();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new ManageSubject();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("subAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@SubjectName", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SubjectCode", textBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@OfferdYear", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@OfferdSemester", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lectuerhour", textBox6.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LabHour", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@TutorialHour", textBox7.Text.Trim());
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

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textBox1.Text = textBox4.Text = comboBox1.Text = comboBox2.Text = textBox6.Text = textBox5.Text = textBox7.Text = "";

        }
    }
}
