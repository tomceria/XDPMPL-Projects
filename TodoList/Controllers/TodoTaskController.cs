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
            // TODO: Get 4 different lists, use IEnumerable
            var result = (await _todoTaskService.GetAllTodoTasks()).ToList();

            var createdTodoTasks = result;
            var assignedTodoTasks = result;
            var associatedTodoTasks = result;
            var publicTodoTasks = result;

            var viewModel = new TodoTaskIndexVm
            {
                CreatedTodoTasks = createdTodoTasks,
                AssignedTodoTasks = assignedTodoTasks,
                AssociatedTodoTasks = associatedTodoTasks,
                PublicTodoTasks = publicTodoTasks
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
            
            /*
             * Get Staffs and Exclude TodoTask.Staff out of Staff list
             */
            var staffs = await _staffService.GetAllStaffs();
            staffs = staffs.Where(o => o.Id != todoTask.StaffId);

            /*
             * Constructs ViewModel
             */
            var selectedStaffIds = todoTask.TodoTaskPartners != null
                ? todoTask.TodoTaskPartners.Select(o => o.StaffId).ToArray()
                : new int[]{};
            var viewModel = new TodoTaskEditVm
            {
                TodoTask = todoTask,
                StaffSelectList = new SelectList(
                    staffs.ToList(),
                    nameof(Staff.Id),
                    nameof(Staff.FirstName)
                ),
                TodoTaskPartnerIds = selectedStaffIds
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            var user = await _accountService.GetCurrentUser(User);

            var todoTask = _todoTaskService.CreateTodoTask(name, user.Staff);
            _todoTaskService.AddTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Edit", new {id = todoTask.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind("TodoTask,StaffSelectList,TodoTaskPartnerIds")]
            TodoTaskEditVm viewModel
        )
        {
            TodoTask todoTask = viewModel.TodoTask;
            
            if (!ModelState.IsValid)
            {
                return View(
                    new TodoTaskEditVm
                    {
                        TodoTask = todoTask,
                        StaffSelectList = viewModel.StaffSelectList,
                        TodoTaskPartnerIds = viewModel.TodoTaskPartnerIds
                    }
                );
            }

            _todoTaskService.UpdateTodoTask(todoTask, viewModel.TodoTaskPartnerIds);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([Bind("Id")] TodoTask todoTask)
        {
            if (!ModelState.IsValid) return RedirectToAction("Edit", new {id = todoTask.Id});

            _todoTaskService.DeleteTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }
    }
}