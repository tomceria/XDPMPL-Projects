using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface IActivityLogService
    {
        IEnumerable<ActivityLog> GetAllActivityLogs();
        IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId);
        void AddActivityLog(TodoTask todoTask, int staffId, ActivityType activityType);
    }
}