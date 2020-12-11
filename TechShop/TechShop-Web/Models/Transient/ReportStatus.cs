using System.ComponentModel.DataAnnotations;

namespace TechShop_Web.Models.Transient
{
    public enum ReportStatus
    {
        [Display(Name = "Đang làm")] InProgress,
        [Display(Name = "Đã hoàn tất")] Completed,
        [Display(Name = "Đang làm (Trễ hạn)")] Overdue,
        [Display(Name = "Đã hoàn tất (Trễ hạn)")] CompletedLate
    }
}