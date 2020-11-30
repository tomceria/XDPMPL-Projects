using System.Collections.Generic;
using System.ComponentModel;

namespace TodoList.ViewModels
{
    public class AccountLoginVm
    {
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        
        public List<FormResult> FormResults { get; set; }

        public void Deconstruct(out string username, out string password)
        {
            username = Username;
            password = Password;
        }
    }
}