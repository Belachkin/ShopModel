using ShopHuep;
using ShopModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            WriteLine("░██████╗██╗░░██╗███╗░░░███╗███████╗██╗░░░░░░░░░░░░░░░▄/▄/▄░░░░░░░░░██████╗████████╗░█████╗░██████╗░███████╗");
            Thread.Sleep(200);
            WriteLine("██╔════╝██║░░██║████╗░████║██╔════╝██║░░░░░░░░░░▐▀▄░▐▄█▄▌░▄▀▌░░░░░██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██╔════╝");
            Thread.Sleep(200);
            WriteLine("╚█████╗░███████║██╔████╔██║█████╗░░██║░░░░░░░░░░▐──▀─▀▀▀─▀──▌░░░░░╚█████╗░░░░██║░░░██║░░██║██████╔╝█████╗░░");
            Thread.Sleep(200);
            WriteLine("░╚═══██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║░░░░░░░░░░░▀▄▄▀▀▀▀▀▄▄▀░░░░░░░╚═══██╗░░░██║░░░██║░░██║██╔══██╗██╔══╝░░");
            Thread.Sleep(200);
            WriteLine("██████╔╝██║░░██║██║░╚═╝░██║███████╗███████╗░░░░░░░░░▀▀▀▀▀░░░░░░░░░██████╔╝░░░██║░░░╚█████╔╝██║░░██║███████╗");
            Thread.Sleep(200);
            WriteLine("╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚══════╝░░░░░░░░░░▀█▀░░░░░░░░░░╚═════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚══════╝");

            
            
            Store store = new Store();


            Authentication(store);


        }

        public static void Authentication(Store store)
        {
            for(; ; )
            {
                WriteLine("1 - Вход\n2 - Регистрация");

                string answer = ReadLine();

                switch (answer)
                {
                    case "1":

                        Write("Username: ");
                        string username = ReadLine();

                        Write("Password: ");
                        string password = ReadLine();



                        if (store.Users.Any(x => x.Username == username && x.Password == password))
                        {
                            User user = store.Users.First(x => x.Username == username && x.Password == password);

                            if (user.Role == "User")
                            {
                                UserConsol(store, user);
                            }
                            else if (user.Role == "Admin")
                            {
                                AdminConsol(store, user);
                            }

                        }

                        break;

                    case "2":
                        WriteLine("Регистрация");

                        Write("Username: ");
                        username = ReadLine();

                        Write("Password: ");
                        password = ReadLine();

                        Write("LastName: ");
                        string lastname = ReadLine();

                        Write("FirstName: ");
                        string firstname = ReadLine();

                        Write("MiddleName: ");
                        string middlename = ReadLine();

                        Write("Address: ");
                        string address = ReadLine();



                        User newUser = new User(username, lastname, firstname, middlename, "User", address, password);
                       
                        store.Users.Add(newUser);


                        WriteLine($"Аккаунт {newUser.Username} зарегестрирован\nТеперь можете войти в аккаунт");

                        break;

                    default:
                        WriteLine("Ошибка введения данных");
                        break;
                }
            }
            
        }
        public static void UserConsol(Store store, User user)
        {

            WriteLine($"Вы успешно вышли в аккаунт - {user.Username}");

            WriteLine("\n\n\nСписок команд которые вы можите использовать:\n " +
                "1 Просмотр списка товаров\n " +
                "2 Добавить товар в корзину\n" +
                "3 Просмотр корзины\n" +
                "4 Оформить заказ\n" +
                "5 Список заказов"); 

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
        public static void AdminConsol(Store store, User user)
        {

        }
    }
}
