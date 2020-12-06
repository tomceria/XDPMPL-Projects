using System.Collections.Generic;
using System.Linq;
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

        public TodoTaskController(ITodoTaskService todoTaskService, IStaffService staffService)
        {
            _todoTaskService = todoTaskService;
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var user = _staffService.GetCurrentUser(User);
            var userStaff = user.Staff;

            var todoTasks = _todoTaskService.GetTodoTasks(userStaff);

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

        public IActionResult View(int id)
        {
            /*
             * Get TodoTask by id
             */
            var todoTask = _todoTaskService.GetOneTodoTask(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            /*
             * Check if this task is assigned to Current User
             */
            var user = _staffService.GetCurrentUser(User);
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
             * Get TodoTask by id
             */
            var todoTask = _todoTaskService.GetOneTodoTask((int) id);
            if (todoTask == null)
            {
                return NotFound();
            }

            var user = _staffService.GetCurrentUser(User);

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
            var staffs = _staffService.GetAllStaffs();

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
        public IActionResult Create([Bind("NewTaskName")] TodoTaskIndexVm viewModel)
        {
            var name = viewModel.NewTaskName;

            if (name == null || name.Trim().Equals(""))
            {
                return RedirectToAction("Index");
            }

            var user = _staffService.GetCurrentUser(User);

            var todoTask = _todoTaskService.AddTodoTask(name, user.Staff, user.Staff);

            return RedirectToAction("Edit", new {id = todoTask.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("TodoTask,TodoTaskStaffId,TodoTaskPartnerIds")]
            TodoTaskEditVm viewModel
        )
        {
            TodoTask todoTask = viewModel.TodoTask;

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _todoTaskService.UpdateTodoTask(todoTask, viewModel.TodoTaskPartnerIds);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete([Bind("TodoTaskId,WillComplete")] TodoTaskCompleteVm viewModel)
        {
            var todoTaskId = viewModel.TodoTaskId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("View", new {id = todoTaskId});
            }

            var todoTask = _todoTaskService.GetOneTodoTask(todoTaskId);
            _todoTaskService.CompleteTodoTask(todoTask);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id")] TodoTask todoTask)
        {
            _todoTaskService.RemoveTodoTask(todoTask);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(
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
            var todoTask = _todoTaskService.GetOneTodoTask(todoTaskId);
            var user = _staffService.GetCurrentUser(User);

            Comment comment = new Comment(content, todoTask, user.Staff);
            _todoTaskService.AddComment(comment);

            /*
             * Redirect to the same page
             */
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}