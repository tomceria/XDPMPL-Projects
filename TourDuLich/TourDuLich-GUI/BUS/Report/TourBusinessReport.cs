using System;
using System.Collections.Generic;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        public List<TourBusinessReport> getTourBusinessReport(DateTime startDate, DateTime endDate) {
            List<Tour> tours = TourDAL.GetAll();
            List<TourBusinessReport> reports = new List<TourBusinessReport>();

            // thống kê theo từng tour
            foreach (Tour tour in tours) {
                TourBusinessReport report = new TourBusinessReport();

                foreach (TourGroup tourGroup in tour.TourGroups) {
                    report.TourCostPerCostType = new Dictionary<CostType, long>();
                    report.Sales += tourGroup.PriceGroup;
                    report.CustomerCount += tourGroup.TourGroupDetails.Count;
                    
                    foreach (TourGroupCost tourGroupCost in tourGroup.TourGroupCosts) {
                        report.TotalCost += tourGroupCost.Value;
                        if (report.TourCostPerCostType.ContainsKey(tourGroupCost.CostType)) {
                            report.TourCostPerCostType[tourGroupCost.CostType] += tourGroupCost.Value;
                        } else {
                            report.TourCostPerCostType.Add(tourGroupCost.CostType, tourGroupCost.Value);
                        }
                    }
                }

                report.TourGroupCount = tour.TourGroups.Count;
            }
            
            return reports;
        }
    }
}
