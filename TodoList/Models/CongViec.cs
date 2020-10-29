using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum Status
    {
        inProgress, completed, overdue
    }
    public enum Access
    {
        isPublic, isPrivate
    }

    public class CongViec
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status TrangThai { get; set; }
        public Access Privacy { get; set; }

        [ForeignKey("NhanVien")]
        public int NhanVienID { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<NguoiLamChung> NguoiLamChung { get; set; }

    }
}