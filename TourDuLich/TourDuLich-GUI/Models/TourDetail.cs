using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDuLich_GUI.Models
{
    public class TourDetail
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Required, Display(Name = "Thứ tự")]
        public int Order { get; set; }

/*        [Key, ForeignKey("Tour"), Display(Name = "Tour")]
        public int TourID { get; set; }

        [Key, ForeignKey("Destination"), Display(Name = "Địa điểm")]
        public int DestinationID { get; set; }
*/
        public virtual Tour Tour { get; set; }

        public virtual Destination Destination { get; set; }

        public override string ToString()
        {
            return $"{this.Order}: {this.Destination.Name}";
        }
    }

}
