using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    public class ProductDAL
    {
        static ShopContext _ctx = new ShopContext();

        public ProductDAL()
        {
            _ctx = new ShopContext();
        }

        public static List<Product> GetAll()
        {
            var products = _ctx.Products
                .Where(o => o.IsHidden == false)
                // .Include(o => o.ProductType)
                .ToList();

            return products;
        }

        public static Product GetOne(int id)
        {
            return _ctx.Products.Find(id);
        }

        public static Product AddOne(Product item)
        {
            _ctx.Products.Add(item);
            _ctx.SaveChanges();

            return item;
        }

        public static Product UpdateOne(Product item)
        {
            _ctx.Entry(item).State = EntityState.Modified;

            _ctx.SaveChanges();

            return item;
        }

        public static void DeleteOne(int id)
        {
            var product = _ctx.Products.Find(id);

            if (product != null)
            {
                product.IsHidden = true;

                _ctx.Entry(product).State = EntityState.Modified;
            }

            _ctx.SaveChanges();
        }

        public static void Reload()
        {
            _ctx = new ShopContext();
        }
        
        // ProductTypes

        public static List<ProductType> GetProductTypes()
        {
            return _ctx.ProductTypes.ToList();
        }
    }

}