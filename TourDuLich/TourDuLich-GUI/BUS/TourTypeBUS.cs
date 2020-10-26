using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS
{
    public partial class TourType
    {
        public static List<TourType> GetAll() {
            return TourTypeDAL.GetAll();
        }
    }
}
