using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Common.ValidationAttributes;

namespace TodoList.Models
{
    public enum TaskStatus
    {
        [Display(Name = "Đang làm")] 
        InProgress,
        [Display(Name = "Hoàn tất")] 
        Completed
    }
    public enum TaskAccess
    {
        [Display(Name = "Công khai")] 
        IsPublic,
        [Display(Name = "Riêng tư")] 
        IsPrivate
    }

    public class TodoTask
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên công việc bắt buộc phải có.")]
        [DisplayName("Tên công việc")]
        public string Name { get; set; }
        
        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }
        
        [AfterDate("StartDate", ErrorMessage = "Phải sau ngày bắt đầu.")]
        [DisplayName("Ngày kết thúc")]
        public DateTime EndDate { get; set; }
        
        [DisplayName("Trạng thái")]
        public TaskStatus Status { get; set; }
        
        [DisplayName("Quyền truy cập")]
        public TaskAccess Access { get; set; }

        [DisplayName("Nhân viên")]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public virtual Staff Staff { get; set; }
        
        [DisplayName("Những người làm chung")]
        public virtual ICollection<TodoTaskPartner> TodoTaskPartners { get; set; }
    }
}