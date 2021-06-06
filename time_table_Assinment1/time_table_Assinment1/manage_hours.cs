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
    public partial class manage_hours : Form
    {
        SqlConnection Sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Thilina prawanka\source\repos\time_table_Assinment1\time_table_Assinment1\DatabaseConnect.mdf;Integrated Security = True");
        int id = 0;
        public manage_hours()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
          comboBox1.Text = textBox1.Text = textBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (this.dataGridView1.CurrentRow.Cells[4].Value.Equals("One Hour"))
                    radioButton1.Checked = true;
                else
                    radioButton1.Checked = false;

                if (this.dataGridView1.CurrentRow.Cells[4].Value.Equals("Thirty minutes"))
                    radioButton2.Checked = true;
                else
                    radioButton2.Checked = false;

                button3.Text = "update";
                button3.Enabled = true;
            }
        }
        void FillDataGideView()
        {
            if (Sqlcon.State == ConnectionState.Closed)
                Sqlcon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("sloatSearch", Sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("Day", textBox3.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            Sqlcon.Close();
        }

        private void manage_hours_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("slotedit", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.Parameters.AddWithValue("@Day", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Start_time", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@End_time", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Sloat", textBox2.Text.Trim());

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("slotdelete", Sqlcon);
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

        private void button4_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                var newform1 = new hours();
                newform1.Closed += (s, args) => this.Close();
                newform1.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
