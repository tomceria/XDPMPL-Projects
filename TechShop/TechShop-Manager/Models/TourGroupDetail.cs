using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    public class TourGroupDetail
    {
        [Key, Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("TourGroup"), Display(Name = "Đoàn")]
        public int TourGroupID { get; set; }

        [ForeignKey("Customer"), Display(Name = "Khách hàng")]
        public int CustomerID { get; set; }

        public virtual TourGroup TourGroup { get; set; }
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            return $"{this.Customer.Name}";
        }
    }
}
