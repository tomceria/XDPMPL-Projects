using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class Staff
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên nhân viên")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupStaff> TourGroupStaffs { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
