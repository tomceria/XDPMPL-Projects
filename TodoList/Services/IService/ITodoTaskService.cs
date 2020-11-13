using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTodoTasks();
        Task<TodoTask> GetOneTodoTask(int id);
        Task<TodoTask> CreateTodoTask(string name);
        void AddTodoTask(TodoTask todoTask);
        void UpdateTodoTask(TodoTask todoTask);
        void DeleteTodoTask(TodoTask todoTask);
        Task Save();
    }
}