using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("TodoTask")] public int TodoTaskId { get; set; }
        public virtual TodoTask TodoTask { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public Comment()
        {
            this.CreatedAt = DateTime.Now;
        }

        public Comment(string content, TodoTask todoTask, Staff staff) : this()
        {
            Content = content;
            TodoTaskId = todoTask.Id;
            StaffId = staff.Id;
        }
    }
}