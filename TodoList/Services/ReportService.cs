using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Models.Transient;
using TodoList.Persistence;
using TodoList.Services.IService;

namespace TodoList.Services
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
                    .Where(o => o.StartDate >= startDate && o.StartDate <= endDate)
                    .OrderByDescending(o => o.StartDate)
                    .ToList();

            var result = todoTasks.Select(todoTask => new TaskOnStaffReportData
            {
                Status = DetermineReportStatus(todoTask, endDate),
                StatusNow = DetermineReportStatusNow(todoTask),
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
                    && o.StartDate >= startDate && o.StartDate <= endDate)
                .Include(o => o.Staff)
                .ToList();

            var result = todoTasks
                .Select(todoTask => new TaskOnStatusReportData
                {
                    Status = DetermineReportStatus(todoTask, endDate),
                    StatusNow = DetermineReportStatusNow(todoTask),
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

            if (todoTask.CompleteDate != null && todoTask.EndDate < todoTask.CompleteDate)
            {
                if (endDate < todoTask.EndDate)
                {
                    status = ReportStatus.InProgress;
                }
                else if (endDate < todoTask.CompleteDate)
                {
                    status = ReportStatus.Overdue;
                }
                else
                {
                    status = ReportStatus.CompletedLate;
                }
            }
            else if (todoTask.CompleteDate != null && todoTask.CompleteDate <= todoTask.EndDate)
            {
                if (endDate < todoTask.CompleteDate)
                {
                    status = ReportStatus.InProgress;
                }
                else if (endDate < todoTask.EndDate)
                {
                    status = ReportStatus.Completed;
                }
                else
                {
                    status = ReportStatus.Completed;
                }
            }
            else // todoTask.CompleteDate == null
            {
                if (endDate < todoTask.EndDate)
                {
                    status = ReportStatus.InProgress;
                }
                else
                {
                    status = ReportStatus.Overdue;
                }
            }


            return status;
        }
        
        private ReportStatus DetermineReportStatusNow(TodoTask todoTask) {
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
                if (todoTask.IsOverdue)
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