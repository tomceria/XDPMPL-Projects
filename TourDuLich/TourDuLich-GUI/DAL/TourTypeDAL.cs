using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL
{
    class TourTypeDAL
    {
        static TourContext _ctx = new TourContext();

        public static List<TourType> GetAll()
        {
            List<TourType> result = _ctx.Set<TourType>()
                .Include(o => o.Tours)
                .ToList();

            return result;
        }
        public static TourType GetOne(int id)
        {
            var _ctx = new TourContext();

            TourType result = _ctx.Set<TourType>()
                .FirstOrDefault(o => o.ID == id);

            return result;
        }
    }
}
