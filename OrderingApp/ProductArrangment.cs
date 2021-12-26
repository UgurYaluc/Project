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
    public partial class ProductArrangment : Form
    {
        public ProductArrangment()
        {
            InitializeComponent();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        public static string userFilePath = Application.StartupPath + "\\Datalar\\" + "productdata.txt";
        List<Product> products = new List<Product>();
        List<string> datas = File.ReadAllLines(userFilePath).ToList();

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                string[] entries = new string[3];
                entries = data.Split('/');
                if (entries[0] == "")
                    break;
                Product product1 = new Product();
                product1.name = entries[0];
                product1.price = entries[1];
                product1.shippingWeight = Convert.ToInt32(entries[2]);
                product1.description = entries[3];
                products.Add(product1);
            }

            string temp = textBox2.Text.ToString();
            Product product = new Product();
            product.name = textBox1.Text;
            product.price = temp;
            product.shippingWeight = Int32.Parse(textBox3.Text);
            product.description = richTextBox1.Text;
            products.Add(product);
            listBox1.Items.Clear();
            using (TextWriter tw = new StreamWriter(userFilePath))
            {
                foreach(Product product1 in products)
                {
                    tw.WriteLine(string.Format("{0}/{1}/{2}/{3}", product1.name, product1.price, product1.shippingWeight, product1.description));
                    listBox1.Items.Add($"{product1.name}/{product1.price}/{product1.shippingWeight}/{product1.description}");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
                listBox1.Refresh();
                

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductArrangment_Load(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                listBox1.Items.Add(data);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string temp = listBox1.SelectedItem.ToString();
            string[] tempentries = temp.Split('/');
            string temp2 = tempentries[0];
            datas.RemoveAll(x => x.Split('/')[0].Equals(temp2));
            File.WriteAllLines(userFilePath, datas);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
