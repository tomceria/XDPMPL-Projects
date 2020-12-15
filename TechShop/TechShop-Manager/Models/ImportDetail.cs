using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    public class ImportDetail
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        [ForeignKey("Import")]
        public int ImportId { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Import Import { get; set; }
    }
}