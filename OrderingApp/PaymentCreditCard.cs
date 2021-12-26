using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OrderingApp
{
    public partial class PaymentCreditCard : Form
    {
        Customer customer1 = new Customer();
        Credit credit = new Credit();
        public PaymentCreditCard(Customer customer,double double1)
        {
           
            credit.amount = double1;
            customer1 = customer;
            InitializeComponent();
        }
        public static string userFilePath2 = Application.StartupPath + "\\Datalar\\" + "orderdata.txt";
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
            List<string> lines = File.ReadAllLines(userFilePath2).ToList();

            File.WriteAllLines(userFilePath2, lines.GetRange(0, lines.Count - 1).ToArray());
            CustomerMenu customerMenu = new CustomerMenu(customer1);
            Frm(customerMenu);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            const int MIN_VALUE = 22;
            const int MAX_VALUE = 22;
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "")
            {
                MessageBox.Show("Girdiğiniz Bilgiler Hatalıdır.Lütfen Tekrar Giriniz.");
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
            }
            else if ((int.Parse(maskedTextBox4.Text) < MIN_VALUE) || (int.Parse(maskedTextBox2.Text) > MAX_VALUE) || (int.Parse(maskedTextBox2.Text) < 0))
            {
                MessageBox.Show("Kart tarihi hatalı lütfen tekrar deneyiniz.");
                maskedTextBox4.Clear();
                maskedTextBox2.Clear();
            }
            else
            {
                MessageBox.Show("Siparişiniz Alınmıştır.");
                CustomerMenu customerMenu = new CustomerMenu(customer1);
                Frm(customerMenu);
            }


        }

        private void PaymentCreditCard_Load(object sender, EventArgs e)
        {
           
        }
    }
}
