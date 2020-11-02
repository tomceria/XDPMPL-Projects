using System.ComponentModel;

namespace TodoList.ViewModels
{
    public class AccountLoginVm
    {
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
    }
}