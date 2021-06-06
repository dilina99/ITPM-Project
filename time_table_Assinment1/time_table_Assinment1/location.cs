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
    public partial class location : Form
    {
        SqlConnection Sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Thilina prawanka\source\repos\time_table_Assinment1\time_table_Assinment1\DatabaseConnect.mdf;Integrated Security = True");
        int id = 0;
        public location()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("locationadd", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add2");
                sqlCmd.Parameters.AddWithValue("@id", 0);
                sqlCmd.Parameters.AddWithValue("@room", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@s_day", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@start_time", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@end_time", textBox1.Text.Trim());


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Save successfully");
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

        private void button6_Click(object sender, EventArgs e)
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
        void FillDataGideView()
        {
            if (Sqlcon.State == ConnectionState.Closed)
                Sqlcon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("locationsearch", Sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("room", textBox3.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            Sqlcon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                button2.Text = "update";
                button2.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("[locations_update]", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit1");
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.Parameters.AddWithValue("@room", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@s_day", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@start_time", textBox5.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@end_time", textBox1.Text.Trim());

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("location_delete", Sqlcon);
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

        private void button2_Click(object sender, EventArgs e)
        {
            {
                clear();
            }
        }
        void clear()
        {
            comboBox1.Text = comboBox2.Text = textBox5.Text = textBox1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                var newform1 = new select();
                newform1.Closed += (s, args) => this.Close();
                newform1.Show();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
