using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            return await TodoTaskListQuery().ToListAsync();
        }

        public async Task<TodoTask> GetOneTodoTask(int id)
        {
            var todoTask = await _context.TodoTasks
                .Include(o => o.TodoTaskPartners)
                .Include(o => o.CreatedBy)
                .Include(o => o.Staff)
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
            _context.Entry(todoTask).State = EntityState.Added;
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
                /*
                 * Only add partner if they're not the Assigned staff
                 */
                if (todoTaskPartner.StaffId != todoTask.StaffId)
                {
                    _context.Entry(todoTaskPartner).State = EntityState.Added;
                }
            }
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Created(Staff staff)
        {
            var todoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    where todoTask.CreatedById == staff.Id
                    select todoTask
                ).ToListAsync();

            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Assigned(Staff staff)
        {
            var todoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    where todoTask.StaffId == staff.Id
                    select todoTask
                ).ToListAsync();

            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Associated(Staff staff)
        {
            var todoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    from todoTaskPartner in _context.TodoTaskPartners
                    where todoTask.Id == todoTaskPartner.TodoTaskId &&
                          todoTaskPartner.StaffId == staff.Id
                    select todoTask
                ).ToListAsync();

            return todoTasks;
        }

        public async Task<IEnumerable<TodoTask>> GetTodoTasks_Public()
        {
            var todoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    where todoTask.Access == TaskAccess.IsPublic
                    select todoTask
                ).ToListAsync();

            return todoTasks;
        }

        public void DeleteTodoTask(TodoTask todoTask)
        {
            _context.Remove(todoTask);
        }

        public async Task<IEnumerable<Comment>> GetComments(TodoTask todoTask)
        {
            var comments =
               await (
                   from comment in _context.Comments
                   where comment.TodoTaskId == todoTask.Id
                   select comment
               ).ToListAsync();

            return comments;
        }

        public Comment CreateComment(string content, TodoTask todoTask, Staff staff)
        {
            Comment comment = new Comment
            {
                Content = content,
                TodoTaskId = todoTask.Id,
                StaffId = staff.Id
            };

            return comment;
        }

        public void AddComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Added;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        
        /*
         * PRIVATES
         */
        private IIncludableQueryable<TodoTask,Staff> TodoTaskListQuery()
        {
            return _context.TodoTasks
                .Include(o => o.Staff)
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff);
        }

    }
}