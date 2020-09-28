using System;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class TourGroup
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên đoàn")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian bắt đầu")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian kết thúc")]
        public DateTime DateEnd { get; set; }

        [Required, Display(Name = "Giá của đoàn")]
        public long PriceGroup { get; set; }
    }
}
