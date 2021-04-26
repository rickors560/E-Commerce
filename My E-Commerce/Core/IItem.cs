using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IItem
    {
        public int ID { get; }
        public string Name { get; set; }
    }
}
