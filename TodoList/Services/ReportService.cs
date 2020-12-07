using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<TodoTask> assignedTodoTasks;
            IEnumerable<TodoTask> associatedTodoTasks;

            assignedTodoTasks = _unitOfWork.TodoTask.GetAssignedTodoTasks(staff);
            associatedTodoTasks = _unitOfWork.TodoTask.GetAssociatedTodoTasks(staff);
            IEnumerable<TodoTask> staffTodoTasks = assignedTodoTasks.Concat(associatedTodoTasks).OrderByDescending(o => o.StartDate);

            List<TaskOnStaffReportData> result = new List<TaskOnStaffReportData>();

            foreach (TodoTask todotask in staffTodoTasks)
            {
                if (todotask.StartDate < startDate)
                {
                    continue;
                }

                TaskOnStaffReportData a = new TaskOnStaffReportData
                {
                    Status = ReportStatus.InProgress,
                    TodoTask = todotask
                };

                if (todotask.Status == TaskStatus.Completed)
                {
                    if (todotask.EndDate < todotask.CompleteDate)
                    {
                        a.Status = ReportStatus.CompletedLate;
                    }
                    else 
                    {
                        a.Status = ReportStatus.Completed;
                    }
                }
                else
                {
                    if (endDate > todotask.EndDate)
                    {
                        a.Status = ReportStatus.Overdue;
                    }
                    else
                    {
                        a.Status = ReportStatus.InProgress;
                    }
                }

                result.Add(a);

            }

            return result;
        }

            // TODO: Cài đặt chức năng thống kê
            

            /*
             * UnitOfWork chứa các Repository (như .TodoTask, .Staff), là đơn vị DUY NHẤT tương tác DB của chương trình
             * Repository thực hiện các lệnh tương tác với DB (như là lớp DAL)
             * Các ???Repository kế thừa Repository và I???Repository
             * Tham khảo các hàm có sẵn của 1 Repo ở file Repository.cs 
             * VD: _unitOfWork.TodoTask.Find(o => o.StartDate >= startDate);
             * Nếu các hàm có sẵn không đủ đáp ứng, có thể thêm method tại ITodoTaskRepository và TodoTaskRepository
             * (vì Report ko có repo riêng, dùng chung với TodoTask)
             * 
             * chỉ cần thông tin Công việc với lại Trạng thái thôi à, lọc theo nhân viên, start date, end date
             */
    }
}