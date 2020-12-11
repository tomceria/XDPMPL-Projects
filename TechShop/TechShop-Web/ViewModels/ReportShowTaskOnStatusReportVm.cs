using System;
using System.Collections.Generic;
using TechShop_Web.Models.Transient;

namespace TechShop_Web.ViewModels
{
    public class ReportShowTaskOnStatusReportVm
    {
        
        public IEnumerable<TaskOnStatusReportData> Report { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}