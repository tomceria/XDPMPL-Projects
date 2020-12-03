using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;

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
            var userStaff = (await _accountService.GetCurrentUser(User)).Staff;

            var allTasks = await _todoTaskService.GetAllTodoTasks();

            var createdTodoTasks = await _todoTaskService.GetTodoTasks_Created(userStaff);
            var assignedTodoTasks = await _todoTaskService.GetTodoTasks_Assigned(userStaff);
            var associatedTodoTasks = await _todoTaskService.GetTodoTasks_Associated(userStaff);
            var publicTodoTasks = await _todoTaskService.GetTodoTasks_Public();

            /*
             * Construct ViewModel
             */
            var user = await _accountService.GetCurrentUser(User);
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

            var viewModel = new TodoTaskIndexVm
            {
                CreatedTodoTasks = createdTodoTasks,
                AssignedTodoTasks = assignedTodoTasks,
                AssociatedTodoTasks = associatedTodoTasks,
                PublicTodoTasks = publicTodoTasks,
                EditableTodoTaskIds = editableTodoTaskIds
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
                TodoTaskPartnerIds = selectedStaffIds
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
        public async Task<IActionResult> Edit(
            [Bind("TodoTask,TodoTaskStaffId,TodoTaskPartnerIds")]
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
        public async Task<IActionResult> Delete([Bind("Id")] TodoTask todoTask)
        {
            _todoTaskService.DeleteTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }
    }
}