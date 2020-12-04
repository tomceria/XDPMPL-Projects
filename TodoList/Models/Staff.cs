using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum Level
    {
        [Display(Name = "Nhân viên")] 
        Member = 0,
        [Display(Name = "Lãnh đạo")] 
        Leader = 1
    }
    public class Staff
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        [DisplayName("Tên")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Họ không được bỏ trống.")]
        [DisplayName("Họ")]
        public string LastName { get; set; }
        
        [DisplayName("Chức vụ")]
        public Level Level { get; set; }

        [InverseProperty("Staff")]
        public virtual ICollection<TodoTask> AssignedTodoTasks { get; set; }
        
        [InverseProperty("CreatedBy")]
        public virtual ICollection<TodoTask> CreatedTodoTasks { get; set; }
        public virtual ICollection<TodoTaskPartner> TodoTaskPartners { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        
        [NotMapped]
        [DisplayName("Tên")]
        public string FullName => $"{LastName} {FirstName}"; 
    }
}