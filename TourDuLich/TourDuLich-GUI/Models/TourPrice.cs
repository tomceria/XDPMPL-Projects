using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.BUS
{
    public class TourPrice
    {
        public TourPrice()
        {
            Value = 0;
            TimeStart = DateTime.Now;
            TimeEnd = DateTime.Now.AddDays(10);
        }

        public TourPrice(Tour t): this()
        {
            Tour = t;
        }

        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Tour"), Display(Name = "Tour")]
        public int TourID { get; set; }

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
