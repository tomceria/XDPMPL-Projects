using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels.Component
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