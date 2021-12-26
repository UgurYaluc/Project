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
    public partial class CustomerLogin : Form
    {
        public CustomerLogin()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
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
        public static string userFilePath = Application.StartupPath + "\\Datalar\\" + "userdata.txt";
        List<Customer> customers = new List<Customer>();
        List<string> datas = File.ReadAllLines(userFilePath).ToList();
        private void CustomerLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                string[] entries = new string[3];
                entries = data.Split(' ');
                Customer customer = new Customer();
                customer.username = entries[0];
                customer.password = entries[1];
                customer.name = entries[2];
                customer.adress = entries[3];
                customers.Add(customer);
            }

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre girmediniz. Lütfen tekrar giriniz.", "Giriş Başarısız Oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int check = 0;
                foreach (Customer customer in customers)
                {
                    if (textBox1.Text == customer.username && textBox2.Text == customer.password)
                    {
                        CustomerMenu customerMenu = new CustomerMenu(customer);
                        Frm(customerMenu);
                        check = 1;
                        break;
                    }

                }
                if (check == 0)
                    MessageBox.Show("Kullanıcı adı ve şifre uyumsuz Lütfen tekrar giriniz", "Giriş Başarısız Oldu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Bazı Alanları Boş Bıraktınız. Lütfen Boş Alanları Doldurup Tekrar Giriniz.", "Giriş Başarısız Oldu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var data in datas)
                {
                    string[] entries = new string[3];
                    entries = data.Split(' ');
                    Customer customer = new Customer();
                    customer.username = entries[0];
                    customer.password = entries[1];
                    customer.name = entries[2];
                    customer.adress = entries[3];
                    customers.Add(customer);
                }
                customers.Add(new Customer { username = textBox3.Text, password = textBox4.Text, name = textBox5.Text, adress = richTextBox1.Text });
                using (TextWriter tw = new StreamWriter(userFilePath))
                {
                    foreach (Customer customer in customers)
                    {
                        tw.WriteLine(string.Format("{0} {1} {2} {3}", customer.username, customer.password, customer.name, customer.adress));
                    }
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    richTextBox1.Clear();
                    MessageBox.Show("Başarıyla Kayıt Oldunuz", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Frm(mainMenu);
        }
    }
}
