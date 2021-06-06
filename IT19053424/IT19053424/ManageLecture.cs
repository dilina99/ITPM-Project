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
    public partial class ManageLecture : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\IT19053424\IT19053424\Database1.mdf;Integrated Security=True");
        int Id = 0;
        public ManageLecture()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Lecture();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("updateLecture", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@lectureName", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Employ_ID", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Faculty", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Deoartment", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@center", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@bilding", textBox6.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@level", textBox7.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@rank", textBox3.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated suucessfully");


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                button2.Text = "Update";
                button5.Enabled = true;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
        void FillDataGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("lectureView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@lectureName", textBox1.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("lectureDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted suucessfully");
                Clear();
                FillDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = comboBox5.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
