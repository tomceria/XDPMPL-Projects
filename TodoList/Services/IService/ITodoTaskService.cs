using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTodoTasks();
        Task<TodoTask> GetOneTodoTask(int id);
        TodoTask CreateTodoTask(string name, Staff createdBy, Staff assigned);
        void AddTodoTask(TodoTask todoTask);
        void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds);
        void DeleteTodoTask(TodoTask todoTask);
        Task<IEnumerable<TodoTask>> GetTodoTasks_Created(Staff staff);
        Task<IEnumerable<TodoTask>> GetTodoTasks_Assigned(Staff staff);
        Task<IEnumerable<TodoTask>> GetTodoTasks_Associated(Staff staff);
        Task<IEnumerable<TodoTask>> GetTodoTasks_Public();
        Task Save();
    }
}