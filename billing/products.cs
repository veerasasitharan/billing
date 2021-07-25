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
    public partial class products : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public products()
        {
            InitializeComponent();
            loadcombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void products_Load(object sender, EventArgs e)
        {
            loadgrid();
        }
        void loadgrid()
        {

            SqlDataAdapter da = new SqlDataAdapter("select product.PID,product.PNAME,brand.BNAME,product.RATE,product.DES from product inner join brand on product.BID=brand.BID ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void loadcombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("select BID,BNAME from brand", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BNAME";
            comboBox1.ValueMember = "BID";
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "0";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                cmd.CommandText = "insert into product(PNAME,BID,RATE,DES) values('"+textBox2.Text+"',"+Convert.ToInt16(comboBox1.SelectedValue)+",'"+textBox4.Text+"','"+textBox5.Text+"')";
            }else
            {
                cmd.CommandText = "update product set PNAME='"+textBox2.Text+ "',BID=" + Convert.ToInt16(comboBox1.SelectedValue) + ",RATE='" + textBox4.Text + "',DES='" + textBox5.Text + "' where PID=" + Convert.ToInt16(textBox1.Text) + "";
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            button2_Click(sender, e);
            loadgrid();
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete ", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    cmd.CommandText = "delete from product where PID=" + Convert.ToInt16(textBox1.Text) + "";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    button2_Click(sender, e);
                    loadgrid();
                    con.Close();
                }
            }
        }
    }
}
