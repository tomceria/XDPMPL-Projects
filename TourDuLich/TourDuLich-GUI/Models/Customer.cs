using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class Customer
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên khách")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupDetail> TourGroupDetails { get; set; }
    }
}
