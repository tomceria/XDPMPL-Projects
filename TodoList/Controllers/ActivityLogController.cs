using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
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