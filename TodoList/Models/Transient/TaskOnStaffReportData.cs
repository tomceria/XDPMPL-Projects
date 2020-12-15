using System.ComponentModel;

namespace TodoList.Models.Transient
{
    public class TaskOnStaffReportData
    {
        [DisplayName("Công việc")]
        public TodoTask TodoTask { get; set; }
        
        [DisplayName("Trạng thái lúc bấy giờ")]
        public ReportStatus Status { get; set; }
        
        [DisplayName("Trạng thái hiện tại")]
        public ReportStatus StatusNow { get; set; }
    }
}