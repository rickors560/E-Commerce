using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Menu.Manager_Menu
{
    internal class DisplayProducts
    {
        internal void ShowDisplayProducts(){
            Console.WriteLine("Products Available:");
            Console.WriteLine(String.Format("\t{0,3} {1,10} {2,14} {3,14} {4,14} {5,10}", "ID", "Name", "ProductCode", "Manufacturer", "SellingPrice", "Quantity"));
            var Products = RepoDb.GetAll<BasicProduct>().Values;
            foreach (BasicProduct product in Products)
            {
                int quantity = RepoDb.Get<Inventory>(product.ProductCode).Quantity;
                Console.Write(product);
                Console.Write(String.Format(" {0,10}\n",quantity));
            }
            Console.WriteLine();
        }
    }
}