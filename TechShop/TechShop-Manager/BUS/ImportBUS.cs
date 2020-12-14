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

        public Import Add()
        {
            return ImportDAL.AddOne(this);
        }

        public void Update()
        {
            ImportDAL.UpdateOne(this);
        }
    }
}