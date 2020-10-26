namespace TodoList.Models
{
    public enum Level
    {
        A = 0, B = 1
    }
    public class NhanVien
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Level Level { get; set; }
    }
}