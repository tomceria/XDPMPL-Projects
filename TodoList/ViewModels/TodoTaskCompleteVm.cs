using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoTaskCompleteVm : IValidatableObject
    {
        public int TodoTaskId { get; set; }
        public TaskStatus TodoTaskStatus { get; set; }
        public DateTime? TodoTaskCompleteDate { get; set; }
        public bool TodoTaskIsOverdue { get; set; }
        
        public bool IsAssigned { get; set; }
        
        [DisplayName("Hoàn tất")]
        public bool WillComplete { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.WillComplete != true)
            {
                // TODO: This won't appear because ModelState doesn't persist on RedirectToAction. Need fix
                yield return new ValidationResult("Vui lòng đánh dấu vào ô trên trước khi xác nhận.",
                    new[] {"WillComplete"});
            }
        }
    }
}