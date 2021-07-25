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

namespace billing
{
    public partial class customers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public customers()
        {
            InitializeComponent();
        }
        void loadgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from customers",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void customers_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete ", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    cmd.CommandText = "delete from customers where CUID=" + Convert.ToInt16(textBox6.Text) + "";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    button2_Click_1(sender, e);
                    loadgrid();
                    con.Close();
                }
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "0")
                {
                    cmd.CommandText = "insert into customers(NAME,ADDR,CITY,CONT) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                }
                else
                {
                    cmd.CommandText = "update customers set NAME='" + textBox2.Text + "',ADDR='" + textBox3.Text + "',CITY='" + textBox4.Text + "',CONT='" + textBox5.Text + "'";
                }
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                button2_Click_1(sender, e);
                loadgrid();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "0";
        }
    }
}
