using System;
using System.Collections.Generic;

namespace BonusCard.Data
{
    public interface IRepositoriy<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
