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

namespace time_table_Assinment1
{
    public partial class add_Working_days : Form
    {
        SqlConnection Sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Thilina prawanka\source\repos\time_table_Assinment1\time_table_Assinment1\DatabaseConnect.mdf;Integrated Security = True");
        public add_Working_days()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Manage_working_days();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("workingDays_AddOR_Edit", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@id", 0);
                sqlCmd.Parameters.AddWithValue("@NFW", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WD_M", Monday.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_T", checkBox2.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_W", checkBox3.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_TH", checkBox4.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_F", checkBox5.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_S", checkBox6.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_SU", checkBox7.Checked);
                sqlCmd.Parameters.AddWithValue("@WHD", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WH", textBox2.Text.Trim());

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Save successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error message");
            }
            finally
            {
                Sqlcon.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_Working_days_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new hours();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
