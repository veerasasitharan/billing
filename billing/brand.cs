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

    public partial class brand : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
     
       // SqlDataAdapter da;
        public brand()
        {
            InitializeComponent();
            loadc();
            loadgrid();
        }

        private void brand_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void loadgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select brand.BID,BRAND.BNAME as 'brand name',category.CNAME as 'category name' from brand inner join category on brand.CID=category.CID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
     
           

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="0")
            {
                cmd.CommandText = "insert into brand(BNAME,CID) values('"+textBox1.Text+"',"+Convert.ToInt16(comboBox1.SelectedValue)+")";
               
            }else
            {
                cmd.CommandText = "update  brand set BNAME='" + textBox1.Text + "',CID=" + Convert.ToInt16(comboBox1.SelectedValue) + " where BID="+Convert.ToInt16(textBox2.Text)+"";
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            button2_Click(sender, e);
            loadgrid();
            con.Close();
        }

        public void loadc()
        {
            SqlDataAdapter da = new SqlDataAdapter("select CID,CNAME from category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "CNAME";
            comboBox1.ValueMember = "CID";
            comboBox1.SelectedIndex = -1;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    cmd.CommandText = "delete from brand where BID=" + Convert.ToInt16(textBox2.Text) + "";

                }
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            button2_Click(sender, e);
            loadgrid();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
