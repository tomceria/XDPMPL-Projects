using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetAllTodoTasks();
        TodoTask GetOneTodoTask(int id);
        Dictionary<string, IEnumerable<TodoTask>> GetTodoTasks(Staff staff);
        void AddTodoTask(string name, Staff createdBy, Staff assigned);
        void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds);
        void CompleteTodoTask(TodoTask todoTask);
        void RemoveTodoTask(TodoTask todoTask);
        IEnumerable<Comment> GetComments(TodoTask todoTask);
        void AddComment(Comment comment);
    }
}