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
    public partial class manage_session1 : Form
    {
        SqlConnection Sqlcon = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Thilina prawanka\source\repos\time_table_Assinment1\time_table_Assinment1\DatabaseConnect.mdf;Integrated Security = True");
        int id = 0;
        public manage_session1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("[sessions_update]", Sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Edit1");
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.Parameters.AddWithValue("@s_lecture", comboBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@s_group", comboBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@s_sub_group", comboBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@time", comboBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@session_id", textBox5.Text.Trim());

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                button2.Text = "update";
                button2.Enabled = true;
            }
        }
        void FillDataGideView()
        {
            if (Sqlcon.State == ConnectionState.Closed)
                Sqlcon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("sessionssearch", Sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("s_lecture", textBox3.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            Sqlcon.Close();
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sqlcon.State == ConnectionState.Closed)
                    Sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("sessiondelete", Sqlcon);
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

        private void button1_Click(object sender, EventArgs e)
        {

            {
                clear();
            }
        }
            void clear()
            {
                comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox5.Text = "";

            }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                var newform1 = new sessions();
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
    }
}
