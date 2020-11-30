using System.Collections;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskEditVm
    {
        public TodoTask TodoTask { get; set; }
        public IEnumerable<Staff> Staffs { get; set; }
    }
}