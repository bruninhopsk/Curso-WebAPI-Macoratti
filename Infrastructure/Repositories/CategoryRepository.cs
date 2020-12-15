using System.Collections.Generic;
using System.Linq;
using Domain;
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

        public List<Category> GetProducts()
        {
            return Context.Category.AsNoTracking().Include(x => x.Products).ToList();
        }
    }
}