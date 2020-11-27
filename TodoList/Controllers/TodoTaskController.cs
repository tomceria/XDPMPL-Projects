using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public TodoTaskController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
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

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit(int? id)
        {
            // Get Staff
            if (id == null)
            {
                return NotFound();
            }

            var todoTask = await _todoTaskService.GetOneTodoTask((int) id);
            if (todoTask == null)
            {
                return NotFound();
            }

            // Constructs ViewModel
            var viewModel = new TodoTaskEditVm
            {
                TodoTask = todoTask
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            var todoTask = await _todoTaskService.CreateTodoTask(name);
            _todoTaskService.AddTodoTask(todoTask);
            await _todoTaskService.Save();

            return RedirectToAction("Edit", new {id = todoTask.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind("Id,Name,StartDate,EndDate,Status,Access,StaffId")]
            TodoTask todoTask
        )
        {
            if (!ModelState.IsValid)
            {
                return View(
                    new TodoTaskEditVm {TodoTask = todoTask}
                );
            }

            _todoTaskService.UpdateTodoTask(todoTask);
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