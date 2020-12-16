using System.Collections.Generic;
using System.Security.Claims;
using TechShop_Web.Models;

namespace TechShop_Web.Services.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetOneProduct(int id);
        IEnumerable<ProductType> GetProductTypes();
        // void AddProduct(Product product);
        // void UpdateProduct(Product product);
        // void RemoveProduct(Product product);
    }
}