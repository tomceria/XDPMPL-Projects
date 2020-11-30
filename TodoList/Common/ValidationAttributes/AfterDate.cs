using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TodoList.Common.ValidationAttributes
{
    public class AfterDate : ValidationAttribute
    {
        public AfterDate(String dateProperty)
        {
            DateProperty = dateProperty;
        }

        public String DateProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime) value;
            var targetDate = (DateTime) validationContext.ObjectType
                .GetProperty(this.DateProperty)
                ?.GetValue(validationContext.ObjectInstance);
            if (date > targetDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Ngày không hợp lệ.");
        }
    }
}