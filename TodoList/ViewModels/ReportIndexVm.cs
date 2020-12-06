using System;
using System.Collections.Generic;
using TodoList.Models;
using TodoList.Models.Transient;

namespace TodoList.ViewModels
{
    public class ReportIndexVm
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public IEnumerable<TaskOnStaffReportData> TaskOnStaffReport { get; set; }
        public int TaskOnStaffStaffId { get; set; }
        public DateTime TaskOnStaffStartDate { get; set; }
        public DateTime TaskOnStaffEndDate { get; set; }
    }
}