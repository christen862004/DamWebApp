using System.ComponentModel.DataAnnotations;

namespace DamWebApp.Models
{
    public class GreaterThanAttribute:ValidationAttribute
    {
        int _min;
        public string XYZ { get; set; }
        public GreaterThanAttribute(int min)
        {
            _min= min;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int salary =int.Parse(value.ToString());
            if (salary > _min)
                return ValidationResult.Success;
            else
                return new ValidationResult($"Salary Must be greater than {_min}");
        }
    }
}
