using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Models;
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

        public List<Product> GetProducts(ProductParameters parameters)
        {
            var query = GetAll()
                                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                .Take(parameters.PageSize)
                                .ToList();

            return query;
        }
    }
}