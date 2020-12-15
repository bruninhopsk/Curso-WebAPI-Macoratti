using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using Infrastructure.EntityFramework.Context;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private AppDataContext Context { get; }

        public ProductRepository(AppDataContext context) : base(context)
        {
            Context = context;
        }

        public List<Product> GetProductsByPrice()
        {
            return GetAll().OrderBy(x => x.Price).ToList();
        }
    }
}