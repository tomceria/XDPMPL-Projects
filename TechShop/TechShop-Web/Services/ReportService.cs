using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Models;
using TechShop_Web.Models.Transient;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TaskOnStaffReportData> GetTaskOnStaffReport(
            Staff staff, DateTime startDate, DateTime endDate)
        {
            var assignedTodoTasks = _unitOfWork.TodoTask.GetAssignedTodoTasks(staff);
            var associatedTodoTasks = _unitOfWork.TodoTask.GetAssociatedTodoTasks(staff);

            var todoTasks =
                assignedTodoTasks
                    .Concat(associatedTodoTasks)
                    .Where(o => o.StartDate >= startDate)
                    .OrderByDescending(o => o.StartDate)
                    .ToList();

            var result = todoTasks.Select(todoTask => new TaskOnStaffReportData
            {
                Status = DetermineReportStatus(todoTask, endDate),
                TodoTask = todoTask
            }).ToList();

            return result;
        }

        public IEnumerable<TaskOnStatusReportData> GetTaskOnStatusReport(ReportStatus reportStatus, DateTime startDate,
            DateTime endDate)
        {
            var todoTasks = _unitOfWork.TodoTask
                .Find(o =>
                    o.IsHidden == false
                    && startDate <= o.StartDate)
                .Include(o => o.Staff)
                .ToList();

            var result = todoTasks
                .Select(todoTask => new TaskOnStatusReportData
                {
                    Status = DetermineReportStatus(todoTask, endDate),
                    TodoTask = todoTask
                }).ToList();

            result = result.Where(o => o.Status == reportStatus).ToList();

            return result;
        }

        /*
         * PRIVATES
         */

        private ReportStatus DetermineReportStatus(TodoTask todoTask, DateTime endDate)
        {
            ReportStatus status;

            if (todoTask.Status == TaskStatus.Completed)
            {
                if (todoTask.EndDate < todoTask.CompleteDate)
                {
                    status = ReportStatus.CompletedLate;
                }
                else
                {
                    status = ReportStatus.Completed;
                }
            }
            else
            {
                if (endDate > todoTask.EndDate)
                {
                    status = ReportStatus.Overdue;
                }
                else
                {
                    status = ReportStatus.InProgress;
                }
            }

            return status;
        }
    }
}