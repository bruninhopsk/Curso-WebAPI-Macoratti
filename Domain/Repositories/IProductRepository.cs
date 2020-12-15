using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByPrice();
    }
}