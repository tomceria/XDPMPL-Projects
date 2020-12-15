using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public enum ActivityType
    {
        [Display(Name = "Tạo")] Create,
        [Display(Name = "Chỉnh sửa")] Edit,
        [Display(Name = "Đánh dấu hoàn tất")] Complete,
        [Display(Name = "Bình luận")] AddComment,
        [Display(Name = "Xoá")] Delete
    }
    
    public class ActivityLog
    {
        public int Id { get; set; }
        
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        
        [DisplayName("Thao tác")]
        public ActivityType ActivityType { get; set; }
        
        [DisplayName("Thời gian")]
        public DateTime CreatedAt { get; set; }
        
        [DisplayName("Người thực hiện")]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        
        [DisplayName("Công việc")]
        [ForeignKey("TodoTask")]
        public int? TodoTaskId { get; set; }
        
        public virtual Staff Staff { get; set; }
        public virtual TodoTask TodoTask { get; set; }
    }
}