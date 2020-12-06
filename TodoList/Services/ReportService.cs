using System;
using System.Collections.Generic;
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
            int staffId, DateTime startDate, DateTime endDate)
        {
            // TODO: Cài đặt chức năng thống kê
            return new List<TaskOnStaffReportData>
            {
                new TaskOnStaffReportData {
                    Status = ReportStatus.InProgress,
                    TodoTask = new TodoTask { Name = "Hello" }
                }
            };

            /*
             * UnitOfWork chứa các Repository (như .TodoTask, .Staff), là đơn vị DUY NHẤT tương tác DB của chương trình
             * Repository thực hiện các lệnh tương tác với DB (như là lớp DAL)
             * Các ???Repository kế thừa Repository và I???Repository
             * Tham khảo các hàm có sẵn của 1 Repo ở file Repository.cs 
             * VD: _unitOfWork.TodoTask.Find(o => o.StartDate >= startDate);
             * Nếu các hàm có sẵn không đủ đáp ứng, có thể thêm method tại ITodoTaskRepository và TodoTaskRepository
             * (vì Report ko có repo riêng, dùng chung với TodoTask)
             */
        }
    }
}