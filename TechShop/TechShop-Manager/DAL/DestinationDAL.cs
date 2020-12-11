using System.Collections.Generic;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    public class DestinationDAL
    {
        static ShopContext _ctx = new ShopContext();

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
