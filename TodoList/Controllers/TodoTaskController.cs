using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;
using TaskStatus = TodoList.Models.TaskStatus;

namespace TodoList.Controllers
{
    [Authorize]
    public class TodoTaskController : Controller
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IStaffService _staffService;
        private readonly IAccountService _accountService;

        public TodoTaskController(ITodoTaskService todoTaskService, IStaffService staffService,
            IAccountService accountService)
        {
            _todoTaskService = todoTaskService;
            _staffService = staffService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _accountService.GetCurrentUser(User);
            var userStaff = user.Staff;

            var todoTasks = await _todoTaskService.GetTodoTasks(userStaff);

            var assignedTodoTasks = todoTasks["assigned"]
                .Where(o => o.Status != TaskStatus.Completed).ToList();
            var associatedTodoTasks = todoTasks["associated"]
                .Where(o => o.Status != TaskStatus.Completed).ToList();
            var publicTodoTasks = todoTasks["public"]
                .Where(o => o.Status != TaskStatus.Completed).ToList();
            var otherTodoTasks = todoTasks["other"]
                .Where(o => o.Status != TaskStatus.Completed).ToList();
            var completedTodoTasks = todoTasks.Values.Aggregate(
                new List<TodoTask>(),
                (arr, next) =>
                {
                    var todos = next.Where(o => o.Status == TaskStatus.Completed);
                    var newArr = arr.Concat(todos).ToList();
                    return newArr;
                }
            );

            /*
             * EditableTodoTaskIds, for show/hide Edit link
             */
            var allTasks = assignedTodoTasks
                .Concat(associatedTodoTasks)
                .Concat(publicTodoTasks)
                .Concat(otherTodoTasks);

            List<int> editableTodoTaskIds;
            if (User.IsInRole("Leader"))
            {
                editableTodoTaskIds = allTasks.Select(o => o.Id).ToList();
            }
            else
            {
                editableTodoTaskIds = allTasks
                    .Where(o => o.CreatedById == user.StaffId)
                    .Select(o => o.Id)
                    .ToList();
            }

            /*
             * Construct ViewModel
             */
            var viewModel = new TodoTaskIndexVm
            {
                AssignedTodoTasks = assignedTodoTasks,
                AssociatedTodoTasks = associatedTodoTasks,
                PublicTodoTasks = publicTodoTasks,
                OtherTodoTasks = otherTodoTasks,
                CompletedTodoTasks = completedTodoTasks,
                EditableTodoTaskIds = editableTodoTaskIds
            };
            return View(viewModel);
        }

        public async Task<IActionResult> View(int id)
        {
            /*
             * Get TodoTask by id
             */
            var todoTask = await _todoTaskService.GetOneTodoTask(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            /*
             * Check if this task is assigned to Current User
             */
            var user = await _accountService.GetCurrentUser(User);
            bool isAssignedToMe = user.Staff.Id == todoTask.StaffId;
            bool isCreatedByMe = user.Staff.Id == todoTask.CreatedById;

            /*
             * Constructs ViewModel
             */
            var viewModel = new TodoTaskViewVm
            {
                TodoTask = todoTask,
                IsAssignedToMe = isAssignedToMe,
                IsCreatedByMe = isCreatedByMe,
                CurrentStaff = user.Staff
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
             * Get TodoTask by id
             */
            var todoTask = await _todoTaskService.GetOneTodoTask((int) id);
            if (todoTask == null)
            {
                return NotFound();
            }

            var user = await _accountService.GetCurrentUser(User);

            /*
             * User must be the creator to edit Task
             * User can edit all Tasks if they're a Leader
             */
            if (!User.IsInRole("Leader") && user.StaffId != todoTask.CreatedById)
            {
                return Forbid();
            }

            /*
             * Get Staffs and Exclude TodoTask.Staff out of Staff list
             */
            var staffs = await _staffService.GetAllStaffs();

            /*
             * Constructs ViewModel
             */
            var selectedStaffIds = todoTask.TodoTaskPartners != null
                ? todoTask.TodoTaskPartners.Select(o => o.StaffId).ToArray()
                : new int[] { };
            var viewModel = new TodoTaskEditVm
            {
                TodoTask = todoTask,
                Staffs = staffs.ToList(),
                TodoTaskPartnerIds = selectedStaffIds,
                CurrentStaff = user.Staff
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewTaskName")] TodoTaskIndexVm viewModel)
        {
            var name = viewModel.NewTaskName;

            if (name == null || name.Trim().Equals(""))
            {
                return RedirectToAction("Index");
            }

            var user = await _accountService.GetCurrentUser(User);

            var todoTask = _todoTaskService.CreateTodoTask(name, user.Staff, user.Staff);
            _todoTaskService.AddTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Edit", new {id = todoTask.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("TodoTask,TodoTaskStaffId,TodoTaskPartnerIds")]
            TodoTaskEditVm viewModel
        )
        {
            TodoTask todoTask = viewModel.TodoTask;

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _todoTaskService.UpdateTodoTask(todoTask, viewModel.TodoTaskPartnerIds);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete([Bind("TodoTaskId,WillComplete")] TodoTaskCompleteVm viewModel)
        {
            var todoTaskId = viewModel.TodoTaskId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("View", new {id = todoTaskId});
            }

            var todoTask = await _todoTaskService.GetOneTodoTask(todoTaskId);
            _todoTaskService.CompleteTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([Bind("Id")] TodoTask todoTask)
        {
            _todoTaskService.DeleteTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(
            [Bind("NewCommentContent,TodoTaskId")] TodoTaskCommentListVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                /*
                 * Redirect to the same page
                 */
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var (content, todoTaskId) = viewModel;
            var todoTask = await _todoTaskService.GetOneTodoTask(todoTaskId);
            var user = await _accountService.GetCurrentUser(User);

            Comment comment = _todoTaskService.CreateComment(content, todoTask, user.Staff);
            _todoTaskService.AddComment(comment);
            await _todoTaskService.Save();

            /*
             * Redirect to the same page
             */
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}