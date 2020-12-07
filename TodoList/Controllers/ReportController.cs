using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Utilities;
using TodoList.Models;
using TodoList.Models.Transient;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Authorize(Roles = "Leader")]
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
            return View();
        }
        
        public IActionResult TaskOnStaff()
        {
            var staffs = _staffService.GetAllStaffs().ToList();

            var viewModel = new ReportTaskOnStaffVm
            {
                Staffs = staffs
            };
            
            var taskOnStaffData = TempData.Get<ReportShowTaskOnStaffReportVm>("TaskOnStaff");

            if (taskOnStaffData != null)
            {
                viewModel.StaffId = taskOnStaffData.StaffId;
                viewModel.StartDate = taskOnStaffData.StartDate;
                viewModel.EndDate = taskOnStaffData.EndDate;
                viewModel.TaskOnStaffReport = taskOnStaffData.Report;
            }
            else
            {
                viewModel.StartDate = DateTime.Now.AddMonths(-1);
                viewModel.EndDate = DateTime.Now;
                viewModel.TaskOnStaffReport = new List<TaskOnStaffReportData>();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowTaskOnStaffReport(
            [Bind("TaskOnStaffStaffId,TaskOnStaffStartDate,TaskOnStaffEndDate")]
            ReportTaskOnStaffVm viewModel)
        {
            var formData = new ReportShowTaskOnStaffReportVm
            {
                StaffId = viewModel.StaffId,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate
            };
            
            var user = _staffService.GetCurrentUser(User);
            var staff = _staffService.GetOneStaff(viewModel.StaffId);

            formData.Report = _reportService.GetTaskOnStaffReport(
                staff,
                viewModel.StartDate,
                viewModel.EndDate
            ).ToList();
            
            /*
             * Remove Navigational Properties before converting into JSON
             * Preserve properties that are necessary for View
             */
            foreach (var reportData in formData.Report)
            {
                reportData.TodoTask.Staff = new Staff
                {
                    LastName = reportData.TodoTask.Staff.LastName,
                    FirstName = reportData.TodoTask.Staff.FirstName
                };
                reportData.TodoTask.CreatedBy = null;
                reportData.TodoTask.TodoTaskPartners = null;
            }
            
            TempData.Put("TaskOnStaff", formData);

            return RedirectToAction("TaskOnStaff");
        }
    }
}