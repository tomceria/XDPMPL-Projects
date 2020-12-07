using System;
using System.Collections.Generic;
using TodoList.Models.Transient;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface IReportService
    {
        IEnumerable<TaskOnStaffReportData> GetTaskOnStaffReport(Staff staff, DateTime startDate, DateTime endDate);
    }
}