using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database.Products
{
    public class BasicProduct: BaseRecordType
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Manufacturer { get; set; }
        public int SellingPrice { get; set; }
        public BasicProduct()
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
        }
        public BasicProduct(BasicProduct product)
        {
            this.ID = product.ID;
            this.Name = product.Name;
            this.ProductCode = product.ProductCode;
            this.Manufacturer = product.Manufacturer;
            this.SellingPrice = product.SellingPrice;
        }
        public override string ToString()
        {
            return String.Format("\t{0,3} {1,10} {2,14} {3,14} {4,14}", this.ID, this.Name, this.ProductCode, this.Manufacturer, "$ " + this.SellingPrice);
        }
    }
}