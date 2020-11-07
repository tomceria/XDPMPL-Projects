using System;
using System.Collections.Generic;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        public TourBusinessReportResource getTourBusinessReport(DateTime startDate, DateTime endDate) {
            // lấy tất cả các tour
            List<Tour> tours = TourDAL.GetAll(startDate, endDate);
            TourBusinessReportResource response = new TourBusinessReportResource();

            // thống kê theo từng tour
            foreach (Tour tour in tours) {
                TourBusinessReport report = new TourBusinessReport();

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
                        if (response.sumary.TourCostPerCostType.ContainsKey(tourGroupCost.CostType)) {
                            response.sumary.TourCostPerCostType[tourGroupCost.CostType] += tourGroupCost.Value;
                        } else {
                            response.sumary.TourCostPerCostType.Add(tourGroupCost.CostType, tourGroupCost.Value);
                        }
                    }
                }

                report.TourGroupCount = tour.TourGroups.Count;

                // tính tổng tất cả tour
                response.sumary.CustomerCount += report.CustomerCount;
                response.sumary.Sales += report.Sales;
                response.sumary.TotalCost += report.TotalCost;
                response.sumary.TourGroupCount += report.TourGroupCount;

                // thêm report của 1 tour vào danh sách nhiều tour
                response.reports.Add(report);
            }
            
            return response;
        }
    }
}
