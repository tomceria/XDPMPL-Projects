using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.Models
{
    public partial class CostType
    {
        public static List<CostType> GetAll() {
            return CostTypeDAL.GetAll();
        }

        public static CostType GetOne(int id)
        {
            return CostTypeDAL.GetOne(id);
        }
    }
}
