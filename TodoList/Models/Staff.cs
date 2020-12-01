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
        public string LastName { get; set; }
        public Level Level { get; set; }

        [InverseProperty("Staff")]
        public virtual ICollection<TodoTask> AssignedTodoTasks { get; set; }
        
        [InverseProperty("CreatedBy")]
        public virtual ICollection<TodoTask> CreatedTodoTasks { get; set; }
        public virtual ICollection<TodoTaskPartner> TodoTaskPartners { get; set; }
        
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}"; 
    }
}