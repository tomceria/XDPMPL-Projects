using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich_GUI.BUS
{
    public class TourGroupCost
    {
        public TourGroupCost()
        {
            Value = 0;
        }

        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("CostType"), Display(Name = "Loại chi phí")]
        public int CostTypeID { get; set; }

        [Required, Display(Name = "Giá trị")]
        public long Value { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        public virtual CostType CostType { get; set; }
    }
}
