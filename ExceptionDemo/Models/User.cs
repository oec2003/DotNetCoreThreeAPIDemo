using System;
using System.ComponentModel.DataAnnotations;

namespace ExceptionDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]

        public string Name { get; set; }
        [Required(ErrorMessage = "用户编码不能为空")]
        public string Code { get; set; }
        
        public int ParentId { get; set; }
    }
}