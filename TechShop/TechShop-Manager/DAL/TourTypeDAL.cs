using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    class TourTypeDAL
    {
        static ShopContext _ctx = new ShopContext();

        public static List<TourType> GetAll()
        {
            List<TourType> result = _ctx.Set<TourType>()
                .Include(o => o.Tours)
                .ToList();

            return result;
        }
        public static TourType GetOne(int id)
        {
            var _ctx = new ShopContext();

            TourType result = _ctx.Set<TourType>()
                .FirstOrDefault(o => o.ID == id);

            return result;
        }
    }
}
