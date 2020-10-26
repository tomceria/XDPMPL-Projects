using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public partial class Destination
    {
        [Key, Display(AutoGenerateField = false, Name = "Mã địa điểm")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên")]
        public string Name { get; set; }

        public virtual ICollection<TourDetail> TourDetails { get; set; }
    }
}
