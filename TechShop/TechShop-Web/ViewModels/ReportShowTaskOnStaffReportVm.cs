using System;
using System.Collections.Generic;
using TechShop_Web.Models.Transient;

namespace TechShop_Web.ViewModels
{
    public class ReportShowTaskOnStaffReportVm
    {
        public IEnumerable<TaskOnStaffReportData> Report { get; set; }
        public int StaffId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}