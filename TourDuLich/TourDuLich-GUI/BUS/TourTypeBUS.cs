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
            var ctx = new TourContext();

            List<TourType> result = await ctx.Set<TourType>().ToListAsync();

            return result;
        }
        public static async Task<TourType> GetOne(int id)
        {
            var ctx = new TourContext();

            TourType result = await ctx.Set<TourType>()
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }
    }
}
