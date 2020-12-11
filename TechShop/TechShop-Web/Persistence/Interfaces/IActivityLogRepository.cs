using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Persistence.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        IEnumerable<ActivityLog> GetAllActivityLogs();
        IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId);
    }
}