using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        [Display(Name = "Tour")]
        public Tour Tour { get; set; }
        
        [Display(Name = "Doanh thu")]
        public long Sales { get; set; }
        
        [Display(Name = "Số Khách")]
        public int CustomerCount { get; set; }
        
        [Display(Name = "Số Đoàn")]
        public int TourGroupCount { get; set; }
        
        [Display(Name = "Tổng chi phí")]
        public long TotalCost { get; set; }
        public Dictionary<CostType, long> TourCostPerCostType { get; set; }

        public TourBusinessReport() {
            Sales = 0;
            CustomerCount = 0;
            TourGroupCount = 0;
            TotalCost = 0;
            TourCostPerCostType = new Dictionary<CostType, long>();
        }
    }
}
