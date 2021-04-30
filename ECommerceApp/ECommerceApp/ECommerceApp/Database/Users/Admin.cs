using ECommerceApp.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database.Users
{
    public class Admin : User
    {
        public Admin()
        {
            this.UserType = UserTypes.Admin;
        }
    }
}