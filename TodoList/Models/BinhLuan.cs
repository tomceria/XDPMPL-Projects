using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class BinhLuan
    {
        public int ID { get; set; }
        public string NoiDung { get; set; }

        [ForeignKey("CongViec")]
        public int CongViecID { get; set; }
        public virtual CongViec CongViec { get; set; }
    }
}