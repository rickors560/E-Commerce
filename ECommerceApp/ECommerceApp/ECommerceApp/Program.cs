using ECommerceApp.Database;
using ECommerceApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ECommerceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> vs = new List<int>();
            //Console.WriteLine(vs.GetType().GetGenericArguments().Single());
            //RepoDb repoDb = new RepoDb();
            //repoDb.Add(new User() { Name = "Ritik"}, "Ritik");
            //Console.WriteLine(repoDb.Add(new User() { Name = "Ritik" }, "Ritik"));
            //Console.WriteLine(RepoDb.Users.First().Value.Name);
            //Console.WriteLine(repoDb.Get<User>("Ritik"));
            MenuManager menuManager = new MenuManager();
            menuManager.CreateMenu();
        }
    }
}
