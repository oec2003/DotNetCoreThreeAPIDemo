using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ThreeAPIDemo.Services;
using ThreeAPIDemo.ValidationAtrributes;

namespace ThreeAPIDemo.Models
{
    public class User: IValidatableObject
    {
        [Required(ErrorMessage = "姓名不能为空")]
        public string  Name { get; set; }
        
        [EmailAddress(ErrorMessage = "邮件格式不正确")]
        public string  Email { get; set; }

        public string  Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == Email)
            {
                yield return new ValidationResult("名称不能和邮箱相等",
                    new []{nameof(Name),nameof(Email)});
            }
        }
    }
}