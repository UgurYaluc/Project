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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
        public static string userFilePath = Application.StartupPath + "\\Datalar\\" + "admindata.txt";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre girmediniz. Lütfen tekrar giriniz.", "Giriş Başarısız Oldu.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int check = 0;
                List<string> datas = File.ReadAllLines(userFilePath).ToList();
                foreach (var data in datas)
                {
                    string[] entries = new string[1];
                    entries = data.Split(' ');
                    if (textBox1.Text == entries[0] && textBox2.Text == entries[1])
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        Frm(adminMenu);
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
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Bazı Alanları Boş Bıraktınız. Lütfen Boş Alanları Doldurup Tekrar Giriniz.", "Giriş Başarısız Oldu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox3.Text == "0000000001")
                {

                    File.AppendAllText(userFilePath, $"\n{textBox4.Text} {textBox5.Text} ");
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    MessageBox.Show("Başarıyla Kayıt Oldunuz", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.None);

                }



            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Frm(mainMenu);
        }
    }
}
