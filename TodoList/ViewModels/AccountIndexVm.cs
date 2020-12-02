using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AccountIndexVm
    {
        public IEnumerable<Staff> CreatedTodoTasks { get; set; }
    }
}
