using Core.Enums;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LoginManager
{
    public static class Admin
    {
        public static void ShowAdmin()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n\t\t-------------------Welcome '{Login.LoggedInUser.Name}'-------------------\n");
                Login.InventoryDB.DisplayProducts();
                Console.WriteLine("\na. Add a Product to Inventory");
                Console.WriteLine("b. Delete a Product from Inventory");
                Console.WriteLine("c. Update a Product from Inventory");
                Console.WriteLine("d. Edit Users");
                Console.WriteLine("e. LogOut\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        AddProductToInventory();
                        break;
                    case "b":
                        DeleteProductFromInventory();
                        break;
                    case "c":
                        UpdateProductFromInventory();
                        break;
                    case "d":
                        EditUsers();
                        break;
                    case "e":
                        exit = true;
                        Console.WriteLine("\nLogging Out.............\n");
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
        public static void AddProductToInventory()
        {
            Console.WriteLine("\nAdd a Product:");
            Console.WriteLine($"\tID:{Product.autoIncreamentor + 1}");
            Console.Write("\tName:"); string name = Console.ReadLine();
            Console.Write("\tShortCode:"); string shortcode = Console.ReadLine();
            Console.Write("\tManufacturer:"); string manufacturer = Console.ReadLine();
            Console.Write("\tPrice:"); int sellingprice;
            if (!Int32.TryParse(Console.ReadLine(), out sellingprice))
            {
                Console.WriteLine("\nInvalid Price!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (sellingprice < 0)
            {
                Console.WriteLine("\nInvalid Price!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            Console.Write("\tQuantity:"); int quantity;
            if (!Int32.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("\nInvalid Quantity!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (quantity < 0)
            {
                Console.WriteLine("\nInvalid Quantity!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            Product product = new Product()
            {
                Name = name,
                ShortCode = shortcode,
                Manufacturer = manufacturer,
                SellingPrice = sellingprice,
                Quantity = quantity
            };
            Login.InventoryDB.AddProduct(product);
        }
        public static void DeleteProductFromInventory()
        {
            Console.Write("Enter ID to Delete:");
            int id;
            if (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\nInvalid ID!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (id < 0)
            {
                Console.WriteLine("\nInvalid ID!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            Login.InventoryDB.DeleteProduct(id);
        }
        public static void UpdateProductFromInventory()
        {
            Console.Write("Enter ID to Update:");
            int id;
            if (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\nInvalid ID!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            if (id < 0)
            {
                Console.WriteLine("\nInvalid ID!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                return;
            }
            Login.InventoryDB.UpdateProduct(id);
        }
        public static void EditUsers()
        {
            Console.Clear();
            bool exit = false;
            while (!exit) {
                Console.WriteLine($"\n\t\t-------------------Welcome '{Login.LoggedInUser.Name}'-------------------\n");
                Login.UserDB.DisplayUsers();
                Console.WriteLine("\na. Add a User");
                Console.WriteLine("b. Edit User Type");
                Console.WriteLine("c. Delete a User");
                Console.WriteLine("d. Back\n");
                switch (Console.ReadLine().ToLower()) {
                    case "a":
                        AddUser();
                        break;
                    case "b":
                        EditUserType();
                        break;
                    case "c":
                        DeleteUser();
                        break;
                    case "d":
                        exit = true;
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
        private static void AddUser()
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
                AddUser();
            }
            else
            {
                Console.Write("Enter PassWord:");
                string password = Login.ReadPassWord();
                User newUser = new User()
                {
                    Name = username,
                    Password = password,
                };
                Console.WriteLine($"Choose Type of User for '{newUser.Name}': " +
                   $"\n\t1.{UserTypes.Admin} \n\t2.{UserTypes.Customer}");
                switch (Console.ReadLine())
                {
                    case "1":
                        newUser.Type = UserTypes.Admin;
                        break;
                    case "2":
                        newUser.Type = UserTypes.Customer;
                        break;
                    default:
                        newUser.Type = UserTypes.Customer;
                        Console.WriteLine("\nInvalid option!!\n");
                        Console.WriteLine("Making User type Customer. Change in options if want to.\n");
                        break;
                }
                Login.UserDB.AddUser(newUser);
            }
        }
        public static void EditUserType()
        {
            Console.Write("Enter User ID to Update:");
            int id;
            if (Int32.TryParse(Console.ReadLine(), out id))
            {
                if (id > 0)
                {
                    Login.UserDB.UpdateUser(id);
                }
                else
                {
                    Console.WriteLine("\nInvalid Id!!\n");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Id!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public static void DeleteUser()
        {
            Console.Write("Enter User ID to Delete:");
            int id;
            if (Int32.TryParse(Console.ReadLine(), out id))
            {
                if (id > 0)
                {
                    Login.UserDB.DeleteUser(id);
                }
                else
                {
                    Console.WriteLine("\nInvalid Id!!\n");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Id!!\n");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }   
    }
}