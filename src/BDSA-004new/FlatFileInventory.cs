using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using DesignPatterns;

namespace DesignPatterns
{
    class FlatFileInventory<T> : IData<T> where T : IEntity 
    {
        private readonly string _filename;
        private Dictionary<int, T> _items;
        private bool _disposed;

        public FlatFileInventory(string filename)
        {
            _filename = filename;
            if (!Load()) _items = new Dictionary<int, T>();
        }

        public int Create(T item)
        {
            lock (_items)
            {
                if (_disposed) throw new ObjectDisposedException(ToString());
                if (_items.ContainsKey(item.Id)) throw new InvalidOperationException("The item already exist");
                item.Id = _items.Any() ? _items.Max(t => t.Key) + 1 : 1;
                _items.Add(item.Id, item);

                if (Save()) return item.Id;

                _items.Remove(item.Id);
                throw new InvalidOperationException("The item was not be created");
            }
        }

        public T Read(int id)
        {
            lock (_items)
            {
                if (_disposed) throw new ObjectDisposedException(ToString());
                if (_items.ContainsKey(id)) return _items[id];
                throw new InvalidOperationException("The item does not exist");
            }
        }

        public IEnumerable<T> Read()
        {
            lock (_items)
            {
                if (_disposed) throw new ObjectDisposedException(ToString());
                return _items.Values.OfType<T>().ToList();
            }
        }

        public void Update(T item)
        {
            lock (_items)
            {
                if (_disposed) throw new ObjectDisposedException(ToString());
                if (!_items.ContainsKey(item.Id))
                    throw new InvalidOperationException("The item does not already exist");

                _items.Remove(item.Id);
                _items.Add(item.Id, item);

                if (Save()) return;

                if (Load()) throw new InvalidOperationException("The item was not be created");
                Dispose();
                throw new InvalidOperationException("The data repo could not recover from error and was disposed");
            }
        }

        public void Delete(T item)
        {

            lock (_items)
            {
                if (_disposed) throw new ObjectDisposedException(ToString());
                if (!_items.ContainsKey(item.Id))
                    throw new InvalidOperationException("The item does not already exist");
                _items.Remove(item.Id);

                if (Save()) return;
                if (Load()) throw new InvalidOperationException("The item was not be created");
                Dispose();
                throw new InvalidOperationException("The data repo could not recover from error and was disposed");
            }
        }

           private bool Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_items);
                File.WriteAllText(_filename, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Load()
        {
            try
            {
                _items = JsonConvert.DeserializeObject<Dictionary<int, T>>(File.ReadAllText(_filename));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void Dispose()
        {
            _disposed = true;
        }
    }
}
