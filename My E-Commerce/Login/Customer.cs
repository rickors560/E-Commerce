using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoginManager
{
    public static class Customer
    {
        public static void ShowCustomers()
        {
            bool exit = false;
            if (InventoryDB.Items.Count < 1)
            {
                Console.WriteLine($"\n\t\t-------------------Welcome {Login.LoggedInUser.Name}-------------------\n");
                Console.WriteLine("No Products Available!!");
                Console.WriteLine("Press any key to Login as Admin....");
                Console.ReadKey();
                return;
            }
            while (!exit)
            {
                Console.WriteLine($"\n\t\t-------------------Welcome {Login.LoggedInUser.Name}-------------------\n");
                Login.InventoryDB.DisplayProducts();
                Console.WriteLine("\na. Add a Product to Cart");
                Console.WriteLine("b. Proceed to CheckOut");
                Console.WriteLine("c. LogOut\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        AddProductToCart();
                        break;
                    case "b":
                        exit = CheckOut(exit);
                        break;
                    case "c":
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
        public static void AddProductToCart()
        {
            Console.Write("Enter ID of Product:");
            int id;
            if (Int32.TryParse(Console.ReadLine(), out id))
            {
                if (id > 0)
                {
                    if (InventoryDB.Items.ContainsKey(id))
                    {
                        Console.Write("Enter Quantity:");
                        int quantity;
                        if (Int32.TryParse(Console.ReadLine(), out quantity))
                        {
                            if (quantity > 0)
                            {
                                if (quantity > InventoryDB.Items[id].Quantity)
                                {
                                    Console.WriteLine("Quantity not Available. Adding Maximum Quantity Available.");
                                    quantity = InventoryDB.Items[id].Quantity;
                                }
                                try
                                {
                                    Login.LoggedInUser.Cart.Single(product => product.ID == id).Quantity += quantity;
                                }
                                catch (System.InvalidOperationException)
                                {
                                    Product cartProduct = new Product(InventoryDB.Items[id]);
                                    cartProduct.Quantity = quantity;
                                    Login.LoggedInUser.Cart.Add(cartProduct);
                                }
                                Console.WriteLine("Added To Cart!!");
                                Login.InventoryDB.UpdateQuantity(id, quantity);
                                Console.WriteLine("Press any key to continue....");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Quantity");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else {
                        Console.WriteLine("Invalid ID");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                    }
                }
                else {
                    Console.WriteLine("Invalid ID");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid ID");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public static bool CheckOut(bool exit)
        {
            Console.WriteLine($"\n\t......................");
            int totalAmount = 0;
            Console.WriteLine(String.Format("\t{0,3} {1,10} {2,11} {3,14} {4,14} {5,10}", "ID", "Name", "ShortCode", "Manufacturer", "SellingPrice", "Quantity"));
            foreach (Product product in Login.LoggedInUser.Cart)
            {
                Console.WriteLine(product);
                totalAmount += product.SellingPrice * product.Quantity;
            }
            Console.WriteLine("\t......................");
            Console.WriteLine($"\tTotal Amount: $ {totalAmount}");
            Console.WriteLine("a. Proceed to CheckOut!");
            Console.WriteLine("b. Back");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Console.WriteLine("\nOrder Placed,Thank You! .............\n");
                    Thread.Sleep(500);
                    Console.WriteLine("\na. Placed New Order");
                    Console.WriteLine("\nb. Exit");
                    switch (Console.ReadLine().ToLower()) {
                        case "a":
                            Login.LoggedInUser.Cart.Clear();
                            break;
                        case "b":
                            exit = true;
                            break;
                        default:
                            exit = true;
                            Console.WriteLine("\nInvalid option!!\n");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadKey();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid option!!\n");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    break;
            }
            return exit;
        }
    }
}