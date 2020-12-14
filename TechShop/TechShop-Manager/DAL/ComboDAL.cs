using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    public class ComboDAL
    {
        static ShopContext _ctx = new ShopContext();

        public ComboDAL()
        {
            _ctx = new ShopContext();
        }

        public static List<Combo> GetAll()
        {
            var combos = _ctx.Combos.ToList();
            return combos;
        }

        public static Combo GetOne(int id)
        {
            return _ctx.Combos.FirstOrDefault(o => o.Id == id);
        }

        public static Combo CreateOne(Combo combo)
        {
            _ctx.Entry(combo).State = EntityState.Added;
            _ctx.SaveChanges();

            return combo;
        }

        public static void UpdateOne(Combo combo)
        {
            _ctx.Entry(combo).State = EntityState.Modified;

            List<ComboDetail> ComboDetails = combo.ComboDetails.ToList();
            List<ComboDetail> ogComboDetails = _ctx.ComboDetails.Where(o => o.ComboId == combo.Id).ToList();

            foreach (ComboDetail ogComboDetail in ogComboDetails)
            {
                if (ComboDetails.FirstOrDefault(o => o.ComboId == ogComboDetail.ComboId) == null)
                {
                    _ctx.Entry(ogComboDetail).State = EntityState.Deleted;
                }
            }

            foreach (ComboDetail ComboDetail in ComboDetails)
            {
                if (ogComboDetails.FirstOrDefault(o => o.ComboId == ComboDetail.ComboId) == null)
                {
                    _ctx.Entry(ComboDetail).State = EntityState.Added;
                }
                else
                {
                    _ctx.Entry(ComboDetail).State = EntityState.Modified;
                }
            }

            _ctx.SaveChanges();
        }

        public static void DeleteOne(int id)
        {
            Combo combo = _ctx.Combos.FirstOrDefault(o => o.Id == id);
            combo.IsHidden = true;
            _ctx.SaveChanges();
        }

    }
}
