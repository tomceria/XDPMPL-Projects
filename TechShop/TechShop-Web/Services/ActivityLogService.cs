using System;
using System.Collections.Generic;
using System.Linq;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;
using TechShop_Web.Common.Utilities;

namespace TechShop_Web.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ActivityLog> GetAllActivityLogs()
        {
            return _unitOfWork.ActivityLog.GetAllActivityLogs()
                .OrderByDescending(o => o.CreatedAt);
        }

        public IEnumerable<ActivityLog> GetActivityLogsByTodoTask(int todoTaskId)
        {
            return _unitOfWork.ActivityLog.GetActivityLogsByTodoTask(todoTaskId)
                .OrderByDescending(o => o.CreatedAt);
        }

        /// <summary>
        /// Create ActivityLog.
        /// Must be called BEFORE saving TodoTask into the database (Except for "Create", "AddComment")
        /// </summary>
        /// <param name="todoTask">Updated TodoTask (retrieved from Forms); For "Create" it is the newly created</param>
        /// <param name="staffId">Current logged in Staff</param>
        /// <param name="activityType">Type determined by TodoTaskController actions</param>
        public void AddActivityLog(TodoTask todoTask, int staffId, ActivityType activityType)
        {
            var activityLog = new ActivityLog
            {
                TodoTaskId = todoTask.Id,
                StaffId = staffId,
                CreatedAt = DateTime.Now,
                ActivityType = activityType
            };

            var originalTodoTask = _unitOfWork.TodoTask.GetBy(todoTask.Id);
            _unitOfWork.TodoTask.Detach(originalTodoTask);

            /*
             * Build ActivityLog's Content
             */
            var content = "";
            switch (activityType)
            {
                case ActivityType.Create:
                {
                    content += $"đã tạo công việc tên '{todoTask.Name}'";

                    break;
                }
                case ActivityType.Edit:
                {
                    content += "đã chỉnh sửa công việc";
                    if (todoTask.Name != originalTodoTask.Name)
                    {
                        content += $", đổi tên thành '{todoTask.Name}'";
                    }

                    if (todoTask.StaffId != originalTodoTask.StaffId)
                    {
                        if (todoTask.CreatedById == todoTask.StaffId)
                        {
                            content += " phân công cho cho bản thân";
                        }
                        else
                        {
                            var newAssignedStaff = _unitOfWork.Staff.GetBy(todoTask.StaffId);
                            content += $", phân công cho {newAssignedStaff.FullName}";
                        }
                    }

                    if (todoTask.EndDate != originalTodoTask.EndDate)
                    {
                        content += $", đổi hạn thành {todoTask.EndDate.Date:dd/MM/yyyy} {todoTask.EndDate:h:mm tt}";
                    }

                    if (todoTask.Access != originalTodoTask.Access)
                    {
                        content += $", đổi quyền truy cập thành {todoTask.Access.GetDisplayName()}";
                    }

                    break;
                }
                case ActivityType.Complete:
                {
                    content += "đã hoàn tất công việc";
                    if (todoTask.IsOverdue)
                    {
                        content += " (Trễ hạn)";
                    }
                    else
                    {
                        content += " (Đúng hạn)";
                    }

                    break;
                }
                case ActivityType.AddComment:
                {
                    var latestComment = _unitOfWork.TodoTask
                        .GetComments(todoTask)
                        .First(o => o.StaffId == staffId);
                    content += $"đã bình luận vào công việc với nội dung \"{latestComment.Content}\"";
                    break;
                }
                case ActivityType.Delete:
                {
                    content += "đã xoá công việc";
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(activityType), activityType, null);
            }

            activityLog.Content = content;

            _unitOfWork.ActivityLog.Add(activityLog);
            _unitOfWork.Complete();
        }
    }
}