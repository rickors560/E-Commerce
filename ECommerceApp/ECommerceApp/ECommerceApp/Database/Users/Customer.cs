using ECommerceApp.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database.Users
{
    public class Customer : User
    {
        public Dictionary<string, int> Cart { get; set; }
        public Customer()
        {
            this.UserType = UserTypes.Customer;
            this.Cart = new Dictionary<string, int>();
        }
    }
}