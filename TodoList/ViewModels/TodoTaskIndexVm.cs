using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskIndexVm
    {
        public IEnumerable<TodoTask> AssignedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssociatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> PublicTodoTasks { get; set; }
        public IEnumerable<TodoTask> OtherTodoTasks { get; set; }
        
        public List<int> EditableTodoTaskIds { get; set; }
        
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        public string NewTaskName { get; set; }
    }
}