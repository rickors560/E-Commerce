using ECommerceApp.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ECommerceApp.Menu.Manager_Menu
{
    internal class ManagerMenu
    {
        internal static string path = "Main Menu -> Manager Menu";
        private Dictionary<string, object> ManagerMenus;
        public ManagerMenu()
        {
            this.ManagerMenus = new Dictionary<string, object>() {
                { "DisplayProducts", new DisplayProducts() },
                { "AddProductToInventory", new AddProductToInventoryMenu() },
                { "DeleteProductFromInventory", new DeleteProductFromInventoryMenu() },
                { "UpdateProductFromInventory", new UpdateProductFromInventoryMenu() }
            };
        }
        internal void ShowManagerMenu() {
            Console.Clear();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n\t\t{path}\n");
                var displayProducts = (DisplayProducts)this.ManagerMenus["DisplayProducts"];
                displayProducts.ShowDisplayProducts();
                Console.WriteLine("a. Add a Product to Inventory");
                Console.WriteLine("b. Delete a Product from Inventory");
                Console.WriteLine("c. Update a Product from Inventory");
                Console.WriteLine("d. LogOut\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        var addProductToInventoryMenu = (AddProductToInventoryMenu)this.ManagerMenus["AddProductToInventory"];
                        addProductToInventoryMenu.ShowAddProductToInventoryMenu();
                        break;
                    case "b":
                        var deleteProductFromInventoryMenu = (DeleteProductFromInventoryMenu)this.ManagerMenus["DeleteProductFromInventory"];
                        deleteProductFromInventoryMenu.ShowDeleteProductFromInventoryMenu();
                        break;
                    case "c":
                        var updateProductFromInventoryMenu = (UpdateProductFromInventoryMenu)this.ManagerMenus["UpdateProductFromInventory"];
                        updateProductFromInventoryMenu.ShowUpdateProductFromInventoryMenu();
                        break;
                    case "d":
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