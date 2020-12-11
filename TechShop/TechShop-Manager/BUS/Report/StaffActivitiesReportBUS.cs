using System;
using System.Collections.Generic;
using System.Linq;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS.Report {
    public partial class StaffActivitiesReport {
        public static List<StaffActivitiesReport> GetStaffActivitiesReport(DateTime startDate, DateTime endDate) {
            // lấy dữ liệu mới nhất từ database
            TourDAL.Reload();
            TourGroupDAL.Reload();
            StaffDAL.Reload();
            
            List<StaffActivitiesReport> reports = new List<StaffActivitiesReport>();
            List<Staff> staffs = StaffDAL.GetAll(startDate, endDate);
            
            foreach (Staff staff in staffs) {
                StaffActivitiesReport report = new StaffActivitiesReport();
                report.Staff = staff;
                report.TourGroupCount = staff.TourGroupStaffs
                    .GroupBy(o => o.ID)
                    .Count();

                reports.Add(report);
            }

            return reports;
        }
    }
}
