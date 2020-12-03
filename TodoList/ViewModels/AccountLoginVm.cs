using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.ViewModels
{
    public class AccountLoginVm
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống.")]
        [DisplayName("Email")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        
        public void Deconstruct(out string username, out string password)
        {
            username = Username;
            password = Password;
        }
    }
}