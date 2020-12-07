using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Transient
{
    public enum ReportStatus
    {
        [Display(Name = "Đang làm")] InProgress,
        [Display(Name = "Đã hoàn tất")] Completed,
        [Display(Name = "Đang làm (Trễ hạn)")] Overdue,
        [Display(Name = "Đã hoàn tất (Trễ hạn)")] CompletedLate
    }
    
    public class TaskOnStaffReportData
    {
        [DisplayName("Công việc")]
        public TodoTask TodoTask { get; set; }
        
        [DisplayName("Trạng thái")]
        public ReportStatus Status { get; set; }
    }
}