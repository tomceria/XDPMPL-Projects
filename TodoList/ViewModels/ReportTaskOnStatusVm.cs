using System;
using System.Collections.Generic;
using System.ComponentModel;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
{
    public class ReportTaskOnStatusVm
    {
        public IEnumerable<TaskOnStatusReportData> Report { get; set; }
        
        /*
         * Forms
         */
        
        [DisplayName("Trạng thái")]
        public ReportStatus ReportStatus { get; set; }
        
        [DisplayName("Từ lúc")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Đến lúc")]
        public DateTime EndDate { get; set; }
    }
}