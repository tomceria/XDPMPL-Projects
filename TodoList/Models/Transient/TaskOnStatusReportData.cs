using System.ComponentModel;

namespace TodoList.Models.Transient
{
    public class TaskOnStatusReportData
    {
        [DisplayName("Công việc")]
        public TodoTask TodoTask { get; set; }
        
        [DisplayName("Trạng thái")]
        public ReportStatus Status { get; set; }
    }
}