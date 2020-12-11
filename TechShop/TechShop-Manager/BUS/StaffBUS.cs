using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS {
    public partial class Staff {
        public static List<Staff> GetAll() {
            return StaffDAL.GetAll();
        }

        public static Staff GetOne(int id) {
            return StaffDAL.GetOne(id);
        }
    }
}
