using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using TaskStatus = TodoList.Models.TaskStatus;

namespace TodoList.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly TodoContext _context;

        public TodoTaskService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTodoTasks()
        {
            return await _context.TodoTasks
                .Include(o => o.Staff)
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff)
                .ToListAsync();
        }

        public async Task<TodoTask> GetOneTodoTask(int id)
        {
            var todoTask = await _context.TodoTasks
                .Include(o => o.TodoTaskPartners).Include(o => o.CreatedBy).Include(o => o.Staff)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
            return todoTask;
        }

        public TodoTask CreateTodoTask(string name, Staff createdBy, Staff assigned)
        {
            TodoTask todoTask = new TodoTask
            {
                Name = name,
                StartDate = DateTime.Now,
                EndDate = (DateTime.Now).AddDays(7),
                Status = TaskStatus.InProgress,
                Access = TaskAccess.IsPrivate,
            };

            todoTask.CreatedById = createdBy.Id;
            todoTask.StaffId = assigned.Id;

            return todoTask;
        }

        public void AddTodoTask(TodoTask todoTask)
        {
            _context.Add(todoTask);
        }

        public void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds)
        {
            _context.Entry(todoTask).State = EntityState.Modified;

            List<TodoTaskPartner> ogTodoTaskPartners = _context.TodoTaskPartners
                .Where(o => o.TodoTaskId == todoTask.Id).ToList();
            List<TodoTaskPartner> todoTaskPartners = todoTaskPartnerIds != null
                ? todoTaskPartnerIds
                    .Select(todoTaskPartnerId => new TodoTaskPartner
                    {
                        TodoTaskId = todoTask.Id, StaffId = todoTaskPartnerId
                    }).ToList()
                : new List<TodoTaskPartner>();

            foreach (TodoTaskPartner ogTodoTaskPartner in ogTodoTaskPartners)
            {
                _context.Entry(ogTodoTaskPartner).State = EntityState.Deleted;
            }

            foreach (TodoTaskPartner todoTaskPartner in todoTaskPartners)
            {
                _context.Entry(todoTaskPartner).State = EntityState.Added;
            }
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Created(Staff staff)
        {
            // var todoTasks = await _context.TodoTasks
            //     .Include(o => o.TodoTaskPartners)
            //     .Where(o => o.Id == staff.Id)
            //     .ToListAsync();

            var todoTasks = (await _context.Staffs
            .Include(o => o.CreatedTodoTasks)
            .Where(o => o.Id == staff.Id)
            .FirstAsync()).CreatedTodoTasks;
            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Assigned(Staff staff)
        {
            var todoTasks = (await _context.Staffs
            .Include(o => o.AssignedTodoTasks)
            .Where(o => o.Id == staff.Id)
            .FirstAsync()).AssignedTodoTasks;
            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Associated(Staff staff)
        {
            var todoTasks = await _context.TodoTasks
                 .Include(o => o.TodoTaskPartners)
                 .Where(o => o.Id == staff.Id)
                 .ToListAsync();
            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Public()
        {
            String isPublic = "isPublic";
            var todoTasks = await _context.TodoTasks
                 .Include(o => o.TodoTaskPartners)
                 .Where(o => o.Access == TaskAccess.IsPublic)
                 .ToListAsync();
            return todoTasks;
        }
        public void DeleteTodoTask(TodoTask todoTask)
        {
            _context.Remove(todoTask);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}