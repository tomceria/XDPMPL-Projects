using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public partial class TourGroup
    {
        public TourGroup()
        {
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now;
        }

        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [ForeignKey("Tour"), Display(Name = "Tour")]
        public int TourID { get; set; }

        [Required, Display(Name = "Tên đoàn")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian bắt đầu")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Thời gian kết thúc")]
        public DateTime DateEnd { get; set; }

        [Required, Display(Name = "Chi phí của Đoàn")]
        public long PriceGroup { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual ICollection<TourGroupCost> TourGroupCosts { get; set; }
        public virtual ICollection<TourGroupDetail> TourGroupDetails { get; set; }
        public virtual ICollection<TourGroupStaff> TourGroupStaffs { get; set; }
    }
}
