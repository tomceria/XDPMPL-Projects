using System;
using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS.Report {
    public partial class TourBusinessReport {
        public static void GetReports(DateTime startDate, DateTime endDate, out List<TourBusinessReport> toursReport, out TourBusinessReport summaryReport) {
            var result = new
            {
                ReportOnTours = new List<TourBusinessReport>(),
                Summary = new TourBusinessReport()
            };
            
            // lấy dữ liệu mới nhất từ database
            TourDAL.Reload();
            
            // chuẩn bị dữ liệu
            List<Tour> tours = TourDAL.GetAll(startDate, endDate);
            List<CostType> costTypes = CostTypeDAL.GetAll();
            foreach (var costType in costTypes)
            {
                result.Summary.TourCostPerCostType.Add(costType, 0);
            }

            // thống kê theo từng tour
            foreach (Tour tour in tours) {
                TourBusinessReport report = new TourBusinessReport {Tour = tour};

                foreach (var costType in costTypes)
                {
                    report.TourCostPerCostType.Add(costType, 0);
                }
                
                // tính chi phí, số lượng khách của từng đoàn
                foreach (TourGroup tourGroup in tour.TourGroups) {
                    report.Sales += tourGroup.PriceGroup;
                    report.CustomerCount += tourGroup.TourGroupDetails.Count;
                    
                    // chi tiết từng chi phí của từng đoàn
                    foreach (TourGroupCost tourGroupCost in tourGroup.TourGroupCosts) {
                        // tổng chi phí của 1 đoàn
                        report.TotalCost += tourGroupCost.Value;

                        var costType = costTypes.First(cT => cT.ID == tourGroupCost.CostType.ID);
                        // cập nhật loại chi phí. đảm bảo rằng mọi loại chi phí đã được them vào TourCostPerCostType
                        report.TourCostPerCostType[costType] += tourGroupCost.Value;
                        // tổng từng loại chi phí của tất cả tour
                        result.Summary.TourCostPerCostType[costType] += tourGroupCost.Value;
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
