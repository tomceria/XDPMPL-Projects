using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.Models
{
    public partial class Destination
    {
        public static List<Destination> GetAll() {
            return DestinationDAL.GetAll();
        }
    }
}
