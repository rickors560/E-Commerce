using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ECommerceApp.Database.Products;
using ECommerceApp.Database.Users;

namespace ECommerceApp.Database
{
    public class RepoDb
    {
        private static Dictionary<Type, object> Items { get; set; }
        private static Dictionary<string, User> Users { get; set; }
        private static Dictionary<string, BasicProduct> Products { get; set; }
        private static Dictionary<string, Inventory> Inventories { get; set; }
        static RepoDb()
        {
            Users = new Dictionary<string, User>(){ 
                { "admin", new Admin() { UserName = "admin", Password = "admin" } },
                { "manager", new Manager() { UserName = "manager", Password = "qwerty" } },
                { "ritik", new Customer() { UserName = "ritik", Password = "123" } }
            }; 
            Products = new Dictionary<string, BasicProduct>(); 
            Inventories = new Dictionary<string, Inventory>(); 
            Items = new Dictionary<Type, object>();
            Items.Add(typeof(User), Users);
            Items.Add(typeof(BasicProduct), Products);
            Items.Add(typeof(Inventory), Inventories);
        }
        public static bool Add<T>(T record, string key)
        {
            if (!Items.ContainsKey(typeof(T))){
                return false;
            }
            #region "Using Method Reflection"
            //Using Method Reflection
            //MethodInfo add = Items[record.GetType()].GetType().GetMethods().Single(method => method.Name == "Add");
            //MethodInfo add = Items[record.GetType()].GetType().GetMethod("Add");
            //add.Invoke(Items[record.GetType()], new object[] { key, record });
            #endregion

            //Using Type Casting
            var item = (Dictionary<string, T>)Items[typeof(T)];
            if (item.ContainsKey(key))
            {
                return false;
            }
            item.Add(key, record);
            return true;
        }

        #region "Remove-Using Method Reflection"
        //public bool Remove(Type type, string key)
        //{
        //    //Remove-Using Method Reflection
        //    if (!Items.ContainsKey(type))
        //    {
        //        return false;
        //    }
        //    //With Method Reflection
        //    MethodInfo containskey = Items[type].GetType().GetMethod("ContainsKey");
        //    if (!(bool)containskey.Invoke(Items[type], new object[] { key }))
        //    {
        //        return false;
        //    };
        //    //MethodInfo remove = Items[type].GetType().GetMethods().Single(method => method.Name == "Remove" && method.GetParameters().Length == 1);
        //    MethodInfo remove = Items[type].GetType().GetMethod("Remove", new[] { typeof(string) });
        //    remove.Invoke(Items[type], new object[] { key });
        //    return true;
        //}
        #endregion

        public static bool Remove<T>(string key) 
        {
            //Remove-Using Type Casting
            if (!Items.ContainsKey(typeof(T)))
            {
                return false;
            }
            var item = (Dictionary<string, T>)Items[typeof(T)];
            if (!item.ContainsKey(key))
            {
                return false;
            }
            item.Remove(key);
            return true;
        }
        public static T Get<T>(string key) where T: BaseRecordType
        {
            if (!Items.ContainsKey(typeof(T)))
            {
                return null;
            }
            var item = (Dictionary<string, T>)Items[typeof(T)];
            if (!item.ContainsKey(key)) {
                return null;
            }
            return item[key];
        }
        public static Dictionary<string, T> GetAll<T>()
        {
            if (!Items.ContainsKey(typeof(T)))
            {
                return null;
            }
            return (Dictionary<string, T>)Items[typeof(T)];
        }
    }
}