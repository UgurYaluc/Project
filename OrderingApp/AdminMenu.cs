using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderingApp
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }
        public void Frm(Form frm)
        {
            Form1 form1 = new Form1();
            panel2.Controls.Clear();
            frm.MdiParent = form1;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel2.Controls.Add(frm);
            frm.Show();

        }
        public void Frm1(Form frm)
        {
            Form1 form1 = new Form1();
            panel1.Controls.Clear();
            frm.MdiParent = form1;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ProductArrangment productArrangment = new ProductArrangment();
            Frm(productArrangment);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Frm1(mainMenu);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            Frm(orders);
        }
    }
}
