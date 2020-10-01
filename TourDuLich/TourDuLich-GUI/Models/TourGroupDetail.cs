using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupDetail
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [ForeignKey("TourGroupID"), Display(Name = "Đoàn")]
        public virtual TourGroup TourGroup { get; set; }

        [ForeignKey("CustomerID"), Display(Name = "Khách hàng")]
        public virtual Customer Customer { get; set; }
    }
}
