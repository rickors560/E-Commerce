using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Enums;
using ECommerceApp.Database.Users;
using ECommerceApp.Menu.Admin_Menu;
using ECommerceApp.Menu.Customer_Menu;
using ECommerceApp.Menu.Manager_Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ECommerceApp.Menu.Login_Menu
{
    internal class LoginMenu
    {
        internal static string path = "Main Menu";
        internal bool ShowLoginMenu() {
            Console.Clear();
            Console.WriteLine($"\n\t{path}\n");
            Console.WriteLine("a. Login");
            Console.WriteLine("b. Exit\n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("Login");
                    Login();
                    break;
                case "b":
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(500);
                    return false;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }
        private static void Login()
        {
            string oldpath = path;
            path += " -> Login"; 
            Console.Clear();
            Console.WriteLine($"\n\t{path}\n");
            Console.Write("Enter UserName: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = AuthManager.ReadPassWord();
            if (AuthManager.AcceptLoginCreds(username, password)){
                if (AuthManager.LoggedInUser.UserType == UserTypes.Admin) {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.ShowAdminMenu();
                }
                else if (AuthManager.LoggedInUser.UserType == UserTypes.Manager)
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ShowManagerMenu();
                }
                else if (AuthManager.LoggedInUser.UserType == UserTypes.Customer)
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.ShowCustomerMenu();
                }
            }
            else {
                Console.WriteLine("\nInvalid UserName or Password!!");
                Console.Write("\nSign Up for new User(Y/N):");
                if (Console.ReadLine().ToLower() == "y") {
                    SignUp signUp = new SignUp();
                    signUp.ShowSignUp();
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            path = oldpath;
        }
    }
}