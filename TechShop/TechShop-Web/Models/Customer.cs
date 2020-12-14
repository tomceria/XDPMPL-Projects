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
        
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        public string FirstName { get; set; }
        
        [DisplayName("Họ")]
        [Required(ErrorMessage = "Họ không được bỏ trống.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email không được bỏ trống.")]
        public string Email { get; set; }
        
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống.")]
        public string PhoneNumber { get; set; }
        
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được bỏ trống.")]
        [Column(TypeName="date")] 
        public DateTime DOB { get; set; }
        
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống.")]
        [Column(TypeName="text")] 
        public string Address { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        [DisplayName("Tên")]
        public string FullName => $"{LastName} {FirstName}"; 
    }
}