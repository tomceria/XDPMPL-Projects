using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourDuLich_GUI.Models
{
    public class Tour {
        [Key, Display(AutoGenerateField = false, Name = "Mã số tour")]
        public int ID { get; set; }

        [Required, Display(Name = "Tên gọi tour")]
        public string Name { get; set; }

        [Required, Display(Name = "Đặc điểm")]
        public string Description { get; set; }

        [Required, Display(Name = "Giá tham khảo")]
        public long PriceRef { get; set; }

        public virtual ICollection<TourDetail> TourDetails { get; set; }
        public virtual ICollection<TourPrice> TourPrices { get; set; }
    }
}
