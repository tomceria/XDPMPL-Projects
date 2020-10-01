using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupCost
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [ForeignKey("TourGroupID"), Display(Name = "Đoàn")]
        public virtual TourGroup TourGroup { get; set; }

        [ForeignKey("CostTypeID"), Display(Name = "Loại chi phí")]
        public virtual CostType CostType { get; set; }
    }
}
