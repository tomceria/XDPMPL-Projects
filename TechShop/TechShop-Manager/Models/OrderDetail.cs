using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Data;

namespace TechShop_Manager.BUS
{
    public partial class OrderDetail
    {
        [DisplayName("Sản phẩm")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        
        [DisplayName("Sản phẩm")]
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}