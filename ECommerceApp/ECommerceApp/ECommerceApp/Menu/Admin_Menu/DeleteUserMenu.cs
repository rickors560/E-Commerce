using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Enums;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Admin_Menu
{
    internal class DeleteUserMenu
    {
        internal void ShowDeleteUserMenu() {
            Console.Clear();
            string oldpath = AdminMenu.path;
            AdminMenu.path += " -> Delete User";
            Console.WriteLine($"\n\t\t{AdminMenu.path}\n");
            var displayUsers = new DisplayUsers();
            displayUsers.ShowDisplayUsers();
            Console.Write("Enter User Name to Delete: ");
            string username = Console.ReadLine();
            var user = RepoDb.Get<User>(username);
            if (user != null){
                if (user.UserType == UserTypes.Admin)
                {
                    Console.WriteLine("Can't Delete Admin!!");
                }
                else {
                    RepoDb.Remove<User>(username);
                    Console.WriteLine("Deleted Successfully!!");
                }
            }
            else {
                Console.WriteLine("Invalid UserName!!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            AdminMenu.path = oldpath;
        }
    }
}