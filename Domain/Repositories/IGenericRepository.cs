using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
    }
}