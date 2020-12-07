using System.Collections.Generic;
using TodoList.Models;
using TodoList.Persistence;
using TodoList.Services.IService;

namespace TodoList.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<ActivityLog> GetAllActivityLogs()
        {
            return _unitOfWork.ActivityLog.GetAllActivityLogs();
        }

        public IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId)
        {
            return _unitOfWork.ActivityLog.GetActivityLogsByTodoTask(todoTaskId);
        }
    }
}