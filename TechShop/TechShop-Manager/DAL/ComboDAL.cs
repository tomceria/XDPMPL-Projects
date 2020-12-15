using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            var products = _ctx.Combos
                .Where(o => o.IsHidden == false)
                .ToList();

            return products;
        }

        public static Combo GetOne(int id)
        {
            return _ctx.Combos.Find(id);
        }

        public static Combo AddOne(Combo item)
        {
            _ctx.Combos.Add(item);
            _ctx.SaveChanges();

            return item;
        }

        public static Combo UpdateOne(Combo item)
        {
            _ctx.Entry(item).State = EntityState.Modified;

            _ctx.SaveChanges();

            return item;
        }

        public static void DeleteOne(int id)
        {
            var product = _ctx.Combos.Find(id);

            if (product != null)
            {
                product.IsHidden = true;

                _ctx.Entry(product).State = EntityState.Modified;
            }

            _ctx.SaveChanges();
        }
    }
}