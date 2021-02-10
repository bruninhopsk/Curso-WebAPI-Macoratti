using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByPrice();
        Task<PagedList<Product>> GetProducts(ProductsParameters parameters);
    }
}