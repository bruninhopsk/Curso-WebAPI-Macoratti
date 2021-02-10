using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Domain.Pagination;
using Domain.Repositories;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private AppDataContext Context { get; }

        public ProductRepository(AppDataContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<Product>> GetProductsByPrice()
        {
            return await GetAll().OrderBy(x => x.Price).ToListAsync();
        }

        public PagedList<Product> GetProducts(ProductsParameters parameters)
        {
            var query = GetAll().AsQueryable();

            return PagedList<Product>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
        }
    }
}