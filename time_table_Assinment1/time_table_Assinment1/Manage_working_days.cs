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
    public partial class Manage_working_days : Form
    {
        SqlConnection Sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Thilina prawanka\source\repos\time_table_Assinment1\time_table_Assinment1\DatabaseConnect.mdf;Integrated Security = True");
        int id = 0;
        public Manage_working_days()
        {
            InitializeComponent();
        }

        private void Manage_working_days_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void FillDataGideView()
        {
            if (Sqlcon.State == ConnectionState.Closed)
                Sqlcon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("searchandShow1", Sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("NFD1", textBox4.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            Sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGideView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                checkBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                checkBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                checkBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                checkBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                checkBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                checkBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                checkBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                button3.Text = "update";
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("update", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.Parameters.AddWithValue("@NFW", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WD_M", checkBox1.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_T", checkBox2.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_W", checkBox3.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_TH", checkBox4.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_F", checkBox5.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_S", checkBox6.Checked);
                sqlCmd.Parameters.AddWithValue("@WD_SU", checkBox7.Checked);
                sqlCmd.Parameters.AddWithValue("@WHD", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WH", textBox2.Text.Trim());

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
            finally
            {
                Sqlcon.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform1 = new add_Working_days();
            newform1.Closed += (s, args) => this.Close();
            newform1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("delete", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete successfully");
                clear();
                FillDataGideView();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }
    }
}
