using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskIndexVm
    {
        public IEnumerable<TodoTask> CreatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssignedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssociatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> PublicTodoTasks { get; set; }
        
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        public string NewTaskName { get; set; }
        /**
         * Leader-only properties
         */
        public IEnumerable<Staff> Staffs { get; set; }
    }
}