using System.Collections.Generic;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByPrice();
        PagedList<Product> GetProducts(ProductsParameters parameters);
    }
}