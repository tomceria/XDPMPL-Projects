using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupStaff
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Nhiệm vụ")]
        public Task StaffTask { get; set; }

        [ForeignKey("TourGroupID"), Display(Name = "Đoàn")]
        public virtual TourGroup TourGroup { get; set; }

        [ForeignKey("StaffID"), Display(Name = "Nhân viên")]
        public virtual Staff Staff { get; set; }

        [NotMapped]
        public class Task
        {
            private Task(string value) { Value = value; }
            public string Value { get; set; }
            public Task Driver { get { return new Task("Tài xế"); } }
            public Task TourGuide { get { return new Task("Hướng dẫn viên"); } }
        }
    }
}
