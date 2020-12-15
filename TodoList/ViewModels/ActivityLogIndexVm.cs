using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class ActivityLogIndexVm
    {
        public IEnumerable<ActivityLog> ActivityLogs { get; set; }
    }
}