using System;
using System.Collections.Generic;
using System.ComponentModel;
using TechShop_Web.Models;
using TechShop_Web.Models.Transient;

namespace TechShop_Web.ViewModels
{
    public class ReportTaskOnStaffVm
    {
        public IEnumerable<TaskOnStaffReportData> Report { get; set; }
        
        /*
         * Forms
         */
        
        public IEnumerable<Staff> Staffs { get; set; }
        
        [DisplayName("Nhân viên")]
        public int StaffId { get; set; }
        
        [DisplayName("Từ lúc")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Đến lúc")]
        public DateTime EndDate { get; set; }
    }
}