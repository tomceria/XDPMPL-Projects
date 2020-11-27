using System.Collections;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskIndexVm
    {
        public IEnumerable<TodoTask> CreatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssignedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssociatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> PublicTodoTasks { get; set; }
        /**
         * Leader-only properties
         */
        public IEnumerable<Staff> Staffs { get; set; }
    }
}