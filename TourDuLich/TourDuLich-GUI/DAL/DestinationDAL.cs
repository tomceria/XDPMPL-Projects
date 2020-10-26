using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.DAL
{
    public class DestinationDAL
    {
        static TourContext _ctx = new TourContext();

        public static List<Destination> GetAll()
        {

            List<Destination> result = _ctx.Set<Destination>().ToList();

            return result;
        }
        public static Destination GetOne(int id)
        {

            Destination result = _ctx.Set<Destination>()                
                .FirstOrDefault(o => o.ID == id);

            return result;
        }

      
    }
}
