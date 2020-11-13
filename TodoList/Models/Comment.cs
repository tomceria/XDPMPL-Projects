using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("TodoTask")]
        public int TodoTaskId { get; set; }
        public virtual TodoTask TodoTask { get; set; }
    }
}