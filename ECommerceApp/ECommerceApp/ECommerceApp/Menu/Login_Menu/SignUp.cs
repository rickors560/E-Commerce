using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Enums;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Login_Menu
{
    internal class SignUp{
        internal void ShowSignUp() {
            Console.Write("\n\tEnter User Name: ");
            string username = Console.ReadLine().Trim();
            if (! AuthManager.ValidateUniqueUserName(username)) {
                Console.WriteLine("\tUserName already Exists!!\n");
                return;
            }
            Console.Write("\tEnter Password: ");
            string password = AuthManager.ReadPassWord().Trim();
            Customer customer = new Customer() { UserName = username, Password = password };
            if (RepoDb.Add<User>(customer, username))
            {
                Console.WriteLine("\tUser Added Successfully!!");
            }
            else
            {
                Console.WriteLine("\tUser Not Added!!");
            } 
        }
    }
}