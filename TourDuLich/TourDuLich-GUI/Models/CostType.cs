using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class CostType
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên chi phí")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupCost> TourGroupCosts { get; set; }
    }
}
