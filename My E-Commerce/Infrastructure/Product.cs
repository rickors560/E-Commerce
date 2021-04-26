using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class Product : IItem
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public Product()
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
        }
        public Product(Product product)
        {
            this.ID = product.ID;
            this.Name = product.Name;
            this.ShortCode = product.ShortCode;
            this.Manufacturer = product.Manufacturer;
            this.SellingPrice = product.SellingPrice;
            this.Quantity = product.Quantity;
        }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,10} {2,11} {3,14} {4,14} {5,10}",this.ID,this.Name,this.ShortCode,this.Manufacturer,"$ "+this.SellingPrice,this.Quantity);
        }
    }
}