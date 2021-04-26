using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoginManager
{
    public class Login
    {
        public static InventoryDB InventoryDB { get; set; }
        public static UserDB UserDB { get; set; }
        public static User LoggedInUser { get; set; }
        public Login()
        {
            InventoryDB = new InventoryDB();
            UserDB = new UserDB();
        }
        public void Welcome()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t\t-------------------Welcome-------------------\n");
                Console.WriteLine("a. Login");
                Console.WriteLine("b. Exit\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        this.Authenticate();
                        break;
                    case "b":
                        exit = true;
                        Console.WriteLine("\nExiting.............\n");
                        Thread.Sleep(500);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!!\n");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        public static string ReadPassWord()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
        private void Authenticate()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t-------------------Login-------------------\n");
            Console.Write("Enter UserName:");
            string username = Console.ReadLine();
            bool usernameexists = false;
            foreach (User user in UserDB.Items.Values)
            {
                if (user.Name == username)
                {
                    usernameexists = true;
                }
            }
            if (!usernameexists) {
                Console.WriteLine("\nInvalid UserName!!\n");
                Console.Write("Sign Up for New User(Y/N):");
                if (Console.ReadLine().ToLower() == "y")
                {
                    this.AddUser();
                }
                return;
            }
            Console.Write("Enter Password:");
            string password = ReadPassWord();

            bool userfound = false;
            foreach (KeyValuePair<int, User> user in UserDB.Items)
            {
                if (user.Value.Name == username)
                {
                    if (user.Value.Password == password)
                    {
                        userfound = true;
                        LoggedInUser = user.Value;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Password!!");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            if (userfound)
            {
                if (UserDB.Items[LoggedInUser.ID].Type == Core.Enums.UserTypes.Admin)
                {
                    Console.Clear();
                    Admin.ShowAdmin();
                }
                else if (UserDB.Items[LoggedInUser.ID].Type == Core.Enums.UserTypes.Customer)
                {
                    Console.Clear();
                    Customer.ShowCustomers();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Password!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        private void AddUser()
        {
            Console.WriteLine($"\nUser ID:{User.autoIncreamentor + 1}");
            Console.Write("Enter UserName:");
            string username = Console.ReadLine();

            bool usernameexists = false;
            foreach (User user in UserDB.Items.Values)
            {
                if (user.Name == username)
                {
                    Console.WriteLine("\nUserName already Exists!!\n");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    usernameexists = true;
                }
            }
            if (usernameexists)
            {
                this.AddUser();
            }
            else {
                Console.Write("Enter PassWord:");
                string password = ReadPassWord();
                User newUser = new User() {
                    Name = username,
                    Password = password,
                    Type = Core.Enums.UserTypes.Customer
                };
                UserDB.AddUser(newUser);
            }
        }
    }
}