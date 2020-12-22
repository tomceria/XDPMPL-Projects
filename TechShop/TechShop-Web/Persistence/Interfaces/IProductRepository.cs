using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Persistence.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductType> GetProductTypes();
        void AddQuantityLogs(List<QuantityLog> quantityLogs);
        QuantityLog GetLatestQuantityLogBy(int productId);
    }
}