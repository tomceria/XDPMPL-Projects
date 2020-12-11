using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class TodoTaskCommentListVm
    {
        public int TodoTaskId { get; set; }
        
        public IEnumerable<Comment> Comments { get; set; }
        
        public Staff CurrentStaff { get; set; }
        
        [Required]
        [DisplayName("Thêm bình luận...")]
        public string NewCommentContent { get; set; }

        public void Deconstruct(out string content, out int todoTaskId)
        {
            content = this.NewCommentContent;
            todoTaskId = this.TodoTaskId;
        }
    }
}