using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence.Repositories
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
                where comment.TodoTaskId == todoTask.Id
                orderby comment.CreatedAt descending
                select comment
            );
        }

        public void AddComment(Comment comment)
        {
            Context.Add(comment);
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

        public override void Update(TodoTask entity)
        {
            Context.Update(entity);

            foreach (var todoTaskPartner in entity.TodoTaskPartners)
            {
                /*
                 * Remove todoTaskPartner if they are the Assigned Staff
                 */
                if (todoTaskPartner.StaffId == entity.StaffId)
                {
                    Context.Entry(todoTaskPartner).State = EntityState.Deleted;
                }
            }

            // List<TodoTaskPartner> ogTodoTaskPartners = Context.TodoTaskPartners
            //     .Where(o => o.TodoTaskId == entity.Id).ToList();
            // List<TodoTaskPartner> todoTaskPartners = todoTaskPartnerIds != null
            //     ? todoTaskPartnerIds
            //         .Select(todoTaskPartnerId => new TodoTaskPartner
            //         {
            //             TodoTaskId = entity.Id, StaffId = todoTaskPartnerId
            //         }).ToList()
            //     : new List<TodoTaskPartner>();
            //
            // foreach (TodoTaskPartner ogTodoTaskPartner in ogTodoTaskPartners)
            // {
            //     Context.Entry(ogTodoTaskPartner).State = EntityState.Deleted;
            // }
            //
            // foreach (TodoTaskPartner todoTaskPartner in todoTaskPartners)
            // {
            //     /*
            //      * Only add partner if they're not the Assigned staff
            //      */
            //     if (todoTaskPartner.StaffId != entity.StaffId)
            //     {
            //         Context.Entry(todoTaskPartner).State = EntityState.Added;
            //     }
            // }
        }

        /*
         * PRIVATES
         */
        private IIncludableQueryable<TodoTask, Staff> TodoTaskListQuery()
        {
            return Context.TodoTasks
                .Include(o => o.Staff)
                .Include(o => o.TodoTaskPartners)
                .ThenInclude(o => o.Staff);
        }
    }
}