using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Services.IService
{
    public interface IActivityLogService
    {
        IEnumerable<ActivityLog> GetAllActivityLogs();
        IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId);
        void AddActivityLog(TodoTask todoTask, int staffId, ActivityType activityType);
    }
}