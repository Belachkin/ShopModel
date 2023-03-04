﻿using ShopModel;
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

        public void ShowOrdersList()
        {
            
            if(Orders.Count <= 0)
            {
                Console.WriteLine("Список заказов пуст");
            }
            else
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    int orderValue  = 0;
                    Console.WriteLine($"[{i}] {Orders[i].ClientName} | {Orders[i].Address}");


                    for (int j = 0; j < Orders[i].Products.Count; j++)
                    {
                        orderValue += Orders[i].Products[j].Product.Price * Orders[i].Products[j].Count;
                        Console.WriteLine($"       [{j}] {Orders[i].Products[j].Product.Name} {Orders[i].Products[j].Count} шт. {Orders[i].Products[j].Product.Price}р/шт");
                                     
                    }


                    Console.WriteLine($"Общее сумма заказа: {orderValue}");
                }
            }
            
            
        }
    }
}