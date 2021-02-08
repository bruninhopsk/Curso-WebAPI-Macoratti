using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByPrice();
        List<Product> GetProducts(ProductParameters parameters);
    }
}