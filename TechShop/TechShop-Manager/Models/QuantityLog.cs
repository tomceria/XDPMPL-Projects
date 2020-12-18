using System;
using System.ComponentModel;

namespace TechShop_Manager.BUS
{
    public partial class QuantityLog
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        [DisplayName("Ngày giờ")]
        public DateTime Date { get; set; }
        
        [DisplayName("Sản phẩm")]
        public virtual Product Product { get; set; }
    }
}