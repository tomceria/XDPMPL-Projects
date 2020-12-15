using System.Collections.Generic;
using TechShop_Manager.Common.Utilities;
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

        public static void DeleteOne(int id)
        {
            ComboDAL.DeleteOne(id);
        }

        public Combo Add()
        {
            ComboDAL.AddOne(this);

            return this;
        }

        public void Update()
        {
            ComboDAL.UpdateOne(this);
        }
    }
}