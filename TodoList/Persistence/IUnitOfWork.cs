using System;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence
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