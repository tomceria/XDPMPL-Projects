using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechShop_Web.Common.ValidationAttributes;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class AccountRegisterVm
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống.")]
        [DisplayName("Tên tài khoản")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [Equals("Password", ErrorMessage = "Mật khẩu phải giống nhau.")]
        [DisplayName("Nhập lại Mật khẩu")]
        public string Password2 { get; set; }
        
        public Customer Customer { get; set; }
        
        public void Deconstruct(out string username, out string password, out Customer customer)
        {
            username = Username;
            password = Password;
            customer = Customer;
        }
    }
}