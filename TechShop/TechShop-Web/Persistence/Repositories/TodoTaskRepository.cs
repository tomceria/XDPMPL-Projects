using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        protected TodoContext Context => DbContext as TodoContext;

        public TodoTaskRepository(TodoContext context) : base(context)
        {
        }

        public IEnumerable<TodoTask> GetAssignedTodoTasks(Staff staff)
        {
            return (
                from todoTask in TodoTaskListQuery()
                where todoTask.StaffId == staff.Id
                select todoTask
            );
        }

        public IEnumerable<TodoTask> GetAssociatedTodoTasks(Staff staff)
        {
            return (
                from todoTask in TodoTaskListQuery()
                join todoTaskPartner in Context.TodoTaskPartners
                    on todoTask.Id equals todoTaskPartner.TodoTaskId
                where todoTaskPartner.StaffId == staff.Id
                select todoTask
            );
        }

        public IEnumerable<TodoTask> GetPublicTodoTasks(Staff staff)
        {
            return (
                from todoTask in TodoTaskListQuery()
                where todoTask.Access == TaskAccess.IsPublic &&
                      !( // Id NOT IN
                              from tt in Context.TodoTasks
                              where tt.StaffId == staff.Id
                              select tt.Id
                          ).Contains(todoTask.Id) &&
                      !( // Id NOT IN
                              from tt in Context.TodoTasks
                              join todoTaskPartner in Context.TodoTaskPartners
                                  on tt.Id equals todoTaskPartner.TodoTaskId
                              where todoTaskPartner.StaffId == staff.Id
                              select tt.Id
                          ).Contains(todoTask.Id)
                select todoTask
            );
        }

        public IEnumerable<TodoTask> GetOtherTodoTasks(Staff staff)
        {
            return (
                from todoTask in TodoTaskListQuery()
                where !( // Id NOT IN
                              from tt in Context.TodoTasks
                              where tt.StaffId == staff.Id
                              select tt.Id
                          ).Contains(todoTask.Id) &&
                      !( // Id NOT IN
                              from tt in Context.TodoTasks
                              join todoTaskPartner in Context.TodoTaskPartners
                                  on tt.Id equals todoTaskPartner.TodoTaskId
                              where todoTaskPartner.StaffId == staff.Id
                              select tt.Id
                          ).Contains(todoTask.Id)
                select todoTask
            );
        }

        public IEnumerable<Comment> GetComments(TodoTask todoTask)
        {
            return (
                from comment in Context.Comments
                    .Include(o => o.Staff)
                where comment.TodoTaskId == todoTask.Id
                select comment
            );
        }
        
        public void AddComment(Comment comment)
        {
            Context.Add(comment);
        }

        public void UpdateTodoTaskPartners(TodoTask todoTask, int[] todoTaskPartnerIds)
        {
            var ogTodoTaskPartners = (
                from ttp in Context.TodoTaskPartners
                where ttp.TodoTaskId == todoTask.Id
                select ttp
            ).ToList();
            var todoTaskPartners = todoTaskPartnerIds.Length > 0
                ? todoTaskPartnerIds
                    .Select(todoTaskPartnerId => new TodoTaskPartner
                    {
                        StaffId = todoTaskPartnerId,
                        TodoTaskId = todoTask.Id
                    }).ToList()
                : new List<TodoTaskPartner>();

            foreach (var ogTodoTaskPartner in ogTodoTaskPartners)
            {
                Context.Entry(ogTodoTaskPartner).State = EntityState.Deleted;
            }
            foreach (var todoTaskPartner in todoTaskPartners)
            {
                Context.Entry(todoTaskPartner).State = EntityState.Added;
            }
        }

        /*
         * OVERRIDES
         */
        public override TodoTask GetBy(int id)
        {
            return Context.TodoTasks
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff)
                .Include(o => o.CreatedBy)
                .Include(o => o.Staff)
                .FirstOrDefault(o => o.Id == id);
        }

        /*
         * PRIVATES
         */
        private IIncludableQueryable<TodoTask, Staff> TodoTaskListQuery()
        {
            return Context.TodoTasks
                .Where(o => o.IsHidden == false)
                .Include(o => o.Staff)
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff);
        }
    }
}