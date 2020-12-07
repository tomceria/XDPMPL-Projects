using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Authorize(Roles = "Leader")]
    public class ActivityLogController : Controller
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public IActionResult Index()
        {
            var activityLogs = _activityLogService.GetAllActivityLogs().ToList();
            
            /*
             * Upper-case first letter of Content
             */
            foreach (var activityLog in activityLogs)
            {
                if (activityLog.Content.Length > 1)
                {
                    activityLog.Content = char.ToUpper(activityLog.Content[0]) + activityLog.Content.Substring(1);
                }
                else
                {
                    // Will never be reached NORMALLY. Just a safety measure
                    activityLog.Content = activityLog.Content.ToUpper();
                }
            }
            
            /*
             * Constructs ViewModel
             */
            var viewModel = new ActivityLogIndexVm
            {
                ActivityLogs = activityLogs
            };
            return View(viewModel);
        }
    }
}