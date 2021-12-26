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
    public partial class PaymentCheck : Form
    {
        Customer customer1 = new Customer();
        public PaymentCheck(Customer customer)
        {
            customer1 = customer;
            InitializeComponent();
        }
        public void Frm(Form frm)
        {
            Form1 form1 = new Form1();
            panel1.Controls.Clear();
            frm.MdiParent = form1;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CustomerMenu customerMenu = new CustomerMenu(customer1);
            Frm(customerMenu);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" )
            {
                MessageBox.Show("Girdiğiniz Bilgiler Hatalıdır.Lütfen Tekrar Giriniz.");
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
            }
            else
            {
                MessageBox.Show("Siparişiniz Alınmıştır.");
                CustomerMenu customerMenu = new CustomerMenu(customer1);
                Frm(customerMenu);

            }
           
        }
    }
}
