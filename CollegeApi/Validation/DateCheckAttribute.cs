using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace CollegeApi.Validation
{
    public class DateCheckAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date= (DateTime?)value;
            if (date <DateTime.Now)
            {
                return new ValidationResult("Admission Date Should be Greater Than  Current Date");
            }
            return ValidationResult.Success;
        }
       
    }
}
