using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Transient
{
    public enum ReportStatus
    {
        [Display(Name = "Đang làm")] InProgress,
        [Display(Name = "Đã hoàn tất")] Completed,
        [Display(Name = "Đang làm, trễ hạn")] Overdue,
        [Display(Name = "Đã hoàn tất, trễ hạn")] CompletedLate
    }
    
    public class TaskOnStaffReportData
    {
        public TodoTask TodoTask { get; set; }
        public ReportStatus Status { get; set; }
    }
}