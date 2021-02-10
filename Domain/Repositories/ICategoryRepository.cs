using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProducts();
        PagedList<Category> GetCategories(CategoriesParameters parameters);
    }
}