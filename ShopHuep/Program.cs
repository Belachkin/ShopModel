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
                

            ShowLogo(2);
            
            Store store = new Store();


            Authentication(store);


        }

        public static void ShowLogo(int delay)
        {

            string text =   "░██████╗██╗░░██╗███╗░░░███╗███████╗██╗░░░░░░░░░░░░░░░▄/▄/▄░░░░░░░░░██████╗████████╗░█████╗░██████╗░███████╗\n" +
                            "██╔════╝██║░░██║████╗░████║██╔════╝██║░░░░░░░░░░▐▀▄░▐▄█▄▌░▄▀▌░░░░░██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██╔════╝\n" +
                            "╚█████╗░███████║██╔████╔██║█████╗░░██║░░░░░░░░░░▐──▀─▀▀▀─▀──▌░░░░░╚█████╗░░░░██║░░░██║░░██║██████╔╝█████╗░░\n" +
                            "░╚═══██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║░░░░░░░░░░░▀▄▄▀▀▀▀▀▄▄▀░░░░░░░╚═══██╗░░░██║░░░██║░░██║██╔══██╗██╔══╝░░\n" +
                            "██████╔╝██║░░██║██║░╚═╝░██║███████╗███████╗░░░░░░░░░▀▀▀▀▀░░░░░░░░░██████╔╝░░░██║░░░╚█████╔╝██║░░██║███████╗\n" +
                            "╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚══════╝░░░░░░░░░░▀█▀░░░░░░░░░░╚═════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚══════╝\n";


            char[] logo = text.ToCharArray();

            for (int i = 0; i < logo.Length; i++)
            {               
                Thread.Sleep(delay);
                Write(logo[i]);                             
            }
        }

        public static void Authentication(Store store)
        {
            for(; ; )
            {
                Thread.Sleep(1000);
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
                       
                        //TODO: Добавить проверку уникальности unsername

                        if(store.CheckUniquenessUsername(newUser) == true)
                        {
                            store.Users.Add(newUser);
                            WriteLine($"Аккаунт {newUser.Username} зарегестрирован\nТеперь можете войти в аккаунт");
                        }
                        else
                        {
                            Console.WriteLine($"Пользователь Username - {newUser.Username} уже существует");
                        }

                        


                       

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
            Thread.Sleep(1000);
            WriteLine("\nСписок команд которые вы можите использовать:\n" +
                "1 Просмотр списка товаров\n" +
                "2 Добавить товар в корзину\n" +
                "3 Просмотр корзины\n" +
                "4 Оформить заказ\n" +
                "5 Список заказов\n" +
                "exit - выйти из аккунта"); 

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
                        //TODO: Больше взаимодействий с корзиной
                        if(cart.CartList.Count <= 0)
                        {
                            WriteLine("Корзина пуста - не возможно оформить заказ :c");
                        }
                        else
                        {
                            Order order = new Order(user, cart.CartList);

                            store.PlaceAnOrder(order);

                            WriteLine("Заказ оформлен");
                        }
                        

                        break;

                    case "5":
                        WriteLine("Список заказов");
                        store.ShowUserOrdersList(user);
                        break;

                    case "exit":
                        WriteLine($"Выход из аккунта {user.Username}");
                        Authentication(store);

                        break;
                    default:

                        WriteLine("Введите доступную команду");

                        break;
                }
            }
        }
        public static void AdminConsol(Store store, User user)
        {
            WriteLine("Вы вошли в Админку");
            WriteLine("Список команд:\n" +
                " 1 - Список товаров\n" +
                " 2 - Добавить/Удалить Товар\n" +
                " 3 - Список всех заказов\n" +
                " exit - выход из аккунта");

            Write("\n: ");
            string answer = ReadLine();

            switch (answer)
            {

                case "1":

                    store.ShowCatalog();

                    break;
                case "2": break;
                    //TODO: Добавить/Удалить товар
                case "3":
                    WriteLine("Список всех заказов в магазине");
                    store.ShowOrdersList();
                    
                    break;
                case "exit":

                    WriteLine($"Выход из аккунта {user.Username}");
                    Authentication(store);

                    break;


                default: WriteLine("Введите доступную команду"); break;

            }
        }
    }
}
