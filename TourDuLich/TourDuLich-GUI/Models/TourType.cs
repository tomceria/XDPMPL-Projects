using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class TourType
    {
        [Key, Display(AutoGenerateField = false, Name = "Mã loại Tour")]
        public int ID { get; set; }

        [Required, Display(Name = "Tên")]
        public string Name { get; set; }

        public virtual Tour[] Tours { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
