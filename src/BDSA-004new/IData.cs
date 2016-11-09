using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    public interface IData<T> where T : IEntity
    {
        int Create(T item);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(T item);
        void Delete(T item);
        //bool Save();
        //bool Load();
        void Dispose();
    }
}