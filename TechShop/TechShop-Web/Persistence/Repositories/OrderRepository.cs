using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;


namespace TechShop-Web.Persistence.Repositories
{
    public class OrderRepository : Repository<Order> , IOrderRepóitory
    {
        protected ShopContext Context => DbContext as ShopContext;
        
    }
}
