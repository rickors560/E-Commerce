using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Manager_Menu
{
    internal class DeleteProductFromInventoryMenu
    {
        internal void ShowDeleteProductFromInventoryMenu() {
            Console.Clear();
            string oldpath = ManagerMenu.path;
            ManagerMenu.path += " -> Delete Product";
            Console.WriteLine($"\n\t\t{ManagerMenu.path}\n");
            Console.Write("Enter ProductCode to Delete: ");
            string productcode = Console.ReadLine();
            if (RepoDb.Remove<BasicProduct>(productcode) && RepoDb.Remove<Inventory>(productcode))
            {
                Console.WriteLine("Removed Successfully!!");
            }
            else {
                Console.WriteLine("Invalid ProductCode!!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            ManagerMenu.path = oldpath;
        }
    }
}