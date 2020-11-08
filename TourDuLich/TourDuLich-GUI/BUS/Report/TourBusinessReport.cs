using System;
using System.Collections.Generic;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        public static void GetReports(DateTime startDate, DateTime endDate, out List<TourBusinessReport> toursReport, out TourBusinessReport summaryReport) {
            var result = new
            {
                ReportOnTours = new List<TourBusinessReport>(),
                Summary = new TourBusinessReport()
            };
            
            // lấy tất cả các tour
            List<Tour> tours = TourDAL.GetAll(startDate, endDate);

            // thống kê theo từng tour
            foreach (Tour tour in tours) {
                TourBusinessReport report = new TourBusinessReport {Tour = tour};

                // tính chi phí, số lượng khách của từng đoàn
                foreach (TourGroup tourGroup in tour.TourGroups) {
                    report.Sales += tourGroup.PriceGroup;
                    report.CustomerCount += tourGroup.TourGroupDetails.Count;
                    
                    // chi tiết từng chi phí của từng đoàn
                    foreach (TourGroupCost tourGroupCost in tourGroup.TourGroupCosts) {
                        // tổng chi phí của 1 đoàn
                        report.TotalCost += tourGroupCost.Value;

                        // nếu đã có loại chi phí rồi thì cộng thêm, chưa thì thêm mới
                        if (report.TourCostPerCostType.ContainsKey(tourGroupCost.CostType)) {
                            report.TourCostPerCostType[tourGroupCost.CostType] += tourGroupCost.Value;
                        } else {
                            report.TourCostPerCostType.Add(tourGroupCost.CostType, tourGroupCost.Value);
                        }

                        // tổng từng loại chi phí của tất cả tour
                        if (result.Summary.TourCostPerCostType.ContainsKey(tourGroupCost.CostType)) {
                            result.Summary.TourCostPerCostType[tourGroupCost.CostType] += tourGroupCost.Value;
                        } else {
                            result.Summary.TourCostPerCostType.Add(tourGroupCost.CostType, tourGroupCost.Value);
                        }
                    }
                }

                report.TourGroupCount = tour.TourGroups.Count;

                // tính tổng tất cả tour
                result.Summary.CustomerCount += report.CustomerCount;
                result.Summary.Sales += report.Sales;
                result.Summary.TotalCost += report.TotalCost;
                result.Summary.TourGroupCount += report.TourGroupCount;

                // thêm report của 1 tour vào danh sách nhiều tour
                result.ReportOnTours.Add(report);
            }
            
            
            // Trả về các kết quả
            toursReport = result.ReportOnTours;
            summaryReport = result.Summary;
        }
    }
}
