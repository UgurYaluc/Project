using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp
{
    public class OrderDetail
    {
        public double quantity { get; set; }
        public double tax { get; set; }

        public double weight { get; set; }

        public int calcWeight(Product product)
        {
            return product.shippingWeight;
        }
    }
}
