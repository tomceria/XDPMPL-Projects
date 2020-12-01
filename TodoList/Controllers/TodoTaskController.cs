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
            var user = await _accountService.GetCurrentUser(User);

            var createdTodoTasks = (await _todoTaskService.GetTodoTasks_Created(user.Staff)).ToList();
            var assignedTodoTasks = (await _todoTaskService.GetTodoTasks_Assigned(user.Staff)).ToList();
            var associatedTodoTasks = (await _todoTaskService.GetTodoTasks_Associated(user.Staff)).ToList();
            var publicTodoTasks = (await _todoTaskService.GetTodoTasks_Public()).ToList();

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
            if (name == null || name.Trim().Equals(""))
            {
                return RedirectToAction("Index");
            }

            var user = await _accountService.GetCurrentUser(User);
            // TODO to be changed 
            var firstStaff = (await _staffService.GetAllStaffs()).First();

            var todoTask = _todoTaskService.CreateTodoTask(name, user.Staff, firstStaff);
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
            _todoTaskService.DeleteTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Index");
        }
    }
}