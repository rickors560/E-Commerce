using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Admin_Menu
{
    internal class AddManagerMenu
    {
        internal void ShowAddManagerMenu() {
            Console.Clear();
            string oldpath = AdminMenu.path;
            AdminMenu.path += " -> Add Manager";
            Console.WriteLine($"\n\t\t{AdminMenu.path}\n");
            Console.Write("\nEnter User Name: ");
            string username = Console.ReadLine().Trim();
            if (!AuthManager.ValidateUniqueUserName(username))
            {
                Console.WriteLine("UserName already Exists!!");
                return;
            }
            Console.Write("Enter Password: ");
            string password = AuthManager.ReadPassWord().Trim();
            Manager manager = new Manager() { UserName = username, Password = password };
            if (RepoDb.Add<User>(manager, username))
            {
                Console.WriteLine("User Added Successfully!!");
            }
            else
            {
                Console.WriteLine("User Not Added!!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            AdminMenu.path = oldpath;
        }
    }
}