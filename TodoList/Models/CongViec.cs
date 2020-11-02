using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum Status
    {
        [Display(Name = "Đang làm")] 
        inProgress,
        [Display(Name = "Hoàn tất")] 
        completed,
        [Display(Name = "Trễ hạn")] 
        overdue
    }
    public enum Access
    {
        [Display(Name = "Công khai")] 
        isPublic,
        [Display(Name = "Cá nhân")] 
        isPrivate
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
        public Status TrangThai { get; set; }
        [DisplayName("Quyền truy cập")]
        public Access Privacy { get; set; }

        [DisplayName("Nhân viên")]
        [ForeignKey("NhanVien")]
        public int NhanVienID { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<NguoiLamChung> NguoiLamChung { get; set; }

    }
}