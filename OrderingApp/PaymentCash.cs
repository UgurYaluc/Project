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
    public partial class PaymentCash : Form
    {
        Customer customer1 = new Customer();
        public PaymentCash(Customer customer)
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
        public static string userFilePath2 = Application.StartupPath + "\\Datalar\\" + "orderdata.txt";
        //List<Product> products = new List<Product>();
        List<string> datas = File.ReadAllLines(userFilePath2).ToList();

        private void label3_Click(object sender, EventArgs e)
        {
            List<string> lines = File.ReadAllLines(userFilePath2).ToList();

            File.WriteAllLines(userFilePath2, lines.GetRange(0, lines.Count - 1).ToArray());
            CustomerMenu customerMenu = new CustomerMenu(customer1);
            Frm(customerMenu);

        }

        private void label2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Siparişiniz Alınmıştır.", "Sipariş Onayı", MessageBoxButtons.OK, MessageBoxIcon.None);
            CustomerMenu customerMenu = new CustomerMenu(customer1);
            Frm(customerMenu);


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
