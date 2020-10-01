using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourDuLich_GUI.Models
{
    public class Customer
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên khách")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupDetail> TourGroupDetails { get; set; }
    }
}
