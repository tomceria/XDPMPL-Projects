using System.Collections.Generic;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        public Tour Tour { get; set; }
        public long Sales { get; set; }
        public int CustomerCount { get; set; }
        public int TourGroupCount { get; set; }
        public long TotalCost { get; set; }
        public Dictionary<CostType, long> TourCostPerCostType { get; set; }
    }
}
