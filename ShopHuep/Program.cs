using ShopHuep;
using System.Text.RegularExpressions;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            string text = "Добро пожаловать в онлайн магазин\nИмени Рикардо Милоса\nСписок команд которые вы можите использовать:\n " +
                "1 Просмотр списка товаров\n " +
                "2 Добавить товар в корзину\n" +
                "3 Просмотр корзины\n" +
                "4 Оформить заказ\n" +
                "5 Список заказов";

            string[] lines = Regex.Split(text, "\r\n|\r|\n");

            int left = 0;      
            int top = 0;

            int center = WindowWidth / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                
                left = center - (lines[i].Length / 2);

                SetCursorPosition(left, top);
                
                WriteLine(lines[i]);

                top = CursorTop;
            }

            Store store = new Store();
            


            UserConsol(store);
            


        }

        
        public static void UserConsol(Store store)
        {
            
            Cart cart = new Cart();

            for (; ; )
            {

                Write("\n: ");
                string answer = ReadLine();

                switch (answer)
                {
                    case "1":

                        store.ShowCatalog();

                        break;
                    case "2":

                        Write("Введите номер товара из списка который хотите добавить в корзину: ");
                        answer = ReadLine();
                        int productId = Convert.ToInt32(answer);

                        if (productId <= store.Products.Count)
                        {
                            Write("\nВведите кол-во товара: ");
                            answer = ReadLine();
                            int countProduct = Convert.ToInt32(answer);

                            cart.AddProductToCart(store.Products[productId], countProduct);
                        }
                        else
                        {
                            WriteLine("Такого порядкового номера не существует");
                        }

                        break;

                    case "3":

                        cart.ShowCartList();

                        break;

                    case "4":

                        Write("Ваше имя: ");
                        string name = ReadLine();
                        Write("Адресс доставки: ");
                        string address = ReadLine();

                        Order order = new Order(name, address, cart.CartList);

                        store.PlaceAnOrder(order);

                        WriteLine("Заказ оформлен");

                        break;

                    case "5":
                        WriteLine("Список заказов");
                        store.ShowOrdersList();
                        break;

                    default:

                        WriteLine("Введите доступный номер команды");

                        break;
                }
            }
        }

        
    }
}
