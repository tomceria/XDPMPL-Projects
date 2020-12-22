using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TechShop_Manager.Common.Utilities;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Product
    {
        public static List<Product> GetAll()
        {
            var result = ProductDAL.GetAll();
            foreach (var product in result)
            {
                product.Quantity = ProductDAL.GetLatestQuantityLogBy(product.Id)?.Quantity ?? 0;
            }
            return result;
        }

        public static Product GetOne(int id)
        {
            return ProductDAL.GetOne(id);
        }

        public static void DeleteOne(int id)
        {
            ProductDAL.DeleteOne(id);
        }

        public Product Add()
        {
            this.Slug = string.Join("-", StringUtil.ConvertToUnsign(this.Name).ToLower()); 
            ProductDAL.AddOne(this);
            
            this.Slug = $"{this.Slug}-{this.Id}"; 
            ProductDAL.UpdateOne(this);

            return this;
        }

        public void Update()
        {
            ProductDAL.UpdateOne(this);
        }

        public static void RevertChanges()
        {
            ProductDAL.Reload();
        }
        
        // ProductType

        public static List<ProductType> GetProductTypes()
        {
            return ProductDAL.GetProductTypes();
        }
    }
}