using System.Collections.Generic;
using TourDuLich_GUI.BUS.Report;

namespace TourDuLich_GUI.BUS.Report {
    public class TourBusinessReportResource {
        public List<TourBusinessReport> reports { get; set; }
        public TourBusinessReport sumary { get; set; }

        public TourBusinessReportResource() {
            reports = new List<TourBusinessReport>();
            sumary = new TourBusinessReport();
        }
    }
}
