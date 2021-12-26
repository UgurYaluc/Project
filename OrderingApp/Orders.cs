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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        public static string userFilePath2 = Application.StartupPath + "\\Datalar\\" + "orderdata.txt";
        List<string> datas = File.ReadAllLines(userFilePath2).ToList();
        private void FollowingOrder_Load(object sender, EventArgs e)
        {
            foreach (var data in datas)
            {
                listBox1.Items.Add(data);

            }
        }
    }
}
