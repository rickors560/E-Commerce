using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ECommerceApp.Menu.Customer_Menu
{
    internal class DisplayCartMenu
    {
        internal void ShowDisplayCartMenu() {
            Console.Clear();
            string oldpath = CustomerMenu.path;
            CustomerMenu.path += " -> Display Cart";
            Console.WriteLine($"\n\t\t{CustomerMenu.path}\n");
            Console.WriteLine("Products in Cart:");
            Console.WriteLine(String.Format("\t{0,3} {1,10} {2,14} {3,14} {4,14} {5,10}", "ID", "Name", "ProductCode", "Manufacturer", "SellingPrice", "Quantity"));
            var customer = (Customer)AuthManager.LoggedInUser;
            int totalamount = 0;
            foreach (string productcode in customer.Cart.Keys)
            {
                int quantity = customer.Cart[productcode];
                totalamount += (RepoDb.Get<BasicProduct>(productcode).SellingPrice) * quantity;
                Console.Write(RepoDb.Get<BasicProduct>(productcode));
                Console.Write(String.Format(" {0,10}\n", quantity));
            }
            Console.WriteLine("\t......................");
            Console.WriteLine($"\tTotal Amount: $ {totalamount}");
            Console.WriteLine();

            Console.WriteLine("a. Place Order");
            Console.WriteLine("b. Clear Cart");
            Console.WriteLine("c. Back");
            switch (Console.ReadLine().ToLower()) {
                case "a":
                    if (customer.Cart.Count > 0) {
                        customer.Cart.Clear();
                        Console.WriteLine("\nOrder Placed,Thank You!! ...");
                        Thread.Sleep(500);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case "b":
                    this.ClearCart(customer);
                    break;
                case "c":
                    break;
                default:
                    Console.WriteLine("Invalid option!!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            CustomerMenu.path = oldpath;
        }
        private void ClearCart(Customer customer) {
            foreach (string productcode in customer.Cart.Keys) {
                RepoDb.Get<Inventory>(productcode).Quantity += customer.Cart[productcode];
            }
            customer.Cart.Clear();
            Console.WriteLine("Cart Cleared!!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}