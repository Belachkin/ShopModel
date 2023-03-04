using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHuep
{
    internal class Order
    {
        public string ClientName;
        public string Address;
        public List<CartItem> Products;

        public Order(string clientName, string address, List<CartItem> products)
        {
            ClientName = clientName;
            Address = address;
            Products = products;
        }

        
    }
}
