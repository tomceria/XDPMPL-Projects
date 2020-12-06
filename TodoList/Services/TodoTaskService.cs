using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;
using TodoList.Persistence;
using TodoList.Services.IService;
using TaskStatus = TodoList.Models.TaskStatus;

namespace TodoList.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TodoTask> GetAllTodoTasks()
        {
            return _unitOfWork.TodoTask.GetAll();
        }

        public TodoTask GetOneTodoTask(int id)
        {
            return _unitOfWork.TodoTask.GetBy(id);
        }

        public Dictionary<string, IEnumerable<TodoTask>> GetTodoTasks(Staff staff)
        {
            Dictionary<string, IEnumerable<TodoTask>> result = new Dictionary<string, IEnumerable<TodoTask>>();
            IEnumerable<TodoTask> assignedTodoTasks;
            IEnumerable<TodoTask> associatedTodoTasks;
            IEnumerable<TodoTask> publicTodoTasks;
            IEnumerable<TodoTask> otherTodoTasks;

            assignedTodoTasks = _unitOfWork.TodoTask.GetAssignedTodoTasks(staff);
            associatedTodoTasks = _unitOfWork.TodoTask.GetAssociatedTodoTasks(staff);

            if (staff.Level == Level.Leader)
            {
                otherTodoTasks = _unitOfWork.TodoTask.GetOtherTodoTasks(staff);
                publicTodoTasks = new List<TodoTask>();
            }
            else
            {
                publicTodoTasks = _unitOfWork.TodoTask.GetPublicTodoTasks(staff);
                otherTodoTasks = new List<TodoTask>();
            }

            result["assigned"] = assignedTodoTasks;
            result["associated"] = associatedTodoTasks;
            result["public"] = publicTodoTasks;
            result["other"] = otherTodoTasks;

            return result;
        }

        public TodoTask AddTodoTask(string name, Staff createdBy, Staff assigned)
        {
            TodoTask todoTask = new TodoTask(name, createdBy, assigned);

            _unitOfWork.TodoTask.Add(todoTask);
            _unitOfWork.Complete();

            return todoTask;
        }

        public void UpdateTodoTask(TodoTask todoTask, int[] todoTaskPartnerIds)
        {
            todoTask.TodoTaskPartners = todoTaskPartnerIds
                .Select(todoTaskPartnerId => new TodoTaskPartner
                {
                    StaffId = todoTaskPartnerId,
                    TodoTaskId = todoTask.Id
                }).ToList();
            
            _unitOfWork.TodoTask.Update(todoTask);
            _unitOfWork.Complete();
        }

        public void CompleteTodoTask(TodoTask todoTask)
        {
            todoTask.Status = TaskStatus.Completed;
            todoTask.CompleteDate = DateTime.Now;
            _unitOfWork.TodoTask.Update(todoTask);
            _unitOfWork.Complete();
        }

        public void RemoveTodoTask(TodoTask todoTask)
        {
            _unitOfWork.TodoTask.Remove(todoTask);
            _unitOfWork.Complete();
        }

        public IEnumerable<Comment> GetComments(TodoTask todoTask)
        {
            return _unitOfWork.TodoTask.GetComments(todoTask);
        }

        public void AddComment(Comment comment)
        {
            _unitOfWork.TodoTask.AddComment(comment);
            _unitOfWork.Complete();
        }
    }
}