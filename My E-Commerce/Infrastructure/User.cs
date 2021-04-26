using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class User : IItem
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
        public HashSet<Product> Cart { get; set; }
        public User()
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
            this.Cart = new HashSet<Product>();
        }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,10}    {2}", this.ID, this.Name, this.Type);
        }
    }
}