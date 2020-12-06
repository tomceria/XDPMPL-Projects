using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext;

        public Repository(DbContext context)
        {
            DbContext = context;
        }
        
        public virtual T GetBy(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbContext.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            DbContext.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }
    }
}