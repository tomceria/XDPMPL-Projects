using System;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class TourPrice
    {
        static int Count = 0;

        public TourPrice()
        {
            ID = Count++;
            Value = 0;
            TimeStart = new DateTime();
            TimeEnd = new DateTime().AddDays(10);
        }

        public TourPrice(Tour t): this()
        {
            Tour = t;
        }

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
