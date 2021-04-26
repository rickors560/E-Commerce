using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class InventoryDB : DBManager<Product>
    {
        static InventoryDB() {
            Items = new Dictionary<int, Product>();
        }
        public void AddProduct(Product product)
        {
            if (product != null) {
                Items.Add(product.ID, product);
                Console.WriteLine("Product Added!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Product Not Added!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void DeleteProduct(int id)
        {
            if (Items.ContainsKey(id))
            {
                Items.Remove(id);
                Console.WriteLine("Product Deleted!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Product Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void UpdateProduct(int id)
        {
            if (Items.ContainsKey(id))
            {
                Console.WriteLine("\n\ta. Update Name");
                Console.WriteLine("\tb. Update ShortCode");
                Console.WriteLine("\tc. Update Manufacturer");
                Console.WriteLine("\td. Update SellingPrice");
                Console.WriteLine("\te. Update Quantity");
                Console.WriteLine("\tf. Back\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        this.UpdateName(id);
                        break;
                    case "b":
                        this.UpdateShortCode(id);
                        break;
                    case "c":
                        this.UpdateManufacturer(id);
                        break;
                    case "d":
                        this.UpdateSellingPrice(id);
                        break;
                    case "e":
                        this.UpdateQuantity(id);
                        break;
                    case "f":
                        break;
                    default:
                        Console.WriteLine("\n\tInvalid option!!\n");
                        Console.WriteLine("\tPress any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Product Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void UpdateQuantity(int id)
        {
            Console.Write("\tEnter New Quantity:");
            int quantity;
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
            Items[id].Quantity = quantity;
            Console.WriteLine("\nUpdated Quantity!!\n");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void UpdateQuantity(int id, int quantity)
        {
            Items[id].Quantity = Items[id].Quantity - quantity;
        }
        public void UpdateSellingPrice(int id)
        {
            Console.Write("\tEnter New SellingPrice:");
            int sellingprice;
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
            Items[id].SellingPrice = sellingprice;
            Console.WriteLine("\nUpdated Price!!\n");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void UpdateManufacturer(int id)
        {
            Console.Write("\tEnter New Manufacturer:");
            Items[id].Manufacturer = Console.ReadLine();
            Console.WriteLine("\nUpdated Manufacturer!!\n");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void UpdateShortCode(int id)
        {
            Console.Write("\tEnter New ShortCode:");
            Items[id].ShortCode = Console.ReadLine();
            Console.WriteLine("\nUpdated ShortCode!!\n");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void UpdateName(int id)
        {
            Console.Write("\tEnter New Name:");
            Items[id].Name = Console.ReadLine();
            Console.WriteLine("\nUpdated Name!!\n");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public void DisplayProducts() {
            Console.WriteLine("Products Available:");
            Console.WriteLine(String.Format("\t{0,3} {1,10} {2,11} {3,14} {4,14} {5,10}", "ID", "Name", "ShortCode", "Manufacturer", "SellingPrice", "Quantity"));
            foreach (KeyValuePair<int, Product> product in Items) {
                Console.WriteLine(product.Value);
            }
        }
    }
}