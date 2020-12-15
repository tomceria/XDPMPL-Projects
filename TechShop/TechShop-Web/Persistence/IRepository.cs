using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TechShop_Web.Persistence
{
    public interface IRepository<T>
    {
        T GetBy(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        
        void Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Detach(T entity);
    }
}