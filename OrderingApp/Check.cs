using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp
{
    class Check:PaymentClass
    {
        public string name { get; set; }
        public int bankID { get; set; }
        public bool authorized()
        {
            return true;
        }
    }
}
