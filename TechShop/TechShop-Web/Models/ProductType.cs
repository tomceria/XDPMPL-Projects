using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        
        [DisplayName("Tên Phân loại")]
        public string Name { get; set; }
        
        [DisplayName("Mã hiển thị")]
        public string Slug { get; set; }
        
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        
        [DisplayName("Mô tả")]
        [ForeignKey("ParentType")]
        public int? ParentTypeId { get; set; }
        
        public virtual ProductType ParentType { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}