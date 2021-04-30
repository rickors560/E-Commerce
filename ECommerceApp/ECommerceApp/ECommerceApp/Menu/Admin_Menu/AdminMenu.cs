using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ECommerceApp.Menu.Admin_Menu
{
    internal class AdminMenu
    {
        internal static string path = "Main Menu -> Admin Menu";
        private Dictionary<string, object> AdminMenus;
        public AdminMenu()
        {
            this.AdminMenus = new Dictionary<string, object>() {
                { "DisplayUsers", new DisplayUsers() },
                { "AddManagerMenu", new AddManagerMenu() },
                { "DeleteUserMenu", new DeleteUserMenu() }
            };
        }
        internal void ShowAdminMenu() {
            Console.Clear();
            bool exit = false;
            while(!exit){
                Console.WriteLine($"\n\t\t{path}\n");
                var displayUsers = (DisplayUsers)this.AdminMenus["DisplayUsers"];
                displayUsers.ShowDisplayUsers();
                Console.WriteLine("a. Add Manager");
                Console.WriteLine("b. Delete User");
                Console.WriteLine("c. LogOut");
                switch (Console.ReadLine().ToLower()) {
                    case "a":
                        var addManagerMenu = (AddManagerMenu)this.AdminMenus["AddManagerMenu"];
                        addManagerMenu.ShowAddManagerMenu();
                        break;
                    case "b":
                        var deleteUserMenu = (DeleteUserMenu)this.AdminMenus["DeleteUserMenu"];
                        deleteUserMenu.ShowDeleteUserMenu();
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