using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHuep
{
    internal class Store
    {

        public List<Product> Products;
        public List<Order> Orders;
        public List<User> Users;

        public Store()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Users = new List<User>();

            Products.Add(new Product("Фалоимитатор", 1500));
            Products.Add(new Product("Мастурбатор", 2300));
            Products.Add(new Product("Вазилин", 95));
            Products.Add(new Product("Книга - Моя борьба", 1488));

            Users.Add(new User("User1", "User1", "User1", "User1", "User", "", "User1"));
            Users.Add(new User("User2", "User2", "User2", "User2", "User", "", "User2"));
            Users.Add(new User("Admin", "Admin", "Admin", "Admin", "Admin", "", "Admin"));

        }

        public void ShowCatalog()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"[{i}] {Products[i].Name} - {Products[i].Price}р");
            }
        }

        public void PlaceAnOrder(Order newOrder)
        {
            Orders.Add(newOrder);
        }

        public void ShowOrdersList(User user)
        {
            List<Order> userOrders = GetUserOrders(user);

            if(userOrders.Count <= 0)
            {
                Console.WriteLine("Список заказов пуст");
            }
            else
            {
                for (int i = 0; i < userOrders.Count; i++)
                {
                    int orderValue  = 0;
                    Console.WriteLine($"[{i}] {user.Username} | {user.Address}");


                    for (int j = 0; j < userOrders[i].Products.Count; j++)
                    {
                        orderValue += userOrders[i].Products[j].Product.Price * userOrders[i].Products[j].Count;
                        Console.WriteLine($"       [{j}] {userOrders[i].Products[j].Product.Name} {userOrders[i].Products[j].Count} шт. {userOrders[i].Products[j].Product.Price}р/шт");
                                     
                    }


                    Console.WriteLine($"Общая сумма заказа: {orderValue}");
                }
            }
            
            
        }

        public List<Order> GetUserOrders(User user)
        {

            List<Order> userOrders = new List<Order>();

            foreach (var item in Orders)
            {
                if(item.User.Username == user.Username)
                {
                    userOrders.Add(item);
                }
            }

            return userOrders;
        }
    }
}
