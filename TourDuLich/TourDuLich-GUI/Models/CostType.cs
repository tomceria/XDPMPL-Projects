using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class CostType
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên chi phí")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupCost> TourGroupCosts { get; set; }
    }
}
