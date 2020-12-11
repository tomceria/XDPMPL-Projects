using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechShop_Web.Models
{
    public class Customer
    {
        [DisplayName("Mã KH")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        [DisplayName("Tên")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Họ không được bỏ trống.")]
        [DisplayName("Họ")]
        public string LastName { get; set; }

        public string Email { get; set; }
        
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        
        [Column(TypeName="date")] 
        public DateTime DOB { get; set; }
        
        [Column(TypeName="text")] 
        public string Address { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        [DisplayName("Tên")]
        public string FullName => $"{LastName} {FirstName}"; 
    }
}