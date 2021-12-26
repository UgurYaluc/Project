using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApp
{
    public class Order
    {
        OrderDetail orderDetail = new OrderDetail();
        public Order(Customer customer,List<Product> products, OrderDetail orderDetail1)
        {
            orderDetail.quantity = orderDetail1.quantity;
            orderDetail.weight = orderDetail1.weight;
        }


        
        public double total { get; set; }
        public double totalWeight { get; set; }
        public bool status(bool bool1)
        {
            if (bool1 == true)
                return true;
            else
                return false;
        }
        public string Date()
        {
            string date = DateTime.Now.ToString();
            return date;
        }
        public void calcTax()
        {
           
            
                orderDetail.tax = orderDetail.quantity * 0.15;
            
            
        }
        public double calcTotal()
        {
            
            
                total = orderDetail.tax + orderDetail.quantity;
            
            return total;
        }
    }
    
}
