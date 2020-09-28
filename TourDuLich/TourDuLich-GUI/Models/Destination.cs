using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class Destination
    {
        [Key, Display(AutoGenerateField = false, Name = "Mã địa điểm")]
        public int ID { get; set; }

        [Required, Display(Name = "Tên")]
        public string Name { get; set; }
    }
}
