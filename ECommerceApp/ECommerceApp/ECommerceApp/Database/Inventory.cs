using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database
{
    public class Inventory : BaseRecordType
    {
        public static int autoIncreamentor = 0;
        public int ID { get; }
        public string ProductCode { get; private set; }
        public int Quantity { get; set; }
        public Inventory(string productcode, int quantity)
        {
            autoIncreamentor++;
            this.ID = autoIncreamentor;
            this.ProductCode = productcode;
            this.Quantity = quantity;
        }
    }
}