using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Destination
    {
        public static List<Destination> GetAll() {
            return DestinationDAL.GetAll();
        }
    }
}
