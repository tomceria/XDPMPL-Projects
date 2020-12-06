using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Transient
{
    public enum ReportStatus
    {
        [Display(Name = "Đang làm")] InProgress,
        [Display(Name = "Đã hoàn tất")] Completed,
        [Display(Name = "Trễ hạn")] Overdue
    }
    
    public class TaskOnStaffReportData
    {
        public TodoTask TodoTask { get; set; }
        public ReportStatus Status { get; set; }
    }
}