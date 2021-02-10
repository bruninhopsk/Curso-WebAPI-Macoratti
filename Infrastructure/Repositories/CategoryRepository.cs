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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private AppDataContext Context { get; }

        public CategoryRepository(AppDataContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<Category>> GetCategoriesWithProducts()
        {
            return await Context.Category.AsNoTracking().Include(x => x.Products).ToListAsync();
        }

        public Task<PagedList<Category>> GetCategories(CategoriesParameters parameters)
        {
            var query = GetAll().AsQueryable();

            return Task.FromResult(PagedList<Category>.ToPagedList(query, parameters.PageNumber, parameters.PageSize));
        }
    }
}