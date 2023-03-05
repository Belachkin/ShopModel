using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHuep
{
    internal class Order
    {
        public User User;
        public List<CartItem> Products;

        public Order(User user,  List<CartItem> products)
        {
            User = user;         
            Products = products;
        }

        
    }
}
