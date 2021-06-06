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
    public partial class Manage_Tag : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pasindu\Desktop\ITPM last\IT19038988\IT19038988\DatabaseConnect.mdf;Integrated Security=True");
        int Id = 0;

        public Manage_Tag()
        {
            InitializeComponent();
        }

        private void Manage_Tag_Load(object sender, EventArgs e)
        {

        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Tag();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("tagUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@Id", Id);
                sqlCmd.Parameters.AddWithValue("@Subject", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Tag", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Subject_Code", textBox2.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("tagView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Subject", textBox3.Text.Trim());
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
                SqlCommand sqlCmd = new SqlCommand("tagDelete", sqlCon);
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;


            }
        }
    }
}
