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
using System.Configuration;

namespace billing
{

    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                cmd.CommandText = "select * from users where NAME='" + textBox1.Text +"'and PASS='"+textBox2.Text+"'";
                cmd.Connection = con;
                con.Open();
                dr=cmd.ExecuteReader();
                if (dr.Read())
                {
                    home ho = new home();
                    this.Hide();
                    ho.Show();
                }else
                {
                    MessageBox.Show("invalid login");
                }
      
            }
            else
            {
                MessageBox.Show("please fill out the fields");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
