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
    public partial class Manage_Location : Form
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nishadi\source\repos\Project\Project\DatabaseConnect.mdf;Integrated Security=True");
        int Id = 0;

        public Manage_Location()
        {
            InitializeComponent();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Location();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("locationView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Building_Name", textSearch.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textSearch.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("locationUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@Building_Name", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Room_Name", textBox2.Text.Trim());
                if (radioButton1.Checked)
                    sqlCmd.Parameters.AddWithValue("@Room_Type", "Lecture Hall");
                else
                    sqlCmd.Parameters.AddWithValue("@Room_Type", "Laboratory");
                sqlCmd.Parameters.AddWithValue("@Capacity", textBox3.Text.Trim());
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("locationDelete", sqlCon);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                /*if (radioButton1.Checked)
                    radioButton1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                else
                    radioButton2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();*/
                if (this.dataGridView1.CurrentRow.Cells[3].Value.Equals("Lecture Hall"))
                    radioButton1.Checked = true;
                else
                    radioButton1.Checked = false;

                if (this.dataGridView1.CurrentRow.Cells[3].Value.Equals("Laboratory"))
                    radioButton2.Checked = true;
                else
                    radioButton2.Checked = false;
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;


            }
        }
    }
}
