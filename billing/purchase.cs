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
    public partial class purchase : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public purchase()
        {
            InitializeComponent();
        }
        public void loadc()
        {
            SqlDataAdapter da = new SqlDataAdapter("select PID,PNAME from product", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PNAME";
            comboBox1.ValueMember = "PID";
            comboBox1.SelectedIndex = -1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void purchase_Load(object sender, EventArgs e)
        {
            loadc();
        }
        bool ispresent(string pid)
        {
            bool a = false;
            SqlDataAdapter da = new SqlDataAdapter("select PID from stock where PID='" + pid + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                a = true;
            }
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add(comboBox1.SelectedValue.ToString(), comboBox1.Text, textBox2.Text);
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";




        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("please add products");
                return;
            }
            if (textBox1.Text=="")
            {
                MessageBox.Show("please enter invoice no");
                return;
            }
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cmd.CommandText = "insert into purchase (PID,QTY,PDATE,PINV) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dateTimePicker1.Text + "','"+textBox1.Text+"')";

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch(Exception)
            {
                MessageBox.Show("entry saved");
            }


            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cmd.CommandText = "";
                    if (ispresent(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                    {
                        cmd.CommandText = "update stock set QTY=QTY+" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "where PID=" + dataGridView1.Rows[i].Cells[0].Value.ToString();
                    }
                    else
                    {
                        cmd.CommandText = "insert into stock (PID,QTY) values(" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + ")";


                    }
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
            
        
            // label1.Text = textBox1.Text;
            dataGridView1.Rows.Clear();

        }
       

        
    }
}
