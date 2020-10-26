using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.Models
{
    public partial class Staff
    {
        public static List<Staff> GetAll() {
            return StaffDAL.GetAll();
        }

        public static Staff GetOne(int id)
        {
            return StaffDAL.GetOne(id);
        }
    }
}
