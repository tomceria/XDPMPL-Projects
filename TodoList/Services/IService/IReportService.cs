using System;
using System.Collections.Generic;
using TodoList.Models.Transient;

namespace TodoList.Services.IService
{
    public interface IReportService
    {
        IEnumerable<TaskOnStaffReportData> GetTaskOnStaffReport(int staffId, DateTime startDate, DateTime endDate);
    }
}