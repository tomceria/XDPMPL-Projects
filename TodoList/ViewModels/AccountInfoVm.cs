using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Common.ValidationAttributes;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AccountInfoVm
    {
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [Equals("Password", ErrorMessage = "Mật khẩu phải giống nhau.")]
        [DisplayName("Nhập lại Mật khẩu")]
        public string Password2 { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public void Deconstruct(out ApplicationUser applicationUser,  out string password)
        {
            applicationUser = ApplicationUser;
            password = Password;
        }
    }
}
