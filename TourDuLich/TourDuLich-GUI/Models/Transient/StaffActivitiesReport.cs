using System.Collections.Generic;

namespace TourDuLich_GUI.BUS.Report {
    public partial class StaffActivitiesReport {
        public Staff Staff { get; set; }
        public int TourGroupCount { get; set; }
        public ICollection<TourGroup> TourGroups { get; set; }

        public StaffActivitiesReport() {
            Staff = new Staff();
            TourGroupCount = 0;
        }
    }
}
