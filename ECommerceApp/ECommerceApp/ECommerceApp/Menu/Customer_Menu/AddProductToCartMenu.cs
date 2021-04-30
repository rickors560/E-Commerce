using ECommerceApp.Auth;
using ECommerceApp.Database;
using ECommerceApp.Database.Products;
using ECommerceApp.Database.Users;
using ECommerceApp.Menu.Manager_Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Menu.Customer_Menu
{
    internal class AddProductToCartMenu
    {
        internal void ShowAddProductToCartMenu() {
            Console.Clear();
            string oldpath = CustomerMenu.path;
            CustomerMenu.path += " -> Add Product To Cart";
            Console.WriteLine($"\n\t\t{CustomerMenu.path}\n");
            var displayProducts = new DisplayProducts();
            displayProducts.ShowDisplayProducts();
            Console.Write("Enter Product Code To Cart: ");
            string productcode = Console.ReadLine();
            if (RepoDb.GetAll<BasicProduct>().ContainsKey(productcode))
            {
                Console.Write("Enter Quantity:");
                int quantity;
                if (Int32.TryParse(Console.ReadLine(), out quantity))
                {
                    if (quantity > 0)
                    {
                        if (quantity > RepoDb.Get<Inventory>(productcode).Quantity)
                        {
                            Console.WriteLine("Quantity not Available. Adding Maximum Quantity Available.");
                            quantity = RepoDb.Get<Inventory>(productcode).Quantity;
                        }
                        RepoDb.Get<Inventory>(productcode).Quantity -= quantity;
                        var customer = (Customer)AuthManager.LoggedInUser;
                        if (customer.Cart.ContainsKey(productcode))
                        {
                            customer.Cart[productcode] += quantity;
                        }
                        else
                        {
                            customer.Cart.Add(productcode, quantity);
                        }
                        Console.WriteLine("Added To Cart!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Quantity!!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Quantity!!");
                }
            }
            else {
                Console.WriteLine("Invalid Product Code!!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            CustomerMenu.path = oldpath;
        }
    }
}