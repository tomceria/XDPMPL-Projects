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
        ITodoTaskRepository TodoTask { get; }
        IStaffRepository Staff { get; }
        IActivityLogRepository ActivityLog { get; }
        
        int Complete();
    }
}