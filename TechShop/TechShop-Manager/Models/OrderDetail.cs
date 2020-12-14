using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    public partial class OrderDetail
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}