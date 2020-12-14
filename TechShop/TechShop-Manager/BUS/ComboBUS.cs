using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Combo
    {
        public static List<Combo> GetAll()
        {
            return ComboDAL.GetAll();
        }

        public static Combo GetOne(int id)
        {
            return ComboDAL.GetOne(id);
        }

        public static Combo CreateOne(Combo combo)
        {
            return ComboDAL.CreateOne(combo);
        }

        public static void UpdateOne(Combo combo)
        {
            ComboDAL.UpdateOne(combo);
        }

        public static void DeleteOne(int id)
        {
            ComboDAL.DeleteOne(id);
        }
    }
}
