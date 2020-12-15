#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [DisplayName("Ngày giờ đặt hàng")]
        public DateTime Date { get; set; }
        
        [DisplayName("Giá")]
        [Column(TypeName="bigint")] 
        public int PaidPrice { get; set; }
        
        [DisplayName("Tên Combo")]
        public string? ComboName { get; set; }
        
        [DisplayName("Địa chỉ nhận hàng")]
        [Column(TypeName="text")] 
        public string DeliveryAddress { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}