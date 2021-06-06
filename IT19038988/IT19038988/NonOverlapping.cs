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
    public partial class NonOverlapping : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pasindu\Desktop\ITPM last\IT19038988\IT19038988\DatabaseConnect.mdf;Integrated Security=True");
        int Id = 0;

        public NonOverlapping()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint2();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newform = new Sprint2();
            newform.Closed += (s, args) => this.Close();
            newform.Show();
        }

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("overlaAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@Id", 0);
                sqlCmd.Parameters.AddWithValue("@category_1", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@category_2", textBox2.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Saved suucessfully");


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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                Id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();


            }
        }

        void FillDataGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("overlaView", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@category_1", textBox3.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView2.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
