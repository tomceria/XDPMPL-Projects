using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected ShopContext Context => DbContext as ShopContext;

        public ProductRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Context.Products.OrderBy(p => p.Id);
        }

        public Product GetOneProduct(int id)
        {
            return Context.Products.Find(id);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return Context.ProductTypes;
        }
    }
}