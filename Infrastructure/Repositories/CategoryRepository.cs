using System.Collections.Generic;
using System.Linq;
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

        public List<Category> GetProducts()
        {
            return Context.Category.AsNoTracking().Include(x => x.Products).ToList();
        }

        public PagedList<Category> GetCategories(CategoriesParameters parameters)
        {
            var query = GetAll().AsQueryable();

            return PagedList<Category>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
        }
    }
}