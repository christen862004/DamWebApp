using System.ComponentModel.DataAnnotations;

namespace DamWebApp.Models
{
    //Server Side Only (web api | Mvc)
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            Employee EmpFromReq=(Employee) validationContext.ObjectInstance;
            //email false | true
            string email = value.ToString();
            //ITIContext context = new ITIContext();create
            ITIContext context = validationContext.GetService<ITIContext>();//ask server provider for ITIContext
            //check with email before
            Employee empFromDb = context.Employees
                .FirstOrDefault(e => e.Email == email && e.DepartmentId == EmpFromReq.DepartmentId);
            if (empFromDb == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email already Exist");
          
        }
    }
}
