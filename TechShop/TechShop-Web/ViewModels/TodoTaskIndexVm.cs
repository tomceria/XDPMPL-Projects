using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class TodoTaskIndexVm
    {
        public IEnumerable<TodoTask> AssignedTodoTasks { get; set; }
        public IEnumerable<TodoTask> AssociatedTodoTasks { get; set; }
        public IEnumerable<TodoTask> PublicTodoTasks { get; set; }
        public IEnumerable<TodoTask> OtherTodoTasks { get; set; }
        public IEnumerable<TodoTask> CompletedTodoTasks { get; set; }
        
        public List<int> EditableTodoTaskIds { get; set; }
        
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        public string NewTaskName { get; set; }
    }
}