using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechShop_Manager.BUS.Report {
    public partial class StaffActivitiesReport {
        [Display(Name = "Nhân viên")]
        public Staff Staff { get; set; }
        
        [Display(Name = "Số lần đi Tour (theo Đoàn)")]
        public int TourGroupCount { get; set; }
        
        public ICollection<TourGroup> TourGroups { get; set; }

        public StaffActivitiesReport() {
            Staff = new Staff();
            TourGroupCount = 0;
        }
    }
}
