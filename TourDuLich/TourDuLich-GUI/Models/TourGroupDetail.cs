using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupDetail
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("Customer"), Display(Name = "Khách hàng")]
        public int CustomerID { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
