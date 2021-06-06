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
    public partial class Student_Groups : Form
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pasindu\Desktop\ITPM last\IT19038988\IT19038988\DatabaseConnect.mdf;Integrated Security=True");

        public Student_Groups()
        {
            InitializeComponent();
        }

        private void Student_Groups_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            var newform = new Manage_Student_Groups();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            comboBox4.Text = textBox2.Text = textBox3.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("groupAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@Year_Sem", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Program", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Group_Number", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SubGroup_Number", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Group_ID", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SubGroup_ID", textBox3.Text.Trim());
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
