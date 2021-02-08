using System;
using Domain.Repositories;
using Infrastructure.EntityFramework.Context;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDataContext Context { get; }
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(AppDataContext context)
        {
            Context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(Context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(Context);
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}