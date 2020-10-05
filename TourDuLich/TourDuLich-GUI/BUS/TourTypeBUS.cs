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
        TourContext _ctx = new TourContext();

        public async Task<List<TourType>> GetAll()
        {
            

            List<TourType> result = await _ctx.Set<TourType>()
                .Include(o => o.Tours)
                .ToListAsync();

            return result;
        }
        public async Task<TourType> GetOne(int id)
        {
            var _ctx = new TourContext();

            TourType result = await _ctx.Set<TourType>()
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }
    }
}
