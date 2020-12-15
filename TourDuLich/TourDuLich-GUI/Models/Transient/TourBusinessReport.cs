using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        [Display(Name = "Tour")]
        public Tour Tour { get; set; }
        
        [Display(Name = "Số Khách")]
        public int CustomerCount { get; set; }
        
        [Display(Name = "Số Đoàn")]
        public int TourGroupCount { get; set; }
        
        [Display(Name = "Doanh thu")]
        public long Sales { get; set; }
        
        [Display(Name = "Tổng chi phí")]
        public long TotalCost { get; set; }
        
        [Display(Name = "Lợi nhuận")]
        public long Profit { get; set; }
        public Dictionary<CostType, long> TourCostPerCostType { get; set; }

        public TourBusinessReport() {
            CustomerCount = 0;
            TourGroupCount = 0;
            Sales = 0;
            TotalCost = 0;
            Profit = 0;
            TourCostPerCostType = new Dictionary<CostType, long>();
        }
    }
}
