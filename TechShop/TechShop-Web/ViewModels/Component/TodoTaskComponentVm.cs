using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels.Component
{
    public class TodoTaskComponentVm
    {
        public TodoTask TodoTask { get; set; }
        public List<int> EditableTodoTaskIds { get; private set; }

        public TodoTaskComponentVm(TodoTask todoTask, List<int> editableTodoTaskIds)
        {
            TodoTask = todoTask;
            EditableTodoTaskIds = editableTodoTaskIds;
        }
    }
}