using ECommerceApp.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database.Users
{
    public class Manager : User
    {
        public Manager()
        {
            this.UserType = UserTypes.Manager;
        }
    }
}