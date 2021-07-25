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
    public partial class sales : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
       
        public sales()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void sales_Load(object sender, EventArgs e)
        {
            loadc();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        DataTable dt;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        int s = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            int r = 0;
            cmd.CommandText="select RATE from product where PNAME = '"+comboBox1.Text+"'";
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            if (dr.Read())
            {
                r = Convert.ToInt16(dr[0]); 
            }
            con.Close();
            
            int q = Convert.ToInt16(textBox3.Text);
            int t = q * r;
            s = s + t;
            dataGridView1.Rows.Add(textBox2.Text, comboBox1.Text, textBox3.Text, r,t);
            label7.Text = s.ToString();
            

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int  isp()
        {
            int a=0;
            cmd.CommandText = "select CUID from customers where NAME='"+textBox2.Text+"'";
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToInt16(dr[0]);
            }
            con.Close();
            return a;
        }
        void dec(string pnm)
        {
           
           
            
        }
        void loadgrid()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            label7.Text = "0";
            dataGridView1.Rows.Clear();
        }
        string pnm = "";
            private void button2_Click_1(object sender, EventArgs e)
        {
           
              for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
              {



             
              
                  if (isp() != 0)
                  {
                      cmd.CommandText = "insert into sales(INVNO,INVDATE,CUID,PNAME,QTY,AMT) values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + isp() + "','" +Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value) + "'," + Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value) + ")";
                  }else
                  {
                      MessageBox.Show("Invalid Customer");
                      return;
                  }
                  cmd.Connection = con;
                  con.Open();
                  cmd.ExecuteNonQuery();
                  con.Close();
                  
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
               // string pnm = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                int f = 0;
                cmd.CommandText = "select PID from product where PNAME ='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    f = Convert.ToInt16(dr[0]);
                }
                con.Close();
                cmd.CommandText = "update stock set QTY=QTY - " + Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value) + "where PID=" +f+ "";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            MessageBox.Show("entry saved");
            loadgrid();
            //  label7.Text = isp().ToString();
        }
       
        
    }
}
