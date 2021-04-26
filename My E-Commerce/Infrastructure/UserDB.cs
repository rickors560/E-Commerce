using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class UserDB : DBManager<User>
    {
        static UserDB() {
            Items = new Dictionary<int, User>();
            User Admin = new User()
            {
                Name = "admin",
                Password = "admin",
                Type = UserTypes.Admin
            };
            Items.Add(Admin.ID, Admin);
            User Ritik = new User()
            {
                Name = "ritik",
                Password = "123",
                Type = UserTypes.Customer
            };
            Items.Add(Ritik.ID, Ritik);
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                Items.Add(user.ID, user);
                Console.WriteLine("User account created!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("User Not Added!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void DeleteUser(int id)
        {
            if (id == 1)
            {
                Console.WriteLine("\nCan't Delete 'admin'!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (Items.ContainsKey(id)) {
                Items.Remove(id);
                Console.WriteLine("User Deleted!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("User Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void UpdateUser(int id)
        {
            if (id == 1) {
                Console.WriteLine("\nCan't Update 'admin'!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (Items.ContainsKey(id))
            {
                Console.WriteLine($"Choose Type of User for '{Items[id].Name}': " +
                    $"\n\t1.{UserTypes.Admin} \n\t2.{UserTypes.Customer}");
                switch (Console.ReadLine()) {
                    case "1":
                        Items[id].Type = UserTypes.Admin;
                        Console.WriteLine("\nUpdated Successfully!!\n");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        break;
                    case "2":
                        Items[id].Type = UserTypes.Customer;
                        Console.WriteLine("\nUpdated Successfully!!\n");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!!\n");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("User Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void DisplayUsers()
        {
            Console.WriteLine("Users in the System:");
            Console.WriteLine(String.Format("\t{0,3} {1,10}    {2}", "ID", "UserName", "Type"));
            foreach (User user  in Items.Values)
            {
                Console.WriteLine(user);
            }
        }
    }
}