using System;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        /*
         * Repositories
         */
        IAccountRepository Account { get; }
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        
        int Complete();
    }
}