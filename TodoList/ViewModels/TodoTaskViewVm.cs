using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskViewVm
    {
        public TodoTask TodoTask { get; set; }

        public bool IsAssigned { get; set; }
        
        public Staff CurrentStaff { get; set; }
    }
}