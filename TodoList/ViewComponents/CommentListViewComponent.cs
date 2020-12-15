using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;
#pragma warning disable 1998

namespace TodoList.ViewComponents
{
    public class CommentListViewComponent : ViewComponent
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IAccountService _accountService;

        public CommentListViewComponent(ITodoTaskService todoTaskService, IAccountService accountService)
        {
            _todoTaskService = todoTaskService;
            _accountService = accountService;
        }

        public async Task<IViewComponentResult> InvokeAsync(TodoTask todoTask, Staff staff)
        {
            var comments = _todoTaskService.GetComments(todoTask);
            
            /*
             * Construct ViewModel
             */
            var viewModel = new TodoTaskCommentListVm
            {
                TodoTaskId = todoTask.Id,
                Comments = comments,
                CurrentStaff = staff
            };
            
            /*
             * Disable this line for ReSharper since it couldnt detect Views/TodoTask/Components/CommentList/Default
             */
            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return View(viewModel);
        }
    }
}