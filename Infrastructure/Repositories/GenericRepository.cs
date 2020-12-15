using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            this.SaveChange();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            var entity = Context.Set<T>().AsNoTracking().FirstOrDefault(predicate);

            return entity;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            this.SaveChange();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            this.SaveChange();
        }

        public void SaveChange()
        {
            Context.SaveChanges();
        }
    }
}