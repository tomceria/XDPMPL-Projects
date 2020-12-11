using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class CostType
    {
        public static List<CostType> GetAll() {
            return CostTypeDAL.GetAll();
        }

        public static CostType GetOne(int id)
        {
            return CostTypeDAL.GetOne(id);
        }
    }
}
