using System.ComponentModel.DataAnnotations;

namespace TodoList.Common.ValidationAttributes
{
    public class Equals : ValidationAttribute
    {
        public string PropertyName { get; set; }

        public Equals(string propertyName)
        {
            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetValue = validationContext.ObjectType
                .GetProperty(this.PropertyName)
                ?.GetValue(validationContext.ObjectInstance);
            
            if (value == null || targetValue == null)
            {
                return new ValidationResult("Một trong hai là rỗng.");
            }

            if (value.Equals(targetValue))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Phải bằng nhau.");
        }
    }
}