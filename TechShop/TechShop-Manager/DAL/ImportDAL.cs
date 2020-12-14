using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    public class ImportDAL
    {
        static ShopContext _ctx = new ShopContext();

        public ImportDAL()
        {
            _ctx = new ShopContext();
        }
        
        public static List<Import> GetAll()
        {
            var imports = _ctx.Imports.ToList();

            return imports;
        }
        public static Import GetOne(int id)
        {
            return _ctx.Imports.Find(id);
        }

        public static Import AddOne(Import import)
        {
            // This "item" is unattached => ATTACH!
            _ctx.Entry(import).State = EntityState.Added;

            _ctx.SaveChanges();

            return import;
        }

        public static Import UpdateOne(Import import)
        {
            _ctx.Entry(import).State = EntityState.Modified;    

            _ctx.SaveChanges();

            return import;
        }
        
        public static void DeleteOne(int id) {
            var import = _ctx.Set<Import>()
                .Include(o => o.ImportDetails)
                .First(o => o.Id == id);
            
            _ctx.ImportDetails.RemoveRange(import.ImportDetails);
            
            _ctx.Imports.Remove(import);
            
            _ctx.SaveChanges();
        }

        public static void Reload()
        {
            _ctx = new ShopContext();
        }
    }
}