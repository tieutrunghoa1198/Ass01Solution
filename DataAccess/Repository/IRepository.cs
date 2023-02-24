using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
