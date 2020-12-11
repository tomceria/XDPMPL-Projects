using System;
using System.Collections.Generic;
using System.ComponentModel;
using TechShop_Web.Models.Transient;

namespace TechShop_Web.ViewModels
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