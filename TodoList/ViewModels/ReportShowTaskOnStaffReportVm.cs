using System;
using System.Collections.Generic;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
{
    public class ReportShowTaskOnStaffReportVm
    {
        public IEnumerable<TaskOnStaffReportData> Report { get; set; }
        public int StaffId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}