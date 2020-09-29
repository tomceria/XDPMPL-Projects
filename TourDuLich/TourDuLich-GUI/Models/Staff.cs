using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class Staff
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên nhân viên")]
        public string Name { get; set; }
    }
}
