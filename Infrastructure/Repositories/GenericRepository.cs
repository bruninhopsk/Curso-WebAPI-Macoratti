using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDataContext Context { get; }

        public GenericRepository(AppDataContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}