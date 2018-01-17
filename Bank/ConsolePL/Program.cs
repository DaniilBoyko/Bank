using System;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolverConsole();
        }

        public static void Main(string[] args)
        {
            var accountService = Resolver.Get<IAccountService>();
            var userService = Resolver.Get<IUserService>();


            try
            {
                //accountService.CreateNewType("Platinum");
                foreach (var type in accountService.GetAllTypes())
                {
                    Console.WriteLine($"{type.Type}\n");
                }

                /*
                Console.WriteLine("-----CREATE NEW USERS-----");
                //userService.CreateUser("Kostya", "Trush", "kostya.trush.2010@mail.ru", "111111");
                //accountService.CreateNewAccount("Base", "daniil.boyko.2010@mail.ru", 1003);

                Console.WriteLine("-----DELETE USER-----");
                //userService.DeleteUser(userService.GetUser("kostya.trush.2010@mail.ru", "111111"));

                Console.WriteLine("-----CREATE NEW ACCOUNT-----");
                //accountService.CreateNewAccount("Base", "daniil.boyko.2010@mail.ru", 999);
                //accountService.CreateNewAccount("Gold", "daniil.boyko.2010@mail.ru", 9999);
                //accountService.CreateNewAccount("Platinum", "daniil.boyko.2010@mail.ru", 99999);

                Console.WriteLine("-----WITHDRAW 999 FROM ACCOUNT-----");
                //accountService.WithdrawFromAccount(8, 999);

                Console.WriteLine("-----DEPOSIT 100 TO THE ACCOUNT-----");
                //accountService.DepositToAccount(8, 100);

                Console.WriteLine("-----WITHDRAW 100 FROM ACCOUNT-----");
                //accountService.WithdrawFromAccount(8, 100);

                Console.WriteLine("-----DELETE ACCOUNT-----");
                //accountService.DeleteAccount(8);

                Console.WriteLine("----SHOW ACCOUNT INFO-----");
                //accountService.ShowAccountInfo(10);

                Console.WriteLine("----GET ACCOUNTS BY EMAIL-----");
                var account = accountService.SelectAll("daniil.boyko.2010@mail.ru");

                Console.WriteLine("----GET USER BY EMAIL AND PASSWORD-----");
                var user = userService.GetUser("daniil.boyko.2010@mail.ru", "501466");
                Console.WriteLine($"Name: {user.Name}:\nSurname: {user.Surname}\nEmail: {user.Email}\nPassword: {user.Password}\n");

    */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
