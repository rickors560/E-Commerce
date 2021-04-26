using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DBManager<T> : IDBManager<T> where T : IItem
    {
        public static Dictionary<int, T> Items { get; set; }
        public void Add(T item)
        {
            if (item != null)
            {
                Items.Add(item.ID, item);
                Console.WriteLine("Item added!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Item Not Added!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void Delete(int id)
        {
            if (Items.ContainsKey(id))
            {
                Items.Remove(id);
                Console.WriteLine("Item Deleted!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Item Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        public void Update(int id)
        {
            if (Items.ContainsKey(id))
            {
                Console.Write($"Enter Name of Item for '{Items[id].Name}':");
                Items[id].Name = Console.ReadLine();
                Console.WriteLine("Item Updated Successfully!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Item Not Found!!");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
    }
}
