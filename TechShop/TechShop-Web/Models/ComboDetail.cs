using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class ComboDetail
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Combo Combo { get; set; }
    }
}