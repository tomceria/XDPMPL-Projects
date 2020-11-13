using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum Level
    {
        Member = 0, Leader = 1
    }
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Level Level { get; set; }

        public virtual ICollection<TodoTask> TodoTasks { get; set; }
        public virtual ICollection<TodoTaskPartner> TodoTaskPartners { get; set; }
    }
}