using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechShop_Web.Models;
using TechShop_Web.Models.Transient;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;
using TechShop_Web.Common.Utilities;

namespace TechShop_Web.Controllers
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
                viewModel.Report = taskOnStaffData.Report;
            }
            else
            {
                viewModel.StartDate = DateTime.Now.AddMonths(-1);
                viewModel.EndDate = DateTime.Now;
                viewModel.Report = new List<TaskOnStaffReportData>();
            }

            return View(viewModel);
        }

        public IActionResult TaskOnStatus()
        {
            var viewModel = new ReportTaskOnStatusVm();
            
            var taskOnStaffData = TempData.Get<ReportShowTaskOnStatusReportVm>("TaskOnStatus");

            if (taskOnStaffData != null)
            {
                viewModel.ReportStatus = taskOnStaffData.ReportStatus;
                viewModel.StartDate = taskOnStaffData.StartDate;
                viewModel.EndDate = taskOnStaffData.EndDate;
                viewModel.Report = taskOnStaffData.Report;
            }
            else
            {
                viewModel.StartDate = DateTime.Now.AddMonths(-1);
                viewModel.EndDate = DateTime.Now;
                viewModel.Report = new List<TaskOnStatusReportData>();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowTaskOnStaffReport(
            [Bind("StaffId,StartDate,EndDate")]
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowTaskOnStatusReport(
            [Bind("ReportStatus,StartDate,EndDate")]
            ReportTaskOnStatusVm viewModel)
        {
            var formData = new ReportShowTaskOnStatusReportVm
            {
                ReportStatus = viewModel.ReportStatus,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate
            };
            
            formData.Report = _reportService.GetTaskOnStatusReport(
                viewModel.ReportStatus,
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
            
            TempData.Put("TaskOnStatus", formData);

            return RedirectToAction("TaskOnStatus");
        }
    }
}