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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }
        Customer customer1 = new Customer();
        public CustomerMenu(Customer customer)
        {
            InitializeComponent();
            customer1 = customer;
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
        public static string userFilePath = Application.StartupPath + "\\Datalar\\" + "productdata.txt";
        public static string userFilePath2 = Application.StartupPath + "\\Datalar\\" + "orderdata.txt";
        
        List<Product> products = new List<Product>();
        List<string> datas = File.ReadAllLines(userFilePath).ToList();
        private void CustomerMenu_Load(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                checkedListBox1.Items.Add(data);
                
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            MainMenu mainMenu = new MainMenu();
            Frm(mainMenu);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            products.Clear();
            
                string selectedItem = checkedListBox1.SelectedItem.ToString();
                File.AppendAllText(userFilePath2, selectedItem);
                File.AppendAllText(userFilePath2, "\n");
                string[] entries = selectedItem.Split('/');
                Product product1 = new Product();
                product1.name = entries[0];
                product1.price = entries[1];
                product1.shippingWeight = Convert.ToInt32(entries[2]);
                product1.description = entries[3];
                products.Add(product1);

            
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.weight =product1.shippingWeight;
            orderDetail.quantity =  Int32.Parse(product1.price);

            Order order = new Order(customer1, products, orderDetail);
            Payment payment = new Payment(customer1,order);
            Frm(payment);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
    }
}
