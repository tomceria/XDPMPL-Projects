using System;
using System.Collections.Generic;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS.Report {
    public partial class StaffActivitiesReport {
        public static List<StaffActivitiesReport> GetStaffActivitiesReport(DateTime startDate, DateTime endDate) {
            List<StaffActivitiesReport> reports = new List<StaffActivitiesReport>();
            List<Staff> staffs = StaffDAL.GetAll(startDate, endDate);
            
            // lấy dữ liệu mới nhất từ database
            TourDAL.Reload();
            TourGroupDAL.Reload();
            StaffDAL.Reload();

            foreach (Staff staff in staffs) {
                StaffActivitiesReport report = new StaffActivitiesReport();
                report.Staff = staff;
                report.TourGroupCount = staff.TourGroupStaffs.Count;

                reports.Add(report);
            }

            return reports;
        }
    }
}
