using System;
using System.Collections.Generic;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
{
    public class ReportShowTaskOnStatusReportVm
    {
        
        public IEnumerable<TaskOnStatusReportData> Report { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}