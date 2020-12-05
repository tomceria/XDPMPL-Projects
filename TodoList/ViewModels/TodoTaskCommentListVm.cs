using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskCommentListVm
    {
        public IEnumerable<Comment> Comments { get; set; }
        
        public Staff CurrentStaff { get; set; }
    }
}