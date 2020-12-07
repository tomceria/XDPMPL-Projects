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
        [Display(Name = "Đang làm")] InProgress,
        [Display(Name = "Đã Hoàn tất")] Completed
    }

    public enum TaskAccess
    {
        [Display(Name = "Công khai")] IsPublic,
        [Display(Name = "Riêng tư")] IsPrivate
    }

    public class TodoTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên công việc bắt buộc phải có.")]
        [DisplayName("Tên công việc")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phải có Ngày bắt đầu.")]
        [DisplayName("Thời gian bắt đầu")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Phải có Ngày kết thúc.")]
        [AfterDate("StartDate", ErrorMessage = "Phải sau ngày bắt đầu.")]
        [DisplayName("Thời gian kết thúc")]
        public DateTime EndDate { get; set; }

        [DisplayName("Thời gian hoàn tất")] public DateTime? CompleteDate { get; set; }

        [DisplayName("Trạng thái")] public TaskStatus Status { get; set; }

        [DisplayName("Quyền truy cập")] public TaskAccess Access { get; set; }

        [DisplayName("Đã xoá?")] public bool IsHidden { get; set; }
        
        [DisplayName("Nhân viên đảm nhiệm")]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        [DisplayName("Người tạo")]
        [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Staff CreatedBy { get; set; }

        [DisplayName("Những người làm chung")]
        public virtual ICollection<TodoTaskPartner> TodoTaskPartners { get; set; }

        /*
         * Transients
         */
        [NotMapped] public bool IsOverdue => DateTime.Now > this.EndDate;

        public TodoTask()
        {
            IsHidden = false;
        }
        public TodoTask(string name, Staff createdBy, Staff assigned) : this()
        {
            Name = name;
            StartDate = DateTime.Now;
            EndDate = (DateTime.Now).AddDays(7);
            Status = TaskStatus.InProgress;
            Access = TaskAccess.IsPrivate;
            CreatedById = createdBy.Id;
            StaffId = assigned.Id;
        }
    }
}