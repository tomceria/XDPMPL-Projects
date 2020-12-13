using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    public partial class Combo
    {
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
    }
}