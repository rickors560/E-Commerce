using ECommerceApp.Database;
using ECommerceApp.Database.Enums;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Admin_Menu
{
    internal class DisplayUsers
    {
        internal void ShowDisplayUsers() {
            Console.WriteLine("Users in the System:");
            Console.WriteLine(String.Format("\t{0,3} {1,10} {2,10}  {3,10}", "ID", "UserName", "Password", "UserType"));
            var users = RepoDb.GetAll<User>().Values;
            foreach (User user in users) {
                if (user.UserType == UserTypes.Admin) {
                    Console.WriteLine(user);
                }
            }
            foreach (User user in users)
            {
                if (user.UserType == UserTypes.Manager)
                {
                    Console.WriteLine(user);
                }
            }
            foreach (User user in users)
            {
                if (user.UserType == UserTypes.Customer)
                {
                    Console.WriteLine(user);
                }
            }
            Console.WriteLine();
        }
    }
}
