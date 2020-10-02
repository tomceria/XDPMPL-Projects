using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    class TourTypeBUS
    {
        public static async Task<List<TourType>> GetAll()
        {
            using var _ctx = new TourContext();

            List<TourType> result = await _ctx.Set<TourType>()
                .Include(o => o.Tours)
                .ToListAsync();

            return result;
        }
        public static async Task<TourType> GetOne(int id)
        {
            var _ctx = new TourContext();

            TourType result = await _ctx.Set<TourType>()
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }
    }
}
