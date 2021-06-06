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
    public partial class ManageSession : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\IT19053424\IT19053424\Database1.mdf;Integrated Security=True");
        int Id = 0;

        public ManageSession()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new AddSession();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            comboBox4.Text = comboBox3.Text = comboBox5.Text = comboBox2.Text = textBox5.Text = textBox7.Text = textBox1.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sesUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@group1", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@subject", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@lectuer", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@tag", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@student", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@duration", textBox7.Text.Trim());
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sesDelete", sqlCon);
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

        void FillDataGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("sesView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@subject", textBox1.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                button6.Text = "Update";
                button7.Enabled = true;


            }
        }
    }
}
