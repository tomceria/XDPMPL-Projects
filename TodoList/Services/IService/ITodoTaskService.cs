using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTodoTasks();
        Task<TodoTask> GetOneTodoTask(int id);
        Task<Dictionary<string, IEnumerable<TodoTask>>> GetTodoTasks(Staff staff);
        TodoTask CreateTodoTask(string name, Staff createdBy, Staff assigned);
        void AddTodoTask(TodoTask todoTask);
        void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds);
        void CompleteTodoTask(TodoTask todoTask);
        void DeleteTodoTask(TodoTask todoTask);
        Task<IEnumerable<Comment>> GetComments(TodoTask todoTask);
        Comment CreateComment(string content, TodoTask todoTask, Staff staff);
        void AddComment(Comment comment);
        Task Save();
    }
}