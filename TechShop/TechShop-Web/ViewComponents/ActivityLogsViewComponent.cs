using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechShop_Web.Services.IService;

#pragma warning disable 1998

namespace TechShop_Web.ViewComponents
{
    public class ActivityLogsViewComponent : ViewComponent
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogsViewComponent(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int todoTaskId)
        {
            var activityLogs = _activityLogService.GetActivityLogsByTodoTask(todoTaskId).ToList();

            /*
             * Disable this line for ReSharper since it couldnt detect Views/TodoTask/Components/CommentList/Default
             */
            // ReSharper disable Mvc.ViewComponentViewNotResolved
            return View(activityLogs);
        }
    }
}