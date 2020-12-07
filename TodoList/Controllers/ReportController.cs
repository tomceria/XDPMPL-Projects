using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Utilities;
using TodoList.Models.Transient;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IStaffService _staffService;

        public ReportController(IReportService reportService, IStaffService staffService)
        {
            _reportService = reportService;
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var staffs = _staffService.GetAllStaffs().ToList();

            var viewModel = new ReportIndexVm
            {
                Staffs = staffs
            };
            
            var taskOnStaffData = TempData.Get<ReportShowTaskOnStaffReportVm>("TaskOnStaff");

            if (taskOnStaffData != null)
            {
                viewModel.TaskOnStaffStaffId = taskOnStaffData.StaffId;
                viewModel.TaskOnStaffStartDate = taskOnStaffData.StartDate;
                viewModel.TaskOnStaffEndDate = taskOnStaffData.EndDate;
                viewModel.TaskOnStaffReport = taskOnStaffData.Report;
            }
            else
            {
                viewModel.TaskOnStaffStartDate = DateTime.Now;
                viewModel.TaskOnStaffEndDate = DateTime.Now.AddMonths(1);
                viewModel.TaskOnStaffReport = new List<TaskOnStaffReportData>();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowTaskOnStaffReport(
            [Bind("TaskOnStaffStaffId,TaskOnStaffStartDate,TaskOnStaffEndDate")]
            ReportIndexVm viewModel)
        {
            var formData = new ReportShowTaskOnStaffReportVm
            {
                StaffId = viewModel.TaskOnStaffStaffId,
                StartDate = viewModel.TaskOnStaffStartDate,
                EndDate = viewModel.TaskOnStaffEndDate
            };
            
            var user = _staffService.GetCurrentUser(User);
            var staff = _staffService.GetOneStaff(viewModel.TaskOnStaffStaffId);

            formData.Report = _reportService.GetTaskOnStaffReport(
                staff,
                viewModel.TaskOnStaffStartDate,
                viewModel.TaskOnStaffEndDate
            ).ToList();
            
            TempData.Put("TaskOnStaff", formData);

            return RedirectToAction("Index");
        }
    }
}