using System.Collections.Generic;

namespace TechShop_Manager.BUS.Report {
    public class TourBusinessReportResource {
        public List<TourBusinessReport> reports { get; set; }
        public TourBusinessReport sumary { get; set; }

        public TourBusinessReportResource() {
            reports = new List<TourBusinessReport>();
            sumary = new TourBusinessReport();
        }
    }
}
