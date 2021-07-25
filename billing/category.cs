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
    public partial class category : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
      

        public category()
        {
            InitializeComponent();
            loagrid();
        }
        void loagrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select CID,category.CNAME as 'category' from category ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox2.Text == "0")
            {
                cmd.CommandText = "insert into category(CNAME) values('" + textBox1.Text + "')";


            }
            else
            {
                cmd.CommandText = "update category set CNAME='" + textBox1.Text + "' where CID=" + Convert.ToInt16(textBox2.Text) + "";
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            button2_Click_1(sender, e);
            loagrid();
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "0";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    cmd.CommandText = "delete from category where CID=" + Convert.ToInt16(textBox2.Text) + "";

                }
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            button2_Click_1(sender, e);
            loagrid();
            con.Close();
        }
    }
    
}
