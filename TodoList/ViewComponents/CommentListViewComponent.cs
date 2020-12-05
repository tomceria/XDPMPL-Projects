using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;

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
            var comments = await _todoTaskService.GetComments(todoTask);
            
            /*
             * Construct ViewModel
             */
            var viewModel = new TodoTaskCommentListVm
            {
                TodoTaskId = todoTask.Id,
                Comments = comments,
                CurrentStaff = staff
            };
            return View(viewModel);
        }
    }
}