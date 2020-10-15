using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupStaff
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("Staff"), Display(Name = "Nhân viên")]
        public int StaffID { get; set; }

        [Required, Display(Name = "Nhiệm vụ")]
        public Task StaffTask { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        public virtual Staff Staff { get; set; }

        [NotMapped]
        public class Task
        {
            private Task(string value) { Value = value; }
            public string Value { get; set; }
            public Task Driver { get { return new Task("Tài xế"); } }
            public Task TourGuide { get { return new Task("Hướng dẫn viên"); } }
        }

        public override string ToString()
        {
            return $"{this.Staff.Name}";
        }
    }
}
