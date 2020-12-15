using System.Collections.Generic;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS {
    public partial class Staff {
        public static List<Staff> GetAll() {
            return StaffDAL.GetAll();
        }

        public static Staff GetOne(int id) {
            return StaffDAL.GetOne(id);
        }
    }
}
