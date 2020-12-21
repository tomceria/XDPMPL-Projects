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
        
        public ComboRepository(DbContext context) : base(context)
        {
        }
    }
}