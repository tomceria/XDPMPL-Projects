using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Manager.BUS
{
    public partial class Order
    {
        [DisplayName("Mã HĐ")]
        public int Id { get; set; }
        
        [DisplayName("Ngày giờ đặt hàng")]
        public DateTime Date { get; set; }
        
        [DisplayName("Thành tiền")]
        [Column(TypeName="bigint")] 
        public int PaidPrice { get; set; }
        
        [DisplayName("Tên Combo")]
        public string? ComboName { get; set; }
        
        [DisplayName("Địa chỉ nhận hàng")]
        [Column(TypeName="text")] 
        public string DeliveryAddress { get; set; }
        
        [DisplayName("Khách hàng")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        [DisplayName("Khách hàng")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}