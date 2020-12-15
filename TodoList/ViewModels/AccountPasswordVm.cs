using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoList.Common.ValidationAttributes;

namespace TodoList.ViewModels
{
    public class AccountPasswordVm
    {
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [Equals("Password", ErrorMessage = "Mật khẩu phải giống nhau.")]
        [DisplayName("Nhập lại Mật khẩu")]
        public string Password2 { get; set; }
    }
}