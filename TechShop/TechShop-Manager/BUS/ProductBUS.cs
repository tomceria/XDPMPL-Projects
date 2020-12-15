using System;
using System.Collections.Generic;
using TechShop_Manager.Common.Utilities;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Product
    {
        public static List<Product> GetAll()
        {
            return ProductDAL.GetAll();
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
    }
}