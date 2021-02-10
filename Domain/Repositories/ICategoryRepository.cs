using System.Collections.Generic;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetProducts();
        PagedList<Category> GetCategories(CategoriesParameters parameters);
    }
}