using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHuep
{
    internal class Cart
    {
        public List<CartItem> CartList { get; set; }

        public Cart()
        {
            CartList = new List<CartItem>();
        }

        public void AddProductToCart(Product product, int count)
        {
            if(count <= 0)
            {
                Console.WriteLine("Нельзя добавлять товар колличеством меньше нуля");
            }
            else if (CartList.Any(x => x.Product.Name == product.Name))
            {
                CartList.First(x => x.Product == product).Count += count;
            }
            else
            {
                CartItem newCartElement = new CartItem(product, count);

                CartList.Add(newCartElement);

            }

        }

        public void ShowCartList()
        {
            if(CartList.Count <= 0)
            {
                Console.WriteLine("Корзина пуста");
            }
            else
            {
                Console.WriteLine("Ваша корзина");
                for (int i = 0; i < CartList.Count; i++)
                {
                    Console.WriteLine($"[{i}] {CartList[i].Product.Name} | {CartList[i].Product.Price}р. | {CartList[i].Count} шт.");
                }
            }

        }
    }

    internal class CartItem
    {
        
        public Product Product { get; set; }
        public int Count { get; set; }

        public CartItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }
    }
}
