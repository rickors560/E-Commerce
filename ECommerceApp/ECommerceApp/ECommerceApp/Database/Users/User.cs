using ECommerceApp.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database.Users
{
    public class User : BaseRecordType
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
        public User()
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
        }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,10} {2,10}  {3,10}", this.ID, this.UserName, this.Password, this.UserType);
        }
    }
}