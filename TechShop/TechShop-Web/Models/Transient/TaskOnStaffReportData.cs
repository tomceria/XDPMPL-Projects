using System.ComponentModel;

namespace TechShop_Web.Models.Transient
{
    public class TaskOnStaffReportData
    {
        [DisplayName("Công việc")]
        public TodoTask TodoTask { get; set; }
        
        [DisplayName("Trạng thái")]
        public ReportStatus Status { get; set; }
    }
}