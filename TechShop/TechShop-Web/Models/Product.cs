using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [DisplayName("Tên Sản phẩm")]
        public string Name { get; set; }
        
        [DisplayName("Mã hiển thị")]
        public string Slug { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        [DisplayName("Nhà sản xuất")]
        public string Manufacturer { get; set; }
        
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
    }
}