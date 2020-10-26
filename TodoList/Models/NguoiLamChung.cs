using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class NguoiLamChung
    {
        [ForeignKey("CongViec")]
        public int CongViecID { get; set; }

        [ForeignKey("NhanVien")]
        public int NguoiLamChungID { get; set; }

        public virtual CongViec CongViec { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}