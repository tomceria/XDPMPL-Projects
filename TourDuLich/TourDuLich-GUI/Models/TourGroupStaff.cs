using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.BUS
{
    public class TourGroupStaff
    {
        public static List<string> Tasks = new List<string>()
        {
            "Tài xế",
            "Hướng dẫn viên"
        };

        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("Staff"), Display(Name = "Nhân viên")]
        public int StaffID { get; set; }

        [Required, Display(Name = "Nhiệm vụ")]
        public string StaffTask { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        
        [Display(Name = "Nhân viên")]
        public virtual Staff Staff { get; set; }

        public override string ToString()
        {
            return $"{this.Staff.Name}";
        }
    }
}
