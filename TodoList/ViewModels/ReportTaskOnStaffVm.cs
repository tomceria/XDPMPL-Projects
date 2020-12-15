using System;
using System.Collections.Generic;
using System.ComponentModel;
using TodoList.Models;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
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