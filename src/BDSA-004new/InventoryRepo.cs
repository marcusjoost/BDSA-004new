using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class InventoryRepo<T> : IData<T> where T : IEntity
    {
        private InventoryContext _context;
        public InventoryRepo(InventoryContext context)
        {
            this._context = context;
        }
        public int Create(T item)
        {
            _context.Products.Add(item);
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
