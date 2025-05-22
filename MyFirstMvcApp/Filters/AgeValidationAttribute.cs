using System.ComponentModel.DataAnnotations;

namespace MyFirstMvcApp.Filters
{
    public class AgeValidationAttribute:ValidationAttribute
    {
        public AgeValidationAttribute() { }
        public int MinimumAge { get; set; } = 18;
        public int MaximumAge { get; set; } = 100;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("value is null");
            }
            if (value is not DateTime dateTime)
            {
                return new ValidationResult("value is not a DateTime");
            }
            var age = DateTime.Now.Year - dateTime.Year;
            if (dateTime > DateTime.Now.AddYears(-age))
            {
                age--;
            }
            if (age < MinimumAge)
            {
                return new ValidationResult($"You must be at least {MinimumAge} years old to register.");
            }
            if (age > MaximumAge)
            {
                return new ValidationResult($"You must be at most {MaximumAge} years old to register.");
            }

            return ValidationResult.Success;
            
        }
    }
}
