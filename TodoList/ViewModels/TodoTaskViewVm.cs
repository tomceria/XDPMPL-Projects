using System.ComponentModel;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskViewVm
    {
        public TodoTask TodoTask { get; set; }
        
        [DisplayName("Hoàn tất")]
        public bool WillComplete { get; set; }
    }
}