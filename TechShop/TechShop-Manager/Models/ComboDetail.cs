using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    [Table("ComboDetails")]
    public partial class ComboDetail
    {
        [DisplayName("Mã SP")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        
        [DisplayName("Sản phẩm")]
        public virtual Product Product { get; set; }
        public virtual Combo Combo { get; set; }
    }
}