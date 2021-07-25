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
    public partial class stock : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public stock()
        {
            InitializeComponent();
        }

        private void stock_Load(object sender, EventArgs e)
        {
            loadgrid();
        }
        DataTable dt;
        void loadgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select product.PNAME as product,stock.QTY from stock inner join product on stock.PID=product.PID ", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadgrid();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "product like '%"+textBox1.Text+"%'";
                dataGridView1.DataSource = dv;

            }
          

        }
    }
}
