using ECommerceApp.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Manager_Menu
{
    internal class UpdateProductFromInventoryMenu
    {
        internal void ShowUpdateProductFromInventoryMenu() {
            Console.Clear();
            string oldpath = ManagerMenu.path;
            ManagerMenu.path += " -> Update Product";
            Console.WriteLine($"\n\t\t{ManagerMenu.path}\n");
            Console.Write("Enter ProductCode to Update Quantity: ");
            string productcode = Console.ReadLine();
            if (RepoDb.Get<Inventory>(productcode) == null) {
                Console.WriteLine("Invalid ProductCode!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            Console.Write("\tEnter New Quantity:");
            int quantity;
            if (!Int32.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid Quantity!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            if (quantity < 0)
            {
                Console.WriteLine("Invalid Quantity!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            RepoDb.Get<Inventory>(productcode).Quantity = quantity;
            Console.WriteLine("Updated Quantity!!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            ManagerMenu.path = oldpath;
        }
    }
}