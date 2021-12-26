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
    public partial class Payment : Form
    {
        public Customer customer1 = new Customer();
        public double totalprice;
        public double totalweight;

        public Payment(Customer customer,Order order)
        {
            totalprice = order.calcTotal();
            totalweight = order.totalWeight;
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
        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PaymentCash paymentCash = new PaymentCash(customer1);
            Frm(paymentCash);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PaymentCreditCard paymentCredit = new PaymentCreditCard(customer1,totalprice);
            Frm(paymentCredit);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            PaymentCheck paymentCheck = new PaymentCheck(customer1);
            Frm(paymentCheck);
        }
    }
}
