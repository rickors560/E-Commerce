using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Manager_Menu
{
    internal class AddProductToInventoryMenu
    {
        internal void ShowAddProductToInventoryMenu() {
            Console.Clear();
            string oldpath = ManagerMenu.path;
            ManagerMenu.path += " -> Add Product"; 
            Console.WriteLine($"\n\t\t{ManagerMenu.path}\n");
            Console.WriteLine("Add a Product:");
            Console.WriteLine($"\tID:{BasicProduct.autoIncreamentor + 1}");
            Console.Write("\tName: "); string name = Console.ReadLine();
            Console.Write("\tProductCode: "); string productcode = Console.ReadLine();
            if (RepoDb.Get<BasicProduct>(productcode) != null) {
                Console.WriteLine("ProductCode Must Be Unique!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            Console.Write("\tManufacturer: "); string manufacturer = Console.ReadLine();
            Console.Write("\tPrice: "); int sellingprice;
            if (!Int32.TryParse(Console.ReadLine(), out sellingprice))
            {
                Console.WriteLine("Invalid Price!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            if (sellingprice < 0)
            {
                Console.WriteLine("Invalid Price!!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                ManagerMenu.path = oldpath;
                return;
            }
            Console.Write("\tQuantity: "); int quantity;
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
            BasicProduct product = new BasicProduct()
            {
                Name = name,
                ProductCode = productcode,
                Manufacturer = manufacturer,
                SellingPrice = sellingprice
            };
            Inventory inventory = new Inventory(productcode, quantity);
            if (RepoDb.Add<BasicProduct>(product, productcode) && RepoDb.Add<Inventory>(inventory, productcode))
            {
                Console.WriteLine("Added Successfully!!");
            }
            else
            {
                Console.WriteLine("Product Not Added!!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            ManagerMenu.path = oldpath;
        }
    }
}