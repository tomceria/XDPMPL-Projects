using System.Collections.Generic;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        Tour Tour;
        long Sales;
        int CustomerCount;
        int TourGroupCount;
        long TotalCost;
        Dictionary<CostType, long> TourCostPerCostType;
    }
}
