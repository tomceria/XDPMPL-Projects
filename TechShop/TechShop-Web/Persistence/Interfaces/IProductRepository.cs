using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Persistence.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetOneProduct(int id);
        IEnumerable<ProductType> GetProductTypes();
    }
}