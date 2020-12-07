using System;
using System.Collections.Generic;
using System.ComponentModel;
using TodoList.Models;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
{
    public class ReportTaskOnStaffVm
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public IEnumerable<TaskOnStaffReportData> TaskOnStaffReport { get; set; }
        
        /*
         * Forms
         */
        
        [DisplayName("Nhân viên")]
        public int StaffId { get; set; }
        
        [DisplayName("Từ lúc")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Đến lúc")]
        public DateTime EndDate { get; set; }
    }
}