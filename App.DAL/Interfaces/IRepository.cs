using System;
using AppDAL.Entities;

namespace AppDAL.Interfaces
{
    public interface IRepository<T> where T : class {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetItemsForListView(int skip, int size);
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}

