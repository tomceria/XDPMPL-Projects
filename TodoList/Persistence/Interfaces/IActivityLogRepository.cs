using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Persistence.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        IEnumerable<ActivityLog> GetAllActivityLogs();
        IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId);
    }
}