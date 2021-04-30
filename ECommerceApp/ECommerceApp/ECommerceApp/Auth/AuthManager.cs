using ECommerceApp.Database;
using ECommerceApp.Database.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Auth
{
    public class AuthManager
    {
        public static User LoggedInUser { get; set; }
        private static string UserName { get; set; }
        private static string Password { get; set; }
        public static bool AcceptLoginCreds(string username, string password)
        {
            UserName = username.Trim();
            Password = password.Trim();
            return ValidateUser();
        }
        private static bool ValidateUser()
        {
            if (ValidateUniqueUserName(UserName)) {
                return false;
            }
            if (RepoDb.GetAll<User>()[UserName].Password != Password) {
                return false;
            }
            LoggedInUser = RepoDb.Get<User>(UserName);
            return true;
        }
        public static bool ValidateUniqueUserName(string username) {
            if (RepoDb.GetAll<User>().ContainsKey(username))
            {
                return false;
            }
            return true;
        }
        public static string ReadPassWord()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}