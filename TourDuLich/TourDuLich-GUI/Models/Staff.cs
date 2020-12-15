using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.BUS
{
    public partial class Staff
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, Display(Name = "Tên nhân viên")]
        public string Name { get; set; }

        public virtual ICollection<TourGroupStaff> TourGroupStaffs { get; set; }

        public Staff() { }

        public Staff(Staff staff) {
            this.Name = staff.Name;
            
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
