using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class TourType
    {
        public static List<TourType> GetAll() {
            return TourTypeDAL.GetAll();
        }
    }
}
