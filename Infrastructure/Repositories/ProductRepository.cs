using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Models;
using Domain.Pagination;
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

        public PagedList<Product> GetProducts(ProductsParameters parameters)
        {
            var query = GetAll().AsQueryable();

            return PagedList<Product>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
        }
    }
}