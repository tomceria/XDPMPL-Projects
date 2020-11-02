using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum TaskStatus
    {
        [Display(Name = "Đang làm")] 
        InProgress,
        [Display(Name = "Hoàn tất")] 
        Completed
    }
    public enum TaskAccess
    {
        [Display(Name = "Công khai")] 
        IsPublic,
        [Display(Name = "Cá nhân")] 
        IsPrivate
    }

    public class CongViec
    {
        public int ID { get; set; }
        [DisplayName("Tên công việc")]
        public string Name { get; set; }
        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }
        [DisplayName("Ngày kết thúc")]
        public DateTime EndDate { get; set; }
        [DisplayName("Trạng thái")]
        public TaskStatus Status { get; set; }
        [DisplayName("Quyền truy cập")]
        public TaskAccess Access { get; set; }

        [DisplayName("Nhân viên")]
        [ForeignKey("NhanVien")]
        public int NhanVienID { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<NguoiLamChung> NguoiLamChung { get; set; }

    }
}