using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS
{
    public partial class Customer
    {
        public static List<Customer> GetAll() {
            return CustomerDAL.GetAll();
        }

        public static Customer GetOne(int id)
        {
            return CustomerDAL.GetOne(id);
        }
    }
}
