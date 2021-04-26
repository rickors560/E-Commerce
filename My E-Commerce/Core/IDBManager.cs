using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IDBManager<TItem>
    {
        public void Add(TItem item);
        public void Delete(int id);
        public void Update(int id);
    }
}