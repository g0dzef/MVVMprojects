using MVVMproject.MVVM.Models.Interfaces;
using MVVMproject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Services.Base
{
    public abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private List<T> _items = new List<T>();
        private int _lastId;

        protected RepositoryInMemory() { }

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }
       

        public void Add(T item)
        {
           if (item is null) throw new ArgumentNullException(nameof(item));

           if(_items.Contains(item)) return;

            item.Id = ++_lastId;
            _items.Add(item);
        }

        public bool Delete(T item) => _items.Remove(item);

        public IEnumerable<T> GetAll() => _items;

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Index out of range");

            if (_items.Contains(item)) return;

            var dbItem = ((IRepository<T>)this).Get(id);

            if (dbItem is null) throw new InvalidOperationException("Item does not exist in repository ");

            Update(item, dbItem);
        }

        protected abstract void Update(T Source, T Destination);
    }
}
