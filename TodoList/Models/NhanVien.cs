using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum Level
    {
        NhanVien = 0, LanhDao = 1
    }
    public class NhanVien
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public Level Level { get; set; }

        public virtual ICollection<CongViec> DSCongViec { get; set; }
    }
}