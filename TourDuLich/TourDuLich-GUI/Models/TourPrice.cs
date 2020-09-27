using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDuLich_GUI.Models
{
    public class TourPrice
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Giá trị")]
        public long Value { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian bắt đầu")]
        public DateTime TimeStart { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian kết thúc")]
        public DateTime TimeEnd { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
