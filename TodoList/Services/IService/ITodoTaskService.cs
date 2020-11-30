using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTodoTasks();
        Task<TodoTask> GetOneTodoTask(int id);
        TodoTask CreateTodoTask(string name, Staff staff);
        void AddTodoTask(TodoTask todoTask);
        void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds);
        void DeleteTodoTask(TodoTask todoTask);
        Task Save();
    }
}