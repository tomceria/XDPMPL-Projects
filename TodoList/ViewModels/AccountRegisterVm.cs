using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AccountRegisterVm
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DisplayName("Nhập lại Mật khẩu")]
        public string Password2 { get; set; }
        
        public Staff Staff { get; set; }
        
        public List<FormResult> FormResults { get; set; }
    }
}