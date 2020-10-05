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
    public class DestinationBUS
    {
        TourContext _ctx = new TourContext();

        public async Task<List<Destination>> GetAll()
        {

            List<Destination> result = await _ctx.Set<Destination>().ToListAsync();
            /*List<Tour> = */

            Console.WriteLine("Count: " + result.Count);

            return result;
        }
        public async Task<Destination> GetOne(int id)
        {


            Destination result = await _ctx.Set<Destination>()                
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }

    }
}
