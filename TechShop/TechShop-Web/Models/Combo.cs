using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TechShop_Web.Models
{
    public class Combo
    {
        [DisplayName("Mã Combo")]
        public int Id { get; set; }
        
        [DisplayName("Tên Combo")]
        public string Name { get; set; }
        
        [DisplayName("Mã hiển thị")]
        public string Slug { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        public bool IsHidden { get; set; } = false;
        
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }

        [NotMapped]
        [DisplayName("Giá gốc")]
        public int PriceOriginal
        {
            get
            {
                return ComboDetails?.Sum(comboDetail => comboDetail.Product.Price) ?? 0;
            }
        }
    }
}