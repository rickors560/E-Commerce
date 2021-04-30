using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using ECommerceApp.Menu.Manager_Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ECommerceApp.Menu.Customer_Menu
{
    internal class CustomerMenu
    {
        internal static string path = "Main Menu -> Customer Menu";
        private Dictionary<string, object> CustomerMenus;
        public CustomerMenu()
        {
            this.CustomerMenus = new Dictionary<string, object>() {
                { "DisplayProducts", new DisplayProducts() },
                { "AddProductToCart", new AddProductToCartMenu() },
                { "DisplayCartMenu", new DisplayCartMenu() }
            };
        }
        internal void ShowCustomerMenu() {
            Console.Clear();
            bool exit = false;
            if (RepoDb.GetAll<BasicProduct>().Count < 1)
            {
                Console.WriteLine($"\n\t\t{path}\n");
                Console.WriteLine("No Products Available!!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            while (!exit)
            {
                Console.WriteLine($"\n\t\t{path}\n");
                var displayProducts = (DisplayProducts)this.CustomerMenus["DisplayProducts"];
                displayProducts.ShowDisplayProducts();
                Console.WriteLine("a. Add a Product to Cart");
                Console.WriteLine("b. Display Cart");
                Console.WriteLine("c. LogOut\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        var addProductToCartMenu = (AddProductToCartMenu)this.CustomerMenus["AddProductToCart"];
                        addProductToCartMenu.ShowAddProductToCartMenu();
                        break;
                    case "b":
                        var displayCartMenu = (DisplayCartMenu)this.CustomerMenus["DisplayCartMenu"];
                        displayCartMenu.ShowDisplayCartMenu();
                        break;
                    case "c":
                        exit = true;
                        Console.WriteLine("Logging Out...");
                        Thread.Sleep(500);
                        break;
                    default:
                        Console.WriteLine("Invalid option!!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        } 
    }
}