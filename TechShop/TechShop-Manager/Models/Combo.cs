using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TechShop_Manager.BUS
{
    [Table("Combos")]
    public partial class Combo
    {
        [DisplayName("Mã Combo")]
        public int Id { get; set; }

        [DisplayName("Tên Combo")] public string Name { get; set; }

        [DisplayName("Mã hiển thị")] public string Slug { get; set; }

        [DisplayName("Giá")]
        [Column(TypeName = "bigint")]
        public int Price { get; set; }

        public bool IsHidden { get; set; } = false;

        public virtual ICollection<ComboDetail> ComboDetails { get; set; }

        [NotMapped]
        [DisplayName("Số lượng SP")]
        public int DetailCount => this.ComboDetails.Count;

        [NotMapped]
        [DisplayName("Sản phẩm")]
        public string DetailSummary
        {
            get
            {
                var result = string.Join(", ", this.ComboDetails.Select(o => o.Product.Name));
                if (result.Length >= 30)
                {
                    result = result.Substring(0, 30) + "...";
                }

                return result;
            }
        }
    }
}