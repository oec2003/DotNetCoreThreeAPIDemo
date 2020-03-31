using System.ComponentModel.DataAnnotations;
using ThreeAPIDemo.Models;

namespace ThreeAPIDemo.ValidationAtrributes
{
    public class NameNotEqualEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var user = validationContext.ObjectInstance as User;
            if (user.Name == user.Email)
            {
                return new ValidationResult("名称不能和邮箱相等",
                    new []{nameof(User)});
            }
            return ValidationResult.Success;
            
        }
    }
}