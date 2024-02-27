using Day1WebApi.Interface;
using System.ComponentModel.DataAnnotations;

namespace Day1WebApi.Validation
{
    public class UniqueeNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IDepartmentRep deptRepo = (IDepartmentRep)validationContext.GetService(typeof(IDepartmentRep));

            string name = value as string;

            if (deptRepo.GetbyName(name) != null)
            {
                return new ValidationResult($"{name} is already taken by another Department");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
