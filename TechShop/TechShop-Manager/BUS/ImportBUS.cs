using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Import
    {
        public static List<Import> GetAll()
        {
            return ImportDAL.GetAll();
        }

        public static Import GetOne(int id)
        {
            return ImportDAL.GetOne(id);
        }

        public static void DeleteOne(int id)
        {
            ImportDAL.DeleteOne(id);
        }

        public static void RevertChanges()
        {
            ImportDAL.Reload();
        }

        public Import Add()
        {
            ImportDAL.AddOne(this);

            List<QuantityLog> quantityLogs = new List<QuantityLog>();
            foreach (var importDetail in this.ImportDetails)
            {
                var quantityLog = new QuantityLog()
                {
                    ProductId = importDetail.ProductId,
                    Date = this.Date,
                    Quantity = importDetail.Quantity
                };
                quantityLogs.Add(quantityLog);
            }
            ProductDAL.AddQuantityLogs(quantityLogs);

            return this;
        }

        public void Update()
        {
            ImportDAL.UpdateOne(this);
        }
    }
}