using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourType
    {
        [Key, Display(AutoGenerateField = false, Name = "Mã loại Tour")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên")]
        public string Name { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
