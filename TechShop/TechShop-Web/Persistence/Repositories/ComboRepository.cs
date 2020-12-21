using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
{
    public class ComboRepository : Repository<Combo>, IComboRepository
    {
        protected ShopContext Context => DbContext as ShopContext;
        
        public ComboRepository(ShopContext context) : base(context)
        {
        }
        
        // Overrides

        public override Combo GetBy(int id)
        {
            return Context.Combos
                .Where(o => o.Id == id)
                .Include(o => o.ComboDetails)
                .ThenInclude(o => o.Product)
                .First();
        }
    }
}