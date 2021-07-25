using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace billing
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(brand))
                {
                    f.Activate();
                    return;
                    
                }
            }
            brand frm = new brand();
            frm.MdiParent = this;
            frm.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(category))
                {
                    f.Activate();
                    return;

                }
            }
            category frm = new category();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(products))
                {
                    f.Activate();
                  
                    return;

                }
            }
            products frm = new products();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(customers))
                {
                    f.Activate();
                    return;

                }
            }
            customers frm = new customers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(purchase))
                {
                    f.Activate();

                    return;

                }
            }
            purchase frm = new purchase();
            frm.MdiParent = this;
            frm.Show();
        }

        private void minimumStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(stock))
                {
                    f.Activate();
                    return;

                }
            }
            stock frm = new stock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(sales))
                {
                    f.Activate();
                    return;

                }
            }
            sales frm = new sales();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
