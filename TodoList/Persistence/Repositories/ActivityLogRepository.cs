using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence.Repositories
{
    public class ActivityLogRepository : Repository<ActivityLog>, IActivityLogRepository
    {
        protected TodoContext Context => DbContext as TodoContext;

        public ActivityLogRepository(TodoContext context) : base(context)
        {
        }

        public IEnumerable<ActivityLog> GetAllActivityLogs()
        {
            return (
                from activityLog in Context.ActivityLogs
                    .Include(o => o.Staff)
                    .Include(o => o.TodoTask)
                select activityLog
            );
        }

        public IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId)
        {
            return (
                from activityLog in Context.ActivityLogs
                    .Include(o => o.Staff)
                    .Include(o => o.TodoTask)
                where activityLog.TodoTaskId == todoTaskId
                select activityLog
            );
        }
    }
}