using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetProducts();
    }
}