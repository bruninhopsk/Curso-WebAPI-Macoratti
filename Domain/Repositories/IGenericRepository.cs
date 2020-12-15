using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(Expression<Func<T, bool>> predicate);
    }
}