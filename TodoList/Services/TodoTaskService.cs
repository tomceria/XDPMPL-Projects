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
                .ThenInclude(o => o.Staff)
                .Include(o => o.CreatedBy)
                .Include(o => o.Staff)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
            return todoTask;
        }

        public async Task<Dictionary<string, IEnumerable<TodoTask>>> GetTodoTasks(Staff staff)
        {
            Dictionary<string, IEnumerable<TodoTask>> result = new Dictionary<string, IEnumerable<TodoTask>>();
            List<TodoTask> assignedTodoTasks;
            List<TodoTask> associatedTodoTasks;
            List<TodoTask> publicTodoTasks;
            List<TodoTask> otherTodoTasks;

            /*
             * Assigned TodoTasks
             */
            assignedTodoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    where todoTask.StaffId == staff.Id
                    select todoTask
                ).ToListAsync();

            /*
             * Associated TodoTasks
             */
            associatedTodoTasks =
                await (
                    from todoTask in TodoTaskListQuery()
                    join todoTaskPartner in _context.TodoTaskPartners on todoTask.Id equals todoTaskPartner.TodoTaskId
                    where todoTaskPartner.StaffId == staff.Id
                    select todoTask
                ).ToListAsync();

            if (staff.Level == Level.Leader)
            {
                /*
                 * Other TodoTasks (For LEADERS)
                 */
                otherTodoTasks =
                    await (
                        from todoTask in TodoTaskListQuery()
                        where !( // Id NOT IN
                                      from tt in _context.TodoTasks
                                      where tt.StaffId == staff.Id
                                      select tt.Id
                                  ).Contains(todoTask.Id) &&
                              !( // Id NOT IN
                                      from tt in _context.TodoTasks
                                      join todoTaskPartner in _context.TodoTaskPartners
                                          on tt.Id equals todoTaskPartner.TodoTaskId
                                      where todoTaskPartner.StaffId == staff.Id
                                      select tt.Id
                                  ).Contains(todoTask.Id)
                        select todoTask
                    ).ToListAsync();
                publicTodoTasks = new List<TodoTask>();
            }
            else
            {
                /*
                 * Public TodoTasks
                 */
                publicTodoTasks =
                    await (
                        from todoTask in TodoTaskListQuery()
                        where todoTask.Access == TaskAccess.IsPublic &&
                              !( // Id NOT IN
                                      from tt in _context.TodoTasks
                                      where tt.StaffId == staff.Id
                                      select tt.Id
                                  ).Contains(todoTask.Id) &&
                              !( // Id NOT IN
                                      from tt in _context.TodoTasks
                                      join todoTaskPartner in _context.TodoTaskPartners
                                          on tt.Id equals todoTaskPartner.TodoTaskId
                                      where todoTaskPartner.StaffId == staff.Id
                                      select tt.Id
                                  ).Contains(todoTask.Id)
                        select todoTask
                    ).ToListAsync();
                otherTodoTasks = new List<TodoTask>();
            }

            result["assigned"] = assignedTodoTasks;
            result["associated"] = associatedTodoTasks;
            result["public"] = publicTodoTasks;
            result["other"] = otherTodoTasks;

            return result;
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

        public void CompleteTodoTask(TodoTask todoTask)
        {
            todoTask.Status = TaskStatus.Completed;
            todoTask.CompleteDate = DateTime.Now;
            _context.Entry(todoTask).State = EntityState.Modified;
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
            Comment comment = new Comment()
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
        private IIncludableQueryable<TodoTask, Staff> TodoTaskListQuery()
        {
            return _context.TodoTasks
                .Include(o => o.Staff)
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff);
        }
    }
}