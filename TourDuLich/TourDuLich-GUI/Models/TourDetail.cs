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

        [Key, ForeignKey("Tour"), Display(Name = "Tour")]
        public virtual Tour TourID { get; set; }

        [Key, ForeignKey("Destination"), Display(Name = "Địa điểm")]
        public virtual Destination DestinationID { get; set; }
    }
}
