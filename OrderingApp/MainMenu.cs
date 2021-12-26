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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public void Frm(Form frm)
        {
            Form1 form11 = new Form1();
            panel1.Controls.Clear();
            frm.MdiParent = form11;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            Frm(adminLogin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLogin customerLogin = new CustomerLogin();
            Frm(customerLogin);
        }
    }
}
