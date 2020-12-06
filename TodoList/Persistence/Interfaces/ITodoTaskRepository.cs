using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Persistence.Interfaces
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        IEnumerable<TodoTask> GetAssignedTodoTasks(Staff staff);
        IEnumerable<TodoTask> GetAssociatedTodoTasks(Staff staff);
        IEnumerable<TodoTask> GetPublicTodoTasks(Staff staff);
        IEnumerable<TodoTask> GetOtherTodoTasks(Staff staff);
        IEnumerable<Comment> GetComments(TodoTask todoTask);
        void UpdateTodoTaskPartners(TodoTask todoTask, int[] todoTaskPartnerIds);
        void AddComment(Comment comment);
    }
}