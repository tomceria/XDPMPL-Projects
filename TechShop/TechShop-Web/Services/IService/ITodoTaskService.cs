using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Services.IService
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetAllTodoTasks();
        TodoTask GetOneTodoTask(int id);
        Dictionary<string, IEnumerable<TodoTask>> GetTodoTasks(Staff staff);
        TodoTask AddTodoTask(string name, Staff createdBy, Staff assigned);
        void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds);
        void CompleteTodoTask(TodoTask todoTask);
        void RemoveTodoTask(TodoTask todoTask);
        IEnumerable<Comment> GetComments(TodoTask todoTask);
        void AddComment(Comment comment);
    }
}