using System.ComponentModel.DataAnnotations;

namespace ThreeAPIDemo.Dtos
{
    public class TokenDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string  Password { get; set; }
    }
}