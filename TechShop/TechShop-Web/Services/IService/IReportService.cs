using System;
using System.Collections.Generic;
using TechShop_Web.Models;
using TechShop_Web.Models.Transient;

namespace TechShop_Web.Services.IService
{
    public interface IReportService
    {
        IEnumerable<TaskOnStaffReportData> GetTaskOnStaffReport(Staff staff, DateTime startDate, DateTime endDate);

        IEnumerable<TaskOnStatusReportData> GetTaskOnStatusReport(ReportStatus reportStatus, DateTime startDate,
            DateTime endDate);
    }
}