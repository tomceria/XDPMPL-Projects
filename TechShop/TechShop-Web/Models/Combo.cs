using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class Combo
    {
        public int Id { get; set; }
        
        [DisplayName("Tên Combo")]
        public string Name { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int Price { get; set; }
        
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
    }
}