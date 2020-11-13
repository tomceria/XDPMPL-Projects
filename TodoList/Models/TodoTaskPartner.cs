using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class TodoTaskPartner
    {
        [ForeignKey("TodoTask")]
        public int TodoTaskId { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public virtual TodoTask TodoTask { get; set; }
        public virtual Staff Staff { get; set; }
    }
}