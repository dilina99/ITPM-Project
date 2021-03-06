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
    
    public partial class Manage__Sessions : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nishadi\source\repos\Project\Project\DatabaseConnect.mdf;Integrated Security=True");
        int Id = 0;

        public Manage__Sessions()
        {
            InitializeComponent();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sessions();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sessionUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@Lecturer_1", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lecturer_2", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Code", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Name", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Group_ID", comboBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Tag", comboBox6.Text.Trim());
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;


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
            SqlDataAdapter sqlDa = new SqlDataAdapter("sessionView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Subject_Name", textBox1.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sessionDelete", sqlCon);
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
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = textBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
