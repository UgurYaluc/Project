using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp
{
    class Credit:PaymentClass
    {
        public int cardNumber { get; set; }
        public string Type { get; set; }
        public string expDate { get; set; }
        public bool authorized()
        {
            return true;
        }


    }
}
