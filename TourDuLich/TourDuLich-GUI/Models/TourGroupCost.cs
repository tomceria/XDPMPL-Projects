using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.Models
{
    public class TourGroupCost
    {
        [Key, Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("CostType"), Display(Name = "Loại chi phí")]
        public int CostTypeID { get; set; }


        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        public virtual CostType CostType { get; set; }
    }
}
